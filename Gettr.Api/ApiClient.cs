using System;
using System.Net.Http;
using System.Text.Json;
using System.Reflection;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Threading.Tasks;


using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Gettr.Api.Data;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace Gettr.Api
{
	//[Serializable]
	public class XAppAuth
	{
		public static readonly string HeaderName = "x-app-auth";
		public string user { get; set; }
		public string token { get; set; }
	}

	public partial class ApiClient
	{
		private const string OriginUrl = "https://www.gettr.com";
		private const string ApiBaseUrl = "https://api.gettr.com";
		private const string UploadBaseUrl = "https://upload.gettr.com";

		private const string USERAGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36";
		private readonly XAppAuth xappauth;

		private readonly HttpClient http;

		private int Timeout;

		// Login on gettr.com with browser, chrome developer tools, search for api calls, inspect x-app-auth request header for userid and token

		public ApiClient(string UserId, string Token, int Timeout = 5000)
		{
			this.Timeout = Timeout;

			xappauth = new XAppAuth()
			{
				user = UserId,
				token = Token
			};

			http = new HttpClient()
			{
				BaseAddress = new Uri(ApiBaseUrl),
				Timeout = TimeSpan.FromMilliseconds(this.Timeout)
			};

			//var header = new ProductHeaderValue("Gettr.Api", this.GetType().GetTypeInfo().Assembly.GetName().Version.ToString());

			//http.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(header));

			http.DefaultRequestHeaders.UserAgent.TryParseAdd(USERAGENT);

			http.DefaultRequestHeaders.Add(XAppAuth.HeaderName, JsonSerializer.Serialize(xappauth));
		}

		private async Task<XResp<T>> GetXRespAsync<T>(string url)
		{
			try
			{
				var sw = Stopwatch.StartNew();

				var response = await http.GetAsync(url);

				response.EnsureSuccessStatusCode();

				var result = await response.Content.ReadFromJsonAsync<XResp<T>>();

				if (sw.ElapsedMilliseconds > 1000)
					Debug.WriteLine($"call {url} took {sw.ElapsedMilliseconds}mS");

				return result;
			}
			catch (Exception eee)
			{
				return new XResp<T> { rc = $"ERROR: {eee.Message}" };
			}
		}

		private async Task<XResp<T>> PostMultipartFormDataAsync<T>(string url, object request)
		{
			try
			{
				var sw = Stopwatch.StartNew();

				var multipartFormDataContent = new MultipartFormDataContent();

				var content = new StringContent(JsonSerializer.Serialize(request));
				content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
				{
					Name = "content",
				};
				multipartFormDataContent.Add(content);

				var http = new HttpClient()
				{
					BaseAddress = new Uri(ApiBaseUrl),
					Timeout = TimeSpan.FromMilliseconds(this.Timeout)
				};
				http.DefaultRequestHeaders.UserAgent.TryParseAdd(USERAGENT);

				http.DefaultRequestHeaders.Add(XAppAuth.HeaderName, JsonSerializer.Serialize(xappauth));

				http.DefaultRequestHeaders.Add("enctype", "multipart/form-data");

				var response = await http.PostAsync(url, multipartFormDataContent);

				response.EnsureSuccessStatusCode();

				var result = await response.Content.ReadFromJsonAsync<XResp<T>>();

				if (sw.ElapsedMilliseconds > 1000)
					Debug.WriteLine($"call {url} took {sw.ElapsedMilliseconds}mS");

				return result;
			}
			catch (Exception eee)
			{
				return new XResp<T> { rc = $"ERROR: {eee.Message}" };
			}
		}

		private async Task<XResp<UploadResult>> UploadImageAsync(string FilePath)
		{
			try
			{
				var sw = Stopwatch.StartNew();

				var data = File.ReadAllBytes(FilePath);

				var http = new HttpClient()
				{
					BaseAddress = new Uri(UploadBaseUrl),
					Timeout = TimeSpan.FromMilliseconds(this.Timeout)
				};

				var filename = Path.GetFileName(FilePath);

				var filetype = "image/png";
				switch(Path.GetExtension(filename))
				{
					default:
						break;
					case ".gif":
						filetype = "image/gif";
						break;
					case ".png":
						filetype = "image/png";
						break;
					case ".jpg":
					case ".jpeg":
					case ".jfif":
						filetype = "image/jpeg";
						break;
				}


				http.DefaultRequestHeaders.Clear();
				http.DefaultRequestHeaders.Add("Accept", "*/*");
				http.DefaultRequestHeaders.Add("Authorization", this.xappauth.token);
				http.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
				http.DefaultRequestHeaders.Add("Connection", "keep-alive");
				http.DefaultRequestHeaders.Add("env", "prod");
				http.DefaultRequestHeaders.Add("filename", filename);
				http.DefaultRequestHeaders.Add("Host", "upload.gettr.com");
				http.DefaultRequestHeaders.Add("Origin", OriginUrl);
				http.DefaultRequestHeaders.Add("Referer", OriginUrl);
				http.DefaultRequestHeaders.Add("Tus-Resumable", "1.0.0");
				http.DefaultRequestHeaders.Add("Upload-Length", data.Length.ToString());
				http.DefaultRequestHeaders.Add("Upload-Metadata", $"filename {Convert.ToBase64String(Encoding.UTF8.GetBytes(filename))},filetype {Convert.ToBase64String(Encoding.UTF8.GetBytes(filetype))}");
				http.DefaultRequestHeaders.UserAgent.TryParseAdd(USERAGENT);
				http.DefaultRequestHeaders.Add("userid", this.xappauth.user);

				var response = await http.PostAsync("/media/big/upload", new ByteArrayContent(new byte[0]));

				response.EnsureSuccessStatusCode(); // 201
				response.Headers.TryGetValues("location", out IEnumerable<string> locations);
				var location = locations.ToList()[0];

				http.DefaultRequestHeaders.Remove("Upload-Length");
				http.DefaultRequestHeaders.Remove("Upload-Metadata");
				http.DefaultRequestHeaders.Add("Upload-Offset", "0");

				var content = new ByteArrayContent(data);
				content.Headers.ContentType = new MediaTypeHeaderValue("application/offset+octet-stream");
				response = await http.PatchAsync(location, content); // not in netstandard2.0
				response.EnsureSuccessStatusCode();


				var result = await response.Content.ReadFromJsonAsync<UploadResult>();

				using var md5 = MD5.Create();
				var hash = BitConverter.ToString(md5.ComputeHash(data)).Replace("-", "").ToLower();

				if (hash != result.md5)
					throw new Exception($"Hash uploade file does not match {hash} != {result.md5}");

				// result.ori = "group4/origin/2022/01/14/11/d3d37865-85d2-e420-1efe-e1a1cbff3400/0a5d1cd1c5af4b45bd5c02d011b36b13.png"
				// https://media.gettr.com/group4/origin/2022/01/14/11/d3d37865-85d2-e420-1efe-e1a1cbff3400/0a5d1cd1c5af4b45bd5c02d011b36b13.png

				if (sw.ElapsedMilliseconds > 1000)
					Debug.WriteLine($"call uploading file took {sw.ElapsedMilliseconds}mS");

				return new XResp<UploadResult>() { _t = "xresp", rc = "OK", result = result };
			}
			catch (Exception eee)
			{
				return new XResp<UploadResult> { _t = "xresp", rc = $"ERROR: {eee.Message}" };
			}
		}

	}
}
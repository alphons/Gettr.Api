using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;

using Gettr.Api.Data;

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
		private const string ApiBaseUrl = "https://api.gettr.com";

		private readonly XAppAuth xappauth;

		private readonly HttpClient http;

		// Login on gettr.com with browser, chrome developer tools, search for api calls, inspect x-app-auth request header for userid and token

		public ApiClient(string UserId, string Token, int Timeout = 5000)
		{
			xappauth = new XAppAuth()
			{
				user = UserId,
				token = Token
			};

			http = new HttpClient()
			{
				BaseAddress = new Uri(ApiBaseUrl),
				Timeout = TimeSpan.FromMilliseconds(Timeout)
			};

			ProductHeaderValue header = new ("Gettr.Api", this.GetType().GetTypeInfo().Assembly.GetName().Version.ToString());

			http.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(header));

			//http.DefaultRequestHeaders.UserAgent.TryParseAdd($"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36");

			http.DefaultRequestHeaders.Add(XAppAuth.HeaderName, JsonSerializer.Serialize(xappauth));
		}

		private async Task<XResp<T>> GetWrappedAsync<T>(string url)
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



	}
}
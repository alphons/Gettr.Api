using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

using Gettr.Api.Data;

namespace Gettr.Api
{
	public partial class ApiClient
	{
		public async Task<XResp<bool>> ProfileAsync()
		{
			var url = $@"/u/live/profile";

			return await GetXRespAsync<bool>(url);
		}

		public async Task<XResp<QueryFirebaseHistory.Result>> QueryFirebaseHistoryAsync(int max = 20, string action = "ls", bool ifRefresh = true)
		{
			var url = $@"/u/user/{xappauth.user}/query_firebase_history?max={max}";

			if (action != null)
				url += $"&action={action}";

			if (ifRefresh)
				url += $"&ifRefresh={ifRefresh}";

			return await GetXRespAsync<QueryFirebaseHistory.Result>(url);
		}

		public async Task<XResp<PublicGlobals.Result>> PublicGlobalsAsync()
		{
			var url = $@"/u/public_globals";

			return await GetXRespAsync<PublicGlobals.Result>(url);
		}

		public async Task<XResp<string>> MutesAsync(string UserId)
		{
			var url = $@"/u/user/{xappauth.user}/mutes/{UserId}";

			return await GetXRespAsync<string>(url);
		}

		public async Task<XResp<string>> BlocksAsync(string UserId)
		{
			var url = $@"/u/user/{xappauth.user}/blocks/{UserId}";

			return await GetXRespAsync<string>(url);
		}

		public async Task<XResp<Result<ActionActivity>>> TimelineAsync(int offset = 0, int max = 20, string dir = "fwd", string incl = "posts|stats|userinfo|shared|liked", DateTimeOffset? StartTs = null, string merge = "shares")
		{
			var startTs = StartTs == null ? DateTimeOffset.Now.ToUnixTimeMilliseconds() : StartTs.Value.ToUnixTimeMilliseconds();

			var url = $@"/u/user/{xappauth.user}/timeline?offset={offset}&max={max}&dir={dir}&incl={incl}&startTs={startTs}&merge={merge}";

			return await GetXRespAsync<Result<ActionActivity>>(url);
		}

		public async Task<XResp<Result<ActionActivity>>> UserInfoAsync(string UserId)
		{
			var url = $@"/s/uinf/{UserId}";

			return await GetXRespAsync<Result<ActionActivity>>(url);
		}

		public enum FPEnum
		{
			/// <summary>
			/// Posts
			/// </summary>
			f_uo,
			/// <summary>
			/// Replies
			/// </summary>
			f_uc,
			/// <summary>
			/// Media
			/// </summary>
			f_um,
			/// <summary>
			/// Likes
			/// </summary>
			f_ul
		}

		public async Task<XResp<Result<ActionActivity>>> PostsAsync(int offset=0, int max = 20, string dir = "fwd", string incl = "posts|stats|userinfo|shared|liked", FPEnum fp = FPEnum.f_uo)
		{
			var url = $@"/u/user/{xappauth.user}/posts?offset={offset}&max={max}&dir={dir}&incl={incl}&fp={fp}";

			return await GetXRespAsync<Result<ActionActivity>>(url);
		}

		public async Task<XResp<Result<string>>> FollowersAsync(int offset = 0, int max = 20, string incl = "userstats|userinfo|followings|followers")
		{
			var url = $@"/u/user/{xappauth.user}/followers/?offset=0&max=20&incl=userstats|userinfo|followings|followers";

			return await GetXRespAsync<Result<string>>(url);
		}

		public async Task<XResp<Result<string>>> FollowingAsync(int offset = 0, int max = 20, string incl = "userstats|userinfo|followings|followers")
		{
			var url = $@"/u/user/{xappauth.user}/followings/?offset=0&max=20&incl=userstats|userinfo|followings|followers";

			return await GetXRespAsync<Result<string>>(url);
		}

		// {"data":{"acl":{"_t":"acl"},"_t":"post","txt":"Test👍","udate":1642160207331,"cdate":1642160207331,"uid":"alphons"
		// ,"imgs":["group4/origin/2022/01/14/11/d3d37865-85d2-e420-1efe-e1a1cbff3400/0a5d1cd1c5af4b45bd5c02d011b36b13.png"],"vid_wid":800,"vid_hgt":600,"meta":[{}]},"aux":null,"serial":"post"}

		public async Task<XResp<PostResult>> DoPostAsync(string text, string ImagePath = null)
		{
			var url = $@"/u/post";

			var request = new PostRequest()
			{
				data = new PostRequest.Data()
				{
					acl = new PostRequest.Acl() { _t = "acl" },
					_t = "post",
					txt = text,
					udate = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
					cdate = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
					uid = this.xappauth.user,
					meta = new List<PostRequest.Meta>()
				},
				aux = null,
				serial = "post"
			};

			if (ImagePath != null)
			{
				var response = await UploadImageAsync(ImagePath);
				request.data.imgs = new List<string>() { response.result.ori };

#pragma warning disable CA1416 // Validate platform compatibility
				using (var bmp = Image.FromFile(ImagePath))
				{
					request.data.vid_wid = bmp.Width;
					request.data.vid_hgt = bmp.Height;
				}
#pragma warning restore CA1416 // Validate platform compatibility
			}

			return await PostMultipartFormDataAsync<PostResult>(url, request);
		}

	}
}

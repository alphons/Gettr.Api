using System;
using System.Threading.Tasks;

using Gettr.Api.Data;

namespace Gettr.Api
{
	public partial class ApiClient
	{
		public async Task<XResp<bool>> ProfileAsync()
		{
			var url = $@"/u/live/profile";

			return await GetWrappedAsync<bool>(url);
		}

		public async Task<XResp<QueryFirebaseHistory.Result>> QueryFirebaseHistoryAsync(int max = 20, string action = "ls", bool ifRefresh = true)
		{
			var url = $@"/u/user/{xappauth.user}/query_firebase_history?max={max}";

			if (action != null)
				url += $"&action={action}";

			if (ifRefresh)
				url += $"&ifRefresh={ifRefresh}";

			return await GetWrappedAsync<QueryFirebaseHistory.Result>(url);
		}

		public async Task<XResp<PublicGlobals.Result>> PublicGlobalsAsync()
		{
			var url = $@"/u/public_globals";

			return await GetWrappedAsync<PublicGlobals.Result>(url);
		}

		public async Task<XResp<string>> MutesAsync(string UserId)
		{
			var url = $@"/u/user/{xappauth.user}/mutes/{UserId}";

			return await GetWrappedAsync<string>(url);
		}

		public async Task<XResp<string>> BlocksAsync(string UserId)
		{
			var url = $@"/u/user/{xappauth.user}/blocks/{UserId}";

			return await GetWrappedAsync<string>(url);
		}

		public async Task<XResp<ElementResult<ElementList>>> TimelineAsync(int offset = 0, int max = 20, string dir = "fwd", string incl = "posts|stats|userinfo|shared|liked", DateTimeOffset? StartTs = null, string merge = "shares")
		{
			var startTs = StartTs == null ? DateTimeOffset.Now.ToUnixTimeMilliseconds() : StartTs.Value.ToUnixTimeMilliseconds();

			var url = $@"/u/user/{xappauth.user}/timeline?offset={offset}&max={max}&dir={dir}&incl={incl}&startTs={startTs}&merge={merge}";

			return await GetWrappedAsync<ElementResult<ElementList>>(url);
		}

		public async Task<XResp<ElementResult<ElementList>>> UserInfoAsync(string UserId)
		{
			var url = $@"/s/uinf/{UserId}";

			return await GetWrappedAsync<ElementResult<ElementList>>(url);
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

		public async Task<XResp<ElementResult<ElementList>>> PostsAsync(int offset=0, int max = 20, string dir = "fwd", string incl = "posts|stats|userinfo|shared|liked", FPEnum fp = FPEnum.f_uo)
		{
			var url = $@"/u/user/{xappauth.user}/posts?offset={offset}&max={max}&dir={dir}&incl={incl}&fp={fp}";

			return await GetWrappedAsync<ElementResult<ElementList>>(url);
		}

		public async Task<XResp<ElementResult<string>>> FollowersAsync(int offset = 0, int max = 20, string incl = "userstats|userinfo|followings|followers")
		{
			var url = $@"/u/user/{xappauth.user}/followers/?offset=0&max=20&incl=userstats|userinfo|followings|followers";

			return await GetWrappedAsync<ElementResult<string>>(url);
		}

		public async Task<XResp<ElementResult<string>>> FollowingAsync(int offset = 0, int max = 20, string incl = "userstats|userinfo|followings|followers")
		{
			var url = $@"/u/user/{xappauth.user}/followings/?offset=0&max=20&incl=userstats|userinfo|followings|followers";

			return await GetWrappedAsync<ElementResult<string>>(url);
		}

	}
}

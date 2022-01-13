
using Gettr.Api.Data;

namespace Gettr.Api
{
	public partial class ApiClient
	{
		public async Task<ResultWrapper<TimeLine.Result>> TimelineAsync(int offset = 0, int max = 20, string dir = "fwd", string incl = "posts|stats|userinfo|shared|liked", DateTimeOffset? StartTs = null, string merge = "shares")
		{
			var startTs = StartTs == null ? DateTimeOffset.Now.ToUnixTimeMilliseconds() : StartTs.Value.ToUnixTimeMilliseconds();

			var url = $@"/u/user/{xappauth.user}/timeline?offset={offset}&max={max}&dir={dir}&incl={incl}&startTs={startTs}&merge={merge}";

			return await GetWrappedAsync<TimeLine.Result>(url);
		}

		public async Task<ResultWrapper<UserInfo.Result>> UserInfoAsync(string UserId)
		{
			var url = $@"/s/uinf/{UserId}";

			return await GetWrappedAsync<UserInfo.Result>(url);
		}

		public async Task<ResultWrapper<QueryFirebaseHistory.Result>> QueryFirebaseHistoryAsync(int max = 20, string action = "ls", bool ifRefresh = true)
		{
			var url = $@"/u/user/{xappauth.user}/query_firebase_history?max={max}&action={action}";

			if (ifRefresh)
				url += $"&ifRefresh={ifRefresh}";

			return await GetWrappedAsync<QueryFirebaseHistory.Result>(url);
		}

		public async Task<ResultWrapper<Posts.Result>> PostsAsync(int offset=0, int max = 20, string dir = "fwd", string incl = "posts|stats|userinfo|shared|liked", string fp = "f_uo")
		{
			var url = $@"/u/user/{xappauth.user}/posts?offset={offset}&max={max}&dir={dir}&incl={incl}&fp={fp}";

			return await GetWrappedAsync<Posts.Result>(url);
		}

	}
}

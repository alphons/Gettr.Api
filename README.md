# Gettr.Api

netstandard2.0 / .NET Core 6 Api Library for Gettr.com

```
using Gettr.Api;

// Login on gettr.com with browser, chrome developer tools, search for api calls, inspect x-app-auth request header

var api = new ApiClient("user", ".....token.....");

var r01 = await api.TimelineAsync();

var r02 = await api.UserInfoAsync("alphons");

var r03a = await api.QueryFirebaseHistoryAsync(ifRefresh: true);

var r03b = await api.QueryFirebaseHistoryAsync(action:"ls");

var r03c = await api.QueryFirebaseHistoryAsync(action: "mc", ifRefresh: true);

var r03d = await api.QueryFirebaseHistoryAsync(max:1, action:null, ifRefresh:false);

var r04 = await api.PostsAsync();

var r04a = await api.PostsAsync(fp: ApiClient.FPEnum.f_uo); // Posts
var r04b = await api.PostsAsync(fp: ApiClient.FPEnum.f_uc); // Replies
var r04c = await api.PostsAsync(fp: ApiClient.FPEnum.f_um); // Media
var r04d = await api.PostsAsync(fp: ApiClient.FPEnum.f_ul); // Likes


var r05 = await api.ProfileAsync();

var r06 = await api.PublicGlobalsAsync();

var r07 = await api.MutesAsync("alphons"); // "nm" = no-mutes

var r08 = await api.BlocksAsync("alphons"); // "nb" = no-blocks

var r09 = await api.FollowersAsync();

var r10 = await api.FollowingAsync();


```

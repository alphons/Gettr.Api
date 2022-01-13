# Gettr.Api
.NET Core 6 Api Library for Gettr.com

```
using Gettr.Api;

// Login on gettr.com with browser, chrome developer tools, search for api calls, inspect x-app-auth request header

var api = new ApiClient("user", ".....token.....");

var r1 = await api.TimelineAsync();

var r2 = await api.UserInfoAsync("alphons");

var r3a = await api.QueryFirebaseHistoryAsync(ifRefresh: true);

var r3b = await api.QueryFirebaseHistoryAsync(action:"ls");

var r3c = await api.QueryFirebaseHistoryAsync(action: "mc", ifRefresh: true);

var r3d = await api.QueryFirebaseHistoryAsync(max:1, action:null, ifRefresh:false);

var r4 = await api.PostsAsync();

var r5 = await api.ProfileAsync();

var r6 = await api.PublicGlobalsAsync();

var r7 = await api.MutesAsync("alphons"); // "nm" = no-mutes

var r8 = await api.BlocksAsync("alphons"); // "nb" = no-blocks


```

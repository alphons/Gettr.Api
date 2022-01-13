# Gettr.Api
.NET Core 6 Api Library for Gettr.com

```
using Gettr.Api;

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var credentials = config.GetSection("GettrCredentials");

var api = new ApiClient(credentials["user"], credentials["token"]);

var r1 = await api.TimelineAsync();

var r2 = await api.UserInfoAsync("alphons");

var r3a = await api.QueryFirebaseHistoryAsync(ifRefresh: true);

var r3b = await api.QueryFirebaseHistoryAsync(action:"ls");

var r3c = await api.QueryFirebaseHistoryAsync(action: "mc", ifRefresh: true);

var r4 = await api.PostsAsync();

var r5 = await api.ProfileAsync();

```

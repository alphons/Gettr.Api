﻿using Gettr.Api;

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json.private") // for git, remove .private in production
    .Build();

var credentials = config.GetSection("GettrCredentials");

var api = new ApiClient(credentials["user"], credentials["token"], 30000);

//var r01 = await api.TimelineAsync();

//var r02 = await api.UserInfoAsync("alphons");

//var r03a = await api.QueryFirebaseHistoryAsync(ifRefresh: true);

//var r03b = await api.QueryFirebaseHistoryAsync(action:"ls");

//var r03c = await api.QueryFirebaseHistoryAsync(action: "mc", ifRefresh: true);

//var r03d = await api.QueryFirebaseHistoryAsync(max:1, action:null, ifRefresh:false);

//var r04 = await api.PostsAsync();

//var r05 = await api.ProfileAsync();

//var r06 = await api.PublicGlobalsAsync();

//var r07 = await api.MutesAsync("alphons"); // "nm" = no-mutes

//var r08 = await api.BlocksAsync("alphons"); // "nb" = no-blocks

//var r09 = await api.FollowersAsync();

//var r10 = await api.FollowingAsync();

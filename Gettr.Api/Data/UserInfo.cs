
namespace Gettr.Api.Data
{
	public class UserInfo
	{
		public class UserInfoData
		{
			public string udate { get; set; }
			public string _t { get; set; }
			public string _id { get; set; }
			public string nickname { get; set; }
			public string username { get; set; }
			public string ousername { get; set; }
			public string dsc { get; set; }
			public string status { get; set; }
			public string cdate { get; set; }
			public string lang { get; set; }
			public string ico { get; set; }
			public string bgimg { get; set; }
			public string location { get; set; }
			public string flw { get; set; }
			public string flg { get; set; }
		}

		public class Result
		{
			public UserInfoData data { get; set; }
			public object aux { get; set; }
			public string serial { get; set; }
		}
	}


}

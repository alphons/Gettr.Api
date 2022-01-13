
namespace Gettr.Api.Data
{
	public class Posts
	{

		public class Activity
		{
			public long cdate { get; set; }
			public string init_id { get; set; }
			public int init_lvl { get; set; }
			public string src_type { get; set; }
			public string src_id { get; set; }
			public string action { get; set; }
			public string tgt_type { get; set; }
			public string tgt_id { get; set; }
			public string tgt_oid { get; set; }
			public int tgt_lvl { get; set; }
			public string pstid { get; set; }
			public string uid { get; set; }
			public bool media { get; set; }
			public string _id { get; set; }
		}

		public class List
		{
			public long udate { get; set; }
			public string _t { get; set; }
			public long cdate { get; set; }
			public string receiver_id { get; set; }
			public Activity activity { get; set; }
			public string _id { get; set; }
			public string action { get; set; }
		}

		public class Data
		{
			public long udate { get; set; }
			public string _t { get; set; }
			public long cdate { get; set; }
			public List<List> list { get; set; }
			public string _id { get; set; }
		}

		public class Acl
		{
			public string _t { get; set; }
		}

		public class PostInfo
		{
			public long udate { get; set; }
			public Acl acl { get; set; }
			public string _t { get; set; }
			public long cdate { get; set; }
			public string _id { get; set; }
			public string txt { get; set; }
			public List<string> htgs { get; set; }
			public List<object> utgs { get; set; }
			public string uid { get; set; }
			public string txt_lang { get; set; }
		}

		public class Post
		{
			public PostInfo pnv4u9e8fa { get; set; }
		}

		public class SPst
		{
			public PostInfo pnv4u9e8fa { get; set; }
		}

		public class UserRecord
		{
			public string udate { get; set; }
			public string _t { get; set; }
			public string _id { get; set; }
			public string nickname { get; set; }
			public string username { get; set; }
			public string ousername { get; set; }
			public string status { get; set; }
			public string cdate { get; set; }
			public string lang { get; set; }
			public string ico { get; set; }
			public string bgimg { get; set; }
			public string flw { get; set; }
			public string flg { get; set; }
		}

		public class Uinf
		{
			public UserRecord alphons { get; set; }
		}

		public class Aux
		{
			public int cursor { get; set; }
			public int removed { get; set; }
			public object pinf { get; set; }
			public Post post { get; set; }
			public SPst s_pst { get; set; }
			public Uinf uinf { get; set; }
			public List<object> lks { get; set; }
			public List<object> shrs { get; set; }
		}

		public class Result
		{
			public Data data { get; set; }
			public Aux aux { get; set; }
			public string serial { get; set; }
		}



	}
}

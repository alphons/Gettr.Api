

namespace Gettr.Api.Data
{
	public class TimeLine
	{
		public class Meta
		{

		}

		public class Activity
		{
			public object cdate { get; set; }
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
			public string src_oid { get; set; }
			public string opid { get; set; }
			public string opuid { get; set; }
			public List<string> rpstIds { get; set; }
			public List<string> rusrIds { get; set; }
		}

		public class List
		{
			public object udate { get; set; }
			public string _t { get; set; }
			public object cdate { get; set; }
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
			public int pub { get; set; }
			public string _t { get; set; }
		}

		public class Meta2
		{
			public object heads { get; set; }
			public object wid { get; set; }
			public object hgt { get; set; }
			public Meta meta { get; set; }
		}

		public class TranslatesItem
		{
			public string pstid { get; set; }
			public string uid { get; set; }
			public long translatedDate { get; set; }
			public string sourceLang { get; set; }
			public string targetLang { get; set; }
			public string translatedPath { get; set; }
		}

		public class Translates
		{
			// 
			// TranslatesItem
		}

		public class Id_Post
		{
			public long udate { get; set; }
			public Acl acl { get; set; }
			public string _t { get; set; }
			public long cdate { get; set; }
			public string _id { get; set; }
			public string txt { get; set; }
			public List<string> imgs { get; set; }
			public string main { get; set; }
			public string vid_wid { get; set; }
			public string vid_hgt { get; set; }
			public List<object> utgs { get; set; }
			public string vis { get; set; }
			public List<Meta> meta { get; set; }
			public string uid { get; set; }
			public string txt_lang { get; set; }
			public Translates translates { get; set; }
			public int lkbpst { get; set; }
			public int cm { get; set; }
			public int shbpst { get; set; }
			public int vfpst { get; set; }
		}

		public class Head
		{
			public List<int> box { get; set; }
			public double score { get; set; }
		}



		public class Pnu5ao65df
		{
			public long udate { get; set; }
			public Acl acl { get; set; }
			public string _t { get; set; }
			public long cdate { get; set; }
			public string _id { get; set; }
			public string txt { get; set; }
			public List<object> utgs { get; set; }
			public string prevsrc { get; set; }
			public string previmg { get; set; }
			public string ttl { get; set; }
			public string dsc { get; set; }
			public string uid { get; set; }
			public string txt_lang { get; set; }
			public Translates translates { get; set; }
			public int lkbpst { get; set; }
			public int cm { get; set; }
			public int shbpst { get; set; }
			public int vfpst { get; set; }
		}


		public class NotherItem
		{
			public long udate { get; set; }
			public Acl acl { get; set; }
			public string _t { get; set; }
			public long cdate { get; set; }
			public string _id { get; set; }
			public string txt { get; set; }
			public string main { get; set; }
			public string vid_dur { get; set; }
			public string vid_wid { get; set; }
			public string vid_hgt { get; set; }
			public string vid { get; set; }
			public string ovid { get; set; }
			public List<string> utgs { get; set; }
			public string vis { get; set; }
			public string uid { get; set; }
			public string txt_lang { get; set; }
			public Translates translates { get; set; }
			public int lkbpst { get; set; }
			public int cm { get; set; }
			public int shbpst { get; set; }
			public int vfpst { get; set; }
		}

		public class Post // NotherItems?
		{

		}

		public class SPst // Notheritems?
		{

		}

		public class Id_Item2
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
			public int infl { get; set; }
			public string ico { get; set; }
			public string bgimg { get; set; }
			public string location { get; set; }
			public string website { get; set; }
			public string flw { get; set; }
			public string flg { get; set; }
		}



		public class Uinf // Id_Item2
		{

		}

		public class Aux
		{
			public int removed { get; set; }
			public string cursor { get; set; }
			public object pinf { get; set; }
			public Post post { get; set; }
			public SPst s_pst { get; set; }
			public Uinf uinf { get; set; }
			public List<string> lks { get; set; }
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

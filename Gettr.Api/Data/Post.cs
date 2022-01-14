
using System.Collections.Generic;

namespace Gettr.Api.Data
{
	public class Post
	{
		public long udate { get; set; }
		public Acl acl { get; set; }
		public string _t { get; set; }
		public long cdate { get; set; }
		public string _id { get; set; }
		public string txt { get; set; }
		public string[] imgs { get; set; }
		public string main { get; set; }
		public string vid_dur { get; set; }
		public string vid_wid { get; set; }
		public string vid_hgt { get; set; }
		public string vis { get; set; }
		public List<Meta> meta { get; set; }
		public string vid { get; set; }
		public string ovid { get; set; }
		public List<string> htgs { get; set; }
		public List<string> utgs { get; set; }
		public string prevsrc { get; set; }
		public string previmg { get; set; }
		public string ttl { get; set; }
		public string dsc { get; set; }
		public string uid { get; set; }
		public string txt_lang { get; set; }
		public Dictionary<string, Language> translates { get; set; }
		public int lkbpst { get; set; }
		public int cm { get; set; }
		public int shbpst { get; set; }
		public int vfpst { get; set; }
	}
}

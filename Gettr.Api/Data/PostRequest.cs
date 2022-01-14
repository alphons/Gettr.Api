
using System.Collections.Generic;

namespace Gettr.Api.Data
{
	public class PostRequest
	{
        public class Acl
        {
            public string _t { get; set; }
        }

        public class Meta
        {
        }

        public class Data
        {
            public Acl acl { get; set; }
            public string _t { get; set; }
            public string txt { get; set; }
            public long udate { get; set; }
            public long cdate { get; set; }
            public string uid { get; set; }
            public List<string> imgs { get; set; }
            public int vid_wid { get; set; }
            public int vid_hgt { get; set; }
            public List<Meta> meta { get; set; }
        }

        public Data data { get; set; }
		public object aux { get; set; }
		public string serial { get; set; }
	}
}

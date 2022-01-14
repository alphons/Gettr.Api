
using System.Collections.Generic;

namespace Gettr.Api.Data
{
	public class PostResult
	{
        public class RateLimit
        {
            public int min { get; set; }
            public int day { get; set; }
        }

        public class Aux
        {
            public RateLimit rateLimit { get; set; }
        }

        public class Data
        {
            public Acl acl { get; set; }
            public string txt { get; set; }
            public List<string> imgs { get; set; }
            public int vid_wid { get; set; }
            public int vid_hgt { get; set; }
            public List<Meta> meta { get; set; }
            public object htgs { get; set; }
            public List<object> utgs { get; set; }
            public string _t { get; set; }
            public string uid { get; set; }
            public long cdate { get; set; }
            public long udate { get; set; }
            public string txt_lang { get; set; }
            public string _id { get; set; }
        }

        public Data data { get; set; }
		public Aux aux { get; set; }
		public string serial { get; set; }
	}
}

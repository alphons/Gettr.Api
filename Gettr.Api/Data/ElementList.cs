

using System.Collections.Generic;

namespace Gettr.Api.Data
{
	public class ElementList
	{
		public long udate { get; set; }
		public string _t { get; set; }
		public long cdate { get; set; }
		public string receiver_id { get; set; }
		public ElementActivity activity { get; set; }
		public string _id { get; set; }
		public string action { get; set; }
	}
}

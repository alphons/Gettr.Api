

using System.Collections.Generic;

namespace Gettr.Api.Data
{
	public class ElementData
	{
		public long udate { get; set; }
		public string _t { get; set; }
		public long cdate { get; set; }
		public List<ElementList> list { get; set; }
		public string _id { get; set; }
	}
}

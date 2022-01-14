

using System.Collections.Generic;

namespace Gettr.Api.Data
{
	public class Data<T>
	{
		public long udate { get; set; }
		public string _t { get; set; }
		public long cdate { get; set; }
		public List<T> list { get; set; }
		public string _id { get; set; }
	}
}

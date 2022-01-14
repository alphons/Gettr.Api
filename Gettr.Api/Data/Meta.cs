
using System.Collections.Generic;

namespace Gettr.Api.Data
{
	public class Meta
	{
		public class Head
		{
			public List<int> box { get; set; }
			public double score { get; set; }
		}

		public class MetaData
		{
			public List<Head> heads { get; set; }
		}

		public bool auto_connect { get; set; }
		public int? wid { get; set; }
		public int? hgt { get; set; }

		public MetaData meta { get; set; }
	}
}

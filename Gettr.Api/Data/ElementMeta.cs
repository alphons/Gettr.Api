
namespace Gettr.Api.Data
{
	public class ElementMeta
	{
		public class Head
		{
			public List<int> box { get; set; }
			public double score { get; set; }
		}

		public class Meta
		{
			public List<Head> heads { get; set; }
		}

		public int wid { get; set; }
		public int hgt { get; set; }

		public Meta meta { get; set; }
	}
}

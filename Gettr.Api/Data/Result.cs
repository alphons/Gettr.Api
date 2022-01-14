

namespace Gettr.Api.Data
{
	public class Result<T>
	{
		public Data<T> data { get; set; }
		public Auxilery aux { get; set; }
		public string serial { get; set; }
	}
}



namespace Gettr.Api.Data
{
	public class ElementResult<T>
	{
		public ElementData<T> data { get; set; }
		public ElementAux aux { get; set; }
		public string serial { get; set; }
	}
}

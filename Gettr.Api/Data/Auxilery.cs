
using System.Collections.Generic;

namespace Gettr.Api.Data
{
	public class Auxilery
	{
		public int removed { get; set; }
		public object cursor { get; set; }
		public object pinf { get; set; }
		public Dictionary<string, Post> post { get; set; }
		public Dictionary<string, Post> s_pst { get; set; }
		public Dictionary<string, UserInfo> uinf { get; set; }
		public List<object> lks { get; set; }
		public List<object> shrs { get; set; }
	}
}

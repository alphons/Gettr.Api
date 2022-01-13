﻿
using System.Collections.Generic;

namespace Gettr.Api.Data
{
	public class ElementAux
	{
		public int removed { get; set; }
		public object cursor { get; set; }
		public object pinf { get; set; }
		public Dictionary<string, ElementPost> post { get; set; }
		public Dictionary<string, ElementPost> s_pst { get; set; }
		public Dictionary<string, ElementUserInfo> uinf { get; set; }
		public List<object> lks { get; set; }
		public List<object> shrs { get; set; }
	}
}

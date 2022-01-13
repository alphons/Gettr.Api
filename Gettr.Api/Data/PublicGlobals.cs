

namespace Gettr.Api.Data
{
	public class PublicGlobals
	{
		public class Globals
		{
			public string disable_signup { get; set; }
			public string disable_qs { get; set; }
			public string disable_sms { get; set; }
		}

		public class Result
		{
			public Globals globals { get; set; }
		}

	}
}


namespace Gettr.Api.Data
{
	public class QueryFirebaseHistory
	{
		public class Othr
		{
			public string i { get; set; }
			public string n { get; set; }
			public string o { get; set; }
			public string p { get; set; }
		}

		public class RecordList
		{
			public long msgId { get; set; }
			public string act { get; set; }
			public object cdate { get; set; }
			public string tid { get; set; }
			public string ttxt { get; set; }
			public string ttype { get; set; }
			public List<string> tmedia { get; set; }
			public object rid { get; set; }
			public object rtxt { get; set; }
			public List<object> rmedia { get; set; }
			public string lsurl { get; set; }
			public string ruid { get; set; }
			public List<Othr> othr { get; set; }
			public int count { get; set; }
		}

		public class Result
		{
			public List<RecordList> recordList { get; set; }
			public long next { get; set; }
			public bool isDone { get; set; }
		}



	}
}

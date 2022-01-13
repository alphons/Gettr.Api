

namespace Gettr.Api.Data
{
    public class XResp<T>
    {
        public string _t { get; set; } // xresp
        public string rc { get; set; } // OK, ERROR
        public T result { get; set; }
    }
}

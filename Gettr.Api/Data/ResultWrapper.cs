

namespace Gettr.Api.Data
{
    public class ResultWrapper<T>
    {
        public string _t { get; set; }
        public string rc { get; set; }
        public T result { get; set; }
    }
}

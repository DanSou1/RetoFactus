namespace RetoFactus.Models
{
    public class RootNumberRange
    {
        public NumberRangeResponse data { get; set; }
    }
    public class NumberRangeResponse
    {
        public List<RangeItems> data { get; set; }
    }
    public class RangeItems
    {
        public int id { get; set; }
        public string document { get; set; }
        public string prefix { get; set; }
    }
}
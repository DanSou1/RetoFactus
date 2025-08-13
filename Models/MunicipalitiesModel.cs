namespace RetoFactus.Models
{
    public class MunicipalitiesModel
    {
        public List<Municipalities> data { get; set; }

    }
    public class Municipalities
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string department { get; set; }
    }
}

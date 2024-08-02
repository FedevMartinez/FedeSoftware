namespace FedeSoftware.Models
{
    public class ProvinciaViewModel
    {
        public string id { get; set; }
        public string nombre { get; set; }

    }

    public class CentroideViewModel
    {
        public string lat { get; set; }
        public string log { get; set; }
    }
    public class ProvinciaResponseViewModel
    {
        public int cantidad { get; set; }
        public int inicio { get; set; }
        public string[] Parametros { get; set; }
        public List<ProvinciaViewModel> provincias { get; set; }
        public int total { get; set; }
    }
}

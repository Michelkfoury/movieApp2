using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication8
{
    public class moviedetails
    {

        public bool adult { get; set; }

        public string? imdb_id { get; set; } = string.Empty;


        public int budget { get; set; }

        public List<moviegenres>? genres { get; set; }



    }
    public class moviegenres
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace SCDFrontend.Models
{
    public class Installation
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string active_users { get; set; }
    }
}
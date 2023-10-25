using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.DB
{
    public class VerLists
    {
        [Key]
        public int list_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Visibility { get; set; }
        public DateTime Created_at { get; set; }
    }
}

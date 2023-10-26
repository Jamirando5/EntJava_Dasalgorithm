using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.ViewModel
{
    public class VerListModel
    {
        [Key]
        public int list_id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "List Name")]
        public string Name { get; set; }
        

        [Required(ErrorMessage = "*")]
        [Display(Name = "Description")]
        public string Description { get; set; }

       
        [Required(ErrorMessage = "*")]
        [Display(Name = "Visibility")]
        public string Visibility { get; set; }

        public DateTime Created_at { get; set; }
    }
    public class VerListsModel
    {
        public List<VerListModel> VerLists { get; set; }
    }

}

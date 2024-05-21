using System.ComponentModel.DataAnnotations;

namespace WebApplicationLumia.ViewModel
{
    public class UpdateTeamsVm
    {
        public int Id { get; set; }
        [StringLength(25, ErrorMessage = "Uzlug 25 i kece bilmez")]
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplicationLumia.Models
{
    public class Teams
    {

        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public string Description { get; set; }
        [MinLength(5)]
        [MaxLength(50)]

        public string   Position { get; set;}

        public string? ImgUrl { get; set; }

    }
}

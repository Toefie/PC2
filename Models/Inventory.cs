using System.ComponentModel.DataAnnotations;

namespace PcollectorV2.Models
{
    public class Inventory
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        // Relatie: één inventory heeft meerdere collecties
        public ICollection<Collection> Collections { get; set; }
    }
}

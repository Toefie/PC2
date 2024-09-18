using System.ComponentModel.DataAnnotations;

namespace PcollectorV2.Models
{
    public class Collection
    {
        [Key] // Explicitly mark CollectionID as the primary key
        public int CollectionID { get; set; }

        [Required]
        public string CollectionName { get; set; }

        // Foreign key for Inventory
        public int InventoryID { get; set; }
        public Inventory? Inventory { get; set; }

        // One collection can have many cards
        public ICollection<Card>? Cards { get; set; }
    }
}

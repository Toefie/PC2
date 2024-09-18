using Microsoft.EntityFrameworkCore;
using PcollectorV2.Models;

namespace PcollectorV2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=.;Initial Catalog=bla;Integrated Security=true;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure the CollectionID is properly seeded in the Collections table first
            modelBuilder.Entity<Collection>().HasData(new Collection
            {
                CollectionID = 1, // Primary key
                CollectionName = "Holo"
            });

            // Then seed the Card table with a valid CollectionID
            modelBuilder.Entity<Card>().HasData(new Card
            {
                ID = 2,
                Name = "Charizard",
                Condition = "Good Condition",
                BuyDate = DateTime.Now,
                BuyPrice = 23.00,
                CollectionName = "expensive",
                CollectionID = 1, // This must match the CollectionID in the Collections table
                CurrentPrice = 800,
                Description = "Met sleeve",
                Specialty = "PSA 10"
            });
        }
    }
}

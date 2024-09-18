namespace PcollectorV2.Models
{
    public class Card
    {
        public int ID {  get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public double BuyPrice { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime BuyDate { get; set; }
        public string Condition { get; set; }
        public string Specialty { get; set; }
        public string CollectionName { get; set; }

        //Foreign key collection
        public int CollectionID { get; set; }   

        //berekend prijs en slaat niet op in de db
        public double PriceDiffrence => BuyPrice - CurrentPrice;
    }
}

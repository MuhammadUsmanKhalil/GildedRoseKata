namespace GildedRoseKata
{
    public class AgedBrieItem : GildedRoseInventoryItem
    {
        public AgedBrieItem() 
        {
            Name = "Aged Brie";
        }

        public override void ProcessExpired()
        {           
            IncreaseQuality();
        }        

        public override void UpdateQuality()
        {
            IncreaseQuality();
        }
    }
}

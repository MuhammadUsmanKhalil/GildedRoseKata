namespace GildedRoseKata
{
    public class ConjuredItem : GildedRoseInventoryItem
    {
        public ConjuredItem() 
        {
            Name = "Conjured";
        }
        public override void ProcessExpired()
        {

        }

        public override void UpdateQuality()
        {
            DecreaseQuality();
            DecreaseQuality();
        }
    }
}

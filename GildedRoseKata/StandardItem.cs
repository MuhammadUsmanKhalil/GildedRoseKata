namespace GildedRoseKata
{
    internal class StandardItem : GildedRoseInventoryItem
    {
        public override void ProcessExpired()
        {
            DecreaseQuality();
        }        

        public override void UpdateQuality()
        {
            DecreaseQuality();
        }        
    }
}

namespace GildedRoseKata
{
    internal class SulfurasItem : GildedRoseInventoryItem
    {
        private static int  _qualityValue = 80;
        public SulfurasItem() 
        {
            Name = "Sulfuras, Hand of Ragnaros";
            Quality = _qualityValue;
        }

        public override void ProcessExpired()
        {
            
        }

        public override void UpdateExpiration()
        {
            
        }

        public override void UpdateQuality()
        {
        }
    }
}

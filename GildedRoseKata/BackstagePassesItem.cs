namespace GildedRoseKata
{
    internal class BackstagePassesItem : GildedRoseInventoryItem
    {
        public override void ProcessExpired()
        {
            Quality = _minQualityThreshold;
        }     
        
        public BackstagePassesItem()
        {
            Name = "Backstage passes to a TAFKAL80ETC concert";
        }

        public override void UpdateQuality()
        {            
            if (SellIn > 10)
            {
                IncreaseQuality();
            }

            else if (SellIn > 5)
            {
                IncreaseQuality(2);
            }

            else if (SellIn > 0)
            {
                IncreaseQuality(3);
            }
            else
                DecreaseQualityToZero();


        }
    }
}

namespace GildedRoseKata
{
    public abstract class GildedRoseInventoryItem : Item
    {
        private static int _maxQualityThreshold = 50;
        protected static int _minQualityThreshold = 0;
        
        protected void DecreaseQuality()
        {
            if (Quality > _minQualityThreshold)
            {
                Quality = Quality - 1;
            }
        }

        protected void DecreaseQualityToZero()
        {
            Quality = 0;
        }

        protected void IncreaseQuality(int NoOfDays = 1)
        {
            if (Quality < _maxQualityThreshold)
            {
                Quality = Quality + NoOfDays;
            }
        }
        
        public bool IsExpired() => SellIn < 0;
        public abstract void UpdateQuality();
        public abstract void ProcessExpired();

        public virtual void UpdateExpiration()
        {
            SellIn--;
        }

        public GildedRoseInventoryItem()
        {

        }
    }
}

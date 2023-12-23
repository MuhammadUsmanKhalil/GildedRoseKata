namespace GildedRoseKata
{
    public class GildedRoseInventoryItemsFactory
    {
        private static readonly string Conjured = "Conjured";
        private static readonly string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private static readonly string AgedBrie = "Aged Brie";
        private static readonly string Sulfuras = "Sulfuras, Hand of Ragnaros";

        private static Dictionary<string, Func<Item>> _inventoryItems = new()
        {
            [Conjured] = () => new ConjuredItem(),
            [BackstagePass] = () => new BackstagePassesItem(),
            [AgedBrie] = () => new AgedBrieItem(),
            [Sulfuras] = () => new SulfurasItem(),
        };

        public static Item CreateInventoryItem(string itemName)
        {
            if(_inventoryItems.ContainsKey(itemName))
                return _inventoryItems[itemName]();

            return new StandardItem();
        }
    }
}

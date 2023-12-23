namespace GildedRoseKata
{
    public class GildedRoseInventoryManager
    {
        private readonly List<Item> _items;
        public GildedRoseInventoryManager(List<Item> items)
        {
            _items = items;
        }

        public void UpdateInventory()
        {             
            foreach (var item in _items)
            {
                var inventoryItem = (GildedRoseInventoryItem)item;
                UpdateItem(inventoryItem);
            }            
        }

        private void UpdateItem(GildedRoseInventoryItem item)
        {            
            item.UpdateQuality();

            item.UpdateExpiration();

            if (item.IsExpired())
                item.ProcessExpired();
        }
    }
}
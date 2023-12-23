using GildedRoseKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestClass]
    public class GildedRoseTests
    {
        [TestMethod]
        public void GildedRose_StandardItemQualitySellIn_Decreases_EachyDay()
        {
            int startingSellIn = 5;
            int startingQuality = 7;

            var standardInventoryItem = GildedRoseInventoryItemsFactory.CreateInventoryItem("Elixir of the mongoose test item..");

            standardInventoryItem.Quality = startingQuality;
            standardInventoryItem.SellIn = startingSellIn;

            GildedRoseInventoryManager subject = new GildedRoseInventoryManager(new List<Item> { standardInventoryItem });

            subject.UpdateInventory();

            Assert.AreEqual(standardInventoryItem.SellIn, startingSellIn - 1);
            Assert.AreEqual(standardInventoryItem.Quality, startingQuality - 1);
        }

        [TestMethod]

        public void GildedRose_StandardItem_After_Expired_Quality_Decreases_Twice()
        {
            int startingSellIn = 5;
            int startingQuality = 12; 

            var standardInventoryItem = GildedRoseInventoryItemsFactory.CreateInventoryItem("Elixir of the mongoose test item expiry..");

            standardInventoryItem.Quality = startingQuality;
            standardInventoryItem.SellIn = startingSellIn;

            GildedRoseInventoryManager subject = new(new List<Item> { standardInventoryItem });

            var qualityBeforeExpiry = standardInventoryItem.Quality;

            subject.UpdateInventory();

            Assert.AreEqual(qualityBeforeExpiry - 1, standardInventoryItem.Quality);

            while (!((GildedRoseInventoryItem)standardInventoryItem).IsExpired())            
                subject.UpdateInventory();

            var qualityOnExpiry = standardInventoryItem.Quality;
            
            subject.UpdateInventory();

            var qualityAfterExpiry = standardInventoryItem.Quality;

            Assert.AreEqual(2, qualityOnExpiry - qualityAfterExpiry);
        }

        [TestMethod]
        public void GildedRose_SulfurasNeverLosingQuality_NeverSold_Remains_Fixed()
        {
            int sulfurasExpectedQuality = 80;
            int startingSellIn = 5;

            var sulfurasInventoryItem = GildedRoseInventoryItemsFactory.CreateInventoryItem("Sulfuras, Hand of Ragnaros");

            sulfurasInventoryItem.SellIn = startingSellIn;

            GildedRoseInventoryManager subject = new(new List<Item> { sulfurasInventoryItem });

            subject.UpdateInventory();

            Assert.AreEqual(sulfurasExpectedQuality, sulfurasInventoryItem.Quality);
            Assert.AreEqual(startingSellIn, sulfurasInventoryItem.SellIn);

        }        
      
        [TestMethod]
        public void GildedRose_AgedBrie_Quality_Increases_On_Each_Day()
        {
            int startingSellIn = 5;
            int startingQuality = 10;

            var agedBrieItem = GildedRoseInventoryItemsFactory.CreateInventoryItem("Aged Brie");

            agedBrieItem.SellIn = startingSellIn;
            agedBrieItem.Quality = startingQuality;

            GildedRoseInventoryManager subject = new(new List<Item> { agedBrieItem });

            subject.UpdateInventory();

            Assert.AreEqual(11, agedBrieItem.Quality);
            Assert.AreEqual(4, agedBrieItem.SellIn);
        }

        [TestMethod]

        public void GildedRose_BackstagePasses_Quality_Increases_By_3_When_SellIn_Days_LessThan_5()
        {
            int startingSellIn = 5;
            int startingQuality = 10;

            var backstagePasses = GildedRoseInventoryItemsFactory.CreateInventoryItem("Backstage passes to a TAFKAL80ETC concert");

            backstagePasses.SellIn = startingSellIn;
            backstagePasses.Quality = startingQuality;

            GildedRoseInventoryManager subject = new(new List<Item> { backstagePasses });

            subject.UpdateInventory();

            Assert.AreEqual(13, backstagePasses.Quality);            
        }

        [TestMethod]

        public void GildedRose_BackstagePasses_Quality_Increases_By_2_When_SellIn_Days_LessThan_11()
        {
            int startingSellIn = 8;
            int startingQuality = 10;

            var backstagePasses = GildedRoseInventoryItemsFactory.CreateInventoryItem("Backstage passes to a TAFKAL80ETC concert");

            backstagePasses.SellIn = startingSellIn;
            backstagePasses.Quality = startingQuality;

            GildedRoseInventoryManager subject = new(new List<Item> { backstagePasses });

            subject.UpdateInventory();

            Assert.AreEqual(12, backstagePasses.Quality);
        }

        [TestMethod]

        public void GildedRose_BackstagePasses_Quality_Increases_By_1_When_SellIn_Days_GreaterThan_10()
        {
            int startingSellIn = 12;
            int startingQuality = 10;

            var backstagePasses = GildedRoseInventoryItemsFactory.CreateInventoryItem("Backstage passes to a TAFKAL80ETC concert");

            backstagePasses.SellIn = startingSellIn;
            backstagePasses.Quality = startingQuality;

            GildedRoseInventoryManager subject = new(new List<Item> { backstagePasses });

            subject.UpdateInventory();

            Assert.AreEqual(11, backstagePasses.Quality);
        }

        [TestMethod]

        public void GildedRose_BackstagePasses_Quality_After_Concert()
        {
            int startingSellIn = 0;
            int startingQuality = 10;

            var backstagePasses = GildedRoseInventoryItemsFactory.CreateInventoryItem("Backstage passes to a TAFKAL80ETC concert");

            backstagePasses.SellIn = startingSellIn;
            backstagePasses.Quality = startingQuality;

            GildedRoseInventoryManager subject = new(new List<Item> { backstagePasses });

            subject.UpdateInventory();

            Assert.AreEqual(0, backstagePasses.Quality);
        }

        [TestMethod]

        public void GildedRose_Conjured_Decreases_Quality_Twice_Upon_InventoryUpdation()
        {
            int startingSellIn = 10;
            int startingQuality = 20;

            var backstagePasses = GildedRoseInventoryItemsFactory.CreateInventoryItem("Conjured");

            backstagePasses.SellIn = startingSellIn;
            backstagePasses.Quality = startingQuality;

            GildedRoseInventoryManager subject = new(new List<Item> { backstagePasses });

            subject.UpdateInventory();

            Assert.AreEqual(18, backstagePasses.Quality);
            Assert.AreEqual(9, backstagePasses.SellIn);
        }        
    }
}
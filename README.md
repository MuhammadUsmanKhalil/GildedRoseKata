# GildedRoseKata

## Tools

- Visual Studio
- C#

## Steps to run

- Load the entire solution in Visual studio and build the entire solution. It should compile without any errors
- Execute the tests in the unit test project.

## Choices and strategies made in the code.

- This entire method needed refactoring for maintaining and considering it as production code.
- I used Template design pattern for organizing the entire if-else logic within object oriented hierarchy. Set of classes will be considered as 'inventory' items.
- I didnt change Item.cs and item property in the code.
- Main logic is written within 'GildedRoseInventoryManager.cs' which calls other methods polymorphically.
- The whole logic is devided in three steps ( i.e. Updation of Quality of items, Updation of their expiry and finally based on expiry status, their individual processing )
- Dedicated unit tests are covering the entire functionality of the code.
  


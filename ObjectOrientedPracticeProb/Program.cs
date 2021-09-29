using System;
namespace ObjectOrientedPracticeProb.JSONInventoryDataManagement
{
    namespace ObjectOrientedPracticeProb
    {
        class Program
        {
            static string filepathJson = @"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\JSONInventoryDataManagement\Inventory.json";
            static string filepathInventoryList=@"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\InventoryManagementProgram\Inventory.json";
            static string filepathStockList = @"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\StockManagement\Stock.json";
            static void Main(string[] args)
            {
                InventoryManagementProgram.InventoryManger inventoryManger = new InventoryManagementProgram.InventoryManger();
                bool isExit = false;
                int options;
                while (!isExit)
                {
                    Console.WriteLine("Choose 1.JSONInventoryDataManagement 2.InventoryManagementProgram 3.StockManagement");
                    options = Convert.ToInt32(Console.ReadLine());
                    switch (options)
                    {
                        case 1:
                            InventoryMain inventoryMain = new InventoryMain();
                            inventoryMain.DisplayData(filepathJson);
                            break;
                        case 2:
                            inventoryManger.ReadData(filepathInventoryList);
                            inventoryManger.DisplayData("Rice");
                            inventoryManger.EditData("Pulse");
                            inventoryManger.DeleteData("Pulse");
                            inventoryManger.AddData("Pulse");
                            break;
                        case 3:
                            StockManagement.Stock stock = new StockManagement.Stock();
                            stock.ReadData(filepathStockList);
                            stock.DisplayData("hp");
                            break;
                        default:
                            Console.WriteLine("Choose valid option");
                            break;
                    }
                }
            }
        }
    }
}

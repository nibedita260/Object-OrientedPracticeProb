using System;
namespace ObjectOrientedPracticeProb.JSONInventoryDataManagement
{
    namespace ObjectOrientedPracticeProb
    {
        class Program
        {
            static string filepathJson = @"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\JSONInventoryDataManagement\Inventory.json";
            static string filepathInventoryList=@"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\InventoryManagementProgram\Inventory.json";
            static string filepathStockList = @"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\StockManagement\Transaction.json";
            static void Main(string[] args)
            {
                InventoryManagementProgram.InventoryManger inventoryManger = new InventoryManagementProgram.InventoryManger();
                StockManagement.Stock stock = new StockManagement.Stock();
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
                            //inventoryManger.DisplayData();
                            inventoryManger.EditData();
                            //inventoryManger.DeleteData();
                            //inventoryManger.AddData();
                            break;
                        case 3:
                            stock.ReadData(filepathStockList);
                            stock.DisplayStocks();
                            stock.BuyStocks();
                            //stock.SellStocks();
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

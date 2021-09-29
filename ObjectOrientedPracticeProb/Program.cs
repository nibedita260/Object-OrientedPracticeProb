using System;
namespace ObjectOrientedPracticeProb.JSONInventoryDataManagement
{
    namespace ObjectOrientedPracticeProb
    {
        class Program
        {
            static string filepathJson = @"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\JSONInventoryDataManagement\Inventory.json";
            static string filepathJsonList=@"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\InventoryManagementProgram\Inventory.json";
            static void Main(string[] args)
            {
                InventoryManagementProgram.InventoryManger inventoryManger = new InventoryManagementProgram.InventoryManger();
                bool isExit = false;
                int options;
                while (!isExit)
                {
                    Console.WriteLine("Choose 1.JSONInventoryDataManagement 2.InventoryManagementProgram");
                    options = Convert.ToInt32(Console.ReadLine());
                    switch (options)
                    {
                        case 1:
                            InventoryMain inventoryMain = new InventoryMain();
                            inventoryMain.DisplayData(filepathJson);
                            break;
                        case 2:
                            inventoryManger.ReadData(filepathJsonList);
                            inventoryManger.DisplayData("Rice");
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

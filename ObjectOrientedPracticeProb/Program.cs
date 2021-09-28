using System;
namespace ObjectOrientedPracticeProb.JSONInventoryDataManagement
{
    namespace ObjectOrientedPracticeProb
    {
        class Program
        {
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
                            inventoryMain.DisplayData(@"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\JSONInventoryDataManagement\Inventory.json");
                            break;
                        case 2:
                            inventoryManger.ReadData(@"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\InventoryManagementProgram\Inventory.json");
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

using System;
namespace ObjectOrientedPracticeProb.JSONInventoryDataManagement
{

    namespace ObjectOrientedPracticeProb
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool isExit = false;
                int options;
                while (!isExit)
                {
                    Console.WriteLine("Choose 1.JSONInventoryDataManagement");
                    options = Convert.ToInt32(Console.ReadLine());
                    switch (options)
                    {
                        case 1:
                            InventoryMain inventoryMain = new InventoryMain();
                            inventoryMain.DisplayData(@"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\JSONInventoryDataManagement\Inventory.json");
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

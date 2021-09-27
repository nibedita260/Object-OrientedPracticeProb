using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedPracticeProb.JSONInventoryDataManagement
{
    class InventoryMain
    {
        InventoryModel inventoryModel = new InventoryModel();
        List<InventoryModel> inventoryModels = new List<InventoryModel>();
        public void DisplayData(string filepath)
        {
            try
            {
                using (StreamReader r = new StreamReader(filepath))//@"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\JSONInventoryDataManagement\Inventory.json"
                {
                    var json = r.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<List<InventoryModel>>(json);
                    Console.WriteLine("Name\tWeight\tPrice");
                    foreach(var item in items)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", item.Name, item.Weight, item.Price);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

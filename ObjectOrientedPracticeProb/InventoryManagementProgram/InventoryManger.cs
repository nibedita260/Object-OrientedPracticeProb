using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedPracticeProb.InventoryManagementProgram
{
    class InventoryManger
    {
        public List<InventoryModel> Rice;
        public List<InventoryModel> Pulse;
        public List<InventoryModel> Wheat;
        public void ReadData(string filepath)
        {
            try
            {
                using (StreamReader r = new StreamReader(filepath))//@"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\InventoryManagementProgram\Inventory.json"
                {
                    var json = r.ReadToEnd();
                    InventoryFactory items = JsonConvert.DeserializeObject<InventoryFactory>(json);
                    Rice= items.RiceList;
                    Pulse = items.PulseList;
                    Wheat = items.WheatList;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DisplayData(string state)
        {
            Console.WriteLine("enter any one of state-[ Rice Or Pulse Or Wheat] which you want to display of that state Inventory");
            state=Console.ReadLine();
            try
            {
                if (state == "Rice")
                {
                    Console.WriteLine("Name\tWeight\tPrice");
                    foreach(var item in Rice)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", item.Name, item.Weight, item.Price);
                    }
                }
                if (state == "Pulse")
                {
                    Console.WriteLine("Name\tWeight\tPrice");
                    foreach (var item in Pulse)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", item.Name, item.Weight, item.Price);
                    }
                }
                if (state == "Wheat")
                {
                    Console.WriteLine("Name\tWeight\tPrice");
                    foreach (var item in Wheat)
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

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
        public List<InventoryFactory.Rice> Rice;
        public List<InventoryFactory.Pulse> Pulse;
        public List<InventoryFactory.Wheat> Wheat;
        public void ReadData(string filepath)
        {
            try
            {
                using (StreamReader r = new StreamReader(filepath))//@"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\InventoryManagementProgram\Inventory.json"
                {
                    var json = r.ReadToEnd();
                    Console.WriteLine(json);
                   // dynamic dObject = JObject.Parse(json);
                    InventoryFactory items = JsonConvert.DeserializeObject<InventoryFactory>(json);
                    Console.WriteLine(items);
                    Rice= items.RiceList;
                    Console.WriteLine(Rice);
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
                    foreach(var item in riceList)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", item.Name, item.Weight, item.Price);
                    }
                }
                if (state == "Pulse")
                {
                    Console.WriteLine("Name\tWeight\tPrice");
                    foreach (var item in pulseList)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", item.Name, item.Weight, item.Price);
                    }
                }
                if (state == "Wheat")
                {
                    Console.WriteLine("Name\tWeight\tPrice");
                    foreach (var item in wheatList)
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

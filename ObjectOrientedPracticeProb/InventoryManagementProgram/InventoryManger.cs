using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ObjectOrientedPracticeProb.InventoryManagementProgram
{
    class InventoryManger
    {
        static string filepath = @"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\InventoryManagementProgram\Inventory.json";
        public List<InventoryModel> Rice;
        public List<InventoryModel> Pulse;
        public List<InventoryModel> Wheat;
        InventoryFactory items = new InventoryFactory();
        public void ReadData(string filepath)
        {
            try
            {
                using (StreamReader r = new StreamReader(filepath))//@"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\InventoryManagementProgram\Inventory.json"
                {
                    var json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<InventoryFactory>(json);
                    Rice = items.RiceList;
                    Pulse = items.PulseList;
                    Wheat = items.WheatList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DisplayData()
        {
            Console.WriteLine("enter any one of state-[ Rice Or Pulse Or Wheat] which you want to display of that state Inventory");
            string state = Console.ReadLine();
            try
            {
                if (state == "Rice")
                {
                    Console.WriteLine("Name\tWeight\tPrice");
                    foreach (var item in Rice)
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void EditData()
        {
            Console.WriteLine("enter any one of state-[ Rice Or Pulse Or Wheat] which you want to edit of that state Inventory");
            string state = Console.ReadLine();
            if (state == "Rice")
            {
                Console.WriteLine("enter the Rice name which you want to edit");
                string name = Console.ReadLine();
                foreach (var item in Rice)
                {
                    if (item.Name == name)
                    {
                        Console.WriteLine("To edit RiceList enter 1. Weight 2.Price ");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                item.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                item.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose valid option");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("enter valid RiceName");
                    }
                }
                //serialize the string to json
                string output = JsonConvert.SerializeObject(Rice);
                File.WriteAllText(filepath, output, Encoding.UTF8);
            }

            if (state == "Pulse")
            {
                Console.WriteLine("enter the Pulse name which you want to edit");
                string name = Console.ReadLine();

                foreach (var item in Pulse)
                {
                    if (item.Name == name)
                    {
                        InventoryModel inventoryModel = new InventoryModel();
                        Console.WriteLine("To edit PulseList enter 1. Weight 2.Price ");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                item.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                item.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose valid option");
                                break;
                        }
                        inventoryModel = item;
                        return;
                    }
                }
                items.PulseList = Pulse;
                //serialize the string to json
                string output = JsonConvert.SerializeObject(Pulse);
                File.WriteAllText(filepath, output, Encoding.UTF8);

            }
        }
        public void DeleteData()
        {
            Console.WriteLine("enter any one of state-[ Rice Or Pulse Or Wheat] which you want to delete of that state Inventory");
            string state = Console.ReadLine();
            if (state == "Pulse")
            {
                Console.WriteLine("enter name to delete item of Pulse list");
                string name = Console.ReadLine();
                InventoryModel inventoryModel = new InventoryModel();
                foreach (var item in Pulse)
                {
                    if (item.Name == name)
                    {
                        inventoryModel = item;
                    }
                }
                Pulse.Remove(inventoryModel);
                items.PulseList = Pulse;
                //serialize the string to json
                string output = JsonConvert.SerializeObject(items);
                File.WriteAllText(filepath, output);
            }

        }
        public void AddData()
        {
            Console.WriteLine("enter any one of state-[ Rice Or Pulse Or Wheat] which you want to add of that state Inventory");
            string state = Console.ReadLine();
            if (state == "Pulse")
            {
                try
                {
                    InventoryModel item = new InventoryModel();
                    Console.WriteLine("enter Name of PulseList");
                    item.Name = Console.ReadLine();
                    Console.WriteLine("enter Weight of PulseList");
                    item.Weight = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter Price of PulseList");
                    item.Price = Convert.ToInt32(Console.ReadLine());
                    Pulse.Add(item);
                    Console.WriteLine("items added successfully in Pulselist ");
                    items.PulseList = Pulse;
                    //serialize the string to json
                    string output = JsonConvert.SerializeObject(items);
                    File.WriteAllText(filepath, output);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
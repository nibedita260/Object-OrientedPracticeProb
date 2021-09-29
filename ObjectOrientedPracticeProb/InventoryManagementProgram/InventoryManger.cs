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
        public void EditData(string state)
        {
            StringBuilder TheListBuilder = new StringBuilder();

            

            if (state == "Rice")
            {
                TheListBuilder.Append("'RiceList': [");
                Console.WriteLine("enter the Rice name[] which you want to edit");
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
                TheListBuilder.Append(output);
                TheListBuilder.Append("],");
                File.WriteAllText(filepath, output, Encoding.UTF8);
                Console.WriteLine(output);
                
            }

            if (state == "Pulse")
            {
                TheListBuilder.Append("PulseList: [");
                Console.WriteLine("enter the Pulse name[] which you want to edit");
                string name = Console.ReadLine();
                foreach (var item in Pulse)
                {
                    if (item.Name == name)
                    {
                        Console.WriteLine("To edit PulseList enter 1.name 2. Weight 3.Price ");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                item.Name = Console.ReadLine();
                                break;
                            case 2:
                                item.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 3:
                                item.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose valid option");
                                break;
                        }
                        break;
                    }
                }
                //serialize the string to json
                string output = JsonConvert.SerializeObject(Pulse);
                TheListBuilder.Append(output);
                TheListBuilder.Append("],");
                File.WriteAllText(filepath, output, Encoding.UTF8);
                Console.WriteLine(output);
                //JsonSerializer serializer = new JsonSerializer();
                //using (StreamWriter sw = new StreamWriter(filepath))
                //using (JsonWriter writer = new JsonTextWriter(sw))
                //{
                //    serializer.Serialize(writer, Rice);

                //}

            }
            TheListBuilder.Append("}");
            TheListBuilder.ToString();
        }
        public void DeleteData(string state)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (state == "Pulse")
            {
                foreach (var item in Pulse)
                {
                    Console.WriteLine("Do you want to delete the whole PulseList ,enter 1. Yes 2.No 3.only delete Pulse weight 4. only delete pulse price");
                    int options = Convert.ToInt32(Console.ReadLine());
                    switch (options)
                    {
                        case 1:
                            Pulse.RemoveAt(0);
                            break;
                        case 2:
                            break;
                        case 3:
                            Console.WriteLine("enter the specific Pulse name whose weight you want to delete");
                            string name = Console.ReadLine();
                            if (item.Name == name)
                                item.Weight = 0;
                            break;
                        case 4:
                            string namePulse = Console.ReadLine();
                            if (item.Name == namePulse)
                                item.Price = 0;
                            break;
                        default:
                            Console.WriteLine("Choose valid option");
                            break;
                    }
                    break;
                }
                //serialize the string to json
                string output = JsonConvert.SerializeObject(Pulse);
                stringBuilder.Append(output);
                stringBuilder.Append(Rice);
                File.WriteAllText(filepath, output, Encoding.UTF8);
                Console.WriteLine(output);
            }

        }
        public void AddData(string state)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (state == "Pulse")
            {
                try
                {
                    foreach (var item in Pulse.ToArray())
                    {
                        if (Pulse.Count > 0 && Pulse.Contains(item))
                        {
                            Console.WriteLine("enter Name of PulseList");
                            item.Name = Console.ReadLine();
                            Console.WriteLine("enter Weight of PulseList");
                            item.Weight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter Price of PulseList");
                            item.Price = Convert.ToInt32(Console.ReadLine());
                            Pulse.Add(item);
                            Console.WriteLine("items added successfully in Pulselist ");
                            //serialize the string to json
                            string output = JsonConvert.SerializeObject(Pulse);
                            stringBuilder.Append(output);
                            stringBuilder.Append(Rice);
                            File.WriteAllText(filepath, output, Encoding.UTF8);
                            Console.WriteLine(output);
                        }
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}

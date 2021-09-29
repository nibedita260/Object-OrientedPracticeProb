using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedPracticeProb.StockManagement
{
    class Stock
    {
        public List<StockModel> lenevo;
        public List<StockModel> hp;
        public List<StockModel> dell;
        public void ReadData(string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    File.Create(filepath);
                }
                //D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\StockManagement\Stock.json
                using (StreamReader r = new StreamReader(filepath))
                {
                    var json = r.ReadToEnd();
                    StockPortfolio stock = JsonConvert.DeserializeObject<StockPortfolio>(json);
                    lenevo = stock.Lenevo;
                    hp = stock.HP;
                    dell = stock.DELL;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DisplayData(string stocks)
        {
            Console.WriteLine("enter any one of stock-[ Lenevo Or HP Or Dell] which you want to display of that stock Management");
            stocks = Console.ReadLine();
            try
            {
                if (stocks == "lenevo")
                {
                    Console.WriteLine("Name\tNumberOfShares\tPrice");
                    foreach (var stock in lenevo)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", stock.Name, stock.NumberOfShares, stock.Price);
                    }
                }
                if (stocks == "hp")
                {
                    Console.WriteLine("Name\tNumberOfShares\tPrice");
                    foreach (var stock in hp)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", stock.Name, stock.NumberOfShares, stock.Price);
                    }
                }
                if (stocks == "Wheat")
                {
                    Console.WriteLine("Name\tNumberOfShares\tPrice");
                    foreach (var stock in dell)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", stock.Name, stock.NumberOfShares, stock.Price);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

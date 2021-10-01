using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedPracticeProb.StockManagement
{
    class Stock
    {
        static string filepathJson = @"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\StockManagement\StockJson.json";
        static string filepath = @"D:\git\Object-OrientedPracticeProb\ObjectOrientedPracticeProb\StockManagement\Stock.json";
        public List<StockModel> employee;
        public List<StockModel> accountant;
        public List<StockModel> manager;
        StockPortfolio stocks = new StockPortfolio();
        StockModel stockModel = new StockModel();
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
                    stocks = JsonConvert.DeserializeObject<StockPortfolio>(json);
                    employee = stocks.Employee;
                    accountant = stocks.Accountant;
                    manager = stocks.Manager;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DisplayStocks()
        {
            Console.WriteLine("enter any one of stock-[ employee Or accountant Or manager] which you want to display of that stock Management");
            string stock = Console.ReadLine();
            try
            {
                if (stock == "employee")
                {
                    Console.WriteLine("Name\tNumberOfShares\tPrice");
                    foreach (var stocks in employee)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", stocks.Name, stocks.NumberOfShares, stocks.Price);
                    }
                }
                if (stock == "accountant")
                {
                    Console.WriteLine("Name\tNumberOfShares\tPrice");
                    foreach (var stocks in accountant)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", stocks.Name, stocks.NumberOfShares, stocks.Price);
                    }
                }
                if (stock == "manager")
                {
                    Console.WriteLine("Name\tNumberOfShares\tPrice");
                    foreach (var stocks in manager)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", stocks.Name, stocks.NumberOfShares, stocks.Price);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void BuyStocks()
        {
            Console.WriteLine("enter any one of state-[ employee Or accountant Or manager] which you want to buy of that state Stock");
            string state = Console.ReadLine();
            if (state == "employee")
            {
                Console.WriteLine("enter the employeeStock name which you want to buy");
                string name = Console.ReadLine();
                foreach (var stock in employee)
                {
                    if (stock.Name == name)
                    {
                        stock.DateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        StockModel stockModel = new StockModel();
                        Console.WriteLine("enter numOfShares you want to buy for employeeStock");
                        int numOfShares = Convert.ToInt32(Console.ReadLine());
                        stock.NumberOfShares -= numOfShares;
                        stockModel = stock;
                        //update the filepathJson file to the specific NumberOfShares
                        try
                        {
                            StreamReader r = new StreamReader(filepathJson);
                            var json = r.ReadToEnd();
                            var stockData = JsonConvert.DeserializeObject<List<StockModel>>(json);
                            foreach (var data in stockData)
                            {
                                if (data.Name == stock.Name)
                                    data.NumberOfShares += numOfShares;
                            }
                            r.Close();
                            //serialize the string to json
                            string result = JsonConvert.SerializeObject(stockData);
                            File.WriteAllText(filepathJson, result);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        //serialize the string to json
                        string res = JsonConvert.SerializeObject(stocks);
                        File.WriteAllText(filepath, res);
                        return;
                    }
                }
                Console.WriteLine("Stock does not found");
            }
        }
        public void SellStocks()
        {
            Console.WriteLine("enter any one of state-[ employee Or accountant Or manager] which you want to sell of that state Stock");
            string state = Console.ReadLine();
            if (state == "employee")
            {
                Console.WriteLine("enter the employeeStock name which you want to sell");
                string name = Console.ReadLine();
                foreach (var stock in employee)
                {
                    if (stock.Name == name)
                    {
                        stock.DateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        StockModel stockModel = new StockModel();
                        Console.WriteLine("enter numOfShares you want to sell from employeeStock");
                        int numOfShares = Convert.ToInt32(Console.ReadLine());
                        stock.NumberOfShares -= numOfShares;
                        stockModel = stock;
                    }
                }
                stocks.Employee = employee;
                //serialize the string to json
                string output = JsonConvert.SerializeObject(stocks);
                File.WriteAllText(filepath, output);
            }
        }
    }
}
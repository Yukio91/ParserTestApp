using HtmlAgilityPack;
using ParserTestApp.Classes;
using System;
using System.Linq;

namespace ParserTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = @"https://www.kellysubaru.com/used-inventory/index.htm";

            try
            {
                var htmlDoc = new HtmlWeb().Load(url);

                var inventoryList = htmlDoc.DocumentNode.SelectSingleNode("//ul[@class='inventoryList data full list-unstyled']")?.ChildNodes.Where(li => li.Name == "li").ToList();
                if (!(inventoryList?.Any() ?? false))
                    return;

                var selectedNode = inventoryList.Skip(1).FirstOrDefault();
                if (selectedNode == null)
                    return;

                var car = CarHelper.ParseCar(selectedNode);

                Console.WriteLine(car);
                Console.ReadKey();
            }
            catch (HtmlWebException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

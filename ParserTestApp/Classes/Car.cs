using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserTestApp.Classes
{
    public class Car
    {
        public string Vin { get; set; }
        public string Price { get; set; }
        public string CoverPhotoUrl { get; set; }
        public override string ToString()
        {
            return $"Vin: {Vin} Price: {Price} CoverLink: {CoverPhotoUrl}";
        }
    }

    public static class CarManager
    {
        public static Car ParseCarInfo(HtmlNode selectedNode)
        {
            return new Car()
            {
                Vin = selectedNode.SelectSingleNode("//dl[@class='vin']/dd")?.InnerText,
                Price = selectedNode.SelectSingleNode("//span[@class='internetPrice final-price']/span[@class='value']")?.InnerText,
                CoverPhotoUrl = selectedNode.SelectSingleNode("//img[@class='photo thumb']")?.Attributes.FirstOrDefault(attr => attr.Name == "src")?.Value
            };
        }
    }
}

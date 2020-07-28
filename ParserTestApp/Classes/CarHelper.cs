using HtmlAgilityPack;
using System;
using System.Linq;

namespace ParserTestApp.Classes
{
    public static class CarHelper
    {
        public static Car ParseCar(HtmlNode node)
        {
            var coverUri = new Uri(node.SelectSingleNode(".//img[@class='photo thumb']")?.Attributes.FirstOrDefault(attr => attr.Name == "src")?.Value);

            return new Car()
            {
                Vin = node.SelectSingleNode(".//dl[@class='vin']/dd")?.InnerText,
                Price = node.SelectSingleNode(".//span[@class='internetPrice final-price']/span[@class='value']")?.InnerText,
                CoverPhotoUrl = coverUri.AbsoluteUri.Replace(coverUri.Query, String.Empty)
            };
        }
    }
}

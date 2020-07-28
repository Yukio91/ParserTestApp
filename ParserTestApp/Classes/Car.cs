using System;
using System.Collections.Generic;
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
            return $"Vin: {Vin} \nPrice: {Price} \nCoverLink: {CoverPhotoUrl}";
        }
    }
}

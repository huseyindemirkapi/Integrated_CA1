using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Paradigms_Assigment
{
    internal class Country : InflationRate
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public void IsEU()
        {
            Console.WriteLine("Yes");
        }

        private void Langeuage()
        {
            Console.WriteLine("English");
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Programming_Paradigms_Assigment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                WebClient webClient = new WebClient();
                string page = webClient.DownloadString("https://www.worlddata.info/europe/germany/inflation-rates.php");

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page);
                List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table[@class='std100 hover']")
                            .Descendants("tr")
                            .Skip(1)
                            .Where(tr => tr.Elements("td").Count() > 1)
                            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                            .ToList();


                List<Country> countryList = new List<Country>();

                List<string> list1 = new List<string>();

                list1.Add("germany");
                list1.Add("turkey");
                list1.Add("china");
                list1.Add("ireland");

                foreach (var countryname in list1)
                {
                    Country country = new Country();
                    country.CountryName = countryname;

                    for (int i = 0; i < table.Count; i++)
                    {
                        foreach (var item in table)
                        {
                            country.Year = item[i][0];
                            country.EuInflationRate = item[i][1];
                            country.EuInflationRate = item[i][2];
                            country.UsaInflationRate = item[i][3];
                            country.WorldInflationRate = item[i][4];
                            countryList.Add(country);
                        }

                    }
                }

                Console.WriteLine(countryList);
            }
        }
        public void CountryIsEU(string countryname)
        {
            Country country = new Country();

            if (country.CountryName == "Germany" || country.CountryName == "Ireland")
            {
                country.IsEU();
            }
            else
            {
                Console.Write(countryname + " is not a part of EU");
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace WebScraper
{
    public class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();

            HtmlDocument doc = web.Load("https://en.wikipedia.org/wiki/Greece");

           
            var HeaderNames = doc.DocumentNode.SelectNodes("//span[@class='toctext']");

            //store in CSV for later

            var titles = new List<Row>();   

            foreach(var item in HeaderNames)
            {
                titles.Add(new Row { Title = item.InnerText});
            }
            using (var writer = new StreamWriter(@"C:\Users\steve\repos\WebScraper\Scraped Nike Info.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(titles);
            }
        }
    }
}
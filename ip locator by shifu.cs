using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace geolocate by shifu
{

    public class Data
    {
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Loc { get; set; }
        public string org { get; set; }
        public string postal { get; set; }
        internal class Program
        {
            private static object ex;

            static async Task Main(string[] args)
            { 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Title = "GeoLocator by shifu";
                Console.Write("Enter Ip Address: ");
                string ip = Console.ReadLine();
                string url = $"https://ipinfo.io/{ip}/json";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();

                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("[+] Request Successfully Made!");

                        string responseData = await response.Content.ReadAsStringAsync();
                        Data ipInfo = JsonConvert.DeserializeObject<Data>(responseData);

                        Console.Clear();
                        Console.WriteLine($"Country: {ipInfo.Country}");
                        Console.WriteLine($"City: {ipInfo.City}");
                        Console.WriteLine($"Coordinates: {ipInfo.Loc}");
                        Console.WriteLine($"Postal Code: {ipInfo.postal}");
                        Console.WriteLine($"region: {ipInfo.Region}");
                        Console.WriteLine($"ASN: {ipInfo.org}");
                        string[] Coords = ipInfo.Loc.Split(',');
                        Console.WriteLine($"Google Maps: https://www.google.com/maps/?q={Coords[0]}, {Coords[1]}");
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }

                    }
                }
            }
}

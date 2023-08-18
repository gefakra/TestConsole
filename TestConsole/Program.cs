using Microsoft.Identity.Client;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace TestConsole
{
    public class Program
    {
        static Warehouse Warehouse;

        static void Main(string[] args)
        {
            GetData();
            OutputSortedGroups();
            OutputThreePallets();
            Console.ReadLine();
        }

        public static void OutputSortedGroups()
        {            
            var groupedPallets = Warehouse.Pallets
                .GroupBy(p => p.ExpirationDate)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    ExpirationDate = g.Key,
                    SortedPallets = g.OrderBy(p => p.Weight)
                });

            foreach (var group in groupedPallets)
            {
                Console.WriteLine($"Expiration Date: {group.ExpirationDate}");
                foreach (var pallet in group.SortedPallets)
                {
                    Console.WriteLine($"Weight: {pallet.Weight}, Palet Id: {pallet.Id}");
                }
            }
        }
        public static void OutputThreePallets()
        {
            var selectedPallets = Warehouse.Pallets
                .OrderByDescending(p => p.ExpirationDate)
                .Take(3)
                .OrderBy(p => p.Volume);

            Console.WriteLine("Three pallets with highest expiry date:");

            foreach (Pallet pallet in selectedPallets)
            {
                Console.WriteLine($"- Pallet ID: {pallet.Id}, Volume: {pallet.Volume}");
            }
        }
    private static void GetData()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var JsonString = File.ReadAllText(path + "/warehouse.json");
            Warehouse = JsonSerializer.Deserialize<Warehouse>(JsonString);
        }
    }

}
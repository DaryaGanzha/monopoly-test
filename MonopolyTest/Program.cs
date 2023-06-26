using MonopolyTest.DTO;
using MonopolyTest.Models;
using MonopolyTest.Services;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите опцию:");
            Console.WriteLine("1 - Добавить палету.");
            Console.WriteLine("2 - Добавить коробку.");
            Console.WriteLine("3 - Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу");
            Console.WriteLine("4 - 3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.");
            string choice = Console.ReadLine();

            var service = new PalletService();
            if (choice == "1")
            {
                Console.WriteLine("Enter Width: ");
                double width = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Height: ");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Depth: ");
                double depth = Convert.ToDouble(Console.ReadLine());

                var pallet = new PalletDTO { Width = width, Height = height, Depth = depth };
                service.CreatePallet(pallet);
                Console.WriteLine("Pallet is created!");
            }
            if (choice == "2")
            {
                Console.WriteLine("Выберите номер паллеты:");
                List<Pallet> pallets = (List<Pallet>)service.GetPallets();
                int k = 0;
                foreach (var pallet in pallets)
                {
                    Console.WriteLine("Номер: {0} Ширина: {1} Высота: {2} Глубина: {3} Вес: {4}", k, pallet.Width, pallet.Height, pallet.Depth, pallet.Weight);
                    k++;
                }
                int palletNum = Convert.ToInt32(Console.ReadLine());
                var newBox = new BoxDTO { Width = 200, Height = 10, Depth = 20, PalletId = pallets[palletNum].Id, Weight = 9, Production_date = new DateTime(2023, 5, 20) };
                service.CreateBox(newBox, pallets[palletNum]);
            }
            if (choice == "3")
            {
                IEnumerable<dynamic> sortedPallets = service.GroupPallets();
                foreach (var group in sortedPallets)
                {
                    Console.WriteLine($"Expiration Date: {group.ExpirationDate}");
                    foreach (var pallet in group.Pallets)
                    {
                        Console.WriteLine($"Pallet ID: {pallet.Id}, Weight: {pallet.Weight}");
                    }
                }
                Console.ReadLine();
            }
            if (choice == "4")
            {
                IEnumerable<dynamic> pallets = service.TopThreePallets();
                foreach (var group in pallets)
                {
                    Console.WriteLine($"Expiration Date: {group.ExpirationDate}");
                    foreach (var pallet in group.Pallets)
                    {
                        Console.WriteLine($"Pallet ID: {pallet.Id}, Volume: {pallet.Volume}");
                    }
                }
                Console.ReadLine();
            }
        }
    }
}

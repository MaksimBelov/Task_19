using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_19
{
    class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Processor { get; set; }
        public double Frequency { get; set; }
        public int RAM { get; set; }
        public int VolumeHDD { get; set; }
        public int MemoryVideo { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()
            {
                new Computer() { Id = 1, Name = "ASUS", Processor = "Intel", Frequency = 3.6, RAM = 16, VolumeHDD = 1000, MemoryVideo = 8, Cost = 100000, Count = 20 },
                new Computer() { Id = 2, Name = "Apple", Processor = "Intel", Frequency = 3.0, RAM = 8, VolumeHDD = 500, MemoryVideo = 4, Cost = 40000, Count = 30 },
                new Computer() { Id = 3, Name = "HP", Processor = "Intel", Frequency = 2.3, RAM = 8, VolumeHDD = 1000, MemoryVideo = 4, Cost = 50000, Count = 15 },
                new Computer() { Id = 4, Name = "MSI", Processor = "Intel", Frequency = 5.0, RAM = 16, VolumeHDD = 2000, MemoryVideo = 16, Cost = 150000, Count = 35 },
                new Computer() { Id = 5, Name = "Lenovo", Processor = "AMD", Frequency = 2.8, RAM = 4, VolumeHDD = 250, MemoryVideo = 4, Cost = 30000, Count = 16 },
                new Computer() { Id = 6, Name = "HP", Processor = "Intel", Frequency = 2.8, RAM = 16, VolumeHDD = 500, MemoryVideo = 8, Cost = 50000, Count = 6 },
                new Computer() { Id = 7, Name = "MSI", Processor = "AMD", Frequency = 4.2, RAM = 32, VolumeHDD = 3000, MemoryVideo = 16, Cost = 200000, Count = 40 },
                new Computer() { Id = 8, Name = "DELL", Processor = "AMD", Frequency = 2.0, RAM = 8, VolumeHDD = 250, MemoryVideo = 4, Cost = 30000, Count = 7 }
            };

            // список компьютеров с указанным процессором
            Console.Write("Введите название процессора: ");
            string processor = Console.ReadLine();
            List<Computer> computersByProcessor = listComputer
                .Where(x => x.Processor == processor)
                .ToList();
            Console.WriteLine("Компьютеры с указанным параметром:");
            PrintData(computersByProcessor);

            // список компьютеров с объемом ОЗУ не ниже, чем указано
            Console.Write("Введите объем ОЗУ: ");
            try
            {
                int ram = Convert.ToInt32(Console.ReadLine());
                List<Computer> computersByRam = listComputer
                    .Where(x => x.RAM >= ram)
                    .ToList();
                Console.WriteLine("Компьютеры с указанным параметром:");
                PrintData(computersByRam);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.Write("Нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }

            // список, отсортированный по увеличению стоимости
            Console.Write("Список компьютеров, отсортированный по увеличению стоимости:");
            Console.WriteLine();
            List<Computer> computersByCost = listComputer
                .OrderBy(x => x.Cost)
                .ToList();
            PrintData(computersByCost);

            // список, сгруппированный по типу процессора
            Console.WriteLine("Список компьютеров, сгруппированный по типу процессора:");
            var computersByProc = listComputer
                .GroupBy(x => x.Processor);
            foreach (IGrouping<string, Computer> group in computersByProc)
            {
                Console.WriteLine();
                Console.WriteLine($"Компьютеры с процессором {group.Key}:");
                Console.WriteLine("N\tNAME\tFREQ\tRAM\tHDD\tVRAM\tCOST\tCOUNT");
                foreach (var comp in group)
                {
                    Console.WriteLine($"{comp.Id}\t{comp.Name}\t{comp.Frequency}\t{comp.RAM}\t{comp.VolumeHDD}\t{comp.MemoryVideo}\t{comp.Cost}\t{comp.Count}");
                }
            }
            Console.WriteLine();
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            // самый дорогой компьютер
            Console.WriteLine("Самый дорогой компьютер(ы):");
            int maxCost = listComputer.Max(x => x.Cost);
            List<Computer> maxCostComputers = listComputer
                .Where(x => x.Cost == maxCost)
                .ToList();
            PrintData(maxCostComputers);

            // самый бюджетный компьютер
            Console.WriteLine("Самый бюджетный компьютер(ы):");
            int minCost = listComputer.Min(x => x.Cost);
            List<Computer> minCostComputers = listComputer
                .Where(x => x.Cost == minCost)
                .ToList();
            PrintData(minCostComputers);

            //определяем, есть ли хотя бы один компьютер в количестве не менее 30 штук
            List<Computer> сomputers30 = listComputer
                .Where(x => x.Count >= 30)
                .ToList();
            if (сomputers30.Count == 0)
            {
                Console.WriteLine("Компьютеры в количестве не менее 30 штук отсутствуют");
                Console.WriteLine();
                Console.Write("Нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Компьютеры в количестве не менее 30 штук:");
                PrintData(сomputers30);
            }
        }
        
        static void PrintData(List<Computer> computers)
        {
            Console.WriteLine();
            if (computers.Count == 0)
            {
                Console.WriteLine("Компьютеры с указанным параметром отсутствуют");
            }
            else
            {
                Console.WriteLine("N\tNAME\tPROC\tFREQ\tRAM\tHDD\tVRAM\tCOST\tCOUNT");
                foreach (Computer comp in computers)
                {
                    Console.WriteLine($"{comp.Id}\t{comp.Name}\t{comp.Processor}\t{comp.Frequency}\t{comp.RAM}\t{comp.VolumeHDD}\t{comp.MemoryVideo}\t{comp.Cost}\t{comp.Count}");
                }
            }
            Console.WriteLine();
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

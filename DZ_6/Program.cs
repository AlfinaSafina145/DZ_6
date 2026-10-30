using System;

namespace BuildingApp
{
    public class Building
    {
        private static int lastBuildingNumber = 0;

        private static int GenerateBuildingNumber()
        {
            lastBuildingNumber++;
            return lastBuildingNumber;
        }
        private int buildingNumber;
        private double height;
        private int floors;
        private int apartmentsTotal;
        private int entrances;
        public Building(double height, int floors, int apartmentsTotal, int entrances)
        {
            buildingNumber = GenerateBuildingNumber();

            Height = height;
            Floors = floors;
            ApartmentsTotal = apartmentsTotal;
            Entrances = entrances;
        }
        public int BuildingNumber
        {
            get { return buildingNumber; }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value > 0) height = value;
                else Console.WriteLine("Ошибка: высота должна быть больше 0.");
            }
        }

        public int Floors
        {
            get { return floors; }
            set
            {
                if (value > 0) floors = value;
                else Console.WriteLine("Ошибка: этажность должна быть больше 0.");
            }
        }

        public int ApartmentsTotal
        {
            get { return apartmentsTotal; }
            set
            {
                if (value >= 0) apartmentsTotal = value;
                else Console.WriteLine("Ошибка: количество квартир не может быть отрицательным.");
            }
        }

        public int Entrances
        {
            get { return entrances; }
            set
            {
                if (value > 0) entrances = value;
                else Console.WriteLine("Ошибка: подъездов должно быть больше 0.");
            }
        }
        public double GetFloorHeight()
        {
            return Height / Floors;
        }

        public double GetApartmentsPerEntrance()
        {
            return (double)ApartmentsTotal / Entrances;
        }
        public double GetApartmentsPerFloorTotal()
        {
            return (double)ApartmentsTotal / Floors;
        }
        public double GetApartmentsPerFloorInEntrance()
        {
            return (double)ApartmentsTotal / Entrances / Floors;
        }
        public void PrintInfo()
        {
            Console.WriteLine("=== Информация о здании ===");
            Console.WriteLine($"Уникальный номер: {BuildingNumber}");
            Console.WriteLine($"Высота: {Height} м.");
            Console.WriteLine($"Этажность: {Floors}");
            Console.WriteLine($"Всего квартир: {ApartmentsTotal}");
            Console.WriteLine($"Подъездов: {Entrances}");

            Console.WriteLine("--- Вычисления ---");
            Console.WriteLine($"Высота одного этажа: {Math.Round(GetFloorHeight(), 2)} м.");
            Console.WriteLine($"Квартир в подъезде: {GetApartmentsPerEntrance()}");
            Console.WriteLine($"Квартир на этаже (во всем доме): {Math.Round(GetApartmentsPerFloorTotal(), 2)}");
            Console.WriteLine($"Квартир на этаже (в одном подъезде): {Math.Round(GetApartmentsPerFloorInEntrance(), 2)}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создаем первое здание:");
            Building house1 = new Building(height: 30.0, floors: 10, apartmentsTotal: 120, entrances: 2);
            house1.PrintInfo();

            Console.WriteLine("\nСоздаем второе здание:");
            Building house2 = new Building(15.5, 5, 40, 1);
            house2.PrintInfo();
        }
    }
}
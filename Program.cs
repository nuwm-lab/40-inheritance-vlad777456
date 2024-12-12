using System;

namespace PraktikantAndPratsivnik
{
    // Базовий клас "Практикант"
    class Praktikant
    {
        // Атрибути класу
        public string Prizvyshche { get; set; }
        public string Imya { get; set; }
        public string Vuz { get; set; }

        // Метод для введення даних
        public void ZadatyDani()
        {
            Console.WriteLine("Введіть прізвище практиканта:");
            Prizvyshche = Console.ReadLine();
            Console.WriteLine("Введіть ім'я практиканта:");
            Imya = Console.ReadLine();
            Console.WriteLine("Введіть назву навчального закладу:");
            Vuz = Console.ReadLine();
        }

        // Метод для визначення чи є прізвище симетричним
        public bool ChiSimetrichnePrizvyshche()
        {
            string reversedPrizvyshche = string.Join("", Prizvyshche.ToCharArray().Reverse());
            return Prizvyshche.Equals(reversedPrizvyshche, StringComparison.OrdinalIgnoreCase);
        }
    }

    // Похідний клас "ПрацівникФірми", що наслідує від "Практикант"
    class PratsivnikFirmy : Praktikant
    {
        // Атрибути для "ПрацівникФірми"
        public DateTime DataPryjomu { get; set; }
        public string Posada { get; set; }
        public string ZakincheneVuz { get; set; }

        // Метод для введення даних для працівника фірми
        public void ZadatyDani()
        {
            // Викликаємо метод базового класу для введення спільних даних
            base.ZadatyDani();

            // Вводимо додаткові дані для працівника
            Console.WriteLine("Введіть дату прийому на роботу (в форматі рік-місяць-день):");
            DataPryjomu = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введіть посаду працівника:");
            Posada = Console.ReadLine();
            Console.WriteLine("Введіть навчальний заклад, який закінчив працівник:");
            ZakincheneVuz = Console.ReadLine();
        }

        // Метод для визначення стажу роботи на фірмі
        public int StazhRoboti()
        {
            int stazh = DateTime.Now.Year - DataPryjomu.Year;
            if (DateTime.Now < DataPryjomu.AddYears(stazh))
                stazh--;
            return stazh;
        }

        // Перевантаження методу для перевірки симетричності прізвища
        public new bool ChiSimetrichnePrizvyshche()
        {
            return base.ChiSimetrichnePrizvyshche();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо об'єкт класу "Практикант"
            Praktikant praktikant = new Praktikant();
            praktikant.ZadatyDani(); // Викликаємо метод для вводу даних практиканта

            // Перевіряємо, чи є прізвище практиканта симетричним
            Console.WriteLine($"Прізвище практиканта симетричне? {praktikant.ChiSimetrichnePrizvyshche()}");

            // Створюємо об'єкт класу "ПрацівникФірми"
            PratsivnikFirmy pratsivnik = new PratsivnikFirmy();
            pratsivnik.ZadatyDani(); // Викликаємо метод для вводу даних працівника

            // Визначаємо стаж роботи на фірмі
            Console.WriteLine($"Стаж роботи на фірмі: {pratsivnik.StazhRoboti()} років");

            // Перевіряємо, чи є прізвище працівника фірми симетричним
            Console.WriteLine($"Прізвище працівника фірми симетричне? {pratsivnik.ChiSimetrichnePrizvyshche()}");
        }
    }
}

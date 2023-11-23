// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

//Завдання 1:
//Реалізуйте користувацький тип «Фірма». В ньому має бути інформація про назву фірми, дату заснування, профіль бізнесу (маркетинг, IT, і т. д.),
//ПІБ директора, кількість працівників, адреса.

namespace d3_04._11
{
    public class Firma
    {
        public string Name { get; set; }
        public DateTime FoudedData { get; set; }
        public string Profile { get; set; }
        public string FulNameBoss { get; set; }
        public int Employees { get; set; }
        public string Address { get; set; }

        public Firma(string n, DateTime fd, string prf, string fnb, int emp, string ads)
        {
            Name = n;
            FoudedData = fd;
            Profile = prf;
            FulNameBoss = fnb;
            Employees = emp;
            Address = ads;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Назва фірми :{Name}");
            Console.WriteLine($"Дата заснування :{FoudedData.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Профіль :{Profile}");
            Console.WriteLine($"ПІБ деректора :{FulNameBoss}");
            Console.WriteLine($"Кількість прцівників :{Employees}");
            Console.WriteLine($"Адреса :{Address}");
            Console.WriteLine();
        }
    }

    class Program {
        static void Main(string[] args)
        {
            List<Firma> firms = new List<Firma>();
            firms.Add(new Firma("Home Food", new DateTime(2011,11,5), "Fust food", "Bryant Booton", 402, "KIev"));
            firms.Add(new Firma("Swaniawski-Kuvalis", new DateTime(2007,5,13), "Basic Industries", "Sheilakathryn Life", 443, "Carmo do Paranaíba"));
            firms.Add(new Firma("Simonis and White", new DateTime(2023,12,2), "Basic Industries", "Dewitt Black", 207, "Neos Voutzás"));
            firms.Add(new Firma("Stehr-Lang", new DateTime(2017,4,4), "IT", "Allan White", 398, "London"));
            firms.Add(new Firma("Cole Inc", new DateTime(2015,12,3), "Marketing", "Sue Buchan", 195, "Zhongcun"));
            firms.Add(new Firma("Pouros-Morar", new DateTime(2019,9,16), "Consumer Services", "Lucina Geockle", 87, "Buenavista"));

            //Отримати інформацію про всі фірми.
            ////1 варіант
            //var allFirmsInfo = from firma in firms
            //                   select firma;
            //foreach (var firma in allFirmsInfo)
            //{
            //    firma.ShowInfo();
            //}
            //2 варіaнт 
            //var allFirmsInfo2 = firms;
            //foreach (var firma in allFirmsInfo2)
            //{
            //    firma.ShowInfo();
            //}

            //Отримати фірми, які мають у назві слово «Food».
            //1 варіант
            //var foodFirms1 = firms.Where(firma => firma.Name.Contains("Food"));
            //foreach (var firma in foodFirms1)
            //{
            //    firma.ShowInfo();
            //}
            //2 варіaнт
            //var foodFirms2 = from firma in firms
            //                 where firma.Name.Contains("Food",StringComparison.OrdinalIgnoreCase)
            //                 select firma;
            //foreach (var firma in foodFirms2)
            //{
            //    firma.ShowInfo();
            //}

            //Отримати фірми, які працюють у галузі маркетингу.
            //1 варіант
            //var marketingFirm = firms.Where(firma => firma.Profile.Contains("Marketing"));
            //foreach (var firma in marketingFirm)
            //{
            //    firma.ShowInfo();
            //}
            //2 варіaнт
            //var marketingFirm2 = from firma in firms
            //                     where firma.Profile.Equals("Marketing", StringComparison.OrdinalIgnoreCase)
            //                     select firma;
            //foreach (var firma in marketingFirm2)
            //{
            //    firma.ShowInfo();
            //}

            // Отримати фірми, які працюють у галузі маркетингу або IT.
            //1 варіант
            //var MorIT = from f in firms
            //            where f.Profile.Equals("Marketing", StringComparison.OrdinalIgnoreCase) 
            //            || f.Profile.Equals("IT", StringComparison.OrdinalIgnoreCase)
            //            select f;
            //foreach(var firma in MorIT)
            //{
            //    firma.ShowInfo();
            //}

            //2 варіaнт
            //var MorIT2 = firms.Where(firma => firma.Profile.Equals("Marketing") || firma.Profile.Equals("IT"));

            //    foreach (var firma in MorIT2)
            //    {
            //    firma.ShowInfo();
            //    }

            //Отримати фірми з кількістю працівників більшою, ніж 100.
            //1 варіант
            //var emp1001=from f in firms
            //            where f.Employees>100
            //            select f;
            //foreach (var emp in emp1001)
            //{
            //    emp.ShowInfo();
            //}
            ////2 варіaнт
            //var emp1002 = firms.Where(firma => firma.Employees >100);
            //       foreach (var emp in emp1002)
            //{
            //    emp.ShowInfo();
            //}

            //Отримати фірми з кількістю працівників у діапазоні від 100 до 300.
            //1 варіант
            //var emp100300 = from f in firms
            //              where f.Employees>= 100 && f.Employees <= 300
            //              select f;
            //foreach (var emp in emp100300)
            //{
            //    emp.ShowInfo();
            //}
            //2 варіaнт
            //var emp1003002 = firms.Where(firma => firma.Employees >= 100 && firma.Employees <= 300);
            //foreach (var emp in emp1003002)
            //{
            //    emp.ShowInfo();
            //}

            //Отримати фірми, які знаходяться в Лондоні.
            //1 варіант
            //var city = from f in firms
            //           where f.Address.Equals("London")
            //           select f;
            //foreach (var c in city)
            //{
            //    c.ShowInfo();
            //}
            //2 варіaнт
            //var city2 = firms.Where(firma => firma.Address.Equals("London"));
            //foreach (var c in city2)
            //{
            //    c.ShowInfo();
            //}

            //Отримати фірми, в яких прізвище директора White.
            //1 варіант
            //var surname= from f in firms
            //           where f.FulNameBoss.Contains("White",StringComparison.OrdinalIgnoreCase)
            //           select f;
            //foreach (var s in surname)
            //{
            //    s.ShowInfo();
            //}
            //2 варіант
            //var surname2 = firms.Where(firma => firma.FulNameBoss.Contains("White"));
            //foreach (var s in surname2)
            //{
            //    s.ShowInfo();
            //}

            //Отримати фірми, які засновані більше двох років тому.
            DateTime currentDate = DateTime.Now;
            //1 варіант
            //var Data2Year = from f in firms
            //                where (currentDate - f.FoudedData).TotalDays > 365 * 2
            //                select f;
            //foreach(var d in Data2Year)
            //{
            //    d.ShowInfo();
            //}

            //2BapiaHT
            //var DAata2year = firms.Where(f => (currentDate - f.FoudedData).TotalDays > 365 * 2);

            //foreach (var d in DAata2year)
            //{
            //    d.ShowInfo();
            //}

            //Отримати фірми з дня заснування яких минуло 123 дні.
            //1 варіант
            //var Data123 = from f in firms
            //               where (currentDate - f.FoudedData).TotalDays > 123
            //               select f;
            //foreach(var d in Data123)
            //{
            //    d.ShowInfo();
            //}
            //2BapiaHT
            //var Data1232 = firms.Where(f => (currentDate - f.FoudedData).TotalDays > 123);

            //foreach (var d in Data1232)
            //{
            //    d.ShowInfo();
            //}

            //Отримати фірми, в яких прізвище директора Black і мають у назві фірми слово «White»
            //1 варіант
            var BWName = from f in firms
                         where f.FulNameBoss.Contains("Black") && f.Name.Contains("White")
                         select f;

            foreach (var d in BWName)
            {
                d.ShowInfo();
            }

            //2BapiaHT
            var BWName2 = firms.Where(f => f.FulNameBoss.Contains("Black") && f.Name.Contains("White"));

            foreach (var d in BWName2)
            {
                d.ShowInfo();
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace Program
{
    class Program
    {
        static SortedDictionary<string, List<string>> sd = new SortedDictionary<string, List<string>>();

        static void Main()
        {
            insert();
            print();
        }

        static void insert()
        {
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kayitlar.txt"));
            foreach (var line in lines)
            {
                string[] parts = line.Split("|");
                if (parts.Length == 3) 
                {
                    string isim = parts[0].Trim();
                    string şehir = parts[1].Trim();
                    string telefon = parts[2].Trim();

                    string personInfo = String.Format("{0} - {1}", isim, telefon);

                    if (!sd.ContainsKey(şehir))
                    {
                        sd[şehir] = new List<string>();
                    }

                    sd[şehir].Add(personInfo);
                }
            }
        }

        static void print()
        {
            foreach (var city in sd)
            {
                Console.WriteLine("{0} :", city.Key);
                foreach (var person in city.Value)
                {
                    Console.WriteLine("  {0}", person);
                }
            }
        }
    }
}

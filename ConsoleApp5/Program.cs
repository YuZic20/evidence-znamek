using ClassLibrary1;
using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            

            x();
            Console.ReadLine();
            
        }


        public static async void x()
        {
            ClassLibrary1.Tabulka databaze = new ClassLibrary1.Tabulka();

            Znamky znamka = new Znamky();
            znamka.IdPredmet = 1;
            znamka.Vaha = 20;
            znamka.Znamka = 1;

            await Tabulka.Database.SaveItemAsync(znamka);

            Znamky getznamka ;

            getznamka = await Tabulka.Database.GetItemAsync(0);
            int x = 5;
        }
    }
}

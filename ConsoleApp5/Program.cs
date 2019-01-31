using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static async Task Main(string[] args)
        {


            
            

            Znamky znamka = new Znamky();
            znamka.IdPredmet = 1;
            znamka.Vaha = 20;
            znamka.Znamka = 1;

            znamka = await Tabulka.Database.GetItemAsync<Znamky>(5);

            Predmet fyzika = new Predmet();
            fyzika.Id = 0;
            fyzika.Nazev = "Fyzika";

            Predmet fyzika2 = new Predmet();


            await Tabulka.Database.SaveItemAsync<Predmet>(fyzika);
            fyzika2 = await Tabulka.Database.GetItemAsync<Predmet>(2);

          
            
            Console.ReadLine();
            
        }


        
    }
}

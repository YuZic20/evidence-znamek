using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static async Task Main(string[] args)
        {



            
            /*
            Znamky znamka = new Znamky();
            znamka.IdPredmet = 1;
            znamka.Vaha = 20;
            znamka.Znamka = 5;

            await Tabulka.Database.SaveItemAsync<Znamky>(znamka);
            */
            /*
            Predmet fyzika = new Predmet();
            fyzika.Id = 1;
            fyzika.Nazev = "Matika";

            Predmet fyzika2 = new Predmet();
            

            await Tabulka.Database.SaveItemAsync<Predmet>(fyzika);
            fyzika2 = await Tabulka.Database.GetItemAsync<Predmet>(2);
            */
            List<Znamky> Znamky = await ZnamkaHndle.Ziskat<Znamky>();
            List<Predmet> Predmety = await ZnamkaHndle.Ziskat<Predmet>();





            PrintListPrumer(Znamky, Predmety);



            Console.ReadLine();
            
        }
        public void PrintList(List<Znamky> Znamky, List<Predmet> Predmety)
        {
            for(int i = 0; i < Znamky.Count(); i++)
            {
                Console.WriteLine(Znamky[i].Id + "  " + Predmety[Znamky[i].IdPredmet] + "  " + Znamky[i].Vaha + "  " + Znamky[i].Znamka);
            }
        }
        static void PrintListPrumer(List<Znamky> Znamky, List<Predmet> Predmety)
        {
            List<TrippleInt> ListOfPred = Enumerable.Repeat<TrippleInt>(null, Predmety.Count()).ToList();

            for (int i = 0; i < Znamky.Count(); i++)
            {
                TrippleInt Znamka = new TrippleInt();
                if (ListOfPred[Znamky[i].IdPredmet] != null)
                {
                    Znamka.A = Znamky[i].IdPredmet;
                    Znamka.B = Znamka.B + Znamky[i].Znamka;
                    Znamka.C++;
                }
                else
                {
                    Znamka.A = Znamky[i].IdPredmet;//oprav
                    Znamka.B = ListOfPred[Znamka.A].B + Znamky[i].Znamka;
                    Znamka.C++;
                }

                


                ListOfPred[Znamka.A] = Znamka;

                int a = 4;
            }

            foreach (TrippleInt prumer in ListOfPred)
            {
                if (prumer != null)
                {
                    Console.WriteLine(Predmety[prumer.A].Nazev + "  " + (float)(prumer.B / prumer.C));
                }
                
            }
            
        }




    }
}

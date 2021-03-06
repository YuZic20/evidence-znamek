﻿using ClassLibrary1;
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
             znamka.IdPredmet = 0;
             znamka.Vaha = 50;
             znamka.Znamka = 5;

             await Tabulka.Database.SaveItemAsync<Znamky>(znamka);


             Predmet fyzika = new Predmet();
             fyzika.Id = 0;
             fyzika.Nazev = "Matisadf222asdfka";

             Predmet fyzika2 = new Predmet();    


             await Tabulka.Database.SaveItemAsync<Predmet>(fyzika);
             fyzika2 = await Tabulka.Database.GetItemAsync<Predmet>(2);
             */
            List<Mark> Znamky = await Table.Database.GetItemsAsync<Mark>();
            List<Class> Predmety = await Table.Database.GetItemsAsync<Class>();

            



            PrintListPrumer(Znamky, Predmety);
            int value;
            string input;
            while (true)
            {
                Console.WriteLine("Přidat 1, Odebrat 2");
                input = Console.ReadLine();
                
                if(int.TryParse(input, out value))
                {
                    break;
                }
            }

            if(value == 1)
            {
                Mark NewZnamka = new Mark();
                
                while (true)
                {
                    Console.WriteLine("Váha");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out value))
                    {
                        break;
                    }
                }

                NewZnamka.Vaha = value;

                while (true)
                {
                    foreach(Class predmet in Predmety)
                    {
                        Console.WriteLine(predmet.Id-1 + "  " + predmet.Name);
                    }
                    Console.WriteLine("Předmět, zadej id");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out value))
                    {
                        break;
                    }
                }
                NewZnamka.IdPredmet = value;

                while (true)
                {
                    Console.WriteLine("známka");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out value))
                    {
                        break;
                    }
                }
                NewZnamka.Znamka = value;
                await Table.Database.SaveItemAsync<Mark>(NewZnamka);
            }else if (value == 2)
            {
                while (true)
                {
                    PrintList(Znamky, Predmety);

                    Console.WriteLine("zadej id znamky");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out value))
                    {
                        if(value <= Znamky.Count() && value >= 0)
                        {
                            break;
                        }
                    }
                }
                await Table.Database.DeleteItemAsync<Mark>(Znamky[value]);


            }
            

            
        }
        static void PrintList(List<Mark> Znamky, List<Class> Predmety)
        {
            for(int i = 0; i < Znamky.Count(); i++)
            {
                Console.WriteLine(Znamky[i].Id + "  " + Predmety[Znamky[i].IdPredmet] + "  " + Znamky[i].Vaha + "  " + Znamky[i].Znamka);
            }
        }
        static void PrintListPrumer(List<Mark> Znamky, List<Class> Predmety)
        {
            List<TrippleInt> ListOfPred = Enumerable.Repeat<TrippleInt>(null, Predmety.Count()).ToList();
            
            for (int i = 0; i < Znamky.Count(); i++)
            {
                TrippleInt Znamka = new TrippleInt();
                if (ListOfPred[Znamky[i].IdPredmet] == null)
                {
                    Znamka = new TrippleInt();
                    Znamka.A = Znamky[i].IdPredmet;
                    Znamka.B = Znamky[i].Znamka * Znamky[i].Vaha;
                    Znamka.C = Znamky[i].Vaha;
                    ListOfPred[Znamky[i].IdPredmet] = Znamka;
                    Znamka = ListOfPred[Znamky[i].IdPredmet];
                }
                else
                {
                    Znamka = new TrippleInt();
                    Znamka = ListOfPred[Znamky[i].IdPredmet];

                    Znamka.A = Znamky[i].IdPredmet;
                    Znamka.B = ListOfPred[Znamka.A].B + Znamky[i].Znamka * Znamky[i].Vaha;
                    Znamka.C = Znamka.C + Znamky[i].Vaha;
                    ListOfPred[Znamky[i].IdPredmet] = Znamka;
                }
                







            }

            foreach (TrippleInt prumer in ListOfPred)
            {
                if (prumer != null)
                {
                    Console.WriteLine(Predmety[prumer.A].Name + "  " + ((double)prumer.B / (double)prumer.C));
                }
                
            }
            
        }




    }
}

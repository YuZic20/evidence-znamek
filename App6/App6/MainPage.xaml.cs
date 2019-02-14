using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ClassLibrary1;

namespace App6
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            PrintDataAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await NewPage();
        }
        private async Task NewPage()
        {
            await Navigation.PushAsync(new Page1());
         
        }
        public async Task PrintDataAsync()

        {




            List<Mark> ListZnamky = await Table.Database.GetItemsAsync<Mark>();
            List<Class> ListPredmety = await Table.Database.GetItemsAsync<Class>();

            LeftStock.Children.Clear();
            RigtStock.Children.Clear();
            for (int i = 0; i < ListZnamky.Count(); i++)
            {
                //Console.WriteLine(Znamky[i].Id + "  " + Predmety[Znamky[i].IdPredmet] + "  " + Znamky[i].Vaha + "  " + Znamky[i].Znamka);
                Label Left = new Label();
                Left.Text = ListZnamky[i].Znamka.ToString();
                LeftStock.Children.Add(Left);

                Label Right = new Label();
                Right.Text = ListPredmety[ListZnamky[i].IdPredmet].Nazev;
                RigtStock.Children.Add(Right);


            }
           await PrintPrumerAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await PrintDataAsync();
        }
        
        private async Task PrintPrumerAsync()
        {
            List<Mark> ListZnamky = await Table.Database.GetItemsAsync<Mark>();
            List<Class> ListPredmety = await Table.Database.GetItemsAsync<Class>();

            List<TrippleInt> ListOfPred = Enumerable.Repeat<TrippleInt>(null, ListPredmety.Count()).ToList();

            for (int i = 0; i < ListZnamky.Count(); i++)
            {
                TrippleInt Znamka = new TrippleInt();
                if (ListOfPred[ListZnamky[i].IdPredmet] == null)
                {
                    Znamka = new TrippleInt();
                    Znamka.A = ListZnamky[i].IdPredmet;
                    Znamka.B = ListZnamky[i].Znamka * ListZnamky[i].Vaha;
                    Znamka.C = ListZnamky[i].Vaha;
                    ListOfPred[ListZnamky[i].IdPredmet] = Znamka;
                    Znamka = ListOfPred[ListZnamky[i].IdPredmet];
                }
                else
                {
                    Znamka = new TrippleInt();
                    Znamka = ListOfPred[ListZnamky[i].IdPredmet];

                    Znamka.A = ListZnamky[i].IdPredmet;
                    Znamka.B = ListOfPred[Znamka.A].B + ListZnamky[i].Znamka * ListZnamky[i].Vaha;
                    Znamka.C = Znamka.C + ListZnamky[i].Vaha;
                    ListOfPred[ListZnamky[i].IdPredmet] = Znamka;
                }


            }

            foreach (TrippleInt prumer in ListOfPred)
            {
                if (prumer != null)
                {
                    Double prumernum = (double)prumer.B / (double)prumer.C;
                    Label Left = new Label();
                    Left.Text = prumernum.ToString();
                    LeftStock.Children.Add(Left);

                    Label Right = new Label();
                    Right.Text = ListPredmety[prumer.A].Nazev;
                    RigtStock.Children.Add(Right);
                    
                }

            }
        }
        
    }
}

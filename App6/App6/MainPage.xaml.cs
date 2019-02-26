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
                //Console.WriteLine(ListZnamky[i].Id + "  " + ListPredmety[ListZnamky[i].IdPredmet] + "  " + ListZnamky[i].Vaha + "  " + ListZnamky[i].Znamka);
                Label Left = new Label();
                Left.Text = ListZnamky[i].Znamka.ToString() + " " + ListPredmety[ListZnamky[i].IdPredmet].Name; 
                LeftStock.Children.Add(Left);
                /*
                Label Right = new Label();
                Right.Text = ListPredmety[ListZnamky[i].IdPredmet].Name;
                RigtStock.Children.Add(Right);
                */

            }

            Label Left2 = new Label();
            Label Right2 = new Label();
            Left2.Text = "";
            Right2.Text = "";
            LeftStock.Children.Add(Left2);
            RigtStock.Children.Add(Right2);



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
                    Left.Text = prumernum.ToString() + " " + ListPredmety[prumer.A].Name; ;
                    LeftStock.Children.Add(Left);
                    /*
                    Label Right = new Label();
                    Right.Text = ListPredmety[prumer.A].Name;
                    RigtStock.Children.Add(Right);
                    */
                }

            }
        }
        
    }
}

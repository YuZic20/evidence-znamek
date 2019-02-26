using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClassLibrary1;
using System.Collections.ObjectModel;

namespace App6
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        List<Class> ListPredmety;
        public Page1 ()
		{
			InitializeComponent ();
            loadClass();


		}

        private async Task loadClass()
        {

            predment.SelectedItem = 0;
            ObservableCollection<Class> employees = new ObservableCollection<Class>();
            ListPredmety = await Table.Database.GetItemsAsync<Class>();
            foreach(Class uffclass in ListPredmety)
            {
                employees.Add(uffclass);
            }

            
            predment.ItemsSource = employees;

        }
        private async  Task Button_Clicked(object sender, EventArgs e)
        {
            int TestZnamka;
            int TestVaha;
            int TestPredmet;
            bool isNumeric1 = int.TryParse(znamka.Text, out TestZnamka);
            bool isNumeric2 = int.TryParse(vaha.Text, out TestVaha);

            Class item = (Class)predment.SelectedItem;

           

            

            if (isNumeric1 && isNumeric2)
            {
                await AddZnamkaAsync(TestZnamka, TestVaha, item.Id-1);
                
            }
        }
        private async Task AddZnamkaAsync(int znamka, int vaha, int predmet)
        {
            Mark AddZnamka = new Mark();
            AddZnamka.Znamka = znamka;
            AddZnamka.Vaha = vaha;
            AddZnamka.IdPredmet = predmet;
            await Table.Database.SaveItemAsync(AddZnamka);
        }

        private async Task Button_Clicked_1(object sender, EventArgs e)
        {
            
            await AddClassAsync(novypredmet.Text);

            
        }
        private async Task AddClassAsync(string predment)
        {
            Class NewClass = new Class();
            NewClass.Name = predment;

            await Table.Database.SaveItemAsync(NewClass);
            loadClass();
        }
    }
}
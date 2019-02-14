using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClassLibrary1;

namespace App6
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();

		}

        private async  Task Button_Clicked(object sender, EventArgs e)
        {
            int TestZnamka;
            int TestVaha;
            int TestPredmet;
            bool isNumeric1 = int.TryParse(znamka.Text, out TestZnamka);
            bool isNumeric2 = int.TryParse(vaha.Text, out TestVaha);
            bool isNumeric3 = int.TryParse(predmet.Text, out TestPredmet);

            if (isNumeric1 && isNumeric2 && isNumeric3)
            {
                await AddZnamkaAsync(TestZnamka, TestVaha, TestPredmet);
                
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
    }
}
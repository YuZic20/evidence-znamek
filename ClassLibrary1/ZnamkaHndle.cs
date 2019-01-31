using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ZnamkaHndle
    {
        public static async Task PridatUpravitZnamku(Znamky znamka)
        {

            await Tabulka.Database.SaveItemAsync(znamka);

        }
        public static async Task<Znamky> ZiskatZnamku(int znamka)
        {

            Znamky getznamka;

            getznamka = await Tabulka.Database.GetItemAsync(znamka);

            return getznamka;

        }
        public static async Task<List<Znamky>> ZiskatZnamky()
        {

            List<Znamky> getznamka;

            getznamka = await Tabulka.Database.GetItemsAsync();

            return getznamka;

        }
        public static async Task SmazatZnamku(Znamky znamka)
        {
            await Tabulka.Database.DeleteItemAsync(znamka);

        }
    }
}

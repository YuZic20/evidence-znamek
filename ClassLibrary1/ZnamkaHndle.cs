using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ZnamkaHndle
    {
        
        public static async Task PridatUpravit<T>(T Item) where T : ATabulka, new()
        {

            await Tabulka.Database.SaveItemAsync(Item);

        }
        public static async Task<T> Ziskat<T>(int znamka) where T : ATabulka, new()
        {

            T getznamka;

            getznamka = await Tabulka.Database.GetItemAsync<T>(znamka);

            return getznamka;

        }
        public static async Task<List<T>> Ziskat<T>() where T : ATabulka, new()
        {

            List<T> getznamka;

            getznamka = await Tabulka.Database.GetItemsAsync<T>();

            return getznamka;

        }
        public static async Task Smazat<T>(T znamka) where T : ATabulka, new()
        {
            await Tabulka.Database.DeleteItemAsync(znamka);

        }
    }
}

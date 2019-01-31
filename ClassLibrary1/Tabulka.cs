using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary1
{
    public class Tabulka
    {
        
        static ZnamkyDatabase database;

        public static ZnamkyDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ZnamkyDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Znamky85_SQLite.db3"));
                }
                return database;
            }
        }
        
    }
    
}

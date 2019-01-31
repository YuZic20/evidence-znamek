using SQLite;
using System;

namespace ClassLibrary1
{
    public class Znamky
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public int IdPredmet { get; set; }
        public int Znamka { get; set; }
        public int Vaha { get; set; }
    }
    
}

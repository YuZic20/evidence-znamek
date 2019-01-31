using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Predmet
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public int Nazev { get; set; }

    }
}

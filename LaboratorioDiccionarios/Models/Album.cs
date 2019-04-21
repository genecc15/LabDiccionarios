using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioDiccionarios.Models
{
    public class Album
    {
        public int Codigo { get; set; }
        public string Equipo { get; set; }
        public string Existe { get; set; }
    }

    public class Album2
    {
        public int Codigo2 { get; set; }
        public string Equipo2 { get; set; }
        public bool Existe { get; set; }
    }
}
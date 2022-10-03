using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempinho.Model
{
    class Tempo
    {
        public string Titulo { get; set; }
        public string Temperatura { get; set; }
        public string Vento { get; set; }
        public string Humidade { get; set; }
        public string Visibilidade { get; set; }
        public string NascerSol { get; set; }

        public string Porsol { get; set; }

        public Tempo()
        {
            this.Titulo = "";
            this.Temperatura = "";
            this.Vento = "";
            this.Humidade = "";
            this.Visibilidade = "";
            this.NascerSol = "";
            this.Porsol = "";


        }
    }

}

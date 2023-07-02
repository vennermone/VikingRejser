using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VikingRejser
{
    public class Rejse
    {
        public string Titel { get; set; }
        public string By { get; set; }
        public decimal Pris { get; set; }
        public int MaxAntal { get; set; }
        public string Beskrivelse { get; set; }

        public DateOnly StartDato { get; set; }
        public DateOnly SlutDato { get; set; }
        public int Id { get; set; }



    }
}

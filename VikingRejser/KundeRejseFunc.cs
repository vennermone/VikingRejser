using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace VikingRejser
{
    public class KundeRejseFunc : INotifyPropertyChanged
    {
        private KundeRejseData KundeRejseData { get; set; } = new KundeRejseData();

        public event PropertyChangedEventHandler? PropertyChanged;

        public Kunde OpretKunde(string navn, string adresse, int telefon)
        {
            if (navn == "")
            {
                throw new Exception("Giv den lige et navn tak");
            }
            Kunde kunde = new Kunde();

            // Add inforkmation to kunde
            kunde.Navn = navn;
            kunde.Adresse = adresse;
            kunde.Telefon = telefon;

            KundeRejseData.OpretKunde(kunde);

            return kunde;
        }
        public ObservableCollection<Kunde> Kundeoversigt
        {
            get
            {
                return KundeRejseData.Kundeoversigt;
            }
        }
    }
}

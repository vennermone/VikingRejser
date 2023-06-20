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

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

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
            RaisePropertyChanged(nameof(Kundeoversigt));


            return kunde;
        }
        public ObservableCollection<Kunde> Kundeoversigt
        {
            get
            {
                return KundeRejseData.Kundeoversigt;
            }
        }
        public void Gem(Kunde kunde)
        {
            KundeRejseData.GemKunde(kunde);
            RaisePropertyChanged(nameof(Kundeoversigt));

        }
        public void Remove(Kunde kunde)
        {
            KundeRejseData.SletKunde(kunde);
            RaisePropertyChanged(nameof (Kundeoversigt));
        }

    }
}

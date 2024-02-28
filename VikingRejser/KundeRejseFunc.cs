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
            //Sørger for automatisk at opdatere visningen
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

            // Tilføjer information til kunde
            kunde.Navn = navn;
            kunde.Adresse = adresse;
            kunde.Telefon = telefon;

            KundeRejseData.OpretKunde(kunde);
            RaisePropertyChanged(nameof(Kundeoversigt));


            return kunde;
        }
        public Rejse OpretRejse(string titel, string byen, DateTime startDato, DateTime slutDato, decimal pris, int maxAntal, string beskrivelse)
        {
            Rejse rejse = new Rejse();

            rejse.Titel = titel;
            rejse.Byen = byen;
            rejse.StartDato = startDato;
            rejse.SlutDato = slutDato;
            rejse.Pris = pris;
            rejse.MaxAntal = maxAntal;
            rejse.Beskrivelse = beskrivelse;
            KundeRejseData.OpretRejse(rejse);
            RaisePropertyChanged(nameof(Rejseoversigt)); 
            return rejse;
        }
        public ObservableCollection<Kunde> Kundeoversigt
        {
            get
            {
                return KundeRejseData.Kundeoversigt;
            }
        }
        public ObservableCollection<Rejse> Rejseoversigt
        {
            get
            {
                return KundeRejseData.Rejseoversigt;
            }
        }
        public void GemKunder(Kunde kunde)
        {
            KundeRejseData.GemKunder(kunde);
            RaisePropertyChanged(nameof(Kundeoversigt));

        }
        public void Remove(Kunde kunde)
        {
            KundeRejseData.SletKunde(kunde);
            RaisePropertyChanged(nameof (Kundeoversigt));
        }
        public void GemRejser(Rejse rejse)
        {
            KundeRejseData.GemRejser(rejse);
            RaisePropertyChanged(nameof(Rejseoversigt));

        }

    }
}

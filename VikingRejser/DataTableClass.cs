using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VikingRejser
{
    internal class DataTableClass
    {
        public ObservableCollection<Kunde> GetKundeoversigt(DataTable table)
        {
            ObservableCollection<Kunde> liste = new ObservableCollection<Kunde>();
            foreach (DataRow row in table.Rows)
            {
                Kunde kunde = GetKunde(row);
                liste.Add(kunde);
            }

            return liste;
        }

        private Kunde GetKunde(DataRow row)
        {
            Kunde kunde = new Kunde();
            kunde.Navn = (string) row["Navn"];
            kunde.Adresse = (string)row["Adresse"];
            kunde.Telefon = (int)row["Telefonnummer"];
            kunde.Id = (int)row["Id"];
            return kunde;
        }
        public ObservableCollection<Rejse> GetRejseoversigt(DataTable table)
        {
            ObservableCollection<Rejse> liste = new ObservableCollection<Rejse>();
            foreach (DataRow row in table.Rows)
            {
                Rejse rejse = GetRejse(row);
                liste.Add(rejse);
            }
            return liste;
        }
        private Rejse GetRejse(DataRow row)
        {
            Rejse rejse = new Rejse();
            rejse.Titel = (string)row["Titel"];
            rejse.Byen = (string)row["Byen"];
            rejse.StartDato = (DateTime)row["StartDato"];
            rejse.SlutDato = (DateTime)row["SlutDato"];
            rejse.Pris = (decimal)row["Pris"];
            rejse.MaxAntal = (int)row["MaxAntal"];
            rejse.Beskrivelse = (string)row["Beskrivelse"];
            rejse.Id = (int)row["Id"];
            return rejse;
        }
    }
}

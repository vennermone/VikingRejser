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
            var liste = new ObservableCollection<Kunde>(table.Rows.Cast<DataRow>().Select(GetKunde));
            return liste;
        }

        private Kunde GetKunde(DataRow row)
        {
            return new Kunde
            {
                Navn = (string)row["Navn"],
                Adresse = (string)row["Adresse"],
                Telefon = (int)row["Telefonnummer"],
                Id = (int)row["Id"]
            };
        }

        public ObservableCollection<Rejse> GetRejseoversigt(DataTable table)
        {
            var liste = new ObservableCollection<Rejse>(table.Rows.Cast<DataRow>().Select(GetRejse));
            return liste;
        }

        private Rejse GetRejse(DataRow row)
        {
            return new Rejse
            {
                Titel = (string)row["Titel"],
                Byen = (string)row["Byen"],
                StartDato = (DateTime)row["StartDato"],
                SlutDato = (DateTime)row["SlutDato"],
                Pris = (decimal)row["Pris"],
                MaxAntal = (int)row["MaxAntal"],
                Beskrivelse = (string)row["Beskrivelse"],
                Id = (int)row["Id"]
            };
        }
    }
}

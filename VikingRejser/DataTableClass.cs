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
    }
}

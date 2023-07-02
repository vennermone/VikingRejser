using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace VikingRejser
{
    public class KundeRejseData
    {
        public event PropertyChangedEventHandler PropertyChanged;

        SqlAccess sqlAccess = new SqlAccess();
        DataTableClass converter = new DataTableClass();
        public ObservableCollection<Kunde> Kundeoversigt
        {
            get
            {
                return converter.GetKundeoversigt(sqlAccess.ExecuteSql("select * from Kunder"));
            }
        }
        public ObservableCollection<Rejse> Rejseoversigt
        {
            get
            {
                return converter.GetRejseoversigt(sqlAccess.ExecuteSql("select * from Rejser"));
            }
        }

        public void OpretKunde(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"insert into Kunder (Navn, Adresse, Telefonnummer) values ('{kunde.Navn}','{kunde.Adresse}','{kunde.Telefon}')");

        }
        public void OpretRejse(Rejse rejse)
        {
            sqlAccess.ExecuteSql($"insert into Rejser (Titel, Byen, StartDato, SlutDato, Pris, MaxAntal, Beskrivelse) values ('{rejse.Titel}','{rejse.Byen}','{rejse.StartDato}','{rejse.SlutDato}','{rejse.Pris}','{rejse.MaxAntal}','{rejse.Beskrivelse}')");
        }
        public void GemKunde(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"Update Kunder set Navn = '{kunde.Navn}', Adresse = {kunde.Adresse}, Telefonnummer = '{kunde.Telefon}' where Id={kunde.Id}");
        }
        public void SletKunde(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"delete from Kunder where Id = {kunde.Id}");
        }
    }
    
}

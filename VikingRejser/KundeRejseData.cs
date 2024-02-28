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
        // Event that is raised when a property value changes
        public event PropertyChangedEventHandler PropertyChanged;

        // Instance of the SqlAccess class for executing SQL queries
        SqlAccess sqlAccess = new SqlAccess();

        // Instance of the DataTableClass for converting data between DataTable and ObservableCollection
        DataTableClass converter = new DataTableClass();

        // Property for accessing the collection of customers
        public ObservableCollection<Kunde> Kundeoversigt
        {
            get
            {
                // Retrieve the customer data from the database and convert it to an ObservableCollection
                return converter.GetKundeoversigt(sqlAccess.ExecuteSql("select * from Kunder"));
            }
        }

        // Property for accessing the collection of travels
        public ObservableCollection<Rejse> Rejseoversigt
        {
            get
            {
                // Retrieve the travel data from the database and convert it to an ObservableCollection
                return converter.GetRejseoversigt(sqlAccess.ExecuteSql("select * from Rejser"));
            }
        }

        // Method for creating a new customer record in the database
        public void OpretKunde(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"insert into Kunder (Navn, Adresse, Telefonnummer) values ('{kunde.Navn}','{kunde.Adresse}','{kunde.Telefon}')");
        }

        // Method for creating a new travel record in the database
        public void OpretRejse(Rejse rejse)
        {
            sqlAccess.ExecuteSql($"insert into Rejser (Titel, Byen, StartDato, SlutDato, Pris, MaxAntal, Beskrivelse) values ('{rejse.Titel}','{rejse.Byen}','{rejse.StartDato}','{rejse.SlutDato}','{rejse.Pris}','{rejse.MaxAntal}','{rejse.Beskrivelse}')");
        }

        // Method for updating an existing customer record in the database
        public void GemKunder(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"Update Kunder set Navn = '{kunde.Navn}', Adresse = '{kunde.Adresse}', Telefonnummer = '{kunde.Telefon}' where Id={kunde.Id}");

        }

        // Method for deleting a customer record from the database
        public void SletKunde(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"delete from Kunder where Id = {kunde.Id}");
        }

        // Method for updating an existing travel record in the database
        public void GemRejser(Rejse rejse)
        {
            sqlAccess.ExecuteSql($"Update Rejser set Titel = '{rejse.Titel}', Byen = '{rejse.Byen}', StartDato = '{rejse.StartDato}', SlutDato = '{rejse.SlutDato}' where Id = '{rejse.Id}'");
        }

        // Method for deleting a travel record from the database
        public void SletRejse(Rejse rejse)
        {
            sqlAccess.ExecuteSql($"delete from Rejser where Id = {rejse.Id}");
        }
    }
 }



using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace VikingRejser
{
    internal class KundeRejseData
    {
        SqlAccess sqlAccess = new SqlAccess();
        DataTableClass converter = new DataTableClass();
        public ObservableCollection<Kunde> Kundeoversigt
        {
            get
            {
                return converter.GetKundeoversigt(sqlAccess.ExecuteSql("select * from Kunder"));
            }
        }

        public void OpretKunde(Kunde kunde)
        {

        }
    }
}

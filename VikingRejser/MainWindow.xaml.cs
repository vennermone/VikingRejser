using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VikingRejser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public KundeRejseFunc RejseFunc {get; set;} = new KundeRejseFunc();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bnt_OptretKunde_Click(object sender, RoutedEventArgs e)
        {
            // Find den information brugeren har skrevet ind i text-box-felterne

            // Kald funktionslaget for at oprette ny kunde
            RejseFunc.OpretKunde(Tbox_Navn.Text, Tbox_Adresse.Text, int.Parse(Tbox_Telefon.Text));
        }
    }
}

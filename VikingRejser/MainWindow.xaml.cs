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
    // This line marks the beginning of the class definition for MainWindow

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    // This line declares a public class named MainWindow that inherits from the Window class

    {
        public KundeRejseFunc RejseFunc { get; set; } = new KundeRejseFunc();
        // This line declares a public property named RejseFunc of type KundeRejseFunc and initializes it with a new instance of KundeRejseFunc

        public MainWindow()
        // This line declares a public constructor for the MainWindow class
        {
            InitializeComponent();
            // This line calls the InitializeComponent method, which initializes the components defined in the XAML file

            DataContext = this;
            // This line sets the DataContext property of the MainWindow instance to itself
        }

        private void bnt_OptretKunde_Click(object sender, RoutedEventArgs e)
        // This line declares a private method named bnt_OptretKunde_Click that takes the input from the window and sends it to the database
        {
            

            try
            {
                
                RejseFunc.OpretKunde(Tbox_Navn.Text, Tbox_Adresse.Text, int.Parse(Tbox_Telefon.Text));
                // This line calls the OpretKunde method of the RejseFunc object, passing in the values from the text boxes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // This line displays an error message box with the exception message if an exception occurs
            }
        }

        private void btn_Slet_Click(object sender, RoutedEventArgs e)
        // This line declares a private method named btn_Slet_Click that takes two parameters: sender and e
        {
            RejseFunc.Remove(DG_Kunder.SelectedItem as Kunde);
            // This line calls the Remove method of the RejseFunc object, passing in the selected item from the dg_Kunder data grid as a Kunde object
        }

        private void btn_OpretRejse_Click(object sender, RoutedEventArgs e)
        // This line declares a private method named btn_OpretRejse_Click that takes two parameters: sender and e
        {
            try
            {
                RejseFunc.OpretRejse(TB_Titel.Text, TB_Byen.Text, DateTime.Parse(DP_StartDato.Text), DateTime.Parse(DP_SlutDato.Text), int.Parse(TB_Pris.Text), int.Parse(TB_MaxAntal.Text), Tbox_Beskrivelse.Text);
                // This line calls the OpretRejse method of the RejseFunc object, passing in the values from the text boxes and date picker
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // This line displays an error message box with the exception message if an exception occurs
            }
        }

        private void btn_OpdaterRejse_Click(object sender, RoutedEventArgs e)
        {
            {
                RejseFunc.GemRejser(DG_Rejser.SelectedItem as Rejse);
            }
        }

        private void btn_OpdaterKunde_Click(object sender, RoutedEventArgs e)
        {
            RejseFunc.GemKunder(DG_Kunder.SelectedItem as Kunde);
        }
    }
}

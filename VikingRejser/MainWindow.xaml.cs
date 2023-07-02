﻿using System;
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
            DataContext = this;
        }

        private void bnt_OptretKunde_Click(object sender, RoutedEventArgs e)
        {
            // Find den information brugeren har skrevet ind i text-box-felterne
            try
            { 
            // Kald funktionslaget for at oprette ny kunde
            RejseFunc.OpretKunde(Tbox_Navn.Text, Tbox_Adresse.Text, int.Parse(Tbox_Telefon.Text));
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Slet_Click(object sender, RoutedEventArgs e)
        {
            RejseFunc.Remove(dg_Kunder.SelectedItem as Kunde);
        }

        private void btn_OpretRejse(object sender, RoutedEventArgs e)
        {
            try
            {
                //var DatoTid = DP_StartDato.DisplayDate
                //DateOnly dateOnly = DP_StartDato.SelectedDate.Value.;
                RejseFunc.OpretRejse(TB_Titel.Text, TB_By.Text, DateOnly.Parse(DP_StartDato.Text), DateOnly.Parse(DP_SlutDato.Text), int.Parse(TB_Pris.Text), int.Parse(TB_MaxAntal.Text), Tbox_Beskrivelse.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf_DrugDonation
{
    /// <summary>
    /// Interaction logic for W_Withdraw.xaml
    /// </summary>
    public partial class W_Withdraw : Window
    {

        public W_Withdraw()
        {
            InitializeComponent();
        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (chckBx_Withdrawn.IsChecked==false) //checkbox not checked
            {
                var filter = Tbx_filter.Text.ToLower();

                if (filter == "")
                {
                    Dg_AllMedicines.ItemsSource = App._allMedicines;
                    return;
                }
                else if (filter == Tbx_filter.Text.ToLower())
                {
                    var lst = from s in App._allMedicines where (s.medName.ToLower().Contains(filter) | s.serialNumber.ToLower().Contains(filter)) select s; //Using LINQ to filter medicine by name or serial number 
                    var lstMedicines = (from x in App._allMedicines where (x.medName.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) | x.serialNumber.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase)) select x).ToList(); //Using LINQ and adding to a list
                    lstMedicines.AddRange(lst);
                    Dg_AllMedicines.ItemsSource = lstMedicines.Distinct();

                }
            }
            else if (chckBx_Withdrawn.IsChecked==true) //checkbox checked
            {
                var filter = Tbx_filter.Text.ToLower();

                if (filter == "")
                {
                    Dg_AllMedicines.ItemsSource = App._withdrawnMedicines;
                    return;
                }
                else if (filter == Tbx_filter.Text.ToLower())
                {
                    var lst = from s in App._withdrawnMedicines where (s.medName.ToLower().Contains(filter) | s.serialNumber.ToLower().Contains(filter)) select s;
                    var lstMedicines = (from x in App._withdrawnMedicines where (x.medName.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) | x.serialNumber.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase)) select x).ToList();
                    lstMedicines.AddRange(lst);
                    Dg_AllMedicines.ItemsSource = lstMedicines.Distinct();

                }
            }
           
        }

        private void Dg_AllMedicines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chckBx_Withdrawn.IsChecked==true)
            {
                Btn_Withdraw_med.IsEnabled = false;
                Btn_DonorDetails.IsEnabled = true;
            }
            else
            {
                Btn_Withdraw_med.IsEnabled = true;
                Btn_DonorDetails.IsEnabled = true;
            }
                
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           Dg_AllMedicines.ItemsSource = App._allMedicines;    
        }

        private void Btn_Donate_Click(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow(); //taking to MainWindow
            this.Close();
            win.Show();
        }

        private void Btn_Withdraw_med_Click(object sender, RoutedEventArgs e)
        {
            
            var medSelected = Dg_AllMedicines.SelectedItem;
            var medicine = medSelected as Medicine;
            App._withdrawnMedicines.Add(medicine); // adding medicine to withdrawn collection
            App._allMedicines.Remove(medicine); // removing medicine from allMedicines collection
            MyStorage.WriteXml<ObservableCollection<Medicine>>(App._withdrawnMedicines, "withdrawnMedicines.xml");
            MyStorage.WriteXml<ObservableCollection<Medicine>>(App._allMedicines, "allMedicines.xml");
            MessageBox.Show($"{medicine.medName} withdrawn!");
        }

        private void chckBx_Withdrawn_Checked(object sender, RoutedEventArgs e)
        {    
            Dg_AllMedicines.ItemsSource = App._withdrawnMedicines;
            Tblck_withdrawals_details.Text = "Withdrawn Medicine Details"; 
            Btn_Withdraw_med.IsEnabled = false;    
        }

        private void chckBx_Withdrawn_Unchecked(object sender, RoutedEventArgs e)
        {
            Dg_AllMedicines.ItemsSource = App._allMedicines;
            Tblck_withdrawals_details.Text = "Medicine Details";
        }

        private void Btn_DonorDetails_Click(object sender, RoutedEventArgs e)
        {
            var medSelected = Dg_AllMedicines.SelectedItem;
            var med = new DonorDetails { donorID = (medSelected as Medicine).donorID }; //picking donorID from Medicine collection and adding to a new collection
            App._selectedItem.Add(med);

            var win = new MainWindow(); //taking to MainWindow
            win.Show();
            this.Close();
        }
    }
}

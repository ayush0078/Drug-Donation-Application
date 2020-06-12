using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Wpf_DrugDonation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tbx_Med_Expiry.DisplayDateStart = DateTime.Today; //to display date from today

            if (App._selectedItem.Count > 0)
            {
                for (int i = 0; i < App._donors.Count; i++)
                {
                    if (App._donors[i].donorID == App._selectedItem[0].donorID)
                    {
                        Sp_Donor_Details.DataContext = App._donors[i];
                        Dg_Donor.SelectedItem = App._donors[i];
                        
                        App._selectedItem.Clear();
                        break;
                    }
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dg_Donor.ItemsSource = App._donors; 
        }

        private void Btn_Donor_Add_Click(object sender, RoutedEventArgs e)
        {
            Guid IDgen = Guid.NewGuid(); // to generate random id for donor
            Tbx_filter.Text = "";

            var dnr = new Donor { donorID = IDgen.ToString(), firstName = "", lastName = "", governmentID = "", contactNumber = "" , medicines = new ObservableCollection<Medicine>()};
            App._donors.Add(dnr);
            Dg_Donor.SelectedItem = dnr;
            Dg_Donor.ScrollIntoView(dnr);

            if (Dg_Donor.SelectedItem == dnr) // dnr selected in the data grid
            {
                Tbx_cNumber.IsEnabled = true;
                Tbx_fName.IsEnabled = true;
                Tbx_lName.IsEnabled = true;
                Tbx_gID.IsEnabled = true;
                Btn_Donor_Edit.IsEnabled = false;
                Tab_prsnl.IsSelected = true;
                Btn_Donor_Save.IsEnabled = true;
            }
        }

        private void Btn_Donor_Del_Click(object sender, RoutedEventArgs e)
        {
            Tbx_filter.Text = "";

            var itm2delete = Dg_Donor.SelectedItem;
            if (itm2delete==null)
            {
                MessageBox.Show("Please select donor to be deleted first!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var donor = itm2delete as Donor; 
            var res = MessageBox.Show($"Do you really want to delete {donor.firstName} {donor.lastName}", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res==MessageBoxResult.Yes)
            {
                App._donors.Remove(donor);
                MyStorage.WriteXml<ObservableCollection<Donor>>(App._donors, "donors.xml");
            }
        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = Tbx_filter.Text.ToLower(); 

            if (filter=="")
            {
                Dg_Donor.ItemsSource = App._donors;
                return;
            }
            else if (filter == Tbx_filter.Text.ToLower())
            {
                var lst = from s in App._donors where (s.firstName.ToLower().Contains(filter) | s.lastName.ToLower().Contains(filter) | s.governmentID.ToLower().Contains(filter)) select s; // using LINQ to filter donor by firstname, lastname and GovernmentID
                var lstDonors = (from x in App._donors where (x.firstName.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) | x.lastName.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) | x.governmentID.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase)) select x).ToList(); // using LINQ and adding to a list
                lstDonors.AddRange(lst);
                Dg_Donor.ItemsSource = lstDonors.Distinct();

            }
        }

        private void Btn_Donor_Edit_Click(object sender, RoutedEventArgs e)
        {
            //to enable textboxes to edit donor details
            Tbx_fName.IsEnabled = true;
            Tbx_lName.IsEnabled = true;
            Tbx_cNumber.IsEnabled = true;
            Btn_Donor_Save.IsEnabled = true;
            Btn_Donor_Edit.IsEnabled = false;
        }

        private void Btn_Med_Add_Click(object sender, RoutedEventArgs e)
        {
            var dSelected = Dg_Donor.SelectedItem;
            if (dSelected == null)
            {
                MessageBox.Show("Please select a donor first!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                

                var med = new Medicine {donorID = (dSelected as Donor).donorID,  serialNumber = "", medName = "", strength = "", expiryDate = DateTime.Today, packSize = 0 };
                (dSelected as Donor).medicines.Add(med);
                App._allMedicines.Add(med);
                Dg_Med_list.SelectedItem = med;
                Dg_Med_list.ScrollIntoView(med);

                if (Dg_Med_list.SelectedItem == med)
                {
                    Tbx_Med_sNum.IsEnabled = true;
                    Tbx_Med_Name.IsEnabled = true;
                    Tbx_Med_Strength.IsEnabled = true;
                    Tbx_Med_Expiry.IsEnabled = true;
                    Tbx_Med_PackSize.IsEnabled = true;
                    Btn_Med_Save.IsEnabled = true;
                }
            }
        }

        private void Dg_Donor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dSelected = Dg_Donor.SelectedItem;
            Sp_Donor_Details.DataContext = Dg_Donor.SelectedItem;
            if (dSelected == null)
            {
                Btn_Donor_Edit.IsEnabled = false;
            }
            else
            {
                Tbx_cNumber.IsEnabled = false;
                Tbx_fName.IsEnabled = false;
                Tbx_gID.IsEnabled = false;
                Tbx_lName.IsEnabled = false;
                Btn_Donor_Edit.IsEnabled = true;
            }
            
        }
        private void Btn_Med_Del_Click_1(object sender, RoutedEventArgs e)
        {
            var dSelected = Dg_Donor.SelectedItem;
            if (dSelected == null)
            {
                MessageBox.Show("Please select a donor first!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var med = Dg_Med_list.SelectedItem;
                var medicine = med as Medicine;
                var res = MessageBox.Show($"Do you really want to delete {medicine.medName}", "warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    (dSelected as Donor).medicines.Remove(medicine); // remove medicine from donor collection
                    App._allMedicines.Remove(medicine); // remove medicine from allMedicine collection
                    MyStorage.WriteXml<ObservableCollection<Donor>>(App._donors, "donors.xml");
                    MyStorage.WriteXml<ObservableCollection<Medicine>>(App._allMedicines, "allMedicines.xml");
                }

            }            
        }

        private void Btn_Donor_Save_Click(object sender, RoutedEventArgs e)
        {
            var input = Tbx_cNumber.Text;
            var regEx = new Regex(@"(^\+[0-9]{2}\s+[0-9]{2}\s+[0-9]{8}$)|(^\+[0-9]{2}\s+[0-9]{3}\s+[0-9]{8}$)|(^\+[0-9]{2}\s+[0-9]{4}\s+[0-9]{8}$)|(^\+[0-9]{2}\s+[0-9]{5}\s+[0-9]{8}$)"); //regular expression for contact details to be taken in the format

            if (Tbx_fName.Text == "" | Tbx_lName.Text == "" | Tbx_gID.Text == "") // checking textbox to not be empty
            {
                MessageBox.Show("Please fill-in all the fields first!");
            }
            else if (!regEx.IsMatch(input)) //checking redular expression to be matched with the given input
            {
                MessageBox.Show("Please Enter a valid Telephone number in the format of ", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MyStorage.WriteXml<ObservableCollection<Donor>>(App._donors, "donors.xml");
                Btn_Donor_Edit.IsEnabled = true;
                Btn_Donor_Save.IsEnabled = false;
                Tbx_cNumber.IsEnabled = false;
                Tbx_fName.IsEnabled = false;
                Tbx_lName.IsEnabled = false;
                Tbx_gID.IsEnabled = false;
            }

        }

        private void Dg_Med_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tbx_Med_sNum.IsEnabled = false;
            Tbx_Med_Name.IsEnabled = false;
            Tbx_Med_Strength.IsEnabled = false;
            Tbx_Med_Expiry.IsEnabled = false;
            Tbx_Med_PackSize.IsEnabled = false;
        }

        private void Btn_Med_Save_Click(object sender, RoutedEventArgs e)
        {

            if (Tbx_Med_sNum.Text == "" | Tbx_Med_Name.Text == ""| Tbx_Med_Strength.Text == "" | Tbx_Med_Expiry.SelectedDate == DateTime.Today | Tbx_Med_PackSize.Text == Convert.ToString("")) //checking for textboxes to be not empty
            {
                MessageBox.Show("Please fill-in all the fields first!");
            }
            else
            {
                MyStorage.WriteXml<ObservableCollection<Donor>>(App._donors, "donors.xml");
                MyStorage.WriteXml<ObservableCollection<Medicine>>(App._allMedicines, "allMedicines.xml");
                Tbx_Med_sNum.IsEnabled = false;
                Tbx_Med_Name.IsEnabled = false;
                Tbx_Med_Strength.IsEnabled = false;
                Tbx_Med_Expiry.IsEnabled = false;
                Tbx_Med_PackSize.IsEnabled = false;
                Btn_Med_Save.IsEnabled = false;
            }

        }

        private void Btn_Withdraw_Click(object sender, RoutedEventArgs e)
        {
            var win = new W_Withdraw(); //taking to another window
            win.Show();
            this.Close();
        }
    }
}

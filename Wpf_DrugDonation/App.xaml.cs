using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_DrugDonation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Donor> _donors;
        public static ObservableCollection<Medicine> _allMedicines;
        public static ObservableCollection<Medicine> _withdrawnMedicines;
        public static ObservableCollection<DonorDetails> _selectedItem;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _donors = MyStorage.ReadXml<ObservableCollection<Donor>>("donors.xml");
            if (_donors == null)
            {
                _donors = new ObservableCollection<Donor>();
            }

            _allMedicines = MyStorage.ReadXml<ObservableCollection<Medicine>>("allMedicines.xml");
            if (_allMedicines==null)
            {
                _allMedicines = new ObservableCollection<Medicine>();
            }

            _withdrawnMedicines = MyStorage.ReadXml<ObservableCollection<Medicine>>("withdrawnMedicines.xml");
            if (_withdrawnMedicines==null)
            {
                _withdrawnMedicines = new ObservableCollection<Medicine>();
            }

            _selectedItem = new ObservableCollection<DonorDetails>();

        }
    }
}

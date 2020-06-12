using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security;
using System.Windows.Navigation;

namespace Wpf_DrugDonation
{
    public class Donor
    {
        public string donorID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string governmentID { get; set; }
        public string contactNumber { get; set; }
        public ObservableCollection<Medicine> medicines { get; set; }
    }

    public class Medicine
    {
        public string donorID { get; set; }
        public string serialNumber { get; set; }
        public string medName { get; set; }
        public string strength { get; set; }
        public DateTime? expiryDate { get; set; }
        public int packSize { get; set; }
    }
}
using Stock_Management_System.Models;
using System.Collections.Generic;

namespace Stock_Management_System.ViewModels
{
    public class DashboardViewModel
    {
        public List<SellItems> SellItems { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<View> ViewAllItems { get; set; }

        public List<RegisterViewModels> AspNetUsers { get; set; }
        public SellItems MaxTotalSoldItem { get; set; }

        public SellItems MaxItemsSoldItem { get; set; }

        public View MaxItemsViewItem { get; set; }

        public int TotalSuppliers { get; set; }

        public int TotalProducts { get; set; }

        public int TotalSoldProducts { get; set; }

    }
}

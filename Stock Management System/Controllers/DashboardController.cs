using Microsoft.AspNetCore.Mvc;
using Stock_Management_System.Controllers.Data;
using Stock_Management_System.ViewModels;
using System.Linq;

public class DashboardController : Controller
{
    private readonly SupplierDbContext _supplierContext;
    private readonly OrderDbContext _orderContext;
    private readonly StockDbContext _stockContext;
    private readonly AppDbContext _appContext;
   

    public DashboardController(SupplierDbContext supplierContext, OrderDbContext orderContext, StockDbContext stockContext, AppDbContext appContext)
    {
        _supplierContext = supplierContext;
        _orderContext = orderContext;
        _stockContext = stockContext;
        _appContext = appContext;
    }
    public IActionResult Dashboard()
    {
        // Retrieve data from multiple tables
        var suppliers = _supplierContext.Suppliers.ToList();
        var viewAllItems = _stockContext.ViewAllItems.ToList();
        var soldItems = _orderContext.SoldItems.ToList();

       
        int totalSoldProducts = soldItems.Count;

       
        int totalViewAllProducts = viewAllItems.Count;

       
        int totalProducts = totalSoldProducts + totalViewAllProducts;

        
        var totalSuppliers = suppliers.Count;

        var maxTotalSoldItem = soldItems.OrderByDescending(item => item.Total).FirstOrDefault();
        var maxItemsSoldItem = soldItems.OrderByDescending(item => item.Items).FirstOrDefault();
        var maxItemsViewItem = viewAllItems.OrderByDescending(item => item.Item).FirstOrDefault();

        var viewModel = new DashboardViewModel
        {
            Suppliers = suppliers,
            SellItems = soldItems,
            ViewAllItems = viewAllItems,
            MaxTotalSoldItem = maxTotalSoldItem, 
            MaxItemsSoldItem = maxItemsSoldItem,
            MaxItemsViewItem = maxItemsViewItem,
            TotalSuppliers = totalSuppliers, 
            TotalSoldProducts = totalSoldProducts,
           
            TotalProducts = totalProducts 
        };

        return View(viewModel);
    }



    public IActionResult Profile()
    {
        return View();
    }
    public IActionResult CustomerSupport()
    {
        return View();
    }
}

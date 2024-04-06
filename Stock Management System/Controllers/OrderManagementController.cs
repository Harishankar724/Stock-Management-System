using Microsoft.AspNetCore.Mvc;
using Stock_Management_System.Controllers.Data;
using Stock_Management_System.Models;

namespace Stock_Management_System.Controllers
{
    public class OrderManagement : Controller
    {

        private readonly OrderDbContext db1;

        public OrderManagement(OrderDbContext context)
        {
            db1 = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SellManagement(SellItems model)
        {
            // Calculate the total price
            model.Total = model.Product_Price * model.Items;

            // Add the model to the database context
            db1.SoldItems.Add(model);

            // Save changes to the database
            db1.SaveChanges();

            return RedirectToAction("SoldData");
        }

        public IActionResult SoldData()
        {
            var data = db1.SoldItems.ToList();
            return View(data);
        }

        public IActionResult Remove(int id)
        {

            var data = db1.SoldItems.Find(id);

            if (data == null)
            {
                return NotFound(); // Or handle the case where the supplier with the given id is not found
            }

            db1.SoldItems.Remove(data);
            db1.SaveChanges();

            return RedirectToAction("SoldData");
        }

    }
}

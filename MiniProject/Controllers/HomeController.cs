using MiniProject.Models;
using MiniProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly OrderDBEntities orderDBEntities;
        public HomeController()
        {
            orderDBEntities = new OrderDBEntities();
        }
        public ActionResult Index()
        {
            var objCustomerRepository = new CustomerRepository();
            var objItemRepository = new ItemRepository();
            var objPaymentRepository = new PaymentTypeRepository();
            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(
                    objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentRepository.GetAllPaymentType());
            return View(objMultipleModels);
        }
        [HttpGet]



        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = orderDBEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }
    }
}
using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject.Repositories
{
    public class CustomerRepository
    {
        private readonly OrderDBEntities orderDBEntities;
        public CustomerRepository()
        {
            orderDBEntities = new OrderDBEntities();
        }



        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();



            objSelectListItems = (
                                     from obj in orderDBEntities.Customers
                                     select new SelectListItem
                                     {
                                         Text = obj.CustomerName,
                                         Value = obj.CustomerId.ToString(),
                                         Selected = true
                                     }
                                 ).ToList();



            return objSelectListItems;
        }
    }
}
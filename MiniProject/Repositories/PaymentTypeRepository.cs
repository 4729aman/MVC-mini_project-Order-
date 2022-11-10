using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject.Repositories
{
    public class PaymentTypeRepository
    {
        private readonly OrderDBEntities orderDBEntities;
        public PaymentTypeRepository()
        {
            orderDBEntities = new OrderDBEntities();
        }



        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();



            objSelectListItems = (
                                     from obj in orderDBEntities.PaymentTypes
                                     select new SelectListItem
                                     {
                                         Text = obj.PaymentTypeName,
                                         Value = obj.PaymentTypeId.ToString(),
                                         Selected = true
                                     }
                                 ).ToList();



            return objSelectListItems;
        }
    }
}
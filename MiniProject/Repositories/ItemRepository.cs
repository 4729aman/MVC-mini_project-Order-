using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject.Repositories
{
   
        public class ItemRepository
        {
            private readonly OrderDBEntities orderDBEntities;
            public ItemRepository()
            {
                orderDBEntities = new OrderDBEntities();
            }



            public IEnumerable<SelectListItem> GetAllItems()
            {
                IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();



                objSelectListItems = (
                                         from obj in orderDBEntities.Items
                                         select new SelectListItem
                                         {
                                             Text = obj.ItemName,
                                             Value = obj.ItemId.ToString(),
                                             Selected = true
                                         }
                                     ).ToList();



                return objSelectListItems;
            }
        }
}
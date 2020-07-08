
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingCompany.Models;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace ClothingCompany.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Index()
        {
            var footerFolder = Sitecore.Context.Database.GetItem("/sitecore/content/Home/Resources");

            // Ctrl + K + C to comment out block of code & Ctrl + K + U to undo it
            IEnumerable<NavItem> GetNavItems(Item navRoot)
            {
                var items = new List<Item> { navRoot };
                items.AddRange(navRoot.Children.Where(item => item.DescendsFrom(new Sitecore.Data.ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}"))));
                var navItems = items.Skip(1).Select(item => new NavItem
                {
                    Item = item,
                    Url = LinkManager.GetItemUrl(item),
                }).ToList();
                return navItems;
            }
            return View();
        }
    }
}
using ClothingCompany.Models;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingCompany.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Index()
        {
            Item homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

            // In-controller function that would normally be separated out
            // Provide it with the Home item and have it return a list of NavItem children items
            IEnumerable<NavItem> GetNavItems(Item navRoot)
            {
                var items = new List<Item> { navRoot };
                items.AddRange(navRoot.Children.Where(item => item.DescendsFrom(new Sitecore.Data.ID("{B73DBC32-A17B-4329-A49E-02D46F22229A}"))));

                // Loop over items in list to get each item's url and create the NavItems List
                var navItems = items.Select(item => new NavItem
                {
                    Item = item,
                    Url = LinkManager.GetItemUrl(item),
                }).ToList();

                return navItems;
            }

            // populate NavGroup model itself
            var navigation = new NavGroup
            {
                RootItem = homeItem,
                RootUrl = LinkManager.GetItemUrl(homeItem),
                NavItems = GetNavItems(homeItem)
            };

            return View(navigation);
        }
    }
}
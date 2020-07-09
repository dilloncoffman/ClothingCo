using System.Linq;
using System.Web.Mvc;
using ClothingCompany.Models;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;

namespace ClothingCompany.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        public ActionResult Index()
        {
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var pageList = new Listing();

            if (dataSourceId != null)
            {
                var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
                if (dataSource != null)
                {
                    var listofArticles = dataSource.Children;
                    pageList.Posts = listofArticles.Select(item => new NavItem
                    {
                        Item = item,
                        Url = LinkManager.GetItemUrl(item),
                    }).ToList();
                }
            }
            return View(pageList);
        }
    }
}
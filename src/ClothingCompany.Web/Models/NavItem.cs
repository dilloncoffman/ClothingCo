using Sitecore.Data.Items;

namespace ClothingCompany.Models
{
    public class NavItem : Sitecore.Mvc.Presentation.RenderingModel
    {
        public Item Item { get; set; }
        public string Url { get; set; }
    }
}
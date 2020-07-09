using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;

namespace ClothingCompany.Models
{
    public class Listing
    {
        public Item ParentItem { get; set; }
        public IEnumerable<NavItem> Posts { get; set; } = Enumerable.Empty<NavItem>();
    }
}
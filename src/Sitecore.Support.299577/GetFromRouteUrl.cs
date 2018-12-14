using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.IO;
using Sitecore.Mvc.Configuration;
using Sitecore.Mvc.Data;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Pipelines.Response.GetPageItem;
using Sitecore.Sites;
using System;
using System.Linq;
using System.Web.Routing;


namespace Sitecore.Support.Mvc.Pipelines.Response.GetPageItem
{
    public class GetFromRouteUrl : Sitecore.Mvc.Pipelines.Response.GetPageItem.GetFromRouteUrl
    {
        protected override Item ResolveItem(GetPageItemArgs args)
        {
            string path = this.GetPath(args.RouteData);
            Item item = Context.Item;
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }
            else
            {
                SiteContext site = Context.Site;
                if ((site != null) && path.Equals(site.VirtualFolder.Substring(0, site.VirtualFolder.Length - 1)))
                {
                    return null;
                }
            }
            return base.GetItem(path, args);
        }
    }
}

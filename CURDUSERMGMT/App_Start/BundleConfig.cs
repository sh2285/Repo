using System.Web;
using System.Web.Optimization;

namespace CURDUSERMGMT
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/font-awesome.min.css",
                       "~/Content/fonts/fontawesome-webfont.eot",
                       "~/Content/fonts/fontawesome-webfont.svg",
                       "~/Content/fonts/fontawesome-webfont.ttf",
                       "~/Content/fonts/fontawesome-webfont.woff",
                       "~/Content/fonts/FontAwesome.otf",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/font-awesome-4.1.0").Include(
                "~/Content/font-awesome-4.1.0/font-awesome.min.css"
                ));
        }
    }
}

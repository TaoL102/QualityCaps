using System.Web;
using System.Web.Optimization;

namespace QualityCaps
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bundleJquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/bundleModernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bundleBootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bundleCustomizedJS").Include(
                      "~/Scripts/jquery.dropdown.js",
                      "~/Scripts/jquery.tagsinput.js",                     
                       "~/Scripts/material.min.js",
                     
                      "~/Scripts/nouislider.min.js",
                      "~/Scripts/material-kit.js",/*"~/Scripts/creative.js",*/
                      "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/bundles/bundleCss").Include(
                      "~/Content/bootstrap.css").Include(
               "~/Content/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bundleCustomizedCSS").Include(
                 "~/Content/material-kit.css", new CssRewriteUrlTransform()).Include(
                //"~/Content/creative.css",
                      "~/Content/site.css"));
        }
    }
}

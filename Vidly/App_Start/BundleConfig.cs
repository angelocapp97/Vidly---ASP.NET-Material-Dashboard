using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // Per altre informazioni sulla creazione di bundle, vedere https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                        "~/Content/js/jquery-3.1.0.min.js",
                        "~/Content/js/bootstrap.min.js",
                        "~/Content/js/material.min.js",
                        "~/Scripts/bootbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartist").Include(
                        "~/Content/js/chartist.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-notify").Include(
                        "~/Content/js/bootstrap-notify.js"));

            bundles.Add(new ScriptBundle("~/bundles/material-dashboard").Include(
                        "~/Content/js/material-dashboard.js"));

            bundles.Add(new ScriptBundle("~/bundles/demo").Include(
                        "~/Content/js/site.js"));




            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/material-dashboard").Include(
                      "~/Content/css/material-dashboard.css"));

            bundles.Add(new StyleBundle("~/Content/demo").Include(
                      "~/Content/css/site.css"));
        }
    }
}

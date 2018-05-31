using System.Web.Optimization;

namespace SimpleNews
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region admin layout styles
            bundles.Add(new StyleBundle("~/admin/global-mandatory")
                .Include("~/Areas/Admin/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css")
                .Include("~/Areas/Admin/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css")
                .Include("~/Areas/Admin/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css")
                .Include("~/Areas/Admin/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css")
            );

            bundles.Add(new StyleBundle("~/admin/global")
                .Include("~/Areas/Admin/Content/assets/global/css/components.min.css")
                .Include("~/Areas/Admin/Content/assets/global/css/plugins.min.css")
            );

            bundles.Add(new StyleBundle("~/admin/layout-style")
                .Include("~/Areas/Admin/Content/assets/layouts/layout/css/layout.min.css")
                .Include("~/Areas/Admin/Content/assets/layouts/layout/css/themes/darkblue.min.css")
                .Include("~/Areas/Admin/Content/assets/layouts/layout/css/custom.min.css")
            );
            #endregion

            #region admin layout scripts
            bundles.Add(new ScriptBundle("~/admin/core-begin")
                .Include("~/Areas/Admin/Content/assets/global/plugins/jquery.min.js")
                .Include("~/Areas/Admin/Content/assets/global/plugins/bootstrap/js/bootstrap.min.js")
                .Include("~/Areas/Admin/Content/assets/global/plugins/js.cookie.min.js")
                .Include("~/Areas/Admin/Content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js")
                .Include("~/Areas/Admin/Content/assets/global/plugins/jquery.blockui.min.js")
                .Include("~/Areas/Admin/Content/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js")
            );

            bundles.Add(new ScriptBundle("~/admin/global-scripts")
                .Include("~/Areas/Admin/Content/assets/global/scripts/app.min.js")
            );

            bundles.Add(new ScriptBundle("~/admin/layout-scripts")
                .Include("~/Areas/Admin/Content/assets/layouts/layout/scripts/layout.min.js")
            );
            #endregion


            bundles.Add(new StyleBundle("~/admin/datatable-style")
                .Include("~/Areas/Admin/Content/assets/global/plugins/datatables/datatables.min.css")
                .Include("~/Areas/Admin/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css")
            );

            bundles.Add(new ScriptBundle("~/admin/datatable-script")
                .Include("~/Areas/Admin/Content/assets/global/scripts/datatable.min.js")
                .Include("~/Areas/Admin/Content/assets/global/plugins/datatables/datatables.min.js")
                .Include("~/Areas/Admin/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js")
                .Include("~/Areas/Admin/Content/assets/pages/scripts/table-datatables-buttons.js")
                );




            #region Site
            bundles.Add(new StyleBundle("~/style")
                .Include("~/Content/assets/font/font-awesome.min.css")
                .Include("~/Content/assets/font/font.css")
                .Include("~/Content/assets/css/bootstrap.min.css")
                .Include("~/Content/assets/css/style.css")
                .Include("~/Content/assets/css/responsive.css")
                .Include("~/Content/assets/css/jquery.bxslider.css")
                );

            bundles.Add(new ScriptBundle("~/scripts")
                .Include("~/Content/assets/js/jquery-min.js")
                .Include("~/Content/assets/js/bootstrap.min.js")
                .Include("~/Content/assets/js/jquery.bxslider.js")
                .Include("~/Content/assets/js/selectnav.min.js")
                );
            #endregion

        }
    }
}
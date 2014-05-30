using Microsoft.Phone.Shell;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;

using Microsoft.Phone.Info;
using Microsoft.Phone.Controls;

namespace WPCordovaClassLib.Cordova.Commands
{
    public class ViewportHeight : BaseCommand
    {
        public void get(string options)
        {
            // http://developer.nokia.com/community/wiki/Setting_WebBrowser_control_viewport_dimensions
            // http://mail-archives.apache.org/mod_mbox/cordova-dev/201403.mbox/%3CCAKP6k2s=mgWtwLTD_h_2CTLss52VV81i4rdg8dxX4hSg0qp-yw@mail.gmail.com%3E
            string height = "";
            try
            {
                var _resolution = (Size)DeviceExtendedProperties.GetValue("PhysicalScreenResolution");
                height = _resolution.Height.ToString();
                
            }
            catch
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    Application app = Application.Current;
                    if (app.RootVisual != null)
                    {
                        height = (app.RootVisual.RenderSize.Height * app.Host.Content.ScaleFactor / 100).ToString();
                        DispatchCommandResult(new PluginResult(PluginResult.Status.OK, height));
                    }
                    else
                    {
                        DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, "Could not compute viewport height!"));
                    }
                });
                return;
            }

            DispatchCommandResult(new PluginResult(PluginResult.Status.OK, height));
        }
    }
}
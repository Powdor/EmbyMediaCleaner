using System;
using MediaBrowser.Common.Plugins;
using Emby.Plugins.AutoMediaCleaner.Config;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Model.Serialization;
using MediaBrowser.Model.Plugins;

namespace XNet.Emby.Plugins.AutoMediaCleaner
{
    public class Plugin : BasePlugin<AutoMediaCleanerConfig>
    {
        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) : base(applicationPaths, xmlSerializer)
        {
        }

        public override Guid Id => new Guid("e4aa099e-ce35-4dca-b596-cebf13e05598");
        public override string Name => "XNet Emby AutoMediaCleaner Plugin";

        public override string Description => base.Description;

        public override string ConfigurationFileName => base.ConfigurationFileName;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override PluginInfo GetPluginInfo()
        {
            return base.GetPluginInfo();
        }

        public override void OnUninstalling()
        {
            base.OnUninstalling();
        }

        public override void SaveConfiguration()
        {
            base.SaveConfiguration();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void UpdateConfiguration(BasePluginConfiguration configuration)
        {
            base.UpdateConfiguration(configuration);
        }
    }
}

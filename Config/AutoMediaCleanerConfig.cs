using MediaBrowser.Model.Plugins;

namespace Emby.Plugins.AutoMediaCleaner.Config 
{
    public class AutoMediaCleanerConfig : BasePluginConfiguration
    {
        public int MaxAgeInDays {get; set;}
        public bool SkipFavorites {get;set;} 
    }
}
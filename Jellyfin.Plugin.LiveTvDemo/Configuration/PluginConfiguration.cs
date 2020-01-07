using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.LiveTvDemo.Configuration
{
    public enum SomeOptions
    {
        OneOption,
        AnotherOption
    }

    public class PluginConfiguration : BasePluginConfiguration
    {
        // store configurable settings your plugin might need
        public string AString { get; set; }
        
        public PluginConfiguration()
        {
            
        }
    }
}

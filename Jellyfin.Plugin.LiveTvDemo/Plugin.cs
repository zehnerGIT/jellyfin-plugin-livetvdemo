using System;
using System.Collections.Generic;
using Jellyfin.Plugin.LiveTvDemo.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.LiveTvDemo
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public override string Name => "LiveTvDemo";

        public override Guid Id => Guid.Parse("49BF45C8-DE97-465A-BC5E-8CD9ACE1B10B");

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }

        public static Plugin Instance { get; private set; }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = this.Name,
                    EmbeddedResourcePath = string.Format("{0}.Configuration.configPage.html", GetType().Namespace)
                }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Controller.Channels;
using MediaBrowser.Controller.LiveTv;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Entities;

namespace Jellyfin.Plugin.LiveTvDemo
{
    public class RecordingsChannel : IChannel
    {
        private ILiveTvManager _liveTvManager;

        public RecordingsChannel(ILiveTvManager liveTvManager)
        {
            _liveTvManager = liveTvManager;
        }
        public InternalChannelFeatures GetChannelFeatures()
        {
            throw new System.NotImplementedException();
        }

        public bool IsEnabledFor(string userId)
        {
            return true;
        }

        public async Task<ChannelItemResult> GetChannelItems(InternalChannelItemQuery query, CancellationToken cancellationToken)
        {
            var result = new ChannelItemResult()
            {
                Items = new List<ChannelItemInfo>()
            };
            result.Items.AddRange(DataGenerator.GetChannelItemInfos());
            return result;
        }

        public Task<DynamicImageResponse> GetChannelImage(ImageType type, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ImageType> GetSupportedChannelImages()
        {
            throw new System.NotImplementedException();
        }

        public string Name => "RecordingsChannel";
        public string Description { get; }
        public string DataVersion { get; }
        public string HomePageUrl { get; }
        public ChannelParentalRating ParentalRating => ChannelParentalRating.GeneralAudience;
    }
}

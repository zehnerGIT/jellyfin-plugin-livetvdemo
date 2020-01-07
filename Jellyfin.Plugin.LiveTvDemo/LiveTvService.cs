using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Common.Net;
using MediaBrowser.Controller.LiveTv;
using MediaBrowser.Model.Dto;
using MediaBrowser.Model.Serialization;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.LiveTvDemo
{
    public class LiveTvService : ILiveTvService
    {
        private readonly ILogger _logger;

        public LiveTvService(IHttpClient httpClient, IJsonSerializer jsonSerializer, ILogger logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<ChannelInfo>> GetChannelsAsync(CancellationToken cancellationToken)
        {
            var channelInfos = DataGenerator.GetChannelInfos();
            _logger.LogInformation($"GetChannelsAsync: {channelInfos.Count()}");
            return channelInfos;
        }

        public Task CancelTimerAsync(string timerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CancelSeriesTimerAsync(string timerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CreateTimerAsync(TimerInfo info, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CreateSeriesTimerAsync(SeriesTimerInfo info, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTimerAsync(TimerInfo info, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSeriesTimerAsync(SeriesTimerInfo info, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TimerInfo>> GetTimersAsync(CancellationToken cancellationToken)
        {
            var timerInfos = DataGenerator.GetTimerInfos();
            _logger.LogInformation($"GetTimersAsync: {timerInfos.Count()}");
            return timerInfos;
        }

        public async Task<SeriesTimerInfo> GetNewTimerDefaultsAsync(CancellationToken cancellationToken, ProgramInfo program = null)
        {
            //don't throw exception, otherwise details page no longer opens
            //throw new NotImplementedException();
            return new SeriesTimerInfo();
        }

        public Task<IEnumerable<SeriesTimerInfo>> GetSeriesTimersAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProgramInfo>> GetProgramsAsync(string channelId, DateTime startDateUtc, DateTime endDateUtc, CancellationToken cancellationToken)
        {
            var programInfos = DataGenerator.GetProgramInfos(channelId);
            _logger.LogInformation($"GetProgramsAsync: {programInfos.Count()} for Id: {channelId}");
            return programInfos;
        }

        public async Task<MediaSourceInfo> GetChannelStream(string channelId, string streamId, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetChannelStream: {channelId}");
            return DataGenerator.GetMediaSourceInfo(channelId);
        }

        public Task<List<MediaSourceInfo>> GetChannelStreamMediaSources(string channelId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CloseLiveStream(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RecordLiveStream(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ResetTuner(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public string Name { get; }
        public string HomePageUrl { get; }

        public async Task<IEnumerable<RecordingInfo>> GetRecordingsAsync(CancellationToken cancellationToken)
        {
            _logger.LogWarning("this method is obsolete and never called, RecordingsChannel is used instead");
            return new List<RecordingInfo>();
        }

    }
    }

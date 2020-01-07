using System;
using System.Collections.Generic;
using System.Timers;
using MediaBrowser.Controller.Channels;
using MediaBrowser.Controller.LiveTv;
using MediaBrowser.Model.Dto;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.LiveTv;
using MediaBrowser.Model.MediaInfo;

namespace Jellyfin.Plugin.LiveTvDemo
{
    public class DataGenerator
    {
        private const string LoremIpsum =
            "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero";
        private DataGenerator()
        {

        }

        public static IEnumerable<ChannelInfo> GetChannelInfos()
        {
            List<ChannelInfo> channelInfos = new List<ChannelInfo>();
            channelInfos.Add(getChannelInfo("1", "Das Erste HD", ChannelType.TV, "https://github.com/jnk22/kodinerds-iptv/raw/master/logos/tv/daserstehd.png"));
            channelInfos.Add(getChannelInfo("2", "ZDF HD", ChannelType.TV, "https://github.com/jnk22/kodinerds-iptv/raw/master/logos/tv/zdfhd.png"));
            channelInfos.Add(getChannelInfo("3", "B5 aktuell", ChannelType.Radio, "https://github.com/jnk22/kodinerds-iptv/raw/master/logos/radio/b5aktuell.png"));
            return channelInfos;
        }

        private static ChannelInfo getChannelInfo(string id, string name, ChannelType type, string imageUrl)
        {
            ChannelInfo channelInfo = new ChannelInfo();

            channelInfo.Id = id;
            channelInfo.Name = name;
            channelInfo.ChannelType = type;
            channelInfo.Number = id;
            channelInfo.HasImage = true;
            channelInfo.ImagePath = imageUrl;
            //channelInfo.ImageUrl = imageUrl;

            return channelInfo;
        }

        public static MediaSourceInfo GetMediaSourceInfo(string id)
        {
            string path = "https://mcdn.daserste.de/daserste/de/master_3744/00371/master_3744_00458.ts";
            if (id == "2")
            {
                path = "https://zdf-hls-01.akamaized.net/hls/live/2002460-b/de/ec5c90c57223874232064f8344a09cb5/5/1015300.ts";
            } else if (id == "3")
            {
                path = "http://br-b5aktuell-live.cast.addradio.de/br/b5aktuell/live/mp3/128/stream.mp3";
            }

            var mediaSourceInfo = new MediaSourceInfo() {Id = id, Protocol = MediaProtocol.Http, Path = path};


            var mediaStreams = new List<MediaStream>();
            if (int.Parse(id) <= 2)
            {
                mediaStreams.Add(new MediaStream
                {
                    Type = MediaStreamType.Video,
                    // Set the index to -1 because we don't know the exact index of the video stream within the container
                    Index = -1,

                    // Set to true if unknown to enable deinterlacing
                    IsInterlaced = true

                });
            }
            mediaStreams.Add(new MediaStream
            {
                Type = MediaStreamType.Audio,
                // Set the index to -1 because we don't know the exact index of the audio stream within the container
                Index = -1
            });
            mediaSourceInfo.MediaStreams = mediaStreams;
            return mediaSourceInfo;
        }

        public static IEnumerable<ProgramInfo> GetProgramInfos(string channelId)
        {
            List<ProgramInfo> programInfos = new List<ProgramInfo>();

                var startDate = DateTime.Now;
                for (int j = 1; j <= 10; j++)
                {
                    var programInfo = getProgramInfo(j, channelId, startDate);
                    programInfos.Add(programInfo);
                    startDate = programInfo.EndDate;
                }
          
            return programInfos;
        }

        private static int[] _durations = new[] {5, 30, 90};

        private static ProgramInfo getProgramInfo(int id, string channelId, DateTime startDate)
        {
            ProgramInfo programInfo = new ProgramInfo();
            //Id must be unique, otherwise epg is incomplete (but no exception is thrown)
            programInfo.Id = $"{channelId}_{id}";
            programInfo.ChannelId = channelId;
            programInfo.Overview = LoremIpsum;
                
            programInfo.ShortOverview = "Lorem ipsum dolor...";
            int duration = _durations[new Random().Next(0, 3)];
            string title = "Unknown";
            if (duration == 5)
            {
                title = "News";
                programInfo.IsNews = true;
            } else if (duration == 30)
            {
                title = "Series";
                programInfo.IsSeries = true;
            } else if (duration == 90)
            {
                title = "Movie";
                programInfo.IsMovie = true;
            }
            programInfo.Name = $"{title} {id}";
            programInfo.StartDate = startDate;
            programInfo.EndDate = startDate.AddMinutes(duration);
            return programInfo;
        }

        public static IEnumerable<TimerInfo> GetTimerInfos()
        {
            var timerInfos = new List<TimerInfo>();
            for (int i = 1; i <= 3; i++)
            {
                timerInfos.Add(getTimerInfo(i));
            }
            return timerInfos;
        }

        private static TimerInfo getTimerInfo(int id)
        {
            var timerInfo = new TimerInfo();
            timerInfo.Id = Convert.ToString(id);
            timerInfo.ChannelId = Convert.ToString(id);
            timerInfo.Name = $"Timer {id}";
            timerInfo.Overview = LoremIpsum;
            var startDate = DateTime.Now.AddDays(id);
            timerInfo.StartDate = startDate;
            timerInfo.EndDate = startDate.AddMinutes(_durations[id-1]);
            return timerInfo;
        }

        public static IEnumerable<ChannelItemInfo> GetChannelItemInfos()
        {
            var channelItemInfos = new List<ChannelItemInfo>();
            for (int i = 1; i <= 10; i++)
            {
                channelItemInfos.Add(getChannelItemInfo(i));
            } 
            return channelItemInfos;
        }

        private static ChannelItemInfo getChannelItemInfo(int id)
        {
            int duration = _durations[new Random().Next(0, 3)];
            DateTime startDate = DateTime.Now.AddDays(id * -1);
            var channelItemInfo = new ChannelItemInfo()
            {
                Id = Convert.ToString(id),
                Name = $"Recording {id}",
                Overview = LoremIpsum,
                StartDate = startDate,
                EndDate = startDate.AddMinutes(duration)
            };
            
            return channelItemInfo;
        }
    }
}

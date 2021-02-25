using System;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;

namespace YouTubeAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            YouTubeService yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = "YOUR_API_KEY" });

            var searchListRequest = yt.Search.List("snippet");
            searchListRequest.ChannelId = "YOUR_CHANNEL_ID";
            var searchListResult = searchListRequest.Execute();
            foreach (var item in searchListResult.Items)
            {
                Console.WriteLine("ID:" + item.Id.VideoId);
                Console.WriteLine("snippet:" + item.Snippet.Title);
            }
    }
}

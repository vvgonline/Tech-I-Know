using System;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;

namespace YouTubeAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            YouTubeService yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = "AIzaSyCinG0shBtUVFt6IVvCDZYVqiefVwPi0Wc" });

            var searchListRequest = yt.Search.List("snippet");
            searchListRequest.ChannelId = "UCsFTSQ6exutOIpP-wHl8qQQ";
            var searchListResult = searchListRequest.Execute();
            foreach (var item in searchListResult.Items)
            {
                Console.WriteLine("ID:" + item.Id.VideoId);
                Console.WriteLine("snippet:" + item.Snippet.Title);
            }
    }
}

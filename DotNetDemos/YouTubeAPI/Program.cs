using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace YouTubeAPI
{
    class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            getYTVideos();
        }

        public static void getYTVideos(){
            YouTubeService yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = "YOUR_API_KEY" });

            var searchListRequest = yt.Search.List("snippet");
            searchListRequest.ChannelId = "UCsFTSQ6exutOIpP-wHl8qQQ";
            searchListRequest.Type = "video";
            //searchListRequest.MaxResults = 10;
            var searchListResult = searchListRequest.Execute();
            
            foreach (var item in searchListResult.Items)
            {
                Console.WriteLine("Video Id: " + item.Id.VideoId.ToString());
                Console.WriteLine("Video Title: " + item.Snippet.Title.ToString());
                Console.WriteLine("Video Description: " + item.Snippet.Description.ToString());
            }
        }
    }
}
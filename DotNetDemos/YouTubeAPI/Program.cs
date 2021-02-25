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
            YouTubeService yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = "AIzaSyCinG0shBtUVFt6IVvCDZYVqiefVwPi0Wc" });

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

            //google sample code below
            //Console.WriteLine("YouTube Data API: My Uploads");
            //Console.WriteLine("============================");

            //try
            //{
            //    new Program().Run().Wait();
            //}
            //catch (AggregateException ex)
            //{
            //    foreach (var e in ex.InnerExceptions)
            //    {
            //        Console.WriteLine("Error: " + e.Message);
            //    }
            //}

            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();

        }

        private async Task Run()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    // This OAuth 2.0 access scope allows for read-only access to the authenticated 
                    // user's account, but not other types of account access.
                    new[] { YouTubeService.Scope.YoutubeReadonly },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(this.GetType().ToString())
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = this.GetType().ToString()
            });

            var channelsListRequest = youtubeService.Channels.List("contentDetails");
            channelsListRequest.Mine = true;

            // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
            var channelsListResponse = await channelsListRequest.ExecuteAsync();

            foreach (var channel in channelsListResponse.Items)
            {
                // From the API response, extract the playlist ID that identifies the list
                // of videos uploaded to the authenticated user's channel.
                var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;

                Console.WriteLine("Videos in list {0}", uploadsListId);

                var nextPageToken = "";
                while (nextPageToken != null)
                {
                    var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
                    playlistItemsListRequest.PlaylistId = uploadsListId;
                    playlistItemsListRequest.MaxResults = 50;
                    playlistItemsListRequest.PageToken = nextPageToken;

                    // Retrieve the list of videos uploaded to the authenticated user's channel.
                    var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();

                    foreach (var playlistItem in playlistItemsListResponse.Items)
                    {
                        // Print information about each video.
                        Console.WriteLine("{0} ({1})", playlistItem.Snippet.Title, playlistItem.Snippet.ResourceId.VideoId);
                    }

                    nextPageToken = playlistItemsListResponse.NextPageToken;
                }
            }
        }

        //public Task<List<SearchResult>> GetVideosFromChannelAsync(string ytChannelId)
        //{

        //    return Task.Run(() =>
        //    {
        //        List<SearchResult> res = new List<SearchResult>();

        //        var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
        //        {
        //            ApiKey = "AIzaXyBa0HT1K81LpprSpWvxa70thZ6Bx4KD666",
        //            ApplicationName = "Videopedia"//this.GetType().ToString()
        //        });

        //        string nextpagetoken = " ";

        //        while (nextpagetoken != null)
        //        {
        //            var searchListRequest = _youtubeService.Search.List("snippet");
        //            searchListRequest.MaxResults = 50;
        //            searchListRequest.ChannelId = ytChannelId;
        //            searchListRequest.PageToken = nextpagetoken;

        //            // Call the search.list method to retrieve results matching the specified query term.
        //            var searchListResponse = searchListRequest.Execute();

        //            // Process  the video responses 
        //            res.AddRange(searchListResponse.Items);

        //            nextpagetoken = searchListResponse.NextPageToken;

        //        }

        //        return res;

        //    });
        //}
    }
}
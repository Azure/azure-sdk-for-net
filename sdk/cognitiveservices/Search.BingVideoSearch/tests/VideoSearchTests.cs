using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Search.VideoSearch;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace SearchSDK.Tests
{
    public class VideoSearchTests
    {
        private const string Query = "cars";
        private const string VideoResultId = "A9A6BF1A1882870A2BF1A9A6BF1A1882870A2BF1";
        private static string SubscriptionKey = "fake";

        [Fact]
        public void VideoSearch()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "VideoSearch");

                IVideoSearchClient client = new VideoSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.Videos.SearchAsync(query: Query).Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.WebSearchUrl);
                Assert.NotNull(resp.Value);
                Assert.True(resp.Value.Count > 0);

                var video = resp.Value[0];
                Assert.NotNull(video.HostPageUrl);
                Assert.NotNull(video.WebSearchUrl);
            }
        }

        [Fact]
        public void VideoDetail()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "VideoDetail");

                IVideoSearchClient client = new VideoSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.Videos.DetailsAsync(query: Query, id: VideoResultId).Result;

                Assert.NotNull(resp);

                Assert.NotNull(resp.RelatedVideos);
                Assert.NotNull(resp.RelatedVideos.Value);
                Assert.True(resp.RelatedVideos.Value.Count > 0);

                var relatedVideo = resp.RelatedVideos.Value[0];
                Assert.NotNull(relatedVideo.HostPageUrl);
                Assert.NotNull(relatedVideo.WebSearchUrl);

                Assert.NotNull(resp.VideoResult);
                Assert.NotNull(resp.VideoResult.HostPageUrl);
                Assert.NotNull(resp.VideoResult.WebSearchUrl);
                Assert.Equal(VideoResultId, resp.VideoResult.VideoId);
            }
        }

        [Fact]
        public void VideoTrending()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "VideoTrending");

                IVideoSearchClient client = new VideoSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.Videos.TrendingAsync().Result;

                Assert.NotNull(resp);

                Assert.NotNull(resp.BannerTiles);
                Assert.True(resp.BannerTiles.Count > 0);

                var bannerTile = resp.BannerTiles[0];
                Assert.NotNull(bannerTile.Image);
                Assert.NotNull(bannerTile.Query);

                Assert.NotNull(resp.Categories);
                Assert.True(resp.Categories.Count > 0);

                var category = resp.Categories[0];
                Assert.NotNull(category.Title);
                Assert.NotNull(category.Subcategories);
                Assert.True(category.Subcategories.Count > 0);

                var subCategory = category.Subcategories[0];
                Assert.NotNull(subCategory.Title);
                Assert.NotNull(subCategory.Tiles);
                Assert.True(subCategory.Tiles.Count > 0);

                var subCategoryTile = subCategory.Tiles[0];
                Assert.NotNull(subCategoryTile.Image);
                Assert.NotNull(subCategoryTile.Query);
            }
        }
    }
}

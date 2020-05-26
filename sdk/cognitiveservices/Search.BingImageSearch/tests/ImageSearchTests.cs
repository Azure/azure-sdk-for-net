using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Search.ImageSearch;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Collections.Generic;

namespace SearchSDK.Tests
{
    public class ImageSearchTests
    {
        private const string Query = "degas";
        private const string ImageInsightsToken = "bcid_2B63103C3B473829DCC4F03074E157E6*ccid_sGbXtPJL*mid_3B429ACA76F93D5417A3F0D646E96520CE704B3F*simid_608000193735756642";
        private static List<string> Modules = new List<string>{ "all" };
        private static string SubscriptionKey = "fake";

        [Fact]
        public void ImageSearch()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ImageSearch");

                IImageSearchClient client = new ImageSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.Images.SearchAsync(query: Query).Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.WebSearchUrl);
                Assert.NotNull(resp.Value);
                Assert.True(resp.Value.Count > 0);

                var image = resp.Value[0];
                Assert.NotNull(image.WebSearchUrl);
                Assert.NotNull(image.ThumbnailUrl);

                Assert.NotNull(resp.QueryExpansions);
                Assert.True(resp.QueryExpansions.Count > 0);

                var query = resp.QueryExpansions[0];
                Assert.NotNull(query.Text);
                Assert.NotNull(query.SearchLink);
            }
        }

        [Fact]
        public void ImageDetail()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ImageDetail");

                IImageSearchClient client = new ImageSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.Images.DetailsAsync(query: Query, insightsToken: ImageInsightsToken, modules: Modules).Result;

                Assert.NotNull(resp);

                Assert.NotNull(resp.BestRepresentativeQuery);
                Assert.NotNull(resp.ImageCaption);

                Assert.NotNull(resp.PagesIncluding);
                Assert.True(resp.PagesIncluding.Value.Count > 0);
                var pageIncluding = resp.PagesIncluding.Value[0];
                Assert.NotNull(pageIncluding.HostPageUrl);
                Assert.NotNull(pageIncluding.WebSearchUrl);

                Assert.NotNull(resp.RelatedSearches);
                Assert.True(resp.RelatedSearches.Value.Count > 0);
                var relatedSearch = resp.RelatedSearches.Value[0];
                Assert.NotNull(relatedSearch.Text);
                Assert.NotNull(relatedSearch.WebSearchUrl);

                Assert.NotNull(resp.VisuallySimilarImages);
                Assert.True(resp.VisuallySimilarImages.Value.Count > 0);
                var visuallySimilarImage = resp.VisuallySimilarImages.Value[0];
                Assert.NotNull(visuallySimilarImage.WebSearchUrl);
                Assert.NotNull(visuallySimilarImage.ImageInsightsToken);
            }
        }

        [Fact]
        public void ImageTrending()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ImageTrending");

                IImageSearchClient client = new ImageSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.Images.TrendingAsync().Result;

                Assert.NotNull(resp);
                
                Assert.NotNull(resp.Categories);
                Assert.True(resp.Categories.Count > 0);

                var category = resp.Categories[0];
                Assert.NotNull(category.Title);
                Assert.NotNull(category.Tiles);
                Assert.True(category.Tiles.Count > 0);
                
                var categoryTile = category.Tiles[0];
                Assert.NotNull(categoryTile.Image);
                Assert.NotNull(categoryTile.Query);
            }
        }
    }
}

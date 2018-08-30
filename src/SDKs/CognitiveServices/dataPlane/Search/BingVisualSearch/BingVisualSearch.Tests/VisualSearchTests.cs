using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Search.VisualSearch;
using Microsoft.Azure.CognitiveServices.Search.VisualSearch.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Xunit;
using System.IO;

namespace SearchSDK.Tests
{
    public class VisualSearchTests
    {
        private const string ImageInsightsToken = "bcid_2B63103C3B473829DCC4F03074E157E6*ccid_sGbXtPJL*mid_3B429ACA76F93D5417A3F0D646E96520CE704B3F*simid_608000193735756642";
        private const string ImageUrl = "http://3.bp.blogspot.com/-dbDvMyLyZUU/T2fvDTnPFzI/AAAAAAAAAxs/i53ZHxUtZRo/s400/915534489_de793b90b5_b.jpg";
        private static string SubscriptionKey = "fake";
        CropArea CropArea = new CropArea(top: (float)0.1, bottom: (float)0.5, left: (float)0.1, right: (float)0.9);

        [Fact]
        public void VisualSearchWithBinary()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "VisualSearchWithBinary");

                IVisualSearchAPI client = new VisualSearchAPI(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "image.jpg"), FileMode.Open))
                {
                    VisualSearchRequest VisualSearchRequest = new VisualSearchRequest();

                    var resp = client.Images.VisualSearchMethodAsync(image: stream, knowledgeRequest: JsonConvert.SerializeObject(VisualSearchRequest)).Result;

                    Assert.NotNull(resp);
                    Assert.NotNull(resp.Tags);
                    Assert.True(resp.Tags.Count > 0);

                    var tag = resp.Tags[0];
                    Assert.NotNull(tag.Actions);
                    Assert.True(tag.Actions.Count > 0);

                    var action = tag.Actions[0];
                    Assert.NotNull(action.ActionType);
                }
            }
        }

        [Fact]
        public void VisualSearchWithInsightsToken()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "VisualSearchWithInsightsToken");

                IVisualSearchAPI client = new VisualSearchAPI(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                ImageInfo ImageInfo = new ImageInfo(imageInsightsToken: ImageInsightsToken, cropArea: CropArea);
                Filters Filters = new Filters(site: "www.bing.com");
                KnowledgeRequest KnowledgeRequest = new KnowledgeRequest(filters: Filters);
                VisualSearchRequest VisualSearchRequest = new VisualSearchRequest(imageInfo: ImageInfo, knowledgeRequest: KnowledgeRequest);

                var resp = client.Images.VisualSearchMethodAsync(knowledgeRequest: JsonConvert.SerializeObject(VisualSearchRequest)).Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.Tags);
                Assert.True(resp.Tags.Count > 0);

                var tag = resp.Tags[0];
                Assert.NotNull(tag.Actions);
                Assert.True(tag.Actions.Count > 0);

                var action = tag.Actions[0];
                Assert.NotNull(action.ActionType);
            }
        }

        [Fact]
        public void VisualSearchWithUrl()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "VisualSearchWithUrl");

                IVisualSearchAPI client = new VisualSearchAPI(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                ImageInfo ImageInfo = new ImageInfo(url: ImageUrl, cropArea: CropArea);
                VisualSearchRequest VisualSearchRequest = new VisualSearchRequest(imageInfo: ImageInfo);

                var resp = client.Images.VisualSearchMethodAsync(knowledgeRequest: JsonConvert.SerializeObject(VisualSearchRequest)).Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.Tags);
                Assert.True(resp.Tags.Count > 0);

                var tag = resp.Tags[0];
                Assert.NotNull(tag.Actions);
                Assert.True(tag.Actions.Count > 0);

                var action = tag.Actions[0];
                Assert.NotNull(action.ActionType);
            }
        }

        [Fact]
        public void VisualSearchWithKnowledgeRequestObject()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "VisualSearchWithKnowledgeRequestObject");

                IVisualSearchAPI client = new VisualSearchAPI(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                ImageInfo ImageInfo = new ImageInfo(url: ImageUrl, cropArea: CropArea);
                VisualSearchRequest VisualSearchRequest = new VisualSearchRequest(imageInfo: ImageInfo);

                var resp = client.Images.VisualSearchMethodAsync(knowledgeRequest: VisualSearchRequest).Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.Tags);
                Assert.True(resp.Tags.Count > 0);

                var tag = resp.Tags[0];
                Assert.NotNull(tag.Actions);
                Assert.True(tag.Actions.Count > 0);

                var action = tag.Actions[0];
                Assert.NotNull(action.ActionType);
            }
        }
    }
}

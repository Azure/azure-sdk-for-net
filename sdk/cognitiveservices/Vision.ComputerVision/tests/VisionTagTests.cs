using System.IO;
using System.Linq;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionTagTests : BaseTests
    {
        [Fact]
        public void TagImageInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "TagImageInStreamTest");

                const string Chinese = "zh";

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("house.jpg"), FileMode.Open))
                {
                    TagResult result = client.TagImageInStreamAsync(stream, Chinese).Result;

                    var expects = new string[] { "草", "户外", "天空", "屋子", "建筑", "绿色", "草坪", "住宅", "绿色的", "家", "房子" };
                    var intersect = expects.Intersect(result.Tags.Select(tag => tag.Name).ToArray()).ToArray();

                    Assert.True(intersect.Length == expects.Length);
                }
            }
        }

        [Fact]
        public void TagImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "TagImageTest");

                string imageUrl = GetTestImageUrl("house.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    TagResult result = client.TagImageAsync(imageUrl).Result;

                    var expects = new string[] { "grass", "outdoor", "sky", "house", "building", "green", "lawn", "residential", "grassy", "home" };
                    var intersect = expects.Intersect(result.Tags.Select(tag => tag.Name).ToArray()).ToArray();

                    Assert.True(intersect.Length == expects.Length);

                    // Confirm tags are in descending confidence order
                    var orignalConfidences = result.Tags.Select(tag => tag.Confidence).ToArray();
                    var sortedConfidences = orignalConfidences.OrderByDescending(c => c).ToArray();
                    Assert.Equal(sortedConfidences, orignalConfidences);
                }
            }
        }
    }
}

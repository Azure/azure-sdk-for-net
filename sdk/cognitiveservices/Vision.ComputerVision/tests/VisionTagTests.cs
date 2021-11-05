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

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("house.jpg"), FileMode.Open))
                {
                    const string Chinese = "zh";

                    TagResult result = client.TagImageInStreamAsync(stream, Chinese).Result;

                    Assert.Matches("^\\d{4}-\\d{2}-\\d{2}(-preview)?$", result.ModelVersion);

                    var expects = new string[] { "草", "户外", "建筑", "植物", "财产", "家", "屋子", "不动产", "天空",
                        "护墙板", "门廊", "院子", "小别墅", "花园建筑", "门", "草坪", "窗户/车窗", "农舍", "树", "后院",
                        "车道", "小屋", "屋顶", "地段" };

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

                    Assert.Matches("^\\d{4}-\\d{2}-\\d{2}(-preview)?$", result.ModelVersion);

                    var expects = new string[] { "grass", "outdoor", "building", "plant", "property", "home",
                        "house", "real estate", "sky", "siding", "porch", "yard", "cottage", "garden buildings",
                        "door", "lawn", "window", "farmhouse", "tree", "backyard", "driveway", "shed", "roof", "land lot" };

                    var intersect = expects.Intersect(result.Tags.Select(tag => tag.Name).ToArray()).ToArray();

                    Assert.True(intersect.Length == expects.Length);

                    // Confirm tags are in descending confidence order
                    var orignalConfidences = result.Tags.Select(tag => tag.Confidence).ToArray();
                    var sortedConfidences = orignalConfidences.OrderByDescending(c => c).ToArray();
                    Assert.Equal(sortedConfidences, orignalConfidences);
                }
            }
        }

        [Fact]
        public void TagImageModelVersionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "TagImageModelVersionTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("house.jpg"), FileMode.Open))
                {
                    const string Chinese = "zh";
                    const string targetModelVersion = "2021-04-01";

                    TagResult result = client.TagImageInStreamAsync(
                        stream,
                        Chinese,
                        modelVersion: targetModelVersion).Result;

                    Assert.Equal(targetModelVersion, result.ModelVersion);
                }
            }
        }
    }
}

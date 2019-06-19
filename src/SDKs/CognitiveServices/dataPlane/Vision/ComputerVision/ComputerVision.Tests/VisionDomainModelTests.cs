using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionDomainModelTests : BaseTests
    {
        [Fact]
        public void AnalyzeCelebritiesDomainImageInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "AnalyzeCelebritiesDomainImageInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("satya.jpg"), FileMode.Open))
                {
                    DomainModelResults results = client.AnalyzeImageByDomainInStreamAsync("celebrities", stream).Result;

                    var jobject = results.Result as JObject;
                    Assert.NotNull(jobject);

                    var celebrities = jobject.ToObject<CelebrityResults>();
                    Assert.NotNull(celebrities);
                    Assert.Equal(1, celebrities.Celebrities.Count);

                    var celebrity = celebrities.Celebrities[0];
                    Assert.Equal("Satya Nadella", celebrity.Name);
                    Assert.True(celebrity.Confidence > 0.98);
                    Assert.True(celebrity.FaceRectangle.Width > 0);
                    Assert.True(celebrity.FaceRectangle.Height > 0);
                }
            }
        }

        [Fact]
        public void AnalyzeCelebritiesDomainImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "AnalyzeCelebritiesDomainTest");

                string celebrityUrl = GetTestImageUrl("satya.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    DomainModelResults results = client.AnalyzeImageByDomainAsync("celebrities", celebrityUrl).Result;

                    var jobject = results.Result as JObject;
                    Assert.NotNull(jobject);

                    var celebrities = jobject.ToObject<CelebrityResults>();
                    Assert.NotNull(celebrities);
                    Assert.Equal(1, celebrities.Celebrities.Count);

                    var celebrity = celebrities.Celebrities[0];
                    Assert.Equal("Satya Nadella", celebrity.Name);
                    Assert.True(celebrity.Confidence > 0.98);
                    Assert.True(celebrity.FaceRectangle.Width > 0);
                    Assert.True(celebrity.FaceRectangle.Height > 0);
                }
            }
        }

        [Fact]
        public void AnalyzeLandmarksDomainImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "AnalyzeLandmarksDomainImageTest");

                string landmarksUrl = GetTestImageUrl("spaceneedle.jpg");
                const string Portuguese = "pt";

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    DomainModelResults results = client.AnalyzeImageByDomainAsync("landmarks", landmarksUrl, Portuguese).Result;

                    var jobject = results.Result as JObject;
                    Assert.NotNull(jobject);

                    var landmarks = jobject.ToObject<LandmarkResults>();
                    Assert.NotNull(landmarks);
                    Assert.Equal(1, landmarks.Landmarks.Count);

                    var landmark = landmarks.Landmarks[0];
                    Assert.Equal("Obelisco Espacial", landmark.Name);
                    Assert.True(landmark.Confidence > 0.99);
                }
            }
        }
    }
}

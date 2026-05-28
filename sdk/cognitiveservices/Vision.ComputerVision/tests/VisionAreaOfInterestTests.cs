using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionAreaOfInterestTests : BaseTests
    {
        [Fact]
        public void AreaOfInterestImageInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AreaOfInterestImageInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("house.jpg"), FileMode.Open))
                {
                    AreaOfInterestResult result = client.GetAreaOfInterestInStreamAsync(stream).Result;

                    Assert.Matches("^\\d{4}-\\d{2}-\\d{2}(-preview)?$", result.ModelVersion);
                    Assert.Equal(112, result.AreaOfInterest.X);
                    Assert.Equal(0, result.AreaOfInterest.Y);
                    Assert.Equal(462, result.AreaOfInterest.W);
                    Assert.Equal(462, result.AreaOfInterest.H);
                }
            }
        }

        [Fact]
        public void AreaOfInterestImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AreaOfInterestImageTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    AreaOfInterestResult result = client.GetAreaOfInterestAsync(GetTestImageUrl("house.jpg")).Result;

                    Assert.Matches("^\\d{4}-\\d{2}-\\d{2}(-preview)?$", result.ModelVersion);
                    Assert.Equal(112, result.AreaOfInterest.X);
                    Assert.Equal(0, result.AreaOfInterest.Y);
                    Assert.Equal(462, result.AreaOfInterest.W);
                    Assert.Equal(462, result.AreaOfInterest.H);
                }
            }
        }

        [Fact]
        public void AreaOfInterestLogoTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AreaOfInterestLogoTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("achtung.jpg"), FileMode.Open))
                {
                    AreaOfInterestResult result = client.GetAreaOfInterestInStreamAsync(stream).Result;

                    Assert.Matches("^\\d{4}-\\d{2}-\\d{2}(-preview)?$", result.ModelVersion);
                    Assert.Equal(0, result.AreaOfInterest.X);
                    Assert.Equal(0, result.AreaOfInterest.Y);
                    Assert.Equal(result.Metadata.Width, result.AreaOfInterest.W);
                    Assert.Equal(result.Metadata.Height, result.AreaOfInterest.H);
                }
            }
        }

        [Fact]
        public void AreaOfInterestModelVersionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AreaOfInterestModelVersionTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("house.jpg"), FileMode.Open))
                {
                    const string targetModelVersion = "2021-04-01";

                    AreaOfInterestResult result = client.GetAreaOfInterestInStreamAsync(
                        stream,
                        modelVersion: targetModelVersion).Result;

                    Assert.Equal(targetModelVersion, result.ModelVersion);
                }
            }
        }
    }
}

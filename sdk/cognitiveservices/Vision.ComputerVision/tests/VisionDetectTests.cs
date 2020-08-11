using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionDetectTests : BaseTests
    {
        [Fact]
        public void DetectImageInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DetectImageInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("people.jpg"), FileMode.Open))
                {
                    DetectResult result = client.DetectObjectsInStreamAsync(stream).Result;

                    Assert.NotNull(result.Objects);
                    Assert.Equal(5, result.Objects.Count);
                    Assert.Equal("person", result.Objects[0].ObjectProperty);
                    Assert.Equal("person", result.Objects[1].ObjectProperty);
                    Assert.Equal("person", result.Objects[2].ObjectProperty);
                    Assert.Equal("person", result.Objects[3].ObjectProperty);

                    var firstObject = result.Objects[0];
                    Assert.Equal(0, firstObject.Rectangle.X);
                    Assert.Equal(46, firstObject.Rectangle.Y);
                    Assert.Equal(698, firstObject.Rectangle.H);
                    Assert.Equal(229, firstObject.Rectangle.W);
                    Assert.Equal(0.554, result.Objects[0].Confidence);

                    var secondObject = result.Objects[1];
                    Assert.Equal(5, secondObject.Rectangle.X);
                    Assert.Equal(71, secondObject.Rectangle.Y);
                    Assert.Equal(671, secondObject.Rectangle.H);
                    Assert.Equal(532, secondObject.Rectangle.W);
                    Assert.Equal(0.953, secondObject.Confidence);
                }
            }
        }

        [Fact]
        public void DetectImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DetectImageTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    DetectResult result = client.DetectObjectsAsync(GetTestImageUrl("satya.jpg")).Result;

                    Assert.NotNull(result.Objects);
                    Assert.Equal(1, result.Objects.Count);

                    var firstObject = result.Objects[0];
                    Assert.Equal("person", firstObject.ObjectProperty);
                    Assert.Equal(151, firstObject.Rectangle.X);
                    Assert.Equal(24, firstObject.Rectangle.Y);
                    Assert.Equal(260, firstObject.Rectangle.H);
                    Assert.Equal(228, firstObject.Rectangle.W);
                    Assert.Equal(0.956, result.Objects[0].Confidence);
                }
            }
        }
    }
}

using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionOcrTests : BaseTests
    {
        [Fact]
        public void OcrImageInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "OcrImageInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("signage.jpg"), FileMode.Open))
                {
                    const bool DetectOrientation = true;
                    OcrResult result = client.RecognizePrintedTextInStreamAsync(DetectOrientation, stream).Result;

                    Assert.Equal("en", result.Language);
                    Assert.Equal("Up", result.Orientation);
                    Assert.True(result.TextAngle < 0);
                    Assert.Equal(1, result.Regions.Count);
                    Assert.Equal(3, result.Regions[0].Lines.Count);
                    Assert.Equal(1, result.Regions[0].Lines[0].Words.Count);
                    Assert.Equal("WEST", result.Regions[0].Lines[0].Words[0].Text);
                    Assert.Equal("520", result.Regions[0].Lines[1].Words[0].Text);
                    Assert.Equal("Seattle", result.Regions[0].Lines[2].Words[0].Text);
                }
            }
        }

        [Fact]
        public void OcrImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "OcrImageTest");

                string germanTextUrl = GetTestImageUrl("achtung.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    const bool DetectOrientation = true;
                    OcrResult result = client.RecognizePrintedTextAsync(DetectOrientation, germanTextUrl, OcrLanguages.De).Result;

                    Assert.Equal("de", result.Language);
                    Assert.Equal("Up", result.Orientation);
                    Assert.True(result.TextAngle > 0);
                    Assert.Equal(1, result.Regions.Count);
                    Assert.Equal(1, result.Regions[0].Lines.Count);
                    Assert.Equal(1, result.Regions[0].Lines[0].Words.Count);
                    Assert.Equal("ACHTUNG", result.Regions[0].Lines[0].Words[0].Text);
                    Assert.True(result.Regions[0].BoundingBox == result.Regions[0].Lines[0].BoundingBox);
                }
            }
        }
    }
}

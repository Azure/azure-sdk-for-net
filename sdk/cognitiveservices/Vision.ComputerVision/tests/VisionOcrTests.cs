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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "OcrImageInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("signage.jpg"), FileMode.Open))
                {
                    const bool DetectOrientation = true;
                    OcrResult result = client.RecognizePrintedTextInStreamAsync(DetectOrientation, stream).Result;

                    Assert.Matches("^\\d{4}-\\d{2}-\\d{2}(-preview)?$", result.ModelVersion);
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "OcrImageTest");

                string germanTextUrl = GetTestImageUrl("achtung.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    const bool DetectOrientation = true;
                    OcrResult result = client.RecognizePrintedTextAsync(DetectOrientation, germanTextUrl, OcrLanguages.De).Result;

                    Assert.Matches("^\\d{4}-\\d{2}-\\d{2}(-preview)?$", result.ModelVersion);
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

        [Fact]
        public void OcrImageModelVersionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "OcrImageModelVersionTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("signage.jpg"), FileMode.Open))
                {
                    const bool DetectOrientation = true;
                    const string targetModelVersion = "2021-04-01";

                    OcrResult result = client.RecognizePrintedTextInStreamAsync(
                        DetectOrientation,
                        stream,
                        modelVersion: targetModelVersion).Result;

                    Assert.Equal(targetModelVersion, result.ModelVersion);
                }
            }
        }
    }
}

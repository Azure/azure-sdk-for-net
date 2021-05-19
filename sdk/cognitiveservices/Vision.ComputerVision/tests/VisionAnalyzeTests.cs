using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionAnalyzeTests : BaseTests
    {
        [Fact]
        public void AnalyzeImageInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AnalyzeImageInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("house.jpg"), FileMode.Open))
                {
                    ImageAnalysis result = client.AnalyzeImageInStreamAsync(
                        stream,
                        new List<VisualFeatureTypes?>()
                        {
                            VisualFeatureTypes.Adult,
                            VisualFeatureTypes.Categories,
                            VisualFeatureTypes.Color,
                            VisualFeatureTypes.Faces,
                            VisualFeatureTypes.ImageType,
                            VisualFeatureTypes.Tags
                        })
                        .Result;

                    Assert.Equal("grass", result.Tags[0].Name);
                    Assert.True(result.Tags[0].Confidence > 0.9);
                    Assert.Equal("Jpeg", result.Metadata.Format);
                    Assert.False(result.Adult.IsAdultContent);
                    Assert.False(result.Adult.IsRacyContent);
                    Assert.False(result.Adult.IsGoryContent);
                    Assert.True(result.Adult.AdultScore < 0.1);
                    Assert.True(result.Adult.RacyScore < 0.1);
                    Assert.True(result.Adult.GoreScore < 0.1);
                    Assert.Equal("building_", result.Categories[0].Name);
                    Assert.True(result.Categories[0].Score > 0.5);
                    Assert.Equal("Green", result.Color.DominantColorBackground);
                    Assert.Equal("Green", result.Color.DominantColorForeground);
                }
            }
        }

        [Fact]
        public void AnalyzeImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AnalyzeImageTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    ImageAnalysis result = client.AnalyzeImageAsync(
                        GetTestImageUrl("house.jpg"),
                        new List<VisualFeatureTypes?>()
                        {
                            VisualFeatureTypes.Adult,
                            VisualFeatureTypes.Categories,
                            VisualFeatureTypes.Color,
                            VisualFeatureTypes.Faces,
                            VisualFeatureTypes.ImageType,
                            VisualFeatureTypes.Tags
                        })
                        .Result;

                    Assert.Equal("grass", result.Tags[0].Name);
                    Assert.True(result.Tags[0].Confidence > 0.9);
                    Assert.Equal("Jpeg", result.Metadata.Format);
                    Assert.False(result.Adult.IsAdultContent);
                    Assert.False(result.Adult.IsRacyContent);
                    Assert.False(result.Adult.IsGoryContent);
                    Assert.True(result.Adult.AdultScore < 0.1);
                    Assert.True(result.Adult.RacyScore < 0.1);
                    Assert.True(result.Adult.GoreScore < 0.1);
                    Assert.Equal("building_", result.Categories[0].Name);
                    Assert.True(result.Categories[0].Score > 0.5);
                    Assert.Equal("Green", result.Color.DominantColorBackground);
                    Assert.Equal("Green", result.Color.DominantColorForeground);
                }
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6214")]
        public void AnalyzeBrandsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AnalyzeBrandsTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("MicrosoftRealMadrid.jpg"), FileMode.Open))
                {
                    ImageAnalysis result = client.AnalyzeImageInStreamAsync(
                        stream,
                        new List<VisualFeatureTypes?>()
                        {
                            VisualFeatureTypes.Brands
                        })
                        .Result;

                    Assert.Equal("Microsoft", result.Brands[0].Name);
                    Assert.True(result.Brands[0].Confidence > 0.5);
                    Assert.True(result.Brands[0].Rectangle.X >= 0);
                    Assert.True(result.Brands[0].Rectangle.W >= 0);
                    Assert.True(result.Brands[0].Rectangle.X + result.Brands[0].Rectangle.W <= result.Metadata.Width);
                    Assert.True(result.Brands[0].Rectangle.Y >= 0);
                    Assert.True(result.Brands[0].Rectangle.H >= 0);
                    Assert.True(result.Brands[0].Rectangle.Y + result.Brands[0].Rectangle.H <= result.Metadata.Height);
                }
            }
        }

        [Fact]
        public void AnalyzeImageNullImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AnalyzeImageNullImageTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    Assert.ThrowsAsync<ValidationException>(() => client.AnalyzeImageAsync(null));
                }
            }
        }
    }
}

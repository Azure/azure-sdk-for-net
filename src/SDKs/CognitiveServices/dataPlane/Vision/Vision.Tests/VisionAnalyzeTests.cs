using FaceSDK.Tests;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace VisionSDK.Tests
{
    public class VisionAnalyzeTests : BaseTests
    {
        [Fact]
        public void AnalyzeImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "AnalyzeImageTest");

                IComputerVisionAPI client = GetComputerVisionClient(HttpMockServer.CreateInstance());
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "house.jpg"), FileMode.Open))
                {
                    ImageAnalysis result = client.AnalyzeImageInStreamAsync(
                        stream,
                        new List<VisualFeatureTypes>()
                    {
                        VisualFeatureTypes.Adult,
                        VisualFeatureTypes.Categories,
                        VisualFeatureTypes.Color,
                        VisualFeatureTypes.Faces,
                        VisualFeatureTypes.ImageType,
                        VisualFeatureTypes.Tags
                    }).Result;

                    Assert.Equal("grass", result.Tags[0].Name);
                    Assert.True(result.Tags[0].Confidence > 0.9);
                    Assert.Equal("Jpeg", result.Metadata.Format);
                    Assert.False(result.Adult.IsAdultContent);
                    Assert.False(result.Adult.IsRacyContent);
                    Assert.True(result.Adult.AdultScore < 0.1);
                    Assert.True(result.Adult.RacyScore < 0.1);
                    Assert.Equal("building_", result.Categories[0].Name);
                    Assert.True(result.Categories[0].Score > 0.5);
                    Assert.Equal("Green", result.Color.DominantColorBackground);
                    Assert.Equal("Green", result.Color.DominantColorForeground);
                }
            }
        }
    }
}

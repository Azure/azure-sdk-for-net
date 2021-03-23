using System.Globalization;
using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionDescribeTests : BaseTests
    {
        [Fact]
        public void DescribeImageInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DescribeImageInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("house.jpg"), FileMode.Open))
                {
                    ImageDescription result = client.DescribeImageInStreamAsync(stream).Result;

                    Assert.Equal(result.Tags, new string[] {
                        "grass",
                        "outdoor",
                        "sky",
                        "house",
                        "building",
                        "green",
                        "lawn",
                        "residential",
                        "grassy"
                    });

                    Assert.Equal(1, result.Captions.Count);
                    Assert.Equal("a house with a flag", result.Captions[0].Text);
                    Assert.True(result.Captions[0].Confidence > 0.41);
                }
            }
        }

        [Fact]
        public void DescribeImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DescribeImageTest");

                string imageUrl = GetTestImageUrl("dog.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    const int maxCandidates = 2;

                    ImageDescription result = client.DescribeImageAsync(imageUrl, maxCandidates).Result;

                    Assert.Equal(result.Tags, new string[] {
                        "dog",
                        "tree",
                        "outdoor",
                        "sitting",
                        "ground",
                        "animal",
                        "mammal",
                        "close"
                    });
                    Assert.Equal(1, result.Captions.Count);
                    Assert.Equal("a dog with its mouth open", result.Captions[0].Text);
                    Assert.True(result.Captions[0].Confidence > 0.5);
                }
            }
        }

        [Fact]
        public void DescribeImageInJapaneseTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DescribeImageInJapaneseTest");

                string imageUrl = GetTestImageUrl("dog.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    const int maxCandidates = 1;

                    ImageDescription result = client.DescribeImageAsync(imageUrl, maxCandidates, "ja").Result;

                    Assert.Equal(result.Tags, new string[] {
                        "犬",
                        "屋外",
                        "座る",
                        "動物",
                        "哺乳類",
                        "探す",
                        "茶色",
                        "ベンチ",
                        "フロント",
                        "木製",
                        "大きい",
                        "小さい",
                        "立つ",
                        "閉じる",
                        "テーブル",
                        "オレンジ",
                        "横たわる",
                        "公園",
                        "頭"
                    });
                    Assert.Equal(1, result.Captions.Count);
                    Assert.Equal("犬の顔", result.Captions[0].Text);
                    Assert.True(result.Captions[0].Confidence > 0.79);
                }
            }
        }
    }
}

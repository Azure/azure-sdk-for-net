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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DescribeImageInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("house.jpg"), FileMode.Open))
                {
                    ImageDescription result = client.DescribeImageInStreamAsync(stream).Result;

                    Assert.Equal(result.Tags, new string[] {
                        "grass",
                        "outdoor",
                        "house",
                        "building",
                        "green",
                        "yard",
                        "lawn",
                        "front",
                        "small",
                        "field",
                        "home",
                        "red",
                        "sitting",
                        "grassy",
                        "brick",
                        "white",
                        "large",
                        "old",
                        "standing",
                        "grazing",
                        "sheep",
                        "parked",
                        "garden",
                        "woman",
                        "man",
                        "sign"
                    });
                    Assert.Equal(1, result.Captions.Count);
                    Assert.Equal("a large lawn in front of a house", result.Captions[0].Text);
                    Assert.True(result.Captions[0].Confidence > 0.96);
                }
            }
        }

        [Fact]
        public void DescribeImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DescribeImageTest");

                string imageUrl = GetTestImageUrl("dog.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    const int maxCandidates = 2;

                    ImageDescription result = client.DescribeImageAsync(imageUrl, maxCandidates).Result;

                    Assert.Equal(result.Tags, new string[] {
                        "dog",
                        "outdoor",
                        "sitting",
                        "animal",
                        "mammal",
                        "looking",
                        "brown",
                        "bench",
                        "yellow",
                        "front",
                        "large",
                        "wooden",
                        "small",
                        "white",
                        "standing",
                        "close",
                        "table",
                        "orange",
                        "laying",
                        "park",
                        "head"
                    });
                    Assert.Equal(2, result.Captions.Count);
                    Assert.Equal("a close up of a dog", result.Captions[0].Text);
                    Assert.Equal("close up of a dog", result.Captions[1].Text);
                    Assert.True(result.Captions[0].Confidence > result.Captions[1].Confidence);
                }
            }
        }

        [Fact]
        public void DescribeImageInJapaneseTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DescribeImageInJapaneseTest");

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
                        "イエロー",
                        "フロント",
                        "大きい",
                        "木製",
                        "小さい",
                        "ホワイト",
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
                    Assert.True(result.Captions[0].Confidence > 0.8);
                }
            }
        }
    }
}

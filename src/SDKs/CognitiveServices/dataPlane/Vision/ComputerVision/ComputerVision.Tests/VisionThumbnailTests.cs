using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionThumbmailTests : BaseTests
    {
        const int EOF = -1;

        [Fact]
        public void ThumbnailImageInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "ThumbnailImageInStreamTest");

                IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance());
                using (FileStream stream = new FileStream(GetTestImagePath("house.jpg"), FileMode.Open))
                using (Stream result = client.GenerateThumbnailInStreamAsync(64, 64, stream).Result)
                {
                    // Note - .NET Core 2.0 doesn't support System.Drawing.Bitmap

                    byte[] expected = File.ReadAllBytes(GetTestImagePath("house_thumbnail.jpg"));
                    byte[] actual = new byte[expected.Length];
                    result.Read(actual, 0, expected.Length);

                    // Reinstate for playback when HttpRecorder is fixed
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        Assert.Equal(EOF, result.ReadByte());
                        Assert.Equal(expected, actual);
                    }
                }
            }
        }

        [Fact]
        public void ThumbnailImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "ThumbnailImageTest");

                string ImageUrl = GetTestImageUrl("house.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (Stream result = client.GenerateThumbnailAsync(64, 64, ImageUrl).Result)
                {
                    byte[] expected = File.ReadAllBytes(GetTestImagePath("house_thumbnail.jpg"));
                    byte[] actual = new byte[expected.Length];
                    result.Read(actual, 0, expected.Length);

                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        Assert.Equal(EOF, result.ReadByte());
                        Assert.Equal(expected, actual);
                    }
                }
            }
        }

        [Fact]
        public void ThumbnailInvalidSizeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "ThumbnailInvalidSizeTest");

                string imageUrl = GetTestImageUrl("house.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    Assert.ThrowsAsync<ValidationException>(() => client.GenerateThumbnailAsync(5000, 64, imageUrl));
                    Assert.ThrowsAsync<ValidationException>(() => client.GenerateThumbnailAsync(64, 5000, imageUrl));
                    Assert.ThrowsAsync<ValidationException>(() => client.GenerateThumbnailAsync(0, 64, imageUrl));
                    Assert.ThrowsAsync<ValidationException>(() => client.GenerateThumbnailAsync(64, 0, imageUrl));
                }
            }
        }
    }
}

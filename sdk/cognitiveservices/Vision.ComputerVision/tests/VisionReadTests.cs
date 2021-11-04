using System;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionReadTests : BaseTests
    {
        static private ReadOperationResult GetRecognitionResultWithPolling(IComputerVisionClient client, string operationLocation)
        {
            string operationId = operationLocation.Substring(operationLocation.LastIndexOf('/') + 1);

            for (int remainingTries = 10; remainingTries > 0; remainingTries--)
            {
                ReadOperationResult result = client.GetReadResultAsync(new Guid(operationId)).Result;

                Assert.True(result.Status != OperationStatusCodes.Failed);

                if (result.Status == OperationStatusCodes.Succeeded)
                {
                    return result;
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            return null;
        }

        [Fact]
        public void ReadLatestNaturalTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ReadLatestNaturalTest");

                string imageUrl = GetTestImageUrl("signage.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    ReadHeaders headers = client.ReadAsync(imageUrl, modelVersion:"latest", readingOrder:"natural").Result;

                    Assert.NotNull(headers.OperationLocation);

                    ReadOperationResult readOperationResult = GetRecognitionResultWithPolling(client, headers.OperationLocation);

                    Assert.NotNull(readOperationResult);
                    Assert.Equal(OperationStatusCodes.Succeeded, readOperationResult.Status);

                    Assert.NotNull(readOperationResult.AnalyzeResult);
                    Assert.Equal(1, readOperationResult.AnalyzeResult.ReadResults.Count);

                    var recognitionResult = readOperationResult.AnalyzeResult.ReadResults[0];

                    Assert.Equal(1, recognitionResult.Page);
                    Assert.Equal(250, recognitionResult.Width);
                    Assert.Equal(258, recognitionResult.Height);
                    Assert.Equal(TextRecognitionResultDimensionUnit.Pixel, recognitionResult.Unit);

                    Assert.Equal(
                        new string[] { "520", "WEST", "Seattle" }.OrderBy(t => t),
                        recognitionResult.Lines.Select(line => line.Text).OrderBy(t => t));
                    Assert.Equal(
                        new string[] { "520", "WEST", "Seattle" }.OrderBy(t => t),
                        recognitionResult.Lines.SelectMany(line => line.Words).Select(word => word.Text).OrderBy(t => t));
                    Assert.Equal(3, recognitionResult.Lines.Count);
                }
            }
        }

        [Fact]
        public void ReadAprilModelBasicTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ReadAprilModelBasicTest");

                string imageUrl = GetTestImageUrl("signage.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    ReadHeaders headers = client.ReadAsync(imageUrl, modelVersion: "2021-04-12", readingOrder: "basic").Result;

                    Assert.NotNull(headers.OperationLocation);

                    ReadOperationResult readOperationResult = GetRecognitionResultWithPolling(client, headers.OperationLocation);

                    Assert.NotNull(readOperationResult);
                    Assert.Equal(OperationStatusCodes.Succeeded, readOperationResult.Status);

                    Assert.NotNull(readOperationResult.AnalyzeResult);
                    Assert.Equal(1, readOperationResult.AnalyzeResult.ReadResults.Count);

                    var recognitionResult = readOperationResult.AnalyzeResult.ReadResults[0];

                    Assert.Equal(1, recognitionResult.Page);
                    Assert.Equal(250, recognitionResult.Width);
                    Assert.Equal(258, recognitionResult.Height);
                    Assert.Equal(TextRecognitionResultDimensionUnit.Pixel, recognitionResult.Unit);

                    Assert.Equal(
                        new string[] { "520", "WEST", "Seattle" }.OrderBy(t => t),
                        recognitionResult.Lines.Select(line => line.Text).OrderBy(t => t));
                    Assert.Equal(
                        new string[] { "520", "WEST", "Seattle" }.OrderBy(t => t),
                        recognitionResult.Lines.SelectMany(line => line.Words).Select(word => word.Text).OrderBy(t => t));
                    Assert.Equal(3, recognitionResult.Lines.Count);
                }
            }
        }

        [Fact]
        public void ReadFileInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ReadFileInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("whiteboard.jpg"), FileMode.Open))
                {
                    ReadInStreamHeaders headers = client.ReadInStreamWithHttpMessagesAsync(stream).Result.Headers;

                    Assert.NotNull(headers.OperationLocation);

                    ReadOperationResult readOperationResult = GetRecognitionResultWithPolling(client, headers.OperationLocation);

                    Assert.NotNull(readOperationResult);
                    Assert.Equal(OperationStatusCodes.Succeeded, readOperationResult.Status);

                    Assert.NotNull(readOperationResult.AnalyzeResult);
                    Assert.Equal(1, readOperationResult.AnalyzeResult.ReadResults.Count);

                    var recognitionResult = readOperationResult.AnalyzeResult.ReadResults[0];

                    Assert.Equal(1, recognitionResult.Page);
                    Assert.Equal(1000, recognitionResult.Width);
                    Assert.Equal(664, recognitionResult.Height);
                    Assert.Equal(TextRecognitionResultDimensionUnit.Pixel, recognitionResult.Unit);

                    Assert.Equal(
                        new string[] { "you must be the change", "you want to see in the world!" }.OrderBy(t => t),
                        recognitionResult.Lines.Select(line => line.Text).OrderBy(t => t));
                    Assert.Equal(2, recognitionResult.Lines.Count);
                    Assert.Equal(5, recognitionResult.Lines[0].Words.Count);
                    Assert.Equal(7, recognitionResult.Lines[1].Words.Count);
                }
            }
        }

        [Fact]
        public void ReadFileInStreamAprilModelBasicTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ReadFileInStreamAprilModelBasicTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("whiteboard.jpg"), FileMode.Open))
                {
                    ReadInStreamHeaders headers = client.ReadInStreamWithHttpMessagesAsync(stream, modelVersion: "2021-04-12", readingOrder: "basic").Result.Headers;

                    Assert.NotNull(headers.OperationLocation);

                    ReadOperationResult readOperationResult = GetRecognitionResultWithPolling(client, headers.OperationLocation);

                    Assert.NotNull(readOperationResult);
                    Assert.Equal(OperationStatusCodes.Succeeded, readOperationResult.Status);

                    Assert.NotNull(readOperationResult.AnalyzeResult);
                    Assert.Equal(1, readOperationResult.AnalyzeResult.ReadResults.Count);

                    var recognitionResult = readOperationResult.AnalyzeResult.ReadResults[0];

                    Assert.Equal(1, recognitionResult.Page);
                    Assert.Equal(1000, recognitionResult.Width);
                    Assert.Equal(664, recognitionResult.Height);
                    Assert.Equal(TextRecognitionResultDimensionUnit.Pixel, recognitionResult.Unit);

                    Assert.Equal(
                        new string[] { "you must be the change", "you want to see in the world!" }.OrderBy(t => t),
                        recognitionResult.Lines.Select(line => line.Text).OrderBy(t => t));
                    Assert.Equal(2, recognitionResult.Lines.Count);
                    Assert.Equal(5, recognitionResult.Lines[0].Words.Count);
                    Assert.Equal(7, recognitionResult.Lines[1].Words.Count);
                }
            }
        }

        [Fact]
        public void ReadPdfFileInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ReadPdfFileInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("menu.pdf"), FileMode.Open))
                {
                    ReadInStreamHeaders headers = client.ReadInStreamWithHttpMessagesAsync(stream).Result.Headers;

                    Assert.NotNull(headers.OperationLocation);

                    ReadOperationResult readOperationResult = GetRecognitionResultWithPolling(client, headers.OperationLocation);

                    Assert.NotNull(readOperationResult);
                    Assert.Equal(OperationStatusCodes.Succeeded, readOperationResult.Status);

                    Assert.NotNull(readOperationResult.AnalyzeResult);
                    Assert.Equal(1, readOperationResult.AnalyzeResult.ReadResults.Count);

                    var recognitionResult = readOperationResult.AnalyzeResult.ReadResults[0];

                    Assert.Equal(1, recognitionResult.Page);
                    Assert.Equal(8.5, recognitionResult.Width);
                    Assert.Equal(11, recognitionResult.Height);
                    Assert.Equal(TextRecognitionResultDimensionUnit.Inch, recognitionResult.Unit);

                    Assert.Equal(28, recognitionResult.Lines.Count);
                    Assert.Equal("Microsoft", recognitionResult.Lines[0].Text);
                }
            }
        }
    }
}

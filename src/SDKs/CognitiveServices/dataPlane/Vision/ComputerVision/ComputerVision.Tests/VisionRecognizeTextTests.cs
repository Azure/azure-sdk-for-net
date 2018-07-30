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
    public class VisionRecognizeTextTests : BaseTests
    {
        static private RecognitionResult GetRecognitionResultWithPolling(IComputerVisionClient client, string operationLocation)
        {
            string operationId = operationLocation.Substring(operationLocation.LastIndexOf('/') + 1);

            for (int remainingTries = 10; remainingTries > 0; remainingTries--)
            {
                TextOperationResult result = client.GetTextOperationResultAsync(operationId).Result;

                Assert.True(result.Status != TextOperationStatusCodes.Failed);

                if (result.Status == TextOperationStatusCodes.Succeeded)
                {
                    return result.RecognitionResult;
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            return null;
        }

        [Fact]
        public void RecognizeTextInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "RecognizeTextInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("whiteboard.jpg"), FileMode.Open))
                {
                    RecognizeTextInStreamHeaders headers = client.RecognizeTextInStreamAsync(stream, TextRecognitionMode.Handwritten).Result;

                    Assert.NotNull(headers.OperationLocation);

                    RecognitionResult recognitionResult = GetRecognitionResultWithPolling(client, headers.OperationLocation);

                    Assert.NotNull(recognitionResult);

                    Assert.Equal(
                        new string[] { "You must be the change", "you want to see in the world !" },
                        recognitionResult.Lines.Select(line => line.Text));
                    Assert.Equal(2, recognitionResult.Lines.Count);
                    Assert.Equal(5, recognitionResult.Lines[0].Words.Count);
                    Assert.Equal(8, recognitionResult.Lines[1].Words.Count);
                }
            }
        }

        [Fact]
        public void RecognizeTextTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "RecognizeTextTest");

                string imageUrl = GetTestImageUrl("signage.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    RecognizeTextHeaders headers = client.RecognizeTextAsync(imageUrl, TextRecognitionMode.Printed).Result;

                    Assert.NotNull(headers.OperationLocation);

                    RecognitionResult recognitionResult = GetRecognitionResultWithPolling(client, headers.OperationLocation);

                    Assert.NotNull(recognitionResult);

                    Assert.Equal(
                        new string[] { "520", "WEST", "Seattle" },
                        recognitionResult.Lines.Select(line => line.Text));
                    Assert.Equal(
                        new string[] { "520", "WEST", "Seattle" },
                        recognitionResult.Lines.SelectMany(line => line.Words).Select(word => word.Text));
                    Assert.Equal(3, recognitionResult.Lines.Count);
                }
            }
        }
    }
}

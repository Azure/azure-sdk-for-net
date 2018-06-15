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
        [Fact]
        public void RecognizeTextInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "RecognizeTextInStreamTest");

                using (IComputerVisionAPI client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("whiteboard.jpg"), FileMode.Open))
                {
                    RecognizeTextInStreamHeaders headers = client.RecognizeTextInStreamAsync(stream).Result;

                    Assert.NotNull(headers.OperationLocation);

                    string operationId = headers.OperationLocation.Substring(headers.OperationLocation.LastIndexOf('/') + 1);

                    RecognitionResult recognitionResult = null;
                    int remainingTries = 10;

                    while (remainingTries > 0)
                    {
                        TextOperationResult result = client.GetTextOperationResultAsync(operationId).Result;

                        Assert.True(result.Status != TextOperationStatusCodes.Failed);

                        if (result.Status == TextOperationStatusCodes.Succeeded)
                        {
                            recognitionResult = result.RecognitionResult;
                            break;
                        }

                        Thread.Sleep(TimeSpan.FromSeconds(1));

                        remainingTries--;
                    }

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
    }
}

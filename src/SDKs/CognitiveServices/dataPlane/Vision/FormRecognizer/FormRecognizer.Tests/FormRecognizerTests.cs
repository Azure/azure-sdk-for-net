using Microsoft.Azure.CognitiveServices.FormRecognizer;
using Microsoft.Azure.CognitiveServices.FormRecognizer.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Xunit;

namespace FormRecognizerSDK.Tests
{
    public class FormRecognizerTests : BaseTests
    {
        [Fact]
        public void TrainModel()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceIdentificationPersonGroupPositive");

                IFormRecognizerClient client = GetFormRecognizerClient(HttpMockServer.CreateInstance());

                TrainResult trainResult = client.TrainCustomModel(new TrainRequest("/input/data"));

                Assert.True(trainResult.Errors.Count == 0);
                Assert.True(!string.IsNullOrEmpty(trainResult.ModelId.ToString()));
            }
        }
    }
}

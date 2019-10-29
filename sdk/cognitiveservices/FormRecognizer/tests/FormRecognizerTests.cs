using Microsoft.Azure.CognitiveServices.FormRecognizer;
using Microsoft.Azure.CognitiveServices.FormRecognizer.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Xunit;
using System;
using System.IO;

namespace FormRecognizerSDK.Tests
{
    public class FormRecognizerTests : BaseTests
    {
        [Fact]
        public void VerifyFormClientObjectCreation()
        {
            var client = GetFormRecognizerClient(null);

            Assert.True(client.GetType() == typeof(FormRecognizerClient));
        }
    }
}

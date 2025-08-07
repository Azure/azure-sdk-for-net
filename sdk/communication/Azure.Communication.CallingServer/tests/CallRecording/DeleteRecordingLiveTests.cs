// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    internal class DeleteRecordingLiveTests : CallAutomationClientLiveTestsBase
    {
        public DeleteRecordingLiveTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task DeleteRecording()
        {
            if (SkipCallingServerInteractionLiveTests)
            {
                Assert.Ignore("Skip callingserver interaction live tests flag is on");
            }

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            string documentId = "0-wus-d4-d4c223871b58d3664401b66d35fca784";
            Uri contentEndpoint = new Uri($"https://us-storage.asm.skype.com/v1/objects/{documentId}");
            CallRecording callRecordingClient = client.GetCallRecording();
            Response response = await callRecordingClient.DeleteRecordingAsync(contentEndpoint);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task DeleteRecording404()
        {
            if (SkipCallingServerInteractionLiveTests)
            {
                Assert.Ignore("Skip callingserver interaction live tests flag is on");
            }

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            string nonExistentDocumentId = "0-wus-d4-d4c223871b58d3664401b66d35fca785";
            Uri contentEndpoint = new Uri($"https://us-storage.asm.skype.com/v1/objects/{nonExistentDocumentId}");
            CallRecording callRecordingClient = client.GetCallRecording();
            try
            {
                await callRecordingClient.DeleteRecordingAsync(contentEndpoint);
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404)
                {
                    Assert.Pass("Recording was not found");
                }
                else
                {
                    Assert.Fail($"Unexpected error: {ex}");
                }
            }
        }
    }
}

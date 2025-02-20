// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    internal class ContentDownloadLiveTests : CallAutomationClientLiveTestsBase
    {
        public ContentDownloadLiveTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task DownloadMetadata()
        {
            if (SkipCallingServerInteractionLiveTests)
            {
                Assert.Ignore("Skip callingserver interaction live tests flag is on");
            }

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            string documentId = "0-wus-d4-d4c223871b58d3664401b66d35fca784";
            Uri metadataEndpoint = new Uri($"https://us-storage.asm.skype.com/v1/objects/{documentId}/content/acsmetadata");
            CallRecording callRecordingClient = client.GetCallRecording();
            Stream metadata = await callRecordingClient.DownloadStreamingAsync(metadataEndpoint);
            Assert.IsNotNull(metadata);
            JsonElement actual = JsonDocument.Parse(metadata).RootElement;
            Assert.AreEqual(documentId, actual.GetProperty("chunkDocumentId").ToString());
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task DownloadMetadata_404()
        {
            if (SkipCallingServerInteractionLiveTests)
            {
                Assert.Ignore("Skip callingserver interaction live tests flag is on");
            }

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            string nonExistentDocumentId = "0-wus-d4-d4c223871b58d3664401b66d35fca785";
            Uri metadataEndpoint = new Uri($"https://us-storage.asm.skype.com/v1/objects/{nonExistentDocumentId}/content/acsmetadata");
            CallRecording callRecordingClient = client.GetCallRecording();
            try
            {
                Stream metadata = await callRecordingClient.DownloadStreamingAsync(metadataEndpoint);
                Assert.IsNotNull(metadata);
                JsonElement actual = JsonDocument.Parse(metadata).RootElement;
                Assert.AreEqual(nonExistentDocumentId, actual.GetProperty("chunkDocumentId").ToString());
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

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task DownloadMetadataRange()
        {
            if (SkipCallingServerInteractionLiveTests)
            {
                Assert.Ignore("Skip callingserver interaction live tests flag is on");
            }

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            int length = 5;
            string documentId = "0-wus-d4-d4c223871b58d3664401b66d35fca784";
            Uri metadataEndpoint = new Uri($"https://us-storage.asm.skype.com/v1/objects/{documentId}/content/acsmetadata");
            CallRecording callRecordingClient = client.GetCallRecording();
            Response<Stream> response = await callRecordingClient.DownloadStreamingAsync(metadataEndpoint, new HttpRange(0, length));
            Assert.IsNotNull(response);
            Assert.AreEqual(length, response.GetRawResponse().Headers.ContentLength);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        /// This test tries to get a US stored document id from EU endpoint.
        /// The backend server will redirect (respond with a 302) the request to a US endpoint
        /// and the SDK should be able to make the new request with no error.
        public async Task DownloadMetadataWithRedirection()
        {
            if (SkipCallingServerInteractionLiveTests)
            {
                Assert.Ignore("Skip callingserver interaction live tests flag is on");
            }

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            string documentId = "0-wus-d4-d4c223871b58d3664401b66d35fca784";
            Uri metadataEndpoint = new Uri($"https://eu-storage.asm.skype.com/v1/objects/{documentId}/content/acsmetadata");
            CallRecording callRecordingClient = client.GetCallRecording();
            Stream metadata = await callRecordingClient.DownloadStreamingAsync(metadataEndpoint);
            Assert.IsNotNull(metadata);
            JsonElement actual = JsonDocument.Parse(metadata).RootElement;
            Assert.AreEqual(documentId, actual.GetProperty("chunkDocumentId").ToString());
        }
    }
}

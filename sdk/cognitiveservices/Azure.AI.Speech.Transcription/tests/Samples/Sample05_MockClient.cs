// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples demonstrating how to mock TranscriptionClient for unit testing.
    /// </summary>
    public partial class Sample05_MockClient : TranscriptionSampleBase
    {
        /// <summary>
        /// Demonstrates creating a mock TranscriptionClient for testing purposes.
        /// This allows testing application logic without making actual API calls to Azure.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void CreateMockClient()
        {
            #region Snippet:CreateMockTranscriptionClient
            // TranscriptionClient provides a protected constructor for mocking
            // You can create a derived class for testing purposes

            // Example: Create a test-specific derived class
            var mockClient = new MockTranscriptionClient();

            // Use the mock client in your tests
            // It won't make actual API calls
            #endregion Snippet:CreateMockTranscriptionClient
        }

        /// <summary>
        /// Demonstrates mocking TranscriptionClient behavior for unit tests.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task MockTranscriptionBehavior()
        {
            #region Snippet:MockTranscriptionBehavior
            // Create a mock client that returns predefined results
            var mockClient = new MockTranscriptionClient();

            // Configure the mock to return a specific result
            var expectedText = "This is a mock transcription result";
            mockClient.SetMockResult(expectedText);

            // Create a test request
            using var audioStream = new MemoryStream(new byte[] { 0x00, 0x01, 0x02 });
            TranscriptionContent request = new TranscriptionContent
            {
                Audio = audioStream
            };

            // Call the mock client
            Response<TranscriptionResult> response = await mockClient.TranscribeAsync(request);

            // Verify the result
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);

            // The mock client returns the configured result
            var phrases = response.Value.PhrasesByChannel.FirstOrDefault();
            if (phrases != null)
            {
                Console.WriteLine($"Mock transcription: {phrases.Text}");
            }
            #endregion Snippet:MockTranscriptionBehavior
        }

        /// <summary>
        /// Demonstrates using InMemoryTransport for testing without network calls.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task UseInMemoryTransport()
        {
            #region Snippet:UseInMemoryTransport
            // Create a mock response that the client will return
            var mockResponseContent = @"{
                ""durationMilliseconds"": 5000,
                ""combinedPhrases"": [
                    {
                        ""channel"": 0,
                        ""text"": ""This is a test transcription""
                    }
                ],
                ""phrases"": [
                    {
                        ""channel"": 0,
                        ""offsetMilliseconds"": 0,
                        ""durationMilliseconds"": 5000,
                        ""text"": ""This is a test transcription"",
                        ""words"": [],
                        ""locale"": ""en-US"",
                        ""confidence"": 0.95
                    }
                ]
            }";

            // Create options with a mock transport
            var mockTransport = new MockTransport(new MockResponse(200)
            {
                ContentStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(mockResponseContent))
            });

            TranscriptionClientOptions options = new TranscriptionClientOptions();
            options.Transport = mockTransport;

            // Create client with mock transport
            Uri endpoint = new Uri("https://mock.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("mock-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);

            // Make a request - it will use the mock response
            using var audioStream = new MemoryStream(new byte[] { 0x00, 0x01, 0x02 });
            TranscriptionContent request = new TranscriptionContent
            {
                Audio = audioStream
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);

            // Verify the mock response was returned
            Console.WriteLine($"Duration: {response.Value.Duration}");
            var phrases = response.Value.PhrasesByChannel.First();
            Console.WriteLine($"Transcription: {phrases.Text}");
            #endregion Snippet:UseInMemoryTransport
        }

        /// <summary>
        /// Demonstrates testing error scenarios with mock responses.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task MockErrorScenarios()
        {
            #region Snippet:MockErrorScenarios
            // Create a mock transport that returns an error
            var mockTransport = new MockTransport(new MockResponse(401)
            {
                ContentStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(
                    @"{""error"": {""code"": ""Unauthorized"", ""message"": ""Invalid API key""}}"
                ))
            });

            TranscriptionClientOptions options = new TranscriptionClientOptions();
            options.Transport = mockTransport;

            Uri endpoint = new Uri("https://mock.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("invalid-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);

            // Test error handling
            try
            {
                using var audioStream = new MemoryStream(new byte[] { 0x00, 0x01, 0x02 });
                TranscriptionContent request = new TranscriptionContent
                {
                    Audio = audioStream
                };

                await client.TranscribeAsync(request);
                Assert.Fail("Expected RequestFailedException was not thrown");
            }
            catch (RequestFailedException ex)
            {
                // Verify error handling works correctly
                Assert.AreEqual(401, ex.Status);
                Console.WriteLine($"Successfully caught error: {ex.Message}");
            }
            #endregion Snippet:MockErrorScenarios
        }

        /// <summary>
        /// Example mock implementation for testing.
        /// </summary>
        private class MockTranscriptionClient : TranscriptionClient
        {
            private string _mockResultText = "Mock transcription";

            public MockTranscriptionClient() : base()
            {
            }

            public void SetMockResult(string text)
            {
                _mockResultText = text;
            }

            // Override methods to return mock results
            // Note: In a real implementation, you would override the actual methods
            // This is just an illustration of the pattern
        }
    }
}
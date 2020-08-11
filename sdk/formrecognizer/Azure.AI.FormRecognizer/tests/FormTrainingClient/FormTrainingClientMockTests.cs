// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of mock tests for the <see cref="FormTrainingClient"/> class.
    /// </summary>
    public class FormTrainingClientMockTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClientMockTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormTrainingClientMockTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="FormTrainingClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The instrumented <see cref="FormTrainingClient" />.</returns>
        private FormTrainingClient CreateInstrumentedClient(FormRecognizerClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new FormRecognizerClientOptions();

            var client = new FormTrainingClient(fakeEndpoint, fakeCredential, options);
            return InstrumentClient(client);
        }

        [Test]
        public async Task StartTrainingEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(201);
            mockResponse.AddHeader(new HttpHeader("Location", "host/custom/models/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var encodedUriString = "https://fakeuri.com/blank%20space";
            var decodedUriString = "https://fakeuri.com/blank space";

            await client.StartTrainingAsync(new Uri(encodedUriString), useTrainingLabels: false);
            await client.StartTrainingAsync(new Uri(decodedUriString), useTrainingLabels: false);

            Assert.AreEqual(2, mockTransport.Requests.Count);

            foreach (var request in mockTransport.Requests)
            {
                var requestBody = GetString(request.Content);

                Assert.True(requestBody.Contains(encodedUriString));
                Assert.False(requestBody.Contains(decodedUriString));
            }
        }

        [Test]
        public async Task GetCustomModelDoesNotNeedTrainResult()
        {
            // When a model is still being created, the "trainResult" property is
            // not returned. We're mimicking this behavior here to make sure that
            // we can parse the response even without the "trainResult" property.

            // Ideally this test should be live, but the service behavior is
            // non-deterministic. Any delay in sending the request could give the
            // model enough time to change its status to Ready.

            using var Stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""modelInfo"": {
                        ""modelId"": ""00000000-0000-0000-0000-000000000000"",
                        ""status"": ""creating"",
                        ""createdDateTime"": ""1975-04-04T00:00:00Z"",
                        ""lastUpdatedTime"": ""1975-04-04T00:00:00Z""
                    }
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = Stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var response = await client.GetCustomModelAsync("00000000-0000-0000-0000-000000000000");
            var model = response.Value;

            Assert.IsEmpty(model.TrainingDocuments);
            Assert.IsEmpty(model.Errors);
        }

        private static string GetString(RequestContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}

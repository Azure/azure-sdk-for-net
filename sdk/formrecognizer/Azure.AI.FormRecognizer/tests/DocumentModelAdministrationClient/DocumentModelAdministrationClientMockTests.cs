// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of mock tests for the <see cref="DocumentModelAdministrationClient"/> class.
    /// </summary>
    public class DocumentModelAdministrationClientMockTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentModelAdministrationClientMockTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentModelAdministrationClientMockTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="DocumentModelAdministrationClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The instrumented <see cref="DocumentModelAdministrationClient" />.</returns>
        private DocumentModelAdministrationClient CreateInstrumentedClient(DocumentAnalysisClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new DocumentAnalysisClientOptions();

            var client = new DocumentModelAdministrationClient(fakeEndpoint, fakeCredential, options);
            return InstrumentClient(client);
        }

        [Test]
        public async Task BuildModelEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("operation-location", "host/operations/00000000000000000000000000000000?api-version=2021-07-30-preview"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var encodedUriString = "https://fakeuri.com/blank%20space";
            var decodedUriString = "https://fakeuri.com/blank space";

            await client.BuildDocumentModelAsync(WaitUntil.Started, new Uri(encodedUriString), DocumentBuildMode.Template);
            await client.BuildDocumentModelAsync(WaitUntil.Started, new Uri(decodedUriString), DocumentBuildMode.Template);

            Assert.AreEqual(2, mockTransport.Requests.Count);

            foreach (var request in mockTransport.Requests)
            {
                var requestBody = GetString(request.Content);

                Assert.True(requestBody.Contains(encodedUriString));
                Assert.False(requestBody.Contains(decodedUriString));
            }
        }

        [Test]
        public async Task BuildModelGeneratesModelID()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("operation-location", "host/operations/00000000000000000000000000000000?api-version=2021-07-30-preview"));

            var mockTransport = new MockTransport(new[] { mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            await client.BuildDocumentModelAsync(WaitUntil.Started, new Uri("http://localhost"), DocumentBuildMode.Template);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string modelId = contentString.Substring(contentString.IndexOf("modelId") + 10, 36);

            ClientCommon.ValidateModelId(modelId, "test");
        }

        [Test]
        public async Task ComposeModelGeneratesModelID()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("operation-location", "host/operations/00000000000000000000000000000000?api-version=2021-07-30-preview"));

            var mockTransport = new MockTransport(new[] { mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            await client.ComposeDocumentModelAsync(WaitUntil.Started, new List<string> { "123123", "34234"} );

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string modelId = contentString.Substring(contentString.IndexOf("modelId") + 10, 36);

            ClientCommon.ValidateModelId(modelId, "test");
        }

        private static string GetString(RequestContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}

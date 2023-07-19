// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Tests
{
    public class DocumentTranslationMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso-textanalytics.cognitiveservices.azure.com/";
        private static readonly string s_apiKey = "FakeapiKey";

        public DocumentTranslationMockTests(bool isAsync) : base(isAsync)
        {
        }

        private DocumentTranslationClient CreateTestClient(HttpPipelineTransport transport)
        {
            var options = new DocumentTranslationClientOptions()
            {
                Transport = transport
            };

            return new DocumentTranslationClient(new Uri(s_endpoint), new AzureKeyCredential(s_apiKey), options);
        }

        [Test]
        public async Task StartTranslationWithCategoryId()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/batches/215c9633-fca1-4821-ab29-70e4e2fbacc7"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var input = new DocumentTranslationInput(new Uri("http://source"), new Uri("http://target"), "fr");
            input.AddTarget(new Uri("http://target2"), "es", categoryId: "myCategoryId");

            await client.StartTranslationAsync(input);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string category = contentString.Substring(contentString.IndexOf("category"), 23);

            var expectedContent = "category\":\"myCategoryId";
            Assert.AreEqual(expectedContent, category);
        }

        private static string GetString(RequestContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}

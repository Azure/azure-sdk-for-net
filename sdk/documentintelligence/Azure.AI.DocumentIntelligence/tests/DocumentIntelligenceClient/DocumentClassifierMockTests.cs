// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DocumentClassifierMockTests : ClientTestBase
    {
        public DocumentClassifierMockTests(bool isAsync)
            : base(isAsync)
        {
        }

        private static object[] s_ClassifyDocumentSendsSplitTestCases =
        {
            new object[] { "split=auto", SplitMode.Auto },
            new object[] { "split=perPage", SplitMode.PerPage }
        };

        [Test]
        [TestCaseSource(nameof(s_ClassifyDocumentSendsSplitTestCases))]
        public async Task ClassifyDocumentSendsSplit(string expectedQuerySubstring, SplitMode split)
        {
            var mockResponse = new MockResponse(202);
            var mockTransport = new MockTransport(new[] { mockResponse });
            var options = new AzureAIDocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var content = new ClassifyDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.ClassifyDocumentAsync(WaitUntil.Started, "classifierId", content, split: split);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;

            Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
        }

        private DocumentIntelligenceClient CreateInstrumentedClient(AzureAIDocumentIntelligenceClientOptions options)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            var client = new DocumentIntelligenceClient(fakeEndpoint, fakeCredential, options);

            return InstrumentClient(client);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DocumentModelMockTests : ClientTestBase
    {
        public DocumentModelMockTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [TestCase("")]
        [TestCase("1")]
        [TestCase("1-2")]
        [TestCase("1-2,3", Ignore = "https://github.com/Azure/azure-sdk-for-net/issues/41291")]
        public async Task AnalyzeDocumentSendsPages(string pages)
        {
            var mockResponse = new MockResponse(202);
            var mockTransport = new MockTransport(new[] { mockResponse });
            var options = new AzureAIDocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", content, pages: pages);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedQuerySubstring = $"pages={pages}";

            Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
        }

        [Test]
        [TestCase("")]
        [TestCase("en-US")]
        [TestCase("pt-BR")]
        public async Task AnalyzeDocumentSendsLocale(string locale)
        {
            var mockResponse = new MockResponse(202);
            var mockTransport = new MockTransport(new[] { mockResponse });
            var options = new AzureAIDocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", content, locale: locale);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedQuerySubstring = $"locale={locale}";

            Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
        }

        private static object[] s_AnalyzeDocumentSendsFeaturesTestCases =
        {
            new object[] { "features=", Array.Empty<DocumentAnalysisFeature>() },
            new object[] { "features=formulas",
                new[] { DocumentAnalysisFeature.Formulas } },
            new object[] { "features=formulas%2CstyleFont",
                new[] { DocumentAnalysisFeature.Formulas, DocumentAnalysisFeature.StyleFont } }
        };

        [Test]
        [TestCaseSource(nameof(s_AnalyzeDocumentSendsFeaturesTestCases))]
        public async Task AnalyzeDocumentSendsFeatures(string expectedQuerySubstring, DocumentAnalysisFeature[] features)
        {
            var mockResponse = new MockResponse(202);
            var mockTransport = new MockTransport(new[] { mockResponse });
            var options = new AzureAIDocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", content, features: features);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;

            Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
        }

        [Test]
        [TestCase(new object[] { })]
        [TestCase(new object[] { "name" })]
        [TestCase(new object[] { "name", "address" })]
        public async Task AnalyzeDocumentSendsQueryFields(params string[] queryFields)
        {
            var mockResponse = new MockResponse(202);
            var mockTransport = new MockTransport(new[] { mockResponse });
            var options = new AzureAIDocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", content, queryFields: queryFields);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedQuerySubstring = "queryFields=" + string.Join("%2C", queryFields);

            Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
        }

        private static object[] s_AnalyzeDocumentSendsOutputContentFormatTestCases =
        {
            new object[] { "outputContentFormat=text", ContentFormat.Text },
            new object[] { "outputContentFormat=markdown", ContentFormat.Markdown }
        };

        [Test]
        [TestCaseSource(nameof(s_AnalyzeDocumentSendsOutputContentFormatTestCases))]
        public async Task AnalyzeDocumentSendsOutputContentFormat(string expectedQuerySubstring, ContentFormat format)
        {
            var mockResponse = new MockResponse(202);
            var mockTransport = new MockTransport(new[] { mockResponse });
            var options = new AzureAIDocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", content, outputContentFormat: format);

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

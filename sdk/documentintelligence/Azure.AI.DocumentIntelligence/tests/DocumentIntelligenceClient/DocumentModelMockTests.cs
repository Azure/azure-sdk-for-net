// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            var clientOptions = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(clientOptions);

            var options = new AnalyzeDocumentOptions()
            {
                UriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", options, pages: pages);

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
            var clientOptions = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(clientOptions);

            var options = new AnalyzeDocumentOptions()
            {
                UriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", options, locale: locale);

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
                new[] { DocumentAnalysisFeature.Formulas, DocumentAnalysisFeature.FontStyling } }
        };

        [Test]
        [TestCaseSource(nameof(s_AnalyzeDocumentSendsFeaturesTestCases))]
        public async Task AnalyzeDocumentSendsFeatures(string expectedQuerySubstring, DocumentAnalysisFeature[] features)
        {
            var mockResponse = new MockResponse(202);
            var mockTransport = new MockTransport(new[] { mockResponse });
            var clientOptions = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(clientOptions);

            var options = new AnalyzeDocumentOptions()
            {
                UriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", options, features: features);

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
            var clientOptions = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(clientOptions);

            var options = new AnalyzeDocumentOptions()
            {
                UriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", options, queryFields: queryFields);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedQuerySubstring = "queryFields=" + string.Join("%2C", queryFields);

            Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
        }

        private static object[] s_AnalyzeDocumentSendsOutputContentFormatTestCases =
        {
            new object[] { "outputContentFormat=text", DocumentContentFormat.Text },
            new object[] { "outputContentFormat=markdown", DocumentContentFormat.Markdown }
        };

        [Test]
        [TestCaseSource(nameof(s_AnalyzeDocumentSendsOutputContentFormatTestCases))]
        public async Task AnalyzeDocumentSendsOutputContentFormat(string expectedQuerySubstring, DocumentContentFormat format)
        {
            var mockResponse = new MockResponse(202);
            var mockTransport = new MockTransport(new[] { mockResponse });
            var clientOptions = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(clientOptions);

            var options = new AnalyzeDocumentOptions()
            {
                UriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", options, outputContentFormat: format);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;

            Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
        }

        private DocumentIntelligenceClient CreateNonInstrumentedClient(DocumentIntelligenceClientOptions options)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");

            return new DocumentIntelligenceClient(fakeEndpoint, fakeCredential, options);
        }

        private DocumentIntelligenceClient CreateInstrumentedClient(DocumentIntelligenceClientOptions options)
        {
            var client = CreateNonInstrumentedClient(options);

            return InstrumentClient(client);
        }
    }
}

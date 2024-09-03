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
            var options = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
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
            var options = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
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
            var options = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
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
            var options = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
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
            var options = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, "modelId", content, outputContentFormat: format);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;

            Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeBatchDocuments(bool isAsync)
        {
            using var postResponse = new MockResponse(202);

            postResponse.AddHeader("Operation-Location", "https://fakeResource.azure.com/documentIntelligence/documentModels/prebuilt-read/analyzeBatchResults/0123456789ABCDEF?api-version=2024-07-31-preview");

            using var getResponseRunning = new MockResponse(200);
            using var getResponseRunningBody = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "status": "running",
                    "percentCompleted": 67,
                    "createdDateTime": "2021-09-24T13:00:46Z",
                    "lastUpdatedDateTime": "2021-09-24T13:00:49Z"
                }
                """));

            getResponseRunning.ContentStream = getResponseRunningBody;

            using var getResponseCompleted = new MockResponse(200);
            using var getResponseCompletedBody = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "status": "succeeded",
                    "percentCompleted": 100,
                    "createdDateTime": "2021-09-24T13:00:46Z",
                    "lastUpdatedDateTime": "2021-09-24T13:00:55Z",
                    "result": {
                        "succeededCount": 2,
                        "failedCount": 0,
                        "skippedCount": 0,
                        "details": [
                            {
                                "sourceUrl": "https://fake_source_url_0.com/",
                                "resultUrl": "https://fake_result_url_0.com/",
                                "status": "succeeded"
                            },
                            {
                                "sourceUrl": "https://fake_source_url_1.com/",
                                "resultUrl": "https://fake_result_url_1.com/",
                                "status": "succeeded"
                            }
                        ]
                    }
                }
                """));

            getResponseCompleted.ContentStream = getResponseCompletedBody;

            var mockTransport = new InterceptorMockTransport(new[] { postResponse, getResponseRunning, getResponseCompleted });
            var options = new DocumentIntelligenceClientOptions() { Transport = mockTransport };
            var client = CreateNonInstrumentedClient(options);

            var content = new AnalyzeBatchDocumentsContent(new Uri("https://fake_result_container_url.com"))
            {
                AzureBlobSource = new AzureBlobContentSource(new Uri("https://fake_source_container_url.com"))
            };

            var operation = isAsync
                ? await client.AnalyzeBatchDocumentsAsync(WaitUntil.Completed, "prebuilt-read", content)
                : client.AnalyzeBatchDocuments(WaitUntil.Completed, "prebuilt-read", content);

            // Validate the request.

            var postRequestBody = mockTransport.FirstRequestBody;
            var postRequestJson = JsonDocument.Parse(postRequestBody);

            var resultContainerUrlElement = postRequestJson.RootElement.GetProperty("resultContainerUrl");
            var azureBlobSourceElement = postRequestJson.RootElement.GetProperty("azureBlobSource");
            var containerUrlElement = azureBlobSourceElement.GetProperty("containerUrl");

            Assert.That(resultContainerUrlElement.ToString(), Is.EqualTo("https://fake_result_container_url.com/"));
            Assert.That(containerUrlElement.ToString(), Is.EqualTo("https://fake_source_container_url.com/"));

            // Validate the response.

            Assert.That(operation.HasValue);
            Assert.That(operation.HasCompleted);

            var result = operation.Value;

            Assert.That(result.SucceededCount, Is.EqualTo(2));
            Assert.That(result.FailedCount, Is.EqualTo(0));
            Assert.That(result.SkippedCount, Is.EqualTo(0));
            Assert.That(result.Details.Count, Is.EqualTo(2));

            var operationDetail0 = result.Details[0];
            var operationDetail1 = result.Details[1];

            Assert.That(operationDetail0.Status, Is.EqualTo(OperationStatus.Succeeded));
            Assert.That(operationDetail0.SourceUrl.AbsoluteUri, Is.EqualTo("https://fake_source_url_0.com/"));
            Assert.That(operationDetail0.ResultUrl.AbsoluteUri, Is.EqualTo("https://fake_result_url_0.com/"));

            Assert.That(operationDetail1.Status, Is.EqualTo(OperationStatus.Succeeded));
            Assert.That(operationDetail1.SourceUrl.AbsoluteUri, Is.EqualTo("https://fake_source_url_1.com/"));
            Assert.That(operationDetail1.ResultUrl.AbsoluteUri, Is.EqualTo("https://fake_result_url_1.com/"));
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

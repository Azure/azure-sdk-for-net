// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Moq;
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
        [AsyncOnly]
        public async Task AnalyzeDocumentAsyncFromUriSourceInvokesMainMethod()
        {
            var mockClient = new Mock<DocumentIntelligenceClient>() { CallBase = true };
            var uriSource = new Uri("https://fakeuri.com/");
            using var tokenSource = new CancellationTokenSource();
            var expectedResult = Mock.Of<Operation<AnalyzeResult>>();

            mockClient.Setup(c => c.AnalyzeDocumentAsync(
                WaitUntil.Started,
                It.Is<AnalyzeDocumentOptions>(options =>
                    options.ModelId == "<modelId>"
                    && options.UriSource == uriSource
                    && options.BytesSource == null
                    && options.Pages == null
                    && options.Locale == null
                    && !options.Features.Any()
                    && !options.QueryFields.Any()
                    && options.OutputContentFormat == null
                    && !options.Output.Any()),
                tokenSource.Token
            )).Returns(Task.FromResult(expectedResult));

            var result = await mockClient.Object.AnalyzeDocumentAsync(WaitUntil.Started, "<modelId>", uriSource, tokenSource.Token);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [SyncOnly]
        public void AnalyzeDocumentFromUriSourceInvokesMainMethod()
        {
            var mockClient = new Mock<DocumentIntelligenceClient>() { CallBase = true };
            var uriSource = new Uri("https://fakeuri.com/");
            using var tokenSource = new CancellationTokenSource();
            var expectedResult = Mock.Of<Operation<AnalyzeResult>>();

            mockClient.Setup(c => c.AnalyzeDocument(
                WaitUntil.Started,
                It.Is<AnalyzeDocumentOptions>(options =>
                    options.ModelId == "<modelId>"
                    && options.UriSource == uriSource
                    && options.BytesSource == null
                    && options.Pages == null
                    && options.Locale == null
                    && !options.Features.Any()
                    && !options.QueryFields.Any()
                    && options.OutputContentFormat == null
                    && !options.Output.Any()),
                tokenSource.Token
            )).Returns(expectedResult);

            var result = mockClient.Object.AnalyzeDocument(WaitUntil.Started, "<modelId>", uriSource, tokenSource.Token);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [AsyncOnly]
        public async Task AnalyzeDocumentAsyncFromBytesSourceInvokesMainMethod()
        {
            var mockClient = new Mock<DocumentIntelligenceClient>() { CallBase = true };
            var bytesSource = BinaryData.FromBytes(new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F });
            using var tokenSource = new CancellationTokenSource();
            var expectedResult = Mock.Of<Operation<AnalyzeResult>>();

            mockClient.Setup(c => c.AnalyzeDocumentAsync(
                WaitUntil.Started,
                It.Is<AnalyzeDocumentOptions>(options =>
                    options.ModelId == "<modelId>"
                    && options.UriSource == null
                    && options.BytesSource == bytesSource
                    && options.Pages == null
                    && options.Locale == null
                    && !options.Features.Any()
                    && !options.QueryFields.Any()
                    && options.OutputContentFormat == null
                    && !options.Output.Any()),
                tokenSource.Token
            )).Returns(Task.FromResult(expectedResult));

            var result = await mockClient.Object.AnalyzeDocumentAsync(WaitUntil.Started, "<modelId>", bytesSource, tokenSource.Token);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [SyncOnly]
        public void AnalyzeDocumentFromBytesSourceInvokesMainMethod()
        {
            var mockClient = new Mock<DocumentIntelligenceClient>() { CallBase = true };
            var bytesSource = BinaryData.FromBytes(new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F });
            using var tokenSource = new CancellationTokenSource();
            var expectedResult = Mock.Of<Operation<AnalyzeResult>>();

            mockClient.Setup(c => c.AnalyzeDocument(
                WaitUntil.Started,
                It.Is<AnalyzeDocumentOptions>(options =>
                    options.ModelId == "<modelId>"
                    && options.UriSource == null
                    && options.BytesSource == bytesSource
                    && options.Pages == null
                    && options.Locale == null
                    && !options.Features.Any()
                    && !options.QueryFields.Any()
                    && options.OutputContentFormat == null
                    && !options.Output.Any()),
                tokenSource.Token
            )).Returns(expectedResult);

            var result = mockClient.Object.AnalyzeDocument(WaitUntil.Started, "<modelId>", bytesSource, tokenSource.Token);

            Assert.That(result, Is.EqualTo(expectedResult));
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

            var uriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt);
            var options = new AnalyzeDocumentOptions("modelId", uriSource)
            {
                Pages = pages
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, options);

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

            var uriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt);
            var options = new AnalyzeDocumentOptions("modelId", uriSource)
            {
                Locale = locale
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, options);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedQuerySubstring = $"locale={locale}";

            Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
        }

        private static object[] s_AnalyzeDocumentSendsFeaturesTestCases =
        {
            new object[] { null, Array.Empty<DocumentAnalysisFeature>() },
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

            var uriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt);
            var options = new AnalyzeDocumentOptions("modelId", uriSource);

            foreach (var feature in features)
            {
                options.Features.Add(feature);
            }

            await client.AnalyzeDocumentAsync(WaitUntil.Started, options);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;

            if (features.Length > 0)
            {
                Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
            }
            else
            {
                Assert.That(requestUriQuery.Contains("features"), Is.False);
            }
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

            var uriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt);
            var options = new AnalyzeDocumentOptions("modelId", uriSource);

            foreach (var queryField in queryFields)
            {
                options.QueryFields.Add(queryField);
            }

            await client.AnalyzeDocumentAsync(WaitUntil.Started, options);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;

            if (queryFields.Length > 0)
            {
                var expectedQuerySubstring = "queryFields=" + string.Join("%2C", queryFields);

                Assert.That(requestUriQuery.Contains(expectedQuerySubstring));
            }
            else
            {
                Assert.That(requestUriQuery.Contains("queryFields"), Is.False);
            }
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

            var uriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt);
            var options = new AnalyzeDocumentOptions("modelId", uriSource)
            {
                OutputContentFormat = format
            };

            await client.AnalyzeDocumentAsync(WaitUntil.Started, options);

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

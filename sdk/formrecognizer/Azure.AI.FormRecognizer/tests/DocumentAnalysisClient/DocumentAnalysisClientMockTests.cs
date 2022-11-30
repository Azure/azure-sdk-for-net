// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

using TestFile = Azure.AI.FormRecognizer.Tests.TestFile;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of mock tests for the <see cref="DocumentAnalysisClient"/> class.
    /// </summary>
    public class DocumentAnalysisClientMockTests : ClientTestBase
    {
        private const string FakeGuid = "00000000000000000000000000000000";

        private const string OperationId = "00000000000000000000000000000000/analyzeResults/00000000000000000000000000000000?api-version=2021-09-30-preview";

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClientMockTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentAnalysisClientMockTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="DocumentAnalysisClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The instrumented <see cref="DocumentAnalysisClient" />.</returns>
        private DocumentAnalysisClient CreateInstrumentedClient(DocumentAnalysisClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new DocumentAnalysisClientOptions();

            var client = new DocumentAnalysisClient(fakeEndpoint, fakeCredential, options);
            return InstrumentClient(client);
        }

        #region Analyze Document

        [Test]
        public async Task AnalyzeDocumentSendsContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            await client.AnalyzeDocumentAsync(WaitUntil.Started, FakeGuid, stream);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("application/octet-stream", contentType);
        }

        [Test]
        [TestCase("")]
        [TestCase("en-US")]
        public async Task AnalyzeDocumentSendsUserSpecifiedLocale(string locale)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            var analyzeOptions = new AnalyzeDocumentOptions { Locale = locale };
            await client.AnalyzeDocumentAsync(WaitUntil.Started, FakeGuid, stream, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"locale={locale}";

            Assert.True(requestUriQuery.Contains(expectedSubstring));
        }

        [Test]
        [TestCase("")]
        [TestCase("en-US")]
        public async Task AnalyzeDocumentFromUriSendsUserSpecifiedLocale(string locale)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var uri = new Uri("https://fakeuri.com/");
            var analyzeOptions = new AnalyzeDocumentOptions { Locale = locale };
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, uri, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"locale={locale}";

            Assert.True(requestUriQuery.Contains(expectedSubstring));
        }

        [Test]
        [TestCase("1")]
        [TestCase("1-2")]
        public async Task AnalyzeDocumentSendsOnePageArgument(string pages)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            var analyzeOptions = new AnalyzeDocumentOptions { Pages = { pages } };
            await client.AnalyzeDocumentAsync(WaitUntil.Started, FakeGuid, stream, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"pages={pages}";

            Assert.True(requestUriQuery.Contains(expectedSubstring));
        }

        [Test]
        [TestCase("1")]
        [TestCase("1-2")]
        public async Task AnalyzeDocumentFromUriSendsOnePageArgument(string pages)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var uri = new Uri("https://fakeuri.com/");
            var analyzeOptions = new AnalyzeDocumentOptions { Pages = { pages } };
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, uri, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"pages={pages}";

            Assert.True(requestUriQuery.Contains(expectedSubstring));
        }

        [Test]
        [TestCase("1", "3")]
        [TestCase("1-2", "3")]
        public async Task AnalyzeDocumentSendsMultiplePageArgument(string page1, string page2)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            var analyzeOptions = new AnalyzeDocumentOptions { Pages = { page1, page2 } };
            await client.AnalyzeDocumentAsync(WaitUntil.Started, FakeGuid, stream, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"pages={page1}%2C{page2}";

            Assert.True(requestUriQuery.Contains(expectedSubstring));
        }

        [Test]
        [TestCase("1", "3")]
        [TestCase("1-2", "3")]
        public async Task AnalyzeDocumentFromUriSendsMultiplePageArgument(string page1, string page2)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var uri = new Uri("https://fakeuri.com/");
            var analyzeOptions = new AnalyzeDocumentOptions { Pages = { page1, page2 } };
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, uri, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"pages={page1}%2C{page2}";

            Assert.True(requestUriQuery.Contains(expectedSubstring));
        }

        [Test]
        public async Task AnalyzeDocumentFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var encodedUriString = "https://fakeuri.com/blank%20space";
            var decodedUriString = "https://fakeuri.com/blank space";

            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, new Uri(encodedUriString));
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, new Uri(decodedUriString));

            Assert.AreEqual(2, mockTransport.Requests.Count);

            foreach (var request in mockTransport.Requests)
            {
                var requestBody = GetString(request.Content);

                Assert.True(requestBody.Contains(encodedUriString));
                Assert.False(requestBody.Contains(decodedUriString));
            }
        }

        #endregion

        private static string GetString(RequestContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}

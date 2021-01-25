// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of mock tests for the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    public class FormRecognizerClientMockTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClientMockTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormRecognizerClientMockTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="FormRecognizerClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateInstrumentedClient(FormRecognizerClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new FormRecognizerClientOptions();

            var client = new FormRecognizerClient(fakeEndpoint, fakeCredential, options);
            return InstrumentClient(client);
        }

        #region Recognize Content

        [Test]
        public async Task StartRecognizeContentSendsUserSpecifiedContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/layout/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            var recognizeOptions = new RecognizeContentOptions { ContentType = FormContentType.Jpeg };
            await client.StartRecognizeContentAsync(stream, recognizeOptions);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("image/jpeg", contentType);
        }

        [Test]
        public async Task StartRecognizeContentSendsAutoDetectedContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/layout/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            await client.StartRecognizeContentAsync(stream);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("image/tiff", contentType);
        }

        [Test]
        public async Task StartRecognizeContentFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/layout/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var encodedUriString = "https://fakeuri.com/blank%20space";
            var decodedUriString = "https://fakeuri.com/blank space";

            await client.StartRecognizeContentFromUriAsync(new Uri(encodedUriString));
            await client.StartRecognizeContentFromUriAsync(new Uri(decodedUriString));

            Assert.AreEqual(2, mockTransport.Requests.Count);

            foreach (var request in mockTransport.Requests)
            {
                var requestBody = GetString(request.Content);

                Assert.True(requestBody.Contains(encodedUriString));
                Assert.False(requestBody.Contains(decodedUriString));
            }
        }

        [Test]
        [TestCase("")]
        [TestCase("en")]
        public async Task StartRecognizeContentSendsUserSpecifiedLanguage(string language)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/layout/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Form1);
            var recognizeOptions = new RecognizeContentOptions { Language = language };
            await client.StartRecognizeContentAsync(stream, recognizeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;

            var languageQuery = "language=";
            var index = requestUriQuery.IndexOf(languageQuery);
            var length = requestUriQuery.Length - (index + languageQuery.Length);
            Assert.AreEqual(language, requestUriQuery.Substring(index + languageQuery.Length, length));
        }

        #endregion

        #region Recognize Receipt
        [Test]
        public async Task StartRecognizeReceiptsSendsUserSpecifiedContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/receipt/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            var recognizeOptions = new RecognizeReceiptsOptions { ContentType = FormContentType.Jpeg };
            await client.StartRecognizeReceiptsAsync(stream, recognizeOptions);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("image/jpeg", contentType);
        }

        [Test]
        public async Task StartRecognizeReceiptsSendsAutoDetectedContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/receipt/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            await client.StartRecognizeReceiptsAsync(stream);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("image/tiff", contentType);
        }

        [Test]
        public async Task StartRecognizeReceiptsFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/receipt/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var encodedUriString = "https://fakeuri.com/blank%20space";
            var decodedUriString = "https://fakeuri.com/blank space";

            await client.StartRecognizeReceiptsFromUriAsync(new Uri(encodedUriString));
            await client.StartRecognizeReceiptsFromUriAsync(new Uri(decodedUriString));

            Assert.AreEqual(2, mockTransport.Requests.Count);

            foreach (var request in mockTransport.Requests)
            {
                var requestBody = GetString(request.Content);

                Assert.True(requestBody.Contains(encodedUriString));
                Assert.False(requestBody.Contains(decodedUriString));
            }
        }

        [Test]
        [TestCase("")]
        [TestCase("en-US")]
        public async Task StartRecognizeReceiptsSendsUserSpecifiedLocale(string locale)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/receipt/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            var recognizeOptions = new RecognizeReceiptsOptions { Locale = locale };
            await client.StartRecognizeReceiptsAsync(stream, recognizeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;

            var localeQuery = "locale=";
            var index = requestUriQuery.IndexOf(localeQuery);
            var length = requestUriQuery.Length - (index + localeQuery.Length);
            Assert.AreEqual(locale, requestUriQuery.Substring(index + localeQuery.Length, length));
        }

        #endregion

        #region Recognize Business Cards
        [Test]
        public async Task StartRecognizeBusinessCardsSendsUserSpecifiedContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/businessCard/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            var recognizeOptions = new RecognizeBusinessCardsOptions { ContentType = FormContentType.Jpeg };
            await client.StartRecognizeBusinessCardsAsync(stream, recognizeOptions);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("image/jpeg", contentType);
        }

        [Test]
        public async Task StartRecognizeBusinessCardsSendsAutoDetectedContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/businessCard/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            await client.StartRecognizeBusinessCardsAsync(stream);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("image/tiff", contentType);
        }

        [Test]
        public async Task StartRecognizeBusinessCardsFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/businessCard/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var encodedUriString = "https://fakeuri.com/blank%20space";
            var decodedUriString = "https://fakeuri.com/blank space";

            await client.StartRecognizeBusinessCardsFromUriAsync(new Uri(encodedUriString));
            await client.StartRecognizeBusinessCardsFromUriAsync(new Uri(decodedUriString));

            Assert.AreEqual(2, mockTransport.Requests.Count);

            foreach (var request in mockTransport.Requests)
            {
                var requestBody = GetString(request.Content);

                Assert.True(requestBody.Contains(encodedUriString));
                Assert.False(requestBody.Contains(decodedUriString));
            }
        }

        [Test]
        [TestCase("")]
        [TestCase("en-US")]
        public async Task StartRecognizeBusinessCardsSendsUserSpecifiedLocale(string locale)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/businesscards/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            var recognizeOptions = new RecognizeReceiptsOptions { Locale = locale };
            await client.StartRecognizeReceiptsAsync(stream, recognizeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;

            var localeQuery = "locale=";
            var index = requestUriQuery.IndexOf(localeQuery);
            var length = requestUriQuery.Length - (index + localeQuery.Length);
            Assert.AreEqual(locale, requestUriQuery.Substring(index + localeQuery.Length, length));
        }

        #endregion

        #region Recognize Invoices
        [Test]
        public async Task StartRecognizesInvoicesSendsUserSpecifiedContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/invoice/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            var recognizeOptions = new RecognizeInvoicesOptions { ContentType = FormContentType.Jpeg };
            await client.StartRecognizeInvoicesAsync(stream, recognizeOptions);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("image/jpeg", contentType);
        }

        [Test]
        public async Task StartRecognizeInvoicesSendsAutoDetectedContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/invoice/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            await client.StartRecognizeInvoicesAsync(stream);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("image/tiff", contentType);
        }

        [Test]
        public async Task StartRecognizeInvoicesFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/invoice/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var encodedUriString = "https://fakeuri.com/blank%20space";
            var decodedUriString = "https://fakeuri.com/blank space";

            await client.StartRecognizeInvoicesFromUriAsync(new Uri(encodedUriString));
            await client.StartRecognizeInvoicesFromUriAsync(new Uri(decodedUriString));

            Assert.AreEqual(2, mockTransport.Requests.Count);

            foreach (var request in mockTransport.Requests)
            {
                var requestBody = GetString(request.Content);

                Assert.True(requestBody.Contains(encodedUriString));
                Assert.False(requestBody.Contains(decodedUriString));
            }
        }

        [Test]
        [TestCase("")]
        [TestCase("en-US")]
        public async Task StartRecognizeInvoicesSendsUserSpecifiedLocale(string locale)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/prebuilt/invoice/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            var recognizeOptions = new RecognizeInvoicesOptions { Locale = locale };
            await client.StartRecognizeInvoicesAsync(stream, recognizeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;

            var localeQuery = "locale=";
            var index = requestUriQuery.IndexOf(localeQuery);
            var length = requestUriQuery.Length - (index + localeQuery.Length);
            Assert.AreEqual(locale, requestUriQuery.Substring(index + localeQuery.Length, length));
        }

        #endregion

        #region Recognize Custom Forms

        [Test]
        public async Task StartRecognizeCustomFormsSendsUserSpecifiedContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/custom/models/00000000000000000000000000000000/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            var recognizeOptions = new RecognizeCustomFormsOptions { ContentType = FormContentType.Jpeg };
            await client.StartRecognizeCustomFormsAsync("00000000000000000000000000000000", stream, recognizeOptions);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("image/jpeg", contentType);
        }

        [Test]
        public async Task StartRecognizeCustomFormsSendsAutoDetectedContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/custom/models/00000000000000000000000000000000/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            await client.StartRecognizeCustomFormsAsync("00000000000000000000000000000000", stream);

            var request = mockTransport.Requests.Single();

            Assert.True(request.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("image/tiff", contentType);
        }

        [Test]
        public async Task StartRecognizeCustomFormsFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, "host/custom/models/00000000000000000000000000000000/analyzeResults/00000000000000000000000000000000"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var encodedUriString = "https://fakeuri.com/blank%20space";
            var decodedUriString = "https://fakeuri.com/blank space";

            await client.StartRecognizeCustomFormsFromUriAsync("00000000000000000000000000000000", new Uri(encodedUriString));
            await client.StartRecognizeCustomFormsFromUriAsync("00000000000000000000000000000000", new Uri(decodedUriString));

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

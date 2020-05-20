// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    public class FormRecognizerClientTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClientTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormRecognizerClientTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="FormRecognizerClient" />.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The fake <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateClient(FormRecognizerClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new FormRecognizerClientOptions();

            return new FormRecognizerClient(fakeEndpoint, fakeCredential, options);
        }

        /// <summary>
        /// Creates a fake <see cref="FormRecognizerClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateInstrumentedClient(FormRecognizerClientOptions options = default) =>
            InstrumentClient(CreateClient(options));

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheEndpoint()
        {
            var tokenCredential = new DefaultAzureCredential();
            var keyCredential = new AzureKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(null, tokenCredential));
            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(null, tokenCredential, new FormRecognizerClientOptions()));
            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(null, keyCredential));
            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(null, keyCredential, new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheTokenCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, default(TokenCredential)));
            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, default(TokenCredential), new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheAzureKeyCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, default(AzureKeyCredential)));
            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, default(AzureKeyCredential), new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheOptions()
        {
            var endpoint = new Uri("http://localhost");
            var tokenCredential = new DefaultAzureCredential();
            var keyCredential = new AzureKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, tokenCredential, null));
            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, keyCredential, null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeContentAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeContentRequiresTheFormFileStream()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartRecognizeContentAsync(null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeContentAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeContentRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var options = new RecognizeOptions { ContentType = ContentType.Pdf };

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.StartRecognizeContentAsync(stream, options, cancellationSource.Token));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeContentFromUriAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeContentFromUriRequiresTheFormFileUri()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartRecognizeContentFromUriAsync(null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeContentFromUriAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeContentFromUriRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var fakeUri = new Uri("http://localhost");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.StartRecognizeContentFromUriAsync(fakeUri, cancellationToken: cancellationSource.Token));
        }

        [Test]
        public async Task StartRecognizeContentFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "host/layout/analyzeResults/00000000000000000000000000000000"));

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

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeReceiptsAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeReceiptsRequiresTheReceiptFileStream()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartRecognizeReceiptsAsync(null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeReceiptsAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeReceiptsRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var options = new RecognizeOptions { ContentType = ContentType.Pdf };

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.StartRecognizeReceiptsAsync(stream, recognizeOptions: options, cancellationToken: cancellationSource.Token));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeReceiptsFromUriAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeReceiptsFromUriRequiresTheReceiptFileUri()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartRecognizeReceiptsFromUriAsync(null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeReceiptsFromUriAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeReceiptsFromUriRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var fakeUri = new Uri("http://localhost");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.StartRecognizeReceiptsFromUriAsync(fakeUri, cancellationToken: cancellationSource.Token));
        }

        [Test]
        public async Task StartRecognizeReceiptsFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "host/prebuilt/receipt/analyzeResults/00000000000000000000000000000000"));

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

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeCustomFormsAsync"/>
        /// method.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void StartRecognizeCustomFormsRequiresTheModelId(string modelId)
        {
            var client = CreateInstrumentedClient();
            var expectedType = modelId == null
                ? typeof(ArgumentNullException)
                : typeof(ArgumentException);

            using var stream = new MemoryStream(Array.Empty<byte>());
            var options = new RecognizeOptions { ContentType = ContentType.Jpeg };

            Assert.ThrowsAsync(expectedType, async () => await client.StartRecognizeCustomFormsAsync(modelId, stream, options));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeCustomFormsAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeCustomFormsRequiresTheFormFileStream()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartRecognizeCustomFormsAsync("00000000-0000-0000-0000-000000000000", null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeCustomFormsAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeCustomFormsValidatesTheModelIdFormat()
        {
            var client = CreateClient();
            using var stream = new MemoryStream(Array.Empty<byte>());
            var options = new RecognizeOptions { ContentType = ContentType.Jpeg };

            Assert.ThrowsAsync<ArgumentException>(async () => await client.StartRecognizeCustomFormsAsync("1975-04-04", stream, options));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeCustomFormsAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeCustomFormsRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var options = new RecognizeOptions { ContentType = ContentType.Pdf };

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.StartRecognizeCustomFormsAsync("00000000-0000-0000-0000-000000000000", stream, recognizeOptions: options, cancellationToken: cancellationSource.Token));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeCustomFormsFromUriAsync"/>
        /// method.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void StartRecognizeCustomFormsFromUriRequiresTheModelId(string modelId)
        {
            var client = CreateInstrumentedClient();
            var expectedType = modelId == null
                ? typeof(ArgumentNullException)
                : typeof(ArgumentException);

            var uri = new Uri("https://tobeornot.to.be");

            Assert.ThrowsAsync(expectedType, async () => await client.StartRecognizeCustomFormsFromUriAsync(modelId, uri));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeCustomFormsFromUriAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeCustomFormsFromUriRequiresTheFormFileUri()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartRecognizeCustomFormsFromUriAsync("00000000-0000-0000-0000-000000000000", null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeCustomFormsFromUriAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeCustomFormsFromUriValidatesTheModelIdFormat()
        {
            var client = CreateClient();
            var uri = new Uri("https://thatistheques.ti.on");

            Assert.ThrowsAsync<ArgumentException>(async () => await client.StartRecognizeCustomFormsFromUriAsync("1975-04-04", uri));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient.StartRecognizeCustomFormsFromUriAsync"/>
        /// method.
        /// </summary>
        [Test]
        public void StartRecognizeCustomFormsFromUriRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var fakeUri = new Uri("http://localhost");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.StartRecognizeCustomFormsFromUriAsync("00000000-0000-0000-0000-000000000000", fakeUri, cancellationToken: cancellationSource.Token));
        }

        [Test]
        public async Task StartRecognizeCustomFormsFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "host/custom/models/00000000000000000000000000000000/analyzeResults/00000000000000000000000000000000"));

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

        private static string GetString(RequestContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}

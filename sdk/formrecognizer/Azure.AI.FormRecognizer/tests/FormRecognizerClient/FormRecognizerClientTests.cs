// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
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
        public FormRecognizerClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="FormRecognizerClient" />.
        /// </summary>
        /// <returns>The fake <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new AzureKeyCredential("fakeKey");

            return new FormRecognizerClient(fakeEndpoint, fakeCredential);
        }

        /// <summary>
        /// Creates a fake <see cref="FormRecognizerClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateInstrumentedClient() => InstrumentClient(CreateClient());

        #region client
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

        [Test]
        public async Task FormRecognizerClientThrowsWithNonExistingResourceEndpoint()
        {
            var client = CreateInstrumentedClient();

            try
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);
                await client.StartRecognizeContentFromUriAsync(uri);
            }
            catch (AggregateException ex)
            {
                var innerExceptions = ex.InnerExceptions.ToList();
                Assert.IsTrue(innerExceptions.All(ex => ex is RequestFailedException));
            }
        }

        #endregion

        #region Recognize Content

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
            var options = new RecognizeContentOptions { ContentType = FormContentType.Pdf };

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartRecognizeContentAsync(stream, options, cancellationSource.Token));
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

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartRecognizeContentFromUriAsync(fakeUri, cancellationToken: cancellationSource.Token));
        }

        #endregion

        #region Recognize Receipt

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
            var options = new RecognizeReceiptsOptions { ContentType = FormContentType.Pdf };

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartRecognizeReceiptsAsync(stream, recognizeReceiptsOptions: options, cancellationToken: cancellationSource.Token));
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

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartRecognizeReceiptsFromUriAsync(fakeUri, cancellationToken: cancellationSource.Token));
        }

        #endregion

        #region Recognize Business Cards

        [Test]
        public void StartRecognizeBusinessCardsRequiresTheFileStream()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartRecognizeBusinessCardsAsync(null));
        }

        [Test]
        public void StartRecognizeBusinessCardsRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var options = new RecognizeBusinessCardsOptions { ContentType = FormContentType.Pdf };

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartRecognizeBusinessCardsAsync(stream, recognizeBusinessCardsOptions: options, cancellationToken: cancellationSource.Token));
        }

        [Test]
        public void StartRecognizeBusinessCardsFromUriRequiresTheFileUri()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartRecognizeBusinessCardsFromUriAsync(null));
        }

        [Test]
        public void StartRecognizeBusinessCardsFromUriRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var fakeUri = new Uri("http://localhost");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartRecognizeBusinessCardsFromUriAsync(fakeUri, cancellationToken: cancellationSource.Token));
        }

        #endregion

        #region Recognize Invoices

        [Test]
        public void StartRecognizeInvoicesRequiresTheFileStream()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartRecognizeInvoicesAsync(null));
        }

        [Test]
        public void StartRecognizeInvoicesRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var options = new RecognizeInvoicesOptions { ContentType = FormContentType.Pdf };

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartRecognizeInvoicesAsync(stream, recognizeInvoicesOptions: options, cancellationToken: cancellationSource.Token));
        }

        [Test]
        public void StartRecognizeInvoicesFromUriRequiresTheFileUri()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartRecognizeInvoicesFromUriAsync(null));
        }

        [Test]
        public void StartRecognizeInvoicesFromUriRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var fakeUri = new Uri("http://localhost");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartRecognizeInvoicesFromUriAsync(fakeUri, cancellationToken: cancellationSource.Token));
        }

        #endregion

        #region Recognize Custom Forms

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
            var options = new RecognizeCustomFormsOptions { ContentType = FormContentType.Jpeg };

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
            var options = new RecognizeCustomFormsOptions { ContentType = FormContentType.Jpeg };

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
            var options = new RecognizeCustomFormsOptions { ContentType = FormContentType.Pdf };

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartRecognizeCustomFormsAsync("00000000-0000-0000-0000-000000000000", stream, recognizeCustomFormsOptions: options, cancellationToken: cancellationSource.Token));
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

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartRecognizeCustomFormsFromUriAsync("00000000-0000-0000-0000-000000000000", fakeUri, cancellationToken: cancellationSource.Token));
        }

        #endregion
    }
}

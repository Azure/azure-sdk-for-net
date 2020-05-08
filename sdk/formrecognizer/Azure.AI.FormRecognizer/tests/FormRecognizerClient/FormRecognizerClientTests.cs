﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core.TestFramework;
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
        /// <returns>The fake <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateClient()
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");

            return new FormRecognizerClient(fakeEndpoint, fakeCredential);
        }

        /// <summary>
        /// Creates a fake <see cref="FormRecognizerClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateInstrumentedClient() => InstrumentClient(CreateClient());

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheEndpoint()
        {
            var credential = new AzureKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(null, credential));
            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(null, credential, new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, null));
            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, null, new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormRecognizerClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheOptions()
        {
            var endpoint = new Uri("http://localhost");
            var credential = new AzureKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, credential, null));
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
    }
}

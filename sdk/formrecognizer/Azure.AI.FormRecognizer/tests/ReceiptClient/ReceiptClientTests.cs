// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="ReceiptClient"/> class.
    /// </summary>
    public class ReceiptClientTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptClientTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ReceiptClientTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient"/> constructors.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void ConstructorRequiresTheEndpoint()
        {
            var credential = new FormRecognizerApiKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new ReceiptClient(null, credential));
            Assert.Throws<ArgumentNullException>(() => new ReceiptClient(null, credential, new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient"/> constructors.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void ConstructorRequiresTheCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new ReceiptClient(endpoint, null));
            Assert.Throws<ArgumentNullException>(() => new ReceiptClient(endpoint, null, new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient"/> constructors.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void ConstructorRequiresTheOptions()
        {
            var endpoint = new Uri("http://localhost");
            var credential = new FormRecognizerApiKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new ReceiptClient(endpoint, credential, null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient.StartExtractReceiptsAsync(Stream, ContentType, bool, CancellationToken)"/>
        /// method.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void StartExtractReceiptsWithStreamRequiresTheStream()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartExtractReceiptsAsync(null, ContentType.Jpeg));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient.StartExtractReceiptsAsync(Stream, ContentType, bool, CancellationToken)"/>
        /// method.
        /// </summary>
        [Test]
        public void StartExtractReceiptsWithStreamRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.StartExtractReceiptsAsync(stream, ContentType.Jpeg, cancellationToken: cancellationSource.Token));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient.StartExtractReceiptsAsync(Uri, bool, CancellationToken)"/>
        /// method.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void StartExtractReceiptsWithEndpointRequiresTheUri()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartExtractReceiptsAsync(null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient.StartExtractReceiptsAsync(Uri, bool, CancellationToken)"/>
        /// method.
        /// </summary>
        [Test]
        public void StartExtractReceiptsWithEndpointRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var fakeEndpoint = new Uri("http://localhost");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.StartExtractReceiptsAsync(fakeEndpoint, cancellationToken: cancellationSource.Token));
        }

        /// <summary>
        /// Creates a fake <see cref="ReceiptClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="ReceiptClient" />.</returns>
        private ReceiptClient CreateInstrumentedClient()
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new FormRecognizerApiKeyCredential("fakeKey");
            var client = new ReceiptClient(fakeEndpoint, fakeCredential);

            return InstrumentClient(client);
        }
    }
}

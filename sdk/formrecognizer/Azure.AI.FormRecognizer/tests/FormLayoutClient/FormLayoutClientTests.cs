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
    /// The suite of tests for the <see cref="FormLayoutClient"/> class.
    /// </summary>
    public class FormLayoutClientTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormLayoutClientTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormLayoutClientTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormLayoutClient"/> constructors.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void ConstructorRequiresTheEndpoint()
        {
            var credential = new AzureKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new FormLayoutClient(null, credential));
            Assert.Throws<ArgumentNullException>(() => new FormLayoutClient(null, credential, new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormLayoutClient"/> constructors.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void ConstructorRequiresTheCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new FormLayoutClient(endpoint, null));
            Assert.Throws<ArgumentNullException>(() => new FormLayoutClient(endpoint, null, new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormLayoutClient"/> constructors.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void ConstructorRequiresTheOptions()
        {
            var endpoint = new Uri("http://localhost");
            var credential = new AzureKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new FormLayoutClient(endpoint, credential, null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormLayoutClient.StartExtractLayoutsAsync(Stream, ContentType, CancellationToken)"/>
        /// method.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void StartExtractLayoutsWithStreamRequiresTheStream()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartExtractLayoutsAsync(null, ContentType.Jpeg));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormLayoutClient.StartExtractLayoutsAsync(Stream, ContentType, CancellationToken)"/>
        /// method.
        /// </summary>
        [Test]
        public void StartExtractLayoutsWithStreamRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.StartExtractLayoutsAsync(stream, ContentType.Jpeg, cancellationSource.Token));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormLayoutClient.StartExtractLayoutsAsync(Uri, CancellationToken)"/>
        /// method.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void StartExtractLayoutsWithUriRequiresTheUri()
        {
            var client = CreateInstrumentedClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartExtractLayoutsAsync(null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormLayoutClient.StartExtractLayoutsAsync(Uri, CancellationToken)"/>
        /// method.
        /// </summary>
        [Test]
        public void StartExtractReceiptsWithUriRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var fakeUri = new Uri("http://localhost");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.StartExtractLayoutsAsync(fakeUri, cancellationSource.Token));
        }

        /// <summary>
        /// Creates a fake <see cref="FormLayoutClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormLayoutClient" />.</returns>
        private FormLayoutClient CreateInstrumentedClient()
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            var client = new FormLayoutClient(fakeEndpoint, fakeCredential);

            return InstrumentClient(client);
        }
    }
}

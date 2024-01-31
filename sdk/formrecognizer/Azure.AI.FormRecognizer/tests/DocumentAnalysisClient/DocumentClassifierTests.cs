// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the document classifier methods in the <see cref="DocumentAnalysisClient"/> class.
    /// </summary>
    internal class DocumentClassifierTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentClassifierTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentClassifierTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void ClassifyDocumentValidatesArguments()
        {
            var client = CreateInstrumentedClient();
            using var document = new MemoryStream();

            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.ClassifyDocumentAsync(WaitUntil.Started, classifierId: null, document));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.ClassifyDocumentAsync(WaitUntil.Started, classifierId: string.Empty, document));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.ClassifyDocumentAsync(WaitUntil.Started, "classifierId", document: null));

            Assert.Throws<ArgumentNullException>(() => client.ClassifyDocument(WaitUntil.Started, classifierId: null, document));
            Assert.Throws<ArgumentException>(() => client.ClassifyDocument(WaitUntil.Started, classifierId: string.Empty, document));
            Assert.Throws<ArgumentNullException>(() => client.ClassifyDocument(WaitUntil.Started, "classifierId", document: null));
        }

        [Test]
        public void ClassifyDocumentHonorsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            using var document1 = new MemoryStream();
            using var document2 = new MemoryStream(); // The first stream is closed after the first method call.
            using var cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.ClassifyDocumentAsync(WaitUntil.Started, "classifierId", document1, cancellationSource.Token));
            Assert.Throws<TaskCanceledException>(() => client.ClassifyDocument(WaitUntil.Started, "classifierId", document2, cancellationSource.Token));
        }

        [Test]
        public void ClassifyDocumentFromUriValidatesArguments()
        {
            var client = CreateInstrumentedClient();
            var documentUri = new Uri("http://notreal.azure.com/");

            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.ClassifyDocumentFromUriAsync(WaitUntil.Started, classifierId: null, documentUri));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.ClassifyDocumentFromUriAsync(WaitUntil.Started, classifierId: string.Empty, documentUri));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.ClassifyDocumentFromUriAsync(WaitUntil.Started, "classifierId", documentUri: null));

            Assert.Throws<ArgumentNullException>(() => client.ClassifyDocumentFromUri(WaitUntil.Started, classifierId: null, documentUri));
            Assert.Throws<ArgumentException>(() => client.ClassifyDocumentFromUri(WaitUntil.Started, classifierId: string.Empty, documentUri));
            Assert.Throws<ArgumentNullException>(() => client.ClassifyDocumentFromUri(WaitUntil.Started, "classifierId", documentUri: null));
        }

        [Test]
        public void ClassifyDocumentFromUriHonorsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var documentUri = new Uri("http://notreal.azure.com/");
            using var cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.ClassifyDocumentFromUriAsync(WaitUntil.Started, "classifierId", documentUri, cancellationSource.Token));
            Assert.Throws<TaskCanceledException>(() => client.ClassifyDocumentFromUri(WaitUntil.Started, "classifierId", documentUri, cancellationSource.Token));
        }

        /// <summary>
        /// Creates a fake <see cref="DocumentAnalysisClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="DocumentAnalysisClient" />.</returns>
        private DocumentAnalysisClient CreateInstrumentedClient(DocumentAnalysisClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com/");
            var fakeCredential = new AzureKeyCredential("fakeKey");

            options ??= new DocumentAnalysisClientOptions() { Retry = { Delay = TimeSpan.Zero, Mode = RetryMode.Fixed } };
            var client = new DocumentAnalysisClient(fakeEndpoint, fakeCredential, options);

            return client;
        }
    }
}

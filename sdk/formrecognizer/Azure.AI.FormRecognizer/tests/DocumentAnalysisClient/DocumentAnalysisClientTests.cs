// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="DocumentAnalysisClient"/> class.
    /// </summary>
    public class DocumentAnalysisClientTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClientTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentAnalysisClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="DocumentAnalysisClient" />.
        /// </summary>
        /// <returns>The fake <see cref="DocumentAnalysisClient" />.</returns>
        private DocumentAnalysisClient CreateClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new AzureKeyCredential("fakeKey");

            return new DocumentAnalysisClient(fakeEndpoint, fakeCredential, new DocumentAnalysisClientOptions(){ Retry = { Delay = TimeSpan.Zero, Mode = RetryMode.Fixed}});
        }

        /// <summary>
        /// Creates a fake <see cref="DocumentAnalysisClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="DocumentAnalysisClient" />.</returns>
        private DocumentAnalysisClient CreateInstrumentedClient() => InstrumentClient(CreateClient());

        #region Client

        /// <summary>
        /// Verifies functionality of the <see cref="DocumentAnalysisClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheEndpoint()
        {
            var tokenCredential = new DefaultAzureCredential();
            var keyCredential = new AzureKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new DocumentAnalysisClient(null, tokenCredential));
            Assert.Throws<ArgumentNullException>(() => new DocumentAnalysisClient(null, tokenCredential, new DocumentAnalysisClientOptions()));
            Assert.Throws<ArgumentNullException>(() => new DocumentAnalysisClient(null, keyCredential));
            Assert.Throws<ArgumentNullException>(() => new DocumentAnalysisClient(null, keyCredential, new DocumentAnalysisClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="DocumentAnalysisClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheTokenCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new DocumentAnalysisClient(endpoint, default(TokenCredential)));
            Assert.Throws<ArgumentNullException>(() => new DocumentAnalysisClient(endpoint, default(TokenCredential), new DocumentAnalysisClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="DocumentAnalysisClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheAzureKeyCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new DocumentAnalysisClient(endpoint, default(AzureKeyCredential)));
            Assert.Throws<ArgumentNullException>(() => new DocumentAnalysisClient(endpoint, default(AzureKeyCredential), new DocumentAnalysisClientOptions()));
        }

        [Test]
        public async Task DocumentAnalysisClientThrowsWithNonExistingResourceEndpoint()
        {
            var client = CreateInstrumentedClient();

            try
            {
                using var stream = new MemoryStream(Array.Empty<byte>());
                await client.StartAnalyzeDocumentAsync("modelId", stream);
            }
            catch (AggregateException ex)
            {
                var innerExceptions = ex.InnerExceptions.ToList();
                Assert.IsTrue(innerExceptions.All(ex => ex is RequestFailedException));
            }
        }

        #endregion

        #region Analyze Document

        /// <summary>
        /// Verifies functionality of the <see cref="DocumentAnalysisClient.StartAnalyzeDocument"/>
        /// method.
        /// </summary>
        [Test]
        public void StartAnalyzeDocumentArgumentValidation()
        {
            var client = CreateInstrumentedClient();

            using var stream = new MemoryStream(Array.Empty<byte>());
            var options = new AnalyzeDocumentOptions();

            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartAnalyzeDocumentAsync(null, stream, options));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.StartAnalyzeDocumentAsync("", stream, options));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartAnalyzeDocumentAsync("modelId", null, options));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="DocumentAnalysisClient.StartAnalyzeDocument"/>
        /// method.
        /// </summary>
        [Test]
        public void StartAnalyzeDocumentRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var options = new AnalyzeDocumentOptions();

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartAnalyzeDocumentAsync("modelId", stream, options, cancellationSource.Token));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="DocumentAnalysisClient.StartAnalyzeDocumentFromUri"/>
        /// method.
        /// </summary>
        [Test]
        public void StartAnalyzeDocumentFromUriArgumentValidation()
        {
            var client = CreateInstrumentedClient();

            var fakeUri = new Uri("http://localhost");
            var options = new AnalyzeDocumentOptions();

            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartAnalyzeDocumentFromUriAsync(null, fakeUri, options));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.StartAnalyzeDocumentFromUriAsync("", fakeUri, options));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.StartAnalyzeDocumentFromUriAsync("modelId", null, options));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="DocumentAnalysisClient.StartAnalyzeDocumentFromUri"/>
        /// method.
        /// </summary>
        [Test]
        public void StartAnalyzeDocumentFromUriRespectsTheCancellationToken()
        {
            var client = CreateInstrumentedClient();
            var options = new AnalyzeDocumentOptions();

            var fakeUri = new Uri("http://localhost");
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<OperationCanceledException>(), async () => await client.StartAnalyzeDocumentFromUriAsync("modelId", fakeUri, options, cancellationSource.Token));
        }

        #endregion
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the document classifier methods in the <see cref="DocumentModelAdministrationClient"/> class.
    /// </summary>
    internal class DocumentClassifierAdministrationTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentModelAdministrationClientTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentClassifierAdministrationTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void BuildDocumentClassifierValidatesArguments()
        {
            var client = CreateInstrumentedClient();
            var emptyDocumentTypes = new Dictionary<string, ClassifierDocumentTypeDetails>();

            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.BuildDocumentClassifierAsync(WaitUntil.Started, documentTypes: null));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.BuildDocumentClassifierAsync(WaitUntil.Started, emptyDocumentTypes));

            Assert.Throws<ArgumentNullException>(() => client.BuildDocumentClassifier(WaitUntil.Started, documentTypes: null));
            Assert.Throws<ArgumentException>(() => client.BuildDocumentClassifier(WaitUntil.Started, emptyDocumentTypes));
        }

        [Test]
        public void DeleteDocumentClassifierValidatesArguments()
        {
            var client = CreateInstrumentedClient();

            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.DeleteDocumentClassifierAsync(classifierId: null));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.DeleteDocumentClassifierAsync(classifierId: string.Empty));

            Assert.Throws<ArgumentNullException>(() => client.DeleteDocumentClassifier(classifierId: null));
            Assert.Throws<ArgumentException>(() => client.DeleteDocumentClassifier(classifierId: string.Empty));
        }

        /// <summary>
        /// Creates a fake <see cref="DocumentModelAdministrationClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="DocumentModelAdministrationClient" />.</returns>
        private DocumentModelAdministrationClient CreateInstrumentedClient(DocumentAnalysisClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com/");
            var fakeCredential = new AzureKeyCredential("fakeKey");

            options ??= new DocumentAnalysisClientOptions() { Retry = { Delay = TimeSpan.Zero, Mode = RetryMode.Fixed } };
            var client = new DocumentModelAdministrationClient(fakeEndpoint, fakeCredential, options);

            return client;
        }
    }
}

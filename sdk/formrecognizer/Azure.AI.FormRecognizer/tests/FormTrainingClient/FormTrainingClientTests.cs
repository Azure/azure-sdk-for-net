// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FormTrainingClientTests"/> class.
    /// </summary>
    public class FormTrainingClientTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClientTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormTrainingClientTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="FormTrainingClient" /> to be used for non-live testing.
        /// </summary>
        /// <param name="instrumentClient">Whether or not to instrument the client to make use of the Azure Core Test Framework functionalities.</param>
        /// <returns>The fake <see cref="FormTrainingClient" />.</returns>
        private FormTrainingClient CreateFormTrainingClient(bool instrumentClient = true)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            var client = new FormTrainingClient(fakeEndpoint, fakeCredential);

            return instrumentClient
                ? InstrumentClient(client)
                : client;
        }

        [Test]
        public void CreateClientArgumentValidation()
        {
            var uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new FormTrainingClient(null, new AzureKeyCredential("apiKey")));
            Assert.Throws<ArgumentNullException>(() => new FormTrainingClient(uri, null));
            Assert.Throws<ArgumentNullException>(() => new FormTrainingClient(uri, new AzureKeyCredential("apiKey"), null));
        }

        [Test]
        public void StartTrainingArgumentValidation()
        {
            FormTrainingClient client = CreateFormTrainingClient();

            Assert.ThrowsAsync<UriFormatException>(() => client.StartTrainingAsync(new Uri(string.Empty)));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.StartTrainingAsync((Uri)null));
        }

        [Test]
        public void GetCustomModelArgumentValidation()
        {
            FormTrainingClient client = CreateFormTrainingClient();

            Assert.ThrowsAsync<ArgumentNullException>(() => client.GetCustomModelAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => client.GetCustomModelAsync(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.GetCustomModelAsync("1975-04-04"));
        }

        [Test]
        public void DeleteModelArgumentValidation()
        {
            FormTrainingClient client = CreateFormTrainingClient();

            Assert.ThrowsAsync<ArgumentNullException>(() => client.DeleteModelAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => client.DeleteModelAsync(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.DeleteModelAsync("1975-04-04"));
        }

        [Test]
        public void CreateFormRecognizerClientFromFormTrainingClient()
        {
            // Skip client instrumentation because it makes ServiceClient = null.

            FormTrainingClient trainingClient = CreateFormTrainingClient(instrumentClient: false);
            FormRecognizerClient formRecognizerClient = trainingClient.GetFormRecognizerClient();

            Assert.IsNotNull(formRecognizerClient);
            Assert.IsNotNull(formRecognizerClient.Diagnostics);
            Assert.AreEqual(trainingClient.ServiceClient, formRecognizerClient.ServiceClient);
        }
    }
}

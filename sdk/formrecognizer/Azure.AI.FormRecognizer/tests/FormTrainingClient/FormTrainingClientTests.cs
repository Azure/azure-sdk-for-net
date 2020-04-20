// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.Testing;
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
        /// Creates a fake <see cref="FormTrainingClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormTrainingClient" />.</returns>
        private FormTrainingClient CreateInstrumentedClient()
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            var client = new FormTrainingClient(fakeEndpoint, fakeCredential);

            return InstrumentClient(client);
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
            FormTrainingClient client = CreateInstrumentedClient();

            Assert.ThrowsAsync<UriFormatException>(() => client.StartTrainingAsync(new Uri(string.Empty)));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.StartTrainingAsync((Uri)null));
        }

        [Test]
        public void GetCustomModelArgumentValidation()
        {
            FormTrainingClient client = CreateInstrumentedClient();

            Assert.ThrowsAsync<ArgumentNullException>(() => client.GetCustomModelAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => client.GetCustomModelAsync(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.GetCustomModelAsync("1975-04-04"));
        }

        [Test]
        public void DeleteModelArgumentValidation()
        {
            FormTrainingClient client = CreateInstrumentedClient();

            Assert.ThrowsAsync<ArgumentNullException>(() => client.DeleteModelAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => client.DeleteModelAsync(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.DeleteModelAsync("1975-04-04"));
        }
    }
}

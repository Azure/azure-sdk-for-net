﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
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
        public FormTrainingClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="FormTrainingClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormTrainingClient" />.</returns>
        private FormTrainingClient CreateInstrumentedClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com/");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            var client = new FormTrainingClient(fakeEndpoint, fakeCredential);

            return InstrumentClient(client);
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormTrainingClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheEndpoint()
        {
            var tokenCredential = new DefaultAzureCredential();
            var keyCredential = new AzureKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new FormTrainingClient(null, tokenCredential));
            Assert.Throws<ArgumentNullException>(() => new FormTrainingClient(null, tokenCredential, new FormRecognizerClientOptions()));
            Assert.Throws<ArgumentNullException>(() => new FormTrainingClient(null, keyCredential));
            Assert.Throws<ArgumentNullException>(() => new FormTrainingClient(null, keyCredential, new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormTrainingClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheTokenCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new FormTrainingClient(endpoint, default(TokenCredential)));
            Assert.Throws<ArgumentNullException>(() => new FormTrainingClient(endpoint, default(TokenCredential), new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormTrainingClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheAzureKeyCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, default(AzureKeyCredential)));
            Assert.Throws<ArgumentNullException>(() => new FormRecognizerClient(endpoint, default(AzureKeyCredential), new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="FormTrainingClient"/> constructors.
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
        public async Task FormTrainingClientThrowsWithNonExistingResourceEndpoint()
        {
            var client = CreateInstrumentedClient();

            try
            {
                await client.GetAccountPropertiesAsync();
            }
            catch (AggregateException ex)
            {
                var innerExceptions = ex.InnerExceptions.ToList();
                Assert.IsTrue(innerExceptions.All(ex => ex is RequestFailedException));
            }
        }

        [Test]
        public void StartTrainingArgumentValidation()
        {
            FormTrainingClient client = CreateInstrumentedClient();

            Assert.ThrowsAsync<UriFormatException>(() => client.StartTrainingAsync(new Uri(string.Empty), useTrainingLabels: false));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.StartTrainingAsync((Uri)null, useTrainingLabels: false));
        }

        [Test]
        public void StartCreateComposedModelArgumentValidation()
        {
            FormTrainingClient client = CreateInstrumentedClient();

            Assert.ThrowsAsync<ArgumentNullException>(() => client.StartCreateComposedModelAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => client.StartCreateComposedModelAsync(new List<string>() { string.Empty }));
            Assert.ThrowsAsync<ArgumentException>(() => client.StartCreateComposedModelAsync(new List<string>() { "1975-04-04" }));
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

        [Test]
        public void CreateFormRecognizerClientFromFormTrainingClient()
        {
            FormTrainingClient trainingClient = new FormTrainingClient(new Uri("http://localhost"), new AzureKeyCredential("key"));
            FormRecognizerClient formRecognizerClient = trainingClient.GetFormRecognizerClient();

            Assert.IsNotNull(formRecognizerClient);
            Assert.IsNotNull(formRecognizerClient.Diagnostics);
            Assert.IsNotNull(formRecognizerClient.ServiceClient);
        }

        [Test]
        public void StartCopyModelArgumentValidation()
        {
            FormTrainingClient client = CreateInstrumentedClient();
            var copyAuth = new CopyAuthorization("<modelId>", "<accesstoken>", default, "<resourceId>", "<region>");

            Assert.ThrowsAsync<ArgumentNullException>(() => client.StartCopyModelAsync(null, copyAuth));
            Assert.ThrowsAsync<ArgumentException>(() => client.StartCopyModelAsync(string.Empty, copyAuth));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.StartCopyModelAsync("<modelId>", default));
            Assert.ThrowsAsync<ArgumentException>(() => client.StartCopyModelAsync("1975-04-04", copyAuth));
        }

        [Test]
        public void GetCopyAuthorizationArgumentValidation()
        {
            FormTrainingClient client = CreateInstrumentedClient();
            var text = "text";

            Assert.ThrowsAsync<ArgumentNullException>(() => client.GetCopyAuthorizationAsync(null, text));
            Assert.ThrowsAsync<ArgumentException>(() => client.GetCopyAuthorizationAsync(string.Empty, text));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.GetCopyAuthorizationAsync(text, null));
            Assert.ThrowsAsync<ArgumentException>(() => client.GetCopyAuthorizationAsync(text, string.Empty));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translator.DocumentTranslation.Tests
{
    public class DocumentTranslationClientTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationClientTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentTranslationClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        #region client
        /// <summary>
        /// Verifies functionality of the <see cref="DocumentTranslationClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheEndpoint()
        {
            var keyCredential = new AzureKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new DocumentTranslationClient(null, keyCredential));
            Assert.Throws<ArgumentNullException>(() => new DocumentTranslationClient(null, keyCredential, new DocumentTranslationClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="DocumentTranslationClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheAzureKeyCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new DocumentTranslationClient(endpoint, default(AzureKeyCredential)));
            Assert.Throws<ArgumentNullException>(() => new DocumentTranslationClient(endpoint, default(AzureKeyCredential), new DocumentTranslationClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="DocumentTranslationClient"/> constructors.
        /// </summary>
        [Test]
        public void ConstructorRequiresTheOptions()
        {
            var endpoint = new Uri("http://localhost");
            var keyCredential = new AzureKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new DocumentTranslationClient(endpoint, keyCredential, null));
        }

        #endregion
    }
}

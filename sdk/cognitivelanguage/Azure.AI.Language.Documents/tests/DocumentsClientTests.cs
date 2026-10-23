// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Documents.Tests
{
    public class DocumentsClientTests
    {
        [Test]
        public void DocumentsClientEndpointNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new DocumentsServiceClient(null, new AzureKeyCredential("test-key")));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void DocumentsClientCredentialNull()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new DocumentsServiceClient(endpoint, (AzureKeyCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }

        [Test]
        public void DocumentsClientEndpointNullUsingTokenCredential()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new DocumentsServiceClient(null, new MockCredential()));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void DocumentsClientCredentialNullUsingTokenCredential()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new DocumentsServiceClient(endpoint, (TokenCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationsClientTests
    {
        [Test]
        public void ConversationsClientEndpointNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(null, (AzureKeyCredential)null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void ConversationsClientCredentialNull()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(endpoint, (AzureKeyCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }

        [Test]
        public void ConversationsClientEndpointNullUsingTokenCredential()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(null, (TokenCredential)null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void ConversationsClientCredentialNullUsingTokenCredential()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(endpoint, (TokenCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }
    }
}

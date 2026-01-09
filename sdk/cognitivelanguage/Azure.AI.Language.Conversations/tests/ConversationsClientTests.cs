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
            Assert.That(ex.ParamName, Is.EqualTo("endpoint"));
        }

        [Test]
        public void ConversationsClientCredentialNull()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(endpoint, (AzureKeyCredential)null));
            Assert.That(ex.ParamName, Is.EqualTo("credential"));
        }

        [Test]
        public void ConversationsClientEndpointNullUsingTokenCredential()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(null, (TokenCredential)null));
            Assert.That(ex.ParamName, Is.EqualTo("endpoint"));
        }

        [Test]
        public void ConversationsClientCredentialNullUsingTokenCredential()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(endpoint, (TokenCredential)null));
            Assert.That(ex.ParamName, Is.EqualTo("credential"));
        }
    }
}

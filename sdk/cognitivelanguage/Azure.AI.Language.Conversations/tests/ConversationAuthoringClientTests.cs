// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAuthoringClientTests
    {
        [Test]
        public void ConversationAuthoringClientEndpointNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAuthoringClient(null, (AzureKeyCredential)null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void ConversationAuthoringClientCredentialNull()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAuthoringClient(endpoint, (AzureKeyCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }

        [Test]
        public void ConversationAuthoringClientEndpointNullUsingTokenCredential()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAuthoringClient(null, (TokenCredential)null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void ConversationAuthoringClientCredentialNullUsingTokenCredential()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAuthoringClient(endpoint, (TokenCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }
    }
}

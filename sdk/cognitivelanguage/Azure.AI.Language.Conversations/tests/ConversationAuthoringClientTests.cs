// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.Conversations.Authoring;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAuthoringClientTests
    {
        [Test]
        public void ConversationAuthoringClientEndpointNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAuthoringClient(null, null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void ConversationAuthoringClientCredentialNull()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAuthoringClient(endpoint, null));
            Assert.AreEqual("credential", ex.ParamName);
        }
    }
}

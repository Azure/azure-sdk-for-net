// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAnalysisClientTests
    {
        public Uri Endpoint => new("https://test.api.cognitive.microsoft.com", UriKind.Absolute);

        public ConversationAnalysisClient Client => new(Endpoint, new AzureKeyCredential("test"));

        [Test]
        public void ConversationAnalysisClientEndpointNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(null, null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void ConversationAnalysisClientCredentialNull()
        {
            Uri endpoint = new("https://test.api.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(endpoint, null));
            Assert.AreEqual("credential", ex.ParamName);
        }
    }
}

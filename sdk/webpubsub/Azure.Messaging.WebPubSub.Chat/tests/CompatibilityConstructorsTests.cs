// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Chat.Tests
{
    [TestFixture]
    public class CompatibilityConstructorsTests
    {
        [Test]
        public void PreviouslyRequiredMessageConstructorInitializesValues()
        {
            var content = new WebPubSubChatMessageContent
            {
                Text = "message"
            };
            var message = new WebPubSubChatMessage("user-id", content);

            Assert.That(message.CreatedBy, Is.EqualTo("user-id"));
            Assert.That(message.Content, Is.SameAs(content));
        }
    }
}

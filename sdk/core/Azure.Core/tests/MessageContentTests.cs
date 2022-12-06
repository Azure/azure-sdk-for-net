// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class MessageContentTests
    {
        [Test]
        public void CanCreateMessageContent()
        {
            var messageContent = new MessageContent
            {
                ContentType = ContentType.ApplicationJson,
                Data = new BinaryData("data")
            };

            Assert.AreEqual(ContentType.ApplicationJson, messageContent.ContentType);
            Assert.AreEqual("data", messageContent.Data.ToString());
            Assert.IsFalse(messageContent.IsReadOnly);
        }

        [Test]
        public void CanUseDerivedMessageContent()
        {
            var messageContent = new DerivedMessageContent
            {
                Data = new BinaryData("data")
            };

            // we can cast to base type to use the ContentType struct property
            ((MessageContent) messageContent).ContentType = ContentType.ApplicationJson;

            Assert.AreEqual(ContentType.ApplicationJson, messageContent.ContentType);
            Assert.AreEqual("data", messageContent.Data.ToString());

            // we can also use the derived type string property
            messageContent.ContentType = ContentType.ApplicationJson.ToString();
            Assert.AreEqual(ContentType.ApplicationJson, messageContent.ContentType);

            Assert.IsTrue(messageContent.IsReadOnly);
        }
    }

#pragma warning disable SA1402
    internal class DerivedMessageContent : MessageContent
#pragma warning restore SA1402
    {
        public new string ContentType { get; set; }

        protected override ContentType? ContentTypeCore
        {
            get => new ContentType(ContentType);
            set => ContentType = value.ToString();
        }

        public override bool IsReadOnly => true;
    }
}
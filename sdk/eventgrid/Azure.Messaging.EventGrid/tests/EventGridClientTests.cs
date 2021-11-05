// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridClientTests
    {
        [Test]
        public void ConstructorValidatesUriNotNull()
        {
            Assert.That(
                () => new EventGridPublisherClient(null, new AzureKeyCredential("credential")),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                () => new EventGridPublisherClient(null, new AzureSasCredential("credential")),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ConstructorValidatesKeyNotNull()
        {
            Assert.That(
                () => new EventGridPublisherClient(new Uri("http://localHost"), (AzureKeyCredential)null),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                () => new EventGridPublisherClient(new Uri("http://localHost"), (AzureSasCredential)null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CannotPublishEventGridEventWithNonJsonData()
        {
            EventGridPublisherClient client =
                new EventGridPublisherClient(
                    new Uri("http://localHost"),
                    new AzureKeyCredential("fakeKey"));

            var egEvent = new EventGridEvent(
                $"Subject",
                "Microsoft.MockPublisher.TestEvent",
                "1.0",
                new BinaryData(new byte[] { 1, 2, 3, 4 }));

            Assert.That(
                async () => await client.SendEventAsync(egEvent),
                Throws.InstanceOf<JsonException>());
        }

        [Test]
        public void CannotPublishCustomEventWithNonJsonData()
        {
            EventGridPublisherClient client =
                new EventGridPublisherClient(
                    new Uri("http://localHost"),
                    new AzureKeyCredential("fakeKey"));

            var customEvent = new BinaryData(new byte[] { 1, 2, 3, 4 });

            Assert.That(
                async () => await client.SendEventAsync(customEvent),
                Throws.InstanceOf<JsonException>());
        }
    }
}

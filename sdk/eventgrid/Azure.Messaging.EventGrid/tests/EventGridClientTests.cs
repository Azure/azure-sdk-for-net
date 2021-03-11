// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    }
}

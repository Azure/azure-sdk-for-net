// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridClientUnitTests : ClientTestBase
    {
        public EventGridClientUnitTests(bool async) : base(async)
        {
        }

        [Test]
        public void MustSetKeyCredential()
        {
            EventGridTestEnvironment testEnvironment = new EventGridTestEnvironment();
            EventGridClient client = new EventGridClient(
                new Uri(testEnvironment.TopicHost),
                new AzureKeyCredential(testEnvironment.TopicKey));

            string sasToken = client.BuildSharedAccessSignature(DateTimeOffset.UtcNow.AddMinutes(60));
            EventGridClient sasTokenClient = new EventGridClient(
                new Uri(testEnvironment.TopicHost),
                new SharedAccessSignatureCredential(sasToken));

            Assert.That(() => sasTokenClient.BuildSharedAccessSignature(DateTimeOffset.UtcNow.AddMinutes(60)),
                Throws.InstanceOf<NotSupportedException>());
        }
    }
}

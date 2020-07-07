// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridClientTests
    {
        [Test]
        public void BuildSharedAccessSignatureThrowsWhenCalledFromSasClient()
        {
            EventGridClient client = new EventGridClient(
                new Uri("https://exampletopic.westus2-1.eventgrid.azure.net/api/events"),
                new AzureKeyCredential("thisIsNotAFakeCredential"));

            string sasToken = client.BuildSharedAccessSignature(DateTimeOffset.UtcNow.AddMinutes(60));
            EventGridClient sasTokenClient = new EventGridClient(
                new Uri("https://exampletopic.westus2-1.eventgrid.azure.net/api/events"),
                new SharedAccessSignatureCredential("thisIsNotAFakeCredential"));

            Assert.That(() => sasTokenClient.BuildSharedAccessSignature(DateTimeOffset.UtcNow.AddMinutes(60)),
                Throws.InstanceOf<NotSupportedException>(),
                "Can only create a SAS token when using an EventGridClient created using AzureKeyCredential.");
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class CustomEventTests
    {
        [Test]
        public async Task RespectsPortFromUriSendingCustomEvents()
        {
            var ri = new ResourceIdentifier("////subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.EventGrid/topics/topic1");
            var s = ri.ToString();
            var mockTransport = new MockTransport((request) =>
            {
                Assert.AreEqual(100, request.Uri.Port);
                return new MockResponse(200);
            });
            var options = new EventGridPublisherClientOptions
            {
                Transport = mockTransport
            };
            EventGridPublisherClient client =
               new EventGridPublisherClient(
                   new Uri("https://contoso.com:100/api/events"),
                   new AzureKeyCredential("fakeKey"),
                   options);
            var evt = new BinaryData(
                new TestPayload
                {
                    Name = "name",
                    Age = 10,
                });

            List<BinaryData> eventsList = new List<BinaryData>()
            {
                evt
            };

            await client.SendEventsAsync(eventsList);
        }
    }
}

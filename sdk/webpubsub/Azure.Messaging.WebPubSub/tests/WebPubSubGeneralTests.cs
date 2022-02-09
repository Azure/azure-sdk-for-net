// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Messaging.WebPubSub;

using NUnit.Framework;

namespace Azure.Rest.WebPubSub.Tests
{
    public class WebPubSubGeneralTests : RecordedTestBase<WebPubSubTestEnvironment>
    {
        public WebPubSubGeneralTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task ServiceClientCanBroadcastMessages()
        {
            WebPubSubServiceClientOptions options = InstrumentClientOptions(new WebPubSubServiceClientOptions());

            var serviceClient = new WebPubSubServiceClient(TestEnvironment.ConnectionString, nameof(ServiceClientCanBroadcastMessages), options);
            // broadcast messages
            var textContent = "Hello";
            var response = await serviceClient.SendToAllAsync(textContent, ContentType.TextPlain);

            Assert.AreEqual(202, response.Status);

            var jsonContent = BinaryData.FromObjectAsJson(new { hello = "world" });
            response = await serviceClient.SendToAllAsync(RequestContent.Create(jsonContent), ContentType.ApplicationJson);
            Assert.AreEqual(202, response.Status);
            var binaryContent = BinaryData.FromString("Hello");
            response = await serviceClient.SendToAllAsync(RequestContent.Create(binaryContent), ContentType.ApplicationOctetStream);
            Assert.AreEqual(202, response.Status);
        }
    }
}

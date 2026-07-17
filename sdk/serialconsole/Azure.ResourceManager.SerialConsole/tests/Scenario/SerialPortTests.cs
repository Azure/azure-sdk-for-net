// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.SerialConsole.Tests
{
    [TestFixture]
    public class SerialPortTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";

        [Test]
        public async Task GetSerialPorts_GetsSerialPorts()
        {
            MockResponse response = new MockResponse(200);
            response.SetContent("{\"value\":[]}");
            MockTransport transport = new MockTransport(response);
            ArmClientOptions options = new ArmClientOptions
            {
                Transport = transport
            };
            ArmClient client = new ArmClient(new MockCredential(), SubscriptionId, options);
            SubscriptionResource subscription = client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));

            var result = await subscription.GetSerialPortsAsync();

            Assert.That(result.Value, Is.Not.Null);
            Assert.That(transport.SingleRequest.Uri.ToString(), Does.Contain($"/subscriptions/{SubscriptionId}/providers/Microsoft.SerialConsole/serialPorts"));
        }
    }
}

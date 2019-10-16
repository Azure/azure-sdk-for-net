﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Net;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class WebSocketTests : ClientTestBase
    {
        private string GetWebSocketConnectionString(string ConnectionString)
        {
            // Create connection string builder with web-sockets enabled.
            var csb = new EventHubsConnectionStringBuilder(ConnectionString);
            csb.TransportType = EventHubs.TransportType.AmqpWebSockets;
            csb.OperationTimeout = TimeSpan.FromMinutes(5);

            // Confirm connection string has transport-type set as desired.
            string webSocketConnString = csb.ToString();

            // Remove secrets.
            csb.SasKey = "XXX";
            var webSocketConnStringTest = csb.ToString();

            Assert.True(webSocketConnString.Contains("TransportType=AmqpWebSockets"),
                $"Web-sockets enabled connection string doesn't contain desired setting: {webSocketConnStringTest}");
            return webSocketConnString;
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task GetEventHubRuntimeInformation()
        {

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(GetWebSocketConnectionString(connectionString));

                TestUtility.Log("Getting  EventHubRuntimeInformation");
                var eventHubRuntimeInformation = await ehClient.GetRuntimeInformationAsync();

                Assert.True(eventHubRuntimeInformation != null, "eventHubRuntimeInformation was null!");
                Assert.True(eventHubRuntimeInformation.PartitionIds != null, "eventHubRuntimeInformation.PartitionIds was null!");
                Assert.True(eventHubRuntimeInformation.PartitionIds.Length != 0, "eventHubRuntimeInformation.PartitionIds.Length was 0!");

                TestUtility.Log("Found partitions:");
                foreach (string partitionId in eventHubRuntimeInformation.PartitionIds)
                {
                    TestUtility.Log(partitionId);
                }
            }
        }


        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendAndReceive()
        {
            string targetPartitionId = "0";

            TestUtility.Log("Creating Event Hub client");
            await using (var scope = await EventHubScope.CreateAsync(1))
            {

                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(GetWebSocketConnectionString(connectionString));

                PartitionSender sender = null;
                try
                {
                    // Send single message
                    TestUtility.Log("Sending single event");
                    sender = ehClient.CreatePartitionSender(targetPartitionId);
                    var eventData = new EventData(Encoding.UTF8.GetBytes("This event will be transported via web-sockets"));
                    await sender.SendAsync(eventData);
                }
                finally
                {
                    await sender?.CloseAsync();
                }

                PartitionReceiver receiver = null;
                try
                {
                    // Receive single message.
                    TestUtility.Log("Receiving single event");
                    receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartitionId, EventPosition.FromStart());
                    var msg = await receiver.ReceiveAsync(1);
                    Assert.True(msg != null, $"Failed to receive single event from partition {targetPartitionId}");
                }
                finally
                {
                    await receiver?.CloseAsync();
                }
            }
        }



#if FullNetFx
        /// <summary>
        /// Test proxy setting is honored by providing an invalid proxy.
        /// TODO: Enabled test for .NetStandard when moved to CLR 2.1
        /// </summary>
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task InvalidProxy()
        {
            // Send call should fail.
            await Assert.ThrowsAsync<WebSocketException>(async () =>
            {
                await using (var scope = await EventHubScope.CreateAsync(2))
                {
                    var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                    var ehClient = EventHubClient.CreateFromConnectionString(GetWebSocketConnectionString(connectionString));
                    ehClient.WebProxy = new WebProxy("http://1.2.3.4:9999");
                    var edToFail = new EventData(Encoding.UTF8.GetBytes("This is a sample event."));
                    await ehClient.SendAsync(edToFail);
                }
            });



            // Receive call should fail.
            await Assert.ThrowsAsync<WebSocketException>(async () =>
            {
                await using (var scope = await EventHubScope.CreateAsync(2))
                {
                    var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                    var ehClient = EventHubClient.CreateFromConnectionString(GetWebSocketConnectionString(connectionString));
                    ehClient.WebProxy = new WebProxy("http://1.2.3.4:9999");
                    await ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart()).ReceiveAsync(1);
                }
            });



            // Management link call should fail.
            await Assert.ThrowsAsync<WebSocketException>(async () =>
            {
                await using (var scope = await EventHubScope.CreateAsync(2))
                {
                    var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                    var ehClient = EventHubClient.CreateFromConnectionString(GetWebSocketConnectionString(connectionString));
                    ehClient.WebProxy = new WebProxy("http://1.2.3.4:9999");
                    await ehClient.GetRuntimeInformationAsync();
                }
            });



            // Send/receive should work fine w/o proxy.
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehNoProxyClient = EventHubClient.CreateFromConnectionString(GetWebSocketConnectionString(connectionString));
                var eventData = new EventData(Encoding.UTF8.GetBytes("This is a sample event."));
            }
        }
#endif
    }

}
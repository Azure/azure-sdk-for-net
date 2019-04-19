// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Xunit;

    public class TokenProviderTests : ClientTestBase
    {
        [Fact]
        [DisplayTestMethodName]
        async Task UseSharedAccessSignature()
        {
            // Generate shared access token.
            var csb = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);
            var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(csb.SasKeyName, csb.SasKey);
            var token = await tokenProvider.GetTokenAsync(csb.Endpoint.ToString(), TimeSpan.FromSeconds(120));
            var sas = token.TokenValue.ToString();

            // Update connection string builder to use shared access signature instead.
            csb.SasKey = "";
            csb.SasKeyName = "";
            csb.SharedAccessSignature = sas;

            // Create new client with updated connection string.
            var ehClient = EventHubClient.CreateFromConnectionString(csb.ToString());

            // Send one event
            TestUtility.Log($"Sending one message.");
            var ehSender = ehClient.CreatePartitionSender("0");
            var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!"));
            await ehSender.SendAsync(eventData);

            // Receive event.
            // Receive event.
            PartitionReceiver ehReceiver = null;
            try
            {
                TestUtility.Log($"Receiving one message.");
                ehReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
                var msg = await ehReceiver.ReceiveAsync(1);
                Assert.True(msg != null, "Failed to receive message.");
            }
            finally
            {
                await ehReceiver?.CloseAsync();
            }

            // Get EH runtime information.
            TestUtility.Log($"Getting Event Hub runtime information.");
            var ehInfo = await ehClient.GetRuntimeInformationAsync();
            Assert.True(ehInfo != null, "Failed to get runtime information.");

            // Get EH partition runtime information.
            TestUtility.Log($"Getting Event Hub partition '0' runtime information.");
            var partitionInfo = await ehClient.GetPartitionRuntimeInformationAsync("0");
            Assert.True(ehInfo != null, "Failed to get runtime partition information.");
        }

        [Fact]
        [DisplayTestMethodName]
        async Task UseITokenProviderWithSas()
        {
            // Generate SAS token provider.
            var csb = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);
            var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(csb.SasKeyName, csb.SasKey);

            // Create new client with updated connection string.
            var ehClient = EventHubClient.Create(csb.Endpoint, csb.EntityPath, tokenProvider);

            // Send one event
            TestUtility.Log($"Sending one message.");
            var ehSender = ehClient.CreatePartitionSender("0");
            var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!"));
            await ehSender.SendAsync(eventData);

            // Receive event.
            PartitionReceiver ehReceiver = null;
            try
            {
                TestUtility.Log($"Receiving one message.");
                ehReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
                var msg = await ehReceiver.ReceiveAsync(1);
                Assert.True(msg != null, "Failed to receive message.");
            }
            finally
            {
                await ehReceiver?.CloseAsync();
            }

            // Get EH runtime information.
            TestUtility.Log($"Getting Event Hub runtime information.");
            var ehInfo = await ehClient.GetRuntimeInformationAsync();
            Assert.True(ehInfo != null, "Failed to get runtime information.");

            // Get EH partition runtime information.
            TestUtility.Log($"Getting Event Hub partition '0' runtime information.");
            var partitionInfo = await ehClient.GetPartitionRuntimeInformationAsync("0");
            Assert.True(ehInfo != null, "Failed to get runtime partition information.");
        }

        /// <summary>
        /// This test is for manual only purpose. Fill in the tenant-id, app-id and app-secret before running.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task UseITokenProviderWithAad()
        {
            var tenantId = "";
            var aadAppId = "";
            var aadAppSecret = "";

            if (string.IsNullOrEmpty(tenantId))
            {
                TestUtility.Log($"Skipping test during scheduled runs.");
                return;
            }

            var authContext = new AuthenticationContext($"https://login.windows.net/{tenantId}");
            var cc = new ClientCredential(aadAppId, aadAppSecret);
            var tokenProvider = TokenProvider.CreateAadTokenProvider(authContext, cc);

            // Create new client with updated connection string.
            var csb = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);
            var ehClient = EventHubClient.Create(csb.Endpoint, csb.EntityPath, tokenProvider);

            // Send one event
            TestUtility.Log($"Sending one message.");
            var ehSender = ehClient.CreatePartitionSender("0");
            var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!"));
            await ehSender.SendAsync(eventData);

            // Receive event.
            PartitionReceiver ehReceiver = null;
            try
            {
                TestUtility.Log($"Receiving one message.");
                ehReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
                var msg = await ehReceiver.ReceiveAsync(1);
                Assert.True(msg != null, "Failed to receive message.");
            }
            finally
            {
                await ehReceiver?.CloseAsync();
            }
        }

        /// <summary>
        /// This test is for manual only purpose. Fill in the tenant-id, app-id and app-secret before running.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [DisplayTestMethodName]
        async Task UseCreateApiWithAad()
        {
            var tenantId = "";
            var aadAppId = "";
            var aadAppSecret = "";

            if (string.IsNullOrEmpty(tenantId))
            {
                TestUtility.Log($"Skipping test during scheduled runs.");
                return;
            }

            var authContext = new AuthenticationContext($"https://login.windows.net/{tenantId}");
            var cc = new ClientCredential(aadAppId, aadAppSecret);

            // Create new client with updated connection string.
            var csb = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);
            var ehClient = EventHubClient.Create(csb.Endpoint, csb.EntityPath, authContext, cc);

            // Send one event
            TestUtility.Log($"Sending one message.");
            var ehSender = ehClient.CreatePartitionSender("0");
            var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!"));
            await ehSender.SendAsync(eventData);

            // Receive event.
            PartitionReceiver ehReceiver = null;
            try
            {
                TestUtility.Log($"Receiving one message.");
                ehReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
                var msg = await ehReceiver.ReceiveAsync(1);
                Assert.True(msg != null, "Failed to receive message.");
            }
            finally
            {
                await ehReceiver?.CloseAsync();
            }
        }
    }
}

// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Xunit;

    public class TokenProviderTests : ClientTestBase
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task UseSharedAccessSignature()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var csb = new EventHubsConnectionStringBuilder(connectionString);
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
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task UseITokenProviderWithSas()
        {
            // Generate SAS token provider.
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var csb = new EventHubsConnectionStringBuilder(connectionString);
                var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(csb.SasKeyName, csb.SasKey);

                // Create new client with updated connection string.
                var ehClient = EventHubClient.CreateWithTokenProvider(csb.Endpoint, csb.EntityPath, tokenProvider);

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
        }

        /// <summary>
        /// This test is for manual only purpose. Fill in the tenant-id, app-id and app-secret before running.
        /// </summary>
        [Fact(Skip = "Manual run only")]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task UseITokenProviderWithAad()
        {
            var appAuthority = "";
            var aadAppId = "";
            var aadAppSecret = "";

            AzureActiveDirectoryTokenProvider.AuthenticationCallback authCallback =
                async (audience, authority, state) =>
                {
                    var authContext = new AuthenticationContext(authority);
                    var cc = new ClientCredential(aadAppId, aadAppSecret);
                    var authResult = await authContext.AcquireTokenAsync(audience, cc);
                    return authResult.AccessToken;
                };

            var tokenProvider = TokenProvider.CreateAzureActiveDirectoryTokenProvider(authCallback, appAuthority);

            // Create new client with updated connection string.
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var csb = new EventHubsConnectionStringBuilder(connectionString);
                var ehClient = EventHubClient.CreateWithTokenProvider(csb.Endpoint, csb.EntityPath, tokenProvider);

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

        /// <summary>
        /// This test is for manual only purpose. Fill in the tenant-id, app-id and app-secret before running.
        /// </summary>
        /// <returns></returns>
        [Fact(Skip = "Manual run only")]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task UseCreateApiWithAad()
        {
            var appAuthority = "";
            var aadAppId = "";
            var aadAppSecret = "";

            AzureActiveDirectoryTokenProvider.AuthenticationCallback authCallback =
                async (audience, authority, state) =>
                {
                    var authContext = new AuthenticationContext(authority);
                    var cc = new ClientCredential(aadAppId, aadAppSecret);
                    var authResult = await authContext.AcquireTokenAsync(audience, cc);
                    return authResult.AccessToken;
                };

            // Create new client with updated connection string.
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var csb = new EventHubsConnectionStringBuilder(connectionString);
                var ehClient = EventHubClient.CreateWithAzureActiveDirectory(csb.Endpoint, csb.EntityPath, authCallback, appAuthority);

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
}

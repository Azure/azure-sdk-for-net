// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Microsoft.Azure.ServiceBus.Management;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Xunit;

    public class TokenProviderTests : SenderReceiverClientTestBase
    {
        static readonly Uri ServiceBusAudience = new Uri("https://servicebus.azure.net");
        static readonly AzureActiveDirectoryTokenProvider.AuthenticationCallback AadCallBack = GetAadCallback();

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SasTokenWithLargeExpiryTimeShouldBeAccepted()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var csb = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString);
                var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(csb.SasKeyName, csb.SasKey, TimeSpan.FromDays(100));
                var connection = new ServiceBusConnection(csb)
                {
                    TokenProvider = tokenProvider
                };
                var receiver = new MessageReceiver(connection, queueName, ReceiveMode.PeekLock, RetryPolicy.Default);

                try
                {
                    var msg = await receiver.ReceiveAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                }
                finally
                {
                    await receiver.CloseAsync().ConfigureAwait(false);
                }
            });
        }

        /// <summary>
        /// This test is for manual only purpose.
        /// </summary>
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueWithAadTokenProviderTest()
        {
            if (AadCallBack == null)
            {
                TestUtility.Log($"Skipping test during scheduled runs.");
                return;
            }

            string randomQueueName = "TokenProviderTest-" + new Guid().ToString();
            var builder = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString);
            var managementClient = new ManagementClient(TestUtility.NamespaceConnectionString);
            await managementClient.CreateQueueAsync(randomQueueName).ConfigureAwait(false);

            var queueClient = QueueClient.CreateWithAzureActiveDirectory(builder.Endpoint, randomQueueName, AadCallBack);
            try
            {
                await queueClient.SendAsync(new Message(new byte[5])).ConfigureAwait(false);
            }
            finally
            {
                await queueClient.CloseAsync().ConfigureAwait(false);
                await managementClient.DeleteQueueAsync(randomQueueName).ConfigureAwait(false);
                await managementClient.CloseAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// This test is for manual only purpose.
        /// </summary>
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TopicWithAadTokenProviderTest()
        {
            if (AadCallBack == null)
            {
                TestUtility.Log($"Skipping test during scheduled runs.");
                return;
            }

            string randomTopicName = "TokenProviderTest-" + new Guid().ToString();
            var builder = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString);
            var managementClient = new ManagementClient(TestUtility.NamespaceConnectionString);
            await managementClient.CreateTopicAsync(randomTopicName).ConfigureAwait(false);
            
            var topicClient = TopicClient.CreateWithAzureActiveDirectory(builder.Endpoint, randomTopicName, AadCallBack);
            try
            {
                await topicClient.SendAsync(new Message(new byte[5])).ConfigureAwait(false);
            }
            finally
            {
                await topicClient.CloseAsync().ConfigureAwait(false);
                await managementClient.DeleteTopicAsync(randomTopicName).ConfigureAwait(false);
                await managementClient.CloseAsync().ConfigureAwait(false);
            }
        }

        static AzureActiveDirectoryTokenProvider.AuthenticationCallback GetAadCallback()
        {
            // Please fill out values below manually if the AAD tests should be run
            string tenantId = "";
            string aadAppId = "";
            string aadAppSecret = "";

            if (string.IsNullOrEmpty(tenantId))
            {
                return null;
            }

            return async (audience, authority, state) =>
            {
                var authContext = new AuthenticationContext($"https://login.windows.net/{tenantId}", false);
                var cc = new ClientCredential(aadAppId, aadAppSecret);
                var authResult = await authContext.AcquireTokenAsync(ServiceBusAudience.ToString(), cc);
                return authResult.AccessToken;
            };
        }
    }
}

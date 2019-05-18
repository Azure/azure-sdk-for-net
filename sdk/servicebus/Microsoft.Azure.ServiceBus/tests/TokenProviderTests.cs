// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Xunit;

    public class TokenProviderTests : SenderReceiverClientTestBase
    {
        static readonly Uri ServiceBusAudience = new Uri("https://servicebus.azure.net");

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
                    var msg = await receiver.ReceiveAsync(TimeSpan.FromSeconds(5));
                }
                finally
                {
                    await receiver.CloseAsync();
                }
            });
        }

        /// <summary>
        /// This test is for manual only purpose. Fill in the entity name before running.
        /// </summary>
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueWithAadTokenProviderTest()
        {
            // Please fill out the entity name of the Queue being used
            string entityName = "bailiu_queue_test";
            var authCallback = GetAadCallback();

            if (authCallback == null)
            {
                TestUtility.Log($"Skipping test during scheduled runs.");
                return;
            }

            var builder = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString);

            var queueClient = QueueClient.CreateWithAzureActiveDirectory(builder.Endpoint, entityName, authCallback);

            // Send and receive messages.
            await this.PeekLockTestCase(queueClient.InnerSender, queueClient.InnerReceiver, 10);
        }

        /// <summary>
        /// This test is for manual only purpose. Fill in the entity name before running.
        /// </summary>
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TopicWithAadTokenProviderTest()
        {
            // Please fill out the entity name of the Topic being used
            string entityName = "bailiu_topic_test";
            var authCallback = GetAadCallback();

            if (authCallback == null)
            {
                TestUtility.Log($"Skipping test during scheduled runs.");
                return;
            }

            var builder = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString);

            var topicClient = TopicClient.CreateWithAzureActiveDirectory(builder.Endpoint, entityName, authCallback);
            try
            {
                await topicClient.SendAsync(new Message(new byte[5]));
            }
            finally
            {
                await topicClient.CloseAsync();
            }
        }

        AzureActiveDirectoryTokenProvider.AuthenticationCallback GetAadCallback()
        {
            // Please fill out values below manually if the AAD tests should be run
            string tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            string aadAppId = "b92f645b-4561-4bd7-a609-46a6b3010b92";
            string aadAppSecret = "RTyRw=NAiE4ogwCDl01WqZ3SfBFnA]==";

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

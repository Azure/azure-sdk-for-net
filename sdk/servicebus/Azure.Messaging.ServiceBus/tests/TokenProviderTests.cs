//// Copyright (c) Microsoft. All rights reserved.
//// Licensed under the MIT license. See LICENSE file in the project root for full license information.

//using Azure.Core;

//namespace Azure.Messaging.ServiceBus.UnitTests
//{
//    using System;
//    using System.Threading.Tasks;
//    using Azure.Messaging.ServiceBus.Core;
//    using Azure.Messaging.ServiceBus.Primitives;
//    using Xunit;

//    public class TokenProviderTests : SenderReceiverClientTestBase
//    {
//        [Fact]
//        [LiveTest]
//        [DisplayTestMethodName]
//        public async Task SasTokenWithLargeExpiryTimeShouldBeAccepted()
//        {
//            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
//            {
//                var csb = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString);
//                var tokenProvider = TokenCredential.CreateSharedAccessSignatureTokenProvider(csb.SasKeyName, csb.SasKey, TimeSpan.FromDays(100));
//                var connection = new ServiceBusConnection(csb)
//                {
//                    TokenCredential = tokenProvider
//                };
//                var receiver = new MessageReceiver(connection, queueName, ReceiveMode.PeekLock, new ClientOptions());

//                try
//                {
//                    var msg = await receiver.ReceiveAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
//                }
//                finally
//                {
//                    await receiver.CloseAsync().ConfigureAwait(false);
//                }
//            });
//        }

//        [Fact]
//        public async Task AzureActiveDirectoryTokenProviderAuthCallbackTest()
//        {
//            string TestToken = @"eyJhbGciOiJIUzI1NiJ9.e30.ZRrHA1JJJW8opsbCGfG_HACGpVUMN_a9IV7pAx_Zmeo";
//            string ServiceBusAudience = "https://servicebus.azure.net";

//            var aadTokenProvider = TokenCredential.CreateAzureActiveDirectoryTokenProvider(
//                (audience, authority, state) =>
//                {
//                    Assert.Equal(ServiceBusAudience, audience);
//                    return Task.FromResult(TestToken);
//                },
//                "https://servicebus.azure.net/MyTenantId");

//            var token = await aadTokenProvider.GetTokenAsync(ServiceBusAudience, TimeSpan.FromSeconds(60));
//            Assert.Equal(TestToken, token.TokenValue);
//            Assert.Equal(typeof(JsonSecurityToken), token.GetType());
//        }
//    }
//}

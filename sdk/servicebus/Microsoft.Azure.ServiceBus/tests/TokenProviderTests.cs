// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Xunit;

    public class TokenProviderTests : SenderReceiverClientTestBase
    {
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

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task AzureActiveDirectoryTokenProviderAuthCallbackTest()
        {
            var csb = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString);
            string TestToken = @"eyJhbGciOiJIUzI1NiJ9.e30.ZRrHA1JJJW8opsbCGfG_HACGpVUMN_a9IV7pAx_Zmeo";

            var aadTokenProvider = TokenProvider.CreateAzureActiveDirectoryTokenProvider(
                (audience, authority, state) =>
                {
                    Assert.Equal(Constants.AadServiceBusAudience, audience);
                    return Task.FromResult(TestToken);
                },
                "https://servicebus.azure.net/MyTenantId");

            var token = await aadTokenProvider.GetTokenAsync(csb.Endpoint, TimeSpan.FromSeconds(60));
            Assert.Equal(typeof(JsonSecurityToken), token.GetType());
            Assert.Equal(TestToken, token.TokenValue);
            Assert.Equal(csb.Endpoint, token.Audience);
        }
    }
}

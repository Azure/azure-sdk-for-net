// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscription;
using Xunit;

namespace Subscriptions.Tests
{

    public class SubscriptionsTestBase : AzureStackTestBase<SubscriptionClient>
    {
        public SubscriptionsTestBase()
        {
            // Empty
        }

        protected override void ValidateClient(SubscriptionClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.DelegatedProviderOffers);
            Assert.NotNull(client.Subscriptions);
        }
    }
}

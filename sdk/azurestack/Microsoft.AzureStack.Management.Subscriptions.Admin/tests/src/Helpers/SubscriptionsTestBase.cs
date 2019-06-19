// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Xunit;

namespace Subscriptions.Tests
{

    public class SubscriptionsTestBase : AzureStackTestBase<SubscriptionsAdminClient>
    {
        public SubscriptionsTestBase()
        {
            // Empty
        }

        protected override void ValidateClient(SubscriptionsAdminClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.AcquiredPlans);
            Assert.NotNull(client.DelegatedProviders);
            Assert.NotNull(client.DirectoryTenants);
            Assert.NotNull(client.Locations);
            Assert.NotNull(client.OfferDelegations);
            Assert.NotNull(client.Offers);
            Assert.NotNull(client.Plans);
            Assert.NotNull(client.Quotas);
            Assert.NotNull(client.DelegatedProviderOffers);
            Assert.NotNull(client.Subscriptions);
        }
    }
}

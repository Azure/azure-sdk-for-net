// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions;
using Xunit;

namespace Subscriptions.Tests
{

    public class SubscriptionsTestBase : AzureStackTestBase<SubscriptionsManagementClient>
    {
        public SubscriptionsTestBase()
        {
            // Empty
        }

        protected override void ValidateClient(SubscriptionsManagementClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.DelegatedProviderOffers);
            Assert.NotNull(client.Subscriptions);
        }
    }
}

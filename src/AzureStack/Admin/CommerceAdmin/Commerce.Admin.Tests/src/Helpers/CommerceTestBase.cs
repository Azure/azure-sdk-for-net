// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Commerce.Admin;
using Xunit;

namespace Commerce.Tests
{

    public class CommerceTestBase : AzureStackTestBase<CommerceAdminClient>
    {
        public CommerceTestBase()
        {
            // Empty
        }

        protected override void ValidateClient(CommerceAdminClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.SubscriberUsageAggregates);
            Assert.NotNull(client.SubscriptionId);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.AzureBridge.Admin;
using Xunit;

namespace AzureBridge.Tests
{

    public class AzureBridgeTestBase : AzureStackTestBase<AzureBridgeAdminClient>
    {
        public AzureBridgeTestBase()
        {
            // Empty
        }

        protected override void ValidateClient(AzureBridgeAdminClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.Products);
            Assert.NotNull(client.DownloadedProducts);
            Assert.NotNull(client.Activations);
            Assert.NotNull(client.SubscriptionId);
        }
    }
}

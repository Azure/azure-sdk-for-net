// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Network.Admin;
using Microsoft.AzureStack.Management.Network.Admin.Models;
using System;
using Xunit;

namespace Network.Tests {

    public class NetworkTestBase : AzureStackTestBase<NetworkAdminClient> {

        // Helpful Funcs
        protected static Func<Resource, string> ResourceName = (resource) => resource.Name;
        protected static Func<Resource, string> ResourceId = (resource) => resource.Id;
        protected static Func<Resource, string> ResourceLocation = (resource) => resource.Location;
        protected static Func<Resource, string> ResourceType = (resource) => resource.Type;
        
        public NetworkTestBase() {
        }

        protected override void ValidateClient(NetworkAdminClient client) {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.LoadBalancers);
            Assert.NotNull(client.PublicIPAddresses);
            Assert.NotNull(client.Quotas);
            Assert.NotNull(client.VirtualNetworks);
            Assert.NotNull(client.ResourceProviderState);
            

            // validate properties
            Assert.NotNull(client.SubscriptionId);
        }
    }
}

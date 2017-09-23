// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;
using System;
using Xunit;

namespace Fabric.Tests {

    public class FabricTestBase : AzureStackTestBase<FabricAdminClient> {

        // Helpful funcs
        protected static Func<Resource, string> ResourceName = (resource) => resource.Name;
        protected static Func<Resource, string> ResourceId = (resource) => resource.Id;
        protected static Func<Resource, string> ResourceLocation = (resource) => resource.Location;
        protected static Func<Resource, string> ResourceType = (resource) => resource.Type;
        
        public FabricTestBase() {
        }

        protected override void ValidateClient(FabricAdminClient client) {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.ComputeFabricOperations);
            Assert.NotNull(client.EdgeGateways);
            Assert.NotNull(client.EdgeGatewayPools);
            Assert.NotNull(client.FabricLocations);
            Assert.NotNull(client.FileShares);
            Assert.NotNull(client.InfraRoles);
            Assert.NotNull(client.InfraRoleInstances);
            Assert.NotNull(client.IpPools);
            Assert.NotNull(client.LogicalNetworks);
            Assert.NotNull(client.LogicalSubnets);
            Assert.NotNull(client.MacAddressPools);
            Assert.NotNull(client.NetworkFabricOperations);
            Assert.NotNull(client.ScaleUnits);
            Assert.NotNull(client.ScaleUnitNodes);
            Assert.NotNull(client.SlbMuxInstances);
            
            Assert.NotNull(client.StoragePools);
            Assert.NotNull(client.StorageSystems);
            Assert.NotNull(client.Volumes);

            // validate properties
            Assert.NotNull(client.SubscriptionId);
        }
    }
}

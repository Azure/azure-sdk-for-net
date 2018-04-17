// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using System;
    using Xunit;
    
    public class FabricTestBase : AzureStackTestBase<FabricAdminClient>
    {

        // Helpful funcs
        protected static Func<Resource, string> ResourceName = (resource) => resource.Name;
        protected static Func<Resource, string> ResourceId = (resource) => resource.Id;
        protected static Func<Resource, string> ResourceLocation = (resource) => resource.Location;
        protected static Func<Resource, string> ResourceType = (resource) => resource.Type;

        public FabricTestBase() {
        }

        protected void OverFabricLocations(FabricAdminClient client, Action<string> act) {
            var locations = client.FabricLocations.List(ResourceGroupName);
            Common.MapOverIPage(locations, client.FabricLocations.ListNext, (fLocation) => {
                var fabricLocationName = ExtractName(fLocation.Name);
                act(fabricLocationName);
            });
        }

        protected void OverLogicalNetworks(FabricAdminClient client, Action<string, string> act) {
            OverFabricLocations(client, (fabricLocationName) => {
                var logicalNetworks = client.LogicalNetworks.List(ResourceGroupName, fabricLocationName);
                Common.MapOverIPage(logicalNetworks, client.LogicalNetworks.ListNext, (logicalNetwork) => {
                    var logicalNetworkName = ExtractName(logicalNetwork.Name);
                    act(fabricLocationName, logicalNetworkName);
                });
            });
        }

        protected void OverStorageSystems(FabricAdminClient client, Action<string, string> act) {
            OverFabricLocations(client, (fabricLocationName) => {
                var storageSystems = client.StorageSystems.List(ResourceGroupName, fabricLocationName);
                Common.MapOverIPage(storageSystems, client.StorageSystems.ListNext, (storageSystem) => {
                    var storageSystemName = ExtractName(storageSystem.Name);
                    act(fabricLocationName, storageSystemName);
                });
            });
        }

        protected void OverStoragePools(FabricAdminClient client, Action<string, string, string> act) {
            OverStorageSystems(client, (fabricLocationName, storageSystemName) => {
                var storageSystems = client.StoragePools.List(ResourceGroupName, fabricLocationName, storageSystemName);
                Common.MapOverIPage(storageSystems, client.StoragePools.ListNext, (storagePool) => {
                    var storagePoolName = ExtractName(storagePool.Name);
                    act(fabricLocationName, storageSystemName, storagePoolName);
                });
            });
        }

        public string GetLocation(FabricAdminClient client) {
            return ExtractName(client.FabricLocations.List(ResourceGroupName).GetFirst().Name);
        }

        public string GetLogicalNetwork(FabricAdminClient client, string fabricLocationName) {
            return ExtractName(client.LogicalNetworks.List(ResourceGroupName, fabricLocationName).GetFirst().Name);
        }

        public string GetStorageSystem(FabricAdminClient client, string fabricLocationName) {
            return ExtractName(client.StorageSystems.List(ResourceGroupName, fabricLocationName).GetFirst().Name);
        }

        public string GetStoragePool(FabricAdminClient client, string fabricLocationName, string storageSystemName) {
            return ExtractName(client.StoragePools.List(ResourceGroupName, fabricLocationName, storageSystemName).GetFirst().Name);
        }

        protected override void ValidateClient(FabricAdminClient client) {
            // validate creation
            Assert.NotNull(client);

            // validate objects
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

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

        protected void OverScaleUnits(FabricAdminClient client, Action<string, string> act) {
            OverFabricLocations(client, (fabricLocationName) => {
                var scaleUnits = client.ScaleUnits.List(ResourceGroupName, fabricLocationName);
                Common.MapOverIPage(scaleUnits, client.ScaleUnits.ListNext, (scaleUnit) => {
                    var scaleUnitsName = ExtractName(scaleUnit.Name);
                    act(fabricLocationName, scaleUnitsName);
                });
            });
        }

        protected void OverStorageSubSystems(FabricAdminClient client, Action<string, string, string> act) {
            OverScaleUnits(client, (fabricLocationName, scaleUnitsName) => {
                var storageSubSystems = client.StorageSubSystems.List(ResourceGroupName, fabricLocationName, scaleUnitsName);
                Common.MapOverIPage(storageSubSystems, client.StorageSubSystems.ListNext, (storageSubSystem) => {
                    var storageSubSystemName = ExtractName(storageSubSystem.Name);
                    act(fabricLocationName, scaleUnitsName, storageSubSystemName);
                });
            });
        }

        public string GetLocation(FabricAdminClient client) {
            return ExtractName(client.FabricLocations.List(ResourceGroupName).GetFirst().Name);
        }

        public string GetLogicalNetwork(FabricAdminClient client, string fabricLocationName) {
            return ExtractName(client.LogicalNetworks.List(ResourceGroupName, fabricLocationName).GetFirst().Name);
        }

        public string GetScaleUnit(FabricAdminClient client, string fabricLocationName) {
            return ExtractName(client.ScaleUnits.List(ResourceGroupName, fabricLocationName).GetFirst().Name);
        }

        public string GetStorageSubSystem(FabricAdminClient client, string fabricLocationName, string scaleUnitName) {
            return ExtractName(client.StorageSubSystems.List(ResourceGroupName, fabricLocationName, scaleUnitName).GetFirst().Name);
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
            Assert.NotNull(client.StorageSubSystems);
            Assert.NotNull(client.Volumes);

            // validate properties
            Assert.NotNull(client.SubscriptionId);
        }
    }
}

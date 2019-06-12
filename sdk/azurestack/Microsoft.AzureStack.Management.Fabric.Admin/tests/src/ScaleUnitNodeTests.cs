// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Microsoft.Rest.Azure;
    using Xunit;

    public class ScaleUnitNodeTests : FabricTestBase
    {
        private void AssertScaleUnitNodesAreSame(ScaleUnitNode expected, ScaleUnitNode found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.BiosVersion, found.BiosVersion);
                Assert.Equal(expected.BmcAddress, found.BmcAddress);
                Assert.Equal(expected.CanPowerOff, found.CanPowerOff);
                if (expected.Capacity == null)
                {
                    Assert.Null(found.Capacity);
                }
                else
                {
                    Assert.Equal(expected.Capacity.Cores, found.Capacity.Cores);
                    Assert.Equal(expected.Capacity.MemoryGB, found.Capacity.MemoryGB);
                }
                Assert.Equal(expected.Model, found.Model);
                Assert.Equal(expected.PowerState, found.PowerState);
                Assert.Equal(expected.ScaleUnitName, found.ScaleUnitName);
                Assert.Equal(expected.ScaleUnitNodeStatus, found.ScaleUnitNodeStatus);
                Assert.Equal(expected.ScaleUnitUri, found.ScaleUnitUri);
                Assert.Equal(expected.SerialNumber, found.SerialNumber);
                Assert.Equal(expected.Vendor, found.Vendor);

            }
        }

        private void ValidateScaleUnitNode(ScaleUnitNode scaleUnitNode) {
            FabricCommon.ValidateResource(scaleUnitNode);

            Assert.NotNull(scaleUnitNode.CanPowerOff);
            Assert.NotNull(scaleUnitNode.Capacity);
            Assert.NotNull(scaleUnitNode.PowerState);
            Assert.NotNull(scaleUnitNode.ScaleUnitName);
            Assert.NotNull(scaleUnitNode.ScaleUnitNodeStatus);
            Assert.NotNull(scaleUnitNode.ScaleUnitUri);
        }


        [Fact]
        public void TestListScaleUnitNodes() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var scaleUnitNodes = client.ScaleUnitNodes.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(scaleUnitNodes, client.ScaleUnitNodes.ListNext, ValidateScaleUnitNode);
                    Common.WriteIPagesToFile(scaleUnitNodes, client.ScaleUnitNodes.ListNext, "ListScaleUnitNodes.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetScaleUnitNode() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var scaleUnitNode = client.ScaleUnitNodes.List(ResourceGroupName, fabricLocationName).GetFirst();
                var scaleUnitNodeName = ExtractName(scaleUnitNode.Name);

                var retrieved = client.ScaleUnitNodes.Get(ResourceGroupName, fabricLocationName, scaleUnitNodeName);
                AssertScaleUnitNodesAreSame(scaleUnitNode, retrieved);
            });
        }

        [Fact]
        public void TestGetAllScaleUnitNodes() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var scaleUnitNodes = client.ScaleUnitNodes.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(scaleUnitNodes, client.ScaleUnitNodes.ListNext, (scaleUnitNode) => {

                        var scaleUnitNodeName = ExtractName(scaleUnitNode.Name);
                        var retrieved = client.ScaleUnitNodes.Get(ResourceGroupName, fabricLocationName, scaleUnitNodeName);
                        AssertScaleUnitNodesAreSame(scaleUnitNode, retrieved);
                    });
                });
            });
        }

        [Fact(Skip="Test Framework change, need to record.")]
        public void TestPowerOnScaleUnitNode() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var scaleUnitNode = client.ScaleUnitNodes.List(ResourceGroupName, fabricLocationName).GetFirst();
                var scaleUnitNodeName = ExtractName(scaleUnitNode.Name);

                client.ScaleUnitNodes.PowerOn(ResourceGroupName, fabricLocationName, scaleUnitNodeName);
                var sun = client.ScaleUnitNodes.Get(ResourceGroupName, fabricLocationName, scaleUnitNodeName);
                Assert.Equal("Running", sun.PowerState);
            });
        }

        [Fact]
        public void TestStartStopMaintenanceModeUnitNode() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var fabricLocationName = GetLocation(client);
                    var scaleUnitNode = client.ScaleUnitNodes.List(ResourceGroupName, fabricLocationName).GetFirst();
                    var scaleUnitNodeName = ExtractName(scaleUnitNode.Name);
                    client.ScaleUnitNodes.StartMaintenanceMode(ResourceGroupName, fabricLocationName, scaleUnitNodeName);
                    client.ScaleUnitNodes.StopMaintenanceMode(ResourceGroupName, fabricLocationName, scaleUnitNodeName);
                });
            });
        }


        // Try on Tenant VMs

        // This needs to be setup before the run.
        private string TenantVMName = "f858418d-d6b9-4dc3-ae65-c92fb8a0be8f";


        [Fact]
        public void TestGetScaleUnitNodeOnTenantVM() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var result = client.ScaleUnitNodes.Get(ResourceGroupName, fabricLocationName, TenantVMName);
                Assert.Null(result);
            });
        }

        [Fact]
        public void TestPowerOnOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var fabricLocationName = GetLocation(client);
                    client.ScaleUnitNodes.PowerOn(ResourceGroupName, fabricLocationName, TenantVMName);
                });
            });
        }


        [Fact]
        public void TestPowerOffOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var fabricLocationName = GetLocation(client);
                    client.ScaleUnitNodes.PowerOff(ResourceGroupName, fabricLocationName, TenantVMName);
                });
            });
        }

        [Fact]
        public void TestStartMaintenanceModeOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var fabricLocationName = GetLocation(client);
                    client.ScaleUnitNodes.StartMaintenanceMode(ResourceGroupName, fabricLocationName, TenantVMName);
                });
            });
        }

        // Disabled

        [Fact(Skip = "No hardware")]
        public void TestPowerOffScaleUnitNode() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var scaleUnitNode = client.ScaleUnitNodes.List(ResourceGroupName, fabricLocationName).GetFirst();
                var scaleUnitNodeName = ExtractName(scaleUnitNode.Name);
                client.ScaleUnitNodes.PowerOff(ResourceGroupName, fabricLocationName, scaleUnitNodeName);
                client.ScaleUnitNodes.PowerOn(ResourceGroupName, fabricLocationName, scaleUnitNodeName);
            });
        }

    }
}

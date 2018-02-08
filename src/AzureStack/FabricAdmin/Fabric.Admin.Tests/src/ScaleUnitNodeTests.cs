// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;
using Microsoft.Rest.Azure;
using Xunit;

namespace Fabric.Tests
{

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
                var scaleUnitNodes = client.ScaleUnitNodes.List(Location);
                Common.MapOverIPage(scaleUnitNodes, client.ScaleUnitNodes.ListNext, ValidateScaleUnitNode);
                Common.WriteIPagesToFile(scaleUnitNodes, client.ScaleUnitNodes.ListNext, "ListScaleUnitNodes.txt", ResourceName);
            });
        }

        [Fact]
        public void TestGetScaleUnitNode() {
            RunTest((client) => {
                var scaleUnitNode = client.ScaleUnitNodes.List(Location).GetFirst();
                var retrieved = client.ScaleUnitNodes.Get(Location, scaleUnitNode.Name);
                AssertScaleUnitNodesAreSame(scaleUnitNode, retrieved);
            });
        }

        [Fact]
        public void TestGetAllScaleUnitNodes() {
            RunTest((client) => {
                var scaleUnitNodes = client.ScaleUnitNodes.List(Location);
                Common.MapOverIPage(scaleUnitNodes, client.ScaleUnitNodes.ListNext, (scaleUnitNode) => {
                    var retrieved = client.ScaleUnitNodes.Get(Location, scaleUnitNode.Name);
                    AssertScaleUnitNodesAreSame(scaleUnitNode, retrieved);
                });
            });
        }

        [Fact]
        public void TestPowerOnScaleUnitNode() {
            RunTest((client) => {
                var scaleUnitNode = client.ScaleUnitNodes.List(Location).GetFirst();

                var provisioningState = client.ScaleUnitNodes.PowerOn(Location, scaleUnitNode.Name);
                Assert.NotEqual("", provisioningState.ProvisioningState);
                Assert.Equal("Succeeded", provisioningState.ProvisioningState);

                var sun = client.ScaleUnitNodes.Get(Location, scaleUnitNode.Name);
                Assert.Equal("Running", sun.PowerState);
            });
        }

        [Fact]
        public void TestStartStopMaintenanceModeUnitNode() {
            RunTest((client) => {
                var scaleUnitNode = client.ScaleUnitNodes.List(Location).GetFirst();
                Assert.Throws<CloudException>(() => {
                    client.ScaleUnitNodes.StartMaintenanceMode(Location, scaleUnitNode.Name);
                    client.ScaleUnitNodes.StopMaintenanceMode(Location, scaleUnitNode.Name);
                });
            });
        }


        // Try on Tenant VMs

        // This needs to be setup before the run. 
        private string TenantVMName = "502828aa-de3a-4ba9-a66c-5ae6d49589d7";


        [Fact]
        public void TestGetScaleUnitNodeOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => client.ScaleUnitNodes.Get(Location, TenantVMName));
            });
        }

        [Fact]
        public void TestPowerOnOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var provisioningState = client.ScaleUnitNodes.PowerOn(Location, TenantVMName);
                    Assert.NotEqual("", provisioningState.ProvisioningState);
                    Assert.Equal("Failed", provisioningState.ProvisioningState);
                });
            });
        }


        [Fact]
        public void TestPowerOffOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var provisioningState = client.ScaleUnitNodes.PowerOff(Location, TenantVMName);
                    Assert.NotEqual("", provisioningState.ProvisioningState);
                    Assert.Equal("Failed", provisioningState.ProvisioningState);
                });
            });
        }

        [Fact]
        public void TestStartMaintenanceModeOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var provisioningState = client.ScaleUnitNodes.StartMaintenanceMode(Location, TenantVMName);
                    Assert.NotEqual("", provisioningState.ProvisioningState);
                    Assert.Equal("Failed", provisioningState.ProvisioningState);
                });
            });
        }

        // Disabled

        [Fact(Skip = "No hardware")]
        public void TestPowerOffScaleUnitNode() {
            RunTest((client) => {
                var scaleUnitNode = client.ScaleUnitNodes.List(Location).GetFirst();
                var obj1 = client.ScaleUnitNodes.PowerOff(Location, scaleUnitNode.Name);
                var obj2 = client.ScaleUnitNodes.PowerOn(Location, scaleUnitNode.Name);
            });
        }

    }
}

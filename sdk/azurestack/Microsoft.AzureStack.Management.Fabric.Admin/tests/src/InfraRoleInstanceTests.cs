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

    /// <summary>
    /// Summary description for FabricTest
    /// </summary>
    public class InfraRoleInstanceTests : FabricTestBase
    {
        private string RoleInstance = "AzS-ACS01";

        private void AssertInfraRoleInstancesEqual(InfraRoleInstance expected, InfraRoleInstance found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.Name, found.Name);
                Assert.Equal(expected.Id, found.Id);
                Assert.Equal(expected.Location, found.Location);

                // Infra Role Instance
                Assert.Equal(expected.ScaleUnit, found.ScaleUnit);
                Assert.Equal(expected.ScaleUnitNode, found.ScaleUnitNode);
                Assert.Equal(expected.Size.Cores, found.Size.Cores);
                Assert.Equal(expected.Size.MemoryGb, found.Size.MemoryGb);
                Assert.Equal(expected.State, found.State);
                Assert.Equal(expected.Type, found.Type);
            }
        }

        private void ValiateInfraRoleInstance(InfraRoleInstance instance) {
            FabricCommon.ValidateResource(instance);
            Assert.NotNull(instance.ScaleUnit);
            Assert.NotNull(instance.ScaleUnitNode);
            Assert.NotNull(instance.Size);
            Assert.NotNull(instance.State);
        }

        [Fact]
        public void TestListInfraRoleInstances() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var instances = client.InfraRoleInstances.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(instances, client.InfraRoleInstances.ListNext, ValiateInfraRoleInstance);
                    Common.WriteIPagesToFile(instances, client.InfraRoleInstances.ListNext, "ListInfraRoleInstances.txt", (instance) => instance.Name);
                });
            });
        }

        [Fact]
        public void TestGetInfraRoleInstance() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);

                var instance = client.InfraRoleInstances.List(ResourceGroupName, fabricLocationName).GetFirst();
                var instanceName = ExtractName(instance.Name);

                var retrieved = client.InfraRoleInstances.Get(ResourceGroupName, fabricLocationName, instanceName);
                ValiateInfraRoleInstance(retrieved);
                AssertInfraRoleInstancesEqual(instance, retrieved);
            });
        }

        [Fact]
        public void TestGetAllInfraRoleInstances() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var instances = client.InfraRoleInstances.List(ResourceGroupName, fabricLocationName);

                    Common.MapOverIPage(instances, client.InfraRoleInstances.ListNext, (instance) => {
                        var instanceName = ExtractName(instance.Name);
                        var retrieved = client.InfraRoleInstances.Get(ResourceGroupName, fabricLocationName, instanceName);
                        ValiateInfraRoleInstance(retrieved);
                        AssertInfraRoleInstancesEqual(instance, retrieved);
                    });
                });
            });
        }

        // This should do nothing
        [Fact(Skip="Test Framework change, need to record.")]
        public void TestInfraRoleInstancePowerOn() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var instance = client.InfraRoleInstances.List(ResourceGroupName, fabricLocationName).GetFirst();
                var instanceName = ExtractName(instance.Name);
                client.InfraRoleInstances.PowerOn(ResourceGroupName, fabricLocationName, instanceName);
            });
        }

        // This should do nothing
        [Fact(Skip="Test Framework change, need to record.")]
        public void TestInfraRoleInstancePowerOnAll() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var instances = client.InfraRoleInstances.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(instances, client.InfraRoleInstances.ListNext, (instance) => {
                        var instanceName = ExtractName(instance.Name);
                        client.InfraRoleInstances.PowerOn(ResourceGroupName, fabricLocationName, instanceName);
                    });
                });
            });
        }

        // This needs to be setup before the run.
        private string TenantVMName = "502828aa-de3a-4ba9-a66c-5ae6d49589d7";

        // Make sure we cannot touch tenant VMs

        [Fact]
        public void TestGetInfraRoleInstanceOnTenantVM() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var result = client.InfraRoleInstances.Get(ResourceGroupName, fabricLocationName, TenantVMName);
                Assert.Null(result);
            });
        }

        [Fact]
        public void TestInfraRoleInstanceShutdownOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var fabricLocationName = GetLocation(client);
                    client.InfraRoleInstances.Shutdown(ResourceGroupName, fabricLocationName, TenantVMName);
                });
            });
        }

        [Fact]
        public void TestInfraRoleInstancePowerOffOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var fabricLocationName = GetLocation(client);
                    client.InfraRoleInstances.PowerOff(ResourceGroupName, fabricLocationName, TenantVMName);
                });
            });
        }

        [Fact]
        public void TestInfraRoleInstanceRebootOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var fabricLocationName = GetLocation(client);
                    client.InfraRoleInstances.Reboot(ResourceGroupName, fabricLocationName, TenantVMName);
                });
            });
        }


        // Disabled Tests

        // NOTE: Only test this on a multi-node environment, ASDK will not allow for infrastructure VMs to be powered off/rebooted/etc
        [Fact(Skip = "No hardware")]
        public void TestInfraRoleInstanceShutdown() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);

                client.InfraRoleInstances.Shutdown(ResourceGroupName, fabricLocationName, RoleInstance);
                var instance = client.InfraRoleInstances.Get(ResourceGroupName, fabricLocationName, RoleInstance);
                ValiateInfraRoleInstance(instance);
                client.InfraRoleInstances.PowerOn(ResourceGroupName, fabricLocationName, RoleInstance);
            });
        }

        // TODO: Not sure how safe this is, also not sure of return type or value.
        [Fact(Skip = "No hardware")]
        public void TestInfraRoleInstancePowerOff() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);

                client.InfraRoleInstances.PowerOff(ResourceGroupName, fabricLocationName, RoleInstance);
            });
        }

        [Fact(Skip = "No hardware")]
        public void TestInfraRoleInstanceReboot() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);

                client.InfraRoleInstances.Reboot(ResourceGroupName, fabricLocationName, RoleInstance);
                var instance = client.InfraRoleInstances.Get(ResourceGroupName, fabricLocationName, RoleInstance);
                ValiateInfraRoleInstance(instance);
            });
        }
    }
}

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
                var instances = client.InfraRoleInstances.List(Location);
                Common.MapOverIPage(instances, client.InfraRoleInstances.ListNext, ValiateInfraRoleInstance);
                Common.WriteIPagesToFile(instances, client.InfraRoleInstances.ListNext, "ListInfraRoleInstances.txt", (instance) => instance.Name);
            });
        }

        [Fact]
        public void TestGetInfraRoleInstance() {
            RunTest((client) => {
                var instance = client.InfraRoleInstances.List(Location).GetFirst();
                var retrieved = client.InfraRoleInstances.Get(Location, instance.Name);
                ValiateInfraRoleInstance(retrieved);
                AssertInfraRoleInstancesEqual(instance, retrieved);
            });
        }

        [Fact]
        public void TestGetAllInfraRoleInstances() {
            RunTest((client) => {
                var instances = client.InfraRoleInstances.List(Location);
                Common.MapOverIPage(instances, client.InfraRoleInstances.ListNext, (instance) => {
                    var retrieved = client.InfraRoleInstances.Get(Location, instance.Name);
                    ValiateInfraRoleInstance(retrieved);
                    AssertInfraRoleInstancesEqual(instance, retrieved);
                });
            });
        }

        // This should do nothing
        [Fact]
        public void TestInfraRoleInstancePowerOn() {
            RunTest((client) => {
                var instance = client.InfraRoleInstances.List(Location).GetFirst();
                client.InfraRoleInstances.PowerOn(Location, instance.Name);
            });
        }

        // This should do nothing
        [Fact]
        public void TestInfraRoleInstancePowerOnAll() {
            RunTest((client) => {
                var instances = client.InfraRoleInstances.List(Location);
                Common.MapOverIPage(instances, client.InfraRoleInstances.ListNext, (instance) => {
                    client.InfraRoleInstances.PowerOn(Location, instance.Name);
                });
            });
        }

        // This needs to be setup before the run. 
        private string TenantVMName = "502828aa-de3a-4ba9-a66c-5ae6d49589d7";

        // Make sure we cannot touch tenant VMs

        [Fact]
        public void TestGetInfraRoleInstanceOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => client.InfraRoleInstances.Get(Location, TenantVMName));
            });
        }

        [Fact]
        public void TestInfraRoleInstanceShutdownOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var provisioningState = client.InfraRoleInstances.Shutdown(Location, TenantVMName);
                    Assert.NotEqual("", provisioningState.ProvisioningState);
                    Assert.Equal("Failed", provisioningState.ProvisioningState);
                });
            });
        }

        [Fact]
        public void TestInfraRoleInstancePowerOffOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var provisioningState = client.InfraRoleInstances.PowerOff(Location, TenantVMName);
                    Assert.NotEqual("", provisioningState.ProvisioningState);
                    Assert.Equal("Failed", provisioningState.ProvisioningState);
                });
            });
        }

        [Fact]
        public void TestInfraRoleInstanceRebootOnTenantVM() {
            RunTest((client) => {
                Assert.Throws<CloudException>(() => {
                    var provisioningState = client.InfraRoleInstances.Reboot(Location, TenantVMName);
                    Assert.NotEqual("", provisioningState.ProvisioningState);
                    Assert.Equal("Failed", provisioningState.ProvisioningState);
                });
            });
        }


        // Disabled Tests

        // TODO: Not sure how safe this is, also not sure of return type or value.
        [Fact(Skip = "No hardware")]
        public void TestInfraRoleInstanceShutdown() {
            RunTest((client) => {
                var provisioningState = client.InfraRoleInstances.Shutdown(Location, RoleInstance);
                Assert.NotEqual("", provisioningState.ProvisioningState);
                    Assert.Equal("Failed", provisioningState.ProvisioningState);

                var instance = client.InfraRoleInstances.Get(Location, RoleInstance);
                ValiateInfraRoleInstance(instance);
            });
        }

        // TODO: Not sure how safe this is, also not sure of return type or value.
        [Fact(Skip = "No hardware")]
        public void TestInfraRoleInstancePowerOff() {
            RunTest((client) => {
                var provisioningState = client.InfraRoleInstances.PowerOff(Location, "502828aa-de3a-4ba9-a66c-5ae6d49589d7");
                Assert.NotEqual("", provisioningState.ProvisioningState);
                    Assert.Equal("Failed", provisioningState.ProvisioningState);
            });
        }

        [Fact(Skip = "No hardware")]
        public void TestInfraRoleInstanceReboot() {
            RunTest((client) => {
                client.InfraRoleInstances.Reboot(Location, RoleInstance);
                var instance = client.InfraRoleInstances.Get(Location, RoleInstance);
                ValiateInfraRoleInstance(instance);
                // TODO: What are the assertions?
            });
        }
    }
}

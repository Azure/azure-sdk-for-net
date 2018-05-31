// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    /// <summary>
    /// Summary description for FabricTest
    /// </summary>
    public class InfraRoleTests : FabricTestBase
    {

        private void ValidateInfraRole(InfraRole role) {
            Assert.True(FabricCommon.ValidateResource(role));
            Assert.NotNull(role.Instances);
        }

        private void AssertInfraRolesAreSame(InfraRole expected, InfraRole found) {
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
                Assert.Equal(expected.Type, found.Type);
                Assert.Equal(expected.Instances.Count, found.Instances.Count);
            }
        }

        [Fact]
        public void TestListInfraRoles() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var roles = client.InfraRoles.List(ResourceGroupName, fabricLocationName);
                    Assert.NotNull(roles);

                    Common.MapOverIPage(roles, client.InfraRoles.ListNext, ValidateInfraRole);
                    Common.WriteIPagesToFile(roles, client.InfraRoles.ListNext, "ListInfraRoles.txt", (role) => role.Name);
                });
            });
        }

        [Fact]
        public void TestGetInfraRole() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);

                var role = client.InfraRoles.List(ResourceGroupName, fabricLocationName).GetFirst();
                var roleName = ExtractName(role.Name);

                var retrieved = client.InfraRoles.Get(ResourceGroupName, fabricLocationName, roleName);
                AssertInfraRolesAreSame(role, retrieved);
            });
        }

        [Fact]
        public void TestGetAllInfraRoles() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var roles = client.InfraRoles.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(roles, client.InfraRoles.ListNext, (role) => {

                        var roleName = ExtractName(role.Name);
                        var retrieved = client.InfraRoles.Get(ResourceGroupName, fabricLocationName, roleName);
                        AssertInfraRolesAreSame(role, retrieved);
                    });
                });
            });
        }

    }
}

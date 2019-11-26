// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Microsoft.AzureStack.Management.Subscriptions.Admin.Models;
using Subscriptions.Tests.src.Helpers;
using System;
using Xunit;

namespace Subscriptions.Tests
{
    public class DirectoryTenantTests : SubscriptionsTestBase
    {
        private void ValidateDirectoryTenant(DirectoryTenant item) {
            // Resource
            Assert.NotNull(item);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.Location);
            Assert.NotNull(item.Name);
            Assert.NotNull(item.Type);

            // DirectoryTenant
            Assert.NotNull(item.TenantId);
        }

        private void AssertSame(DirectoryTenant expected, DirectoryTenant given) {
            // Resource
            Assert.Equal(expected.Id, given.Id);
            Assert.Equal(expected.Location, given.Location);
            Assert.Equal(expected.Name, given.Name);
            Assert.Equal(expected.Type, given.Type);

            // DirectoryTenant
            Assert.Equal(expected.TenantId, given.TenantId);
        }

        [Fact]
        public void TestListDirectoryTenants() {
            RunTest((client) => {
                var directoryTenants = client.DirectoryTenants.List(TestContext.InfrastructureResourceGroupName);
                directoryTenants.ForEach(client.DirectoryTenants.ListNext, ValidateDirectoryTenant);
            });
        }

        [Fact]
        public void TestGetAllDirectoryTenants() {
            RunTest((client) => {
                var directoryTenants = client.DirectoryTenants.List(TestContext.InfrastructureResourceGroupName);
                directoryTenants.ForEach(client.DirectoryTenants.ListNext, (tenant) => {
                    var result = client.DirectoryTenants.Get(TestContext.InfrastructureResourceGroupName, tenant.Name);
                    AssertSame(tenant, result);
                });
            });
        }

        [Fact]
        public void TestGetDirectoryTenant() {
            RunTest((client) => {
                var tenant = client.DirectoryTenants.List(TestContext.InfrastructureResourceGroupName).GetFirst();
                var result = client.DirectoryTenants.Get(TestContext.InfrastructureResourceGroupName, tenant.Name);
                AssertSame(tenant, result);
            });
        }
    }
}

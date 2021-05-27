// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabricManagedClusters.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.ServiceFabricManagedClusters;
    using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class ManagedClusterVersionTests : ServiceFabricManagedTestBase
    {
        internal const string Location = "southcentralus";

        [Fact]
        public void GetVersionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricMcClient = GetServiceFabricMcClient(context);
                var version = "7.2.457.9590";

                var versionResult = serviceFabricMcClient.ManagedClusterVersion.Get(Location, version);

                Assert.Equal(version, versionResult.Name);
                Assert.Equal("Windows", versionResult.OsType);
                Assert.Equal(version, versionResult.ClusterCodeVersion);
            }
        }

        [Fact]
        public void GetVersionListTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricMcClient = GetServiceFabricMcClient(context);
                var versionListResult = serviceFabricMcClient.ManagedClusterVersion.List(Location);

                Assert.NotNull(versionListResult);
                Assert.True(versionListResult.Count() > 1);
            }
        }

        [Fact]
        public void GetVersionByEnvironmentTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricMcClient = GetServiceFabricMcClient(context);
                var version = "7.2.457.9590";

                // currently only windows
                var versionResult = serviceFabricMcClient.ManagedClusterVersion.GetByEnvironment(Location, version);

                Assert.Equal(version, versionResult.Name);
                Assert.Equal("Windows", versionResult.OsType);
                Assert.Equal(version, versionResult.ClusterCodeVersion);
            }
        }

        [Fact]
        public void GetVersionListByEnvironmentTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricMcClient = GetServiceFabricMcClient(context);

                // currently only windows
                var versionListResult = serviceFabricMcClient.ManagedClusterVersion.ListByEnvironment(Location);

                Assert.NotNull(versionListResult);
                Assert.True(versionListResult.Count() > 1);
                Assert.True(versionListResult.All(version => version.OsType == "Windows"));
            }
        }
    }
}


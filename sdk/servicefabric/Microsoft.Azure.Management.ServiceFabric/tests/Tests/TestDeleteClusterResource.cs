// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabric.Tests.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.ServiceFabric;
    using System.Linq;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using System.IO;
    using Microsoft.Azure.Management.ServiceFabric.Models;
    using System;
    using System.Collections.Generic;

    public class TestDeleteClusterResource : ServiceFabricTestBase
    {
        [Fact]
        public void TestDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricClient = GetServiceFabricClient(context);
                var resouceClient = GetResourceManagementClient(context);
                var resouceGroupName = "testDeleterg";
                var location = "South Central US";
                var clusterName = "testDeleteCluster";

                var cluster = CreateCluster(resouceClient, serviceFabricClient, resouceGroupName, location, clusterName);

                cluster = serviceFabricClient.Clusters.Get(resouceGroupName, clusterName);
                Assert.NotNull(cluster);

                serviceFabricClient.Clusters.Delete(resouceGroupName, clusterName);

                var exception = Assert.Throws<ErrorModelException>(() =>
                {
                    cluster = serviceFabricClient.Clusters.Get(resouceGroupName, clusterName);
                });

                Assert.True(exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound);

                serviceFabricClient.Clusters.Delete(resouceGroupName, "donotexistcluster");
            }
        }
    }
}


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

    public class TestCreateClusterResource : ServiceFabricTestBase
    {
        [Fact]
        public void TestCreate()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricClient = GetServiceFabricClient(context);
                var resouceClient = GetResourceManagementClient(context);
                var resouceGroupName = "TestRG1";
                var location = "South Central US";
                var clusterName = "testCreateCluster2";

                try
                {
                    serviceFabricClient.Clusters.Get(resouceGroupName, clusterName);
                    serviceFabricClient.Clusters.Delete(resouceGroupName, clusterName);
                }
                catch (ErrorModelException e)
                {
                    Assert.True(e.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(10));

                var cluster = CreateCluster(resouceClient, serviceFabricClient, resouceGroupName, location, clusterName);
                cluster = serviceFabricClient.Clusters.Get(resouceGroupName, clusterName);
                Assert.NotNull(cluster);
            }
        }
    }
}


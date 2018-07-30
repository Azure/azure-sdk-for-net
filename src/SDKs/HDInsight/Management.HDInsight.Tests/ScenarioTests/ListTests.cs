// 
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Management.HDInsight.Tests
{
    using Microsoft.Azure.Management.HDInsight;
    using Microsoft.Azure.Management.HDInsight.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("ScenarioTests")]
    public class ListTests
    {
        [Fact]
        public void TestListClustersInResourceGroup()
        {
            string suiteName = GetType().FullName;
            string testName = "TestListClustersInResourceGroup";
            HDInsightManagementTestUtilities.RunTestInNewResourceGroup(suiteName, testName,
                (resClient, client, rgName) =>
                {
                    string clusterName1 = "hdisdk-cluster1";
                    string clusterName2 = "hdisdk-cluster2";
                    try
                    {
                        var list = client.Clusters.ListByResourceGroup(rgName);
                        Assert.False(list.Any(c => c.Name.Equals(clusterName1, StringComparison.OrdinalIgnoreCase)));
                        Assert.False(list.Any(c => c.Name.Equals(clusterName2, StringComparison.OrdinalIgnoreCase)));

                        // Create one cluster with ADLS so both clusters aren't using the same storage account at the same time
                        ClusterCreateParameters parameters1 = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);
                        ClusterCreateParameters parameters2 = ClusterCreateParametersHelpers.GetCustomCreateParametersForAdl(testName);
                        Parallel.Invoke(
                            () => client.Clusters.Create(rgName, clusterName1, parameters1),
                            () => client.Clusters.Create(rgName, clusterName2, parameters2));

                        list = client.Clusters.ListByResourceGroup(rgName);
                        Assert.True(list.Any(c => c.Name.Equals(clusterName1, StringComparison.OrdinalIgnoreCase)));
                        Assert.True(list.Any(c => c.Name.Equals(clusterName2, StringComparison.OrdinalIgnoreCase)));
                    }
                    finally
                    {
                        client.Clusters.BeginDelete(rgName, clusterName1);
                        client.Clusters.BeginDelete(rgName, clusterName2);
                    }
                });
        }

        [Fact]
        public void TestListClustersInSubscription()
        {
            string suiteName = GetType().FullName;
            string testName = "TestListClustersInSubscription";
            using (MockContext context = MockContext.Start(suiteName, testName))
            {
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var resourceClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);

                string rgName1 = string.Empty;
                string rgName2 = string.Empty;
                string clusterName1 = "hdisdk-cluster-rg1";
                string clusterName2 = "hdisdk-cluster-rg2";
                try
                {
                    rgName1 = HDInsightManagementTestUtilities.CreateResourceGroup(resourceClient);
                    rgName2 = HDInsightManagementTestUtilities.CreateResourceGroup(resourceClient);

                    var list = client.Clusters.List();
                    Assert.False(list.Any(c => c.Name.Equals(clusterName1, StringComparison.OrdinalIgnoreCase)));
                    Assert.False(list.Any(c => c.Name.Equals(clusterName2, StringComparison.OrdinalIgnoreCase)));

                    // Create one cluster with ADLS so both clusters aren't using the same storage account at the same time
                    ClusterCreateParameters parameters1 = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);
                    ClusterCreateParameters parameters2 = ClusterCreateParametersHelpers.GetCustomCreateParametersForAdl(testName);
                    Parallel.Invoke(
                        () => client.Clusters.Create(rgName1, clusterName1, parameters1),
                        () => client.Clusters.Create(rgName2, clusterName2, parameters2));

                    list = client.Clusters.List();
                    Assert.True(list.Any(c => c.Name.Equals(clusterName1, StringComparison.OrdinalIgnoreCase)));
                    Assert.True(list.Any(c => c.Name.Equals(clusterName2, StringComparison.OrdinalIgnoreCase)));
                }
                finally
                {
                    resourceClient.ResourceGroups.BeginDelete(rgName1);
                    resourceClient.ResourceGroups.BeginDelete(rgName2);
                }
            }
        }
    }
}

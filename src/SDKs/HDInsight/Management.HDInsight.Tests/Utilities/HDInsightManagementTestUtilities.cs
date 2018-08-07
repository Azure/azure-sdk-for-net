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
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Xunit;

    internal static class HDInsightManagementTestUtilities
    {
        public static string DefaultLocation = "North Central US";

        public static void RunTestInNewResourceGroup(string suiteName, string testName, Action<ResourceManagementClient, HDInsightManagementClient, string> test)
        {
            using (MockContext context = MockContext.Start(suiteName, testName))
            {
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var resourceClient = GetResourceManagementClient(context, handler);
                var client = GetHDInsightManagementClient(context, handler);

                string rgName = string.Empty;
                try
                {
                    rgName = CreateResourceGroup(resourceClient);
                    test(resourceClient, client, rgName);
                }
                finally
                {
                    if (!string.IsNullOrEmpty(rgName))
                    {
                        resourceClient.ResourceGroups.BeginDelete(rgName);
                    }
                }
            }
        }

        public static void CreateClusterInNewResourceGroupAndRunTest(string suiteName, string testName, string clusterName, ClusterCreateParameters createParams, Action<HDInsightManagementClient, string> test)
        {
            RunTestInNewResourceGroup(suiteName, testName, (resClient, client, rgName) =>
            {
                try
                {
                    Cluster cluster = client.Clusters.Create(rgName, clusterName, createParams);
                    test(client, rgName);
                }
                finally
                {
                    try
                    {
                        client.Clusters.Get(rgName, clusterName);
                        client.Clusters.BeginDelete(rgName, clusterName);
                    }
                    catch(ErrorResponseException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                    }
                }
            });
        }

        public static void ValidateCluster(ClusterCreateParameters parameters, Cluster cluster, string clustername)
        {
            ClusterCreateParametersExtended extendedParams = CreateParametersConverter.GetExtendedClusterCreateParameters(clustername, parameters);
            ValidateCluster(extendedParams, cluster, clustername);
        }

        public static HDInsightManagementClient GetHDInsightManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<HDInsightManagementClient>(handlers:
                handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
            return client;
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return context.GetServiceClient<ResourceManagementClient>(false, new DelegatingHandler[] { handler });
        }

        public static bool IsRecordMode()
        {
            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            bool recordMode = !string.IsNullOrEmpty(testMode) && testMode.Equals("Record", StringComparison.OrdinalIgnoreCase);
            return recordMode;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient, string location = "")
        {
            if (string.IsNullOrEmpty(location))
            {
                location = DefaultLocation;
            }

            string rgname = TestUtilities.GenerateName("hdisdk");

            resourcesClient.ResourceGroups.CreateOrUpdate(
                rgname,
                new ResourceGroup
                {
                    Location = location
                });

            return rgname;
        }

        public static void ValidateCluster(ClusterCreateParametersExtended parameters, Cluster cluster, string clustername)
        {
            Assert.Equal(clustername, cluster.Name);
            Assert.Equal(parameters.Properties.Tier, cluster.Properties.Tier);
            Assert.NotNull(cluster.Etag);
            Assert.True(cluster.Id.EndsWith(clustername));
            Assert.Equal("Running", cluster.Properties.ClusterState);
            Assert.Equal("Microsoft.HDInsight/clusters", cluster.Type);
            Assert.Equal(parameters.Location, cluster.Location);
            Assert.Equal(parameters.Tags, cluster.Tags);
            Assert.Equal(1, cluster.Properties.ConnectivityEndpoints.Count(c => c.Name.Equals("HTTPS", StringComparison.OrdinalIgnoreCase)));
            Assert.Equal(1, cluster.Properties.ConnectivityEndpoints.Count(c => c.Name.Equals("SSH", StringComparison.OrdinalIgnoreCase)));
            Assert.Equal(parameters.Properties.OsType, cluster.Properties.OsType);
            Assert.Null(cluster.Properties.Errors);
            Assert.Equal(HDInsightClusterProvisioningState.Succeeded, cluster.Properties.ProvisioningState);
            Assert.Equal(parameters.Properties.ClusterDefinition.Kind, cluster.Properties.ClusterDefinition.Kind);
            Assert.Equal(parameters.Properties.ClusterVersion, cluster.Properties.ClusterVersion.Substring(0, 3));
            Assert.Null(cluster.Properties.ClusterDefinition.Configurations);
        }
    }
}

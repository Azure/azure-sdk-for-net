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

using System.Linq;
using System.Net;
using HDInsight.Tests.Helpers;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace HDInsight.Tests
{
    public class ResizeTests
    {
        //[Fact]
        public void TestResizeCluster()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname = "hdisdk-resizetest";

                var spec = GetClusterSpecHelpers.GetPaasClusterSpec();

                client.Clusters.Create(resourceGroup, dnsname, spec);

                var cluster = client.Clusters.Get(resourceGroup, dnsname);

                var resizeParams = new ClusterResizeParameters
                {
                    TargetInstanceCount = 2
                };

                client.Clusters.Resize(resourceGroup, dnsname, resizeParams);

                cluster = client.Clusters.Get(resourceGroup, dnsname);

                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }

        //[Fact]
        public void TestInvalidResizeClusterOperations()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname = "hdisdk-resize2";

                var spec = GetClusterSpecHelpers.GetPaasClusterSpec();

                client.Clusters.Create(resourceGroup, dnsname, spec);

                ResizeWithMissingTargetInstanceCount(client, resourceGroup, dnsname);
                ResizeToSameInstanceCount(client, resourceGroup, dnsname);
                ResizeWithOngoingResize(client, resourceGroup, dnsname);
            }
        }

        public void ResizeWithMissingTargetInstanceCount(HDInsightManagementClient client, string resourceGroup, string dnsname)
        {
            var resizeParams = new ClusterResizeParameters();

            try
            {
                client.Clusters.Resize(resourceGroup, dnsname, resizeParams);
            }
            catch (CloudException ex)
            {
                Assert.Equal(ex.Response.StatusCode, HttpStatusCode.BadRequest);
            }
        }

        public void ResizeToSameInstanceCount(HDInsightManagementClient client, string resourceGroup, string dnsname)
        {
            var cluster = client.Clusters.Get(resourceGroup, dnsname);
            var role = cluster.Cluster.Properties.ComputeProfile.Roles.FirstOrDefault(r => r.Name == "DataNode");
            Assert.NotNull(role);
            var targetInstanceCount = role.TargetInstanceCount;

            var resizeParams = new ClusterResizeParameters
            {
                TargetInstanceCount = targetInstanceCount
            };

            try
            {
                client.Clusters.Resize(resourceGroup, dnsname, resizeParams);
            }
            catch
            {
                
            }
        }

        public void ResizeWithOngoingResize(HDInsightManagementClient client, string resourceGroup, string dnsname)
        {
            var cluster = client.Clusters.Get(resourceGroup, dnsname);
            var role = cluster.Cluster.Properties.ComputeProfile.Roles.FirstOrDefault(r => r.Name == "workernode");
            Assert.NotNull(role);
            var targetInstanceCount = role.TargetInstanceCount;

            var resizeParams = new ClusterResizeParameters
            {
                TargetInstanceCount = targetInstanceCount + 1
            };

            client.Clusters.BeginResizing(resourceGroup, dnsname, resizeParams);

            try
            {
                client.Clusters.Resize(resourceGroup, dnsname, resizeParams);
            }
            catch
            {
                
            }
        }
    }
}

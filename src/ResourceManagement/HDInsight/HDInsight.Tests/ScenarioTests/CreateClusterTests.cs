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

using System.Net;
using HDInsight.Tests.Helpers;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace HDInsight.Tests
{
    public class CreateClusterTests
    {
        [Fact]
        public void TestPaasCreateGetDeleteCluster()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetPaasClusterSpec();
                const string dnsname = "hdisdk-paas";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);
                Assert.Equal(cluster.Location, createresponse.Cluster.Location);
                Assert.Equal(cluster.Properties.OperatingSystemType, createresponse.Cluster.Properties.OperatingSystemType);
                Assert.Equal(createresponse.Cluster.Properties.ErrorInfos.Count, 0);
                Assert.Equal(cluster.Properties.ClusterDefinition.ClusterType, createresponse.Cluster.Properties.ClusterDefinition.ClusterType);
                Assert.Equal(cluster.Properties.ClusterVersion, createresponse.Cluster.Properties.ClusterVersion.Substring(0, 3));

                Assert.Null(createresponse.Cluster.Properties.ClusterDefinition.Configurations);

                var getresponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.CreatedDate, getresponse.Cluster.Properties.CreatedDate);
                Assert.Equal(createresponse.Cluster.Name, getresponse.Cluster.Name);

                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                Assert.Equal(result.State, AsyncOperationState.Succeeded);
            }
        }

        //[Fact]
        public void TestIaasCreateGetDeleteCluster()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetIaasClusterSpec();
                const string dnsname = "hdisdk-iaascluster";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(cluster.Location, createresponse.Cluster.Location);
                Assert.Equal(cluster.Properties.ClusterDefinition.ClusterType, createresponse.Cluster.Properties.ClusterDefinition.ClusterType);
                //Assert.Equal(cluster.Properties.ClusterVersion, createresponse.Cluster.Properties.ClusterVersion);
                Assert.Null(createresponse.Cluster.Properties.ClusterDefinition.Configurations);
                Assert.Equal(createresponse.StatusCode, HttpStatusCode.OK);

                var getresponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.ComputeProfile.Roles.Count, getresponse.Cluster.Properties.ComputeProfile.Roles.Count);
                Assert.Equal(createresponse.Cluster.Properties.CreatedDate, getresponse.Cluster.Properties.CreatedDate);

                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                Assert.Equal(result.State, AsyncOperationState.Succeeded);
            }
        }

        [Fact]
        public void TestCreateWithEmptyParameters()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                try
                {
                    client.Clusters.Create(resourceGroup, "fakecluster", new ClusterCreateParametersExtended());
                }
                catch (CloudException ex)
                {
                    Assert.Equal(ex.Response.StatusCode, HttpStatusCode.BadRequest);
                }
            }
        }

        [Fact]
        public void TestCreateDuplicateCluster()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetPaasClusterSpec();
                const string dnsname = "hdisdk-clusterdupe";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                try
                {
                    client.Clusters.Create(resourceGroup, dnsname, cluster);
                }
                catch (CloudException ex)
                {
                    Assert.Equal(ex.Response.StatusCode, HttpStatusCode.Conflict);
                }

                OperationResource result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);               
                Assert.Equal(result.State, AsyncOperationState.Succeeded);
                
            }
        }

        //[Fact]
        public void TestCustomCreateEnableDisableConnectivity()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomCreateParametersPaas();
                const string dnsname = "hdisdk-testcluster1";
              
                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                var getresponse = client.Clusters.Get(resourceGroup, dnsname);
                
                client.Clusters.DisableHttp(resourceGroup, dnsname);
                getresponse = client.Clusters.Get(resourceGroup, dnsname);
                
                client.Clusters.EnableHttp(resourceGroup, dnsname, "hadoopuser", "Akasja2!1a");
                getresponse = client.Clusters.Get(resourceGroup, dnsname);
                
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                Assert.Equal(result.State, AsyncOperationState.Succeeded);

            }
        }

        [Fact]
        public void TestCreateLinuxClusterWithPremiumTier()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
                cluster.ClusterTier= Tier.Premium;
                const string dnsname = "hdisdk-LinuxClusterPremiumTest";
              
                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                var clusterResponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.ClusterTier , Tier.Premium);
                HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsname, client);
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                Assert.Equal(result.State, AsyncOperationState.Succeeded);
            }
        }

        [Fact]
        public void TestCreateLinuxClusterWithStandardTier()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
                cluster.ClusterTier = Tier.Standard;
                const string dnsname = "hdisdk-LinuxClusterStandardTest";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                var clusterResponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.ClusterTier, Tier.Standard);
                HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsname, client);
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                Assert.Equal(result.State, AsyncOperationState.Succeeded);
            }
        }

        [Fact]
        public void TestCreateWindowsClusterWithStandardTier()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetPaasClusterSpec();
                cluster.Properties.ClusterTier = Tier.Standard;
                const string dnsname = "hdisdk-IaasClusterStandardTierTest";             
                          
                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);

                Assert.Equal(dnsname, createresponse.Cluster.Name);
                var clusterResponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.ClusterTier, Tier.Standard);
                HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsname, client);
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                Assert.Equal(result.State, AsyncOperationState.Succeeded);
            }
        }

        [Fact]
        public void TestCreateWindowsClusterWithPremiumTier()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (var context = UndoContext.Current)
            {
                context.Start();
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                var cluster = GetClusterSpecHelpers.GetPaasClusterSpec();
                cluster.Properties.ClusterTier = Tier.Premium;
                const string dnsname = "hdisdk-WindowsClusterPremiumTest";
                try
                {
                    client.Clusters.Create(resourceGroup, dnsname, cluster);
                }
                catch (CloudException ex)
                {
                    Assert.Equal(ex.Response.StatusCode, HttpStatusCode.BadRequest);
                }
            }
        }

        [Fact]
        public void TestCreateHumboldtClusterWithSshUsernamePassword()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
                const string dnsname = "hdisdk-iaasclusternew";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                client.Clusters.Get(resourceGroup, dnsname);
                
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                Assert.Equal(result.State, AsyncOperationState.Succeeded);

            }
        }

        [Fact]
        public void TestCreateHumboldtClusterWithCustomVMSizes()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomVmSizesCreateParametersIaas();
                const string dnsname = "hdisdk-iaasclusternew-customvmsizes-2";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                client.Clusters.Get(resourceGroup, dnsname);

                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                Assert.Equal(result.State, AsyncOperationState.Succeeded);

            }
        }
    }
}
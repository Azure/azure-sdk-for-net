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
        public CreateClusterTests()
        {
            HyakTestUtilities.SetHttpMockServerMatcher();
        }

        [Fact]
        public void TestPaasCreateGetDeleteCluster()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetPaasClusterSpec();
                const string dnsname = "hdisdk-paas";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);
                Assert.Equal(cluster.Location, createresponse.Cluster.Location);
                Assert.Equal(cluster.Properties.OperatingSystemType, createresponse.Cluster.Properties.OperatingSystemType);
                Assert.Equal(0, createresponse.Cluster.Properties.ErrorInfos.Count);
                Assert.Equal(cluster.Properties.ClusterDefinition.ClusterType, createresponse.Cluster.Properties.ClusterDefinition.ClusterType);
                Assert.Equal(cluster.Properties.ClusterVersion, createresponse.Cluster.Properties.ClusterVersion.Substring(0, 3));

                Assert.Null(createresponse.Cluster.Properties.ClusterDefinition.Configurations);

                var getresponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.CreatedDate, getresponse.Cluster.Properties.CreatedDate);
                Assert.Equal(createresponse.Cluster.Name, getresponse.Cluster.Name);

                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);
            }
        }

        [Fact(Skip = "This test case will be skipped.")]
        public void TestIaasCreateGetDeleteCluster()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetIaasClusterSpec();
                const string dnsname = "hdisdk-iaascluster";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(cluster.Location, createresponse.Cluster.Location);
                Assert.Equal(cluster.Properties.ClusterDefinition.ClusterType, createresponse.Cluster.Properties.ClusterDefinition.ClusterType);
                //Assert.Equal(cluster.Properties.ClusterVersion, createresponse.Cluster.Properties.ClusterVersion);
                Assert.Null(createresponse.Cluster.Properties.ClusterDefinition.Configurations);
                Assert.Equal(HttpStatusCode.OK, createresponse.StatusCode);

                var getresponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.ComputeProfile.Roles.Count, getresponse.Cluster.Properties.ComputeProfile.Roles.Count);
                Assert.Equal(createresponse.Cluster.Properties.CreatedDate, getresponse.Cluster.Properties.CreatedDate);

                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);
            }
        }

        [Fact]
        public void TestAdJoinedIaasCreateGetDeleteCluster()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient, "East US 2");

                var cluster = GetClusterSpecHelpers.GetAdJoinedCreateParametersIaas();
                const string dnsname = "hdisdkadjoinediaascluster";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(cluster.Location, createresponse.Cluster.Location);
                Assert.Equal(cluster.ClusterType, createresponse.Cluster.Properties.ClusterDefinition.ClusterType);
                Assert.Null(createresponse.Cluster.Properties.ClusterDefinition.Configurations);
                Assert.Equal(HttpStatusCode.OK, createresponse.StatusCode);
                Assert.Equal(HDInsightClusterProvisioningState.Succeeded, createresponse.Cluster.Properties.ProvisioningState);
                Assert.Equal("Running", createresponse.Cluster.Properties.ClusterState);

                var getresponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.ComputeProfile.Roles.Count, getresponse.Cluster.Properties.ComputeProfile.Roles.Count);
                Assert.Equal(createresponse.Cluster.Properties.CreatedDate, getresponse.Cluster.Properties.CreatedDate);
                Assert.Equal(createresponse.Cluster.Properties.SecurityProfile.DirectoryType, getresponse.Cluster.Properties.SecurityProfile.DirectoryType);
                Assert.Equal(createresponse.Cluster.Properties.SecurityProfile.Domain, getresponse.Cluster.Properties.SecurityProfile.Domain);
                Assert.Equal(createresponse.Cluster.Properties.SecurityProfile.DomainUsername, getresponse.Cluster.Properties.SecurityProfile.DomainUsername);
                Assert.Equal(createresponse.Cluster.Properties.SecurityProfile.OrganizationalUnitDN, getresponse.Cluster.Properties.SecurityProfile.OrganizationalUnitDN);
                Assert.Equal(createresponse.Cluster.Properties.SecurityProfile.DirectoryType, getresponse.Cluster.Properties.SecurityProfile.DirectoryType);
                
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);
            }
        }

        [Fact]
        public void TestCreateWithEmptyParameters()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                try
                {
                    client.Clusters.Create(resourceGroup, "fakecluster", new ClusterCreateParametersExtended());
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
                }
            }
        }

        [Fact]
        public void TestCreateDuplicateCluster()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
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
                    Assert.Equal(HttpStatusCode.Conflict, ex.Response.StatusCode);
                }

                OperationResource result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);               
                Assert.Equal(AsyncOperationState.Succeeded, result.State);
                
            }
        }

        [Fact(Skip = "This test case will be skipped.")]
        public void TestCustomCreateEnableDisableConnectivity()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
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
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);

            }
        }

        [Fact]
        public void TestCreateLinuxClusterWithPremiumTier()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
                cluster.Version = "3.4";
                cluster.ClusterTier= Tier.Premium;
                const string dnsname = "hdisdk-LinuxClusterPremiumTest";
              
                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                var clusterResponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(Tier.Premium, createresponse.Cluster.Properties.ClusterTier);
                HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsname, client);
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);
            }
        }

        [Fact]
        public void TestCreateLinuxClusterWithStandardTier()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
                cluster.ClusterTier = Tier.Standard;
                const string dnsname = "hdisdk-LinuxClusterStandardTest";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                var clusterResponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(Tier.Standard, createresponse.Cluster.Properties.ClusterTier);
                HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsname, client);
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);
            }
        }

        [Fact]
        public void TestCreateWindowsClusterWithStandardTier()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetPaasClusterSpec();
                cluster.Properties.ClusterTier = Tier.Standard;
                const string dnsname = "hdisdk-IaasClusterStandardTierTest";             
                          
                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);

                Assert.Equal(dnsname, createresponse.Cluster.Name);
                var clusterResponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(Tier.Standard, createresponse.Cluster.Properties.ClusterTier);
                HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsname, client);
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);
            }
        }

        [Fact]
        public void TestCreateWindowsClusterWithPremiumTier()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
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
                    Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
                }
            }
        }

        [Fact]
        public void TestCreateHumboldtClusterWithSshUsernamePassword()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
                const string dnsname = "hdisdk-iaasclusternew";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                client.Clusters.Get(resourceGroup, dnsname);
                
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);

            }
        }

        [Fact]
        public void TestCreateHumboldtClusterWithCustomVMSizes()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomVmSizesCreateParametersIaas();
                const string dnsname = "hdisdk-iaasclusternew-customvmsizes-2";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                client.Clusters.Get(resourceGroup, dnsname);

                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);

            }
        }

        [Fact]
        public void TestCreateLinuxSparkClusterWithComponentVersion()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomCreateParametersSparkIaas();
                cluster.ClusterTier = Tier.Standard;
                const string dnsname = "hdisdk-SparkLinuxClusterComponentVersionTest";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                client.Clusters.Get(resourceGroup, dnsname);
                Assert.NotNull(createresponse.Cluster.Properties.ClusterDefinition.ComponentVersion);
                
                HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsname, client);
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);
            }
        }

        [Fact]
        public void TestCreateKafkaCluster()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomCreateParametersKafkaIaas();
                cluster.ClusterTier = Tier.Standard;
                const string dnsname = "hdisdk-KafkaCluster";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                client.Clusters.Get(resourceGroup, dnsname);
                Assert.NotNull(createresponse.Cluster.Properties.ClusterDefinition.ComponentVersion);

                HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsname, client);
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);
            }
        }

        [Fact]
        public void TestCreateKafkaClusterWithManagedDisks()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context,handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var cluster = GetClusterSpecHelpers.GetCustomCreateParametersKafkaIaasWithManagedDisks();
                cluster.ClusterTier = Tier.Standard;
                const string dnsname = "hdisdk-KafkaTestclusterWithManagedDisks";

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, cluster);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                client.Clusters.Get(resourceGroup, dnsname);
                Assert.NotNull(createresponse.Cluster.Properties.ClusterDefinition.ComponentVersion);

                HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsname, client);
                var getresult = client.Clusters.Get(resourceGroup, dnsname);
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(AsyncOperationState.Succeeded, result.State);

            }
        }
    }
}
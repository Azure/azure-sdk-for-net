// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Net;
using HDInsight.Tests.Helpers;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Test;
using Xunit;
using System.Collections.Generic;

namespace HDInsight.Tests
{
    public class DataLakeTests
    {
        //Since we are validating the fields these should have default values.
        private string ApplicationId = "11111111-1111-1111-1111-111111111111";
        private string AadTenantId = "11111111-1111-1111-1111-111111111111";
        private byte[] CertificateFileBytes = { };
        private string CertificatePassword = "";
        private string ResourceUri = "";
        
        [Fact]
        public void TestCreateDataLakeClusterUsingClusterCreateParametersExtended()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                //get clients
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

                //create resourcegroup
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                //set variables
                const string dnsname = "hdisdk-datalake5";

                var spec = GetDataLakeClusterParametersExtended();

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, spec);

                //TODO: Assert if data lake configurations are set once shefali adds GetConfigurations support
                var getresponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.CreatedDate, getresponse.Cluster.Properties.CreatedDate);
                Assert.Equal(createresponse.Cluster.Name, getresponse.Cluster.Name);

                OperationResource result = client.Clusters.Delete(resourceGroup, dnsname);
            }
        }

        private ClusterCreateParametersExtended GetDataLakeClusterParametersExtended()
        {
            var cluster = GetClusterSpecHelpers.GetPaasClusterSpec();

            var dataLakeConfigs = new Dictionary<string, string>
            {
                {"clusterIdentity.applicationId", ApplicationId},
                {"clusterIdentity.aadTenantId", AadTenantId},
                {"clusterIdentity.certificate", Convert.ToBase64String(CertificateFileBytes)},
                {"clusterIdentity.certificatePassword", CertificatePassword},
                {"clusterIdentity.resourceUri", ResourceUri}
            };

            var spec = GetClusterSpecHelpers.AddConfigurations(cluster, ConfigurationKey.ClusterIdentity, dataLakeConfigs);
            spec.Properties.ClusterVersion = "3.2";
            return spec;
        }

        [Fact]
        public void TestCreateDataLakeClusterUsingClusterParameters()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                //get clients
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

                //create resourcegroup
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                //set variables
                const string dnsname = "hdisdk-datalake5";

                var clusterCreateParams = GetDataLakeClusterParameters();

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, clusterCreateParams);
                Assert.Equal(dnsname, createresponse.Cluster.Name);

                //TODO: Assert if data lake configurations are set once shefali adds GetConfigurations support
                var getresponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.CreatedDate, getresponse.Cluster.Properties.CreatedDate);
                Assert.Equal(createresponse.Cluster.Name, getresponse.Cluster.Name);

                // Assert cluster state
                Assert.Equal(createresponse.Cluster.Properties.ClusterState, "Error"); // due to invalid script action
                Assert.Equal(createresponse.Cluster.Properties.ErrorInfos.Count, 1);

                // delete the cluster
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                Assert.Equal(result.State, AsyncOperationState.Succeeded);
            }
        }

        [Fact]
        public void TestCreateDefaultFsDataLakeClusterUsingClusterParameters()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                //get clients
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

                //create resourcegroup
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                //set variables
                const string dnsname = "hdisdk-defaultfsdatalake1";

                var clusterCreateParams = GetDefaultFsDatalakeClusterParameters();

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, clusterCreateParams);
                Assert.Equal(dnsname, createresponse.Cluster.Name);
                Assert.Equal("Running", createresponse.Cluster.Properties.ClusterState);
                
                var getresponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.CreatedDate, getresponse.Cluster.Properties.CreatedDate);
                Assert.Equal(createresponse.Cluster.Name, getresponse.Cluster.Name);

                // delete the cluster
                var result = client.Clusters.Delete(resourceGroup, dnsname);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                Assert.Equal(result.State, AsyncOperationState.Succeeded);
            }
        }

        /// <summary>
        /// ClusterCreateParameters used for DataLake default FS
        /// </summary>
        /// <returns></returns>
        private ClusterCreateParameters GetDefaultFsDatalakeClusterParameters()
        {
            var clusterCreateParams = GetClusterSpecHelpers.GetDataLakeDefaultFsCreateParametersIaas();
            clusterCreateParams.Principal = new ServicePrincipal(new Guid(ApplicationId), new Guid(AadTenantId), 
                                                                    CertificateFileBytes, CertificatePassword);
            return clusterCreateParams;
        }

        /// <summary>
        /// ClusterCreateParameters used for DataLake additional FS
        /// </summary>
        /// <returns></returns>
        private ClusterCreateParameters GetDataLakeClusterParameters()
        {
            var clusterCreateParams = GetClusterSpecHelpers.GetCustomCreateParametersPaas();
            clusterCreateParams.Principal = new ServicePrincipal(new Guid(ApplicationId), new Guid(AadTenantId), 
                                                                    CertificateFileBytes, CertificatePassword);
            return clusterCreateParams;
        }
    }
}

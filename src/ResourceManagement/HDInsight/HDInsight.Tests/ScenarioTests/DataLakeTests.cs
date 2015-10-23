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
                {"clusteridentity.resourceUri", ResourceUri}
            };

            var spec = GetClusterSpecHelpers.AddConfigurations(cluster, ConfigurationKey.ClusterIdentity, dataLakeConfigs);
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

                var spec = GetDataLakeClusterParameters();

                var createresponse = client.Clusters.Create(resourceGroup, dnsname, spec);

                //TODO: Assert if data lake configurations are set once shefali adds GetConfigurations support
                var getresponse = client.Clusters.Get(resourceGroup, dnsname);
                Assert.Equal(createresponse.Cluster.Properties.CreatedDate, getresponse.Cluster.Properties.CreatedDate);
                Assert.Equal(createresponse.Cluster.Name, getresponse.Cluster.Name);
            }
        }

        private ClusterCreateParameters GetDataLakeClusterParameters()
        {
            var spec = GetClusterSpecHelpers.GetCustomCreateParametersPaas();

            ServicePrincipal servicePrincipal = new ServicePrincipal(new Guid(ApplicationId), new Guid(AadTenantId), CertificateFileBytes,
                CertificatePassword);
            spec.Principal = servicePrincipal;
            return spec;
        }
    }
}

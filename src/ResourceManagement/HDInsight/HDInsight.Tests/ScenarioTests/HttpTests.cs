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

using System;
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
    public class HttpTests
    {
        public HttpTests()
        {
            HyakTestUtilities.SetHttpMockServerMatcher();
        }

        [Fact]
        [Obsolete]
        public void TestDisableEnableHttp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname = "hdisdk-httptest2";

                var spec = GetClusterSpecHelpers.GetPaasClusterSpec();

                client.Clusters.Create(resourceGroup, dnsname, spec);

                var httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.True(httpSettings.HttpUserEnabled);

                var httpParams = new HttpSettingsParameters
                {
                    HttpUserEnabled = false,
                };

                client.Clusters.ConfigureHttpSettings(resourceGroup, dnsname, httpParams);
                httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.False(httpSettings.HttpUserEnabled);

                httpParams = new HttpSettingsParameters
                {
                    HttpUserEnabled = true,
                    HttpUsername = "admin",
                    HttpPassword = "Password1!"
                };

                client.Clusters.ConfigureHttpSettings(resourceGroup, dnsname, httpParams);
                httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.True(httpSettings.HttpUserEnabled);

                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }

        [Fact]
        [Obsolete]
        public void TestEnableEnableHttp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname = "hdisdk-httptest3";

                var spec = GetClusterSpecHelpers.GetPaasClusterSpec();

                client.Clusters.Create(resourceGroup, dnsname, spec);

                var httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);

                Assert.True(httpSettings.HttpUserEnabled);
                
                var httpParams = new HttpSettingsParameters
                {
                    HttpUserEnabled = true,
                    HttpUsername = "admin",
                    HttpPassword = "Password1!"
                };

                try
                {
                    client.Clusters.ConfigureHttpSettings(resourceGroup, dnsname, httpParams);
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.Conflict, ex.Response.StatusCode);
                }
                httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.True(httpSettings.HttpUserEnabled);

                var result = client.Clusters.Delete(resourceGroup, dnsname);
                //Assert.Equal(result.StatusCode, HttpStatusCode.NoContent);
            }
        }

        [Fact]
        [Obsolete]
        public void TestEnableDisableDisableHttp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname = "hdisdk-httptest3";

                var spec = GetClusterSpecHelpers.GetPaasClusterSpec();

                var cluster = client.Clusters.Create(resourceGroup, dnsname, spec);

                string errorMessage = cluster.Cluster.Properties.ErrorInfos.Any()
                    ? cluster.Cluster.Properties.ErrorInfos[0].Message
                    : String.Empty;

                Assert.True(cluster.Cluster.Properties.ClusterState.Equals("Running", StringComparison.OrdinalIgnoreCase),
                    String.Format("Cluster Creation Failed ErrorInfo: {0}", errorMessage));

                HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsname, client);

                var httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.True(httpSettings.HttpUserEnabled);

                var httpParams = new HttpSettingsParameters
                {
                    HttpUserEnabled = false,
                };

                client.Clusters.ConfigureHttpSettings(resourceGroup, dnsname, httpParams);
                httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.False(httpSettings.HttpUserEnabled);
                
                client.Clusters.ConfigureHttpSettings(resourceGroup, dnsname, httpParams);

                httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.False(httpSettings.HttpUserEnabled);

                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }

        [Fact]
        [Obsolete]
        public void TestDisableEnableHttpCustomCode()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname = "hdisdk-httptest3";

                var spec = GetClusterSpecHelpers.GetPaasClusterSpec();

                client.Clusters.Create(resourceGroup, dnsname, spec);

                var httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.True(httpSettings.HttpUserEnabled);

                client.Clusters.DisableHttp(resourceGroup, dnsname);
                httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.False(httpSettings.HttpUserEnabled);

                client.Clusters.EnableHttp(resourceGroup, dnsname, "admin", "Password1!");
                httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.True(httpSettings.HttpUserEnabled);

                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }

        [Fact]
        public void TestHttpGetGatewaySettings()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname = "hdisdk-httptest4";

                var clusterParams = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
                clusterParams.Version = "3.6";
                clusterParams.Location = "North Central US";

                client.Clusters.Create(resourceGroup, dnsname, clusterParams);

                var httpGatewaySettings = client.Clusters.GetGatewaySettings(resourceGroup, dnsname);
                Assert.True(httpGatewaySettings.HttpUserEnabled);
                Assert.Equal("admin", httpGatewaySettings.HttpUsername);
                Assert.Equal("test123!", httpGatewaySettings.HttpPassword);

                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }

        [Fact]
        public void TestHttpUpdateGatewaySettings()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                const string dnsname = "hdisdk-httptest5";

                var clusterParams = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
                clusterParams.Version = "3.6";
                clusterParams.Location = "North Central US";

                client.Clusters.Create(resourceGroup, dnsname, clusterParams);

                var gatewayParams = new HttpSettingsParameters
                {
                    HttpUserEnabled = true,
                    HttpUsername = "admin",
                    HttpPassword = "Password2!"
                };

                var result = client.Clusters.UpdateGatewaySettings(resourceGroup, dnsname, gatewayParams);
                Assert.Equal( HttpStatusCode.OK, result.StatusCode);

                var httpGatewaySettings = client.Clusters.GetGatewaySettings(resourceGroup, dnsname);
                Assert.Equal(gatewayParams.HttpUserEnabled, httpGatewaySettings.HttpUserEnabled);
                Assert.Equal(gatewayParams.HttpUsername, httpGatewaySettings.HttpUsername);
                Assert.Equal(gatewayParams.HttpPassword, httpGatewaySettings.HttpPassword);

                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }

        [Fact]
        public void TestHttpListConfigurationsSettings()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                const string dnsname = "hdisdk-httptest6";
                var clusterparams = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
                clusterparams.Version = "3.6";
                clusterparams.Location = "North Central US";

                client.Clusters.Create(resourceGroup, dnsname, clusterparams);

                var clusterConfigurations = client.Clusters.ListConfigurations(resourceGroup, dnsname);

                var coreSite = clusterConfigurations.Configurations["core-site"];
                var gateway = clusterConfigurations.Configurations["gateway"];

                Assert.NotEmpty(coreSite.Configuration["fs.defaultFS"]);
                Assert.NotEmpty(gateway.Configuration["restAuthCredential.isEnabled"]);

                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }
    }
}

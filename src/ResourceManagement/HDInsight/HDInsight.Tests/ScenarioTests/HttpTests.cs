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
    public class HttpTests
    {
        [Fact]
        public void TestDisableEnableHttp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

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
        public void TestEnableEnableHttp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname = "hdisdk-httptest2";

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
                    Assert.Equal(ex.Response.StatusCode, HttpStatusCode.Conflict);
                }
                httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.True(httpSettings.HttpUserEnabled);

                var result = client.Clusters.Delete(resourceGroup, dnsname);
                //Assert.Equal(result.StatusCode, HttpStatusCode.NoContent);
            }
        }

        [Fact]
        public void TestEnableDisableDisableHttp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname = "hdisdk-httptest3";

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
                
                client.Clusters.ConfigureHttpSettings(resourceGroup, dnsname, httpParams);

                httpSettings = client.Clusters.GetConnectivitySettings(resourceGroup, dnsname);
                Assert.False(httpSettings.HttpUserEnabled);

                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }

        [Fact]
        public void TestDisableEnableHttpCustomCode()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

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
    }
}

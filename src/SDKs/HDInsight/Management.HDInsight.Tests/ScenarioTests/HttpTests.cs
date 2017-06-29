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
    using Microsoft.Azure.Management.HDInsight.Models;
    using Microsoft.HDInsight;
    using Microsoft.HDInsight.Models;
    using Microsoft.Rest.Azure;
    using Xunit;

    public class HttpTests
    {
        [Fact]
        public void TestDisableEnableDisableHttpCustom()
        {
            string clusterName = "hdisdk-httpcustom";
            string testName = "CanDisableEnableDisableHttpCustom";
            string suiteName = GetType().FullName;
            ClusterCreateParameters createParams = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas();

            HDInsightManagementTestUtilities.CreateClusterInNewResourceGroupAndRunTest(suiteName, testName,clusterName, createParams, (client, rgName) =>
            {
                HttpConnectivitySettings httpSettings = client.Configurations.Get(rgName, clusterName, ConfigurationName.Gateway);
                ValidateHttpSettings(httpSettings, createParams.UserName, createParams.Password);

                CloudException ex = Assert.Throws<CloudException>(() => client.Configurations.DisableHttp(rgName, clusterName));
                Assert.Equal("Linux clusters do not support revoking HTTP credentials.", ex.Message);

                string newPassword = "NewPassword1!";
                client.Configurations.EnableHttp(rgName, clusterName, "admin", newPassword);
                httpSettings = client.Configurations.Get(rgName, clusterName, ConfigurationName.Gateway);
                ValidateHttpSettings(httpSettings, createParams.UserName, newPassword);
            });
        }

        [Fact]
        public void TestDisableEnableDisableHttpExtended()
        {
            string clusterName = "hdisdk-http";
            string testName = "CanDisableEnableDisableHttpExtended";
            string suiteName = GetType().FullName;
            ClusterCreateParameters createParams = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas();

            HDInsightManagementTestUtilities.CreateClusterInNewResourceGroupAndRunTest(suiteName, testName, clusterName, createParams, (client, rgName) =>
            {
                var httpSettings = client.Configurations.Get(rgName, clusterName, ConfigurationName.Gateway);
                ValidateHttpSettings(httpSettings, createParams.UserName, createParams.Password);

                CloudException ex = Assert.Throws<CloudException>(() => client.Configurations.UpdateHTTPSettings(rgName, clusterName,
                    new HttpConnectivitySettings { EnabledCredential = false }));
                Assert.Equal("Linux clusters do not support revoking HTTP credentials.", ex.Message);

                string newPassword = "NewPassword1!";
                client.Configurations.UpdateHTTPSettings(rgName, clusterName,
                    new HttpConnectivitySettings
                    {
                        EnabledCredential = true,
                        Username = "admin",
                        Password = newPassword
                    });
                httpSettings = client.Configurations.Get(rgName, clusterName, ConfigurationName.Gateway);
                ValidateHttpSettings(httpSettings, createParams.UserName, newPassword);
            });
        }

        private void ValidateHttpSettings(HttpConnectivitySettings httpSettings, string expectedUsername, string expectedPassword)
        {
            Assert.NotNull(httpSettings);
            Assert.True(httpSettings.EnabledCredential);
            Assert.Equal(expectedUsername, httpSettings.Username);
            Assert.Equal(expectedPassword, httpSettings.Password);
        }
    }
}

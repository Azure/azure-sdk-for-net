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
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Xunit;

    [Collection("ScenarioTests")]
    public class HttpTests
    {
        [Fact]
        public void TestHttpCustom()
        {
            string clusterName = "hdisdk-httpcustom";
            string testName = "CanDisableEnableDisableHttpCustom";
            string suiteName = GetType().FullName;
            ClusterCreateParameters createParams = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);

            HDInsightManagementTestUtilities.CreateClusterInNewResourceGroupAndRunTest(suiteName, testName,clusterName, createParams, (client, rgName) =>
            {
                IDictionary<string, string> httpSettings = client.Configurations.Get(rgName, clusterName, ConfigurationKey.Gateway);
                ValidateHttpSettings(httpSettings, createParams.UserName, createParams.Password);
                
                string newPassword = "NewPassword1!";
                client.Configurations.EnableHttp(rgName, clusterName, "admin", newPassword);
                httpSettings = client.Configurations.Get(rgName, clusterName, ConfigurationKey.Gateway);
                ValidateHttpSettings(httpSettings, createParams.UserName, newPassword);
            });
        }

        [Fact]
        public void TestHttpExtended()
        {
            string clusterName = "hdisdk-http";
            string testName = "CanDisableEnableDisableHttpExtended";
            string suiteName = GetType().FullName;
            ClusterCreateParameters createParams = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);

            HDInsightManagementTestUtilities.CreateClusterInNewResourceGroupAndRunTest(suiteName, testName, clusterName, createParams, (client, rgName) =>
            {
                var httpSettings = client.Configurations.Get(rgName, clusterName, ConfigurationKey.Gateway);
                ValidateHttpSettings(httpSettings, createParams.UserName, createParams.Password);
                
                string newPassword = "NewPassword1!";
                client.Configurations.UpdateHTTPSettings(rgName, clusterName, ConfigurationKey.Gateway,
                    ConfigurationsConverter.Convert(new HttpConnectivitySettings
                    {
                        EnabledCredential = "true",
                        Username = "admin",
                        Password = newPassword
                    }));
                httpSettings = client.Configurations.Get(rgName, clusterName, ConfigurationKey.Gateway);
                ValidateHttpSettings(httpSettings, createParams.UserName, newPassword);
            });
        }

        private void ValidateHttpSettings(IDictionary<string, string> httpSettings, string expectedUsername, string expectedPassword)
        {
            Assert.NotNull(httpSettings);
            HttpConnectivitySettings settings = JsonConvert.DeserializeObject<HttpConnectivitySettings>(JsonConvert.SerializeObject(httpSettings));
            Assert.Equal("true", settings.EnabledCredential);
            Assert.Equal(expectedUsername, settings.Username);
            Assert.Equal(expectedPassword, settings.Password);
        }
    }
}

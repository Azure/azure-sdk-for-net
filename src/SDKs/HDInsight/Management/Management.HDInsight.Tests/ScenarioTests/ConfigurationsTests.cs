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
    using Xunit;
    using Microsoft.Azure.Management.HDInsight;
    using Microsoft.Azure.Management.HDInsight.Models;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Collection("ScenarioTests")]
    public class ConfigurationsTests
    {
        [Fact]
        public void TestGetConfigurations()
        {
            string clusterName = "hdisdk-configs";
            string testName = "TestGetConfigurations";
            string suiteName = GetType().FullName;
            ClusterCreateParameters createParams = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);

            Dictionary<string, string> hiveConfig = new Dictionary<string, string>
            {
                {"key1", "value1" },
                {"key2", "value2" }
            };
            Dictionary<string, string> mapredConfig = new Dictionary<string, string>
            {
                {"key5", "value5" },
                {"key6", "value6" }
            };
            Dictionary<string, string> yarnConfig = new Dictionary<string, string>
            {
                {"key7", "value7" },
                {"key8", "value8" }
            };
            createParams.Configurations.Add(ConfigurationKey.HiveSite, hiveConfig);
            createParams.Configurations.Add(ConfigurationKey.MapRedSite, mapredConfig);
            createParams.Configurations.Add(ConfigurationKey.YarnSite, yarnConfig);

            HDInsightManagementTestUtilities.CreateClusterInNewResourceGroupAndRunTest(suiteName, testName, clusterName, createParams, (client, rgName) =>
            {
                var hive = client.Configurations.Get(rgName, clusterName, ConfigurationKey.HiveSite);
                Assert.Equal(hiveConfig, hive);

                var mapred = client.Configurations.Get(rgName, clusterName, ConfigurationKey.MapRedSite);
                Assert.Equal(mapredConfig, mapred);

                var yarn = client.Configurations.Get(rgName, clusterName, ConfigurationKey.YarnSite);
                Assert.Equal(yarnConfig, yarn);

                var gateway = client.Configurations.Get(rgName, clusterName, ConfigurationKey.Gateway);
                Assert.Equal(3, gateway.Count);
                HttpConnectivitySettings settings = JsonConvert.DeserializeObject<HttpConnectivitySettings>(JsonConvert.SerializeObject(gateway));
                Assert.NotNull(settings);
                
                var core = client.Configurations.Get(rgName, clusterName, ConfigurationKey.CoreSite);
                Assert.Equal(2, core.Count);
                Assert.True(core.ContainsKey(Constants.StorageConfigurations.DefaultFsKey));
                string storageKeyFormat = Constants.StorageConfigurations.WasbStorageAccountKeyFormat;
                string storageKeyPrefix = storageKeyFormat.Substring(0, storageKeyFormat.IndexOf("{"));
                Assert.Contains(core, c => c.Key.StartsWith(storageKeyPrefix));
            });
        }
    }
}

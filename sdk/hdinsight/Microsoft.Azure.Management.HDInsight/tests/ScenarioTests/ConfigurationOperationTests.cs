// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;
using static Management.HDInsight.Tests.HDInsightManagementTestUtilities;

namespace Management.HDInsight.Tests
{
    public class ConfigurationOperationTests : HDInsightManagementTestBase
    {
        [Fact]
        public void TestGetConfigurations()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-configs");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var hiveConfig = new Dictionary<string, string>
            {
                {"key1", "value1" },
                {"key2", "value2" }
            };

            var mapredConfig = new Dictionary<string, string>
            {
                {"key5", "value5" },
                {"key6", "value6" }
            };

            var yarnConfig = new Dictionary<string, string>
            {
                {"key7", "value7" },
                {"key8", "value8" }
            };

            var configurations = (Dictionary<string, Dictionary<string, string>>)createParams.Properties.ClusterDefinition.Configurations;
            configurations.Add(ConfigurationKey.HiveSite, hiveConfig);
            configurations.Add(ConfigurationKey.MapRedSite, mapredConfig);
            configurations.Add(ConfigurationKey.YarnSite, yarnConfig);

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            var hive = HDInsightClient.Configurations.Get(CommonData.ResourceGroupName, clusterName, ConfigurationKey.HiveSite);
            Assert.Equal(hiveConfig, hive);

            var mapred = HDInsightClient.Configurations.Get(CommonData.ResourceGroupName, clusterName, ConfigurationKey.MapRedSite);
            Assert.Equal(mapredConfig, mapred);

            var yarn = HDInsightClient.Configurations.Get(CommonData.ResourceGroupName, clusterName, ConfigurationKey.YarnSite);
            Assert.Equal(yarnConfig, yarn);

            var core = HDInsightClient.Configurations.Get(CommonData.ResourceGroupName, clusterName, ConfigurationKey.CoreSite);
            Assert.Equal(2, core.Count);
            Assert.True(core.ContainsKey(Constants.StorageConfigurations.DefaultFsKey));
            Assert.Contains(core, c => c.Key.StartsWith("fs.azure.account.key."));

            var configs = HDInsightClient.Configurations.List(CommonData.ResourceGroupName, clusterName);
            Assert.NotNull(configs);
            Assert.Equal(hiveConfig, configs.Configurations[ConfigurationKey.HiveSite]);
            Assert.Equal(mapredConfig, configs.Configurations[ConfigurationKey.MapRedSite]);
            Assert.Equal(yarnConfig, configs.Configurations[ConfigurationKey.YarnSite]);
            Assert.Equal(configurations[ConfigurationKey.Gateway], configs.Configurations[ConfigurationKey.Gateway]);
            Assert.Equal(2, core.Count);
            Assert.True(core.ContainsKey(Constants.StorageConfigurations.DefaultFsKey));
            Assert.Contains(core, c => c.Key.StartsWith("fs.azure.account.key."));
        }
    }
}

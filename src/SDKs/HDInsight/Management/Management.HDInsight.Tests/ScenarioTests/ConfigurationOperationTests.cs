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

            string clusterName = TestUtilities.GenerateName("hdisdk-humboldt");
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

            var gateway = HDInsightClient.Configurations.Get(CommonData.ResourceGroupName, clusterName, ConfigurationKey.Gateway);
            Assert.Equal(3, gateway.Count);

            var core = HDInsightClient.Configurations.Get(CommonData.ResourceGroupName, clusterName, ConfigurationKey.CoreSite);
            Assert.Equal(2, core.Count);
            Assert.True(core.ContainsKey(Constants.StorageConfigurations.DefaultFsKey));
            Assert.Contains(core, c => c.Key.StartsWith("fs.azure.account.key."));
        }

        [Fact]
        public void TestHttpExtended()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-http");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            string expectedUserName = CommonData.ClusterUserName;
            string expectedPassword = CommonData.ClusterPassword;
            var httpSettings = HDInsightClient.Configurations.Get(CommonData.ResourceGroupName, clusterName, ConfigurationKey.Gateway);
            ValidateHttpSettings(expectedUserName, expectedPassword, httpSettings);

            string newExpectedPassword = "NewPassword1!";
            var updateParams = new Dictionary<string, string>
            {
                {  "restAuthCredential.isEnabled", "true" },
                {  "restAuthCredential.username", expectedUserName },
                {  "restAuthCredential.password", newExpectedPassword }
            };

            HDInsightClient.Configurations.Update(CommonData.ResourceGroupName, clusterName, ConfigurationKey.Gateway, updateParams);
            httpSettings = HDInsightClient.Configurations.Get(CommonData.ResourceGroupName, clusterName, ConfigurationKey.Gateway);
            ValidateHttpSettings(expectedUserName, newExpectedPassword, httpSettings);
        }
    }
}

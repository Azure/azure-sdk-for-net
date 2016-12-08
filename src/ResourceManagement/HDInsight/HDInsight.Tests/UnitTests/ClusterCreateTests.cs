using Microsoft.Azure.Management.HDInsight;
using System.Collections.Generic;
using Xunit;
using Microsoft.Azure.Management.HDInsight.Models;
using Newtonsoft.Json;

namespace HDInsight.Tests.UnitTests
{
    public class ClusterCreateTests
    {
        [Fact]
        public void TestCreateDefaultFsAzureBlobClusterUsingClusterParameters()
        {
            string clusterName = "cluster";
            string storageContainerName = "storageContainer";

            var clusterCreateParams = new ClusterCreateParameters { 
                ClusterSizeInNodes = 3,
                ClusterType = "Hadoop",
                WorkerNodeSize = "Large",
                DefaultStorageInfo = new AzureStorageInfo("storageAccountName", "storageAccountKey", storageContainerName),
                OSType = OSType.Linux,
                UserName = "HttpUser",
                Password = "HttpPassword",
                Location = "East US",
                SshUserName = "SshUser",
                SshPassword = "SshPassword",
                Version = "3.2"
            };

            ClusterOperations op = new ClusterOperations(new HDInsightManagementClient());
            var extendedParams = op.GetExtendedClusterCreateParameters(clusterName, clusterCreateParams);
            AssertContainerMatchesNameProvided(extendedParams, storageContainerName);
        }

        [Fact]
        public void TestCreateDefaultFsAzureBlobClusterContainerNotSpecified()
        {
            string clusterName = "cluster";

            var clusterCreateParams = new ClusterCreateParameters
            {
                ClusterSizeInNodes = 3,
                ClusterType = "Hadoop",
                WorkerNodeSize = "Large",
                DefaultStorageInfo = new AzureStorageInfo("storageAccountName", "storageAccountKey"),
                OSType = OSType.Linux,
                UserName = "HttpUser",
                Password = "HttpPassword",
                Location = "East US",
                SshUserName = "SshUser",
                SshPassword = "SshPassword",
                Version = "3.2"
            };

            ClusterOperations op = new ClusterOperations(new HDInsightManagementClient());
            var extendedParams = op.GetExtendedClusterCreateParameters(clusterName, clusterCreateParams);
            AssertContainerMatchesNameProvided(extendedParams, clusterName);
        }

        private void AssertContainerMatchesNameProvided(ClusterCreateParametersExtended createParamsExtended, string name)
        {
            Dictionary<string,string> coresiteConfig;
            if (JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(createParamsExtended.Properties.ClusterDefinition.Configurations).TryGetValue("core-site", out coresiteConfig))
            {
                string value;
                coresiteConfig.TryGetValue("fs.defaultFS", out value);
                Assert.True(value.StartsWith("wasb://" + name + "@"), "Container does not match the name provided");
            }
            else
            {
                Assert.True(false, "Deserialization error");
            }
        }
    }
}

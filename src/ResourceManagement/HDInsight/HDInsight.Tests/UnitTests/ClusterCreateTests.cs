using Microsoft.Azure.Management.HDInsight;
using System.Collections.Generic;
using Xunit;
using Microsoft.Azure.Management.HDInsight.Models;
using Newtonsoft.Json;

namespace HDInsight.Tests.UnitTests
{
    public class ClusterCreateTests
    {
        public ClusterCreateTests()
        {
        }

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
            Assert.True(ContainerMatchesNameProvided(extendedParams, storageContainerName), "Container name does not match the one specified");
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
            Assert.True(ContainerMatchesNameProvided(extendedParams, clusterName), "Container name does not match the cluster name");
        }

        private bool ContainerMatchesNameProvided(ClusterCreateParametersExtended x, string name)
        {
            Dictionary<string,string> coresiteConfig;
            if(JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(x.Properties.ClusterDefinition.Configurations).TryGetValue("core-site", out coresiteConfig))
            {
                string value;
                coresiteConfig.TryGetValue("fs.defaultFS", out value);
                return value.StartsWith("wasb://" + name + "@");
            }
            return false;
        }
    }
}

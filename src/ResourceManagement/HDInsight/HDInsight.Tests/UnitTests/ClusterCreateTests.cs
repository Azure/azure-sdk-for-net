using Microsoft.Azure.Management.HDInsight;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using Microsoft.Azure.Management.HDInsight.Models;
using Newtonsoft.Json;
using HDInsight.Tests.Helpers;

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

        [Fact]
        public void TestCreateLinuxDevSkuCluster()
        {
            string clusterName = "hdisdk-SandboxLinuxClusterTest";
            var clusterCreateParams = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
            clusterCreateParams.ClusterType = "Sandbox";
            clusterCreateParams.Version = "3.5";

            ClusterOperations op = new ClusterOperations(new HDInsightManagementClient());
            var extendedParams = op.GetExtendedClusterCreateParameters(clusterName, clusterCreateParams);
            Assert.Equal(1, extendedParams.Properties.ComputeProfile.Roles.Count);
            Assert.Equal("Standard_D13_V2", extendedParams.Properties.ComputeProfile.Roles[0].HardwareProfile.VmSize);
            Assert.Equal("headnode", extendedParams.Properties.ComputeProfile.Roles[0].Name);
            Assert.Equal(1, extendedParams.Properties.ComputeProfile.Roles[0].TargetInstanceCount);            
        }

        [Fact]
        public void TestCreateRserverDefaultNodeSizesValues()
        {
            var clusterCreateParams = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
            clusterCreateParams.ClusterType = "RServer";
            clusterCreateParams.Version = "3.5";
            clusterCreateParams.WorkerNodeSize = null;
            clusterCreateParams.HeadNodeSize = null;

            ClusterOperations op = new ClusterOperations(new HDInsightManagementClient());
            var extendedParams = op.GetExtendedClusterCreateParameters("hdisdk-RServerClusterEdgeNodeDefaultTest", clusterCreateParams);

            List<Role> roles = new List<Role>(extendedParams.Properties.ComputeProfile.Roles);
            ValidateRole(roles, "headnode", "Standard_D12_v2");
            ValidateRole(roles, "workernode", "Standard_D4_v2", clusterCreateParams.ClusterSizeInNodes);
            ValidateRole(roles, "edgenode", "Standard_D4_v2", 1);
            ValidateRole(roles, "zookeepernode", "Medium");
        }

        [Fact]
        public void TestCreateRserverEdgeNodeSpecified()
        {
            const string edgeNodeSizeToTest = "Standard_D12_v2";

            var clusterCreateParams = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
            clusterCreateParams.ClusterType = "RServer";
            clusterCreateParams.EdgeNodeSize = edgeNodeSizeToTest;
            clusterCreateParams.Version = "3.5";

            ClusterOperations op = new ClusterOperations(new HDInsightManagementClient());
            var extendedParams = op.GetExtendedClusterCreateParameters("hdisdk-RServerClusterEdgeNodeSpecifiedTest", clusterCreateParams);

            List<Role> roles = new List<Role>(extendedParams.Properties.ComputeProfile.Roles);
            ValidateRole(roles, "edgenode", edgeNodeSizeToTest, 1);
        }

        private void ValidateRole(List<Role> roles, string roleName, string roleVmSize, int roleInstanceCount = -1)
        {
            var roleToValidate = roles.FirstOrDefault(r => r.Name.Equals(roleName, System.StringComparison.OrdinalIgnoreCase));
            Assert.True(roleToValidate != null);

            Assert.Equal(roleToValidate.HardwareProfile.VmSize, roleVmSize, ignoreCase: true);

            if (roleInstanceCount != -1)
                Assert.True(roleToValidate.TargetInstanceCount == roleInstanceCount);
        }
    }
}

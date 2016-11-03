using HDInsight.Tests.Helpers;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Test;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Management.Resources;
using System.Threading;
using Newtonsoft.Json;
using System.Collections;

namespace HDInsight.Tests.UnitTests
{
    public class ClusterCreateTests
    {
        private Mock<HDInsightManagementClient> clientMock;
        private Mock<ClusterOperations> clusterOperationsMock;

        public ClusterCreateTests()
        {
            clientMock = new Mock<HDInsightManagementClient>();
            clusterOperationsMock = new Mock<ClusterOperations>(clientMock.Object);

            clientMock.SetupGet(c => c.Clusters).Returns(clusterOperationsMock.Object);

            clusterOperationsMock.As<IClusterOperations>()
                .Setup(op => op.CreateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ClusterCreateParameters>(), It.IsAny<CancellationToken>()))
                .CallBase();

            clusterOperationsMock.As<IClusterOperations>()
                .Setup(op => op.BeginCreatingAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ClusterCreateParametersExtended>(), It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(new ClusterCreateResponse()));

            clusterOperationsMock.As<IClusterOperations>()
                .Setup(op => op.GetCreateStatusAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(new ClusterGetResponse { 
                    Cluster = new Cluster { 
                        Properties = new ClusterGetProperties { 
                            ProvisioningState = HDInsightClusterProvisioningState.Succeeded 
                        } 
                    } 
                } 
            ));
        }

        [Fact]
        public void TestCreateDefaultFsAzureBlobClusterUsingClusterParameters()
        {
            string resourceGroupName = "resourcegroup";
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

            var createresponse = clientMock.Object.Clusters.Create(resourceGroupName, clusterName, clusterCreateParams);

            clusterOperationsMock.As<IClusterOperations>().Verify(c =>
                c.BeginCreatingAsync(
                    It.Is<string>(x => x == resourceGroupName),
                    It.Is<string>(x => x == clusterName),
                    It.Is<ClusterCreateParametersExtended>(x => ContainerMatchesNameProvided(x, storageContainerName) == true),
                    It.IsAny<CancellationToken>()
                ),
                Times.Once
            );
        }

        [Fact]
        public void TestCreateDefaultFsAzureBlobClusterContainerNotSpecified()
        {
            string resourceGroupName = "resourcegroup";
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

            clientMock.Object.Clusters.Create(resourceGroupName, clusterName, clusterCreateParams);

            clusterOperationsMock.As<IClusterOperations>().Verify(c => 
                c.BeginCreatingAsync(
                    It.Is<string>(x => x == resourceGroupName), 
                    It.Is<string>(x => x == clusterName),
                    It.Is<ClusterCreateParametersExtended>(x => ContainerMatchesNameProvided(x, clusterName) == true),
                    It.IsAny<CancellationToken>()
                ),
                Times.Once
            );
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

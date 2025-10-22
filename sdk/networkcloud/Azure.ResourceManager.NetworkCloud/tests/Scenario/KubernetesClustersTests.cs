// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public partial class KubernetesClustersTests : NetworkCloudManagementTestBase
    {
        public KubernetesClustersTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public KubernetesClustersTests(bool isAsync) : base(isAsync) {}

        [Test]
        [RecordedTest]
        public async Task KubernetesClusters()
        {
            string resourceGroupName = TestEnvironment.ResourceGroup;
            string subscriptionId = TestEnvironment.SubscriptionId;
            ResourceIdentifier l3NetworkId = new ResourceIdentifier(TestEnvironment.L3NAttachmentId);
            ResourceIdentifier cloudServicesNetworkId = new ResourceIdentifier(TestEnvironment.CloudServicesNetworkId);

            string kubernetesClusterName = Recording.GenerateAssetName("kubernetesCluster");
            string SshPublicKey = "ssh-rsa REDACTED";

            // Create ResourceIds
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceIdentifier kubernetesClusterResourceId = NetworkCloudKubernetesClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, kubernetesClusterName);

            // Create ResourceGroup Object and KubernetesClusterCollection Object
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            NetworkCloudKubernetesClusterCollection collection = resourceGroupResource.GetNetworkCloudKubernetesClusters();

            // Create KubernetesClusterData Variables
            KubernetesClusterNetworkConfiguration networkConfiguration = new KubernetesClusterNetworkConfiguration(cloudServicesNetworkId, l3NetworkId)
            {
                DnsServiceIP = System.Net.IPAddress.Parse("10.96.0.10"),
                PodCidrs = { "10.244.0.0/16" },
                ServiceCidrs = { "10.96.0.0/16" },
                BgpServiceLoadBalancerConfiguration = new BgpServiceLoadBalancerConfiguration()
                {
                    BgpAdvertisements =
                    {
                        new BgpAdvertisement(new string[]
                        {
                            "pool1"
                        })
                        {
                            Communities = { "64512:100" },
                            Peers = { "peer1" },
                        }
                    },
                    FabricPeeringEnabled = FabricPeeringEnabled.True,
                    IPAddressPools =
                    {
                        new IPAddressPool(new List<string>(){"198.51.102.0/24"}, "pool1")
                        {
                            AutoAssign = "True",
                            OnlyUseHostIPs = "True",
                        }
                    }
                }
            };

            AdministratorConfiguration administratorConfiguration = new AdministratorConfiguration()
            {
                AdminUsername = "fakesuser",
                SshPublicKeys =
                {
                    new NetworkCloudSshPublicKey(SshPublicKey)
                },
            };

            InitialAgentPoolConfiguration[] initialAgentPoolConfigurationsArray = new InitialAgentPoolConfiguration[]
            {
                new InitialAgentPoolConfiguration(1, NetworkCloudAgentPoolMode.System, "agentPoolConfig", "NC_G2_8_v1")
                {
                    AgentOptions = new NetworkCloudAgentConfiguration(4)
                    {
                        HugepagesSize = HugepagesSize.OneG,
                    },
                    UpgradeSettings = new AgentPoolUpgradeSettings()
                    {
                        MaxSurge = "1",
                    },
                }
            };

            // Create KubernetesCluster
            NetworkCloudKubernetesClusterData createData = new NetworkCloudKubernetesClusterData(
                TestEnvironment.Location,
                new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"),
                new ControlPlaneNodeConfiguration(1, "NC_G2_8_v1")
                {
                    AdministratorConfiguration = administratorConfiguration,
                },
                initialAgentPoolConfigurationsArray,
                TestEnvironment.KubernetesVersion,
                networkConfiguration)
            {
                AadAdminGroupObjectIds = new List<string>() { "3d4c8620-ac8c-4bd6-9a92-f2b75923ef9f" },
                AdministratorConfiguration = administratorConfiguration,
                ManagedResourceGroupConfiguration = new ManagedResourceGroupConfiguration(new AzureLocation(TestEnvironment.Location), kubernetesClusterName + "-MRG", null)
            };

            ArmOperation<NetworkCloudKubernetesClusterResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, kubernetesClusterName, createData);
            Assert.AreEqual(createResult.Value.Data.Name, kubernetesClusterName);

            // Get KubernetesCluster
            NetworkCloudKubernetesClusterResource kubernetesCluster = Client.GetNetworkCloudKubernetesClusterResource(kubernetesClusterResourceId);
            NetworkCloudKubernetesClusterResource getResult = await kubernetesCluster.GetAsync();
            Assert.AreEqual(createResult.Value.Data.Name, kubernetesClusterName);

            // Update KubernetesCluster
            NetworkCloudKubernetesClusterPatch updateData = new NetworkCloudKubernetesClusterPatch()
            {
                ControlPlaneNodeCount = 1,
                KubernetesVersion = TestEnvironment.KubernetesVersionUpdate,
                Tags = { { "test", "patch" } },
            };
            ArmOperation<NetworkCloudKubernetesClusterResource> updateResult = await kubernetesCluster.UpdateAsync(WaitUntil.Completed, updateData);
            Assert.AreEqual(updateResult.Value.Data.Tags["test"], "patch");

            // Get KubernetesClusters by Resource Group
            var listByResourceGroupResult = new List<NetworkCloudKubernetesClusterResource>();
            await foreach (NetworkCloudKubernetesClusterResource kubernetesClusterResource in collection.GetAllAsync())
            {
                listByResourceGroupResult.Add(kubernetesClusterResource);
            }
            Assert.IsNotEmpty(listByResourceGroupResult);

            // Get KubernetesClusters by Subscription
            var listBySubscriptionResult = new List<NetworkCloudKubernetesClusterResource>();
            await foreach (NetworkCloudKubernetesClusterResource kubernetesClusterResource in SubscriptionResource.GetNetworkCloudKubernetesClustersAsync())
            {
                listBySubscriptionResult.Add(kubernetesClusterResource);
            }
            Assert.IsNotEmpty(listBySubscriptionResult);

            // Delete KubernetesCluster
            var deleteResult = await kubernetesCluster.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}

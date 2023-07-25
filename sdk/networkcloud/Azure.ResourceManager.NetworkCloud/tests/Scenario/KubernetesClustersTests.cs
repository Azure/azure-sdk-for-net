// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public async Task KubernetesClusters()
        {
            string resourceGroupName = TestEnvironment.ResourceGroup;
            string subscriptionId = TestEnvironment.SubscriptionId;
            string l3NetworkId = TestEnvironment.L3IsolationDomainId;
            string cloudServicesNetworkId = TestEnvironment.CloudServicesNetworkId;

            string kubernetesClusterName = Recording.GenerateAssetName("kubernetesCluster");
            string SshPublicKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQCjxBjt9iSrZqTJOp+LqGLJN/6x5BhbkReh1F9WtKY5I30NMm8NyJpoTef5tRKWJOFenyhHv92Q1CVbjIOfToM1o+0omzruJnWvzNOIqRfktBgpaAvI3NBW8jyP88dU370R79pCcHS258sEsYZu7Pt3bPHWnJynqqpi3e/icJ902gwR0ZCHWkLS+Kojn6+60TdxnPBlACi/QDQcXE9BtuEO6O9Owtzd9j9q2WdaQTElZHyrjBudDcv8DGVErOl2yPRD9a2kGF3zE9OFemq75UH4YeXDb0FgUdgxq9vvXWlWSm7banZ681MgdMYksYUDuSfvtrnwQl9LBcxvk+Z3eHCaAcHHQ/S5h/lAG5xbGaeE6A9woTMKrnqzXvL/XCg02gM01smgUxO7aIIcMquPaTJBc8rSd4wSihg1iRY93OAMVvj4U8ZqLwIt03Z8aIhrVvAmzkmlZ9YwvSXYBDg0KdMNKG4zrnRqWP7ge7ayb+hPxN6UZ0E7Z3VoVw+2R2NxjHE= fakesuser@fakehost";

            // Create ResourceIds
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceIdentifier kubernetesClusterResourceId = KubernetesClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, kubernetesClusterName);

            // Create ResourceGroup Object and KubernetesClusterCollection Object
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            KubernetesClusterCollection collection = resourceGroupResource.GetKubernetesClusters();

            // Create KubernetesClusterData Variables
            NetworkConfiguration networkConfiguration = new NetworkConfiguration(cloudServicesNetworkId, l3NetworkId)
            {
                DnsServiceIP = "10.96.0.10",
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
                            AdvertiseToFabric = AdvertiseToFabric.True,
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
                    new SshPublicKey(SshPublicKey)
                },
            };

            InitialAgentPoolConfiguration[] initialAgentPoolConfigurationsArray = new InitialAgentPoolConfiguration[]
            {
                new InitialAgentPoolConfiguration(1, AgentPoolMode.System, "agentPoolConfig", "NC_G4_v1")
                {
                    AgentOptions = new AgentOptions(4)
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
            KubernetesClusterData createData = new KubernetesClusterData(
                TestEnvironment.Location,
                new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"),
                new ControlPlaneNodeConfiguration(1, "NC_G4_v1")
                {
                    AdministratorConfiguration = administratorConfiguration,
                },
                initialAgentPoolConfigurationsArray,
                "1.24.9",
                networkConfiguration)
            {
                AadAdminGroupObjectIds = new List<string>() { "3d4c8620-ac8c-4bd6-9a92-f2b75923ef9f" },
                AdministratorConfiguration = administratorConfiguration,
                ManagedResourceGroupConfiguration = new ManagedResourceGroupConfiguration(new AzureLocation("East US"), kubernetesClusterName + "-MRG")
            };

            ArmOperation<KubernetesClusterResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, kubernetesClusterName, createData);
            Assert.AreEqual(createResult.Value.Data.Name, kubernetesClusterName);

            // Get KubernetesCluster
            KubernetesClusterResource kubernetesCluster = Client.GetKubernetesClusterResource(kubernetesClusterResourceId);
            KubernetesClusterResource getResult = await kubernetesCluster.GetAsync();
            Assert.AreEqual(createResult.Value.Data.Name, kubernetesClusterName);

            // Update KubernetesCluster
            KubernetesClusterPatch updateData = new KubernetesClusterPatch()
            {
                ControlPlaneNodeCount = 3,
                KubernetesVersion = "1.25.4-1",
                Tags = { { "test", "patch" } },
            };
            ArmOperation<KubernetesClusterResource> updateResult = await kubernetesCluster.UpdateAsync(WaitUntil.Completed, updateData);
            Assert.AreEqual(updateResult.Value.Data.Tags["test"], "patch");

            // Get KubernetesClusters by Resource Group
            var listByResourceGroupResult = new List<KubernetesClusterResource>();
            await foreach (KubernetesClusterResource kubernetesClusterResource in collection.GetAllAsync())
            {
                listByResourceGroupResult.Add(kubernetesClusterResource);
            }
            Assert.IsNotEmpty(listByResourceGroupResult);

            // Get KubernetesClusters by Subscription
            var listBySubscriptionResult = new List<KubernetesClusterResource>();
            await foreach (KubernetesClusterResource kubernetesClusterResource in SubscriptionResource.GetKubernetesClustersAsync())
            {
                listBySubscriptionResult.Add(kubernetesClusterResource);
            }
            Assert.IsNotEmpty(listBySubscriptionResult);

            // Delete KubernetesCluster
            var deleteResult = await kubernetesCluster.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}

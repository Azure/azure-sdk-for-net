// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridContainerService.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.HybridContainerService.Tests.Tests
{
    [TestFixture]
    public class ProvisionedClusterTests : HybridContainerServiceManagementTestBase
    {
        public ProvisionedClusterTests() : base(true)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Test exceeded global time limit of 10 seconds")]
        public void CreateVnet()
        {
            HybridContainerServiceVirtualNetworkCollection vnetCollection = new HybridContainerServiceVirtualNetworkCollection(Client, ResourceGroupVnet.Id);
            HybridContainerServiceVirtualNetworkData vnetData = new HybridContainerServiceVirtualNetworkData(DefaultLocation);
            vnetData.ExtendedLocation = new HybridContainerServiceExtendedLocation();
            vnetData.ExtendedLocation.ExtendedLocationType = "CustomLocation";
            vnetData.ExtendedLocation.Name = "/subscriptions/0709bd7a-8383-4e1d-98c8-f81d1b3443fc/resourceGroups/hav-ga-rg/providers/Microsoft.ExtendedLocation/customLocations/hav-appl-ga-new-hybridaks-cl";
            vnetData.Properties = new HybridContainerServiceVirtualNetworkProperties();
            vnetData.Properties.InfraVnetProfile = new InfraVnetProfile();
            vnetData.Properties.InfraVnetProfile.Hci = new HciInfraVnetProfile();
            vnetData.Properties.InfraVnetProfile.Hci.MocVnetName = "hybridaks-vnet";
            vnetData.Properties.InfraVnetProfile.Hci.MocGroup = "target-group";
            vnetData.Properties.InfraVnetProfile.Hci.MocLocation = "MocLocation";
            var vnet = vnetCollection.CreateOrUpdate(WaitUntil.Completed, "azvnet-netsdk", vnetData);
            Assert.AreEqual(vnet.Value.Data.Properties.ProvisioningState, HybridContainerServiceProvisioningState.Succeeded);
        }

        //The provisioned cluster is singleton.
        [TestCase]
        [RecordedTest]
        [Ignore("Test exceeded global time limit of 10 seconds")]
        public void CreateProvisionedCluster()
        {
            // Create Vnet
            HybridContainerServiceVirtualNetworkCollection vnetCollection = new HybridContainerServiceVirtualNetworkCollection(Client, ResourceGroupCls.Id);
            HybridContainerServiceVirtualNetworkData vnetData = new HybridContainerServiceVirtualNetworkData(DefaultLocation);
            vnetData.ExtendedLocation = new HybridContainerServiceExtendedLocation();
            vnetData.ExtendedLocation.ExtendedLocationType = "CustomLocation";
            vnetData.ExtendedLocation.Name = "/subscriptions/0709bd7a-8383-4e1d-98c8-f81d1b3443fc/resourceGroups/hav-ga-rg/providers/Microsoft.ExtendedLocation/customLocations/hav-appl-ga-new-hybridaks-cl";
            vnetData.Properties = new HybridContainerServiceVirtualNetworkProperties();
            vnetData.Properties.InfraVnetProfile = new InfraVnetProfile();
            vnetData.Properties.InfraVnetProfile.Hci = new HciInfraVnetProfile();
            vnetData.Properties.InfraVnetProfile.Hci.MocVnetName = "hybridaks-vnet";
            vnetData.Properties.InfraVnetProfile.Hci.MocGroup = "target-group";
            vnetData.Properties.InfraVnetProfile.Hci.MocLocation = "MocLocation";
            var vnet = vnetCollection.CreateOrUpdate(WaitUntil.Completed, "azvnet-sdk", vnetData);
            Assert.AreEqual(vnet.Value.Data.Properties.ProvisioningState, HybridContainerServiceProvisioningState.Succeeded);

            // Connected Cluster base cluster
            string connectedClusterId = "/subscriptions/0709bd7a-8383-4e1d-98c8-f81d1b3443fc/resourceGroups/hav-ga-rg/providers/Microsoft.Kubernetes/connectedClusters/test-cls-netsdk";

            // Create Provisioned Cluster Instance
            ResourceIdentifier provisionedClusterResourceId = ProvisionedClusterResource.CreateResourceIdentifier(connectedClusterId);
            var clusterClient = new ProvisionedClusterResource(Client, provisionedClusterResourceId);

            var clusterData = new ProvisionedClusterData();
            clusterData.ExtendedLocation = new HybridContainerServiceExtendedLocation();
            clusterData.ExtendedLocation.ExtendedLocationType = "CustomLocation";
            clusterData.ExtendedLocation.Name = "/subscriptions/0709bd7a-8383-4e1d-98c8-f81d1b3443fc/resourceGroups/hav-ga-rg/providers/Microsoft.ExtendedLocation/customLocations/hav-appl-ga-new-hybridaks-cl";

            string sshKeyStr = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDCAcY5kdMcyDHffly4RlpAy4WrBvnMEJ45v5AGCQZm0Vv1R5KYYG4+28E+csSdP8GNnxuJWegyqYS9XV0oWxCdN2Wtaqz9QJ2DcFG3panfNn+kWXZtqvf8/lXPEFpX9gmNvAsJYRHBzNnw9/YTbpeHAoQcQniVy616nsxpVyzQVMU2c6SQDapvdot5t9gey9YPhCYxVFZPWmyNL9lSkOAnkGBzDUIr2ne62MGHoyobkPyzPcGIPVV5bDZY2Afw6FvhC+aEZ4k4XRWAOrgRhJyZJe0loC9fc1zpB0LpRA3zaMf+u8hCmnJ8J61xFP4XaG5RJhWOq7syNkc5di3osiuv";
            var publicKeys = new List<LinuxSshPublicKey>();
            publicKeys.Add(new LinuxSshPublicKey(sshKeyStr, null));
            var sshPublicKeys = new LinuxSshConfiguration(publicKeys, null);
            var linuxProfile = new LinuxProfileProperties(sshPublicKeys, null);

            var agentPool = new HybridContainerServiceNamedAgentPoolProfile();
            agentPool.Name = "testnodepool";
            agentPool.Count = 1;
            agentPool.VmSize = "Standard_A4_v2";
            agentPool.OSType = "Linux";
            var agentPoolProfiles = new List<HybridContainerServiceNamedAgentPoolProfile>();
            agentPoolProfiles.Add(agentPool);

            var kubernetesVersion = "1.27.3";

            var controlPlane = new ProvisionedClusterControlPlaneProfile();
            controlPlane.Count = 1;
            controlPlane.VmSize = "Standard_A4_v2";

            var networkProfile = new ProvisionedClusterNetworkProfile();
            networkProfile.LoadBalancerProfile = new ProvisionedClusterLoadBalancerProfile();
            networkProfile.LoadBalancerProfile.Count = 1;
            networkProfile.NetworkPolicy = "calico";
            networkProfile.PodCidr = "10.244.0.0/16";

            var storageProfile = new StorageProfile();

            var clusterVmAccessProfile = new ClusterVmAccessProfile();

            var cloudProviderProfile = new ProvisionedClusterCloudProviderProfile();
            cloudProviderProfile.InfraNetworkProfile = new ProvisionedClusterInfraNetworkProfile(new List<ResourceIdentifier>(), null);
            cloudProviderProfile.InfraNetworkProfile.VnetSubnetIds.Add(vnet.Value.Data.Id);

            clusterData.Properties = new ProvisionedClusterProperties(linuxProfile, controlPlane, kubernetesVersion, networkProfile, storageProfile, clusterVmAccessProfile, agentPoolProfiles, cloudProviderProfile, null, null, null, null, null);

            var cluster = clusterClient.CreateOrUpdate(WaitUntil.Completed, clusterData);
            Assert.AreEqual(cluster.Value.Data.Properties.ProvisioningState, HybridContainerServiceResourceProvisioningState.Succeeded);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridContainerService.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
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
        public void CreateVnet()
        {
            HybridContainerServiceVirtualNetworkCollection vnetCollection = new HybridContainerServiceVirtualNetworkCollection(Client, ResourceGroup.Id);
            HybridContainerServiceVirtualNetworkData vnetData = new HybridContainerServiceVirtualNetworkData(DefaultLocation);
            vnetData.ExtendedLocation = new VirtualNetworksExtendedLocation();
            vnetData.ExtendedLocation.VirtualNetworksExtendedLocationType = "CustomLocation";
            vnetData.ExtendedLocation.Name = "/subscriptions/0709bd7a-8383-4e1d-98c8-f81d1b3443fc/resourcegroups/hybridaksresgrp-1945484400/providers/microsoft.extendedlocation/customlocations/applhybridaks-1945484400-hybridaks-cl";
            vnetData.Properties = new VirtualNetworksProperties();
            vnetData.Properties.InfraVnetProfile = new VirtualNetworksPropertiesInfraVnetProfile();
            vnetData.Properties.InfraVnetProfile.Hci = new VirtualNetworksPropertiesInfraVnetProfileHci();
            vnetData.Properties.InfraVnetProfile.Hci.MocVnetName = "hybridaks-vnet";
            vnetData.Properties.InfraVnetProfile.Hci.MocGroup = "target-group";
            vnetData.Properties.InfraVnetProfile.Hci.MocLocation = "MocLocation";
            var vnet = vnetCollection.CreateOrUpdate(WaitUntil.Completed, "azvnet-sdk", vnetData);
            Assert.AreEqual(vnet.Value.Data.Properties.ProvisioningState, ProvisioningState.Succeeded);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Test exceeds global time limit of 15 seconds")]
        public void CreateProvisionedCluster()
        {
            // Create Vnet
            HybridContainerServiceVirtualNetworkCollection vnetCollection = new HybridContainerServiceVirtualNetworkCollection(Client, ResourceGroup.Id);
            HybridContainerServiceVirtualNetworkData vnetData = new HybridContainerServiceVirtualNetworkData(DefaultLocation);
            vnetData.ExtendedLocation = new VirtualNetworksExtendedLocation();
            vnetData.ExtendedLocation.VirtualNetworksExtendedLocationType = "CustomLocation";
            vnetData.ExtendedLocation.Name = "/subscriptions/0709bd7a-8383-4e1d-98c8-f81d1b3443fc/resourcegroups/hybridaksresgrp-1945484400/providers/microsoft.extendedlocation/customlocations/applhybridaks-1945484400-hybridaks-cl";
            vnetData.Properties = new VirtualNetworksProperties();
            vnetData.Properties.InfraVnetProfile = new VirtualNetworksPropertiesInfraVnetProfile();
            vnetData.Properties.InfraVnetProfile.Hci = new VirtualNetworksPropertiesInfraVnetProfileHci();
            vnetData.Properties.InfraVnetProfile.Hci.MocVnetName = "hybridaks-vnet";
            vnetData.Properties.InfraVnetProfile.Hci.MocGroup = "target-group";
            vnetData.Properties.InfraVnetProfile.Hci.MocLocation = "MocLocation";
            var vnet = vnetCollection.CreateOrUpdate(WaitUntil.Completed, "azvnet-netsdk", vnetData);
            Assert.AreEqual(vnet.Value.Data.Properties.ProvisioningState, ProvisioningState.Succeeded);

            // Create Provisioned Cluster
            var clusterCollection = new ProvisionedClusterCollection(Client, ResourceGroup.Id);
            var clusterData = new ProvisionedClusterCreateOrUpdateContent(DefaultLocation);
            clusterData.ExtendedLocation = new ProvisionedClustersExtendedLocation();
            clusterData.ExtendedLocation.ProvisionedClustersExtendedLocationType = "CustomLocation";
            clusterData.ExtendedLocation.Name = "/subscriptions/0709bd7a-8383-4e1d-98c8-f81d1b3443fc/resourcegroups/hybridaksresgrp-1945484400/providers/microsoft.extendedlocation/customlocations/applhybridaks-1945484400-hybridaks-cl";

            string sshKeyStr = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDCAcY5kdMcyDHffly4RlpAy4WrBvnMEJ45v5AGCQZm0Vv1R5KYYG4+28E+csSdP8GNnxuJWegyqYS9XV0oWxCdN2Wtaqz9QJ2DcFG3panfNn+kWXZtqvf8/lXPEFpX9gmNvAsJYRHBzNnw9/YTbpeHAoQcQniVy616nsxpVyzQVMU2c6SQDapvdot5t9gey9YPhCYxVFZPWmyNL9lSkOAnkGBzDUIr2ne62MGHoyobkPyzPcGIPVV5bDZY2Afw6FvhC+aEZ4k4XRWAOrgRhJyZJe0loC9fc1zpB0LpRA3zaMf+u8hCmnJ8J61xFP4XaG5RJhWOq7syNkc5di3osiuv";
            var publicKeys = new List<LinuxProfilePropertiesSshPublicKeysItem>();
            publicKeys.Add(new LinuxProfilePropertiesSshPublicKeysItem(sshKeyStr));
            var sshPublicKeys = new LinuxProfilePropertiesSsh();
            var linuxProfile = new LinuxProfileProperties(null, sshPublicKeys);

            var agentPool = new NamedAgentPoolProfile();
            agentPool.Name = "default-nodepool";
            agentPool.Count = 1;
            agentPool.VmSize = "Standard_A4_v2";
            agentPool.OSType = "Linux";
            var agentPoolProfiles = new List<NamedAgentPoolProfile>();
            agentPoolProfiles.Add(agentPool);

            var kubernetesVersion = "v1.21.9";

            var controlPlane = new ControlPlaneProfile();
            controlPlane.Count = 1;
            controlPlane.VmSize = "Standard_A4_v2";
            controlPlane.OSType = "Linux";

            var networkProfile = new NetworkProfile();
            networkProfile.LoadBalancerProfile = new LoadBalancerProfile();
            networkProfile.LoadBalancerProfile.Count = 1;
            networkProfile.LoadBalancerProfile.VmSize = "Standard_K8S3_v1";
            networkProfile.LoadBalancerProfile.OSType = "Linux";
            networkProfile.LoadBalancerSku = "unstacked-haproxy";
            networkProfile.NetworkPolicy = "calico";
            networkProfile.PodCidr = "10.244.0.0/16";

            var cloudProviderProfile = new CloudProviderProfile();
            cloudProviderProfile.InfraNetworkProfile = new CloudProviderProfileInfraNetworkProfile(new List<string>());
            cloudProviderProfile.InfraNetworkProfile.VnetSubnetIds.Add(vnet.Value.Data.Id);

            clusterData.Properties = new ProvisionedClustersAllProperties(null, null, null, null, linuxProfile, null, new Dictionary<string, AddonProfiles>(), controlPlane, kubernetesVersion, networkProfile, null, agentPoolProfiles, cloudProviderProfile, null, null);
            clusterData.Identity = new ResourceManager.Models.ManagedServiceIdentity(ResourceManager.Models.ManagedServiceIdentityType.SystemAssigned);

            var cluster = clusterCollection.CreateOrUpdate(WaitUntil.Completed, "cluster-netsdk", clusterData);
            Assert.AreEqual(cluster.Value.Data.Properties.ProvisioningState, ProvisioningState.Succeeded);
        }
    }
}

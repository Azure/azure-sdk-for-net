// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        public void ListClustersInResourceGroup()
        {
            // ResourceIdentifier id = ProvisionedClustersResponseResource.CreateResourceIdentifier(Subscription.Data.SubscriptionId, ResourceGroup.Data.Name, "test-cluster");
            ProvisionedClustersResponseCollection clusterCollection = new ProvisionedClustersResponseCollection(Client, ResourceGroup.Id);
            var provisionedClusters = clusterCollection.GetAll();
            Assert.AreEqual(provisionedClusters.ToList().Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public void ListVnetsInResourceGroup()
        {
            VirtualNetworkCollection vnetCollection = new VirtualNetworkCollection(Client, ResourceGroup.Id);
            var vnets = vnetCollection.GetAll();
            Assert.AreEqual(vnets.ToList().Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public void CreateVnet()
        {
            VirtualNetworkCollection vnetCollection = new VirtualNetworkCollection(Client, ResourceGroup.Id);
            VirtualNetworkData vnetData = new VirtualNetworkData(DefaultLocation);
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
    }
}

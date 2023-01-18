// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.ServiceNetworking.TrafficController;
using Azure.ResourceManager.Network;
using Azure.Core;
using NUnit.Framework;
using Azure.ResourceManager.ServiceNetworking.TrafficController.Models;

namespace Azure.ResourceManager.ServiceNetworking.TrafficController.Tests.Tests
{
    public class TrafficControllerTests : TrafficControllerManagementTestBase
    {
        private SubscriptionResource _subscription;

        public TrafficControllerTests(bool isAsync) : base(isAsync)
        {
        }

        public TrafficControllerTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        private TrafficControllerResource CreateTrafficController(string location, string resourceGroup, string tcName)
        {
            TrafficControllerCollection trafficControllerCollection = GetTrafficControllers(resourceGroup);
            TrafficControllerData tcgw = new TrafficControllerData(location);
            TrafficControllerResource tc = trafficControllerCollection.CreateOrUpdateAsync(WaitUntil.Completed, tcName, tcgw).Result.Value;
            return tc;
        }

        private async Task<TrafficControllerResource> GetTrafficControllerAsync(string resourceGroup, string tcName)
        {
            TrafficControllerCollection trafficControllerCollection = GetTrafficControllers(resourceGroup);
            TrafficControllerResource tc = await trafficControllerCollection.GetAsync(tcName);
            return tc;
        }

        private TrafficControllerResource GetTrafficController(string resourceGroup, string tcName)
        {
            TrafficControllerCollection trafficControllerCollection = GetTrafficControllers(resourceGroup);
            return trafficControllerCollection.Get(tcName);
        }

        [Test]
        public async Task TrafficControllerTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("tc-sdk-test-rg");
            string location = "CanadaEast";
            string tcName = "tc-test";

            //Creating a resource group and validating its creation
            var rgResource = await CreateResourceGroup(Subscription, resourceGroupName, location); //TODO: Validate that this won't be an issue (name reused)
            Assert.NotNull(rgResource, "Resource Group not created successfully");

            //Testing PUT Operation
            TrafficControllerResource tcCreate = CreateTrafficController(location, resourceGroupName, tcName);
            Assert.NotNull(tcCreate, "Traffic Controller is Null");
            Assert.AreEqual(tcCreate.Data.Name, tcName);
            Assert.AreEqual(tcCreate.Data.ProvisioningState, "Succeeded");

            //Testing GET Operation
            TrafficControllerResource tcGet = GetTrafficController(resourceGroupName, tcName);
            Assert.NotNull(tcGet, "Traffic Controller is Null");
            Assert.AreEqual(tcGet.Data.Name, tcName);
            Assert.AreEqual(tcGet.Data.ProvisioningState, "Succeeded");

            //Testing DELETE Operation
            await tcGet.DeleteAsync(WaitUntil.Completed);
            TrafficControllerResource tcDelete = GetTrafficController(resourceGroupName, tcName); //TODO: Think of a better way to test delete operation
            Assert.AreEqual(tcDelete.Data.ProvisioningState.ToString(), "Deleted", "Traffic Controller is NOT Deleted");
        }

        [Test]
        public async Task FrontendsTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("tc-sdk-test-rg");
            string location = "CanadaEast";
            string tcName = "tc-test";

            //Creating a resource group and validating its creation
            var rgResource = await CreateResourceGroup(Subscription, resourceGroupName, location);
            Assert.NotNull(rgResource, "Resource Group not created successfully");

            //Creating Traffic Controller and obtaining Frontends object for performing tests of CRUD functions
            TrafficControllerResource tc = CreateTrafficController(location, resourceGroupName, tcName);
            FrontendCollection frontends = GetFrontends(tc);

            //Creating a public IP Address
            PublicIPAddressCollection publicIPAddresses = rgResource.GetPublicIPAddresses();
            string pipName = "tc-pip";
            var pipData = new PublicIPAddressData()
            {
                PublicIPAddressVersion = Network.Models.NetworkIPVersion.IPv6,
            };

            PublicIPAddressResource pip = publicIPAddresses.CreateOrUpdate(WaitUntil.Completed, pipName, pipData).Value;

            //Testing PUT Operation
            string frontendName = "frontend1";
            FrontendData fnd = new FrontendData(location)
            {
                IPAddressVersion = FrontendIPAddressVersion.IPv6,
                Mode = FrontendMode.Public,
                PublicIPAddressId = pip.Id,
            };
            var frontendCreation = frontends.CreateOrUpdate(WaitUntil.Completed, frontendName, fnd).Value;
            Assert.IsNotNull(frontendCreation);
            Assert.AreEqual(frontendCreation.Data.Name, frontendName);
            Assert.AreEqual(frontendCreation.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing GET Operation
            var frontendGet = frontends.Get(frontendName).Value;
            Assert.IsNotNull(frontendGet);
            Assert.AreEqual(frontendGet.Data.Name, frontendName);
            Assert.AreEqual(frontendGet.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing DELETE Operation
            await frontendGet.DeleteAsync(WaitUntil.Completed);
            frontendGet = frontends.Get(frontendName).Value;
            Assert.AreEqual(frontendGet.Data.ProvisioningState.ToString(), "Deleted", "The Frontend is NOT Deleted");
        }

        [Test]
        public async Task AssociationTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("tc-sdk-test-rg");
            string location = "CanadaEast";
            string tcName = "tc-test";

            //Creating a resource group and validating its creation
            var rgResource = await CreateResourceGroup(Subscription, resourceGroupName, location);
            Assert.NotNull(rgResource, "Resource Group not created successfully");

            //Creating Traffic Controller and obtaining Associations object for performing tests of CRUD functions
            TrafficControllerResource tc = CreateTrafficController(location, resourceGroupName, tcName);
            AssociationCollection associations = GetAssociations(tc);

            //Creating required Association realted resources
            VirtualNetworkCollection vnets = GetVirtualNetworks(resourceGroupName);
            VirtualNetworkData vnetData = new VirtualNetworkData();
            VirtualNetworkResource vnet = vnets.CreateOrUpdate(WaitUntil.Completed, "tc-vnet", vnetData).Value;
            SubnetCollection subnets = vnet.GetSubnets();
            SubnetData subnetData = new SubnetData();
            SubnetResource subnet = subnets.CreateOrUpdate(WaitUntil.Completed, "tc-subnet", subnetData).Value;

            //Testing the PUT Operation
            AssociationData associationData = new AssociationData(location)
            {
                AssociationType = AssociationType.Subnets,
                SubnetId = subnet.Id,
            };
            string associationName = "tc-association";
            AssociationResource associationCreate = associations.CreateOrUpdate(WaitUntil.Completed, associationName, associationData).Value;
            Assert.IsNotNull(associationCreate);
            Assert.AreEqual(associationCreate.Data.Name, associationName);
            Assert.AreEqual(associationCreate.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing the GET Operation
            AssociationResource associationGet = associations.Get(associationName).Value;
            Assert.IsNotNull(associationGet);
            Assert.AreEqual(associationGet.Data.Name, associationName);
            Assert.AreEqual(associationGet.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing the DELETE Operatoin
            await associationGet.DeleteAsync(WaitUntil.Completed);
            associationGet = associations.Get(associationName).Value;
            Assert.IsNull(associationGet);
        }
    }
}

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
using System.IO.Pipelines;
using Castle.Core.Resource;
using System.Xml.Linq;
using Azure.ResourceManager.Network.Models;
using AssociationType = Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType;

namespace Azure.ResourceManager.ServiceNetworking.TrafficController.Tests.Tests
{
    [TestFixture(Author = "shmalpani")]
    public class TrafficControllerTests : TrafficControllerManagementTestBase
    {
        //private SubscriptionResource _subscription;

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                CreateCommonClient();
            }
            //_subscription = Subscription;
        }

        public TrafficControllerTests() : base(false)
        {
        }

        public TrafficControllerTests(bool isAsync) : base(isAsync)
        {
        }

        public TrafficControllerTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        private async Task<ArmOperation<TrafficControllerResource>> CreateTrafficControllerAsync(string location, string resourceGroup, string tcName)
        {
            //Obtaining the Collection object of TrafficController to perform the Create/PUT operation.
            TrafficControllerCollection trafficControllerCollection = GetTrafficControllers(resourceGroup);
            TrafficControllerData tcgw = new TrafficControllerData(location);
            var tcTask = await trafficControllerCollection.CreateOrUpdateAsync(WaitUntil.Completed, tcName, tcgw);
            return tcTask;
        }

        private async Task<TrafficControllerResource> GetTrafficControllerAsync(string resourceGroup, string tcName)
        {
            //Obtaining the Collection object of TrafficController to perform the GET operation.
            TrafficControllerCollection trafficControllerCollection = GetTrafficControllers(resourceGroup);
            return  await trafficControllerCollection.GetAsync(tcName);
        }

        private async Task<ArmOperation<FrontendResource>> CreateFrontendAsync(ResourceGroupResource rgResource, string frontendName, TrafficControllerResource tc, string location)
        {
            //Obtaining the Collection object of the Frontend to perform the Create/PUT operation.
            FrontendCollection frontends = GetFrontends(tc);

            //Creating a public IP (PIP) Address Resource. The resource ID of the resouce is passed on to the Frontend.
            PublicIPAddressCollection publicIPAddresses = rgResource.GetPublicIPAddresses();
            string pipName = Recording.GenerateAssetName("tc-pip");
            var pipData = new PublicIPAddressData()
            {
                Location = "East US 2",
                Sku = new PublicIPAddressSku()
                {
                    Name = PublicIPAddressSkuName.Standard,
                    Tier = PublicIPAddressSkuTier.Global
                },
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Static
            };

            PublicIPAddressResource pip = publicIPAddresses.CreateOrUpdateAsync(WaitUntil.Completed, pipName, pipData).Result.Value;

            //Frontend Data object that is used to create the new frontend object.
            FrontendData fnd = new FrontendData(location)
            {
                Mode = FrontendMode.Public,
                PublicIPAddressId = pip.Id,
                Location = location,
            };
            //Performing the Create/PUT operation and returning the result.
            return await frontends.CreateOrUpdateAsync(WaitUntil.Completed, frontendName, fnd);
        }

        private async Task<FrontendResource> GetFrontendAsync( string frontendName, TrafficControllerResource tc)
        {
            //Obtaining the Collection object of Frontend to perform the GET operation.
            FrontendCollection frontends = GetFrontends(tc);
            //Performing the GET operation and returning the result.
            return await frontends.GetAsync(frontendName);
        }

        private async Task<ArmOperation<AssociationResource>> CreateAssociationAsync(string resourceGroup, string associationName, TrafficControllerResource tc, string location) {
            //Obtaining the Collection object of the Frontend to perform the Create/PUT operation.
            AssociationCollection associations = GetAssociations(tc);

            //Creating the virtual network (vnet) and subnet required for creating an association object.
            VirtualNetworkCollection vnets = GetVirtualNetworks(resourceGroup);
            VirtualNetworkData vnetData = new VirtualNetworkData()
            {
                Location=location,
                AddressPrefixes = { "10.225.0.0/16" },
            };
            string vnetName = Recording.GenerateAssetName("tc-vnet");
            VirtualNetworkResource vnet = vnets.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetData).Result.Value;
            SubnetCollection subnets = vnet.GetSubnets();
            SubnetData subnetData = new SubnetData()
            {
                //Delegations = new List<string>(){ "Microsoft.ServiceNetworking/trafficControllers" },
            };
            string subnetName = Recording.GenerateAssetName("tc-subnet");
            SubnetResource subnet = subnets.CreateOrUpdateAsync(WaitUntil.Completed, subnetName, subnetData).Result.Value;

            //Association Data object that is used to create the new frontend object.
            AssociationData associationData = new AssociationData(location)
            {
                AssociationType = AssociationType.Subnets,
                SubnetId = subnet.Id,
                Location= location,
            };
            //Performing the Create/PUT operation
            return await associations.CreateOrUpdateAsync(WaitUntil.Completed, associationName, associationData);
        }

        private AssociationResource GetAssociation(string associationName, TrafficControllerResource tc)
        {
            //Obtaining the Collection object of Association to perform the GET operation.
            AssociationCollection associations = GetAssociations(tc);
            //Performing the GET operation and returning the result.
            AssociationResource association = associations.Get(associationName).Value;
            return association;
        }

        [Test]
        [RecordedTest]
        public async Task TrafficControllerTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("tc-sdk-test-rg");
            string location = DefaultLocation();
            string tcName = Recording.GenerateAssetName("tc-test");

            //Creating a resource group and validating its creation
            ResourceGroupResource rgResource = CreateResourceGroup(Subscription, resourceGroupName, location);
            resourceGroupName = rgResource.Data.Name;
            //Testing PUT Operation
            TrafficControllerResource tcCreate = CreateTrafficControllerAsync(location, resourceGroupName, tcName).Result.Value;
            Assert.NotNull(tcCreate, "Traffic Controller is Null");
            Assert.AreEqual(tcCreate.Data.Name, tcName);
            Assert.AreEqual(tcCreate.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing GET Operation
            TrafficControllerResource tcGet = GetTrafficControllerAsync(resourceGroupName, tcName).Result;
            Assert.NotNull(tcGet, "Traffic Controller is Null");
            Assert.AreEqual(tcGet.Data.Name, tcName);
            Assert.AreEqual(tcGet.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing DELETE Operation
            var tcDelete = await tcGet.DeleteAsync(WaitUntil.Completed);
            var deleteResponse = tcDelete.WaitForCompletionResponse();
            Assert.AreEqual(deleteResponse.IsError, false);
        }

        [Test]
        [RecordedTest]
        public async Task FrontendsTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("tc-sdk-test-rg");
            string location = DefaultLocation();
            string tcName = Recording.GenerateAssetName("tc-frontend-test");

            //Creating a resource group and validating its creation
            var rgResource = CreateResourceGroup(Subscription, resourceGroupName, location);
            resourceGroupName = rgResource.Data.Name;

            //Creating Traffic Controller and obtaining Frontends object for performing tests of CRUD functions
            TrafficControllerResource tc = CreateTrafficControllerAsync(location, resourceGroupName, tcName).Result.Value;

            //Testing PUT Operation
            string frontendName = Recording.GenerateAssetName("tc-frontend");
            var frontendCreation = CreateFrontendAsync(rgResource, frontendName, tc, location).Result.Value;
            Assert.IsNotNull(frontendCreation);
            Assert.AreEqual(frontendCreation.Data.Name, frontendName);
            Assert.AreEqual(frontendCreation.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing GET Operation
            var frontendGet = GetFrontendAsync(frontendName, tc).Result;
            Assert.IsNotNull(frontendGet);
            Assert.AreEqual(frontendGet.Data.Name, frontendName);
            Assert.AreEqual(frontendGet.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing DELETE Operation
            var frontendDelete = await frontendGet.DeleteAsync(WaitUntil.Completed);
            var deleteResponse = frontendDelete.WaitForCompletionResponse();
            Assert.AreEqual(deleteResponse.IsError, false);
        }

        [Test]
        [RecordedTest]
        public async Task AssociationTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("tc-sdk-test-rg");
            string location = DefaultLocation();
            string tcName = Recording.GenerateAssetName("tc-association-test");

            //Creating a resource group and validating its creation
            var rgResource = CreateResourceGroup(Subscription, resourceGroupName, location);
            resourceGroupName = rgResource.Data.Name;

            //Creating Traffic Controller and obtaining Associations object for performing tests of CRUD functions
            TrafficControllerResource tc = CreateTrafficControllerAsync(location, resourceGroupName, tcName).Result.Value;

            string associationName = Recording.GenerateAssetName("tc-association");
            AssociationResource associationCreate = CreateAssociationAsync(resourceGroupName, associationName, tc, location).Result.Value;
            Assert.IsNotNull(associationCreate);
            Assert.AreEqual(associationCreate.Data.Name, associationName);
            Assert.AreEqual(associationCreate.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing the GET Operation
            AssociationResource associationGet = GetAssociation(associationName, tc);
            Assert.IsNotNull(associationGet);
            Assert.AreEqual(associationGet.Data.Name, associationName);
            Assert.AreEqual(associationGet.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing DELETE Operation
            var associationDelete = await associationGet.DeleteAsync(WaitUntil.Completed);
            var deleteResponse = associationDelete.WaitForCompletionResponse();
            Assert.AreEqual(deleteResponse.IsError, false);
        }
    }
}

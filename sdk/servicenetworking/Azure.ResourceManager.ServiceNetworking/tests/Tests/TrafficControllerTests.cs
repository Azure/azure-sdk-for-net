// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network;
using Azure.Core;
using NUnit.Framework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.ServiceNetworking.Tests;

namespace Azure.ResourceManager.ServiceNetworking.TrafficController.Tests.Tests
{
    [TestFixture(Author = "shmalpani")]
    public class TrafficControllerTests : ServiceNetworkingManagementTestBase
    {
        private Dictionary<string, string> _resourceNames;

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                CreateCommonClient();
            }
        }

        public TrafficControllerTests() : base(false)
        {
            _resourceNames = new Dictionary<string, string>();
        }

        public TrafficControllerTests(bool isAsync) : base(isAsync)
        {
            _resourceNames = new Dictionary<string, string>();
        }

        public TrafficControllerTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            _resourceNames = new Dictionary<string, string>();
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
            return await trafficControllerCollection.GetAsync(tcName);
        }

        private async void DeleteTrafficControllerAsync(TrafficControllerResource tc)
        {
            await tc.DeleteAsync(WaitUntil.Started);
        }

        private async Task<ArmOperation<TrafficControllerFrontendResource>> CreateFrontendAsync(ResourceGroupResource rgResource, string frontendName, TrafficControllerResource tc, string location)
        {
            //Obtaining the Collection object of the Frontend to perform the Create/PUT operation.
            TrafficControllerFrontendCollection frontends = GetFrontends(tc);

            //Frontend Data object that is used to create the new frontend object.
            TrafficControllerFrontendData fnd = new TrafficControllerFrontendData(location)
            {
                Location = location
            };
            //Performing the Create/PUT operation and returning the result.
            return await frontends.CreateOrUpdateAsync(WaitUntil.Completed, frontendName, fnd);
        }

        private async Task<TrafficControllerFrontendResource> GetFrontendAsync(string frontendName, TrafficControllerResource tc)
        {
            //Obtaining the Collection object of Frontend to perform the GET operation.
            TrafficControllerFrontendCollection frontends = GetFrontends(tc);
            //Performing the GET operation and returning the result.
            return await frontends.GetAsync(frontendName);
        }

        private async Task DeleteFrontendResource(ResourceGroupResource rgResource, TrafficControllerResource tc)
        {
            string pipName;
            try
            {
                pipName = _resourceNames["tc-pip"];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Resource Names not found. Unable to perform DELETE for Frontend Resources");
                return;
            }
            TrafficControllerFrontendCollection frontends = GetFrontends(tc);
            PublicIPAddressCollection publicIPAddresses = rgResource.GetPublicIPAddresses();
            PublicIPAddressResource pip = publicIPAddresses.GetAsync(pipName).Result;
            await pip.DeleteAsync(WaitUntil.Started);
        }

        private async Task<ArmOperation<TrafficControllerAssociationResource>> CreateAssociationAsync(string resourceGroup, string associationName, TrafficControllerResource tc, string location)
        {
            //Obtaining the Collection object of the Frontend to perform the Create/PUT operation.
            TrafficControllerAssociationCollection associations = GetAssociations(tc);

            //Creating the virtual network (vnet) and subnet required for creating an association object.
            var rg = GetResourceGroup(resourceGroup);
            string vnetName = Recording.GenerateAssetName("tc-vnet");
            string subnetName = Recording.GenerateAssetName("tc-subnet");
            SubnetResource subnet;
            if (Mode == RecordedTestMode.Playback)
            {
                ResourceIdentifier id = SubnetResource.CreateResourceIdentifier(rg.Id.SubscriptionId, rg.Id.Name, vnetName, subnetName);
                subnet = Client.GetSubnetResource(id);
            }
            else
            {
                VirtualNetworkCollection vnets = GetVirtualNetworks(resourceGroup);
                VirtualNetworkData vnetData = new VirtualNetworkData()
                {
                    Location = location,
                    AddressPrefixes = { "10.225.0.0/16" },
                };
                _resourceNames["tc-vnet"] = vnetName;
                VirtualNetworkResource vnet = vnets.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetData).Result.Value;
                SubnetCollection subnets = vnet.GetSubnets();
                SubnetData subnetData = new SubnetData()
                {
                    AddressPrefix = "10.225.0.0/24",
                };
                var trafficControllerServiceDelegation = new ServiceDelegation()
                {
                    ServiceName = "Microsoft.ServiceNetworking/trafficControllers",
                    Name = "Microsoft.ServiceNetworking/trafficControllers",
                };
                subnetData.Delegations.Add(trafficControllerServiceDelegation);
                _resourceNames["tc-subnet"] = subnetName;
                subnet = subnets.CreateOrUpdateAsync(WaitUntil.Completed, subnetName, subnetData).Result.Value;
            }

            //Association Data object that is used to create the new frontend object.
            TrafficControllerAssociationData associationData = new TrafficControllerAssociationData(location)
            {
                AssociationType = null,
                SubnetId = subnet.Id,
                Location = location,
            };
            //Performing the Create/PUT operation
            return await associations.CreateOrUpdateAsync(WaitUntil.Completed, associationName, associationData);
        }

        private async void DeleteAssociationResourcesAsync(string associationName, TrafficControllerResource tc, string resourceGroup)
        {
            string vnetName;
            string subnetName;
            try
            {
                vnetName = _resourceNames["tc-vnet"];
                subnetName = _resourceNames["tc-subnet"];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Resource Names not found. Unable to perform DELETE for Association Resources");
                return;
            }
            TrafficControllerAssociationCollection associations = GetAssociations(tc);

            VirtualNetworkCollection vnets = GetVirtualNetworks(resourceGroup);
            VirtualNetworkResource vnet = vnets.GetAsync(vnetName).Result;

            SubnetResource subnet = vnet.GetSubnetAsync(subnetName).Result;
            await subnet.DeleteAsync(WaitUntil.Started);
            await vnet.DeleteAsync(WaitUntil.Started);
        }

        private async Task DeleteAssociation(TrafficControllerAssociationResource association)
        {
            await association.DeleteAsync(WaitUntil.Completed);
        }

        private async Task<TrafficControllerAssociationResource> GetAssociationAsync(string associationName, TrafficControllerResource tc)
        {
            //Obtaining the Collection object of Association to perform the GET operation.
            TrafficControllerAssociationCollection associations = GetAssociations(tc);
            //Performing the GET operation and returning the result.
            return await associations.GetAsync(associationName);
        }

        private async void DeleteResourceGroupAsync(ResourceGroupResource rgResource)
        {
            await rgResource.DeleteAsync(WaitUntil.Started);
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
            Assert.AreEqual(tcCreate.Data.TrafficControllerProvisioningState.ToString(), "Succeeded");

            //Testing GET Operation
            TrafficControllerResource tcGet = GetTrafficControllerAsync(resourceGroupName, tcName).Result;
            Assert.NotNull(tcGet, "Traffic Controller is Null");
            Assert.AreEqual(tcGet.Data.Name, tcName);
            Assert.AreEqual(tcGet.Data.TrafficControllerProvisioningState.ToString(), "Succeeded");

            //Testing DELETE Operation
            var tcDelete = await tcGet.DeleteAsync(WaitUntil.Completed);
            var deleteResponse = tcDelete.WaitForCompletionResponse();
            Assert.AreEqual(deleteResponse.IsError, false);
            DeleteResourceGroupAsync(rgResource);
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
            //Deleting Traffic Controller
            await DeleteFrontendResource(rgResource, tc);
            DeleteTrafficControllerAsync(tc);
            DeleteResourceGroupAsync(rgResource);
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
            TrafficControllerAssociationResource associationCreate = CreateAssociationAsync(resourceGroupName, associationName, tc, location).Result.Value;
            Assert.IsNotNull(associationCreate);
            Assert.AreEqual(associationCreate.Data.Name, associationName);
            Assert.AreEqual(associationCreate.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing the GET Operation
            TrafficControllerAssociationResource associationGet = GetAssociationAsync(associationName, tc).Result;
            Assert.IsNotNull(associationGet);
            Assert.AreEqual(associationGet.Data.Name, associationName);
            Assert.AreEqual(associationGet.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing DELETE Operation
            await DeleteAssociation(associationGet);
            //Deleting Traffic Controller
            DeleteAssociationResourcesAsync(associationName, tc, resourceGroupName);
            DeleteTrafficControllerAsync(tc);
            DeleteResourceGroupAsync(rgResource);
        }
    }
}

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
            //Obtaining the Collection object of TrafficController to perform the Create/PUT operation.
            TrafficControllerCollection trafficControllerCollection = GetTrafficControllers(resourceGroup);
            TrafficControllerData tcgw = new TrafficControllerData(location);
            TrafficControllerResource tc = trafficControllerCollection.CreateOrUpdate(WaitUntil.Completed, tcName, tcgw).Value;
            return tc;
        }

        private TrafficControllerResource GetTrafficController(string resourceGroup, string tcName)
        {
            //Obtaining the Collection object of TrafficController to perform the GET operation.
            TrafficControllerCollection trafficControllerCollection = GetTrafficControllers(resourceGroup);
            return trafficControllerCollection.Get(tcName);
        }

        private FrontendResource CreateFrontend(ResourceGroupResource rgResource, string frontendName, TrafficControllerResource tc, string location) {
            //Obtaining the Collection object of the Frontend to perform the Create/PUT operation.
            FrontendCollection frontends = GetFrontends(tc);

            //Creating a public IP (PIP) Address Resource. The resource ID of the resouce is passed on to the Frontend.
            PublicIPAddressCollection publicIPAddresses = rgResource.GetPublicIPAddresses();
            string pipName = "tc-pip";
            var pipData = new PublicIPAddressData()
            {
                PublicIPAddressVersion = Network.Models.NetworkIPVersion.IPv6,
            };
            PublicIPAddressResource pip = publicIPAddresses.CreateOrUpdate(WaitUntil.Completed, pipName, pipData).Value;

            //Frontend Data object that is used to create the new frontend object.
            FrontendData fnd = new FrontendData(location)
            {
                IPAddressVersion = FrontendIPAddressVersion.IPv6,
                Mode = FrontendMode.Public,
                PublicIPAddressId = pip.Id,
            };
            //Performing the Create/PUT operation and returning the result.
            return frontends.CreateOrUpdate(WaitUntil.Completed, frontendName, fnd).Value;
        }

        private FrontendResource GetFrontend( string frontendName, TrafficControllerResource tc)
        {
            //Obtaining the Collection object of Frontend to perform the GET operation.
            FrontendCollection frontends = GetFrontends(tc);
            //Performing the GET operation and returning the result.
            return frontends.Get(frontendName).Value;
        }

        private AssociationResource CreateAssociation(string resourceGroup, string associationName, TrafficControllerResource tc, string location) {
            //Obtaining the Collection object of the Frontend to perform the Create/PUT operation.
            AssociationCollection associations = GetAssociations(tc);

            //Creating the virtual network (vnet) and subnet required for creating an association object. 
            VirtualNetworkCollection vnets = GetVirtualNetworks(resourceGroup);
            VirtualNetworkData vnetData = new VirtualNetworkData();
            VirtualNetworkResource vnet = vnets.CreateOrUpdate(WaitUntil.Completed, "tc-vnet", vnetData).Value;
            SubnetCollection subnets = vnet.GetSubnets();
            SubnetData subnetData = new SubnetData();
            SubnetResource subnet = subnets.CreateOrUpdate(WaitUntil.Completed, "tc-subnet", subnetData).Value;

            //Association Data object that is used to create the new frontend object.
            AssociationData associationData = new AssociationData(location)
            {
                AssociationType = AssociationType.Subnets,
                SubnetId = subnet.Id,
            };
            //Performing the Create/PUT operation
            AssociationResource associationCreate = associations.CreateOrUpdate(WaitUntil.Completed, associationName, associationData).Value;
            return associationCreate;
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
        public async Task TrafficControllerTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("tc-sdk-test-rg");
            string location = "CanadaEast";
            string tcName = "tc-test";

            //Creating a resource group and validating its creation
            var rgResource = CreateResourceGroup(Subscription, resourceGroupName, location);

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

            //Creating Traffic Controller and obtaining Frontends object for performing tests of CRUD functions
            TrafficControllerResource tc = CreateTrafficController(location, resourceGroupName, tcName);

            //Creating a resource group and validating its creation
            var rgResource = CreateResourceGroup(Subscription, resourceGroupName, location);

            //Testing PUT Operation
            string frontendName = "frontend1";
            var frontendCreation = CreateFrontend(rgResource, frontendName, tc, location);
            Assert.IsNotNull(frontendCreation);
            Assert.AreEqual(frontendCreation.Data.Name, frontendName);
            Assert.AreEqual(frontendCreation.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing GET Operation
            var frontendGet = GetFrontend(frontendName, tc);
            Assert.IsNotNull(frontendGet);
            Assert.AreEqual(frontendGet.Data.Name, frontendName);
            Assert.AreEqual(frontendGet.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing DELETE Operation
            await frontendGet.DeleteAsync(WaitUntil.Completed);
            frontendGet = GetFrontend(frontendName, tc);
            Assert.AreEqual(frontendGet.Data.ProvisioningState.ToString(), "Deleted", "The Frontend is NOT Deleted");
        }

        [Test]
        public async Task AssociationTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("tc-sdk-test-rg");
            string location = "CanadaEast";
            string tcName = "tc-test";

            //Creating a resource group and validating its creation
            var rgResource = CreateResourceGroup(Subscription, resourceGroupName, location);

            //Creating Traffic Controller and obtaining Associations object for performing tests of CRUD functions
            TrafficControllerResource tc = CreateTrafficController(location, resourceGroupName, tcName);

            string associationName = "tc-association";
            AssociationResource associationCreate = CreateAssociation(resourceGroupName, associationName, tc, location);
            Assert.IsNotNull(associationCreate);
            Assert.AreEqual(associationCreate.Data.Name, associationName);
            Assert.AreEqual(associationCreate.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing the GET Operation
            AssociationResource associationGet = GetAssociation(associationName, tc);
            Assert.IsNotNull(associationGet);
            Assert.AreEqual(associationGet.Data.Name, associationName);
            Assert.AreEqual(associationGet.Data.ProvisioningState.ToString(), "Succeeded");

            //Testing the DELETE Operatoin
            await associationGet.DeleteAsync(WaitUntil.Completed);
            associationGet = GetAssociation(associationName, tc);
            Assert.IsNull(associationGet);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_CommunicationService_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Communication.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
#endregion Manage_CommunicationService_Namespaces

namespace Azure.ResourceManager.Communication.Tests.Samples
{
    public class Sample1_ManagingCommunicationService
    {
        private ResourceGroupResource resourceGroup;

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion

            #region Snippet:Readme_GetResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = lro.Value;
            #endregion

            this.resourceGroup = resourceGroup;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateCommunicationService()
        {
            #region Snippet:Managing_CommunicationService_CreateAnApplicationDefinition
            CommunicationServiceResourceCollection collection = resourceGroup.GetCommunicationServiceResources();
            string communicationServiceName = "myCommunicationService";
            CommunicationServiceResourceData data = new CommunicationServiceResourceData("global")
            {
                DataLocation = "UnitedStates",
            };
            ArmOperation<CommunicationServiceResource> communicationServiceLro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, communicationServiceName, data);
            CommunicationServiceResource communicationService = communicationServiceLro.Value;
            #endregion Snippet:Managing_CommunicationService_CreateAnApplicationDefinition
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListCommunicationService()
        {
            #region Snippet:Managing_CommunicationService_ListAllCommunicationService
            CommunicationServiceResourceCollection collection = resourceGroup.GetCommunicationServiceResources();

            AsyncPageable<CommunicationServiceResource> list = collection.GetAllAsync();
            await foreach (CommunicationServiceResource communicationService  in list)
            {
                Console.WriteLine(communicationService.Data.Name);
            }
            #endregion Snippet:Managing_CommunicationService_ListAllCommunicationService
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteCommunicationService()
        {
            #region Snippet:Managing_CommunicationService_DeleteAnApplicationDefinition
            CommunicationServiceResourceCollection collection = resourceGroup.GetCommunicationServiceResources();

            CommunicationServiceResource communicationService = await collection.GetAsync("myCommunicationService");
            await communicationService.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_CommunicationService_DeleteAnApplicationDefinition
        }
    }
}

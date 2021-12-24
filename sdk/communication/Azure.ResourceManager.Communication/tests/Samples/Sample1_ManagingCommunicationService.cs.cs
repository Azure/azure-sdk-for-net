// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_CommunicationService_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
#endregion Manage_CommunicationService_Namespaces

namespace Azure.ResourceManager.Communication.Tests.Samples
{
    public class Sample1_ManagingCommunicationService
    {
        private ResourceGroup resourceGroup;

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion

            #region Snippet:Readme_GetResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = lro.Value;
            #endregion

            this.resourceGroup = resourceGroup;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateCommunicationService()
        {
            #region Snippet:Managing_CommunicationService_CreateAnApplicationDefinition
            var collection = resourceGroup.GetCommunicationServices();
            string communicationServiceName = "myCommunicationService";
            CommunicationServiceData data = new CommunicationServiceData()
            {
                Location = "global",
                DataLocation = "UnitedStates",
            };
            var communicationServiceLro = await collection.CreateOrUpdateAsync(communicationServiceName, data);
            CommunicationService communicationService = communicationServiceLro.Value;
            #endregion Snippet:Managing_CommunicationService_CreateAnApplicationDefinition
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListCommunicationService()
        {
            #region Snippet:Managing_CommunicationService_ListAllCommunicationService
            var collection = resourceGroup.GetCommunicationServices();

            AsyncPageable<CommunicationService> list = collection.GetAllAsync();
            await foreach (CommunicationService communicationService  in list)
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
            var collection = resourceGroup.GetCommunicationServices();

            CommunicationService communicationService = await collection.GetAsync("myCommunicationService");
            await communicationService.DeleteAsync();
            #endregion Snippet:Managing_CommunicationService_DeleteAnApplicationDefinition
        }
    }
}

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
            AzureLocation location = AzureLocation.WestUS2;
            ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(true,rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = lro.Value;
            #endregion

            this.resourceGroup = resourceGroup;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateCommunicationService()
        {
            #region Snippet:Managing_CommunicationService_CreateAnApplicationDefinition
            CommunicationServiceCollection collection = resourceGroup.GetCommunicationServices();
            string communicationServiceName = "myCommunicationService";
            CommunicationServiceData data = new CommunicationServiceData()
            {
                Location = "global",
                DataLocation = "UnitedStates",
            };
            CommunicationServiceCreateOrUpdateOperation communicationServiceLro = await collection.CreateOrUpdateAsync(true, communicationServiceName, data);
            CommunicationService communicationService = communicationServiceLro.Value;
            #endregion Snippet:Managing_CommunicationService_CreateAnApplicationDefinition
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListCommunicationService()
        {
            #region Snippet:Managing_CommunicationService_ListAllCommunicationService
            CommunicationServiceCollection collection = resourceGroup.GetCommunicationServices();

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
            CommunicationServiceCollection collection = resourceGroup.GetCommunicationServices();

            CommunicationService communicationService = await collection.GetAsync("myCommunicationService");
            await communicationService.DeleteAsync(true);
            #endregion Snippet:Managing_CommunicationService_DeleteAnApplicationDefinition
        }
    }
}

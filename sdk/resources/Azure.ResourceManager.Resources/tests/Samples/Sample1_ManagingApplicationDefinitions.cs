// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_ApplicationDefinitions_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
#endregion Manage_ApplicationDefinitions_Namespaces

namespace Azure.ResourceManager.Resources.Tests.Samples
{
    public class Sample1_ManagingApplicationDefinitions
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateApplicationDefinitions()
        {
            #region Snippet:Managing_ApplicationDefinitions_CreateAnApplicationDefinition
            // First we need to get the application definition collection from the resource group
            ApplicationDefinitionCollection applicationDefinitionCollection = resourceGroup.GetApplicationDefinitions();
            // Use the same location as the resource group
            string applicationDefinitionName = "myApplicationDefinition";
            var input = new ApplicationDefinitionData(resourceGroup.Data.Location, ApplicationLockLevel.None)
            {
                DisplayName = applicationDefinitionName,
                Description = $"{applicationDefinitionName} description",
                PackageFileUri = "https://raw.githubusercontent.com/Azure/azure-managedapp-samples/master/Managed%20Application%20Sample%20Packages/201-managed-storage-account/managedstorage.zip"
            };
            ApplicationDefinitionCreateOrUpdateOperation lro = await applicationDefinitionCollection.CreateOrUpdateAsync(applicationDefinitionName, input);
            ApplicationDefinition applicationDefinition = lro.Value;
            #endregion Snippet:Managing_ApplicationDefinitions_CreateAnApplicationDefinition
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListApplicationDefinitions()
        {
            #region Snippet:Managing_ApplicationDefinitions_ListAllApplicationDefinitions
            // First we need to get the application definition collection from the resource group
            ApplicationDefinitionCollection applicationDefinitionCollection = resourceGroup.GetApplicationDefinitions();
            // With GetAllAsync(), we can get a list of the application definitions in the collection
            AsyncPageable<ApplicationDefinition> response = applicationDefinitionCollection.GetAllAsync();
            await foreach (ApplicationDefinition applicationDefinition in response)
            {
                Console.WriteLine(applicationDefinition.Data.Name);
            }
            #endregion Snippet:Managing_ApplicationDefinitions_ListAllApplicationDefinitions
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteApplicationDefinitions()
        {
            #region Snippet:Managing_ApplicationDefinitions_DeleteAnApplicationDefinition
            // First we need to get the application definition collection from the resource group
            ApplicationDefinitionCollection applicationDefinitionCollection = resourceGroup.GetApplicationDefinitions();
            // Now we can get the application definition with GetAsync()
            ApplicationDefinition applicationDefinition = await applicationDefinitionCollection.GetAsync("myApplicationDefinition");
            // With DeleteAsync(), we can delete the application definition
            await applicationDefinition.DeleteAsync();
            #endregion Snippet:Managing_ApplicationDefinitions_DeleteAnApplicationDefinition
        }

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
    }
}

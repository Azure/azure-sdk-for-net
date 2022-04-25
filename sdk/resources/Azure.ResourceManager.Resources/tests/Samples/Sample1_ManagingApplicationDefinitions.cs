// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_ApplicationDefinitions_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
#endregion Manage_ApplicationDefinitions_Namespaces

namespace Azure.ResourceManager.Resources.Tests.Samples
{
    public class Sample1_ManagingApplicationDefinitions
    {
        private ResourceGroupResource resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateApplicationDefinitions()
        {
            #region Snippet:Managing_ApplicationDefinitions_CreateAnApplicationDefinition
            // First we need to get the application definition collection from the resource group
            ArmApplicationDefinitionCollection applicationDefinitionCollection = resourceGroup.GetArmApplicationDefinitions();
            // Use the same location as the resource group
            string applicationDefinitionName = "myApplicationDefinition";
            var input = new ArmApplicationDefinitionData(resourceGroup.Data.Location, ArmApplicationLockLevel.None)
            {
                DisplayName = applicationDefinitionName,
                Description = $"{applicationDefinitionName} description",
                PackageFileUri = new Uri("https://raw.githubusercontent.com/Azure/azure-managedapp-samples/master/Managed%20Application%20Sample%20Packages/201-managed-storage-account/managedstorage.zip")
            };
            ArmOperation<ArmApplicationDefinitionResource> lro = await applicationDefinitionCollection.CreateOrUpdateAsync(WaitUntil.Completed, applicationDefinitionName, input);
            ArmApplicationDefinitionResource applicationDefinition = lro.Value;
            #endregion Snippet:Managing_ApplicationDefinitions_CreateAnApplicationDefinition
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListApplicationDefinitions()
        {
            #region Snippet:Managing_ApplicationDefinitions_ListAllApplicationDefinitions
            // First we need to get the application definition collection from the resource group
            ArmApplicationDefinitionCollection applicationDefinitionCollection = resourceGroup.GetArmApplicationDefinitions();
            // With GetAllAsync(), we can get a list of the application definitions in the collection
            AsyncPageable<ArmApplicationDefinitionResource> response = applicationDefinitionCollection.GetAllAsync();
            await foreach (ArmApplicationDefinitionResource applicationDefinition in response)
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
            ArmApplicationDefinitionCollection applicationDefinitionCollection = resourceGroup.GetArmApplicationDefinitions();
            // Now we can get the application definition with GetAsync()
            ArmApplicationDefinitionResource applicationDefinition = await applicationDefinitionCollection.GetAsync("myApplicationDefinition");
            // With DeleteAsync(), we can delete the application definition
            await applicationDefinition.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_ApplicationDefinitions_DeleteAnApplicationDefinition
        }

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
    }
}

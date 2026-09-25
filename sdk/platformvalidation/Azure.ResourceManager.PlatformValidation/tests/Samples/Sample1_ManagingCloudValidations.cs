// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:PlatformValidation_CloudValidations_Usings
using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.PlatformValidation;
using Azure.ResourceManager.PlatformValidation.Models;
using Azure.ResourceManager.Resources;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.PlatformValidation.Tests.Samples
{
    public class Sample1_ManagingCloudValidations
    {
        [Test]
        [Ignore("Only verifying that the sample builds. Running it creates and deletes Azure resources.")]
        public async Task ManageCloudValidations()
        {
            #region Snippet:PlatformValidation_CloudValidations_Authenticate
            string subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID")
                ?? throw new InvalidOperationException("Set AZURE_SUBSCRIPTION_ID.");
            string resourceGroupName = Environment.GetEnvironmentVariable("AZURE_RESOURCE_GROUP")
                ?? throw new InvalidOperationException("Set AZURE_RESOURCE_GROUP to an existing resource group.");
            string location = Environment.GetEnvironmentVariable("AZURE_LOCATION")
                ?? throw new InvalidOperationException("Set AZURE_LOCATION to a region supported by Platform Validation.");

            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceIdentifier resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroup = client.GetResourceGroupResource(resourceGroupId);
            CloudValidationCollection cloudValidations = resourceGroup.GetCloudValidations();
            #endregion

            #region Snippet:PlatformValidation_CloudValidations_Create
            string cloudValidationName = $"sample-{Guid.NewGuid():N}";
            CloudValidationData data = new CloudValidationData(new AzureLocation(location))
            {
                Properties = new CloudValidationProperties
                {
                    Description = "Cloud validation for grouping validation execution plans."
                }
            };

            ArmOperation<CloudValidationResource> operation = await cloudValidations.CreateOrUpdateAsync(
                WaitUntil.Completed, cloudValidationName, data);
            CloudValidationResource cloudValidation = operation.Value;
            Console.WriteLine($"Created cloud validation: {cloudValidation.Id}");
            #endregion

            #region Snippet:PlatformValidation_CloudValidations_GetAndList
            Response<CloudValidationResource> response = await cloudValidations.GetAsync(cloudValidationName);
            Console.WriteLine($"Description: {response.Value.Data.Properties.Description}");

            await foreach (CloudValidationResource item in cloudValidations.GetAllAsync())
            {
                Console.WriteLine(item.Id);
            }
            #endregion

            #region Snippet:PlatformValidation_CloudValidations_Delete
            await cloudValidation.DeleteAsync(WaitUntil.Completed);
            #endregion
        }
    }
}

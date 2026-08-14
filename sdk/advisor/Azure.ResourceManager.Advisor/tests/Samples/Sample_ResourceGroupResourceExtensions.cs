// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Advisor.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Advisor.Samples
{
    public partial class Sample_ResourceGroupResourceExtensions
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetConfigurations_GetConfigurations()
        {
            // Generated from example definition: specification/advisor/resource-manager/Microsoft.Advisor/stable/2020-01-01/examples/ListConfigurations.json
            // this example is just showing the usage of "Configurations_ListByResourceGroup" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "subscriptionId";
            string resourceGroup = "resourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroup);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // invoke the operation and iterate over the result
            await foreach (AdvisorConfigurationData item in resourceGroupResource.GetAdvisorConfigurationsByResourceGroupAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateConfiguration_PutConfigurations()
        {
            // Generated from example definition: specification/advisor/resource-manager/Microsoft.Advisor/stable/2020-01-01/examples/CreateConfiguration.json
            // this example is just showing the usage of "Configurations_CreateInResourceGroup" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "subscriptionId";
            string resourceGroup = "resourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroup);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // invoke the operation
            AdvisorConfigurationName configurationName = AdvisorConfigurationName.Default;
            AdvisorConfigurationData data = new AdvisorConfigurationData
            {
                IsExcluded = true,
                LowCpuThreshold = AdvisorCpuThreshold.Five,
                Digests = {new AdvisorDigestConfiguration
{
Name = "digestConfigName",
ActionGroupResourceId = "/subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/microsoft.insights/actionGroups/actionGroupName",
Frequency = 30,
Categories = { RecommendationCategory.HighAvailability, RecommendationCategory.Security, RecommendationCategory.Performance, RecommendationCategory.Cost, RecommendationCategory.OperationalExcellence},
Language = "en",
State = AdvisorDigestConfigurationState.Active,
}},
            };
            AdvisorConfigurationData result = await resourceGroupResource.CreateAdvisorConfigurationInResourceGroupAsync(configurationName, data);

            Console.WriteLine($"Succeeded: {result}");
        }
    }
}

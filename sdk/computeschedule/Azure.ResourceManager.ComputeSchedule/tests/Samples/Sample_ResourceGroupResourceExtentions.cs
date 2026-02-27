// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ComputeSchedule;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeSchedule.Tests.Samples
{
    public partial class Sample_ResourceGroupResourceExtensions
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAttachedResources_Occurrences_ListResources_MaximumSet_Gen()
        {
            // Generated from example definition: 2025-04-15-preview/Occurrences_ListResources_MaximumSet_Gen.json
            // this example is just showing the usage of "Occurrences_ListResources" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "myResourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // invoke the operation
            string scheduledActionName = "myScheduledAction";
            string occurrenceId = "myOccurrence";
            await foreach (OccurrenceResourceData item in resourceGroupResource.GetAttachedResourcesAsync(scheduledActionName, occurrenceId))
            {
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {item.Id}");
            }

            Console.WriteLine("Succeeded");
        }
    }
}

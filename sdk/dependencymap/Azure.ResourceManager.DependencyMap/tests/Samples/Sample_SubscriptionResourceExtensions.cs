// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.DependencyMap;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DependencyMap.Samples
{
    public partial class Sample_SubscriptionResourceExtensions
    {
        // Generated from example definition: specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_ListBySubscription.json
        // this example is just showing the usage of "Maps_ListBySubscription" operation, for the dependent resources, they will have to be created separately
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetDependencyMapsAsync_MapsListBySubscription()
        {
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "D6E58BDB-45F1-41EC-A884-1FC945058848";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            await foreach (DependencyMapResource item in subscriptionResource.GetDependencyMapsAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                DependencyMapData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
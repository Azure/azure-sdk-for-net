// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.DependencyMap.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DependencyMap.Tests.Samples
{
    public partial class Sample_DependencyMapDiscoverySourceCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_DiscoverySourcesCreateOrUpdateGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/DiscoverySources_CreateOrUpdate.json
            // this example is just showing the usage of "DiscoverySources_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DependencyMapResource created on azure
            // for more information of creating DependencyMapResource, please refer to the document of DependencyMapResource
            string subscriptionId = "D6E58BDB-45F1-41EC-A884-1FC945058848";
            string resourceGroupName = "rgdependencyMap";
            string mapName = "mapsTest1";
            ResourceIdentifier dependencyMapResourceId = DependencyMapResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, mapName);
            DependencyMapResource dependencyMapResource = client.GetDependencyMapResource(dependencyMapResourceId);

            // get the collection of this DependencyMapDiscoverySourceResource
            DependencyMapDiscoverySourceCollection collection = dependencyMapResource.GetDependencyMapDiscoverySources();

            // invoke the operation
            string sourceName = "sourceTest1";
            DependencyMapDiscoverySourceData data = new DependencyMapDiscoverySourceData(new AzureLocation("y"))
            {
                Properties = new OffAzureDiscoverySourceProperties(new ResourceIdentifier("wzlrkzumplzjmixbqv")),
                Tags = { }
            };
            ArmOperation<DependencyMapDiscoverySourceResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, sourceName, data);
            DependencyMapDiscoverySourceResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DependencyMapDiscoverySourceData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_DiscoverySourcesListByMapsResourceGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/DiscoverySources_ListByMapsResource.json
            // this example is just showing the usage of "DiscoverySources_ListByMapsResource" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DependencyMapResource created on azure
            // for more information of creating DependencyMapResource, please refer to the document of DependencyMapResource
            string subscriptionId = "D6E58BDB-45F1-41EC-A884-1FC945058848";
            string resourceGroupName = "rgdependencyMap";
            string mapName = "mapsTest1";
            ResourceIdentifier dependencyMapResourceId = DependencyMapResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, mapName);
            DependencyMapResource dependencyMapResource = client.GetDependencyMapResource(dependencyMapResourceId);

            // get the collection of this DependencyMapDiscoverySourceResource
            DependencyMapDiscoverySourceCollection collection = dependencyMapResource.GetDependencyMapDiscoverySources();

            // invoke the operation and iterate over the result
            await foreach (DependencyMapDiscoverySourceResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                DependencyMapDiscoverySourceData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}

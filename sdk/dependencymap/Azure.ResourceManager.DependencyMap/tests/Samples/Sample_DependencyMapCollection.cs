// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.DependencyMap;
using Azure.ResourceManager.DependencyMap.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DependencyMap.Tests.Samples
{
    public partial class Sample_DependencyMapCollection
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate_MapsCreateOrUpdateGeneratedByMaximumSetRule()
        {
            // Generated from example definition: specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_CreateOrUpdate.json
            // this example is just showing the usage of "Maps_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // get the collection of this resource
            string subscriptionId = "D6E58BDB-45F1-41EC-A884-1FC945058848";
            string resourceGroupName = "rgdependencyMap";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);
            DependencyMapCollection collection = resourceGroupResource.GetDependencyMaps();

            // invoke the operation
            string mapName = "mapsTest1";
            DependencyMapData data = new DependencyMapData(new AzureLocation("wjtzelgfcmswfeflfltwxqveo"))
            {
                Tags = { },
            };
            ArmOperation<DependencyMapResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, mapName, data);
            DependencyMapResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DependencyMapData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get_MapsGetGeneratedByMaximumSetRule()
        {
            // Generated from example definition: specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_Get.json
            // this example is just showing the usage of "Maps_Get" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // get the collection of this resource
            string subscriptionId = "D6E58BDB-45F1-41EC-A884-1FC945058848";
            string resourceGroupName = "rgdependencyMap";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);
            DependencyMapCollection collection = resourceGroupResource.GetDependencyMaps();

            // invoke the operation
            string mapName = "mapsTest1";
            DependencyMapResource result = await collection.GetAsync(mapName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DependencyMapData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Exists_MapsGetGeneratedByMaximumSetRule()
        {
            // Generated from example definition: specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_Get.json
            // this example is just showing the usage of "Maps_Get" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // get the collection of this resource
            string subscriptionId = "D6E58BDB-45F1-41EC-A884-1FC945058848";
            string resourceGroupName = "rgdependencyMap";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);
            DependencyMapCollection collection = resourceGroupResource.GetDependencyMaps();

            // invoke the operation
            string mapName = "mapsTest1";
            bool result = await collection.ExistsAsync(mapName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExists_MapsGetGeneratedByMaximumSetRule()
        {
            // Generated from example definition: specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_Get.json
            // this example is just showing the usage of "Maps_Get" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // get the collection of this resource
            string subscriptionId = "D6E58BDB-45F1-41EC-A884-1FC945058848";
            string resourceGroupName = "rgdependencyMap";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);
            DependencyMapCollection collection = resourceGroupResource.GetDependencyMaps();

            // invoke the operation
            string mapName = "mapsTest1";
            NullableResponse<DependencyMapResource> response = await collection.GetIfExistsAsync(mapName);
            DependencyMapResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine($"Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                DependencyMapData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}

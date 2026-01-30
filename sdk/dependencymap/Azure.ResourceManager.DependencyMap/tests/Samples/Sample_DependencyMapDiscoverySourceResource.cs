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
    public partial class Sample_DependencyMapDiscoverySourceResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_DiscoverySourcesGetGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/DiscoverySources_Get.json
            // this example is just showing the usage of "DiscoverySources_Get" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DependencyMapDiscoverySourceResource created on azure
            // for more information of creating DependencyMapDiscoverySourceResource, please refer to the document of DependencyMapDiscoverySourceResource
            string subscriptionId = "D6E58BDB-45F1-41EC-A884-1FC945058848";
            string resourceGroupName = "rgdependencyMap";
            string mapName = "mapsTest1";
            string sourceName = "sourceTest1";
            ResourceIdentifier dependencyMapDiscoverySourceResourceId = DependencyMapDiscoverySourceResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, mapName, sourceName);
            DependencyMapDiscoverySourceResource dependencyMapDiscoverySourceResource = client.GetDependencyMapDiscoverySourceResource(dependencyMapDiscoverySourceResourceId);

            // invoke the operation
            DependencyMapDiscoverySourceResource result = await dependencyMapDiscoverySourceResource.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DependencyMapDiscoverySourceData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_DiscoverySourcesUpdateGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/DiscoverySources_Update.json
            // this example is just showing the usage of "DiscoverySources_Update" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DependencyMapDiscoverySourceResource created on azure
            // for more information of creating DependencyMapDiscoverySourceResource, please refer to the document of DependencyMapDiscoverySourceResource
            string subscriptionId = "D6E58BDB-45F1-41EC-A884-1FC945058848";
            string resourceGroupName = "rgdependencyMap";
            string mapName = "mapsTest1";
            string sourceName = "sourceTest1";
            ResourceIdentifier dependencyMapDiscoverySourceResourceId = DependencyMapDiscoverySourceResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, mapName, sourceName);
            DependencyMapDiscoverySourceResource dependencyMapDiscoverySourceResource = client.GetDependencyMapDiscoverySourceResource(dependencyMapDiscoverySourceResourceId);

            // invoke the operation
            DependencyMapDiscoverySourcePatch patch = new DependencyMapDiscoverySourcePatch()
            {
                Tags = { }
            };
            ArmOperation<DependencyMapDiscoverySourceResource> lro = await dependencyMapDiscoverySourceResource.UpdateAsync(WaitUntil.Completed, patch);
            DependencyMapDiscoverySourceResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DependencyMapDiscoverySourceData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DiscoverySourcesDeleteGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/DiscoverySources_Delete.json
            // this example is just showing the usage of "DiscoverySources_Delete" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DependencyMapDiscoverySourceResource created on azure
            // for more information of creating DependencyMapDiscoverySourceResource, please refer to the document of DependencyMapDiscoverySourceResource
            string subscriptionId = "D6E58BDB-45F1-41EC-A884-1FC945058848";
            string resourceGroupName = "rgdependencyMap";
            string mapName = "mapsTest1";
            string sourceName = "sourceTest1";
            ResourceIdentifier dependencyMapDiscoverySourceResourceId = DependencyMapDiscoverySourceResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, mapName, sourceName);
            DependencyMapDiscoverySourceResource dependencyMapDiscoverySourceResource = client.GetDependencyMapDiscoverySourceResource(dependencyMapDiscoverySourceResourceId);

            // invoke the operation
            await dependencyMapDiscoverySourceResource.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }
    }
}

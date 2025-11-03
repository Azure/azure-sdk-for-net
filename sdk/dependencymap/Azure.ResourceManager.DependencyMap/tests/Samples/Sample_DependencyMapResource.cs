// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.DependencyMap;
using Azure.ResourceManager.DependencyMap.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DependencyMap.Samples
{
    public partial class Sample_DependencyMapResource
    {
        // Generated from example definition: specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_Delete.json
        // this example is just showing the usage of "Maps_Delete" operation, for the dependent resources, they will have to be created separately
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task DeleteAsync_MapsDelete()
        {
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

            // invoke the operation
            await dependencyMapResource.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }

        // Generated from example definition: specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_Update.json
        // this example is just showing the usage of "Maps_Update" operation, for the dependent resources, they will have to be created separately
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task UpdateAsync_MapsUpdate()
        {
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

            // invoke the operation
            DependencyMapPatch patch = new DependencyMapPatch()
            {
                Tags =
                {
                }
            };
            ArmOperation<DependencyMapResource> lro = await dependencyMapResource.UpdateAsync(WaitUntil.Completed, patch);
            DependencyMapResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DependencyMapData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Generated from example definition: specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_ExportDependencies.json
        // this example is just showing the usage of "Maps_ExportDependencies" operation, for the dependent resources, they will have to be created separately
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task ExportDependenciesAsync_MapsExportDependencies()
        {
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

            // invoke the operation
            ExportDependenciesContent content = new ExportDependenciesContent()
            {
                FocusedMachineId = new ResourceIdentifier("qzjpilzxpurauwfwwanpiiafvz"),
                Filters = new DependencyMapVisualizationFilter()
                {
                    DateTime = new DependencyMapDateTimeFilter()
                    {
                        StartOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z"),
                        EndOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z"),
                    },
                    ProcessNameFilter = new DependencyMapProcessNameFilter(DependencyMapProcessNameFilterOperator.Contains, new string[]
                    {
                        "mnqtvduwzemjcvvmnnoqvcuemwhnz"
                    }),
                },
            };
            content.ApplianceNameList.Add("guwwagnitv");
            ArmOperation<ExportDependenciesOperationResult> lro = await dependencyMapResource.ExportDependenciesAsync(WaitUntil.Completed, content);
            ExportDependenciesOperationResult result = lro.Value;

            Console.WriteLine($"Succeeded: {result}");
        }

        // Generated from example definition: specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_GetDependencyViewForFocusedMachine.json
        // this example is just showing the usage of "Maps_GetDependencyViewForFocusedMachine" operation, for the dependent resources, they will have to be created separately
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetDependencyViewForFocusedMachineAsync_MapsGetDependencyViewForFocusedMachine()
        {
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

            // invoke the operation
            GetDependencyViewForFocusedMachineContent content = new GetDependencyViewForFocusedMachineContent(new ResourceIdentifier("imzykeisagngrnfinbqtu"))
            {
                Filters = new DependencyMapVisualizationFilter()
                {
                    DateTime = new DependencyMapDateTimeFilter()
                    {
                        StartOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z"),
                        EndOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z"),
                    },
                    ProcessNameFilter = new DependencyMapProcessNameFilter(DependencyMapProcessNameFilterOperator.Contains, new string[]
                    {
                        "mnqtvduwzemjcvvmnnoqvcuemwhnz"
                    }),
                },
            };
            ArmOperation lro = await dependencyMapResource.GetDependencyViewForFocusedMachineAsync(WaitUntil.Completed, content);

            Console.WriteLine($"Succeeded");
        }

        // Generated from example definition: specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_GetConnectionsWithConnectedMachineForFocusedMachine.json
        // this example is just showing the usage of "Maps_GetConnectionsWithConnectedMachineForFocusedMachine" operation, for the dependent resources, they will have to be created separately
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetConnectionsWithConnectedMachineForFocusedMachineAsync_MapsGetConnectionsWithConnectedMachineForFocusedMachine()
        {
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

            // invoke the operation
            GetConnectionsWithConnectedMachineForFocusedMachineContent content = new GetConnectionsWithConnectedMachineForFocusedMachineContent(new ResourceIdentifier("gagovctcfgocievqwq"), new ResourceIdentifier("enaieiloylabljxzvmyrshp"))
            {
                Filters = new DependencyMapVisualizationFilter()
                {
                    DateTime = new DependencyMapDateTimeFilter()
                    {
                        StartOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z"),
                        EndOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z"),
                    },
                    ProcessNameFilter = new DependencyMapProcessNameFilter(DependencyMapProcessNameFilterOperator.Contains, new string[]
                    {
                        "mnqtvduwzemjcvvmnnoqvcuemwhnz"
                    }),
                },
            };
            ArmOperation lro = await dependencyMapResource.GetConnectionsWithConnectedMachineForFocusedMachineAsync(WaitUntil.Completed, content);

            Console.WriteLine($"Succeeded");
        }
    }
}

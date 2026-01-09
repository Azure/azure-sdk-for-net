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
    public partial class Sample_DependencyMapResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_MapsGetGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/Maps_Get.json
            // this example is just showing the usage of "Maps_Get" operation, for the dependent resources, they will have to be created separately

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
            DependencyMapResource result = await dependencyMapResource.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DependencyMapData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_MapsUpdateGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/Maps_Update.json
            // this example is just showing the usage of "Maps_Update" operation, for the dependent resources, they will have to be created separately

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
                Tags = { }
            };
            ArmOperation<DependencyMapResource> lro = await dependencyMapResource.UpdateAsync(WaitUntil.Completed, patch);
            DependencyMapResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DependencyMapData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_MapsDeleteGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/Maps_Delete.json
            // this example is just showing the usage of "Maps_Delete" operation, for the dependent resources, they will have to be created separately

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

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task ExportDependencies_MapsExportDependenciesGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/Maps_ExportDependencies.json
            // this example is just showing the usage of "Maps_ExportDependencies" operation, for the dependent resources, they will have to be created separately

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
                        EndOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z")
                    },
                    ProcessNameFilter = new DependencyMapProcessNameFilter(DependencyMapProcessNameFilterOperator.Contains, new string[] { "mnqtvduwzemjcvvmnnoqvcuemwhnz" })
                }
            };
            content.ApplianceNameList.Add("guwwagnitv");
            ArmOperation<ExportDependenciesOperationResult> lro = await dependencyMapResource.ExportDependenciesAsync(WaitUntil.Completed, content);
            ExportDependenciesOperationResult result = lro.Value;

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetDependencyViewForFocusedMachine_MapsGetDependencyViewForFocusedMachineGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/Maps_GetDependencyViewForFocusedMachine.json
            // this example is just showing the usage of "Maps_GetDependencyViewForFocusedMachine" operation, for the dependent resources, they will have to be created separately

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
            ResourceIdentifier focusedMachineId = new ResourceIdentifier("imzykeisagngrnfinbqtu");
            GetDependencyViewForFocusedMachineContent content = new GetDependencyViewForFocusedMachineContent(focusedMachineId)
            {
                Filters = new DependencyMapVisualizationFilter()
                {
                    DateTime = new DependencyMapDateTimeFilter()
                    {
                        StartOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z"),
                        EndOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z")
                    },
                    ProcessNameFilter = new DependencyMapProcessNameFilter(DependencyMapProcessNameFilterOperator.Contains, new string[] { "mnqtvduwzemjcvvmnnoqvcuemwhnz" })
                }
            };
            await dependencyMapResource.GetDependencyViewForFocusedMachineAsync(WaitUntil.Completed, content);

            Console.WriteLine($"Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetConnectionsWithConnectedMachineForFocusedMachine_MapsGetConnectionsWithConnectedMachineForFocusedMachineGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/Maps_GetConnectionsWithConnectedMachineForFocusedMachine.json
            // this example is just showing the usage of "Maps_GetConnectionsWithConnectedMachineForFocusedMachine" operation, for the dependent resources, they will have to be created separately

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
            ResourceIdentifier focusedMachineId = new ResourceIdentifier("gagovctcfgocievqwq");
            ResourceIdentifier connectedMachineId = new ResourceIdentifier("enaieiloylabljxzvmyrshp");
            GetConnectionsWithConnectedMachineForFocusedMachineContent content = new GetConnectionsWithConnectedMachineForFocusedMachineContent(focusedMachineId, connectedMachineId)
            {
                Filters = new DependencyMapVisualizationFilter()
                {
                    DateTime = new DependencyMapDateTimeFilter()
                    {
                        StartOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z"),
                        EndOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z")
                    },
                    ProcessNameFilter = new DependencyMapProcessNameFilter(DependencyMapProcessNameFilterOperator.Contains, new string[] { "mnqtvduwzemjcvvmnnoqvcuemwhnz" })
                }
            };
            await dependencyMapResource.GetConnectionsWithConnectedMachineForFocusedMachineAsync(WaitUntil.Completed, content);

            Console.WriteLine($"Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetConnectionsForProcessOnFocusedMachine_MapsGetConnectionsForProcessOnFocusedMachineGeneratedByMaximumSetRule()
        {
            // Generated from example definition: 2025-05-01-preview/Maps_GetConnectionsForProcessOnFocusedMachine.json
            // this example is just showing the usage of "Maps_GetConnectionsForProcessOnFocusedMachine" operation, for the dependent resources, they will have to be created separately

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
            ResourceIdentifier focusedMachineId = new ResourceIdentifier("abjy");
            string processIdOnFocusedMachine = "yzldgsfupsfvzlztqoqpiv";
            GetConnectionsForProcessOnFocusedMachineContent content = new GetConnectionsForProcessOnFocusedMachineContent(focusedMachineId, processIdOnFocusedMachine)
            {
                Filters = new DependencyMapVisualizationFilter()
                {
                    DateTime = new DependencyMapDateTimeFilter()
                    {
                        StartOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z"),
                        EndOn = DateTimeOffset.Parse("2024-03-29T07:35:15.336Z")
                    },
                    ProcessNameFilter = new DependencyMapProcessNameFilter(DependencyMapProcessNameFilterOperator.Contains, new string[] { "mnqtvduwzemjcvvmnnoqvcuemwhnz" })
                }
            };
            await dependencyMapResource.GetConnectionsForProcessOnFocusedMachineAsync(WaitUntil.Completed, content);

            Console.WriteLine($"Succeeded");
        }
    }
}

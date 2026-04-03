// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.DevCenter.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests.Samples
{
    public class Sample2_ProjectOperations
    {
        private ResourceGroupResource _resourceGroup;
        private DevCenterResource _devCenter;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateProject()
        {
            #region Snippet:DevCenter_CreateProject
            DevCenterProjectCollection projectCollection = _resourceGroup.GetDevCenterProjects();

            DevCenterProjectData projectData = new DevCenterProjectData(AzureLocation.EastUS)
            {
                DevCenterId = _devCenter.Id,
                Description = "My first Dev Center project.",
                Tags = { ["CostCenter"] = "R&D" }
            };
            ArmOperation<DevCenterProjectResource> projectLro = await projectCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "DevProject",
                projectData);
            DevCenterProjectResource project = projectLro.Value;
            Console.WriteLine($"Created Project with id: {project.Data.Id}");
            #endregion Snippet:DevCenter_CreateProject
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDevBoxDefinition()
        {
            #region Snippet:DevCenter_CreateDevBoxDefinition
            DevBoxDefinitionCollection devBoxDefinitionCollection = _devCenter.GetDevBoxDefinitions();

            DevBoxDefinitionData data = new DevBoxDefinitionData(AzureLocation.EastUS)
            {
                ImageReference = new DevCenterImageReference
                {
                    Id = new ResourceIdentifier(
                        $"{_devCenter.Id}/galleries/contosogallery/images/exampleImage/version/1.0.0")
                },
                Sku = new DevCenterSku("general_i_8c32gb256ssd_v2"),
                HibernateSupport = DevCenterHibernateSupport.IsEnabled,
            };
            ArmOperation<DevBoxDefinitionResource> devBoxDefinitionLro = await devBoxDefinitionCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "WebDevBox",
                data);
            DevBoxDefinitionResource devBoxDefinition = devBoxDefinitionLro.Value;
            Console.WriteLine($"Created DevBox definition with id: {devBoxDefinition.Data.Id}");
            #endregion Snippet:DevCenter_CreateDevBoxDefinition
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreatePool()
        {
            #region Snippet:DevCenter_CreatePool
            // Get the project resource
            DevCenterProjectCollection projectCollection = _resourceGroup.GetDevCenterProjects();
            DevCenterProjectResource project = await projectCollection.GetAsync("DevProject");

            // Create a pool in the project
            DevCenterPoolCollection poolCollection = project.GetDevCenterPools();
            DevCenterPoolData poolData = new DevCenterPoolData(AzureLocation.EastUS)
            {
                DevBoxDefinitionName = "WebDevBox",
                NetworkConnectionName = "Network1-eastus",
                LicenseType = DevCenterLicenseType.WindowsClient,
                LocalAdministrator = LocalAdminStatus.IsEnabled,
                StopOnDisconnect = new StopOnDisconnectConfiguration
                {
                    Status = StopOnDisconnectEnableStatus.IsEnabled,
                    GracePeriodMinutes = 60,
                },
            };
            ArmOperation<DevCenterPoolResource> poolLro = await poolCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "DevPool",
                poolData);
            DevCenterPoolResource pool = poolLro.Value;
            Console.WriteLine($"Created pool with id: {pool.Data.Id}");
            #endregion Snippet:DevCenter_CreatePool
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateNetworkConnection()
        {
            #region Snippet:DevCenter_CreateNetworkConnection
            DevCenterNetworkConnectionCollection networkConnectionCollection = _resourceGroup.GetDevCenterNetworkConnections();

            DevCenterNetworkConnectionData networkData = new DevCenterNetworkConnectionData(AzureLocation.EastUS)
            {
                SubnetId = new ResourceIdentifier(
                    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ExampleRG/providers/Microsoft.Network/virtualNetworks/ExampleVNet/subnets/default"),
                DomainJoinType = DomainJoinType.AzureADJoin,
            };
            ArmOperation<DevCenterNetworkConnectionResource> networkLro = await networkConnectionCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "eastus-network",
                networkData);
            DevCenterNetworkConnectionResource networkConnection = networkLro.Value;
            Console.WriteLine($"Created network connection with id: {networkConnection.Data.Id}");
            #endregion Snippet:DevCenter_CreateNetworkConnection
        }
    }
}

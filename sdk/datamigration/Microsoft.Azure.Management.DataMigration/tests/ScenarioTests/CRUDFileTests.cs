// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using DataMigration.Tests.Helpers;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace DataMigration.Tests.ScenarioTests
{
    public class CRUDFileTests : CRUDDMSTestsBase
    {
        [Fact]
        public void CreateResourceSucceeds()
        {
            var dmsClientHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var resourcesHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceGroup = CreateResourceGroup(context, resourcesHandler, ResourceGroupName, TestConfiguration.Location);
                var dmsClient = Utilities.GetDataMigrationManagementClient(context, dmsClientHandler);
                var service = CreateDMSInstance(context, dmsClient, resourceGroup, DmsDeploymentName);
                var project = CreateDMSSqlProject(context, dmsClient, resourceGroup, service.Name, DmsProjectName);
                var task = CreateDMSFile(context, dmsClient, resourceGroup, service, project.Name, DmsFileName);
            }
            // Wait for resource group deletion to complete.
            Utilities.WaitIfNotInPlaybackMode();
        }

        [Fact]
        public void GetResourceSucceeds()
        {
            var dmsClientHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var resourcesHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceGroup = CreateResourceGroup(context, resourcesHandler, ResourceGroupName, TestConfiguration.Location);
                var dmsClient = Utilities.GetDataMigrationManagementClient(context, dmsClientHandler);
                var service = CreateDMSInstance(context, dmsClient, resourceGroup, DmsDeploymentName);
                var project = CreateDMSSqlProject(context, dmsClient, resourceGroup, service.Name, DmsProjectName);
                var file = CreateDMSFile(context, dmsClient, resourceGroup, service, project.Name, DmsFileName);
                var getResult = dmsClient.Files.Get(resourceGroup.Name, service.Name, project.Name, file.Name);
            }
            // Wait for resource group deletion to complete.
            Utilities.WaitIfNotInPlaybackMode();
        }

        [Fact]
        public void DeleteResourceSucceeds()
        {
            var dmsClientHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var resourcesHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceGroup = CreateResourceGroup(context, resourcesHandler, ResourceGroupName, TestConfiguration.Location);
                var dmsClient = Utilities.GetDataMigrationManagementClient(context, dmsClientHandler);
                var service = CreateDMSInstance(context, dmsClient, resourceGroup, DmsDeploymentName);
                var project = CreateDMSSqlProject(context, dmsClient, resourceGroup, service.Name, DmsProjectName);
                var file = CreateDMSFile(context, dmsClient, resourceGroup, service, project.Name, DmsFileName);
                var getResult = dmsClient.Files.Get(resourceGroup.Name, service.Name, project.Name, file.Name);
                Utilities.WaitIfNotInPlaybackMode(1);
                dmsClient.Files.Delete(resourceGroup.Name, service.Name, project.Name, file.Name);
                var x = Assert.Throws<ApiErrorException>(() => dmsClient.Files.Get(resourceGroup.Name, service.Name, project.Name, file.Name));
                Assert.Equal(HttpStatusCode.NotFound, x.Response.StatusCode);
            }
            // Wait for resource group deletion to complete.
            Utilities.WaitIfNotInPlaybackMode();
        }

        private ProjectFile CreateDMSFile(MockContext context,
            DataMigrationServiceClient client,
            ResourceGroup resourceGroup,
            DataMigrationService service,
            string dmsProjectName,
            string dmsFileName)
        {
            var fileProps = new ProjectFileProperties
            {
                FilePath = "NorthWind.sql"
            };

            return client.Files.CreateOrUpdate(
                        new ProjectFile { Properties = fileProps },
                        resourceGroup.Name,
                        service.Name,
                        dmsProjectName,
                        dmsFileName);
        }
    }
}


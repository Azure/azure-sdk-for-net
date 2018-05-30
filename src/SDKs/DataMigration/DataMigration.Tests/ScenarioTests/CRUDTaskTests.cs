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
    public class CRUDTaskTests : CRUDDMSTestsBase
    {
        [Fact]
        public void CreateResourceSucceeds()
        {
            var dmsClientHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var resourcesHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceGroup = CreateResourceGroup(context, resourcesHandler, ResourceGroupName, TestConfiguration.Location);
                var dmsClient = Utilities.GetDataMigrationManagementClient(context, dmsClientHandler);
                var service = CreateDMSInstance(context, dmsClient, resourceGroup, DmsDeploymentName);
                var project = CreateDMSProject(context, dmsClient, resourceGroup, service.Name, DmsProjectName);
                var task = CreateDMSTask(context, dmsClient, resourceGroup, service, project.Name, DmsTaskName);
            }
            // Wait for resource group deletion to complete.
            Utilities.WaitIfNotInPlaybackMode();
        }

        [Fact]
        public void GetResourceSucceeds()
        {
            var dmsClientHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var resourcesHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceGroup = CreateResourceGroup(context, resourcesHandler, ResourceGroupName, TestConfiguration.Location);
                var dmsClient = Utilities.GetDataMigrationManagementClient(context, dmsClientHandler);
                var service = CreateDMSInstance(context, dmsClient, resourceGroup, DmsDeploymentName);
                var project = CreateDMSProject(context, dmsClient, resourceGroup, service.Name, DmsProjectName);
                var task = CreateDMSTask(context, dmsClient, resourceGroup, service, project.Name, DmsTaskName);
                var getResult = dmsClient.Tasks.Get(resourceGroup.Name, service.Name, project.Name, task.Name);
            }
            // Wait for resource group deletion to complete.
            Utilities.WaitIfNotInPlaybackMode();
        }

        [Fact]
        public void DeleteResourceSucceeds()
        {
            var dmsClientHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var resourcesHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceGroup = CreateResourceGroup(context, resourcesHandler, ResourceGroupName, TestConfiguration.Location);
                var dmsClient = Utilities.GetDataMigrationManagementClient(context, dmsClientHandler);
                var service = CreateDMSInstance(context, dmsClient, resourceGroup, DmsDeploymentName);
                var project = CreateDMSProject(context, dmsClient, resourceGroup, service.Name, DmsProjectName);
                var task = CreateDMSTask(context, dmsClient, resourceGroup, service, project.Name, DmsTaskName);
                var getResult = dmsClient.Tasks.Get(resourceGroup.Name, service.Name, project.Name, task.Name);

                dmsClient.Tasks.Cancel(resourceGroup.Name, service.Name, project.Name, task.Name);
                dmsClient.Tasks.Delete(resourceGroup.Name, service.Name, project.Name, task.Name);

                var x = Assert.Throws<ApiErrorException>(() => dmsClient.Tasks.Get(resourceGroup.Name, service.Name, project.Name, task.Name));
                Assert.Equal(HttpStatusCode.NotFound, x.Response.StatusCode);
            }
            // Wait for resource group deletion to complete.
            Utilities.WaitIfNotInPlaybackMode();
        }

        private ProjectTask CreateDMSTask(MockContext context,
            DataMigrationServiceClient client,
            ResourceGroup resourceGroup,
            DataMigrationService service,
            string dmsProjectName,
            string dmsTaskName)
        {
            var taskProps = new ConnectToTargetSqlDbTaskProperties
            {
                Input = new ConnectToTargetSqlDbTaskInput(
                    new SqlConnectionInfo
                    {
                        DataSource = "ssma-test-server.database.windows.net",
                        EncryptConnection = true,
                        TrustServerCertificate = true,
                        UserName = "testuser",
                        Password = "testPassword",
                        Authentication = AuthenticationType.SqlAuthentication,
                    }
                )
            };

            return client.Tasks.CreateOrUpdate(
                        new ProjectTask(
                            properties: taskProps),
                        resourceGroup.Name,
                        service.Name,
                        dmsProjectName,
                        dmsTaskName);
        }
    }
}

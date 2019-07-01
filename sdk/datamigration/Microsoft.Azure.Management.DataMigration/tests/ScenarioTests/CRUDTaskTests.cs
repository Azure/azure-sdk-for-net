// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
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
        public void RunCommandSucceeds()
        {
            var dmsClientHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var resourcesHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceGroup = CreateResourceGroup(context, resourcesHandler, ResourceGroupName, TestConfiguration.Location);
                var dmsClient = Utilities.GetDataMigrationManagementClient(context, dmsClientHandler);
                var service = CreateDMSInstance(context, dmsClient, resourceGroup, DmsDeploymentName);
                var project = CreateDMSProject(context, dmsClient, resourceGroup, service.Name, DmsProjectName);
                var task = CreateDMSSyncTask(context, dmsClient, resourceGroup, service, project.Name, DmsTaskName);
                bool wait = true;
                do
                {
                    var getResult = dmsClient.Tasks.Get(resourceGroup.Name, service.Name, project.Name, task.Name, "output");

                    Assert.True(getResult.Properties.State.Equals(TaskState.Queued) || getResult.Properties.State.Equals(TaskState.Running));

                    MigrateSqlServerSqlDbSyncTaskProperties properties = (MigrateSqlServerSqlDbSyncTaskProperties)getResult.Properties;
                    var databaseLevelResult = (MigrateSqlServerSqlDbSyncTaskOutputDatabaseLevel)properties.Output.Where(o => o.GetType() == typeof(MigrateSqlServerSqlDbSyncTaskOutputDatabaseLevel)).FirstOrDefault();
                    if (databaseLevelResult != null && databaseLevelResult.MigrationState == SyncDatabaseMigrationReportingState.READYTOCOMPLETE)
                    {
                        wait = false;
                    }
                }
                while (wait);
                
                var commandProperties = new MigrateSyncCompleteCommandProperties
                {
                    Input = new MigrateSyncCompleteCommandInput
                    {
                        DatabaseName = "DatabaseName"
                    },
                };

                var command = dmsClient.Tasks.Command(resourceGroup.Name, service.Name, project.Name, task.Name, commandProperties);
                Assert.Equal(command.State, CommandState.Accepted);
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
                Utilities.WaitIfNotInPlaybackMode();
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
                        DataSource = "shuhuandmsdbs.database.windows.net",
                        EncryptConnection = true,
                        TrustServerCertificate = true,
                        UserName = "testuser",
                        Password = "testuserpw",
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

        private ProjectTask CreateDMSSyncTask(MockContext context,
            DataMigrationServiceClient client,
            ResourceGroup resourceGroup,
            DataMigrationService service,
            string dmsProjectName,
            string dmsTaskName)
        {
            var taskProps = new MigrateSqlServerSqlDbSyncTaskProperties
            {
                Input = new MigrateSqlServerSqlDbSyncTaskInput(
                    new SqlConnectionInfo
                    {
                        DataSource = @"steven-work.redmond.corp.microsoft.com\stevenf16,12345",
                        EncryptConnection = true,
                        TrustServerCertificate = true,
                        UserName = "testuser",
                        Password = "Dr22VHg@_,P3",
                        Authentication = AuthenticationType.SqlAuthentication,
                    },
                    new SqlConnectionInfo
                    {
                        DataSource = "shuhuandmsdbs.database.windows.net",
                        EncryptConnection = true,
                        TrustServerCertificate = true,
                        UserName = "testuser",
                        Password = "Dr22VHg@_,P3",
                        Authentication = AuthenticationType.SqlAuthentication,
                    },
                    new List<MigrateSqlServerSqlDbSyncDatabaseInput>
                    {
                        new MigrateSqlServerSqlDbSyncDatabaseInput
                        {
                            Name = "JasmineTest",
                            TargetDatabaseName = "JasmineTest",
                            TableMap = new Dictionary<string, string> { { "dbo.TestTable1", "dbo.TestTable1" }, { "dbo.TestTable2", "dbo.TestTable2" } }
                        }
                    })
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

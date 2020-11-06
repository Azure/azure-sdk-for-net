// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using PostgreSQL.Tests.Helpers;
using Microsoft.Azure.Management.PostgreSQL.FlexibleServers;
using Microsoft.Azure.Management.PostgreSQL.FlexibleServers.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace PostgreSQL.Tests.ScenarioTests
{
    public class CRUDFlexibleServersServiceTests : CRUDDBForPostgreSQLFlexibleServerTestBase
    {
        [Fact]
        public void CreateResourceSucceeds()
        {
            var clientHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var resourcesHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceGroup = CreateResourceGroup(context, resourcesHandler, ResourceGroupName, TestConfiguration.Location);
                var client = Utilities.GetPostgreSQLFlexibleServersManagementClient(context, clientHandler);
                var createResult = CreatePostgreSQLFlexibleServersInstance(context, client, resourceGroup, ServerName);
            }
            // Wait for resource group deletion to complete.
            Utilities.WaitIfNotInPlaybackMode();
        }

        [Fact]
        public void GetResourceSucceeds()
        {
            var clientHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var resourcesHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceGroup = CreateResourceGroup(context, resourcesHandler, ResourceGroupName, TestConfiguration.Location);
                var client = Utilities.GetPostgreSQLFlexibleServersManagementClient(context, clientHandler);
                var createResult = CreatePostgreSQLFlexibleServersInstance(context, client, resourceGroup, ServerName);
                var getResult = client.Servers.Get(resourceGroup.Name, ServerName);
            }
            // Wait for resource group deletion to complete.
            Utilities.WaitIfNotInPlaybackMode();
        }

        [Fact]
        public void DeleteResourceSucceeds()
        {
            var clientHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var resourcesHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceGroup = CreateResourceGroup(context, resourcesHandler, ResourceGroupName, TestConfiguration.Location);
                var client = Utilities.GetPostgreSQLFlexibleServersManagementClient(context, clientHandler);
                var createResult = CreatePostgreSQLFlexibleServersInstance(context, client, resourceGroup, ServerName);
                var getResult = client.Servers.Get(resourceGroup.Name, ServerName);
                client.Servers.Delete(resourceGroup.Name, ServerName);
            }
            // Wait for resource group deletion to complete.
            Utilities.WaitIfNotInPlaybackMode();
        }
    }
}

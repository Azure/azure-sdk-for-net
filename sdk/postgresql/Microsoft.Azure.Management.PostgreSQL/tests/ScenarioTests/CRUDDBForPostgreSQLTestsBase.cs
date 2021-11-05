// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using PostgreSQL.Tests.Helpers;
using Microsoft.Azure.Management.PostgreSQL;
using Microsoft.Azure.Management.PostgreSQL.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace PostgreSQL.Tests.ScenarioTests
{
    public class CRUDPostgreSQLTestsBase : TestBase
    {
        protected static string ResourceGroupName;
        protected static string ServerName;
        protected static string DmsProjectName;
        protected static string DmsTaskName;
        
        public CRUDPostgreSQLTestsBase()
        {
            ResourceGroupName = "pgsdkrg";
            ServerName = "pgsdkserver";
        }

        protected Server CreatePostgreSQLInstance(MockContext context,
            PostgreSQLManagementClient client,
            ResourceGroup resourceGroup,
            string serverName)
        {
            return client.Servers.Create(
                resourceGroup.Name,
                serverName,
                new ServerForCreate(
                    properties: new ServerPropertiesForDefaultCreate(
                        administratorLogin: "testUser",
                        administratorLoginPassword: "testPassword1!"),
                    location: resourceGroup.Location,
                    sku: new Microsoft.Azure.Management.PostgreSQL.Models.Sku(name: "B_Gen5_1")));
        }

        protected ResourceGroup CreateResourceGroup(MockContext context,
            RecordedDelegatingHandler handler,
            string resourceGroupName,
            string location)
        {
            var resourcesClient =
                Utilities.GetResourceManagementClient(
                    context,
                    handler);

            var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = location
                });

            return resourceGroup;
        }

        protected void DeleteResourceGroup(MockContext context,
            RecordedDelegatingHandler handler,
            string resourceGroupName)
        {
            var resourcesClient =
                Utilities.GetResourceManagementClient(
                    context,
                    handler);

            resourcesClient.ResourceGroups.Delete(resourceGroupName);
        }
    }
}


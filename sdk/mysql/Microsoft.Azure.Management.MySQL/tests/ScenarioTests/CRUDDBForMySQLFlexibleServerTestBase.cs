// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using MySQL.Tests.Helpers;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.MySQL.FlexibleServers;
using FlexibleServersModels = Microsoft.Azure.Management.MySQL.FlexibleServers.Models;


namespace MySQL.Tests.ScenarioTests
{
    public class CRUDDBForMySQLFlexibleServerTestBase
    {
        protected static string ResourceGroupName;
        protected static string ServerName;


        public CRUDDBForMySQLFlexibleServerTestBase()
        {
            ResourceGroupName = "mysqlnetsdkrg";
            ServerName = "mysqlsdkflexserver";

        }

        protected FlexibleServersModels.Server CreateMySQLFlexibleServersInstance(MockContext context,
            MySQLManagementClient client,
            ResourceGroup resourceGroup,
            string serverName)
        {
            return client.Servers.Create(
                resourceGroup.Name,
                serverName,
                new FlexibleServersModels.Server(location: resourceGroup.Location,
                            sku: new FlexibleServersModels.Sku("Standard_B1ms", "Burstable"),
                            administratorLogin: "testUser",
                            administratorLoginPassword: "testPassword1!",
                            version: "5.7",
                            storage: new FlexibleServersModels.Storage(storageSizeGB: 512)));
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

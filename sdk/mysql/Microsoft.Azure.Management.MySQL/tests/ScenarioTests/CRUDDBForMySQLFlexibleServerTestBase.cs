// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
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
            ResourceGroupName = "mysqlsdkrg";
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
                            sku: new FlexibleServersModels.Sku("Standard_D4s_v3", "GeneralPurpose"),
                            administratorLogin: "testUser",
                            administratorLoginPassword: "testPassword1!",
                            version: "5.7",
                            storageProfile: new FlexibleServersModels.StorageProfile(storageMB: 524288)));
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

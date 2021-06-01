// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Sql.Tests
{
    public class ActiveDirectoryAdministratorTest
    {
        [Fact]
        public void TestSetServerActiveDirectoryAdministrator()
        {
            string aadAdmin = "DSEngAll";

            Dictionary<string, string> tags = new Dictionary<string, string>();

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                Guid objectId = new Guid(TestEnvironmentUtilities.GetUserObjectId());
                Guid tenantId = new Guid(TestEnvironmentUtilities.GetTenantId());
                
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);

                // Add new Active Directory Admin
                ServerAzureADAdministrator newAdmin = new ServerAzureADAdministrator(
                    aadAdmin, objectId, tenantId: tenantId);
                ServerAzureADAdministrator createResult = sqlClient.ServerAzureADAdministrators.CreateOrUpdate(resourceGroup.Name, server.Name, newAdmin);

                Assert.Equal(aadAdmin, createResult.Login);

                // Get the current Active Directory Admin
                ServerAzureADAdministrator getCreateResult = sqlClient.ServerAzureADAdministrators.Get(resourceGroup.Name, server.Name);
                Assert.Equal(aadAdmin, getCreateResult.Login);
                Assert.Equal(objectId, getCreateResult.Sid);
                Assert.Equal(tenantId, getCreateResult.TenantId);
                
                // Delete the Active Directory Admin on server
                sqlClient.ServerAzureADAdministrators.Delete(resourceGroup.Name, server.Name);

                // List all Active Directory Admin
                List<ServerAzureADAdministrator> admins = sqlClient.ServerAzureADAdministrators.ListByServer(resourceGroup.Name,server.Name) as List<ServerAzureADAdministrator>;
                Assert.True(admins == null || admins.Count == 0);
            }
        }
    }
}

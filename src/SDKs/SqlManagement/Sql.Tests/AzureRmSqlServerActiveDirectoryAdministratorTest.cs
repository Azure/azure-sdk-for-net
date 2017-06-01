// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Sql.Tests
{
    public class AzureRmSqlServerActiveDirectoryAdministratorTest
    {
        [Fact]
        public void TestSetServerActiveDirectoryAdministrator()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            string aadAdmin = "DSEngAll";

            Dictionary<string, string> tags = new Dictionary<string, string>();
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestSetServerActiveDirectoryAdministrator", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Add new Active Directory Admin
                ServerAzureADAdministrator newAdmin = new ServerAzureADAdministrator("DSEngAll", new Guid("5e90ef3b-9b42-4777-819b-25c36961ea4d"), new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), "sqlcrudtest-3421", "2c647056-bab2-4175-b172-493ff049eb29");
                ServerAzureADAdministrator createResult = sqlClient.ServerAzureADAdministrators.CreateOrUpdate(resourceGroup.Name, server.Name, newAdmin);
                
                Assert.Equal(aadAdmin, createResult.Login);

                // Get the current Active Directory Admin
                ServerAzureADAdministrator getResult = sqlClient.ServerAzureADAdministrators.Get(resourceGroup.Name, server.Name);
                Assert.Equal(aadAdmin, getResult.Login);
                Assert.Equal(new Guid("5e90ef3b-9b42-4777-819b-25c36961ea4d"), getResult.Sid);
                Assert.Equal(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), getResult.TenantId);

                // Delete the Active Directory Admin on server
                sqlClient.ServerAzureADAdministrators.Delete(resourceGroup.Name, server.Name);
                
                // List all Active Directory Admin
                List<ServerAzureADAdministrator> admins = sqlClient.ServerAzureADAdministrators.List(resourceGroup.Name,server.Name) as List<ServerAzureADAdministrator>;
                Assert.True(admins == null || admins.Count == 0);
                
            });
        }
    }
}

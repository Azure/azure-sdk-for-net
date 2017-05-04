// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            string login = "dummylogin";
            string password = "Un53cuRE!";
            string version12 = "12.0";

            Dictionary<string, string> tags = new Dictionary<string, string>();
            SqlManagementTestUtilities.RunTestInNewResourceGroup(suiteName, "TestSetServerActiveDirectoryAdministrator", testPrefix, (resClient, sqlClient, resourceGroup) =>
            {
                // Create a server
                string serverName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var server = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, serverName, new Microsoft.Azure.Management.Sql.Models.Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Location = SqlManagementTestUtilities.DefaultLocation,
                    Tags = tags,
                });

                SqlManagementTestUtilities.ValidateServer(server, serverName, login, version12, tags, SqlManagementTestUtilities.DefaultLocation);

                string aadAdmin = "DSEngAll";

                SqlManagementTestUtilities.ValidateServer(server, server.Name, login, version12, tags, SqlManagementTestUtilities.DefaultLocation);

                ServerAzureADAdministrator newAdmin = new ServerAzureADAdministrator("DSEngAll", "5e90ef3b-9b42-4777-819b-25c36961ea4d", "72f988bf-86f1-41af-91ab-2d7cd011db47", "sqlcrudtest-3421", "2c647056-bab2-4175-b172-493ff049eb29");
                ServerAzureADAdministrator createResult = sqlClient.Servers.CreateOrUpdateAzureADAdministrator(resourceGroup.Name, server.Name, newAdmin);
                

                Assert.Equal(aadAdmin, createResult.Login);


                ServerAzureADAdministrator getResult = sqlClient.Servers.GetAzureADAdministrator(resourceGroup.Name, server.Name);
                Assert.Equal(aadAdmin, getResult.Login);

                sqlClient.Servers.DeleteAzureADAdministrator(resourceGroup.Name, server.Name);

                List<ServerAzureADAdministrator> admins = sqlClient.Servers.ListAzureADAdministrator(resourceGroup.Name,server.Name) as List<ServerAzureADAdministrator>;
                Assert.True(admins == null || admins.Count == 0);
                
            });
        }
    }
}

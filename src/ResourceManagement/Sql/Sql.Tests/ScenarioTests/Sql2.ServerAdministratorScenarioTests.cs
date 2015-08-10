//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for Azure SQL Server Active Directory Administrator CRUD
    /// </summary>
    public class Sql2ServerAdministratorScenarioTests : TestBase
    {
        /// <summary>
        /// Test for the Azure SQL Server Active Directory Administrator CRUD operations
        /// </summary>
        [Fact]
        public void ServerAdministratorCRUDTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                Sql2ScenarioHelper.RunServerTestInEnvironment(
                   handler,
                   "12.0",
                   "North Europe",
                   (sqlClient, resGroupName, server) =>
                   {
                       string AdministratorDefaultType = "activeDirectory";
                       string ActiveDirectoryDefaultName = "activeDirectory";
                       string activeDirectoryServerAdminLogin = "testAADaccount";
                       Guid activeDirectoryServerAdminSid = new Guid("4dc34af5-6a71-4838-a983-14cdf8852ff9");
                       Guid activeDirectoryTenantId = new Guid("A0C03064-E4CB-4AB8-AF32-12203273FF1D");

                       ///////////////////////////////////////////////////////////////////////
                       // Update Azure SQL Server Active Directory Administrator
                       var createResponse = sqlClient.ServerAdministrators.CreateOrUpdate(resGroupName, server.Name, ActiveDirectoryDefaultName, new ServerAdministratorCreateOrUpdateParameters()
                       {
                           Properties = new ServerAdministratorCreateOrUpdateProperties()
                           {
                               Login = activeDirectoryServerAdminLogin,
                               Sid = activeDirectoryServerAdminSid,
                               AdministratorType = AdministratorDefaultType,
                               TenantId = activeDirectoryTenantId,
                           },
                       });

                       TestUtilities.ValidateOperationResponse(createResponse, HttpStatusCode.OK);
                       VerifyServerAdministratorInformation(activeDirectoryServerAdminLogin, activeDirectoryServerAdminSid, activeDirectoryTenantId, createResponse.ServerAdministrator);

                       // Get single server active directory administrator
                       var getAdminResponse = sqlClient.ServerAdministrators.Get(resGroupName, server.Name, ActiveDirectoryDefaultName);

                       // Verify that the Get request contains the right information.
                       TestUtilities.ValidateOperationResponse(getAdminResponse, HttpStatusCode.OK);
                       VerifyServerAdministratorInformation(activeDirectoryServerAdminLogin, activeDirectoryServerAdminSid, activeDirectoryTenantId, getAdminResponse.Administrator);

                       // Get list Azure SQL Server Active Directory Administrator
                       var getAdminResponseList = sqlClient.ServerAdministrators.List(resGroupName, server.Name);

                       //There should only be one Azure SQL Server Active Directory Administrator
                       Assert.Equal(getAdminResponseList.Administrators.Count, 1);

                       // Verify that the Get request contains the right information.
                       TestUtilities.ValidateOperationResponse(getAdminResponseList, HttpStatusCode.OK);
                       VerifyServerAdministratorInformation(activeDirectoryServerAdminLogin, activeDirectoryServerAdminSid, activeDirectoryTenantId, getAdminResponseList.Administrators[0]);
                       ///////////////////////////////////////////////////////////////////////

                       ///////////////////////////////////////////////////////////////////////
                       // Delete Azure SQL Server Active Directory Administrator Test
                       var deleteResponse = sqlClient.ServerAdministrators.Delete(resGroupName, server.Name, ActiveDirectoryDefaultName);

                       // Verify that the delete operation works.
                       TestUtilities.ValidateOperationResponse(deleteResponse, HttpStatusCode.NoContent);
                       /////////////////////////////////////////////////////////////////////

                       // Verify that the Azure SQL Active Directory administrator is deleted.  
                       var getNoAdminResponse = sqlClient.ServerAdministrators.List(resGroupName, server.Name);
                       TestUtilities.ValidateOperationResponse(getNoAdminResponse, HttpStatusCode.OK);

                       // There should be no Azure SQL Server Active Directory Administrator after delete
                       Assert.Empty(getNoAdminResponse.Administrators);
                   });
            }
        }

        /// <summary>
        /// Verify that the Server Administrator object matches the provided values
        /// </summary>
        /// <param name="activeDirectoryAdminLogin">The expected admin login</param>
        /// <param name="acitveDirectoryAdminSid">The expected Active Directory User or Group Sid</param>
        /// <param name="activeDirectoryTenantId">The expected Active Directory tenant id</param>
        /// <param name="serverAdministrator">The actual server object</param>
        private static void VerifyServerAdministratorInformation(string activeDirectoryAdminLogin, Guid acitveDirectoryAdminSid, Guid activeDirectoryTenantId, ServerAdministrator serverAdministrator)
        {
            Assert.NotEmpty(serverAdministrator.Id);
            Assert.Equal(activeDirectoryAdminLogin, serverAdministrator.Properties.Login);
            Assert.Equal(acitveDirectoryAdminSid, serverAdministrator.Properties.Sid);
            Assert.Equal(activeDirectoryTenantId, serverAdministrator.Properties.TenantId);
        }
    }
}

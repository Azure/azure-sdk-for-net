// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class RoleAssignmentScenarioTests
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        static RoleAssignmentScenarioTests()
        {
            HubName = AppSettings.HubName;
            ResourceGroupName = AppSettings.ResourceGroupName;
        }

        /// <summary>
        ///     Hub Name
        /// </summary>
        private static readonly string HubName;

        /// <summary>
        ///     Reosurce Group Name
        /// </summary>
        private static readonly string ResourceGroupName;

        [Fact]
        public void CrudRoleAssignmentFullCycle()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var assignmentName = TestUtilities.GenerateName("assignmentName");

                var rbacResourceFormat = Helpers.GetTestRoleAssignment(RoleTypes.Admin, 2);
                var response = aciClient.RoleAssignments.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    assignmentName,
                    rbacResourceFormat);

                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/RoleAssignments",
                    response.Type,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Equal(response.Name, HubName + "/" + assignmentName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(RoleTypes.Admin, response.Role);
                Assert.Equal(response.AssignmentName, assignmentName, StringComparer.OrdinalIgnoreCase);
                Assert.True(response.Principals.Count == 2);

                var getRbacResource = aciClient.RoleAssignments.Get(ResourceGroupName, HubName, assignmentName);

                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/RoleAssignments",
                    getRbacResource.Type,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Equal(getRbacResource.Name, HubName + "/" + assignmentName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(RoleTypes.Admin, getRbacResource.Role);
                Assert.True(getRbacResource.Principals.Count == 2);
                Assert.Equal(getRbacResource.AssignmentName, assignmentName, StringComparer.OrdinalIgnoreCase);

                var rbacResourceUpdateFormat = Helpers.GetTestRoleAssignment(RoleTypes.Admin, 1);
                var updateRbacresponse = aciClient.RoleAssignments.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    assignmentName,
                    rbacResourceUpdateFormat);

                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/RoleAssignments",
                    updateRbacresponse.Type,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Equal(updateRbacresponse.Name, HubName + "/" + assignmentName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(RoleTypes.Admin, updateRbacresponse.Role);
                Assert.Equal(updateRbacresponse.AssignmentName, assignmentName, StringComparer.OrdinalIgnoreCase);
                Assert.True(updateRbacresponse.Principals.Count == 1);
                var getUpdateRbacResource1 = aciClient.RoleAssignments.Get(ResourceGroupName, HubName, assignmentName);

                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/RoleAssignments",
                    getUpdateRbacResource1.Type,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    getUpdateRbacResource1.Name,
                    HubName + "/" + assignmentName,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Equal(RoleTypes.Admin, getUpdateRbacResource1.Role);
                Assert.Equal(getUpdateRbacResource1.AssignmentName, assignmentName, StringComparer.OrdinalIgnoreCase);
                Assert.True(getUpdateRbacResource1.Principals.Count == 1);

                var rbacResourceUpdateFormat2 = Helpers.GetTestRoleAssignment(RoleTypes.Reader, 1);

                try
                {
                    aciClient.RoleAssignments.CreateOrUpdate(
                        ResourceGroupName,
                        HubName,
                        assignmentName,
                        rbacResourceUpdateFormat2);
                }
                catch (Exception exception)
                {
                    Assert.Equal(
                        "Bad Request",
                        ((CloudException)exception).Response.ReasonPhrase, StringComparer.OrdinalIgnoreCase);
                }

                var deleteRbacResource =
                    aciClient.RoleAssignments.DeleteWithHttpMessagesAsync(ResourceGroupName, HubName, assignmentName)
                        .Result;
                Assert.Equal(HttpStatusCode.Accepted, deleteRbacResource.Response.StatusCode);
            }
        }

        [Fact]
        public void ListRoleAssignmentInHub()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var assignmentName1 = TestUtilities.GenerateName("assignmentName1");
                var assignmentName2 = TestUtilities.GenerateName("assignmentName2");

                var rbacResourceFormat1 = Helpers.GetTestRoleAssignment(RoleTypes.Admin, 1);
                var rbacResourceFormat2 = Helpers.GetTestRoleAssignment(RoleTypes.Admin, 1);

                aciClient.RoleAssignments.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    assignmentName1,
                    rbacResourceFormat1);
                aciClient.RoleAssignments.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    assignmentName2,
                    rbacResourceFormat2);

                var result = aciClient.RoleAssignments.ListByHub(ResourceGroupName, HubName);
                Assert.True(result.ToList().Count >= 2);

                Assert.True(
                    result.ToList()
                        .Any(rbacAssignmentReturned => assignmentName1 == rbacAssignmentReturned.AssignmentName)
                    && result.ToList()
                        .Any(rbacAssignmentReturned => assignmentName2 == rbacAssignmentReturned.AssignmentName)
                    && result.ToList()
                        .Any(
                            rbacAssignmentReturned =>
                                "microsoft.customerinsights/hubs/roleassignments"
                                == rbacAssignmentReturned.Type.ToLower()));
            }
        }

        [Fact]
        public void ListRolesInHub()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var result = aciClient.Roles.ListByHub(ResourceGroupName, HubName);
                Assert.True(result.ToList().Count == 6);
                Assert.True(
                    (result.ToList()[0].RoleName.ToLower() == "admin")
                    && (result.ToList()[1].RoleName.ToLower() == "reader")
                    && (result.ToList()[2].RoleName.ToLower() == "metadataadmin")
                    && (result.ToList()[3].RoleName.ToLower() == "metadatareader")
                    && (result.ToList()[4].RoleName.ToLower() == "dataadmin")
                    && (result.ToList()[5].RoleName.ToLower() == "datareader"));
            }
        }
    }
}
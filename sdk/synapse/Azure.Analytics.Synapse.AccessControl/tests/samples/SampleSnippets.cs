// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Analytics.Synapse.AccessControl.Models;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.AccessControl.Samples
{
    public partial class Snippets : SampleFixture
    {
        [Test]
        public void RoleAssignmentSample()
        {
            #region Snippet:CreateAccessControlClient
            // Replace the string below with your actual workspace url.
            string workspaceUrl = "<my-workspace-url>";
            /*@@*/workspaceUrl = TestEnvironment.WorkspaceUrl;
            AccessControlClient client = new AccessControlClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            string principalId = TestEnvironment.PrincipalId;
            string sqlAdminRoleId = client.GetRoleDefinitions().AsEnumerable().Single(role => role.Name == "Sql Admin").Id;

            #region Snippet:CreateRoleAssignment
            RoleAssignmentOptions options = new RoleAssignmentOptions(sqlAdminRoleId, principalId);
            string assignmentId = client.CreateRoleAssignment(options).Value.Id;
            #endregion

            #region Snippet:RetrieveRoleAssignment
            RoleAssignmentDetails roleAssignment = client.GetRoleAssignmentById(assignmentId);
            #endregion

            #region Snippet:ListRoleAssignments
            IReadOnlyList<RoleAssignmentDetails> roleAssignments = client.GetRoleAssignments().Value;
            foreach (RoleAssignmentDetails assignment in roleAssignments)
            {
                Console.WriteLine(assignment.Id);
            }
            #endregion

            #region Snippet:DeleteRoleAssignment
            client.DeleteRoleAssignmentById(roleAssignment.Id);
            #endregion

        }
    }
}

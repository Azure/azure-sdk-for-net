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
#pragma warning disable IDE1006 // Naming Styles
        private AccessControlClient client;
#pragma warning restore IDE1006 // Naming Styles

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            #region Snippet:CreateAccessControlClient
            // Create a new access control client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            AccessControlClient client = new AccessControlClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            this.client = client;
        }

        [Test]
        public void CreateRoleAssignment()
        {
            string principalId = TestEnvironment.PrincipalId;
            string sqlAdminRoleId = client.GetRoleDefinitions().AsEnumerable().Single(role => role.Name == "Sql Admin").Id;

            #region Snippet:CreateRoleAssignment
            RoleAssignmentOptions options = new RoleAssignmentOptions(sqlAdminRoleId, principalId);
            RoleAssignmentDetails roleAssignment = client.CreateRoleAssignment(options);
            #endregion
        }

        [Test]
        public void RetrieveRoleAssignment()
        {
            string principalId = TestEnvironment.PrincipalId;

            #region Snippet:RetrieveRoleAssignment
            RoleAssignmentDetails roleAssignment = client.GetRoleAssignmentById(principalId);
            #endregion
        }

        [Test]
        public void ListRoleAssignments()
        {
            #region Snippet:ListRoleAssignments
            IReadOnlyList<RoleAssignmentDetails> roleAssignments = client.GetRoleAssignments().Value;
            foreach (RoleAssignmentDetails assignment in roleAssignments)
            {
                Console.WriteLine(assignment.Id);
            }
            #endregion
        }

        [Test]
        public void DeleteRoleAssignment()
        {
            string principalId = TestEnvironment.PrincipalId;
            RoleAssignmentDetails roleAssignment = client.GetRoleAssignmentById(principalId);

            #region Snippet:DeleteRoleAssignment
            client.DeleteRoleAssignmentById(roleAssignment.Id);
            #endregion
        }
    }
}

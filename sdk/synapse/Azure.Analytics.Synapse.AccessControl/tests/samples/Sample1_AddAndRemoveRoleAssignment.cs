// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using Azure.Analytics.Synapse.AccessControl;
using Azure.Analytics.Synapse.AccessControl.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Samples
{
    /// <summary>
    /// This sample demonstrates how to submit Spark job in Azure Synapse Analytics using synchronous methods of <see cref="AccessControlClient"/>.
    /// </summary>
    public partial class AddAndRemoveRoleAssignment
    {
        [Test]
        public void SubmitSparkJobSync()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            #region Snippet:AccessControlSample1AccessControlClient
            var client = new AccessControlClient(new Uri(workspaceUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:AccessControlSample1GetWorkspaceAdminRole
            SynapseRole role = client.GetRoleDefinitions().Single(role => role.Name == "Workspace Admin");
            #endregion

            #region Snippet:AccessControlSample1AddRoleAssignment
            string principalId = Guid.NewGuid().ToString();
            var request = new RoleAssignmentOptions(roleId:role.Id, principalId:principalId);
            RoleAssignmentDetails roleAssignmentAdded = client.CreateRoleAssignment(request);
            #endregion

            #region Snippet:AccessControlSample1GetRoleAssignment
            RoleAssignmentDetails roleAssignment = client.GetRoleAssignmentById(principalId);
            Debug.WriteLine($"Role {roleAssignment.RoleId} is assigned to {roleAssignment.PrincipalId}. Role assignment id: {roleAssignment.Id}");
            #endregion

            #region Snippet:AccessControlSample1ListRoleAssignments
            var roleAssignments = client.GetRoleAssignments().Value;
            foreach (var assignment in roleAssignments)
            {
                Console.WriteLine(assignment.Id);
            }
            #endregion

            #region Snippet:AccessControlSample1RemoveRoleAssignment
            client.DeleteRoleAssignmentById(roleAssignment.Id);
            #endregion
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public void AddAndRemoveRoleAssignmentSync()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            AccessControlClient client = new AccessControlClient(new Uri(workspaceUrl), new DefaultAzureCredential());

            SynapseRole role = client.GetRoleDefinitions().Single(role => role.Name == "Workspace Admin");

            string principalId = Guid.NewGuid().ToString();
            RoleAssignmentOptions request = new RoleAssignmentOptions(roleId:role.Id, principalId:principalId);
            RoleAssignmentDetails roleAssignmentAdded = client.CreateRoleAssignment(request);

            RoleAssignmentDetails roleAssignment = client.GetRoleAssignmentById(roleAssignmentAdded.Id);
            Debug.WriteLine($"Role {roleAssignment.RoleId} is assigned to {roleAssignment.PrincipalId}. Role assignment id: {roleAssignment.Id}");

            IReadOnlyList<RoleAssignmentDetails> roleAssignments = client.GetRoleAssignments().Value;
            foreach (RoleAssignmentDetails assignment in roleAssignments)
            {
                Console.WriteLine(assignment.Id);
            }

            client.DeleteRoleAssignmentById(roleAssignment.Id);
        }
    }
}

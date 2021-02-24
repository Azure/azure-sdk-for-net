// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Tests;
using Azure.Analytics.Synapse.AccessControl;
using Azure.Analytics.Synapse.AccessControl.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.AccessControl.Samples
{
    /// <summary>
    /// This sample demonstrates how to submit Spark job in Azure Synapse Analytics using synchronous methods of <see cref="AccessControlClient"/>.
    /// </summary>
    public partial class Sample1_HelloWorld : SamplesBase<SynapseTestEnvironment>
    {
        [Test]
        public void AddAndRemoveRoleAssignmentSync()
        {
            #region Snippet:CreateAccessControlClient
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;

            RoleAssignmentsClient roleAssignmentsClient = new RoleAssignmentsClient(new Uri(endpoint), new DefaultAzureCredential());
            RoleDefinitionsClient definitionsClient = new RoleDefinitionsClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion

            #region Snippet:PrepCreateRoleAssignment
            Response<IReadOnlyList<SynapseRoleDefinition>> roles = definitionsClient.ListRoleDefinitions();
            SynapseRoleDefinition role = roles.Value.Single(role => role.Name == "Synapse Administrator");
            Guid roleId = role.Id.Value;

            string assignedScope = "workspaces/<my-workspace-name>";
            /*@@*/assignedScope = "workspaces/" + TestEnvironment.WorkspaceName;

            // Replace the string below with the ID you'd like to assign the role.
            Guid principalId = /*<my-principal-id>"*/ Guid.NewGuid();

            // Replace the string below with the ID of the assignment you'd like to use.
            string assignmentId = "<my-assignment-id>";
            /*@@*/assignmentId = Guid.NewGuid().ToString();
            #endregion

            #region Snippet:CreateRoleAssignment
            Response<RoleAssignmentDetails> response = roleAssignmentsClient.CreateRoleAssignment (assignmentId, roleId, principalId, assignedScope);
            RoleAssignmentDetails roleAssignmentAdded = response.Value;
            #endregion

            #region Snippet:RetrieveRoleAssignment
            RoleAssignmentDetails roleAssignment = roleAssignmentsClient.GetRoleAssignmentById(roleAssignmentAdded.Id);
            Console.WriteLine($"Role {roleAssignment.RoleDefinitionId} is assigned to {roleAssignment.PrincipalId}.");
            #endregion

            #region Snippet:ListRoleAssignments
            Response<IReadOnlyList<SynapseRoleDefinition>> roleAssignments = definitionsClient.ListRoleDefinitions();
            foreach (SynapseRoleDefinition assignment in roleAssignments.Value)
            {
                Console.WriteLine(assignment.Id);
            }
            #endregion

            #region Snippet:DeleteRoleAssignment
            roleAssignmentsClient.DeleteRoleAssignmentById(roleAssignment.Id);
            #endregion
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Analytics.Synapse.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
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
            Response roleDefinitionsReponse = definitionsClient.ListRoleDefinitions(new());
            BinaryData roleDefinitionsContent = roleDefinitionsReponse.Content;
            JsonDocument roleDefinitionsJson = JsonDocument.Parse(roleDefinitionsContent.ToMemory());

            JsonElement adminRoleJson = roleDefinitionsJson.RootElement.EnumerateArray().
                Single(role => role.GetProperty("name").ToString() == "Synapse Administrator");
            Guid adminRoleId = new Guid(adminRoleJson.GetProperty("id").ToString());

            string assignedScope = "workspaces/<my-workspace-name>";
            /*@@*/assignedScope = "workspaces/" + TestEnvironment.WorkspaceName;

            // Replace the string below with the ID you'd like to assign the role.
            Guid principalId = /*<my-principal-id>"*/ Guid.NewGuid();

            // Replace the string below with the ID of the assignment you'd like to use.
            string assignmentId = "<my-assignment-id>";
            /*@@*/assignmentId = Guid.NewGuid().ToString();
            #endregion

            #region Snippet:CreateRoleAssignment
            var roleAssignmentDetails = new
            {
                roleId = adminRoleId,
                principalId = Guid.NewGuid(),
                scope = assignedScope
            };

            Response addedRoleAssignmentResponse = roleAssignmentsClient.CreateRoleAssignment(assignmentId, RequestContent.Create(roleAssignmentDetails));
            BinaryData addedRoleAssignmentContent = addedRoleAssignmentResponse.Content;
            JsonDocument addedRoleAssignmentJson = JsonDocument.Parse(addedRoleAssignmentContent.ToMemory());
            string addedRoleAssignmentId = addedRoleAssignmentJson.RootElement.GetProperty("id").ToString();

            #endregion

            #region Snippet:RetrieveRoleAssignment
            Response roleAssignmentResponse = roleAssignmentsClient.GetRoleAssignmentById(addedRoleAssignmentId, new());
            BinaryData roleAssignmentContent = roleAssignmentResponse.Content;
            JsonDocument roleAssignmentJson = JsonDocument.Parse(roleAssignmentContent.ToMemory());
            string roleAssignmentRoleDefinitionId = roleAssignmentJson.RootElement.GetProperty("roleDefinitionId").ToString();
            string roleAssignmentPrincipalId = roleAssignmentJson.RootElement.GetProperty("principalId").ToString();
            Console.WriteLine($"Role {roleAssignmentRoleDefinitionId} is assigned to {roleAssignmentPrincipalId}.");
            #endregion

            #region Snippet:ListRoleAssignments
            Response roleAssignmentsResponse = roleAssignmentsClient.ListRoleAssignments(new());
            BinaryData roleAssignmentsContent = roleAssignmentsResponse.Content;
            JsonDocument roleAssignmentsJson = JsonDocument.Parse(roleAssignmentsContent.ToMemory());

            foreach (JsonElement assignmentJson in roleAssignmentsJson.RootElement.GetProperty("value").EnumerateArray())
            {
                Console.WriteLine(assignmentJson.GetProperty("id").ToString());
            }
            #endregion

            #region Snippet:DeleteRoleAssignment
            roleAssignmentsClient.DeleteRoleAssignmentById(addedRoleAssignmentId);
            #endregion
        }
    }
}

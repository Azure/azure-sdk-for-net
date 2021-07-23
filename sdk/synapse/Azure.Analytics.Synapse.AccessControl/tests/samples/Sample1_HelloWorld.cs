// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            endpoint = TestEnvironment.EndpointUrl;

            SynapseAccessControlClient client = new SynapseAccessControlClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion

            #region Snippet:PrepCreateRoleAssignment
            Response listRoleDefinitionsResponse = client.ListRoleDefinitions();
            JsonDocument roleDefinitions = JsonDocument.Parse(listRoleDefinitionsResponse.Content.ToMemory());

            ////SynapseRoleDefinition role = roles.Value.Single(role => role.Name == "Synapse Administrator");
            ////Guid roleId = role.Id.Value;
            JsonElement roleDefinition = roleDefinitions.RootElement.EnumerateArray().Single(role => role.GetProperty("name").ToString() == "Synapse Administrator");
            string roleId = roleDefinition.GetProperty("id").ToString();

            string assignedScope = "workspaces/<my-workspace-name>";
            assignedScope = "workspaces/" + TestEnvironment.WorkspaceName;

            // Replace the string below with the ID you'd like to assign the role.
            Guid principalId = /*<my-principal-id>"*/ Guid.NewGuid();

            // Replace the string below with the ID of the assignment you'd like to use.
            string assignmentId = /*"<my-assignment-id>"*/ Guid.NewGuid().ToString();
            #endregion

            #region Snippet:CreateRoleAssignment
            Response createRoleAssignmentResponse = client.CreateRoleAssignment(
                assignmentId,
                RequestContent.Create(
                    new
                    {
                        RoleId = roleId,
                        PrincipalId = principalId,
                        Scope = assignedScope
                    }));
            JsonDocument roleAssignment = JsonDocument.Parse(createRoleAssignmentResponse.Content.ToMemory());
            string roleAssignmentId = roleAssignment.RootElement.GetProperty("id").ToString();
            string roleDefinitionId = roleAssignment.RootElement.GetProperty("roleDefinitionId").ToString();
            string roleAssignmentPrincipalId = roleAssignment.RootElement.GetProperty("principalId").ToString();
            string roleAssignmentScope = roleAssignment.RootElement.GetProperty("scope").ToString();

            //RoleAssignmentDetails roleAssignmentAdded = response.Value;
            #endregion

			// TODO: Add these
            //#region Snippet:RetrieveRoleAssignment
            //RoleAssignmentDetails roleAssignment = roleAssignmentsClient.GetRoleAssignmentById(roleAssignmentAdded.Id);
            //Console.WriteLine($"Role {roleAssignment.RoleDefinitionId} is assigned to {roleAssignment.PrincipalId}.");
            //#endregion

            //#region Snippet:ListRoleAssignments
            //Response<IReadOnlyList<SynapseRoleDefinition>> roleAssignments = definitionsClient.ListRoleDefinitions();
            //foreach (SynapseRoleDefinition assignment in roleAssignments.Value)
            //{
            //    Console.WriteLine(assignment.Id);
            //}
            //#endregion

            //#region Snippet:DeleteRoleAssignment
            //roleAssignmentsClient.DeleteRoleAssignmentById(roleAssignment.Id);
            //#endregion
        }
    }
}

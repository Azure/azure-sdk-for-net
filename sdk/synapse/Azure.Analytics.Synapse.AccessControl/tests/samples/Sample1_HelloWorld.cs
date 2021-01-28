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
    public partial class Sample1_HelloWorld : SampleFixture
    {
        [Test]
        public void AddAndRemoveRoleAssignmentSync()
        {
            #region Snippet:CreateAccessControlClient
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;

            AccessControlClient client = new AccessControlClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion

            #region Snippet:PrepCreateRoleAssignment
            Pageable<SynapseRole> roles = client.GetRoleDefinitions();
            SynapseRole role = roles.Single(role => role.Name == "Workspace Admin");
            string roleID = role.Id;

            // Replace the string below with the ID you'd like to assign the role.
            string principalId = "<my-principal-id>";
            /*@@*/principalId = Guid.NewGuid().ToString();
            #endregion

            #region Snippet:CreateRoleAssignment
            RoleAssignmentOptions request = new RoleAssignmentOptions(roleID, principalId);
            Response<RoleAssignmentDetails> response = client.CreateRoleAssignment(request);
            RoleAssignmentDetails roleAssignmentAdded = response.Value;
            #endregion

            #region Snippet:RetrieveRoleAssignment
            RoleAssignmentDetails roleAssignment = client.GetRoleAssignmentById(roleAssignmentAdded.Id);
            Console.WriteLine($"Role {roleAssignment.RoleId} is assigned to {roleAssignment.PrincipalId}.");
            #endregion

            #region Snippet:ListRoleAssignments
            Response<IReadOnlyList<RoleAssignmentDetails>> roleAssignments = client.GetRoleAssignments();
            foreach (RoleAssignmentDetails assignment in roleAssignments.Value)
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

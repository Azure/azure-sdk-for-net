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
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;
            AccessControlClient client = new AccessControlClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            string principalId = TestEnvironment.PrincipalId;
            string sqlAdminRoleId = client.GetRoleDefinitions().AsEnumerable().Single(role => role.Name == "Sql Admin").Id;

            #region Snippet:CreateRoleAssignment
            RoleAssignmentOptions options = new RoleAssignmentOptions(sqlAdminRoleId, principalId);
            RoleAssignmentDetails createdRoleAssignment = client.CreateRoleAssignment(options);
            #endregion

            #region Snippet:RetrieveRoleAssignment
            RoleAssignmentDetails retrievedRoleAssignment = client.GetRoleAssignmentById(createdRoleAssignment.Id);
            #endregion

            #region Snippet:ListRoleAssignments
            IReadOnlyList<RoleAssignmentDetails> roleAssignments = client.GetRoleAssignments().Value;
            foreach (RoleAssignmentDetails roleAssignment in roleAssignments)
            {
                Console.WriteLine(roleAssignment.Id);
            }
            #endregion

            #region Snippet:DeleteRoleAssignment
            client.DeleteRoleAssignmentById(retrievedRoleAssignment.Id);
            #endregion
        }
    }
}

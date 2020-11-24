// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Administration.Models;
using Azure.Security.KeyVault.Administration.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class RbacHelloWorld : AccessControlTestBase
    {
        public RbacHelloWorld(bool isAsync)
            : base(isAsync, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [SetUp]
        public void TestSetup()
        {
            _objectId = TestEnvironment.ClientObjectId;
        }

        [RecordedTest]
        [SyncOnly]
        public void CreateClient()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.ManagedHsmUrl;

            #region Snippet:HelloCreateKeyVaultAccessControlClient
            KeyVaultAccessControlClient client = new KeyVaultAccessControlClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion
            client = Client;
        }

        [RecordedTest]
        [SyncOnly]
        public void GetDefinitionsAndAssignmentsSync()
        {
            // Replace client with the Instrumented Client.
            client = Client;

            // Retrieve all the role definitions.
            #region Snippet:GetRoleDefinitionsSync
            List<KeyVaultRoleDefinition> roleDefinitions = client.GetRoleDefinitions(KeyVaultRoleScope.Global).ToList();
            #endregion

            // Retrieve all the role assignments.
            #region Snippet:GetRoleAssignmentsSync
            List<KeyVaultRoleAssignment> roleAssignments = client.GetRoleAssignments(KeyVaultRoleScope.Global).ToList();
            #endregion

        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetDefinitionsAndAssignmentsAsync()
        {
            // Replace client with the Instrumented Client.
            client = Client;

            // Retrieve all the role definitions.
            #region Snippet:GetRoleDefinitionsAsync
            List<KeyVaultRoleDefinition> roleDefinitions = new List<KeyVaultRoleDefinition>();
            await foreach (KeyVaultRoleDefinition definition in client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global))
            {
                roleDefinitions.Add(definition);
            }
            #endregion

            // Retrieve all the role assignments.
            #region Snippet:GetRoleAssignmentsAsync
            List<KeyVaultRoleAssignment> roleAssignments = new List<KeyVaultRoleAssignment>();
            await foreach (KeyVaultRoleAssignment assignment in client.GetRoleAssignmentsAsync(KeyVaultRoleScope.Global))
            {
                roleAssignments.Add(assignment);
            }
            #endregion
        }

        [RecordedTest]
        [SyncOnly]
        public void CreateRoleAssignment()
        {
            // Replace client with the Instrumented Client.
            client = Client;

            List<KeyVaultRoleDefinition> definitions = client.GetRoleDefinitions(KeyVaultRoleScope.Global).ToList();
            _roleDefinitionId = definitions.FirstOrDefault(d => d.RoleName == RoleName).Id;

            // Replace roleDefinitionId with a role definition Id from the definitions returned from GetRoleAssignments.
            string definitionIdToAssign = _roleDefinitionId;

            // Replace objectId with the service principal object id.
            string servicePrincipalObjectId = _objectId;

            #region Snippet:CreateRoleAssignment
            //@@string definitionIdToAssign = "<roleDefinitionId>";
            //@@string servicePrincipalObjectId = "<objectId>";

            //@@KeyVaultRoleAssignment createdAssignment = client.CreateRoleAssignment(RoleAssignmentScope.Global, definitionIdToAssign, servicePrincipalObjectI);
            /*@@*/KeyVaultRoleAssignment createdAssignment = client.CreateRoleAssignment(KeyVaultRoleScope.Global, definitionIdToAssign, servicePrincipalObjectId, _roleAssignmentId);
            #endregion

            #region Snippet:GetRoleAssignment
            KeyVaultRoleAssignment fetchedAssignment = client.GetRoleAssignment(KeyVaultRoleScope.Global, createdAssignment.Name);
            #endregion

            #region Snippet:DeleteRoleAssignment
            KeyVaultRoleAssignment deletedAssignment = client.DeleteRoleAssignment(KeyVaultRoleScope.Global, createdAssignment.Name);
            #endregion
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task CreateRoleAssignmentAsync()
        {
            // Replace client with the Instrumented Client.
            client = Client;

            List<KeyVaultRoleDefinition> definitions = await client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            _roleDefinitionId = definitions.FirstOrDefault(d => d.RoleName == RoleName).Id;

            // Replace roleDefinitionId with a role definition Id from the definitions returned from GetRoleDefinitionsAsync.
            string definitionIdToAssign = _roleDefinitionId;

            // Replace objectId with the service principal object id.
            string servicePrincipalObjectId = _objectId;

            #region Snippet:CreateRoleAssignmentAsync
            //@@string definitionIdToAssign = "<roleDefinitionId>";
            //@@string servicePrincipalObjectId = "<objectId>";

            //@@KeyVaultRoleAssignment createdAssignment = await client.CreateRoleAssignmentAsync(RoleAssignmentScope.Global, definitionIdToAssign, servicePrincipalObjectId);
            /*@@*/KeyVaultRoleAssignment createdAssignment = await client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Global, definitionIdToAssign, servicePrincipalObjectId, _roleAssignmentId).ConfigureAwait(false);
            #endregion

            #region Snippet:GetRoleAssignmentAsync
            KeyVaultRoleAssignment fetchedAssignment = await client.GetRoleAssignmentAsync(KeyVaultRoleScope.Global, createdAssignment.Name);
            #endregion

            #region Snippet:DeleteRoleAssignmentAsync
            KeyVaultRoleAssignment deletedAssignment = await client.DeleteRoleAssignmentAsync(KeyVaultRoleScope.Global, createdAssignment.Name);
            #endregion
        }
    }
}

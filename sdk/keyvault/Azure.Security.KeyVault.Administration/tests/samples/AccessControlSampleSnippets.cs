// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AccessControlSampleSnippets : AccessControlTestBase
    {
        public AccessControlSampleSnippets(bool isAsync)
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

            #region Snippet:CreateKeyVaultAccessControlClient
            // Create a new access control client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            KeyVaultAccessControlClient client = new KeyVaultAccessControlClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());
            /*@@*/ client = Client;

            // Retrieve all the role definitions.
            List<KeyVaultRoleDefinition> roleDefinitions = client.GetRoleDefinitions(KeyVaultRoleScope.Global).ToList();

            // Retrieve all the role assignments.
            List<KeyVaultRoleAssignment> roleAssignments = client.GetRoleAssignments(KeyVaultRoleScope.Global).ToList();
            #endregion
        }

        [RecordedTest]
        [SyncOnly]
        public void GetRoleDefinitions()
        {
            client = Client;
            #region Snippet:GetRoleDefinitions
            Pageable<KeyVaultRoleDefinition> allDefinitions = client.GetRoleDefinitions(KeyVaultRoleScope.Global);

            foreach (KeyVaultRoleDefinition roleDefinition in allDefinitions)
            {
                Console.WriteLine(roleDefinition.Id);
                Console.WriteLine(roleDefinition.RoleName);
                Console.WriteLine(roleDefinition.Description);
                Console.WriteLine();
            }
            #endregion
        }

        [RecordedTest]
        [SyncOnly]
        public void CreateRoleAssignment()
        {
            client = Client;
            Pageable<KeyVaultRoleDefinition> allDefinitions = client.GetRoleDefinitions(KeyVaultRoleScope.Global);
            _roleDefinitionId = allDefinitions.FirstOrDefault(d => d.RoleName == RoleName).Id;

            // Replace roleDefinitionId with a role definition Id from the definitions returned from the List the role definitions section above
            string definitionIdToAssign = _roleDefinitionId;

            // Replace objectId with the service principal object id from the Create/Get credentials section above
            string servicePrincipalObjectId = _objectId;

            #region Snippet:ReadmeCreateRoleAssignment
            // Replace <roleDefinitionId> with a role definition Id from the definitions returned from the List the role definitions section above
            //@@string definitionIdToAssign = "<roleDefinitionId>";

            // Replace <objectId> with the service principal object id from the Create/Get credentials section above
            //@@string servicePrincipalObjectId = "<objectId>";

            //@@RoleAssignment createdAssignment = client.CreateRoleAssignment(RoleAssignmentScope.Global, properties);
            /*@@*/ KeyVaultRoleAssignment createdAssignment = client.CreateRoleAssignment(KeyVaultRoleScope.Global, definitionIdToAssign, servicePrincipalObjectId, _roleAssignmentId);

            Console.WriteLine(createdAssignment.Name);
            Console.WriteLine(createdAssignment.Properties.PrincipalId);
            Console.WriteLine(createdAssignment.Properties.RoleDefinitionId);

            KeyVaultRoleAssignment fetchedAssignment = client.GetRoleAssignment(KeyVaultRoleScope.Global, createdAssignment.Name);

            Console.WriteLine(fetchedAssignment.Name);
            Console.WriteLine(fetchedAssignment.Properties.PrincipalId);
            Console.WriteLine(fetchedAssignment.Properties.RoleDefinitionId);

            KeyVaultRoleAssignment deletedAssignment = client.DeleteRoleAssignment(KeyVaultRoleScope.Global, createdAssignment.Name);

            Console.WriteLine(deletedAssignment.Name);
            Console.WriteLine(deletedAssignment.Properties.PrincipalId);
            Console.WriteLine(deletedAssignment.Properties.RoleDefinitionId);

            #endregion
        }

        [RecordedTest]
        [SyncOnly]
        public void RoleAssignmentNotFound()
        {
            client = Client;
            #region Snippet:RoleAssignmentNotFound
            try
            {
                KeyVaultRoleAssignment roleAssignment = client.GetRoleAssignment(KeyVaultRoleScope.Global, "example-name");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}

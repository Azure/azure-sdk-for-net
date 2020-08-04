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
    public class SampleSnippets : AccessControlTestBase
    {
        public SampleSnippets(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, change this argument to RecordedTestMode.Record */)
        { }

        [SetUp]
        public void TestSetup()
        {
            _objectId = TestEnvironment.ClientObjectId;
        }

        [Test]
        [SyncOnly]
        public void CreateClient()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:CreateKeyVaultAccessControlClient
            // Create a new access control client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            KeyVaultAccessControlClient client = new KeyVaultAccessControlClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());
            /*@@*/client = Client;

            // Retrieve all the role definitions.
            List<RoleDefinition> roleDefinitions = client.GetRoleDefinitions(RoleAssignmentScope.Global).ToList();

            // Retrieve all the role assignments.
            List<RoleAssignment> roleAssignments = client.GetRoleAssignments(RoleAssignmentScope.Global).ToList();
            #endregion
        }

        [Test]
        [SyncOnly]
        public void GetRoleDefinitions()
        {
            client = Client;
            #region Snippet:GetRoleDefinitions
            Pageable<RoleDefinition> allDefinitions = client.GetRoleDefinitions(RoleAssignmentScope.Global);

            foreach (RoleDefinition roleDefinition in allDefinitions)
            {
                Console.WriteLine(roleDefinition.Id);
                Console.WriteLine(roleDefinition.RoleName);
                Console.WriteLine(roleDefinition.Description);
                Console.WriteLine();
            }
            #endregion
        }

        [Test]
        [SyncOnly]
        public async Task CreateRoleAssignment()
        {
            client = Client;
            List<RoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(RoleAssignmentScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            _roleDefinitionId = definitions.FirstOrDefault(d => d.RoleName == RoleName).Id;

            // Replace roleDefinitionId with a role definition Id from the definitions returned from the List the role definitions section above
            string definitionIdToAssign = _roleDefinitionId;

            // Replace objectId with the service principal object id from the Create/Get credentials section above
            string servicePrincipalObjectId = _objectId;

            #region Snippet:ReadmeCreateRoleAssignment
            // Replace <roleDefinitionId> with a role definition Id from the definitions returned from the List the role definitions section above
            //@@string definitionIdToAssign = "<roleDefinitionId>";

            // Replace <objectId> with the service principal object id from the Create/Get credentials section above
            //@@string servicePrincipalObjectId = "<objectId>";

            RoleAssignmentProperties properties = new RoleAssignmentProperties(definitionIdToAssign, servicePrincipalObjectId);
            //@@RoleAssignment createdAssignment = client.CreateRoleAssignment(RoleAssignmentScope.Global, properties);
            /*@@*/RoleAssignment createdAssignment = client.CreateRoleAssignment(RoleAssignmentScope.Global, properties, _roleAssignmentId);

            Console.WriteLine(createdAssignment.Name);
            Console.WriteLine(createdAssignment.Properties.PrincipalId);
            Console.WriteLine(createdAssignment.Properties.RoleDefinitionId);

            RoleAssignment fetchedAssignment = client.GetRoleAssignment(RoleAssignmentScope.Global, createdAssignment.Name);

            Console.WriteLine(fetchedAssignment.Name);
            Console.WriteLine(fetchedAssignment.Properties.PrincipalId);
            Console.WriteLine(fetchedAssignment.Properties.RoleDefinitionId);

            RoleAssignment deletedAssignment = client.DeleteRoleAssignment(RoleAssignmentScope.Global, createdAssignment.Name);

            Console.WriteLine(deletedAssignment.Name);
            Console.WriteLine(deletedAssignment.Properties.PrincipalId);
            Console.WriteLine(deletedAssignment.Properties.RoleDefinitionId);

            #endregion
        }

        [Test]
        [SyncOnly]
        public void RoleAssignmentNotFound()
        {
            client = Client;
            #region Snippet:RoleAssignmentNotFound
            try
            {
                RoleAssignment roleAssignment = client.GetRoleAssignment(RoleAssignmentScope.Global, "invalid-name");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}

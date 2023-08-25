// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Administration.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class RbacHelloWorld : AccessControlTestBase
    {
        public RbacHelloWorld(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
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
            string managedHsmUrl = TestEnvironment.ManagedHsmUrl;

            #region Snippet:HelloCreateKeyVaultAccessControlClient
            KeyVaultAccessControlClient client = new KeyVaultAccessControlClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
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
            _roleDefinitionId = definitions.First(d => d.RoleName == RoleName).Id;

            #region Snippet:CreateRoleAssignment
#if SNIPPET
            string definitionIdToAssign = "<roleDefinitionId>";
            string servicePrincipalObjectId = "<objectId>";

            KeyVaultRoleAssignment createdAssignment = client.CreateRoleAssignment(KeyVaultRoleScope.Global, definitionIdToAssign, servicePrincipalObjectId);
#else
            // Replace roleDefinitionId with a role definition Id from the definitions returned from GetRoleAssignments.
            string definitionIdToAssign = _roleDefinitionId;

            // Replace objectId with the service principal object id.
            string servicePrincipalObjectId = _objectId;

            Guid roleAssignmentName = Recording.Random.NewGuid();
            KeyVaultRoleAssignment createdAssignment = client.CreateRoleAssignment(KeyVaultRoleScope.Global, definitionIdToAssign, servicePrincipalObjectId, roleAssignmentName);
#endif
            #endregion

            #region Snippet:GetRoleAssignment
            KeyVaultRoleAssignment fetchedAssignment = client.GetRoleAssignment(KeyVaultRoleScope.Global, createdAssignment.Name);
            #endregion

            #region Snippet:DeleteRoleAssignment
            client.DeleteRoleAssignment(KeyVaultRoleScope.Global, createdAssignment.Name);
            #endregion
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task CreateRoleAssignmentAsync()
        {
            // Replace client with the Instrumented Client.
            client = Client;

            List<KeyVaultRoleDefinition> definitions = await client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            _roleDefinitionId = definitions.First(d => d.RoleName == RoleName).Id;

            #region Snippet:CreateRoleAssignmentAsync
#if SNIPPET
            string definitionIdToAssign = "<roleDefinitionId>";
            string servicePrincipalObjectId = "<objectId>";

            KeyVaultRoleAssignment createdAssignment = await client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Global, definitionIdToAssign, servicePrincipalObjectId);
#else
            // Replace roleDefinitionId with a role definition Id from the definitions returned from GetRoleDefinitionsAsync.
            string definitionIdToAssign = _roleDefinitionId;

            // Replace objectId with the service principal object id.
            string servicePrincipalObjectId = _objectId;

            Guid roleAssignmentName = Recording.Random.NewGuid();
            KeyVaultRoleAssignment createdAssignment = await client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Global, definitionIdToAssign, servicePrincipalObjectId, roleAssignmentName).ConfigureAwait(false);
#endif
            #endregion

            #region Snippet:GetRoleAssignmentAsync
            KeyVaultRoleAssignment fetchedAssignment = await client.GetRoleAssignmentAsync(KeyVaultRoleScope.Global, createdAssignment.Name);
            #endregion

            #region Snippet:DeleteRoleAssignmentAsync
            await client.DeleteRoleAssignmentAsync(KeyVaultRoleScope.Global, createdAssignment.Name);
            #endregion
        }

        [RecordedTest]
        [SyncOnly]
        public void CrudRoleDefinition()
        {
            // Replace client with the Instrumented Client.
            client = Client;

            #region Snippet:CreateRoleDefinition
#if SNIPPET
            CreateOrUpdateRoleDefinitionOptions options = new CreateOrUpdateRoleDefinitionOptions(KeyVaultRoleScope.Global)
#else
            CreateOrUpdateRoleDefinitionOptions options = new CreateOrUpdateRoleDefinitionOptions(KeyVaultRoleScope.Global, Recording.Random.NewGuid())
#endif
            {
                RoleName = "Managed HSM Data Decryptor",
                Description = "Can only decrypt data using the private key stored in Managed HSM",
                Permissions =
                {
                    new KeyVaultPermission()
                    {
                        DataActions =
                        {
                            KeyVaultDataAction.DecryptHsmKey
                        }
                    }
                }
            };
            KeyVaultRoleDefinition createdDefinition = client.CreateOrUpdateRoleDefinition(options);
#endregion

            #region Snippet:GetRoleDefinition
            Guid roleDefinitionId = new Guid(createdDefinition.Name);
            KeyVaultRoleDefinition fetchedDefinition = client.GetRoleDefinition(KeyVaultRoleScope.Global, roleDefinitionId);
            #endregion

            #region Snippet:DeleteRoleDefinition
            client.DeleteRoleDefinition(KeyVaultRoleScope.Global, roleDefinitionId);
            #endregion
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task CrudRoleDefinitionAsync()
        {
            // Replace client with the Instrumented Client.
            client = Client;

            #region Snippet:CreateRoleDefinitionAsync
#if SNIPPET
            CreateOrUpdateRoleDefinitionOptions options = new CreateOrUpdateRoleDefinitionOptions(KeyVaultRoleScope.Global)
#else
            CreateOrUpdateRoleDefinitionOptions options = new CreateOrUpdateRoleDefinitionOptions(KeyVaultRoleScope.Global, Recording.Random.NewGuid())
#endif
            {
                RoleName = "Managed HSM Data Decryptor",
                Description = "Can only decrypt data using the private key stored in Managed HSM",
                Permissions =
                {
                    new KeyVaultPermission()
                    {
                        DataActions =
                        {
                            KeyVaultDataAction.DecryptHsmKey
                        }
                    }
                }
            };
            KeyVaultRoleDefinition createdDefinition = await client.CreateOrUpdateRoleDefinitionAsync(options);
            #endregion

            #region Snippet:GetRoleDefinitionAsync
            Guid roleDefinitionId = new Guid(createdDefinition.Name);
            KeyVaultRoleDefinition fetchedDefinition = await client.GetRoleDefinitionAsync(KeyVaultRoleScope.Global, roleDefinitionId);
            #endregion

            #region Snippet:DeleteRoleDefinitionAsync
            await client.DeleteRoleDefinitionAsync(KeyVaultRoleScope.Global, roleDefinitionId);
            #endregion
        }
    }
}

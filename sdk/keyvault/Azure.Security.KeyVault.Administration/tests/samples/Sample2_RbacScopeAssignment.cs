// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Administration.Models;
using Azure.Security.KeyVault.Administration.Tests;
using Azure.Security.KeyVault.Keys;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class RbacScopeAssignment : AccessControlTestBase
    {
        public RbacScopeAssignment(bool isAsync)
            : base(isAsync, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [SetUp]
        public void TestSetup()
        {
            _objectId = TestEnvironment.ClientObjectId;
        }

        [RecordedTest]
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

            #region Snippet:CreateRoleAssignmentKeysScope
            //@@string definitionIdToAssign = "<roleDefinitionId>";
            //@@string servicePrincipalObjectId = "<objectId>";

            //@@RoleAssignment keysScopedAssignment = await client.CreateRoleAssignmentAsync(RoleAssignmentScope.Global, definitionIdToAssign, servicePrincipalObjectId);
            /*@@*/KeyVaultRoleAssignment keysScopedAssignment = await client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Keys, definitionIdToAssign, servicePrincipalObjectId , _roleAssignmentId).ConfigureAwait(false);
            #endregion

            RegisterForCleanup(keysScopedAssignment);

            // Make sure we have a key to secure.
            KeyClient keyClient = KeyClient;
            KeyVaultKey createdKey = await keyClient.CreateKeyAsync(Recording.GenerateId(), KeyType.Oct);
            string keyName = createdKey.Name;

            RegisterKeyForCleanup(keyName);

            #region Snippet:CreateRoleAssignmentKeyScope
            //@@string keyName = "<your-key-name>";
            KeyVaultKey key = await keyClient.GetKeyAsync(keyName);

            //@@RoleAssignment keyScopedAssignment = await client.CreateRoleAssignmentAsync(new RoleAssignmentScope(key.Id), definitionIdToAssign, servicePrincipalObjectId);
            /*@@*/KeyVaultRoleAssignment keyScopedAssignment = await client.CreateRoleAssignmentAsync(new KeyVaultRoleScope(key.Id), definitionIdToAssign, servicePrincipalObjectId, _roleAssignmentId).ConfigureAwait(false);
            #endregion

            RegisterForCleanup(keyScopedAssignment);
        }
    }
}

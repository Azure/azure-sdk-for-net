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
        public RbacScopeAssignment(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, change this argument to RecordedTestMode.Record */)
        { }

        [SetUp]
        public void TestSetup()
        {
            _objectId = TestEnvironment.ClientObjectId;
        }

        [Test]
        public async Task CreateRoleAssignmentAsync()
        {
            // Replace client with the Instrumented Client.
            client = Client;

            List<RoleDefinition> definitions = await client.GetRoleDefinitionsAsync(RoleAssignmentScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            _roleDefinitionId = definitions.FirstOrDefault(d => d.RoleName == RoleName).Id;

            // Replace roleDefinitionId with a role definition Id from the definitions returned from GetRoleDefinitionsAsync.
            string definitionIdToAssign = _roleDefinitionId;

            // Replace objectId with the service principal object id.
            string servicePrincipalObjectId = _objectId;

            #region Snippet:CreateRoleAssignmentKeysScope
            //@@string definitionIdToAssign = "<roleDefinitionId>";
            //@@string servicePrincipalObjectId = "<objectId>";

            RoleAssignmentProperties properties = new RoleAssignmentProperties(definitionIdToAssign, servicePrincipalObjectId);
            //@@RoleAssignment keysScopedAssignment = await client.CreateRoleAssignmentAsync(RoleAssignmentScope.Global, properties);
            /*@@*/RoleAssignment keysScopedAssignment = await client.CreateRoleAssignmentAsync(RoleAssignmentScope.Keys, properties, _roleAssignmentId).ConfigureAwait(false);
            #endregion

            RegisterForCleanup(keysScopedAssignment);

            var keyClient = KeyClient;
            List<KeyProperties> keyProperties = await keyClient.GetPropertiesOfKeysAsync().ToEnumerableAsync().ConfigureAwait(false);
            string keyName = keyProperties.First().Name;

            #region Snippet:CreateRoleAssignmentKeyScope
            //@@string keyName = "<your-key-name>";
            KeyVaultKey key = await keyClient.GetKeyAsync(keyName);

            //@@RoleAssignment keyScopedAssignment = await client.CreateRoleAssignmentAsync(new RoleAssignmentScope(key.Id), properties);
            /*@@*/RoleAssignment keyScopedAssignment = await client.CreateRoleAssignmentAsync(new RoleAssignmentScope(key.Id), properties, _roleAssignmentId).ConfigureAwait(false);
            #endregion

            RegisterForCleanup(keyScopedAssignment);
        }
    }
}

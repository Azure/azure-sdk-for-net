// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class SynapseAccessControlClient
    {
        public virtual Response<SynapseRoleAssignment> CreateRoleAssignment(SynapseRoleScope roleScope, string roleDefinitionId, string principalId, Guid? roleAssignmentName = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleDefinitionId, nameof(roleDefinitionId));
            Argument.AssertNotNullOrEmpty(principalId, nameof(principalId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(CreateRoleAssignment)}");
            scope.Start();
            try
            {
                string name = (roleAssignmentName ?? Guid.NewGuid()).ToString();

                Response createRoleAssignmentResponse = CreateRoleAssignment(
                    name,
                    RequestContent.Create(
                        new
                        {
                            RoleId = roleDefinitionId,
                            PrincipalId = principalId,
                            Scope = roleScope.ToString()
                        }),
                    new RequestOptions()
                    {
                        CancellationToken = cancellationToken
                    });

                JsonDocument roleAssignment = JsonDocument.Parse(createRoleAssignmentResponse.Content.ToMemory());

                return Response.FromValue(new SynapseRoleAssignment(
                    roleAssignment.RootElement.GetProperty("id").ToString(),
                    new SynapseRoleAssignmentProperties(
                        roleAssignment.RootElement.GetProperty("principalId").ToString(),
                        roleAssignment.RootElement.GetProperty("roleDefinitionId").ToString(),
                        roleAssignment.RootElement.GetProperty("scope").ToString())),
                    createRoleAssignmentResponse);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        //public virtual Task<Response<KeyVaultRoleAssignment>> CreateRoleAssignmentAsync(KeyVaultRoleScope roleScope, string roleDefinitionId, string principalId, Guid? roleAssignmentName = null, CancellationToken cancellationToken = default);
    }
}

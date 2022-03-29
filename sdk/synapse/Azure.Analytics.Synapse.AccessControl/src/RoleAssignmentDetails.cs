// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    /// <summary> Role Assignment response details. </summary>
    public partial class RoleAssignmentDetails
    {
        /// <summary> Initializes a new instance of RoleAssignmentDetails. </summary>
        internal RoleAssignmentDetails()
        {
        }

        /// <summary> Initializes a new instance of RoleAssignmentDetails. </summary>
        /// <param name="id"> Role Assignment ID. </param>
        /// <param name="roleDefinitionId"> Role ID of the Synapse Built-In Role. </param>
        /// <param name="principalId"> Object ID of the AAD principal or security-group. </param>
        /// <param name="scope"> Scope at the role assignment is created. </param>
        /// <param name="principalType"> Type of the principal Id: User, Group or ServicePrincipal. </param>
        internal RoleAssignmentDetails(string id, Guid? roleDefinitionId, Guid? principalId, string scope, string principalType)
        {
            Id = id;
            RoleDefinitionId = roleDefinitionId;
            PrincipalId = principalId;
            Scope = scope;
            PrincipalType = principalType;
        }

        /// <summary> Role Assignment ID. </summary>
        public string Id { get; }
        /// <summary> Role ID of the Synapse Built-In Role. </summary>
        public Guid? RoleDefinitionId { get; }
        /// <summary> Object ID of the AAD principal or security-group. </summary>
        public Guid? PrincipalId { get; }
        /// <summary> Scope at the role assignment is created. </summary>
        public string Scope { get; }
        /// <summary> Type of the principal Id: User, Group or ServicePrincipal. </summary>
        public string PrincipalType { get; }

        public static implicit operator RoleAssignmentDetails(Response response)
        {
            if (response.IsError)
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                throw new RequestFailedException(response);
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
            }

            using var doc = JsonDocument.Parse(response.Content.ToMemory());
            return DeserializeRoleAssignmentDetails(doc.RootElement);
        }
    }
}

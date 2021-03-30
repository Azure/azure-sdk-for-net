// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.Core;

namespace Proto.Authorization
{
    /// <summary>
    /// Placholder class containing Role assignment POCO properties.
    /// </summary>
    public class RoleAssignmentData : Resource<TenantResourceIdentifier>
    {
        private Azure.ResourceManager.Authorization.Models.RoleAssignment _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignmentData"/> class.
        /// </summary>
        /// <param name="assign"> The Track2 management plane assignment. </param>
        public RoleAssignmentData(Azure.ResourceManager.Authorization.Models.RoleAssignment assign)
        {
            _model = assign;
            Id = new TenantResourceIdentifier(assign.Id);
            Scope = assign.Scope;
            RoleDefinitionId = assign.RoleDefinitionId;
            PrincipalId = assign.PrincipalId;
            PrincipalType = assign.PrincipalType;
            CanDelegate = assign.CanDelegate;
        }

        /// <summary>
        /// Gets the resource type of thsi resource.
        /// </summary>
        public static Azure.ResourceManager.Core.ResourceType ResourceType => "Microsoft.Authorization/roleAssignments";

        /// <summary>
        /// Gets the target of this role assignment.
        /// </summary>
        public string Scope { get; }

        /// <summary>
        /// Gets the role definition id for this role assignment - determines the permissions allowed by this assignment.
        /// </summary>
        public ResourceIdentifier RoleDefinitionId { get; }

        /// <summary>
        /// Gets the ActiveDirectory principal that is assigned privileges to the target by this assignemnt.
        /// </summary>
        public string PrincipalId { get; }

        /// <summary>
        /// Gets the type of the principal associated with this assignment.
        /// </summary>
        public PrincipalType? PrincipalType { get; }

        /// <summary>
        /// Gets the value determining whether the principal can delegate its permissions.
        /// </summary>
        public bool? CanDelegate { get; }

        /// <summary>
        /// Gets or sets the identifier of the RoleAssignment.
        /// </summary>
        public override TenantResourceIdentifier Id { get; protected set; }

        /// <summary>
        /// Gets the Track2 Management model associated with the data object.
        /// </summary>
        /// <returns> The Track2 Role Assignment, for serialization. </returns>
        public Azure.ResourceManager.Authorization.Models.RoleAssignment ToModel()
        {
            return _model;
        }
    }
}

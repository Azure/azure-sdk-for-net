// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.Core;

namespace Proto.Authorization
{
    /// <summary>
    /// Creation properties for RoleAssignments
    /// </summary>
    public class RoleAssignmentCreateParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignmentCreateParameters"/> class.
        /// </summary>
        /// <param name="roleDefinitionId">The granted permissiosn for this assignment</param>
        /// <param name="principalId">The principal id for this assignment</param>
        public RoleAssignmentCreateParameters(ResourceIdentifier roleDefinitionId, string principalId)
        {
            RoleDefinitionId = roleDefinitionId;
            PrincipalId = principalId;
            PrincipalType = Azure.ResourceManager.Authorization.Models.PrincipalType.ServicePrincipal;
        }

        /// <summary>
        /// Gets the identifier of the role definition used in the assignment
        /// </summary>
        public ResourceIdentifier RoleDefinitionId { get; }

        /// <summary>
        /// Gets the Object ID of the principal used in the assignment
        /// </summary>
        public string PrincipalId { get; }

        /// <summary>
        /// Gets or sets the type of the principal used in the assignment
        /// </summary>
        public PrincipalType? PrincipalType { get; set; }

        /// <summary>
        /// Gets or sets the data indicating whether the principal can delegate privileges
        /// </summary>
        public bool? CanDelegate { get; set; }

        /// <summary>
        /// Return the underlying serialization model
        /// </summary>
        /// <returns>The serialization model for the role assignemnt</returns>
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateParameters ToModel()
        {
            var model = new Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateParameters(RoleDefinitionId, PrincipalId);
            model.PrincipalType = PrincipalType;
            model.CanDelegate = CanDelegate;
            return model;
        }
    }
}

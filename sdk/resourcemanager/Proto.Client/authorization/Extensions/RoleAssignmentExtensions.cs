// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using Azure.ResourceManager.Core;

namespace Proto.Authorization
{
    /// <summary>
    /// Extensions for RoleAssignment Containers and Operations
    /// </summary>
    public static class RoleAssignmentExtensions
    {
        /// <summary>
        /// Get RoleAssignment Container for the given resource.  Note that this is only valid for unconstrained role assignments, so
        /// it is a generation-time decision if we include this.
        /// </summary>
        /// <param name="resource">The resource that is the target of the roel assignemnt</param>
        /// <returns>A <see cref="RoleAssignmentContainer"/> that allows creating and listing RoleAssignments</returns>
        public static RoleAssignmentContainer GetRoleAssignments(this ResourceOperationsBase resource)
        {
            return new RoleAssignmentContainer(resource);
        }

        /// <summary>
        /// Get RoleAssignment Container for the given resource.  Note that this is only valid for unconstrained role assignments, so
        /// it is a generation-time decision if we include this.
        /// </summary>
        /// <param name="resource">The subscription that is the target of the role assignemnt</param>
        /// <returns>A <see cref="RoleAssignmentContainer"/> that allows creating and listing RoleAssignments</returns>
        public static RoleAssignmentContainer GetRoleAssignments(this SubscriptionOperations resource)
        {
            return new RoleAssignmentContainer(resource);
        }

        /// <summary>
        /// Get RoleAssignment Container for the given resource and scope.  Note that this is only valid for unconstrained role assignments, so
        /// it is a generation-time decision if we include this.
        /// </summary>
        /// <param name="subscription">The subscription containign the role assignment</param>
        /// <param name="scope">The target of the role assignment</param>
        /// <returns>A <see cref="RoleAssignmentContainer"/> that allows creating and listing RoleAssignments</returns>
        public static RoleAssignmentContainer GetRoleAssigmentsAtScope(this SubscriptionOperations subscription, ResourceIdentifier scope)
        {
            return new RoleAssignmentContainer(subscription, scope);
        }

        /// <summary>
        /// Get RoleAssignment Container for the given resource and scope.  Note that this is only valid for unconstrained role assignments, so
        /// it is a generation-time decision if we include this.
        /// </summary>
        /// <param name="subscription">The subscription containign the role assignment</param>
        /// <param name="scope">The target of the role assignment</param>
        /// <returns>A <see cref="RoleAssignmentContainer"/> that allows creating and listing RoleAssignments</returns>
        public static RoleAssignmentContainer GetRoleAssigmentsAtScope(this SubscriptionOperations subscription, Resource<TenantResourceIdentifier> scope)
        {
            return new RoleAssignmentContainer(subscription, scope.Id);
        }

        /// <summary>
        /// Get RoleAssignment Operations for the given resource and scope.  Note that this is only valid for unconstrained role assignments, so
        /// it is a generation-time decision if we include this.
        /// </summary>
        /// <param name="resource">The resource containing the role assignment</param>
        /// <param name="name">The name of the role assignment</param>
        /// <returns>A <see cref="RoleAssignmentOperations"/> that allows getting and deleting RoleAssignments</returns>
        public static RoleAssignmentOperations GetRoleAssignmentOperations(this ResourceOperationsBase resource, string name)
        {
            return new RoleAssignmentOperations(resource, $"{resource.Id}/providers/Microsoft.Authorization/roleAssignments/{name}");
        }

        /// <summary>
        /// Get RoleAssignment Operations for the given resource and scope.  Note that this is only valid for unconstrained role assignments, so
        /// it is a generation-time decision if we include this.
        /// </summary>
        /// <param name="resource">The subscription containing the role assignment</param>
        /// <param name="name">The name of the role assignment</param>
        /// <returns>A <see cref="RoleAssignmentOperations"/> that allows getting and deleting RoleAssignments</returns>
        public static RoleAssignmentOperations GetRoleAssignmentOperations(this SubscriptionOperations resource, string name)
        {
            return new RoleAssignmentOperations(resource, $"{resource.Id}/providers/Microsoft.Authorization/roleAssignments/{name}");
        }

        /// <summary>
        /// Get RoleAssignment Operations for the given resource and scope.  Note that this is only valid for unconstrained role assignments, so
        /// it is a generation-time decision if we include this.
        /// </summary>
        /// <param name="resource">The subscription containing the role assignment</param>
        /// <param name="resourceId">The id of the role assignment</param>
        /// <returns>A <see cref="RoleAssignmentOperations"/> that allows getting and deleting RoleAssignments</returns>
        public static RoleAssignmentOperations GetRoleAssignmentOperationsAtScope(this SubscriptionOperations resource, ResourceIdentifier resourceId)
        {
            return new RoleAssignmentOperations(resource, resourceId);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.ResourceManager.Authorization;
using Azure.ResourceManager.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Authorization
{
    /// <summary>
    /// Operations over Role Assignments for Role-based access control to ARM resources
    /// </summary>
    public class RoleAssignmentOperations : ExtensionResourceOperationsBase<RoleAssignment>, IDeletableResource
    {
        /// <summary>
        /// Gets the resource type for Role Assignments.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Authorization/roleAssignments";

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignmentOperations"/> class.
        /// Allows creating operations specific to a role assignment from generic ARM operations for the same resource
        /// </summary>
        /// <param name="genericOperations">A generic operations class corresponding to a Role Assignment. </param>
        internal RoleAssignmentOperations(GenericResourceOperations genericOperations)
            : base(genericOperations)
        {
            string subscriptionId;
            if (!Id.TryGetSubscriptionId(out subscriptionId))
            {
                // TODO: Remove this once we have swapped in the REST client
                subscriptionId = Guid.Empty.ToString();
            }

            Operations = new AuthorizationManagementClient(subscriptionId, BaseUri, Credential).RoleAssignments;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignmentOperations"/> class.
        /// </summary>
        /// <param name="operation"> The http settings to use with these operations. </param>
        /// <param name="id"> The resource identifier for the RoleAssignment to operate on. </param>
        internal RoleAssignmentOperations(OperationsBase operation, ResourceIdentifier id)
            : base(operation, id)
        {
            string subscriptionId;
            if (!Id.TryGetSubscriptionId(out subscriptionId))
            {
                // TODO: Remove this once we have swapped in the REST client
                subscriptionId = Guid.Empty.ToString();
            }

            Operations = new AuthorizationManagementClient(subscriptionId, BaseUri, Credential).RoleAssignments;
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        private RoleAssignmentsOperations Operations { get; }

        /// <inheritdoc/>
        public ArmResponse<Response> Delete(CancellationToken cancellationToken = default)
        {
            return new ArmResponse(Operations.DeleteById(Id, cancellationToken).GetRawResponse());
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.DeleteByIdAsync(Id, cancellationToken)).GetRawResponse());
        }

        /// <inheritdoc/>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.DeleteById(Id, cancellationToken).GetRawResponse());
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation((await Operations.DeleteByIdAsync(Id, cancellationToken)).GetRawResponse());
        }

        /// <inheritdoc/>
        public override ArmResponse<RoleAssignment> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<RoleAssignment, Azure.ResourceManager.Authorization.Models.RoleAssignment>(
                Operations.GetById(Id, cancellationToken),
                a => new RoleAssignment(this, new RoleAssignmentData(a)));
        }

        /// <inheritdoc/>
        public async override Task<ArmResponse<RoleAssignment>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<RoleAssignment, Azure.ResourceManager.Authorization.Models.RoleAssignment>(
                await Operations.GetByIdAsync(Id, cancellationToken),
                a => new RoleAssignment(this, new RoleAssignmentData(a)));
        }
    }
}

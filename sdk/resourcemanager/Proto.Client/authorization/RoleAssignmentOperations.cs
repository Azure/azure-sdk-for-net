﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class RoleAssignmentOperations : ResourceOperationsBase<SubscriptionResourceIdentifier, RoleAssignment>
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
        internal RoleAssignmentOperations(ResourceOperationsBase parent)
            : base(parent, parent.Id)
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
        public Response Delete(CancellationToken cancellationToken = default)
        {
            return Operations.DeleteById(Id, cancellationToken).GetRawResponse();
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return (await Operations.DeleteByIdAsync(Id, cancellationToken)).GetRawResponse();
        }

        /// <inheritdoc/>
        public Operation StartDelete(CancellationToken cancellationToken = default)
        {
            return new PhVoidArmOperation(Operations.DeleteById(Id, cancellationToken).GetRawResponse());
        }

        /// <inheritdoc/>
        public async Task<Operation> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new PhVoidArmOperation((await Operations.DeleteByIdAsync(Id, cancellationToken)).GetRawResponse());
        }

        /// <inheritdoc/>
        public override Response<RoleAssignment> Get(CancellationToken cancellationToken = default)
        {
            var response = Operations.GetById(Id, cancellationToken);
            return Response.FromValue(new RoleAssignment(this, new RoleAssignmentData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public async override Task<Response<RoleAssignment>> GetAsync(CancellationToken cancellationToken = default)
        {
            var response = await Operations.GetByIdAsync(Id, cancellationToken);
            return Response.FromValue(new RoleAssignment(this, new RoleAssignmentData(response.Value)), response.GetRawResponse());
        }
    }
}

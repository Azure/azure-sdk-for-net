// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Authorization;
using Azure.ResourceManager.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Authorization
{
    /// <summary>
    /// Container for role assignments - note that in this case, the container is either a TrackedResource or a resource Id
    /// </summary>
    public class RoleAssignmentContainer : ExtensionResourceContainer<RoleAssignment, RoleAssignmentCreateParameters>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignmentContainer"/> class.
        /// </summary>
        /// <param name="operations"> A generic operations class representing the parent of the role Assignment. </param>
        internal RoleAssignmentContainer(OperationsBase operations)
            : base(operations)
        {
            // TODO: Remove this once we nio longer need to create management clients
            string subscriptionId;
            if (!operations.Id.TryGetSubscriptionId(out subscriptionId))
            {
                subscriptionId = Guid.Empty.ToString();
            }

            Operations = new AuthorizationManagementClient(subscriptionId, BaseUri, Credential).RoleAssignments;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignmentContainer"/> class.
        /// </summary>
        /// <param name="operations"> The client options with http client details for these operations. </param>
        /// <param name="scope"> The resource id of the target resource, resource group, or subscription for this role assignment. </param>
        internal RoleAssignmentContainer(OperationsBase operations, ResourceIdentifier scope)
            : base(operations, scope)
        {
            // TODO: Remove this once we nio longer need to create management clients
            string subscriptionId;
            if (!operations.Id.TryGetSubscriptionId(out subscriptionId))
            {
                subscriptionId = Guid.Empty.ToString();
            }

            Operations = new AuthorizationManagementClient(subscriptionId, BaseUri, Credential).RoleAssignments;
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => RoleAssignmentOperations.ResourceType;

        /// <summary>
        /// Gets the resource type of the resource being created.
        /// </summary>
        private RoleAssignmentsOperations Operations { get; }

        /// <summary>
        /// Create a role assignment. This method blocks until the RoleAssignment is created on the service.
        /// </summary>
        /// <param name="name"> The name of the role assignment. </param>
        /// <param name="resourceDetails"> The properties of the role assignment. </param>
        /// <param name="cancellationToken"> A token that allows cancellation of any blockign API calls made during this method. </param>
        /// <returns> The created role assignment. </returns>
        public override ArmResponse<RoleAssignment> Create(string name, RoleAssignmentCreateParameters resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = Operations.Create(Id, name, resourceDetails.ToModel(), cancellationToken);
            return new PhArmResponse<RoleAssignment, Azure.ResourceManager.Authorization.Models.RoleAssignment>(
                response,
                a => new RoleAssignment(this, new RoleAssignmentData(a)));
        }

        /// <summary>
        /// Create a role assignment. This method returns a task performs the creation. The task may make multiple blocking calls.
        /// When complete the task yields the created RoleAssignment.
        /// </summary>
        /// <param name="name"> The name of the role assignment. </param>
        /// <param name="resourceDetails"> The properties of the role assignment. </param>
        /// <param name="cancellationToken"> A token that allows cancellation of any blockign API calls made during this method. </param>
        /// <returns> A Task that yields the created role assignment when complete. </returns>
        public async override Task<ArmResponse<RoleAssignment>> CreateAsync(string name, RoleAssignmentCreateParameters resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = await Operations.CreateAsync(Id, name, resourceDetails.ToModel(), cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<RoleAssignment, Azure.ResourceManager.Authorization.Models.RoleAssignment>(
                response,
                a => new RoleAssignment(this, new RoleAssignmentData(a)));
        }

        /// <summary>
        /// Create a role assignment. This method blocks until the RoleAssignment creation is accepted on the service. It returns an
        /// <see cref="ArmOperation{RoleAssignment}"/> allowing the caller to control polling and waiting for the creation to complete.
        /// </summary>
        /// <param name="name"> The name of the role assignment. </param>
        /// <param name="resourceDetails"> The properties of the role assignment. </param>
        /// <param name="cancellationToken"> A token that allows cancellation of any blocking API calls made during this method. </param>
        /// <returns> An ArmOperation that yields the created role assignment and gives the user control over polling. </returns>
        public override ArmOperation<RoleAssignment> StartCreate(string name, RoleAssignmentCreateParameters resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<RoleAssignment, Azure.ResourceManager.Authorization.Models.RoleAssignment>(
                Operations.Create(Id, name, resourceDetails.ToModel(), cancellationToken),
                a => new RoleAssignment(this, new RoleAssignmentData(a)));
        }

        /// <summary>
        /// Create a role assignment. This method blocks until the RoleAssignment creation is accepted on the service. It returns an
        /// <see cref="ArmOperation{RoleAssignment}"/> allowing the caller to control polling and waiting for the creation to complete.
        /// </summary>
        /// <param name="name"> The name of the role assignment. </param>
        /// <param name="resourceDetails"> The properties of the role assignment. </param>
        /// <param name="cancellationToken"> A token that allows cancellation of any blocking API calls made during this method. </param>
        /// <returns> A <see cref="Task{ArmOperation}"/> that yields the created role assignment and gives the user control over polling. </returns>
        public async override Task<ArmOperation<RoleAssignment>> StartCreateAsync(string name, RoleAssignmentCreateParameters resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<RoleAssignment, Azure.ResourceManager.Authorization.Models.RoleAssignment>(
                await Operations.CreateAsync(Id, name, resourceDetails.ToModel(), cancellationToken).ConfigureAwait(false),
                a => new RoleAssignment(this, new RoleAssignmentData(a)));
        }

        /// <summary>
        /// List all role assignments at this scope.  This call blocks until the first page or results is returned from the service.
        /// </summary>
        /// <param name="cancellationToken"> A token that allows cancellation of any blocking API calls made during this method. </param>
        /// <returns> A <see cref="Azure.Pageable{RoleAssignemnt}"/> that allows paged enumeration of the role assignments at this scope. </returns>
        public override Azure.Pageable<RoleAssignment> ListAtScope(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// List all role assignments at this scope.
        /// </summary>
        /// <param name="cancellationToken"> A token that allows cancellation of any blocking API calls made during this method. </param>
        /// <returns> A <see cref="Azure.AsyncPageable{RoleAssignemnt}"/> that allows asynchronous paged enumeration of the role assignments at this scope. </returns>
        public override Azure.AsyncPageable<RoleAssignment> ListAtScopeAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        protected override void Validate(ResourceIdentifier identifier)
        {
            return;
        }
    }
}

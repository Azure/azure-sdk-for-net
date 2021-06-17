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
    /// Container for role assignments - note that in this case, the container is either a TrackedResource or a resource Id
    /// </summary>
    public class RoleAssignmentContainer : ResourceContainerBase<SubscriptionResourceIdentifier, RoleAssignment, RoleAssignmentCreateParameters>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignmentContainer"/> class.
        /// </summary>
        /// <param name="operations"> A generic operations class representing the parent of the role Assignment. </param>
        internal RoleAssignmentContainer(ResourceOperationsBase operations)
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
        internal RoleAssignmentContainer(ResourceOperationsBase operations, ResourceIdentifier scope)
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

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => RoleAssignmentOperations.ResourceType;

        /// <summary>
        /// Gets the resource type of the resource being created.
        /// </summary>
        private RoleAssignmentsOperations Operations { get; }

        /// <summary>
        /// Gets a RoleAssignment
        /// </summary>
        /// <param name="resourceName"> The role assignment name. </param>
        /// <param name="cancellationToken"> A token that allows cancellation of any blockign API calls made during this method. </param>
        /// <returns> The role assignment. </returns>
        public override Response<RoleAssignment> Get(string resourceName, CancellationToken cancellationToken = default)
        {
            var response = Operations.Get(Id, resourceName, cancellationToken);
            return Response.FromValue(new RoleAssignment(this, new RoleAssignmentData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// Gets a RoleAssignment
        /// </summary>
        /// <param name="resourceName"> The role assignment name. </param>
        /// <param name="cancellationToken"> A token that allows cancellation of any blockign API calls made during this method. </param>
        /// <returns> The role assignment. </returns>
        public async override Task<Response<RoleAssignment>> GetAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            var response = await Operations.GetAsync(Id, resourceName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new RoleAssignment(this, new RoleAssignmentData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// Create a role assignment. This method blocks until the RoleAssignment is created on the service.
        /// </summary>
        /// <param name="name"> The name of the role assignment. </param>
        /// <param name="resourceDetails"> The properties of the role assignment. </param>
        /// <param name="cancellationToken"> A token that allows cancellation of any blockign API calls made during this method. </param>
        /// <returns> The created role assignment. </returns>
        public Response<RoleAssignment> Create(string name, RoleAssignmentCreateParameters resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = Operations.Create(Id, name, resourceDetails.ToModel(), cancellationToken);
            return Response.FromValue(new RoleAssignment(this, new RoleAssignmentData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// Create a role assignment. This method returns a task performs the creation. The task may make multiple blocking calls.
        /// When complete the task yields the created RoleAssignment.
        /// </summary>
        /// <param name="name"> The name of the role assignment. </param>
        /// <param name="resourceDetails"> The properties of the role assignment. </param>
        /// <param name="cancellationToken"> A token that allows cancellation of any blockign API calls made during this method. </param>
        /// <returns> A Task that yields the created role assignment when complete. </returns>
        public async Task<Response<RoleAssignment>> CreateAsync(string name, RoleAssignmentCreateParameters resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = await Operations.CreateAsync(Id, name, resourceDetails.ToModel(), cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new RoleAssignment(this, new RoleAssignmentData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// Create a role assignment. This method blocks until the RoleAssignment creation is accepted on the service. It returns an
        /// <see cref="Operation{RoleAssignment}"/> allowing the caller to control polling and waiting for the creation to complete.
        /// </summary>
        /// <param name="name"> The name of the role assignment. </param>
        /// <param name="resourceDetails"> The properties of the role assignment. </param>
        /// <param name="cancellationToken"> A token that allows cancellation of any blocking API calls made during this method. </param>
        /// <returns> An ArmOperation that yields the created role assignment and gives the user control over polling. </returns>
        public Operation<RoleAssignment> StartCreate(string name, RoleAssignmentCreateParameters resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<RoleAssignment, Azure.ResourceManager.Authorization.Models.RoleAssignment>(
                Operations.Create(Id, name, resourceDetails.ToModel(), cancellationToken),
                a => new RoleAssignment(this, new RoleAssignmentData(a)));
        }

        /// <summary>
        /// Create a role assignment. This method blocks until the RoleAssignment creation is accepted on the service. It returns an
        /// <see cref="Operation{RoleAssignment}"/> allowing the caller to control polling and waiting for the creation to complete.
        /// </summary>
        /// <param name="name"> The name of the role assignment. </param>
        /// <param name="resourceDetails"> The properties of the role assignment. </param>
        /// <param name="cancellationToken"> A token that allows cancellation of any blocking API calls made during this method. </param>
        /// <returns> A <see cref="Task{ArmOperation}"/> that yields the created role assignment and gives the user control over polling. </returns>
        public async Task<Operation<RoleAssignment>> StartCreateAsync(string name, RoleAssignmentCreateParameters resourceDetails, CancellationToken cancellationToken = default)
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
        public Azure.Pageable<RoleAssignment> ListAtScope(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// List all role assignments at this scope.
        /// </summary>
        /// <param name="cancellationToken"> A token that allows cancellation of any blocking API calls made during this method. </param>
        /// <returns> A <see cref="Azure.AsyncPageable{RoleAssignemnt}"/> that allows asynchronous paged enumeration of the role assignments at this scope. </returns>
        public Azure.AsyncPageable<RoleAssignment> ListAtScopeAsync(CancellationToken cancellationToken = default)
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

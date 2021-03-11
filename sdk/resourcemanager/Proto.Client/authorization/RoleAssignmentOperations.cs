// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.ResourceManager.Authorization;
using Azure.ResourceManager.Core;
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
        /// Gets the resource type for Role Assignments
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
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignmentOperations"/> class.
        /// </summary>
        /// <param name="operation"> The http settings to use with these operations. </param>
        /// <param name="id"> The resource identifier for the RoleAssignment to operate on. </param>
        internal RoleAssignmentOperations(OperationsBase operation, ResourceIdentifier id)
            : base(operation, id)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        private RoleAssignmentsOperations Operations => new AuthorizationManagementClient(
            Id.Subscription,
            BaseUri,
            Credential).RoleAssignments;

        /// <summary>
        /// Delete a role assignment. This operation may involve multiple blocking calls to the service.
        /// The operation returns when deletion is complete on the service.
        /// </summary>
        /// <returns> The http response returned from the server. </returns>
        public ArmResponse<Response> Delete()
        {
            return new ArmResponse(Operations.DeleteById(Id).GetRawResponse());
        }

        /// <summary>
        /// Delete a role assignment. This operation creates a Task to perform and monitor deletion of the role assignment.
        /// The task may perform multiple blocking calls, the provided <see cref="System.Threading.CancellationToken"/> can be
        /// used to cancel any of these calls.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing the user to cancel the REST API call. </param>
        /// <returns> A Task that will yield the http response from the server to the delete request once the Task is completed. </returns>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.DeleteByIdAsync(Id)).GetRawResponse());
        }

        /// <summary>
        /// Delete a Role Assignment. This call blocks until the initial response is returned from the service.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing the user to cancel the REST API call. </param>
        /// <returns> An <see cref="ArmOperation{Response}"/> that allows the user to control how to wait and poll
        /// for the delete operation to complete. </returns>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.DeleteById(Id, cancellationToken).GetRawResponse());
        }

        /// <summary>
        /// Delete a Role Assignment. This call returns a Task that blocks until the initial response is returned from the service.
        /// The task yields an <see cref="ArmOperation{Response}"/> that allows the user to control how to wait and poll for the
        /// delete operation on the service to complete
        /// </summary>
        /// <param name="cancellationToken"> A token allowing the user to cancel the REST API call. </param>
        /// <returns> A <see cref="Task{ArmOperation}"/>.  The task yields an Operation that allows the caller to control how to
        /// wait and poll for operation completion on the service. </returns>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation((await Operations.DeleteByIdAsync(Id, cancellationToken)).GetRawResponse());
        }

        /// <summary>
        /// Gets the RoleAssignment.  This call will block until a response is returned from the servcie.
        /// </summary>
        /// <returns> A <see cref="ArmResponse{RoleAssignment}"/>, the http response from the service. </returns>
        public override ArmResponse<RoleAssignment> Get()
        {
            return new PhArmResponse<RoleAssignment, Azure.ResourceManager.Authorization.Models.RoleAssignment>(
                Operations.GetById(Id), a => new RoleAssignment(this, new RoleAssignmentData(a)));
        }

        /// <summary>
        /// Get the role assignment.  This call returns a <see cref="Task"/>.  When complete, the Task yields the <see cref="RoleAssignment"/>
        /// </summary>
        /// <param name="cancellationToken"> A token allowing the user to cancel the REST API call. </param>
        /// <returns> A <see cref="Task"/> that performs the Get operation.  The Task yields a
        /// <see cref="RoleAssignment"/> when complete. </returns>
        public async override Task<ArmResponse<RoleAssignment>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<RoleAssignment, Azure.ResourceManager.Authorization.Models.RoleAssignment>(
                await Operations.GetByIdAsync(Id, cancellationToken),
                a => new RoleAssignment(this, new RoleAssignmentData(a)));
        }
    }
}

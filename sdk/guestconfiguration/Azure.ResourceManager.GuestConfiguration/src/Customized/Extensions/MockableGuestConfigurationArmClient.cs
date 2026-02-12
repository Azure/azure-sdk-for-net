// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.GuestConfiguration.Mocking
{
    public partial class MockableGuestConfigurationArmClient
    {
        private static ResourceIdentifier GetResourceGroupId(ResourceIdentifier scope)
        {
            return ResourceGroupResource.CreateResourceIdentifier(scope.SubscriptionId, scope.ResourceGroupName);
        }

        /// <summary> Gets a collection of GuestConfigurationVmAssignmentResources in the ArmClient. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual GuestConfigurationVmAssignmentCollection GetGuestConfigurationVmAssignments(ResourceIdentifier scope)
        {
            return new GuestConfigurationVmAssignmentCollection(Client, GetResourceGroupId(scope), scope.Name);
        }

        /// <summary> Gets a specific GuestConfigurationVmAssignmentResource. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<GuestConfigurationVmAssignmentResource>> GetGuestConfigurationVmAssignmentAsync(ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return await GetGuestConfigurationVmAssignments(scope).GetAsync(guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific GuestConfigurationVmAssignmentResource. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<GuestConfigurationVmAssignmentResource> GetGuestConfigurationVmAssignment(ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return GetGuestConfigurationVmAssignments(scope).Get(guestConfigurationAssignmentName, cancellationToken);
        }

        /// <summary> Gets a collection of GuestConfigurationHcrpAssignmentResources in the ArmClient. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual GuestConfigurationHcrpAssignmentCollection GetGuestConfigurationHcrpAssignments(ResourceIdentifier scope)
        {
            return new GuestConfigurationHcrpAssignmentCollection(Client, GetResourceGroupId(scope), scope.Name);
        }

        /// <summary> Gets a specific GuestConfigurationHcrpAssignmentResource. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<GuestConfigurationHcrpAssignmentResource>> GetGuestConfigurationHcrpAssignmentAsync(ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return await GetGuestConfigurationHcrpAssignments(scope).GetAsync(guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific GuestConfigurationHcrpAssignmentResource. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<GuestConfigurationHcrpAssignmentResource> GetGuestConfigurationHcrpAssignment(ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return GetGuestConfigurationHcrpAssignments(scope).Get(guestConfigurationAssignmentName, cancellationToken);
        }

        /// <summary> Gets a collection of GuestConfigurationVmssAssignmentResources in the ArmClient. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual GuestConfigurationVmssAssignmentCollection GetGuestConfigurationVmssAssignments(ResourceIdentifier scope)
        {
            return new GuestConfigurationVmssAssignmentCollection(Client, GetResourceGroupId(scope), scope.Name);
        }

        /// <summary> Gets a specific GuestConfigurationVmssAssignmentResource. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="name"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<GuestConfigurationVmssAssignmentResource>> GetGuestConfigurationVmssAssignmentAsync(ResourceIdentifier scope, string name, CancellationToken cancellationToken = default)
        {
            return await GetGuestConfigurationVmssAssignments(scope).GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific GuestConfigurationVmssAssignmentResource. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="name"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<GuestConfigurationVmssAssignmentResource> GetGuestConfigurationVmssAssignment(ResourceIdentifier scope, string name, CancellationToken cancellationToken = default)
        {
            return GetGuestConfigurationVmssAssignments(scope).Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of GuestConfigurationVMwarevSphereAssignmentResources in the ArmClient. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual GuestConfigurationVMwarevSphereAssignmentCollection GetGuestConfigurationVMwarevSphereAssignments(ResourceIdentifier scope)
        {
            return new GuestConfigurationVMwarevSphereAssignmentCollection(Client, GetResourceGroupId(scope), scope.Name);
        }

        /// <summary> Gets a specific GuestConfigurationVMwarevSphereAssignmentResource. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<GuestConfigurationVMwarevSphereAssignmentResource>> GetGuestConfigurationVMwarevSphereAssignmentAsync(ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return await GetGuestConfigurationVMwarevSphereAssignments(scope).GetAsync(guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific GuestConfigurationVMwarevSphereAssignmentResource. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<GuestConfigurationVMwarevSphereAssignmentResource> GetGuestConfigurationVMwarevSphereAssignment(ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return GetGuestConfigurationVMwarevSphereAssignments(scope).Get(guestConfigurationAssignmentName, cancellationToken);
        }
    }
}

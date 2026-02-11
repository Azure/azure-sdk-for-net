// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.GuestConfiguration.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.GuestConfiguration
{
    public static partial class GuestConfigurationExtensions
    {
        // --- ArmClient extension methods (scope-based) ---

        /// <summary> Gets a collection of GuestConfigurationVmAssignmentResources in the ArmClient. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GuestConfigurationVmAssignmentCollection GetGuestConfigurationVmAssignments(this ArmClient client, ResourceIdentifier scope)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationVmAssignments(scope);
        }

        /// <summary> Gets a specific GuestConfigurationVmAssignment. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<GuestConfigurationVmAssignmentResource>> GetGuestConfigurationVmAssignmentAsync(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return await GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationVmAssignmentAsync(scope, guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific GuestConfigurationVmAssignment. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<GuestConfigurationVmAssignmentResource> GetGuestConfigurationVmAssignment(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationVmAssignment(scope, guestConfigurationAssignmentName, cancellationToken);
        }

        /// <summary> Gets a collection of GuestConfigurationHcrpAssignmentResources in the ArmClient. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GuestConfigurationHcrpAssignmentCollection GetGuestConfigurationHcrpAssignments(this ArmClient client, ResourceIdentifier scope)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationHcrpAssignments(scope);
        }

        /// <summary> Gets a specific GuestConfigurationHcrpAssignment. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<GuestConfigurationHcrpAssignmentResource>> GetGuestConfigurationHcrpAssignmentAsync(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return await GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationHcrpAssignmentAsync(scope, guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific GuestConfigurationHcrpAssignment. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<GuestConfigurationHcrpAssignmentResource> GetGuestConfigurationHcrpAssignment(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationHcrpAssignment(scope, guestConfigurationAssignmentName, cancellationToken);
        }

        /// <summary> Gets a collection of GuestConfigurationVmssAssignmentResources in the ArmClient. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GuestConfigurationVmssAssignmentCollection GetGuestConfigurationVmssAssignments(this ArmClient client, ResourceIdentifier scope)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationVmssAssignments(scope);
        }

        /// <summary> Gets a specific GuestConfigurationVmssAssignment. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="name"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<GuestConfigurationVmssAssignmentResource>> GetGuestConfigurationVmssAssignmentAsync(this ArmClient client, ResourceIdentifier scope, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return await GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationVmssAssignmentAsync(scope, name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific GuestConfigurationVmssAssignment. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="name"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<GuestConfigurationVmssAssignmentResource> GetGuestConfigurationVmssAssignment(this ArmClient client, ResourceIdentifier scope, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationVmssAssignment(scope, name, cancellationToken);
        }

        /// <summary> Gets a collection of GuestConfigurationVMwarevSphereAssignmentResources in the ArmClient. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GuestConfigurationVMwarevSphereAssignmentCollection GetGuestConfigurationVMwarevSphereAssignments(this ArmClient client, ResourceIdentifier scope)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationVMwarevSphereAssignments(scope);
        }

        /// <summary> Gets a specific GuestConfigurationVMwarevSphereAssignment. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<GuestConfigurationVMwarevSphereAssignmentResource>> GetGuestConfigurationVMwarevSphereAssignmentAsync(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return await GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationVMwarevSphereAssignmentAsync(scope, guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific GuestConfigurationVMwarevSphereAssignment. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<GuestConfigurationVMwarevSphereAssignmentResource> GetGuestConfigurationVMwarevSphereAssignment(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableGuestConfigurationArmClient(client).GetGuestConfigurationVMwarevSphereAssignment(scope, guestConfigurationAssignmentName, cancellationToken);
        }

        // --- GetAllGuestConfigurationAssignmentData methods ---

        /// <summary> List all guest configuration assignments for a resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableGuestConfigurationResourceGroupResource(resourceGroupResource).GetAllGuestConfigurationAssignmentData(cancellationToken);
        }

        /// <summary> List all guest configuration assignments for a resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableGuestConfigurationResourceGroupResource(resourceGroupResource).GetAllGuestConfigurationAssignmentDataAsync(cancellationToken);
        }

        /// <summary> List all guest configuration assignments for a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableGuestConfigurationSubscriptionResource(subscriptionResource).GetAllGuestConfigurationAssignmentData(cancellationToken);
        }

        /// <summary> List all guest configuration assignments for a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableGuestConfigurationSubscriptionResource(subscriptionResource).GetAllGuestConfigurationAssignmentDataAsync(cancellationToken);
        }
    }
}

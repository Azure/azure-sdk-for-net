// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.GuestConfiguration
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.GuestConfiguration. </summary>
    [CodeGenSuppress("GetGuestConfigurationAssignmentsAsync", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationAssignments", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationAssignmentsAsync", typeof(ResourceGroupResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationAssignments", typeof(ResourceGroupResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationVmAssignments", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetGuestConfigurationHcrpAssignments", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetGuestConfigurationVmssAssignments", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetGuestConfigurationVmAssignmentAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationVmAssignment", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationHcrpAssignmentAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationHcrpAssignment", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationVmssAssignmentAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationVmssAssignment", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    public static partial class GuestConfigurationExtensions
    {
        /// <summary>
        /// List all guest configuration assignments for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments
        /// Operation Id: GuestConfigurationAssignments_SubscriptionList
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GuestConfigurationAssignmentData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetAllGuestConfigurationAssignmentDataAsync(cancellationToken);
        }

        /// <summary>
        /// List all guest configuration assignments for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments
        /// Operation Id: GuestConfigurationAssignments_SubscriptionList
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GuestConfigurationAssignmentData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetAllGuestConfigurationAssignmentData(cancellationToken);
        }

        /// <summary>
        /// List all guest configuration assignments for a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments
        /// Operation Id: GuestConfigurationAssignments_RGList
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GuestConfigurationAssignmentData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroupResource).GetAllGuestConfigurationAssignmentDataAsync(cancellationToken);
        }

        /// <summary>
        /// List all guest configuration assignments for a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments
        /// Operation Id: GuestConfigurationAssignments_RGList
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GuestConfigurationAssignmentData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroupResource).GetAllGuestConfigurationAssignmentData(cancellationToken);
        }

        private static ArmResourceExtensionClient GetExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ArmResourceExtensionClient(client, scope);
            }
            );
        }

        /// <summary> Gets a collection of GuestConfigurationHcrpAssignmentResource in the ArmResource. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <returns> An object representing collection of GuestConfigurationHcrpAssignmentResource and their operations over a GuestConfigurationHcrpAssignmentResource. </returns>
        public static GuestConfigurationHcrpAssignmentCollection GetGuestConfigurationHcrpAssignments(this ArmClient client, ResourceIdentifier scope)
        {
            return GetExtensionClient(client, scope).GetGuestConfigurationHcrpAssignments();
        }

        /// <summary>
        /// Get information about a guest configuration assignment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}
        /// Operation Id: GuestConfigurationHCRPAssignments_Get
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<GuestConfigurationHcrpAssignmentResource>> GetGuestConfigurationHcrpAssignmentAsync(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return await client.GetGuestConfigurationHcrpAssignments(scope).GetAsync(guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get information about a guest configuration assignment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}
        /// Operation Id: GuestConfigurationHCRPAssignments_Get
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<GuestConfigurationHcrpAssignmentResource> GetGuestConfigurationHcrpAssignment(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return client.GetGuestConfigurationHcrpAssignments(scope).Get(guestConfigurationAssignmentName, cancellationToken);
        }

        /// <summary> Gets a collection of GuestConfigurationVmAssignmentResource in the ArmResource. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <returns> An object representing collection of GuestConfigurationVmAssignmentResource and their operations over a GuestConfigurationVmAssignmentResource. </returns>
        public static GuestConfigurationVmAssignmentCollection GetGuestConfigurationVmAssignments(this ArmClient client, ResourceIdentifier scope)
        {
            return GetExtensionClient(client, scope).GetGuestConfigurationVmAssignments();
        }

        /// <summary>
        /// Get information about a guest configuration assignment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}
        /// Operation Id: GuestConfigurationAssignments_Get
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<GuestConfigurationVmAssignmentResource>> GetGuestConfigurationVmAssignmentAsync(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return await client.GetGuestConfigurationVmAssignments(scope).GetAsync(guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get information about a guest configuration assignment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}
        /// Operation Id: GuestConfigurationAssignments_Get
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<GuestConfigurationVmAssignmentResource> GetGuestConfigurationVmAssignment(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return client.GetGuestConfigurationVmAssignments(scope).Get(guestConfigurationAssignmentName, cancellationToken);
        }

        /// <summary> Gets a collection of GuestConfigurationVmssAssignmentResource in the ArmResource. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <returns> An object representing collection of GuestConfigurationVmssAssignmentResource and their operations over a GuestConfigurationVmssAssignmentResource. </returns>
        public static GuestConfigurationVmssAssignmentCollection GetGuestConfigurationVmssAssignments(this ArmClient client, ResourceIdentifier scope)
        {
            return GetExtensionClient(client, scope).GetGuestConfigurationVmssAssignments();
        }

        /// <summary>
        /// Get information about a guest configuration assignment for VMSS
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}
        /// Operation Id: GuestConfigurationAssignmentsVMSS_Get
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="name"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<GuestConfigurationVmssAssignmentResource>> GetGuestConfigurationVmssAssignmentAsync(this ArmClient client, ResourceIdentifier scope, string name, CancellationToken cancellationToken = default)
        {
            return await client.GetGuestConfigurationVmssAssignments(scope).GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get information about a guest configuration assignment for VMSS
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}
        /// Operation Id: GuestConfigurationAssignmentsVMSS_Get
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="name"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<GuestConfigurationVmssAssignmentResource> GetGuestConfigurationVmssAssignment(this ArmClient client, ResourceIdentifier scope, string name, CancellationToken cancellationToken = default)
        {
            return client.GetGuestConfigurationVmssAssignments(scope).Get(name, cancellationToken);
        }
    }
}

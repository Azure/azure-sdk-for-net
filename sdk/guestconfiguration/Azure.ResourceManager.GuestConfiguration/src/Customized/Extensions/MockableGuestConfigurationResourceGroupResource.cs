// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.GuestConfiguration.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    [CodeGenSuppress("GetGuestConfigurationAssignmentsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationAssignments", typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationVmAssignments", typeof(string))]
    [CodeGenSuppress("GetGuestConfigurationHcrpAssignments", typeof(string))]
    [CodeGenSuppress("GetGuestConfigurationVmssAssignments", typeof(string))]
    public partial class MockableGuestConfigurationResourceGroupResource : ArmResource
    {
        /// <summary>
        /// List all guest configuration assignments for a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments
        /// Operation Id: GuestConfigurationAssignments_RGList
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GuestConfigurationAssignmentData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<GuestConfigurationAssignmentData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = GuestConfigurationVmAssignmentGuestConfigurationAssignmentsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetGuestConfigurationAssignmentQueryResults");
                scope.Start();
                try
                {
                    var response = await GuestConfigurationVmAssignmentGuestConfigurationAssignmentsRestClient.RGListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// List all guest configuration assignments for a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments
        /// Operation Id: GuestConfigurationAssignments_RGList
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GuestConfigurationAssignmentData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(CancellationToken cancellationToken = default)
        {
            Page<GuestConfigurationAssignmentData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = GuestConfigurationVmAssignmentGuestConfigurationAssignmentsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetGuestConfigurationAssignmentQueryResults");
                scope.Start();
                try
                {
                    var response = GuestConfigurationVmAssignmentGuestConfigurationAssignmentsRestClient.RGList(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }
    }
}

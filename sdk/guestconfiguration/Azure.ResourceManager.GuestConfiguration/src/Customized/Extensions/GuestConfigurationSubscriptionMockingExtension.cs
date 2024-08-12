// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.GuestConfiguration.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    [CodeGenSuppress("GetGuestConfigurationAssignmentsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationAssignments", typeof(CancellationToken))]
    public partial class MockableGuestConfigurationSubscriptionResource : ArmResource
    {
        /// <summary>
        /// List all guest configuration assignments for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments
        /// Operation Id: GuestConfigurationAssignments_SubscriptionList
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GuestConfigurationAssignmentData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<GuestConfigurationAssignmentData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = GuestConfigurationVmAssignmentGuestConfigurationAssignmentsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetGuestConfigurationAssignmentQueryResults");
                scope.Start();
                try
                {
                    var response = await GuestConfigurationVmAssignmentGuestConfigurationAssignmentsRestClient.SubscriptionListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// List all guest configuration assignments for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments
        /// Operation Id: GuestConfigurationAssignments_SubscriptionList
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GuestConfigurationAssignmentData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(CancellationToken cancellationToken = default)
        {
            Page<GuestConfigurationAssignmentData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = GuestConfigurationVmAssignmentGuestConfigurationAssignmentsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetGuestConfigurationAssignmentQueryResults");
                scope.Start();
                try
                {
                    var response = GuestConfigurationVmAssignmentGuestConfigurationAssignmentsRestClient.SubscriptionList(Id.SubscriptionId, cancellationToken: cancellationToken);
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

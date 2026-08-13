// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.GuestConfiguration.Mocking
{
    public partial class MockableGuestConfigurationSubscriptionResource
    {
        /// <summary> List all guest configuration assignments for a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(CancellationToken cancellationToken = default)
        {
            return SubscriptionList(cancellationToken);
        }

        /// <summary> List all guest configuration assignments for a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(CancellationToken cancellationToken = default)
        {
            return SubscriptionListAsync(cancellationToken);
        }

        /// <summary> List all guest configuration assignments for a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<GuestConfigurationVmAssignmentResource> GetGuestConfigurationVmAssignments(CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<GuestConfigurationAssignmentData, GuestConfigurationVmAssignmentResource>(
                SubscriptionList(cancellationToken),
                data => new GuestConfigurationVmAssignmentResource(Client, data));
        }

        /// <summary> List all guest configuration assignments for a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<GuestConfigurationVmAssignmentResource> GetGuestConfigurationVmAssignmentsAsync(CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<GuestConfigurationAssignmentData, GuestConfigurationVmAssignmentResource>(
                SubscriptionListAsync(cancellationToken),
                data => new GuestConfigurationVmAssignmentResource(Client, data));
        }
    }
}

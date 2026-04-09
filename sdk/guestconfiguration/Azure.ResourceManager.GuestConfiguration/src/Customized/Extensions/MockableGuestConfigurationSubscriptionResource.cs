// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Linq;
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
            return new PageableWrapper<GuestConfigurationVmAssignmentResource, GuestConfigurationAssignmentData>(
                GetGuestConfigurationVmAssignments(cancellationToken),
                resource => resource.Data);
        }

        /// <summary> List all guest configuration assignments for a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<GuestConfigurationVmAssignmentResource, GuestConfigurationAssignmentData>(
                GetGuestConfigurationVmAssignmentsAsync(cancellationToken),
                resource => resource.Data);
        }
    }
}

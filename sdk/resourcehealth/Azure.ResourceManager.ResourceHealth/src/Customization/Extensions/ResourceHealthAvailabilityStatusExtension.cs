// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    public static partial class ResourceHealthExtensions
    {
        /// <summary> Lists the all the children and its current health status for a parent resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatuses(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatuses(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the all the children and its current health status for a parent resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusesAsync(scope, filter, expand, cancellationToken);
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatus(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatus(scope, filter, expand, cancellationToken);
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return await GetMockableResourceHealthArmClient(client).GetAvailabilityStatusAsync(scope, filter, expand, cancellationToken).ConfigureAwait(false);
        }
    }
}

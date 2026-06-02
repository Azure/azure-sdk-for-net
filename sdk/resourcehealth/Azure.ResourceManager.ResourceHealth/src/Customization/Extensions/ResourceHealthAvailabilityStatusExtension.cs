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

            Pageable<ResourceHealthAvailabilityStatusData> statuses = GetAvailabilityStatusOfChildResource(client, scope, filter, expand, cancellationToken);
            return new PageableWrapper<ResourceHealthAvailabilityStatusData, ResourceHealthAvailabilityStatus>(statuses, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Lists the all the children and its current health status for a parent resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            AsyncPageable<ResourceHealthAvailabilityStatusData> statuses = GetAvailabilityStatusOfChildResourceAsync(client, scope, filter, expand, cancellationToken);
            return new AsyncPageableWrapper<ResourceHealthAvailabilityStatusData, ResourceHealthAvailabilityStatus>(statuses, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatus(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            AvailabilityStatusResource resource = GetMockableResourceHealthArmClient(client).GetAvailabilityStatus(scope);
            Response<AvailabilityStatusResource> response = resource.Get(filter, expand, cancellationToken);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            AvailabilityStatusResource resource = GetMockableResourceHealthArmClient(client).GetAvailabilityStatus(scope);
            Response<AvailabilityStatusResource> response = await resource.GetAsync(filter, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }
    }
}

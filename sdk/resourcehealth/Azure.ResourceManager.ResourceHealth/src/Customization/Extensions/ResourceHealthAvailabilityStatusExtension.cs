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
    // This file preserves the GA ArmClient availability status extension APIs.
    // These hidden compatibility methods forward to the mockable layer, which adapts
    // generated resource/data results back to the old ResourceHealthAvailabilityStatus model.
    public static partial class ResourceHealthExtensions
    {
        // Workaound for https://github.com/Azure/azure-sdk-for-net/issues/60100
        // TODO: Remove this method once the issue is fixed and the generator emits the correct method signature.
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
    }
}

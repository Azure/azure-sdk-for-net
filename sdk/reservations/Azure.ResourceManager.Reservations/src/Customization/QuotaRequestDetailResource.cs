// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed CreateResourceIdentifier for direct construction of this resource
// ID. The generated TypeSpec resource does not emit that helper, so this shim preserves the
// public API and keeps the canonical ARM ID format in one place.

using System;
using Azure.Core;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public partial class QuotaRequestDetailResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerId, AzureLocation location, Guid id)
            => new ResourceIdentifier($"/subscriptions/{subscriptionId}/providers/Microsoft.Capacity/resourceProviders/{providerId}/locations/{location}/serviceLimitsRequests/{id}");
    }
}

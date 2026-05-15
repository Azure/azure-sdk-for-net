// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

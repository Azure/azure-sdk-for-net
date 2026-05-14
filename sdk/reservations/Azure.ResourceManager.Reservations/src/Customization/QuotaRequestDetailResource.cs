// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed CreateResourceIdentifier(string subscriptionId, string providerId,
// AzureLocation location, Guid id). The new TypeSpec-based generator emits only the string-typed
// overload; this partial method preserves the legacy Guid API surface.

using System;
using Azure.Core;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public partial class QuotaRequestDetailResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerId, AzureLocation location, Guid id)
            => CreateResourceIdentifier(subscriptionId, providerId, location, id.ToString());
    }
}

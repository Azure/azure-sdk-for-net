// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter
{
    // Backward compatibility: TypeSpec now models ascLocation as AzureLocation, while the previous generated SDK also exposed string overloads.
    public partial class SubscriptionSecurityTaskResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ascLocation, string taskName)
            => CreateResourceIdentifier(subscriptionId, new AzureLocation(ascLocation), taskName);
    }
}

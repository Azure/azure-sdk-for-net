// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The CustomRolloutSpecification. </summary>
    public partial class CustomRolloutSpecification
    {
        /// <summary> Initializes a new instance of <see cref="CustomRolloutSpecification"/>. </summary>
        /// <param name="canary"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="canary"/> is null. </exception>
        public CustomRolloutSpecification(TrafficRegions canary)
        {
            Argument.AssertNotNull(canary, nameof(canary));

            Canary = canary;
            ReleaseScopes = new ChangeTrackingList<string>();
            ResourceTypeRegistrations = new ChangeTrackingList<ResourceTypeRegistrationData>();
        }
    }
}

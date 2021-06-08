// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    /// <summary>
    /// Options to be exposed in client options classes related to bearer token authorization challenge scenarios.
    /// </summary>
    public interface ISupportsTenantIdChallenges
    {
        /// <summary>
        ///  Enables tenant discovery through the authorization challenge when the client is configured to use a <see cref="TokenCredential"/>.
        /// When enabled, the client will attempt an initial un-authroized request to prompt a challenge in order to discover the correct tenant for the resource.
        /// </summary>
        public bool EnableTenantDiscovery { get; }
    }
}

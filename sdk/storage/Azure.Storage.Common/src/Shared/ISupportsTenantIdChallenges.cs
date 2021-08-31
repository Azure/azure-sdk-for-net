// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Shared
{
    /// <summary>
    /// Options to be exposed in client options classes related to bearer token authorization challenge scenarios.
    /// </summary>
    internal interface ISupportsTenantIdChallenges
    {
        /// <summary>
        ///  Enables tenant discovery through the authorization challenge when the client is configured to use a TokenCredential.
        /// When enabled, the client will attempt an initial un-authorized request to prompt a challenge in order to discover the correct tenant for the resource.
        /// </summary>
        public bool EnableTenantDiscovery { get; }
    }
}

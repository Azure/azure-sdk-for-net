// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity.Broker
{
    /// <summary>
    /// Temporary constants for Azure.Identity.Broker until Azure.Identity dependency is updated.
    /// </summary>
    internal static class TemporaryConstants
    {
        /// <summary>
        /// Redirect URI for macOS broker authentication.
        /// TODO: Remove this once Azure.Identity dependency includes Constants.MacBrokerRedirectUri
        /// </summary>
        internal const string MacBrokerRedirectUri = "msauth.com.msauth.unsignedapp://auth";
    }
}

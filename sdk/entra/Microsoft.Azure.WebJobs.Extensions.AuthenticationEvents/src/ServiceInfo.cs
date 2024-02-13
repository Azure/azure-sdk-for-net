// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// The services we support and their configuration.
    /// </summary>
    internal class ServiceInfo
    {
        /// <summary>
        /// The application id of the server side service.
        /// </summary>
        internal string ApplicationId { get; set; }

        /// <summary>
        /// The host of the OpenId connection.
        /// </summary>
        internal string OIDCMetadataUrl { get; set; }

        /// <summary>
        /// The tenant id of the service side service.
        /// </summary>
        internal string TenantId { get; set; }

        /// <summary>
        /// The v1 issuer string of the token.
        /// </summary>
        internal string TokenIssuerV1 { get; set; }

        /// <summary>
        /// the v2 issuer string of the token.
        /// </summary>
        internal string TokenIssuerV2 { get; set; }

        /// <summary>
        /// If definied by the library.
        /// Default is true.
        /// </summary>
        internal bool IsDefault { get; set; } = true;
    }
}

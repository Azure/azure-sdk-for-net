// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    /// <summary>
    ///  The set of options that can be specified to influence how security constraints are enforced by the client.
    /// </summary>
    public class SecurityOptions
    {
        /// <summary>
        /// Gets or sets a value determining if the client will allow confidential authentication schemes over non-TLS (non-HTTPS)
        /// protected connections. WARNING: Setting this value can compromise the security of accounts used by your application.
        /// </summary>
        public bool AllowInsecureConfidentialAuthenticationTransport { get; set; } = false;
    }
}

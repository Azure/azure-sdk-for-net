// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="VisualStudioCredential"/>.
    /// </summary>
    public class VisualStudioCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// The tenant ID the user will be authenticated to. If not specified the user will be authenticated to their home tenant.
        /// </summary>
        public string TenantId { get; set; }
    }
}

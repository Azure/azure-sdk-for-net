// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="EnvironmentCredential"/>.
    /// </summary>
    public class EnvironmentCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery
    {
        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="AzurePowerShellCredential"/>.
    /// </summary>
    public class AzurePowerShellCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// The Azure Active Directory tenant (directory) Id of the service principal
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The Powershell process timeout.
        /// </summary>
        public TimeSpan? PowerShellProcessTimeout { get; set; } = TimeSpan.FromSeconds(10);
    }
}

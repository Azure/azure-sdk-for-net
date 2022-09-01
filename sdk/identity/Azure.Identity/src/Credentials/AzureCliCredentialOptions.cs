// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="AzureCliCredential"/>.
    /// </summary>
    public class AzureCliCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// The Azure Active Directory tenant (directory) Id of the service principal
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The Cli process timeout.
        /// </summary>
        public TimeSpan? CliProcessTimeout { get; set; }
    }
}

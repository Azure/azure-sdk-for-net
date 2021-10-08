// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Exposes client options related to logging, telemetry and distributed tracing.
    /// </summary>
    public class TokenCredentialDiagnosticsOptions : DiagnosticsOptions
    {
        /// <summary>
        /// Enables logging sensitive data from the library. Enabling this will result in logging data that could be used to identify and compromise account security.
        /// This should only be enabled for debugging purposes, and care must be taken to protect log output when enabled.
        /// </summary>
        /// <remarks>
        /// Setting this property will not impact the logging of <see cref="Request"/> Content. To enable logging of <see cref="Request.Content"/>
        /// the <see cref="DiagnosticsOptions.IsLoggingContentEnabled"/> property must be set to <c>true</c>. Request content of credentials will in most cases
        /// also contain data which could compromise account security and should only be enabled on credentials for debugging purposes, and care must be taken to protect log
        /// output when enabled.
        /// </remarks>
        public bool IsExtendedUnsafeLoggingEnabled { get; set; }
    }
}

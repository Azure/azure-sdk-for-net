// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Azure.Core;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity
{
    /// <summary>
    /// Exposes client options related to logging, telemetry, and distributed tracing.
    /// </summary>
    public class TokenCredentialDiagnosticsOptions : DiagnosticsOptions
    {
        /// <summary>
        /// Constructs a new <see cref="TokenCredentialDiagnosticsOptions"/> instance.
        /// </summary>
        public TokenCredentialDiagnosticsOptions()
        {
        }

        [Experimental("SCME0002")]
        internal TokenCredentialDiagnosticsOptions(IConfigurationSection section)
            : base(section)
        {
            if (section is null)
            {
                return;
            }

            if (bool.TryParse(section[nameof(IsAccountIdentifierLoggingEnabled)], out bool isAccountIdentifierLoggingEnabled))
            {
                IsAccountIdentifierLoggingEnabled = isAccountIdentifierLoggingEnabled;
            }
        }

        /// <summary>
        /// If <c>true</c>, we try to log the account identifiers by parsing the received access token.
        ///  The account identifiers we try to log are:
        /// <list type="bullet">
        /// <item><description>The Application or Client Identifier</description></item>
        /// <item><description>User Principal Name</description></item>
        /// <item><description>Tenant Identifier</description></item>
        /// <item><description>Object Identifier of the authenticated user or application</description></item>
        /// </list>
        /// </summary>
        public bool IsAccountIdentifierLoggingEnabled { get; set; }
    }
}

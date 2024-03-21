// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Supported Azure token schema.</summary>
    internal enum SupportedTokenSchemaVersions
    {
        /// <summary>Version 1.</summary>
        [Description("1.0")]
        V1_0,

        /// <summary>Version 2.</summary>
        [Description("2.0")]
        V2_0
    }
}

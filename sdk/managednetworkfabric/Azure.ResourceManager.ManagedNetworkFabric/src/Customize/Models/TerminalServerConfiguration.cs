// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added required constructor parameters (primaryIPv4Prefix, secondaryIPv4Prefix).
    // This preserves the parameterless constructor from v1.1.2.
    public partial class TerminalServerConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="TerminalServerConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TerminalServerConfiguration() : this(default, default)
        {
        }
    }
}

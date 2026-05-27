// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Network and credentials configuration currently applied to terminal server. </summary>
    public partial class TerminalServerConfiguration
    {
        // Backward compatibility shim for the TypeSpec migration. The generated constructors are either
        // parameterless or internal, so this preserves the shipped convenience constructor. Removing it
        // would break callers that create terminal-server configuration with the required IPv4 prefixes.
        /// <summary> Initializes a new instance of <see cref="TerminalServerConfiguration"/>. </summary>
        /// <param name="primaryIPv4Prefix"> IPv4 Address Prefix. </param>
        /// <param name="secondaryIPv4Prefix"> Secondary IPv4 Address Prefix. </param>
        public TerminalServerConfiguration(string primaryIPv4Prefix, string secondaryIPv4Prefix)
            : this()
        {
            PrimaryIPv4Prefix = primaryIPv4Prefix;
            SecondaryIPv4Prefix = secondaryIPv4Prefix;
        }
    }
}

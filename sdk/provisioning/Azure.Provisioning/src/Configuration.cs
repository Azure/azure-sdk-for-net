// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning
{
    /// <summary>
    /// Configuration for the provisioning.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public class Configuration
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Whether to use prompt mode.
        /// </summary>
        public bool UseInteractiveMode { get; set; }
    }
}

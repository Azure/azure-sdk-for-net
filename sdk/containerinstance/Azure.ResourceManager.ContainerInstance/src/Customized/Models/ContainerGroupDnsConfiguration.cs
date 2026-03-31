// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for DnsConfiguration. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupDnsConfiguration : DnsConfiguration
    {
        internal ContainerGroupDnsConfiguration() : base(System.Array.Empty<string>()) { }
    }}

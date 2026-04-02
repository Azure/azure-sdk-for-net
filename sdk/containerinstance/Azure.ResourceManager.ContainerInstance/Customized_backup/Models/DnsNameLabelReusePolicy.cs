// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial struct DnsNameLabelReusePolicy
    {
        // backward-compat shim: old name was NoReuse, new is Noreuse
        /// <summary> No reuse. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsNameLabelReusePolicy NoReuse { get; } = new DnsNameLabelReusePolicy("Noreuse");
    }
}

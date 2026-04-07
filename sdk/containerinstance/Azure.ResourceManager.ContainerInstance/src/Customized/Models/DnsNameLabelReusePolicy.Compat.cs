// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat: NoReuse static property (old casing) renamed to Noreuse in TypeSpec migration.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public readonly partial struct DnsNameLabelReusePolicy
    {
        /// <summary> NoReuse (backward-compat alias for Noreuse). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsNameLabelReusePolicy NoReuse { get; } = new DnsNameLabelReusePolicy(NoreuseValue);
    }
}

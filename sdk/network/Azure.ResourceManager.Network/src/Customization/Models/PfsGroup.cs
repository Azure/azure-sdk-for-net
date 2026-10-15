// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct PfsGroup
    {
        // The pre-TypeSpec Pfs member serialized as "PFSMM". Its clientName now
        // restores that generated member, replacing the incorrect custom "PFS" value.
        // Keep the migration-era uppercase name as an alias of the same wire value.
        /// <inheritdoc cref="Pfs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use Pfs instead.")]
        public static PfsGroup PFSMM => Pfs;
    }
}

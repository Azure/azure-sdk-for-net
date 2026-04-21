// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward compatibility: v1.15.0 spelled the enum members `Nfsv3` and `Nfsv4`. The
    // TypeSpec spec follows the standard NFS spelling `NFSv3`/`NFSv4`, which the generator
    // emits as `NFSv3`/`NFSv4`. We expose the old casing as `[EditorBrowsable(Never)]`
    // forwarding members so existing user code continues to compile.
    public readonly partial struct ElasticProtocolType
    {
        /// <summary> Compatibility shim — formerly named <c>Nfsv3</c>; renamed to <c>NFSv3</c>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticProtocolType Nfsv3 => NFSv3;

        /// <summary> Compatibility shim — formerly named <c>Nfsv4</c>; renamed to <c>NFSv4</c>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticProtocolType Nfsv4 => NFSv4;
    }
}

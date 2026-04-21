// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct ElasticProtocolType
    {
        /// <summary> Compatibility shim for the former member name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticProtocolType Nfsv3 => NFSv3;

        /// <summary> Compatibility shim for the former member name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticProtocolType Nfsv4 => NFSv4;
    }
}

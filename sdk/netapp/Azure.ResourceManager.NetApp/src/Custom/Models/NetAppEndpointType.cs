// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct NetAppEndpointType
    {
        /// <summary> Source. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppEndpointType Source { get; } = Src;

        /// <summary> Destination. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppEndpointType Destination { get; } = Dst;
    }
}

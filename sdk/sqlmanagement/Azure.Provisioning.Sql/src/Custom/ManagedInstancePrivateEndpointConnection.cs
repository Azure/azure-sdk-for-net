// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Sql;

public partial class ManagedInstancePrivateEndpointConnection
{
    /// <summary>
    /// This property is obsolete and will be removed in a future release.
    /// Please use <see cref="PrivateLinkServiceConnectionState"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future release. Please use PrivateLinkServiceConnectionState instead.", false)]
    public ManagedInstancePrivateLinkServiceConnectionStateProperty ConnectionState
    {
        get => PrivateLinkServiceConnectionState;
        set => PrivateLinkServiceConnectionState = value;
    }

    // Preserve API versions shipped by the reflection-based generator that are not emitted
    // by the TypeSpec-based generator when targeting only the current stable API version.
    public static partial class ResourceVersions
    {
        /// <summary> API version "2021-11-01". </summary>
        public static readonly string V2021_11_01 = "2021-11-01";
        /// <summary> API version "2023-08-01". </summary>
        public static readonly string V2023_08_01 = "2023-08-01";
    }
}

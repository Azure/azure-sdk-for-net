// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedInstancePrivateEndpointConnectionData
    {
        /// <summary> Backward-compatible alias for <see cref="PrivateLinkServiceConnectionState"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.privateLinkServiceConnectionState")]
        public ManagedInstancePrivateLinkServiceConnectionStateProperty ConnectionState
        {
            get => PrivateLinkServiceConnectionState;
            set => PrivateLinkServiceConnectionState = value;
        }
    }
}

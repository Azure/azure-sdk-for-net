// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Search.Models
{
    public partial class SearchServicePrivateEndpointConnectionProperties
    {
        /// <summary> Describes the current state of an existing Azure Private Link service connection to the private endpoint. </summary>
        [WirePath("privateLinkServiceConnectionState")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServicePrivateLinkServiceConnectionState ConnectionState
        {
            get => PrivateLinkServiceConnectionState;
            set => PrivateLinkServiceConnectionState = value;
        }
    }
}

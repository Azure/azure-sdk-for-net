// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementPrivateEndpointConnectionData
    {
        // Alias for the flattened PrivateLinkServiceConnectionState property.
        // The generated name is too long; old SDK used ConnectionState.
        // Not spec-fixable: @@clientName on the inner properties model doesn't
        // propagate through flatten to rename the data-class property.

        /// <summary> A collection of information about the state of the connection between service consumer and provider. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.privateLinkServiceConnectionState")]
        public ApiManagementPrivateLinkServiceConnectionState ConnectionState
        {
            get => PrivateLinkServiceConnectionState;
            set => PrivateLinkServiceConnectionState = value;
        }
    }
}

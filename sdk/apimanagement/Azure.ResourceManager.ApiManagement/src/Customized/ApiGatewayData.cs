// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiGatewayData
    {
        // Deep path shortcut (properties.backend.subnet.id) converting string to ResourceIdentifier.
        // Not spec-fixable: @@flattenProperty only handles one level; this is three levels deep.

        /// <summary> The ARM ID of the subnet in which the backend systems are hosted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.backend.subnet.id")]
        public ResourceIdentifier SubnetId
        {
            get => BackendSubnetId is null ? default : new ResourceIdentifier(BackendSubnetId);
            set => BackendSubnetId = value?.ToString();
        }
    }
}

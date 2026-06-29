// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiGatewayData
    {
        // Generated name is BackendSubnetId (from flatten concatenation of backend.subnet.id).
        // Old SDK name was SubnetId. @@clientName on the inner model doesn't override the
        // flatten prefix. @@alternateType already provides ResourceIdentifier type.
        // Tracking: https://github.com/Azure/azure-sdk-for-net/issues/60079

        /// <summary> The ARM ID of the subnet in which the backend systems are hosted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.backend.subnet.id")]
        public ResourceIdentifier SubnetId
        {
            get => BackendSubnetId;
            set => BackendSubnetId = value;
        }
    }
}

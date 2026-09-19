// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    public partial class AvailablePrivateEndpointType
    {
        /// <summary> A unique identifier of the AvailablePrivateEndpoint Type resource. </summary>
        public new string Id => base.Id?.ToString();

        /// <summary> The resource type. </summary>
        public string Type => base.ResourceType.ToString();
    }
}

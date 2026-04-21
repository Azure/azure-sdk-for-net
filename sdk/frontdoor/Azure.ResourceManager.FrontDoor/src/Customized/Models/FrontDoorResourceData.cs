// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.FrontDoor.Models
{
    public partial class FrontDoorResourceData
    {
        /// <summary> Resource type. </summary>
        [WirePath("type")]
        public ResourceType? ResourceType => Type != null ? new ResourceType(Type) : null;
    }
}

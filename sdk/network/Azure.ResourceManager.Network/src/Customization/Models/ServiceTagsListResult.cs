// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    public partial class ServiceTagsListResult
    {
        /// <summary> The ID of the cloud. </summary>
        public new string Id => base.Id?.ToString();

        /// <summary> The resource type. </summary>
        public string Type => base.ResourceType.ToString();
    }
}

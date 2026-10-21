// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // Keep the mapped storage for generated constructors and serialization without exposing a post-1.15 API.
    public partial class NetworkChildResource
    {
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        [CodeGenMember("ETag")]
        internal virtual string ETag { get; }
    }
}

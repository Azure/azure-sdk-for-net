// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class NetworkChildResource
    {
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        [CodeGenMember("ETag")]
        public virtual string ETag { get; }
    }
}

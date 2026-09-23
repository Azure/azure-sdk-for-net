// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // Without this mapping, the resource-aware generator emits ETag? ETag. The custom member preserves the released
    // virtual string ETag API and makes generated constructors, parsers, and writers use the string representation.
    public partial class NetworkProxyResource
    {
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        [CodeGenMember("ETag")]
        public virtual string ETag { get; }
    }
}

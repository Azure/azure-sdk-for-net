// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ProviderResourceType. </summary>
    [CodeGenSerialization(nameof(ServiceTreeInfos), "serviceTreeInfos")]
    public partial class ProviderResourceType
    {
        // Preserve the released read-only collection after its removal from the specification.
        /// <summary> The service tree infos. </summary>
        public IReadOnlyList<ServiceTreeInfo> ServiceTreeInfos { get; } = new ChangeTrackingList<ServiceTreeInfo>();

        /// <summary> Gets the opt in headers. </summary>
        public OptInHeaderType? OptInHeaders
        {
            get => RequestHeaderOptions?.OptInHeaders;
        }
    }
}

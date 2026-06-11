// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.ResourceManager.OperationalInsights;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    // Backward-compat justification: ResourceData restores the old base type but does not carry ETag, so preserve the old ETag API and wire behavior here.
    [CodeGenSerialization(nameof(ETag), "etag")]
    public partial class OperationalInsightsWorkspacePatch
    {
        /// <summary> Resource Etag. </summary>
        [WirePath("etag")]
        public ETag? ETag { get; private set; }
    }
}

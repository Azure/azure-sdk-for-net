// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.ResourceManager.OperationalInsights;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    // Backward-compat justification: the GA workspace patch model exposed ETag as Azure.ETag instead of the generated string from AzureEntityResource.
    public partial class OperationalInsightsWorkspacePatch
    {
        /// <summary> Resource Etag. </summary>
        [WirePath("etag")]
        public new ETag? ETag => base.ETag is null ? default : new ETag(base.ETag);
    }
}

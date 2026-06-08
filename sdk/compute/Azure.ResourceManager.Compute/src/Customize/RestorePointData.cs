// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class RestorePointData
    {
        // Backward compatibility: the generated Compute-local property is named ExcludedDisks and uses
        // ApiEntityReference. Restore the old ExcludeDisks property with ARM common WritableSubResource.
        /// <summary> List of disk resource ids that the customer wishes to exclude from the restore point. </summary>
        public IList<WritableSubResource> ExcludeDisks => ExcludedDisks.ToWritableSubResources();
    }
}

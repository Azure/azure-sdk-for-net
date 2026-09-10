// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class RestorePointData
    {
        // Backward compatibility: the generated Compute-local property is named ExcludedDisks and uses
        // ComputeApiEntityReference. Restore the old ExcludeDisks property with ARM common WritableSubResource.
        /// <summary> List of disk resource ids that the customer wishes to exclude from the restore point. </summary>
        [Obsolete("This property is obsolete and no longer works. Use ExcludedDisks instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        // Compatibility placeholder only; this property is not wired to ExcludedDisks.
        public IList<WritableSubResource> ExcludeDisks { get; set; }
    }
}

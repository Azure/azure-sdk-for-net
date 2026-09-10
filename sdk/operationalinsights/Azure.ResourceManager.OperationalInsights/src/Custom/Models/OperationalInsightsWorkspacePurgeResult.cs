// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    // Backward-compat justification: the GA purge result retained obsolete Guid OperationId beside the string OperationStringId.
    public partial class OperationalInsightsWorkspacePurgeResult
    {
        /// <summary> Id to use when querying for status for a particular purge operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by ResourceUriString", false)]
        public Guid OperationId { get; }
    }
}

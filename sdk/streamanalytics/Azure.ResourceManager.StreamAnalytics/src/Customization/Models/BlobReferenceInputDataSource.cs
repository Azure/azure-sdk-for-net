// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.StreamAnalytics.Models
{
    /// <summary> Describes a blob input data source that contains reference data. </summary>
    public partial class BlobReferenceInputDataSource : ReferenceInputDataSource
    {
         /// <summary> The refresh interval of the blob input data source. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use FullSnapshotRefreshInterval instead.", false)]
        public string FullSnapshotRefreshRate { get; set; }
        /// <summary> The interval that the user generates a delta snapshot of this reference blob input data source. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use DeltaSnapshotRefreshInterval instead.", false)]
        public string DeltaSnapshotRefreshRate { get; set; }
    }
}

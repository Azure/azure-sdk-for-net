// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.StreamAnalytics.Models;

namespace Azure.ResourceManager.StreamAnalytics
{
    /// <summary> A class representing the StreamingJobOutput data model. </summary>
    public partial class StreamingJobOutputData : StreamAnalyticsSubResource
    {
        /// <summary> The time frame for filtering Stream Analytics job outputs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use TimeFrame instead.", false)]
        public DateTimeOffset? TimeWindow { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageTaskReportProperties
    {
        /// <summary> Backward-compatible alias for FinishTime. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? FinishedOn => DateTimeOffset.TryParse(FinishTime, out var result) ? result : null;

        /// <summary> Backward-compatible alias for StartTime. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? StartedOn => DateTimeOffset.TryParse(StartTime, out var result) ? result : null;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageTaskReportProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("finishTime")]
        public DateTimeOffset? FinishedOn { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("startTime")]
        public DateTimeOffset? StartedOn { get; }
    }
}

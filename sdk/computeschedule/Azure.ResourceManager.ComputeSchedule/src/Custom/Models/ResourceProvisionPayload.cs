// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ComputeSchedule.Models
{
    public partial class ResourceProvisionPayload
    {
        /// <summary> JSON object that contains VM properties that are common across all VMs in this batch. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, BinaryData> BaseProfile { get; } = null;

        /// <summary> JSON array that contains VM properties that should be overridden for each VM in the batch. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<IDictionary<string, BinaryData>> ResourceOverrides { get; } = null;
    }
}

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
        /// <summary> The base profile for the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, BinaryData> BaseProfile { get; set; }

        /// <summary> The resource overrides for the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<IDictionary<string, BinaryData>> ResourceOverrides { get; }
    }
}

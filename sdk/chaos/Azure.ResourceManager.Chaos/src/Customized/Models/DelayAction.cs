// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Chaos.Models
{
    public partial class DelayAction
    {
        /// <summary> Arm Id of the job created for this operation. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimeSpan Duration { get; set; }
    }
}

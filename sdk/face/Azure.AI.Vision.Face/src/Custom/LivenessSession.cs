// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Vision.Face
{
    public partial class LivenessSession
    {
        /// <summary> Denotes if the abuse monitoring feature was enabled during this session. </summary>
        public bool IsAbuseMonitoringEnabled { get; }
    }
}

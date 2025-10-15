// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Vision.Face
{
    public partial class AbuseMonitoringResult
    {
        /// <summary> Denotes if abuse detection triggered during this liveness attempt. </summary>
        public bool IsAbuseDetected { get; }
    }
}

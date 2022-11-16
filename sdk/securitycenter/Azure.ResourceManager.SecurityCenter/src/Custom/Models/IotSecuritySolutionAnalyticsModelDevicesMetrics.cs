// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> The IotSecuritySolutionAnalyticsModelDevicesMetrics. </summary>
    public partial class IotSecuritySolutionAnalyticsModelDevicesMetrics
    {
        /// <summary> Aggregation of IoT Security solution device alert metrics by date. </summary>
        [CodeGenMember("On")]
        public DateTimeOffset? Date { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class IotSecurityAggregatedAlertData
    {
        /// <summary> Date of detection. </summary>
        public DateTimeOffset? AggregatedOn => AggregatedDateUtc;
    }
}

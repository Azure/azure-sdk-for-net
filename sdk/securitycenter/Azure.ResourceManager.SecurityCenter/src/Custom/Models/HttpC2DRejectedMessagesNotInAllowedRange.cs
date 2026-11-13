// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The TypeSpec leaf uses Legacy.hierarchyBuilding to share TimeWindow/Allowlist properties through a base model; generated leaf classes therefore get only internal deserialization constructors, not the previous GA public constructor.
    public partial class HttpC2DRejectedMessagesNotInAllowedRange
    {
        /// <summary> Initializes a new instance of <see cref="HttpC2DRejectedMessagesNotInAllowedRange"/>. </summary>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        /// <param name="minThreshold"> The minimum threshold. </param>
        /// <param name="maxThreshold"> The maximum threshold. </param>
        /// <param name="timeWindowSize"> The time window size in iso8601 format. </param>
        public HttpC2DRejectedMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, TimeSpan timeWindowSize) : base(isEnabled, minThreshold, maxThreshold, timeWindowSize)
        {
            RuleType = "HttpC2DRejectedMessagesNotInAllowedRange";
        }
    }
}

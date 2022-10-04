// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Repeatability Headers.
    /// </summary>
    public class RepeatabilityHeaders
    {
        /// <summary>
        /// Repeatabiity Request Id.
        /// </summary>
        public Guid? RepeatabilityRequestId { get; set; }

        /// <summary>
        /// Repeatability First Sent.
        /// </summary>
        public DateTimeOffset? RepeatabilityFirstSent { get; set; }

        /// <summary>
        /// Function that returns RepeatabilityFirstSent in string format using the IMF-fixdate form of HTTP-date.
        /// </summary>
        /// <returns></returns>
        public string GetRepeatabilityFirstSentString() {
            return RepeatabilityFirstSent?.ToString("R");
        }

        /// <summary>
        /// Function that checks the validility of the repeatability header set.
        /// RepeatabilityHeader is valid when:
        ///  - both RepeatabilityRequestId and RepeatabilityFirstSent are null/not set or,
        ///  - both RepeatabilityRequestId and RepeatabilityFirstSent are set to non-null, non-default value.
        /// </summary>
        public Boolean IsValidRepeatabilityHeaders() {
            if (RepeatabilityRequestId == null && !RepeatabilityFirstSent.HasValue) return true;
            if (RepeatabilityRequestId != null && !RepeatabilityRequestId.Equals(Guid.Empty) && RepeatabilityFirstSent.HasValue && !RepeatabilityFirstSent.Equals(DateTimeOffset.MinValue) && !RepeatabilityFirstSent.Equals(DateTimeOffset.MaxValue)) return true;
            return false;
        }
    }
}

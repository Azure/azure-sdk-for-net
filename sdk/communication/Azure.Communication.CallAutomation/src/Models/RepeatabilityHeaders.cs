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
        public string RepeatabilityFirstSent { get; set; }

        /// <summary>
        /// Function that checks the validility of the repeatability header set.
        /// </summary>
        public Boolean IsValidRepeatabilityHeaders() {
            if ((RepeatabilityRequestId == null || RepeatabilityRequestId.Equals(Guid.Empty)) && String.IsNullOrEmpty(RepeatabilityFirstSent)) return true;
            if (RepeatabilityRequestId != null && !RepeatabilityRequestId.Equals(Guid.Empty) && !String.IsNullOrEmpty(RepeatabilityFirstSent)) return true;
            return false;
        }
    }
}

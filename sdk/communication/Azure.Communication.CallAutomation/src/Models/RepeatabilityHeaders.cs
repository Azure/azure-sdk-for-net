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
        /// If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same Repeatability-Request-Id and get back an appropriate response without the server executing the request multiple times. The value of the Repeatability-Request-Id is an opaque string representing a client-generated unique identifier for the request. It is a version 4 (random) UUID.
        /// </summary>
        public Guid? RepeatabilityRequestId { get; set; }

        /// <summary>
        /// If Repeatability-Request-ID header is specified, then Repeatability-First-Sent header must also be specified. The value should be the date and time at which the request was first created.
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

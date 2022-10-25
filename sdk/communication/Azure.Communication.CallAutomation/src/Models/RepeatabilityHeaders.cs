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
        /// The value of the Repeatability-Request-Id is an opaque string representing a client-generated unique identifier for the request. It is a version 4 (random) UUID.
        /// </summary>
        public Guid RepeatabilityRequestId { get; }

        /// <summary>
        /// The value should be the date and time at which the request was first created.
        /// </summary>
        public DateTimeOffset RepeatabilityFirstSent { get; }

        /// <summary>
        /// If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same RepeatabilityHeaders and get back an appropriate response without the server executing the request multiple times.
        /// </summary>
        /// <param name="repeatabilityRequestId"> The value of the Repeatability-Request-Id is an opaque string representing a client-generated unique identifier for the request. It is a version 4 (random) UUID. </param>
        /// <param name="repeatabilityFirstSent"> The value should be the date and time at which the request was first created.</param>
        public RepeatabilityHeaders(Guid repeatabilityRequestId, DateTimeOffset repeatabilityFirstSent) {
            RepeatabilityRequestId = repeatabilityRequestId;
            RepeatabilityFirstSent = repeatabilityFirstSent;
        }

        /// <summary>
        /// Function that returns RepeatabilityFirstSent in string format using the IMF-fixdate form of HTTP-date.
        /// </summary>
        /// <returns></returns>
        public string GetRepeatabilityFirstSentString() {
            return RepeatabilityFirstSent.ToString("R");
        }

        /// <summary>
        /// Function that checks the validity of the repeatability headers.
        /// RepeatabilityHeaders is only valid when RepeatabilityRequestId and RepeatabilityFirstSent are set to non-default value.
        /// </summary>
        public Boolean IsInvalidRepeatabilityHeaders() {
            return RepeatabilityRequestId.Equals(Guid.Empty) || RepeatabilityFirstSent.Equals(DateTimeOffset.MinValue) || RepeatabilityFirstSent.Equals(DateTimeOffset.MaxValue);
        }
    }
}

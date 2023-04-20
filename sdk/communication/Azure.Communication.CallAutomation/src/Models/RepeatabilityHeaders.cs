// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Repeatability Headers.
    /// </summary>
    internal class RepeatabilityHeaders
    {
        /// <summary>
        /// The value of the Repeatability-Request-Id is an opaque string representing a client-generated unique identifier for the request. It is a version 4 (random) UUID.
        /// </summary>
        public Guid RepeatabilityRequestId { get; }

        /// <summary>
        /// The value is the date and time at which the request was first created.
        /// </summary>
        public DateTimeOffset RepeatabilityFirstSent { get; }

        /// <summary>
        /// Function that returns RepeatabilityFirstSent in string format using the IMF-fixdate form of HTTP-date.
        /// </summary>
        /// <returns></returns>
        internal string GetRepeatabilityFirstSentString()
        {
            return RepeatabilityFirstSent.ToString("R");
        }

        public RepeatabilityHeaders()
        {
            RepeatabilityRequestId = Guid.NewGuid();
            RepeatabilityFirstSent = DateTimeOffset.Now;
        }
    }
}

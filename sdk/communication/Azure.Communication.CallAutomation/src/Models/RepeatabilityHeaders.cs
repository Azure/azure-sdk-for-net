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
        public Guid RepeatabilityRequestId { get; private set;  }

        /// <summary>
        /// The value should be the date and time at which the request was first created.
        /// </summary>
        public DateTimeOffset RepeatabilityFirstSent { get; private set; }

        /// <summary>
        /// Let SDK provide repeatability headers. This is also the default behaviour if repeatability header is not provided. If you would like to exlucde repeataiblity headers in the request, pass the NULL value for RepeatabilityHeaders class.
        /// </summary>
        public RepeatabilityHeaders()
        {
            RepeatabilityRequestId = default;
            RepeatabilityFirstSent = default;
        }

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
        internal string GetRepeatabilityFirstSentString()
        {
            return RepeatabilityFirstSent.ToString("R");
        }

        internal void GenerateIfRepeatabilityHeadersNotProvided()
        {
            if (RepeatabilityRequestId == default && RepeatabilityFirstSent == default)
            {
                RepeatabilityRequestId = Guid.NewGuid();
                RepeatabilityFirstSent = DateTimeOffset.Now;
            }
        }
    }
}

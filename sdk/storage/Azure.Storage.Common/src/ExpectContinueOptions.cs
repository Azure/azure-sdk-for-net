// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage
{
    /// <summary>
    /// Options for applying HTTP header <c>Expect: 100-continue</c> to PUT operations.
    /// </summary>
    public class ExpectContinueOptions
    {
        /// <summary>
        /// Mode for these options.
        /// </summary>
        public ExpectContinueMode Mode { get; set; }

        /// <summary>
        /// The minimum value of HTTP request Content-Length for applying expect-continue.
        /// </summary>
        public long? ContentLengthThreshold { get; set; }

        /// <summary>
        /// In mode <see cref="ExpectContinueMode.ApplyOnThrottle"/>, the time interval to apply the header
        /// after recieving a triggering error. The default time is one minute.
        /// </summary>
        public TimeSpan ThrottleInterval { get; set; } = TimeSpan.FromMinutes(1);
    }
}

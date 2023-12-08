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
        /// Mode for applying expect-continue to a PUT request.
        /// </summary>
        public enum ApplyHeaderMode
        {
            /// <summary>
            /// If no options are provided, this is the default behavior.
            /// <para>
            /// Expect-continue will not be applied until specific errors are encountered from the
            /// service, at which point they will be applied until a period of time after the last
            /// of those errors occured.
            /// </para>
            /// <para>
            /// Response codes that trigger this behavior are 429, 500, and 503.
            /// </para>
            /// </summary>
            ApplyOnThrottle = 0,

            /// <summary>
            /// Expect-continue will be applied regardless of recent error status. There may be
            /// some additionally defined thresholds for applying the header.
            /// </summary>
            On = 1,

            /// <summary>
            /// Expect-Continue will never be applied.
            /// </summary>
            Off = 2,
        }

        /// <summary>
        /// Mode for these options.
        /// </summary>
        public ApplyHeaderMode Mode { get; set; }

        /// <summary>
        /// The minimum value of HTTP request Content-Length for applying expect-continue.
        /// </summary>
        public long ContentLengthThreshold { get; set; }

        /// <summary>
        /// In mode <see cref="ApplyHeaderMode.ApplyOnThrottle"/>, the time interval to apply the header
        /// after recieving a triggering error. The default time is one minute.
        /// </summary>
        public TimeSpan ThrottleInterval { get; set; } = TimeSpan.FromMinutes(1);
    }
}

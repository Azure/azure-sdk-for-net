// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Configuration options for controlling function execution timeout behavior.
    /// </summary>
    public class JobHostFunctionTimeoutOptions
    {
        /// <summary>
        /// Gets or sets the timeout value. The default value is <see cref="TimeSpan.Zero"/>, which indicates no timeout.
        /// </summary>
        public TimeSpan Timeout { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Gets or sets a value indicating whether function invocations will timeout when
        /// a <see cref="Timeout"/> is specified and a debugger is attached. False by default.
        /// </summary>
        public bool TimeoutWhileDebugging { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an exception is thrown when a function timeout expires.
        /// </summary>
        public bool ThrowOnTimeout { get; set; }

        /// <summary>
        /// Gets or sets the amount of time to wait between canceling the timeout <see cref="CancellationToken"/> and throwing
        /// a FunctionTimeoutException. This gives functions time to perform any graceful shutdown. 
        /// Only applies if <see cref="ThrowOnTimeout"/> is true.
        /// </summary>
        public TimeSpan GracePeriod { get; set; }

        internal TimeoutAttribute ToAttribute()
        {
            return new TimeoutAttribute(Timeout.ToString())
            {
                TimeoutWhileDebugging = TimeoutWhileDebugging,
                ThrowOnTimeout = ThrowOnTimeout,
                GracePeriod = GracePeriod,
            };
        }
    }
}

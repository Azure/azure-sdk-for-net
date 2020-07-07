// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Timers
{
    /// <summary>
    /// Represents an unhandled exception handler.
    /// </summary>
    public interface IWebJobsExceptionHandler
    {
        /// <summary>
        /// Called when a timeout occurs.
        /// </summary>
        /// <returns>A Task.</returns>
        Task OnTimeoutExceptionAsync(ExceptionDispatchInfo exceptionInfo, TimeSpan timeoutGracePeriod);

        /// <summary>
        /// Implement this method to handle an unhandled exception.
        /// </summary>
        /// <param name="exceptionInfo">The <see cref="ExceptionDispatchInfo"/>.</param>
        Task OnUnhandledExceptionAsync(ExceptionDispatchInfo exceptionInfo);
    }
}

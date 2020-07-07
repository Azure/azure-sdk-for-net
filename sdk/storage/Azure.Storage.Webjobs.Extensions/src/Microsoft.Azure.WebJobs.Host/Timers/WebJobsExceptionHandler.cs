// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Timers
{
    /// <summary>
    /// Default implementation for <see cref="IWebJobsExceptionHandler"/>. 
    /// </summary>
    public class WebJobsExceptionHandler : IWebJobsExceptionHandler
    {
        private IHost _host;

        public WebJobsExceptionHandler(IHost host)
        {
            _host = host;
        }

        /// <inheritdoc />
        public async Task OnTimeoutExceptionAsync(ExceptionDispatchInfo exceptionInfo, TimeSpan timeoutGracePeriod)
        {
            try
            {
                // It's possible to have deadlocks while stopping. Make our best effort to stop 
                // before disposing. We'll give it three seconds to stop before moving on.
                Task stopTask = _host.StopAsync();
                Task delayTask = Task.Delay(TimeSpan.FromSeconds(3));

                await Task.WhenAny(stopTask, delayTask);
            }
            finally
            {
                // TODO: FACAVAL: This shouldn't be here! - review
                (_host as IDisposable)?.Dispose();
            }

            await Task.Delay(timeoutGracePeriod);
            await OnUnhandledExceptionAsync(exceptionInfo);
        }

        /// <inheritdoc />
        public Task OnUnhandledExceptionAsync(ExceptionDispatchInfo exceptionInfo)
        {
            Debug.Assert(exceptionInfo != null);

            Thread thread = new Thread(() =>
            {
                exceptionInfo.Throw();
            });
            thread.Start();
            thread.Join();

            return Task.FromResult(0);
        }
    }
}

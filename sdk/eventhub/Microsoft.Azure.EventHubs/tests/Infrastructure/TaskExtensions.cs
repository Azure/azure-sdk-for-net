// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///   The set of extension methods for the <see cref="Task" /> class.
    /// </summary>
    ///
    public static class TaskExtensions
    {
        /// <summary>
        ///   Executes a task with a timeout period, ignoring any result should the timeout period elapse.
        /// </summary>
        ///
        /// <param name="instance">The target of task execution.</param>
        /// <param name="timeout">The timeout period to allow for the <paramref name="instance"/> to complete.</param>
        /// <param name="cancellationToken">A cancellation token for signaling the <paramref name="instance" /> that a timeout has occurred and work should be stopped.</param>
        /// <param name="timeoutAction">An action to take on timeout; if not specified, a <see cref="TimeoutException" /> will be thrown.</param>
        ///
        /// <returns>A task to be resolved on completion or timeout.</returns>
        ///
        public static async Task WithTimeout(this Task instance, TimeSpan timeout, CancellationTokenSource cancellationToken = null, Action timeoutAction = null)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (instance.IsCompleted || Debugger.IsAttached)
            {
                return;
            }

            using (var timeoutTokenSource = new CancellationTokenSource())
            {
                if (instance == await Task.WhenAny(instance, Task.Delay(timeout, timeoutTokenSource.Token)))
                {
                    timeoutTokenSource.Cancel();
                    await instance;
                    return;
                }
            }

            // A timeout occurred.  Perform the needed actions to request cancellation, allow the task to
            // complete unobserved, and to signal the caller.
            cancellationToken?.Cancel();

            if (timeoutAction != null)
            {
                timeoutAction();
                return;
            }

            throw new TimeoutException();
        }

        /// <summary>
        ///   Executes a task with a timeout period, ignoring any result should the timeout period elapse.
        /// </summary>
        ///
        /// <typeparam name="T">The type of return value of the task.</typeparam>
        ///
        /// <param name="instance">The target of task execution.</param>
        /// <param name="timeout">The timeout period to allow for the <paramref name="instance"/> to complete.</param>
        /// <param name="cancellationToken">A cancellation token for signaling the <paramref name="instance" /> that a timeout has occurred and work should be stopped.</param>
        /// <param name="timeoutCallback">An action to take on timeout which is expected to produce the value of <typeparamref name="T"/> to be used as the result; if not specified, a <see cref="TimeoutException" /> will be thrown.</param>
        ///
        /// <returns>A task to be resolved on completion or timeout.</returns>
        ///
        public static async Task<T> WithTimeout<T>(this Task<T> instance, TimeSpan timeout, CancellationTokenSource cancellationToken = null, Func<T> timeoutCallback = null)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (instance.IsCompleted || Debugger.IsAttached)
            {
                return await instance;
            }

            using (var timeoutTokenSource = new CancellationTokenSource())
            {
                if (instance == await Task.WhenAny(instance, Task.Delay(timeout, timeoutTokenSource.Token)))
                {
                    timeoutTokenSource.Cancel();
                    return await instance;
                }
            }

            // A timeout occurred.  Perform the needed actions to request cancellation, allow the task to
            // complete unobserved, and to signal the caller.
            cancellationToken?.Cancel();

            if (timeoutCallback != null)
            {
                return timeoutCallback();
            }

            throw new TimeoutException();
        }
    }
}
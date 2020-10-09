// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Search.Documents.Batching
{
    /// <summary>
    /// Extensions to raise <see cref="Func{T, CancellationToken, Task}"/>
    /// events that wait for every Task to complete and throw every exception.
    /// </summary>
    internal static class AsyncEventExtensions
    {
        /// <summary>
        /// Wait for all tasks to be completed and throw every exception.
        /// </summary>
        /// <param name="tasks">The tasks to execute.</param>
        /// <returns>A Task representing completion of all handlers.</returns>
        private static async Task JoinAsync(IEnumerable<Task> tasks)
        {
            if (tasks == null) { return; }

            Task joined = Task.WhenAll(tasks);
            try
            {
                await joined.ConfigureAwait(false);
            }
            catch (Exception)
            {
                // awaiting will unwrap the AggregateException which we
                // don't want if there were multiple failures that should
                // be surfaced
                if (joined.Exception?.InnerExceptions?.Count > 1)
                {
                    throw joined.Exception;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Raise the event.
        /// </summary>
        /// <typeparam name="T">Type of the event argument.</typeparam>
        /// <param name="evt">The event to raise.</param>
        /// <param name="args">The event arguments.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A Task representing completion of all handlers.</returns>
        public static async Task RaiseAsync<T>(
            this Func<T, CancellationToken, Task> evt,
            T args,
            CancellationToken cancellationToken = default) =>
            await JoinAsync(
                evt?.GetInvocationList()?.Select(
                    f => (f as Func<T, CancellationToken, Task>)?.Invoke(args, cancellationToken)))
                .ConfigureAwait(false);

        /// <summary>
        /// Raise the event.
        /// </summary>
        /// <typeparam name="T">Type of the first event argument.</typeparam>
        /// <typeparam name="U">Type of the second event argument.</typeparam>
        /// <param name="evt">The event to raise.</param>
        /// <param name="first">The first event argument.</param>
        /// <param name="second">The second event argument.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A Task representing completion of all handlers.</returns>
        public static async Task RaiseAsync<T, U>(
            this Func<T, U, CancellationToken, Task> evt,
            T first,
            U second,
            CancellationToken cancellationToken = default) =>
            await JoinAsync(
                evt?.GetInvocationList()?.Select(
                    f => (f as Func<T, U, CancellationToken, Task>)?.Invoke(first, second, cancellationToken)))
                .ConfigureAwait(false);

        /// <summary>
        /// Raise the event.
        /// </summary>
        /// <typeparam name="T">Type of the first event argument.</typeparam>
        /// <typeparam name="U">Type of the second event argument.</typeparam>
        /// <typeparam name="V">Type of the third event argument.</typeparam>
        /// <param name="evt">The event to raise.</param>
        /// <param name="first">The first event argument.</param>
        /// <param name="second">The second event argument.</param>
        /// <param name="third">The third event argument.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A Task representing completion of all handlers.</returns>
        public static async Task RaiseAsync<T, U, V>(
            this Func<T, U, V, CancellationToken, Task> evt,
            T first,
            U second,
            V third,
            CancellationToken cancellationToken = default) =>
            await JoinAsync(
                evt?.GetInvocationList()?.Select(
                    f => (f as Func<T, U, V, CancellationToken, Task>)?.Invoke(first, second, third, cancellationToken)))
                .ConfigureAwait(false);
    }
}

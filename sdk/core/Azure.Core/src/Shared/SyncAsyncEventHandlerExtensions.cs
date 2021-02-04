// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Extensions for raising <see cref="SyncAsyncEventHandler{T}"/>
    /// events.
    /// </summary>
    internal static class SyncAsyncEventHandlerExtensions
    {
        /// <summary>
        /// Raise an <see cref="Azure.Core.SyncAsyncEventHandler{T}"/>
        /// event by executing each of the handlers sequentially (to avoid
        /// introducing accidental parallelism in customer code) and collecting
        /// any exceptions.
        /// </summary>
        /// <typeparam name="T">Type of the event arguments.</typeparam>
        /// <param name="eventHandler">The event's delegate.</param>
        /// <param name="e">
        /// An <see cref="SyncAsyncEventArgs"/> instance that contains the
        /// event data.
        /// </param>
        /// <param name="declaringTypeName">
        /// The name of the type declaring the event to construct a helpful
        /// exception message and distributed tracing span.
        /// </param>
        /// <param name="eventName">
        /// The name of the event to construct a helpful exception message and
        /// distributed tracing span.
        /// </param>
        /// <param name="clientDiagnostics">
        /// Client diagnostics to wrap all the handlers in a new distributed
        /// tracing span.
        /// </param>
        /// <returns>
        /// A task that represents running all of the event's handlers.
        /// </returns>
        /// <exception cref="AggregateException">
        /// An exception was thrown during the execution of at least one of the
        /// event's handlers.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="e"/>, <paramref name="declaringTypeName"/>,
        /// <paramref name="eventName"/>, or <paramref name="clientDiagnostics"/>
        /// are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="declaringTypeName"/> or
        /// <paramref name="eventName"/> are empty.
        /// </exception>
        public static async Task RaiseAsync<T>(
            this SyncAsyncEventHandler<T> eventHandler,
            T e,
            string declaringTypeName,
            string eventName,
            ClientDiagnostics clientDiagnostics)
            where T : SyncAsyncEventArgs
        {
            Argument.AssertNotNull(e, nameof(e));
            Argument.AssertNotNullOrEmpty(declaringTypeName, nameof(declaringTypeName));
            Argument.AssertNotNullOrEmpty(eventName, nameof(eventName));
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            // Get the invocation list, but return early if there's no work
            if (eventHandler == null) { return; }
            Delegate[] handlers = eventHandler.GetInvocationList();
            if (handlers == null || handlers.Length == 0) { return; }

            // Wrap handler invocation in a distributed tracing span so it's
            // easy for customers to track and measure
            string eventFullName = declaringTypeName + "." + eventName;
            using DiagnosticScope scope = clientDiagnostics.CreateScope(eventFullName);
            scope.Start();
            try
            {
                // Collect any exceptions raised by handlers
                List<Exception> failures = null;

                // Raise the handlers sequentially so we don't introduce any
                // unintentional parallelism in customer code
                foreach (Delegate handler in handlers)
                {
                    SyncAsyncEventHandler<T> azureHandler = (SyncAsyncEventHandler<T>)handler;
                    try
                    {
                        Task runHandlerTask = azureHandler(e);
                        // We can consider logging something when e.RunSynchronously
                        // is true, but runHandlerTask.IsComplete is false.
                        // (We'll not bother to check our tests because
                        // EnsureCompleted on the code path that raised the
                        // event will catch it for us.)
                        await runHandlerTask.ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        failures ??= new List<Exception>();
                        failures.Add(ex);
                    }
                }

                // Wrap any exceptions in an AggregateException
                if (failures?.Count > 0)
                {
                    // Include the event name in the exception for easier debugging
                    throw new AggregateException(
                        "Unhandled exception(s) thrown when raising the " + eventFullName + " event.",
                        failures);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}

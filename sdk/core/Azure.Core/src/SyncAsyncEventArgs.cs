// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure
{
    /// <summary>
    /// Provides data for <see cref="Azure.Core.SyncAsyncEventHandler{T}"/>
    /// events that can be invoked either synchronously or asynchronously.
    /// </summary>
    public class SyncAsyncEventArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether the event handler was invoked
        /// synchronously or asynchronously.  Please see
        /// <see cref="Azure.Core.SyncAsyncEventHandler{T}"/> for more details.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The same <see cref="Azure.Core.SyncAsyncEventHandler{T}"/>
        /// event can be raised from both synchronous and asynchronous code
        /// paths depending on whether you're calling sync or async methods on
        /// a client.  If you write an async handler but raise it from a sync
        /// method, the handler will be doing sync-over-async and may cause
        /// ThreadPool starvation.  See
        /// <see href="https://docs.microsoft.com/archive/blogs/vancem/diagnosing-net-core-threadpool-starvation-with-perfview-why-my-service-is-not-saturating-all-cores-or-seems-to-stall">
        /// Diagnosing .NET Core ThreadPool Starvation with PerfView</see> for
        /// a detailed explanation of how that can cause ThreadPool starvation
        /// and serious performance problems.
        /// </para>
        /// <para>
        /// You can use this <see cref="IsRunningSynchronously"/> property to check
        /// how the event is being raised and implement your handler
        /// accordingly.  Here's an example handler that's safe to invoke from
        /// both sync and async code paths.
        /// <code snippet="Snippet:Azure_Core_Samples_EventSamples_CombinedHandler">
        /// var client = new AlarmClient();
        /// client.Ring += async (SyncAsyncEventArgs e) =&gt;
        /// {
        ///     if (e.IsRunningSynchronously)
        ///     {
        ///         Console.WriteLine(&quot;Wake up!&quot;);
        ///     }
        ///     else
        ///     {
        ///         await Console.Out.WriteLineAsync(&quot;Wake up!&quot;);
        ///     }
        /// };
        ///
        /// client.Snooze(); // sync call that blocks
        /// await client.SnoozeAsync(); // async call that doesn&apos;t block
        /// </code>
        /// </para>
        /// </remarks>
        public bool IsRunningSynchronously { get; }

        /// <summary>
        /// Gets a cancellation token related to the original operation that
        /// raised the event.  It's important for your handler to pass this
        /// token along to any asynchronous or long-running synchronous
        /// operations that take a token so cancellation (via something like
        /// <code>
        /// new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token
        /// </code>
        /// for example) will correctly propagate.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SyncAsyncEventArgs"/>
        /// class.
        /// </summary>
        /// <param name="isRunningSynchronously">
        /// A value indicating whether the event handler was invoked
        /// synchronously or asynchronously.  Please see
        /// <see cref="Azure.Core.SyncAsyncEventHandler{T}"/> for more details.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token related to the original operation that raised
        /// the event.  It's important for your handler to pass this token
        /// along to any asynchronous or long-running synchronous operations
        /// that take a token so cancellation will correctly propagate.  The
        /// default value is <see cref="CancellationToken.None"/>.
        /// </param>
        public SyncAsyncEventArgs(bool isRunningSynchronously, CancellationToken cancellationToken = default)
            : base()
        {
            IsRunningSynchronously = isRunningSynchronously;
            CancellationToken = cancellationToken;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// Represents a method that can handle an event and execute either
    /// synchronously or asynchronously.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the event arguments deriving or equal to
    /// <see cref="SyncAsyncEventArgs"/>.
    /// </typeparam>
    /// <param name="e">
    /// An <see cref="SyncAsyncEventArgs"/> instance that contains the event
    /// data.
    /// </param>
    /// <returns>
    /// A task that represents the handler.  You can return
    /// <see cref="Task.CompletedTask"/> if implementing a sync handler.
    /// Please see the Remarks section for more details.
    /// </returns>
    /// <example>
    /// <para>
    /// If you're using the synchronous, blocking methods of a client (i.e.,
    /// methods without an Async suffix), they will raise events that require
    /// handlers to execute synchronously as well.  Even though the signature
    /// of your handler returns a <see cref="Task"/>, you should write regular
    /// sync code that blocks and return <see cref="Task.CompletedTask"/> when
    /// finished.
    /// <code snippet="Snippet:Azure_Core_Samples_EventSamples_SyncHandler">
    /// var client = new AlarmClient();
    /// client.Ring += (SyncAsyncEventArgs e) =&gt;
    /// {
    ///     Console.WriteLine(&quot;Wake up!&quot;);
    ///     return Task.CompletedTask;
    /// };
    ///
    /// client.Snooze();
    /// </code>
    /// If you need to call an async method from a synchronous event handler,
    /// you have two options.  You can use <see cref="Task.Run(Action)"/> to
    /// queue a task for execution on the ThreadPool without waiting on it to
    /// complete.  This "fire and forget" approach may not run before your
    /// handler finishes executing.  Be sure to understand
    /// <see href="https://docs.microsoft.com/dotnet/standard/parallel-programming/exception-handling-task-parallel-library">
    /// exception handling in the Task Parallel Library</see> to avoid
    /// unhandled exceptions tearing down your process.  If you absolutely need
    /// the async method to execute before returning from your handler, you can
    /// call <c>myAsyncTask.GetAwaiter().GetResult()</c>.  Please be aware
    /// this may cause ThreadPool starvation.  See the sync-over-async note in
    /// Remarks for more details.
    /// </para>
    /// <para>
    /// If you're using the asynchronous, non-blocking methods of a client
    /// (i.e., methods with an Async suffix), they will raise events that
    /// expect handlers to execute asynchronously.
    /// <code snippet="Snippet:Azure_Core_Samples_EventSamples_AsyncHandler">
    /// var client = new AlarmClient();
    /// client.Ring += async (SyncAsyncEventArgs e) =&gt;
    /// {
    ///     await Console.Out.WriteLineAsync(&quot;Wake up!&quot;);
    /// };
    ///
    /// await client.SnoozeAsync();
    /// </code>
    /// </para>
    /// <para>
    /// The same event can be raised from both synchronous and asynchronous
    /// code paths depending on whether you're calling sync or async methods
    /// on a client.  If you write an async handler but raise it from a sync
    /// method, the handler will be doing sync-over-async and may cause
    /// ThreadPool starvation.  See the note in Remarks for more details.  You
    /// should use the <see cref="SyncAsyncEventArgs.IsRunningSynchronously"/>
    /// property to check how the event is being raised and implement your
    /// handler accordingly.  Here's an example handler that's safe to invoke
    /// from both sync and async code paths.
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
    /// </example>
    /// <example>
    /// </example>
    /// <exception cref="AggregateException">
    /// Any exceptions thrown by an event handler will be wrapped in a single
    /// AggregateException and thrown from the code that raised the event.  You
    /// can check the <see cref="AggregateException.InnerExceptions"/> property
    /// to see the original exceptions thrown by your event handlers.
    /// AggregateException also provides
    /// <see href="https://docs.microsoft.com/en-us/archive/msdn-magazine/2009/brownfield/aggregating-exceptions">
    /// a number of helpful methods</see> like
    /// <see cref="AggregateException.Flatten"/> and
    /// <see cref="AggregateException.Handle(Func{Exception, bool})"/> to make
    /// complex failures easier to work with.
    /// <code snippet="Snippet:Azure_Core_Samples_EventSamples_Exceptions">
    /// var client = new AlarmClient();
    /// client.Ring += (SyncAsyncEventArgs e) =&gt;
    ///     throw new InvalidOperationException(&quot;Alarm unplugged.&quot;);
    ///
    /// try
    /// {
    ///     client.Snooze();
    /// }
    /// catch (AggregateException ex)
    /// {
    ///     ex.Handle(e =&gt; e is InvalidOperationException);
    ///     Console.WriteLine(&quot;Please switch to your backup alarm.&quot;);
    /// }
    /// </code>
    /// </exception>
    /// <remarks>
    /// <para>
    /// Most Azure client libraries for .NET offer both synchronous and
    /// asynchronous methods for calling Azure services.  You can distinguish
    /// the asynchronous methods by their Async suffix.  For example,
    /// BlobClient.Download and BlobClient.DownloadAsync make the same
    /// underlying REST call and only differ in whether they block.  We
    /// recommend using our async methods for new applications, but there are
    /// perfectly valid cases for using sync methods as well.  These dual
    /// method invocation semantics allow for flexibility, but require a little
    /// extra care when writing event handlers.
    /// </para>
    /// <para>
    /// The SyncAsyncEventHandler is a delegate used by events in Azure client
    /// libraries to represent an event handler that can be invoked from either
    /// sync or async code paths.  It takes event arguments deriving from
    /// <see cref="SyncAsyncEventArgs"/> that contain important information for
    /// writing your event handler:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="SyncAsyncEventArgs.CancellationToken"/> is a cancellation
    /// token related to the original operation that raised the event.  It's
    /// important for your handler to pass this token along to any asynchronous
    /// or long-running synchronous operations that take a token so cancellation
    /// (via something like
    /// <c>new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token</c>,
    /// for example) will correctly propagate.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="SyncAsyncEventArgs.IsRunningSynchronously"/> is a flag indicating
    /// whether your handler was invoked synchronously or asynchronously.  If
    /// you're calling sync methods on your client, you should use sync methods
    /// to implement your event handler (you can return
    /// <see cref="Task.CompletedTask"/>).  If you're calling async methods on
    /// your client, you should use async methods where possible to implement
    /// your event handler.  If you're not in control of how the client will be
    /// used or want to write safer code, you should check the
    /// <see cref="SyncAsyncEventArgs.IsRunningSynchronously"/> property and call
    /// either sync or async methods as directed.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Most events will customize the event data by deriving from
    /// <see cref="SyncAsyncEventArgs"/> and including details about what
    /// triggered the event or providing options to react.  Many times this
    /// will include a reference to the client that raised the event in case
    /// you need it for additional processing.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// When an event using SyncAsyncEventHandler is raised, the handlers will
    /// be executed sequentially to avoid introducing any unintended
    /// parallelism.  The event handlers will finish before returning control
    /// to the code path raising the event.  This means blocking for events
    /// raised synchronously and waiting for the returned <see cref="Task"/> to
    /// complete for events raised asynchronously.
    /// </para>
    /// <para>
    /// Any exceptions thrown from a handler will be wrapped in a single
    /// <see cref="AggregateException"/>.  If one handler throws an exception,
    /// it will not prevent other handlers from running.  This is also relevant
    /// for cancellation because all handlers are still raised if cancellation
    /// occurs.  You should both pass <see cref="SyncAsyncEventArgs.CancellationToken"/>
    /// to asynchronous or long-running synchronous operations and consider
    /// calling <see cref="System.Threading.CancellationToken.ThrowIfCancellationRequested"/>
    /// in compute heavy handlers.
    /// </para>
    /// <para>
    /// A <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#distributed-tracing">
    /// distributed tracing span</see> is wrapped around your handlers using
    /// the event name so you can see how long your handlers took to run,
    /// whether they made other calls to Azure services, and details about any
    /// exceptions that were thrown.
    /// </para>
    /// <para>
    /// Executing asynchronous code from a sync code path is commonly referred
    /// to as sync-over-async because you're getting sync behavior but still
    /// invoking all the async machinery. See
    /// <see href="https://docs.microsoft.com/archive/blogs/vancem/diagnosing-net-core-threadpool-starvation-with-perfview-why-my-service-is-not-saturating-all-cores-or-seems-to-stall">
    /// Diagnosing.NET Core ThreadPool Starvation with PerfView</see>
    /// for a detailed explanation of how that can cause serious performance
    /// problems.  We recommend you use the
    /// <see cref="SyncAsyncEventArgs.IsRunningSynchronously"/> flag to avoid
    /// ThreadPool starvation.
    /// </para>
    /// </remarks>
    public delegate Task SyncAsyncEventHandler<T>(T e)
        where T : SyncAsyncEventArgs;

    // NOTE: You should always use SyncAsyncEventHandlerExtensions.RaiseAsync
    // in Azure.Core's shared source to ensure consistent event handling
    // semantics.
}

# Azure.Core Event samples

**NOTE:** Samples in this file only apply to packages following the
[Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html).
The names of these packages usually start with `Azure`.

Most Azure client libraries for .NET offer both synchronous and asynchronous
methods for calling Azure services.  You can distinguish the asynchronous
methods by their `Async` suffix.  For example, `BlobClient.Download` and
`BlobClient.DownloadAsync` make the same underlying REST call and only differ in
whether they block.  We recommend using our async methods for new applications,
but there are perfectly valid cases for using sync methods as well.  These dual
method invocation semantics allow for flexibility, but require a little extra
care when writing event handlers.

The `SyncAsyncEventHandler` is a delegate used by events in Azure client
libraries to represent an event handler that can be invoked from either sync or
async code paths.  It takes event arguments deriving from `SyncAsyncEventArgs`
that contain important information for writing your event handler.

- `SyncAsyncEventArgs.CancellationToken` is a cancellation token related to the
  original operation that raised the event.  It's important for your handler to
  pass this token along to any asynchronous or long-running synchronous
  operations that take a token so cancellation (via something like
  `new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token`, for example)
  will correctly propagate.

- There is a `SyncAsyncEventArgs.IsRunningSynchronously` flag indicating whether your
  handler was invoked synchronously or asynchronously.  In general,

    - If you're calling sync methods on your client, you should use sync methods
      to implement your event handler.  You can return `Task.CompletedTask`.
    - If you're calling async methods on your client, you should use async
      methods where possible to implement your event handler.
    - If you're not in control of how the client will be used or want to write
      safer code, you should check the `IsRunningSynchronously` property and call
      either sync or async methods as directed.

  There are code examples of all three situations below to compare.  Please also
  see the note at the very end discussing the dangers of sync-over-async to
  understand the risks of not using the `IsRunningSynchronously` flag.

- Most events will customize the event data by deriving from `SyncAsyncEventArgs`
  and including details about what triggered the event or providing options to
  react.  Many times this will include a reference to the client that raised the
  event in case you need it for additional processing.

When an event using `SyncAsyncEventHandler` is raised, the handlers will be
executed sequentially to avoid introducing any unintended parallelism.  The
event handlers will finish before returning control to the code path raising the
event.  This means blocking for events raised synchronously and waiting for the
returned `Task` to complete for events raised asynchronously.

Any exceptions thrown from a handler will be wrapped in a single
`AggregateException`.  If one handler throws an exception, it will not prevent
other handlers from running.  This is also relevant for cancellation because all
handlers are still raised if cancellation occurs.  You should both pass
`SyncAsyncEventArgs.CancellationToken` to asynchronous or long-running
synchronous operations and consider calling `CancellationToken.ThrowIfCancellationRequested`
in compute heavy handlers.

A [distributed tracing span](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#distributed-tracing)
is wrapped around your handlers using the event name so you can see how long
your handlers took to run, whether they made other calls to Azure services, and
details about any exceptions that were thrown.

The rest of the code samples are using a fictitious `AlarmClient` to demonstrate
how to handle `SyncAsyncEventHandler` events.  There are `Snooze` and
`SnoozeAsync` methods that both raise a `Ring` event.

## Adding a synchronous event handler

If you're using the synchronous, blocking methods of a client (i.e., methods
without an `Async` suffix), they will raise events that require handlers to
execute synchronously as well.  Even though the signature of your handler
returns a `Task`, you should write regular sync code that blocks and return
`Task.CompletedTask` when finished.

```C# Snippet:Azure_Core_Samples_EventSamples_SyncHandler
var client = new AlarmClient();
client.Ring += (SyncAsyncEventArgs e) =>
{
    Console.WriteLine("Wake up!");
    return Task.CompletedTask;
};

client.Snooze();
```

If you need to call an async method from a synchronous event handler, you have
two options:

- You can use [`Task.Run`](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task.run)
  to queue a task for execution on the ThreadPool without waiting on it to
  complete.  This "fire and forget" approach may not run before your handler
  finishes executing.  Be sure to understand
  [exception handling in the Task Parallel Library](https://learn.microsoft.com/dotnet/standard/parallel-programming/exception-handling-task-parallel-library)
  to avoid unhandled exceptions tearing down your process.
- If you absolutely need the async method to execute before returning from your
  handler, you can call `myAsyncTask.GetAwaiter().GetResult()`.  Please be aware
  this may cause ThreadPool starvation.  See the sync-over-async note below for
  more details.

## Adding an asynchronous event handler

If you're using the asynchronous, non-blocking methods of a client (i.e.,
methods with an `Async` suffix), they will raise events that expect handlers to
execute asynchronously.

```C# Snippet:Azure_Core_Samples_EventSamples_AsyncHandler
var client = new AlarmClient();
client.Ring += async (SyncAsyncEventArgs e) =>
{
    await Console.Out.WriteLineAsync("Wake up!");
};

await client.SnoozeAsync();
```

## Handlers that can be called sync or async

The same event can be raised from both synchronous and asynchronous code paths
depending on whether you're calling sync or async methods on a client.  If you
write an async handler but raise it from a sync method, the handler will be
doing sync-over-async and may cause ThreadPool starvation.  See the note at the
bottom for more details.

You should use the `SyncAsyncEventArgs.IsRunningSynchronously` property to check how
the event is being raised and implement your handler accordingly.  Here's an
example handler that's safe to invoke from both sync and async code paths.

```C# Snippet:Azure_Core_Samples_EventSamples_CombinedHandler
var client = new AlarmClient();
client.Ring += async (SyncAsyncEventArgs e) =>
{
    if (e.IsRunningSynchronously)
    {
        Console.WriteLine("Wake up!");
    }
    else
    {
        await Console.Out.WriteLineAsync("Wake up!");
    }
};

client.Snooze(); // sync call that blocks
await client.SnoozeAsync(); // async call that doesn't block
```

## Handling exceptions

Any exceptions thrown by an event handler will be wrapped in a single
[`AggregateException`](https://learn.microsoft.com/dotnet/api/system.aggregateexception) and thrown from the code that raised the event.  You can check the
[`AggregateException.InnerExceptions`](https://learn.microsoft.com/dotnet/api/system.aggregateexception.innerexceptions)
property to see the original exceptions thrown by your event handlers.
`AggregateException` also provides
[a number of helpful methods](https://learn.microsoft.com/archive/msdn-magazine/2009/brownfield/aggregating-exceptions)
like `Flatten` and `Handle` to make complex failures easier to work with.

```C# Snippet:Azure_Core_Samples_EventSamples_Exceptions
var client = new AlarmClient();
client.Ring += (SyncAsyncEventArgs e) =>
    throw new InvalidOperationException("Alarm unplugged.");

try
{
    client.Snooze();
}
catch (AggregateException ex)
{
    ex.Handle(e => e is InvalidOperationException);
    Console.WriteLine("Please switch to your backup alarm.");
}
```

## Sync-over-async

Executing asynchronous code from a sync code path is commonly referred to as
sync-over-async because you're getting sync behavior but still invoking all the
async machinery.  See
[Diagnosing .NET Core ThreadPool Starvation with PerfView](https://learn.microsoft.com/archive/blogs/vancem/diagnosing-net-core-threadpool-starvation-with-perfview-why-my-service-is-not-saturating-all-cores-or-seems-to-stall)
for a detailed explanation of how that can cause serious performance problems.
We recommend you use the `SyncAsyncEventArgs.IsRunningSynchronously` flag to avoid
ThreadPool starvation.

But what about executing synchronous code on an async code path like the "Adding
a synchronous event handler" code sample above?  This is perfectly okay.  Behind
the scenes, we're effectively doing something like:

```C#
var task = InvokeHandler();
if (!task.IsCompleted)
{
    task.Wait();
}
```

Writing sync code in your handler will block before returning a completed `Task`
so there's no need to involve the ThreadPool to run your handler.

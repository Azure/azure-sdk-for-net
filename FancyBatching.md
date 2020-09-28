# Fancy Batching for Azure Cognitive Search

This is a high level description of the algorithm used for fancy batching in our
Azure Cognitive Search client libraries.

## Concepts

Let's introduce the major moving pieces:

- `SearchClient`: the regular client class with an `IndexDocuments` method that
   performs simple batching.  This is tied to a single Search index.  Our fancy
   batching will use one of these instances to handle all communication with the
   service.  _This has already GA'ed._
- `IndexDocumentsAction<T>`: The model type used for simple and fancy batching
  APIs representing an `Upload`, `Merge`, `MergeOrUpload`, or `Delete` of a
  document in a Search index.  _This has already GA'ed._
- `SearchIndexingBufferedSender`: This is our fancy batch "object."  It's not
  quite a client, not quite a model.  It's full of methods for adding index
  actions as fast as possible that mirror the convenience methods on
  `SearchClient`.  This type will be thread-safe so it can be slammed with
  index actions.
- Batch Publisher: We're going to have a "many producers, single publisher"
  model of interaction.  The publisher will not be publicly exposed but handle
  all the conceptual heavy lifting.
- PID Controllers: We want to automatically tune both the batch size, back
  pressure delay, and maybe retry delay.  I expect batch size will look like the
  standard approach to tuning a cache for misses and backpressure will look more
  like scaling queue size.

## Champion Scenarios

We're include updated champion scenarios to help frame the discussion.

#### I have 100,000 documents and I want to jam them into Search as quickly as possible.

    ```C#
    Product[] products = ...;
    SearchClient client = ...;

    // Add documents as fast as we can
    await using SearchIndexingBufferedSender<Product> indexer =
        client.CreateIndexingBufferedSender<Product>();
    await indexer.UploadDocumentsAsync(products);
    ```

#### I want batches submitted when they hit a max size.

    ```C#
    SearchClient client = ...;
    await using SearchIndexingBufferedSender<Product> indexer =
        client.CreateIndexingBufferedSender<Product>(
            new SearchIndexingBufferedSenderOptions<T>
            {
                AutoFlush = true, // <-- Default
                BatchSize = 512
            });
    await indexer.UploadDocumentsAsync(products);
    ```

#### I want to continue adding documents while the last batch is being submitted.

    ```C#
    // No difference from the above
    ```

#### I want explicit control over when batches are submitted.

    ```C#
    SearchClient client = ...;
    await using SearchIndexingBufferedSender<Product> indexer =
        client.CreateIndexingBufferedSender<Product>(
            new SearchIndexingBufferedSenderOptions<Product>
            {
                AutoFlush = false
            };

    await indexer.UploadDocumentsAsync(products.Take(5));
    await indexer.FlushAsync();

    await indexer.UploadDocumentsAsync(products.Skip(5).Take(5));
    await indexer.FlushAsync();
    ```

#### I want batches submitted after 5s of inactivity.

    ```C#
    SearchClient client = ...;
    await using SearchIndexingBufferedSender<Product> indexer =
        client.CreateIndexingBufferedSender<Product>(
            new SearchIndexingBufferedSenderOptions<T>
            {
                AutoFlush = true, // <-- Default
                AutoFlushInterval = TimeSpan.FromSeconds(5)
            });
    await indexer.UploadDocumentsAsync(products);
    ```

#### I want fine grained control of failure.

    ```C#
    SearchClient client = ...;
    await using SearchIndexingBufferedSender<Product> indexer =
        client.CreateIndexingBufferedSender<Product>();
    indexer.ActionFailedAsync +=
        (IndexDocumentsAction<Product> action,
         IndexingResult result,
         Exception exception,
         CancellationToken cancellationToken) =>
        {
            // Do work...
        };
    await indexer.UploadDocumentsAsync(products);
    ```

#### I want to checkpoint documents in case my process dies.

    ```C#
    SearchClient client = ...;
    await using SearchIndexingBufferedSender<Product> indexer =
        client.CreateIndexingBufferedSender<Product>();
    indexer.ActionAddedAsync +=
        (IndexDocumentsAction<Product> action,
         CancellationToken cancellationToken) =>
        {
            // Save action
        };
    indexer.ActionCompletedAsync +=
        (IndexDocumentsAction<Product> action,
         IndexingResult result,
         Exception exception,
         CancellationToken cancellationToken) =>
        {
            // Remove action
        };
    await indexer.UploadDocumentsAsync(products);
    ```

## Obtaining a SearchIndexingBufferedSender

- `SearchClient.CreateIndexingBufferedSender<T>(SearchIndexingBufferedSenderOptions<T>)`
    - Instantiates a new `SearchIndexingBufferedSender` tied to the current client.
    - The sender knows about the type of documents in its index
        - Could also be used with `SearchDocument` for unknown document types
    - The only way of obtaining a `SearchIndexingBufferedSender` (i.e., no .ctor)
    - `virtual` as the entry point for mocking fancy batching scenarios

## Configuring SearchIndexingBufferedSender

- `public class SearchIndexingBufferedSenderOptions<T> { ... }`

    - The generic parameter `T` is the type of documents the
    `SearchIndexingBufferedSender` will manage.  At one point this tyep had to
    be generic for the events, but now it's only for the `KeyFieldAccessor`
    which could be simplified to take `object` if we wanted to remove the type
    parameter here.

    - `bool AutoFlush { get; set; } = true;`

    - `TimeSpan? AutoFlushInterval { get; set; } = TimeSpan.FromSeconds(60);`

    - `CancellationToken AutoFlushIntervalCancellationToken { get; set; }`
    Specifically for when the auto flush happens from the interval elapsed timer.

    - `Func<T, string> KeyFieldAccessor { get; set; }`  Used to get the key of
    a document in case we need to associate errors with their inputs.  We'll use
    this first if provided.

    - `private int? BatchSize  { get; set; }` This will refer to the length of
    the JSON payload and not the number of documents.  We'll keep this private
    for the time being until we can provide reasonable tuning.

    - `private int RetryCount { get; set; } = 3;`  The number of manual retries
    we'll perform for failed documents.  We default to the same as Azure.Core
    which is 3 retries and keep it private for now while we think about how to
    expose the tuning of these parameters.

    - `private ResponseClassifier RetryClassifier { get; set; }`  This is the
    type we use in Azure.Core to customize Retry behavior.  It will basically
    retry on 422, 409, 503 status codes and the standard IOException and
    RequestFailedException with status code 0.

    - TODO: If we end up using PID Controllers for control stabilization, should
    we expose their gain configuration?

## Using SearchIndexingBufferedSender

- `public class SearchIndexingBufferedSender<T>`
    - Add Indexing Actions
        - `void DeleteDocuments(IEnumerable<T>, CancellationToken)`
        - `Task DeleteDocumentsAsync(IEnumerable<T>, CancellationToken)`
        - `void IndexDocuments(IndexDocumentsBatch<T>, CancellationToken)`
        - `Task IndexDocumentsAsync(IndexDocumentsBatch<T>, CancellationToken)`

            Note these are using a batch which we already have conveniences for
            building up.

        - `void MergeDocuments(IEnumerable<T>, CancellationToken)`
        - `Task MergeDocumentsAsync(IEnumerable<T>, CancellationToken)`
        - `void MergeOrUploadDocuments(IEnumerable, CancellationToken)`
        - `Task MergeOrUploadDocumentsAsync(IEnumerable<T>, CancellationToken)`
        - `void UploadDocuments(IEnumerable<T>, CancellationToken)`
        - `Task UploadDocumentsAsync(IEnumerable<T>, CancellationToken)`

        We're not returning any data from these operations.  They may submit
        something immediately or we might be waiting for a flush.

        The provided cancellation token will be used for any requests sent, any
        notifications raised, etc.  If a flush happens when the timer elapses,
        then we'll use the `AutoFlushIntervalCancellationToken` instead.  A 
        customer could reuse a token or link them together for fine grained
        control.

        We're also not including the `IndexDocumentsOptions` parameter because
        that currently only serves to configure exception behavior which we're
        doing exclusively through events.

        - Delete by key

            Add customization for "delete with just a key" scenarios for dynamic
            `SearchDocument`.  We're using extension methods in .NET but other
            languages might need to figure out a different approach.

            - `public static class SearchExtensions`
                - `static void DeleteDocuments(this SearchIndexingBufferedSender<SearchDocument>, string, IEnumerable<string>, CancellationToken)`
                - `static Task DeleteDocumentsAsync(this SearchIndexingBufferedSender<SearchDocument>, string, IEnumerable<string>, CancellationToken)`

    - `void Flush(CancellationToken)` and `Task FlushAsync(CancellationToken)`
        will manually flush any pending operations.  This could result in
        multiple requests.  If a request is already in progress, whatever's left
        will still be flushed on returning.

    - Notifications will be raised as events.
        - `event Action<IndexDocumentsAction<T>, CancellationToken> ActionAdded;`
        - `event Func<IndexDocumentsAction<T>, CancellationToken, Task> ActionAddedAsync;`
        - `event Action<IndexDocumentsAction<T>, CancellationToken> ActionSent;`
        - `event Func<IndexDocumentsAction<T>, CancellationToken, Task> ActionSentAsync;`
        - `event Action<IndexDocumentsAction<T>, CancellationToken> ActionCompleted;`
        - `event Func<IndexDocumentsAction<T>, IndexingResult, CancellationToken, Task> ActionCompletedAsync;`
        - `event Action<IndexDocumentsAction<T>, IndexingResult, Exception, CancellationToken> ActionFailed;`
        - `event Func<IndexDocumentsAction<T>, IndexingResult, Exception, CancellationToken, Task> ActionFailedAsync;`

            Either the `IndexingResult` or `Exception` may be null for failures
            depending on the type of failure and how it was surfaced.

            We'll raise either ActionCompleted or ActionFailed events.  You'd
            need to handle both to implement checkpointing.

            We will not throw any exceptions from the pipeline.  If a failure
            is triggered from a timer, there's no good way for a customer to
            catch it.  Everything will go through the notification events
            instead.  If we find the need for request level failures, we could
            add a `public event Action<Exception, CancellationToken> BatchFailed;`
            or similar.

            If a sync method like `Flush` is called, we'll raise the sync
            `ActionSent` event.  If an aysnc method like `FlushAsync` is called,
            we'll raise `ActionSentAsync`.  In the event of a timer elapsing,
            we will always raise the async event (note that we have a separate
            `CancellationToken` for this scenario too.)

            Because we can't throw once we've entered the publisher, we'll
            validate that the customer is handling the correct events before
            leaving their call stack.  This should be done from every "Add
            Action" method and `Flush` because handlers can be added and removed.

            - If I'm calling an async method, we need to make sure every async
            event has handlers if the corresponding sync event also has handlers.

            - If I'm calling a sync method, we need to make sure every sync
            event has handlers if the corresponding async event has handlers.

            - If I'm calling a sync method when `AutoFlush == true` and
            `AutoFlushInterval != null`, then I need to have parity between the
            handlers for both sync and async events since any immediate
            publishing will happen with a sync handler but an elapsed timer
            publish will happen with an async handler.

            When raising an async event, we'll collect all the returned tasks
            from each handler and `Task.WaitAll` to ensure they've all run to
            completion.

    - Cleaning up with `Dispose`

        - `void Dispose()` will call the publisher's `Dispose`, which does a
        blocking flush.

        - `Task DisposeAsync()` will call the publisher's `DisposeAsync`, which
        does a blocking flush.

        - We need the publisher to block on these particular calls because the
        application might exit as soon as `Dispose` returns.

        - We'll set `bool _disposed = true` and throw `ObjectDisposedException`
        if anyone tries to call any of our methods after disposing.  We'll also
        suppress the finalizer since no new work can take place.

        - We'll add a finalizer/destructor to check for any remaining work if
        we haven't been properly disposed.  In .NET, we can't safely throw an
        exception because it would tear down the process.  Instead we'll throw
        an exception that we immediately catch and swallow ourselves which still
        shows up in logs.  We'll also add a custom logging event for this
        specific scenario if anyone's listening to our event source.  We should
        consider writing an analyzer that warns about not calling `Dispose` on
        `SearchIndexingBufferedSender<T>`.

    - `private int PendingActionCount { get; set; }` This is the number of pending
        actions that haven't been submitted.  It's primarily intended to indicate
        whether the customer needs to apply backpressure higher up the stack.
        We're keeping it private for now while we think about how backpressure
        is exposed.

## Publishing

Most of the heavy lifting will live in an `internal class SearchIndexingPublisher<T>`.
If your language supports internal shared source, it might be good to factor this
into a Search-independent base class so these patterns can be easily reused.

- "Public" API

    These are what `SearchIndexingBufferedSender<T>` will use.

    - `void AddActions(IEnumerable<IndexDocumentsAction<T>>, CancellationToken)`
    - `Task AddActionsAsync(IEnumerable<IndexDocumentsAction<T>>, CancellationToken)`
    - `void Flush(CancellationToken)`
    - `Task FlushAsync(CancellationToken)`
    - `void Dispose(CancellationToken)`
    - `Task DisposeAsync(CancellationToken)`

    We'll also use properties/event handlers on the publisher as the backing
    store for the `SearchClient`, various options, and events.  This is primarily
    to avoid the publisher needing to reach back into the sender.

- Synchronization

    We need to make sure `SearchIndexingBufferedSender<T>` is thread-safe per
    our guidelines even though it has mutable state in the form of pending
    actions.

    We'll use a `ConcurrentQueue<IndexDocumentsAction<T>>` so we can add indexing
    actions from multiple threads without any issues.  `ConcurrentQueue` is
    implemented using `Interlocked` so it'll be lightweight.

    The Search service has undefined semantics around parallel requests updating
    the same document.  We're also far more likely to get throttled if we submit
    simultaneous requests.  We're going to restrict things so that only one
    thread at a time can send requests.

    Ideally we'd use `Interlocked.CompareExchange` as a lightweight gate to
    keep submissions on a single thread.  Unfortunately we need to block in case
    we're disposing which means we'll want to use a `Monitor`.  We should use
    `TryEnter` for non-blocking cases and return straight away.  It might also
    be worth keeping a `volatile` flag around so we can avoid interacting with
    the `Monitor` and use the "double check locking" technique when we don't
    need to block.

    We'll hold the `Monitor` for the duration of our submission(s).  This could
    be a very long time if the user keeps filling up the pending actions faster
    than we can submit batches.  We'll release the `Monitor` when we're out of
    full batches to submit - including when we're waiting for an auto-flush timer
    to elapse (it will have to flush again and re-acquire the `Monitor` if someone
    else hasn't beaten them to it).

- Validate
    - Ensure we have the right set of event handlers
    - Ensure we have a key field accessor
    - This needs to happen on the calling thread so we can raise exceptions

- Adding actions
    - Call Validate
    - The `AddActions`/`Async` methods will add everything to the pending
    actions queue.  It will create an object that includes the action, the
    action's key, the serialized JSON for the action, and a retry count.  We
    could consider tracking intermediate failures if we want to expose those in
    the future.  We'll also `Interlocked.Increment` an `int _pendingSize` with
    the size of serialized JSON that we can use for deciding when a batch is
    ready.

    - Validate the event handlers, raise the `ActionAdded`/`Async` events, and
    log the number of actions added

    - If `AutoFlush` is `true`
        - Call `TrySubmit` if the batch is full.  If `TrySubmit` returns `false`,
        we'll just return because someone else is submitting.  If `TrySubmit` is
        `true` and there's pending actions remaining we'll start the timer.

- Flushing
    - Call Validate
    - The `Flush`/`Async` methods will call `TrySubmit(flush: true)`.  If that returns `false`
    because another thread is already submitting, it will set a `_pendingFlush`
    flag to `true`.  After the submission is finished, we'd normally check
    whether another batch was ready to go.  If `_pendingFlush` is true, we'll
    submit any remaining actions even if they're not a full batch.

- Disposing
    - Call Validate
    - The `Dispose`/`DisposeAsync` methods will call `TrySubmit(block: true)` that
    block on submission.  We'll also set a `_disposed` flag on the publisher.
    Make sure calling `Dispose` from every sender thread works safely.

- `Task<bool> TrySubmitAsync(bool flush, bool block)`
    - First it will make sure it's the only thread currently submitting.  It will
    use `Monitor.TryEnter` when `block == false` and `Monitor.Enter` otherwise.
        - If we can't acquire the monitor, we'll return `false`.
        - If we do acquire the monitor, we'll check if we've been `_disposed` and
        return `false` (in case multiple `Dispose` calls were all waiting on the
        monitor).

    - Disable any existing timer

    - If `flush || (_pendingSize + _retrySize >= BatchSize)`
        - Fill the batch
        - `SubmitBatchAsync(batch, retryAttempt: 0)`
        - Set `_pendingFlush` to `false`

    - Call `Monitor.Exit` and return `true`

- `Task SubmitAsync(Batch<T> batch, int retryAttempt)`
    - Raise the ActionSent event for every item in batch
    - Send the filled batch as a request using our `SearchClient`.

    - If we get a 413 Payload Too Large
        - Keep adding items to fill a new batch so long as we're less than half
        the size of the payload.  Put everything else on the `_retryActions`
        queue but don't increment their `RetryCount`.  Call `SubmitAsync()`
        recursively without changing the `retryAttempt`.

    - If we get a 200 or 207
        - Associate errors with their actions from the batch
        - For each error
            - If the `RetryCount` is less than the max, increment the count and
            add it to the `_retryActions` queue
            - Else raise the `ActionFailed` event and log the failure
        - For each success
            - Raise the `ActionCompleted` event

    - If `_pendingFlush || (_pendingSize + _retrySize >= BatchSize)`
        - Fill the batch
        - If any of the errors were 503s
            - Add an exponential retry delay with hitter based on the number of
            attempts (follow your `RetryPolicy`'s implementation)
            - call `SubmitBatch(batch, retryAttempt + 1)`
        - Else call `SubmitBatch(batch, retryAttempt)`

- Filling Batches
    - A `Batch<T>` will consist of `N` wrapped actions and a `byte[]` JSON payload.
    - `FillFromQueue(batch, _retryActions) && FillFromQueue(batch, _pendingActions)`
    - return `batch`
    - `bool FillFromQueue(batch, queue)`
        - `while (queue.TryPeek(out action))`
            - If `action.Size > BatchSize`
                - Raise `ActionFailed` and log an error
            - Else if `(action.Size + batch.Size) <= BatchSize`
                - Dequeue and add to the batch
            - else return `false`
        - Return `true`
    - This prefers retrying actions before processing new actions
    - We're only filling until the next item would overflow.  No fancy knapsacking.
    - This also prefers keeping actions ordered.


- Associating Errors
    - Given a batch and an indexing response, we'll need to associate errors
    with actions.  This is nontrivial.
    - Walk through the items matching failures to their keys
        - If there are multiple items with the same key, we're not in a good spot.
        - For now we will have to rely on the service ordering (i.e., `Kth`
        response for a key corresponds to the `Kth` requested item)
        - We should follow up with the service team and consider failing any
        retries in batches with multiple actions for a single key.

- Getting a Key Field Accessor
    - If we haven't set a `_keyFieldAccessor`
        - Default to `Options.KeyFieldAccessor`
        - If that's null, use the logic in `FieldBuilder` to find the property
        in `T` with `IsKey=true` set and use its `Getter` as the accessor
        - If that didn't work (because `T` wasn't used with `FieldBuilder`),
        we'll get a `SearchIndexClient` from our `SearchClient` and make a
        `GetIndex` call to the service and compare properties to fields.  We
        will not cover cases like custom naming policies.
        - Set `_keyFieldAccessor` to the value we found
        - If `_keyFieldAccessor == null` throw an exception
    - Return `_keyFieldAccessor`

- Using the timer
    - Use `System.Threading.Timer` in .NET even though it only uses a sync
    callback.
    - Keep track of the `_timer` so it can be disabled later
    - Call `FlushAsync` from the elapsed callback (ignoring the `Task`) and pass
    `AutoFlushIntervalCancellationToken`

- Logging
    
    We need to add a custom `EventSource` for logging so folks can get deep
    insight into exactly what's happening and how they can tune the performance.
    I think we'll start with events for each notification, an event for unfinished
    work, an event for splitting a batch, etc.  We should also include data on
    the current batch size and possibly summary statistics.  Exactly what is
    needed will be clearer after we've done our own initial tuning.  We should
    also discuss this with the service to see what they log today.

### Controllers
- Batch size
- Submission delay
    - Maybe Retry with jitter instead of a controller?
- Add backpressure delay on producers?

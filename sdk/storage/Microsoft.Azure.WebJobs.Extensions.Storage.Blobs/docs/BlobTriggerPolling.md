# Blob trigger polling: log and container scan architecture

This document is a maintainer's companion to the polling BlobTrigger implementation in `Microsoft.Azure.WebJobs.Extensions.Storage.Blobs`. It explains the discovery pipeline, scan state machine, checkpointing, execution handoff, and the concurrency regressions that shaped the current algorithm.

The scan algorithm described here includes [PR #62764](https://github.com/Azure/azure-sdk-for-net/pull/62764), merged on October 6, 2026 in commit [`122c14354ecb`](https://github.com/Azure/azure-sdk-for-net/commit/122c14354ecba5f745d1bd58aaabc2671d2cde92). That is an implementation baseline, not a claim that a particular published package contains the fix. Keep this document aligned with the implementation when changing the scanner.

## Contents

- [Scope and essential mental model](#scope-and-essential-mental-model)
- [Quick answers to common questions](#quick-answers-to-common-questions)
- [Components and data flow](#components-and-data-flow)
- [Listener ownership, accounts, and scheduling](#listener-ownership-accounts-and-scheduling)
- [Storage Analytics log discovery](#storage-analytics-log-discovery)
- [Container scan state machine](#container-scan-state-machine)
- [Why multi-page scans need a time window](#why-multi-page-scans-need-a-time-window)
- [Why complete single-page listings are different](#why-complete-single-page-listings-are-different)
- [Checkpointing, overlap, and failures](#checkpointing-overlap-and-failures)
- [Receipts, queueing, and function execution](#receipts-queueing-and-function-execution)
- [Regression history and rationale](#regression-history-and-rationale)
- [Diagnostics and troubleshooting](#diagnostics-and-troubleshooting)
- [Maintainer checklist and test map](#maintainer-checklist-and-test-map)
- [Source map and references](#source-map-and-references)

## Scope and essential mental model

This polling architecture predates Azure Blob Storage Change Feed support. Classic Storage Analytics logs and container listings were the best available mechanisms for detecting blob changes in the absence of a dedicated change feed. Their scanning cost, latency, and concurrency complexity reflect those historical constraints, rather than an ideal design for a new trigger implementation today.

Event Grid was subsequently added as an alternative blob-trigger source for event-driven discovery, including workloads that need lower latency. Change feed has not been adopted as a blob-trigger source because its publication latency can still be relatively high: a durable change record may take a few minutes to become available. The [Storage guidance comparing change feed and storage events](https://learn.microsoft.com/azure/storage/blobs/storage-blob-change-feed#should-i-use-the-change-feed-or-storage-events) recommends storage events when applications need to react more quickly. Change feed's durability and replay model therefore do not make it a straightforward low-latency replacement for this trigger. This does not imply that the legacy polling strategy itself guarantees low latency.

The default `BlobTriggerSource.LogsAndContainerScan` strategy detects new and updated blobs through two complementary discovery paths:

1. **Best-effort, low-latency discovery:** Classic Azure Storage Analytics logs in the target account's `$logs` container identify writes without requiring a full container scan. When logs arrive promptly, this provides a low-latency path, but neither timely publication nor complete coverage is guaranteed.
2. **Correctness backstop:** Repeated, paged listings of the registered target containers discover blobs independently of log delivery. Scans are slower and inefficient because they traverse the container even when few blobs have changed, but their purpose is to ensure new and updated blobs are not missed when logs omit or delay a write.

These mechanisms deliberately separate responsiveness from completeness: logs improve detection latency when available, while repeated scans provide the backstop for discovering current blob state. Neither path alone supplies the combination this legacy trigger needs.

There is also an in-process notification path for writes reported by output bindings and for blobs that change while queued work is waiting.

All these paths produce **candidates for queueing**, not direct calls to user functions. Repeated discovery of the same blob is expected. A receipt keyed by function and blob ETag suppresses repeated queueing in the normal case; the queue then provides a separate execution and retry pipeline. This is not an exactly-once execution or every-version change-feed guarantee.

The scan backstop is about eventually discovering current blob state, assuming the blob remains observable and scanning continues successfully. It cannot recover an intermediate version overwritten before discovery or a blob created and deleted between scans. Likewise, "logs improve latency" describes their intended role, not a guarantee that logs always beat scanning: a small container scan can find a blob before delayed analytics logs arrive.

The critical scan invariant is:

> Do not advance the completed-sweep watermark beyond a concurrent write that the name-ordered listing could have missed.

For a multi-page sweep, the scanner conservatively bounds both candidate selection and watermark accumulation by the sweep's start time. For a complete single-page listing, it can notify the concurrent blobs present in the response and use their timestamps for the watermark.

The container scanner must remain useful without timely analytics logs. Logs can mask a broken scanner by eventually discovering blobs that listing has permanently excluded. "Eventually runs when logs flush" is not evidence that the listing path is correct.

This document does not describe the Event Grid delivery protocol, Functions host idle behavior, scale-controller implementation, or the full shared queue implementation. `BlobTriggerSource.EventGrid` bypasses creation of the shared poll/scan listener. Development storage also selects a different scanning strategy, so emulator-only tests do not establish correctness of the production hybrid state machine.

## Quick answers to common questions

| Question | Short answer and explanation |
| --- | --- |
| Why use these mechanisms, and why use both? | The design predates change feed. Logs are the best-effort responsive path; scans are the current-state correctness backstop. See [Scope](#scope-and-essential-mental-model). |
| Why not replace polling with change feed? | Durable change-feed publication can still take minutes. Event Grid is the added event-driven alternative. See [Scope](#scope-and-essential-mental-model). |
| How can a listed blob have a timestamp after `PollingStartTime`? | The host captures that time before sending the request; storage can observe a later write when serving it. See [Complete single-page listings](#why-complete-single-page-listings-are-different). |
| Does "seen" mean processed, and does "safe to notify" mean safe to advance the watermark? | No. Being present in a response, being selected for notification, being queued, and being executed are different stages. Notification and watermark safety are separate questions. See [Complete single-page listings](#why-complete-single-page-listings-are-different) and [Receipts](#receipts-queueing-and-function-execution). |
| Why do continuation pages need the sweep-start cutoff? | A later page's newer timestamp must not skip a write behind the name cursor. The next sweep can discover that write because its timestamp remains above the old watermark. See [Multi-page scans](#why-multi-page-scans-need-a-time-window). |
| Is a first page, or the last page of a sweep, a complete single-page listing? | Not necessarily. Both incoming and outgoing tokens must be absent. See [State transitions](#transitions-after-pr-62764). |
| What broke in 5.3.8, and why are both fixes needed? | Mismatched timestamp predicates could skip writes; empty terminal tokens could prevent new sweep windows. They are independent failures. See [Regression history](#regression-history-and-rationale). |
| Why deliberately rediscover equal timestamps, and why does restarting change behavior? | Timestamp overlap avoids precision gaps; receipts normally suppress repeated queueing of an unchanged ETag. Restart resets ephemeral sweep state but reloads the persisted lower bound. See [Checkpointing](#checkpointing-overlap-and-failures). |

## Components and data flow

```text
BlobListenerFactory
  |
  +-- shared, host-singleton discovery listener
  |     SharedBlobListener
  |       ScanBlobScanLogHybridPollingStrategy
  |         +-- container listings, one page per container per iteration
  |         +-- PollLogsStrategy -> BlobLogListener -> $logs
  |         +-- in-memory blob-written notifications and retries
  |                         |
  |                         v
  |                 registered BlobTriggerExecutor(s)
  |                   path-pattern check
  |                   current properties / ETag
  |                   receipt check / lease
  |                   enqueue BlobTriggerMessage
  |                   mark receipt complete
  |                         |
  +-- shared queue listener on every host instance
        SharedBlobQueueListener -> BlobQueueTriggerExecutor
          re-read current blob / validate ETag
          invoke registered function, or notify discovery of a newer ETag
          queue retry / poison handling
```

| Component | Responsibility |
| --- | --- |
| `BlobListenerFactory` | Wire target accounts, function registrations, singleton discovery, and scale-out queue consumption. |
| `SharedBlobListener` | Own the discovery strategy and its `TaskSeriesTimer`; prevent registration after startup. |
| `ScanBlobScanLogHybridPollingStrategy` | Coordinate logs, container pages, direct notifications, and scan checkpoints. |
| `ContainerScanInfo` | Hold registrations and in-memory state for one container's sweep. |
| `PollLogsStrategy` / `BlobLogListener` | Discover candidate paths from recent classic analytics log files. |
| `StorageBlobScanInfoManager` | Load and persist a completed-sweep timestamp in host storage. |
| `BlobTriggerExecutor` / `BlobReceiptManager` | Turn a candidate into version-specific queued work, with receipt-based deduplication. |
| `BlobTriggerQueueWriter` | Write the trigger message and notify the local queue watcher. |
| `BlobQueueTriggerExecutor` | Validate queued work against the current blob and invoke the function. |
| `SharedBlobQueueListenerFactory` | Configure queue execution parallelism, retries, and poison routing. |

## Listener ownership, accounts, and scheduling

### Discovery is singleton; execution scales out

`BlobListenerFactory` uses the host singleton scope `WebJobs.Internal.Blobs` so the shared poll/scan listener runs on one instance within that host's singleton coordination scope. Queue listeners run on all instances so function execution can scale out. This is not a storage-account-wide singleton shared by unrelated applications.

Within a host, multiple blob-trigger functions share the discovery listener. Each distinct container has one `ContainerScanInfo` and a collection of function registrations. Container equality is based on URI, not client object reference. Discovery reports candidates to the registered executors; each executor performs its own path-pattern match.

Registration and execution are not concurrency-safe. Complete registration before starting the listener. `SharedBlobListener` rejects registrations after startup.

### Host storage and target storage are different roles

| Data or operation | Account |
| --- | --- |
| List trigger blobs; read blob properties/content | Target account selected by the trigger's connection |
| Enable and inspect Storage Analytics logging; read `$logs` | Target account supplied during listener registration |
| Scan checkpoints and blob receipts | Host storage account |
| Host blob-trigger notification queue | Host storage account |
| Poison messages | Target account's queue service by default, with host-account fallback as supported by the factory |

The checkpoint path includes the **target** account name even though the checkpoint blob is stored in the **host** account.

The target may be different from `AzureWebJobsStorage`. Do not replace a target client with the host client just because receipts and queues use host storage. [PR #53464](https://github.com/Azure/azure-sdk-for-net/pull/53464) corrected target-client routing in this area.

### Actual polling cadence

The production hybrid strategy returns a ten-second wait after each completed iteration. Its first iteration starts immediately. Work duration, network latency, notification processing, and host scheduling add to that interval; it is not a ten-second delivery SLA.

Each hybrid iteration starts log discovery, drains its in-memory notification queue, launches a `PollAndNotify` task for each registered container, and waits for the discovery work. Different containers can therefore be processed concurrently. Notifications within a container's `PollAndNotify` are awaited sequentially.

Although `PollLogsStrategy.ExecuteAsync` returns a two-second wait for standalone use, the hybrid caller does not schedule that returned wait. **In the production hybrid strategy, both log and container discovery are driven by the outer ten-second loop.** There is no independent two-second analytics timer inside it.

The hybrid strategy constructs `PollLogsStrategy` with `performInitialScan: false`; the outer paged scanner handles container discovery. `PollLogsStrategy` also contains a standalone initial full-scan mode, but that background scan is not started by the production hybrid configuration.

`SharedBlobListener` selects `ScanContainersStrategy` for development storage. That strategy lists containers without this persisted, paged sweep state and returns a two-second wait. Keep its behavior separate when debugging or testing.

## Storage Analytics log discovery

At registration, `PollLogsStrategy` creates one `BlobLogListener` per target service-client identity. `BlobLogListener.CreateAsync` first attempts to enable classic analytics write logging. If write logging was disabled, `EnableLoggingAsync` enables it, sets a seven-day retention policy, and leaves metrics untouched.

The registration path catches the specific permission errors `AuthorizationPermissionMismatch`, `InsufficientAccountPermissions`, and `AuthorizationFailure`, logs `LoggingNotEnabledOnTargetAccount`, and leaves container scanning available. This does not mean every subsequent log-listing or download exception is swallowed. Other failures propagate through the listener/timer exception path.

On each log scan:

1. List `$logs` files under the current UTC hour's prefix and the preceding hour's prefix.
2. Select files whose `LogType` metadata contains `write`.
3. Skip log-file names already in the listener's in-memory cache.
4. Download and parse newly selected files as Storage Analytics log format 1.0.
5. Extract valid blob paths for recognized blob-write operations.
6. Filter candidates to registered containers and notify their function registrations.

The default `hoursWindow = 2` means two hourly prefixes, not an exact rolling 120-minute event cursor. The scanned-file cache is process-local, is not persisted, and clears when it exceeds 100,000 names. A restart or cache clearing can cause repeated discovery; receipts handle the normal duplicate case.

The implementation adds a file name to that cache before downloading and parsing the file. Cache membership therefore does not prove successful parsing or notification, and the cache is not a transactional acknowledgement or a durable retry cursor.

`StorageAnalyticsLogEntry.IsBlobWrite` recognizes `ClearPage`, `CopyBlob`, `CopyBlobDestination`, `PutBlob`, `PutBlockList`, `PutPage`, `SetBlobMetadata`, and `SetBlobProperties`. In particular, metadata changes are writes, not harmless changes that the trigger ignores. Invalid or unsupported log entries are skipped; malformed supported entries generate parser warnings.

The log path supplies blob paths, not a durable stream of blob versions. `BlobTriggerExecutor` reads the current properties and ETag when handling a candidate. Several writes can therefore collapse into processing the currently observable version.

Classic Storage Analytics logs are not Azure Monitor diagnostic logs, and they are not Event Grid events. They may be disabled, unavailable, incomplete, or delayed. Container scanning is the complementary mechanism for discovering current blobs despite missing or late analytics entries, not merely a one-time startup inventory.

## Container scan state machine

### Terms and state

A **poll** retrieves one listing page for a container. A **sweep** starts at the beginning of that container's name-ordered listing and ends when no next-page token remains. A sweep may span many polls.

| Field | Meaning | Lifetime |
| --- | --- | --- |
| `Registrations` | Trigger executors associated with the container | In memory |
| `ContinuationToken` | Opaque position used to request the next page; `null` means no active continuation | In memory |
| `PollingStartTime` | Host UTC time captured immediately before the first page request of a new sweep | In memory |
| `LastSweepCycleLatestModified` | Lower bound for selecting candidates, established by the last completed sweep | In memory; initialized from a persisted timestamp |
| `CurrentSweepCycleLatestModified` | Maximum eligible listing timestamp accumulated across this sweep | In memory |

For reasoning below:

```text
W = LastSweepCycleLatestModified
H = CurrentSweepCycleLatestModified
S = PollingStartTime
L = a listed blob's LastModified
```

`W` is a time watermark, not an ETag, a blob-name cursor, a creation-time cursor, or the time the last function succeeded. `ContinuationToken` supplies the name-listing position. The two cursors solve different problems.

### Listing budget and request shape

The scanner requests one page per registered container per hybrid iteration:

```text
pageSizeHint = 10,000 / number of distinct registered containers
```

This is an internal global listing budget divided by integer arithmetic, not a per-function execution limit. `pageSizeHint` is a hint; service limits and returned continuation tokens determine the actual page boundaries. Do not infer sweep completion from the number of values returned.

The request uses a flat `GetBlobsAsync` listing with `BlobTraits.None`, `BlobStates.None`, and `prefix: null`. It scans the whole registered container, not only the blob-name pattern of a particular function. The executor applies that pattern later. The timestamp test is performed locally; it does not make the storage service list only recently modified blobs.

Because pages are name-ordered rather than modification-time-ordered, even a container with few changes may require reading many pages each sweep.

### Transitions after PR #62764

This pseudocode captures the timestamp/token transitions; notification and persistence happen outside this method:

```text
incoming = normalize empty or null ContinuationToken to null

if incoming is null:
    S = host UTC now
    H = MinValue

page = request one page using incoming
completeListing = incoming is null AND page has no outgoing token

for each listed blob:
    L = blob.LastModified
    eligible = completeListing OR L <= S

    if eligible AND L > H:
        H = L

    if eligible AND L >= W:
        add blob client to candidates

ContinuationToken = normalize empty or null outgoing token to null

if page has no outgoing token AND H > W:
    W = H

return candidates
```

`PollingStartTime` and `H` reset only at the beginning of a sweep. `W` must remain unchanged while continuation pages are outstanding. At the end, `W` advances only if the accumulated safe timestamp exceeds it; an empty listing must not reset the completed watermark.

The ordering matters: `PollNewBlobsAsync` selects candidates and advances the **in-memory** `W` before returning them. `PollAndNotify` then attempts the candidate notifications and writes the **persisted** checkpoint afterward. Matching the eligibility predicates prevents the listing method from selecting a newer watermark while excluding those candidate timestamps; it does not make notification, queueing, and checkpointing atomic.

| Incoming token | Outgoing token | Classification | Eligible timestamps |
| --- | --- | --- | --- |
| Absent | Absent | Complete single-page listing | All listed timestamps |
| Absent | Present | First page of a multi-page sweep | `L <= S` |
| Present | Present | Intermediate page | `L <= S` |
| Present | Absent | Final page of a multi-page sweep | `L <= S` |

Both `null` and `""` mean absent. The outgoing marker is used to recognize completion; it is not enough to test only the incoming marker. In particular, a first page with a next token is **not** a complete listing.

The storage API can represent the end marker as `<NextMarker />`, exposed as `string.Empty` by the SDK. Token normalization must be symmetric when reading existing state and storing a response. Empty pages with a nonempty continuation token still belong to an unfinished sweep.

## Why multi-page scans need a time window

List Blobs is ordered lexicographically by name, not by `LastModified`. A paginated traversal is not a frozen container snapshot.

Consider this sweep:

```text
T0: sweep begins
T1: page 1 returns names A through C
T2: blob B2 is created (behind the current name cursor)
T3: blob E is modified
T4: page 2 returns names D through F, including E with LastModified = T3
```

The traversal did not see B2. If the scanner promotes the maximum observed timestamp, `T3`, to `W`, the next sweep rejects B2 because:

```text
B2.LastModified = T2 < W = T3
```

The same problem occurs when a blob already listed on page 1 is updated before later pages finish. The new ETag/version of that earlier name may be missed if a later page advances the watermark past its modification time.

The safe multi-page rule is to ignore timestamps after `S = T0` for both notification selection and watermark accumulation. Consequently, the finished sweep's watermark remains at or before `T0`. On a later sweep, B2 and E are still at or above that watermark and can become candidates once the new sweep's start time includes them.

For example, if the next sweep starts at `T5 > T3`, B2 has `W <= T0 < T2 <= T5` and passes both timestamp bounds when the fresh name traversal reaches it. E likewise passes with `L = T3`. They are deferred, not discarded: the next sweep starts the name traversal from the beginning with a new start time and accumulator, while the completed watermark remains conservative enough to admit them.

The implementation uses the maximum **observed eligible** timestamp, not an unconditional assignment of `W = S`. If no eligible timestamp advances `H`, the watermark stays put.

Notifying a returned post-start blob is not inherently unsafe: receipt checks can tolerate it. The current implementation chooses to defer such notification on multi-page sweeps. **Using its timestamp to skip unseen blobs is the actual correctness hazard.** If changing notification policy in the future, preserve the conservative multi-page watermark even if more candidates are notified.

Large-container latency follows from this design. A blob behind an active name cursor may require another sweep; the next sweep must also reach its name. Ten-second polling is not ten-second detection for every blob in a large container.

## Why complete single-page listings are different

`PollingStartTime` is captured on the host before issuing the request. It is not the timestamp of the storage service's response view.

```text
10:00:00: host captures S and issues the listing request
10:00:01: a blob is created or its metadata is updated
10:00:02: the complete listing response includes that blob with L = 10:00:01
```

The response already contains a concrete candidate. Rejecting it just because `L > S` discards useful information. Here, "the blob has been seen" means **present in the listing response**, not queued, executed, or successfully processed.

There are two separate questions:

| Question | Reasoning |
| --- | --- |
| May a returned candidate be notified? | Yes. The executor checks the current ETag and receipt. Repeated discovery of an unchanged ETag normally does not enqueue again. |
| May its timestamp advance the container-wide watermark? | Only if doing so does not skip writes missed by the traversal. A complete single-page response has no inter-page traversal gap. |

PR #62764 permits post-start timestamps for both notification and watermark accumulation **only when the incoming and outgoing tokens are both absent**. It does not apply this relaxation to the first page of a multi-page sweep or to the final page of a sweep.

This distinction removes the inter-request pagination race; it must not be described as a transaction locking the whole container. The optimization relies on normal complete-listing visibility and storage timestamp ordering. Writes and deletes can still race with later property reads, queueing, and function execution. A future change to service consistency assumptions or timestamp semantics requires revisiting the watermark argument, not simply broadening the test for "complete."

For a write occurring after the listing's view of the container, the intended argument is that its storage timestamp is at or above the maximum timestamp returned by that listing, so a later sweep can still select it. Inclusive comparison also admits later writes in the same timestamp bucket. In a multi-page sweep, that argument fails: a write behind the cursor can be older than a timestamp observed on a later page.

Nor is there unlimited host/storage clock-skew tolerance. `S` comes from the host while `L` comes from storage. A host clock behind storage can defer multi-page candidates until a later `S` includes them. Equality overlap protects timestamp precision boundaries, not arbitrary backdated timestamps or a non-monotonic service clock.

## Checkpointing, overlap, and failures

### Persisted state and restart behavior

`StorageBlobScanInfoManager` stores a JSON `LatestScan` timestamp in the host account's `azure-webjobs-hosts` container at:

```text
blobscaninfo/{hostId}/{targetAccountName}/{containerName}/scanInfo
```

The checkpoint is per host ID, target account, and container, not per function. At registration, a missing checkpoint initializes `W` to `DateTimeOffset.MinValue`, allowing an initial sweep to consider existing blobs. An existing checkpoint initializes `W` from its timestamp.

Continuation tokens, `S`, `H`, analytics-file caches, and in-memory notification queues are not persisted. After restart or singleton ownership transfer, a new sweep begins at the start of the container using the persisted lower bound. This can repeat discovery and is preferable to losing candidates. Adding a function to a container with an existing shared checkpoint does not by itself reset the scan to inventory all older blobs for that function.

The timestamp is serialized as `DateTimeOffset`; the manager's tests also cover older serialized timestamp formats. Treat format compatibility as part of restart correctness.

### Equality and the one-millisecond overlap

Storage timestamps have second-level precision. Two different writes can have the same `LastModified`, so the candidate test is:

```text
L >= W
```

not `L > W`. Re-listing the boundary timestamp catches writes within that timestamp bucket; the receipt separates distinct ETags.

After `PollAndNotify` has handled returned candidates, it persists the changed watermark slightly earlier:

```text
persisted LatestScan = selected checkpoint timestamp - 1 millisecond
```

This adds restart overlap. The checkpoint is not "now minus one millisecond"; it is derived from the safe listing watermark, or from a recorded failed notification as described below.

### Notification failures are not function failures

`BlobTriggerExecutor` can return an unsuccessful result when receipt creation or lease acquisition races with another actor. Strategies record unsuccessful notifications for retry. This is a failure to complete the candidate-to-queue handoff, not a failure returned by the eventual user function.

The hybrid path keeps a failure collection during an iteration. When persisting a changed watermark, `PollAndNotify` checks that collection and, if nonempty, selects the earliest current `LastModified` obtained from the failed blobs instead of blindly storing the new watermark. It then subtracts the one-millisecond overlap. The intent is to leave failed candidates discoverable after a restart.

The failure collection is shared among container tasks, while direct notifications and failed notifications use an in-memory queue. In this implementation, `ExecuteAsync` starts container tasks, runs the failure re-enqueue loop, and then awaits `Task.WhenAll(pollingTasks)`. Do not assume that loop sees failures added after an asynchronous task resumes. When modifying this code, inspect the exact ordering of task completion, failure recording, retry enqueueing, and checkpoint writes, as well as the thread safety of the shared collection. These operations are not one atomic transaction, and the existence of a "retry" comment is not proof of every failure interleaving.

`StorageBlobScanInfoManager.UpdateLatestScanAsync` currently treats persistence as best effort and suppresses write failures. A failed write can leave an older persisted lower bound, causing extra rediscovery on restart. Other listing failures, except the explicitly handled not-found container case, propagate. Do not infer that missing logs, authorization errors, checkpoint write errors, and function failures all have the same handling.

## Receipts, queueing, and function execution

### The discovery-to-queue handoff

For each candidate and function registration, `BlobTriggerExecutor`:

1. Checks the trigger's path pattern before making unnecessary property requests.
2. Reads current blob properties; if the blob no longer exists or has no ETag, returns success without queueing.
3. Looks up the receipt for the current ETag.
4. Returns success without queueing if that receipt is complete.
5. Creates an incomplete receipt if necessary and acquires its 30-second lease.
6. Rechecks the leased receipt to handle races.
7. Enqueues a message containing function ID, blob type, container, blob name, and ETag.
8. Marks the receipt complete and releases the lease.

The host account's receipt path is:

```text
azure-webjobs-hosts/
  blobreceipts/{hostId}/{functionId}/{ETag}/{containerName}/{blobName}
```

The ETag precedes the blob name because blob names can contain slashes.

**A completed receipt records completion of queueing, not successful user-function execution.** Log messages such as `BlobAlreadyProcessed` must be interpreted in that context.

Receipt checks suppress duplicate queueing of an unchanged blob/function version in the normal case. They do not make the queue send and receipt update atomic: for example, a failure after sending a message but before completing the receipt can permit another message. Queue delivery and function retries are also at least once. Applications still need idempotent processing where duplicate side effects matter.

### Consuming queued work

`BlobQueueTriggerExecutor` finds the function registration and reads the blob's current properties again.

| Condition | Action |
| --- | --- |
| Function registration no longer exists | Discard the message successfully. |
| Blob has been deleted | Discard the message successfully. |
| Blob ETag changed, polling strategy | Report a fast-path notification to the blob-written watcher and discard stale queued work. |
| Blob still has the queued ETag | Invoke the registered function. |

The ETag can still change after validation and before the function reads the blob; the code explicitly allows that race. This is current-state processing, not replay of an immutable historical version.

Function failures are handled by the queue execution pipeline. `BlobsOptions.PoisonBlobThreshold` defaults to five and maps to the queue's maximum dequeue count. Poison messages use `webjobs-blobtrigger-poison`. `MaxDegreeOfParallelism` maps to queue batching/concurrency, not the scanner's listing budget; dynamic concurrency may also affect execution through the shared queue listener.

`BlobCommittedAction` reports output-binding writes to `IBlobWrittenWatcher`. These notifications bypass the listing timestamp filter but still pass through `BlobTriggerExecutor` and receipt checks. They are process-local hints, not a broadcast to every app watching the account, and the scanner does not install an independent timer wakeup for them.

A metadata write changes the blob's observable version and can produce a new trigger candidate. Two applications that watch and stamp metadata on the same input illustrate the distinction between repeated discovery of the **same** ETag and genuine discovery of a **new** ETag. Receipt deduplication does not suppress a feedback loop that keeps modifying the triggering blob.

## Regression history and rationale

| Reference | Problem or change | Architectural lesson |
| --- | --- | --- |
| [Azure/azure-webjobs-sdk#3014](https://github.com/Azure/azure-webjobs-sdk/pull/3014) | Earlier proposal to constrain timestamp advancement during continuation pages. | The pagination/write race predates the current package layout. |
| [#53464](https://github.com/Azure/azure-sdk-for-net/pull/53464), merged December 2025 | Route discovery registration and log access through the specified target `BlobServiceClient`. | Host coordination storage and trigger data storage are different roles. |
| [#51030](https://github.com/Azure/azure-sdk-for-net/issues/51030) | Concurrent writes during a large listing could fall behind a watermark advanced by a later page. | The maximum timestamp in a mutable name-ordered traversal is not automatically a safe watermark. |
| [#53767](https://github.com/Azure/azure-sdk-for-net/pull/53767), merged February 2026 | Introduce the sweep-start time window and use `DateTimeOffset`; reported in package 5.3.8. | Keep multi-page watermark accumulation within the sweep's start-time window. |
| [#61660](https://github.com/Azure/azure-sdk-for-net/issues/61660) | An empty terminal marker prevented subsequent sweep initialization. | End-of-sweep and start-of-sweep token semantics must agree. |
| [#62763](https://github.com/Azure/azure-sdk-for-net/issues/62763) | A complete listing could reject post-start blobs while promoting their timestamps. | Candidate eligibility and watermark eligibility must not contradict each other. |
| [#62764](https://github.com/Azure/azure-sdk-for-net/pull/62764), merged October 2026 | Normalize tokens and relax the timestamp window only for complete single-page listings. | Fix both regressions without undoing target routing or multi-page protection. |

### Original concurrency bug: #51030

Before the sweep-start window, `H` could advance to any timestamp in a later page. A write behind the name cursor could then be below the completed watermark without ever having been seen. The example in [Why multi-page scans need a time window](#why-multi-page-scans-need-a-time-window) is the essential reproduction.

The misleading interpretation is "we found something modified later, so everything older must already have been processed." Name ordering and a changing container make that inference invalid.

### Complete-listing regression: #62763

The merged #53767 code used different eligibility rules:

```text
Accumulate H:
    L > H AND (incoming token is null OR L <= S)

Select candidate:
    L >= W AND L <= S
```

On the first page, a post-start timestamp could increase `H` even though the same blob failed candidate selection. If that page completed the listing, `W` immediately advanced to `H`.

This could exclude an unnotified blob below the new maximum on subsequent sweeps. A skipped blob exactly equal to `W` is still eligible under the inclusive lower-bound test once a later sweep's window includes it; not every skipped post-start blob is therefore permanently lost. The bug is that the watermark can pass **other** skipped writes. Delayed logs can hide the omission.

For a concrete example, let `S = 10:00:00` and let the complete response contain B with `L = 10:00:01` and C with `L = 10:00:02`. The old notification predicate rejects both, but the watermark becomes `10:00:02`. On a later sweep with a refreshed start time, B is below `W` and is skipped, while C can pass the equality check. With #62764, both are selected for notification in the complete response before a later scan could exclude B.

The inconsistency also affected the first page of a multi-page sweep, whose unrestricted timestamps could contaminate `H` even though later pages applied the time window. #62764 removes that first-page exception for unfinished listings.

The [original review discussion](https://github.com/Azure/azure-sdk-for-net/pull/53767#issuecomment-3509081358) called out the tradeoff between retaining concurrent first-page candidates and conservative timestamp advancement. The current fix uses the narrower, explicit condition that the entire listing fits in a single response.

### Empty-marker regression: #61660

The old code recognized `""` as the end of a sweep when advancing `W`, but only `null` as the start of the next sweep when resetting `S` and `H`:

```text
First sweep:       incoming null -> S initialized -> outgoing ""
Next poll:         incoming ""   -> S not reset
Later uploaded L:  L > original S -> rejected indefinitely
```

The host kept making listing calls, but they were effectively evaluated against the first sweep's window. Restarting reset the in-memory token and start time, which explains the report that blobs present before restart were processed while later uploads stopped triggering.

Both fixes are needed. Normalizing tokens alone does not repair the mismatched timestamp predicates. Fixing complete-listing notification alone does not reliably establish new sweep windows for empty markers.

### Production symptom and package distinction

The issue/PR reports describe an isolated Functions A/B comparison: worker extension 6.8.1 used host extension 5.3.7, while worker extension 6.8.2 used host extension 5.3.8. The earlier version detected the example blobs in seconds; the regressed version often waited several minutes for analytics log delivery. A local host build with both fixes restored listing-driven discovery.

Those observations are reported reproductions, not latency guarantees. The isolated worker package and the host WebJobs extension package are separate versioned components. When diagnosing a deployment, verify the actual host-side extension version rather than assuming a worker package version identifies the scanner implementation.

Downgrading to 5.3.7 may avoid the 5.3.8 regressions, but also restores exposure to the original multi-page race. #62764 preserves the multi-page window; it is not a wholesale rollback of #53767 or #53464.

## Diagnostics and troubleshooting

Discovery and receipt events use the `BlobListener` logging category. Container and receipt events are generally Debug; failure to enable target analytics logging is Warning. Enable appropriate logging before concluding that one path did not run.

| Event | What it establishes | What it does not establish |
| --- | --- | --- |
| `InitializedScanInfo` | Initial persisted lower bound loaded for the container | A full scan or function invocation has completed |
| `PollBlobContainer` | Candidate count, listing latency, request correlation, and whether another page exists | Actual function invocation count; the exact current `PollingStartTime` |
| `ScanBlobLogs` | Candidate paths found in logs for a registered container | Timely log publication or successful function execution |
| `LoggingNotEnabledOnTargetAccount` | Registration could not enable analytics logging with the supplied permissions | That container listing is disabled |
| `BlobDoesNotMatchPattern` | Candidate rejected by a particular function's path pattern | A container-wide scan error |
| `BlobHasNoETag` | Candidate no longer has an observable blob/ETag | A timestamp-window rejection |
| `BlobAlreadyProcessed` | The current function/ETag receipt is complete | The user function previously succeeded |
| `BlobMessageEnqueued` | Candidate reached the host trigger queue | Queue consumption or user-function completion |

`PollBlobContainer` logs `pollMinimumTime`, the completed watermark used for candidate selection, not `PollingStartTime`. Its candidate count is computed before executor pattern/receipt filtering. Correlate container `clientRequestId` with executor `PollId` and `ContainerScan` source; log candidates use `LogScan` source. Direct notifications through the hybrid strategy are labeled `ContainerScan` too, so that source label alone does not prove the candidate came from a listing response.

For missing or slow triggering:

1. Confirm polling versus Event Grid and the actual host extension version.
2. Confirm the target account/container and distinguish them from checkpoint/queue storage.
3. Determine whether candidates originate from container scans, logs, or direct notifications.
4. Inspect sweep completion and terminal token handling, including `""`.
5. Compare blob `LastModified` with the persisted lower bound; inspect in-memory `S`, `H`, and token state when needed.
6. Check whether a candidate was excluded by its function's pattern or receipt.
7. If enqueued, move the investigation to queue consumption, ETag changes, retries, and poison messages.

A burst of executions coinciding with a `$logs` flush can indicate that analytics is rescuing a broken listing path. A restart temporarily restoring triggering is consistent with a stuck in-memory sweep window. Neither symptom alone proves the root cause.

Deleting a receipt and changing a scan checkpoint address different layers. A deleted receipt will not force the scanner to rediscover a blob already below its time window. Moving a checkpoint backward creates scan overlap but does not itself force requeueing of a completed ETag receipt. Treat either operation as an intentional replay intervention, not a generic restart fix.

## Maintainer checklist and test map

### Invariants to preserve

1. Normalize empty and null terminal tokens consistently on both input and output.
2. Reset `S` and `H` once per new sweep, never per continuation page.
3. Advance `W` only after the last page, and only forward.
4. Do not let post-start timestamps contaminate any page of a multi-page sweep, including its first page.
5. Require both absent incoming and absent outgoing tokens before relaxing the time window.
6. Preserve inclusive timestamp overlap and receipt-based ETag filtering.
7. Keep target-account discovery separate from host-account coordination.
8. Account for asynchronous failures, cancellation, restart, and singleton handoff when reasoning about checkpoint safety.
9. Do not turn receipt completion into a claim of successful or exactly-once function execution.
10. Demonstrate container-scan behavior without timely log entries; a hybrid test can otherwise mask a scanner defect.

### Existing coverage

| Tests | Coverage |
| --- | --- |
| `ScanBlobScanLogHybridPollingStrategyTests.TestBlobListenerWithContainerBiggerThanThreshold` / `TestBlobListenerWithMultipleContainers` | Sweep continuation and budget sharing |
| `BlobPolling_IncludesPreviousBatch` | Same-timestamp boundary overlap |
| `RegisterAsync_InitializesWithScanInfoManager` / `ExecuteAsync_UpdatesScanInfoManager` | Loading and updating checkpoints |
| `ExecuteAsync_UpdatesScanInfo_WithEarliestFailure` | Checkpoint selection in the presence of failed notifications |
| `RegisterAsync_HandlesPermissionErrors` | Target analytics permission failures |
| `ExecuteAsync_PollNewBlobsAsync_ContinuationTokenUpdatedBlobs` | A post-start blob on a later page is deferred and discovered in a later sweep |
| `ExecuteAsync_CompleteListing_IncludesBlobsModifiedAfterPollStart` | #62764 complete-listing candidate selection |
| `ExecuteAsync_EmptyContinuationToken_StartsNewCycleAndFindsLaterBlobs` | #62764 empty terminal marker regression |
| `StorageBlobScanInfoManagerTests` | Missing checkpoints and timestamp serialization compatibility |
| `BlobTriggerExecutorTests` | Candidate filtering, receipt creation/lease races, enqueueing, and completion |
| `BlobReciptManagerTests` (existing spelling) | Receipt lease-conflict diagnostics; its test is currently ignored |
| `BlobQueueTriggerExecutorTests` | Deleted blobs, changed ETags, and function execution results |
| `BlobLogListenerTests` / `StorageAnalyticsLogParserTests` | Recognized write paths and analytics parsing |

These tests cover particular scenarios, not all possible concurrent interleavings. In particular, the clock-skew-named test must not be read as proof of arbitrary host/service skew tolerance.

When extending coverage, assert state transitions as well as candidate names: `S` changes between sweeps, `H` excludes post-start timestamps on the first multi-page page, `W` does not advance mid-sweep, and stored timestamps remain replay-safe after notification failures. Exercise null and empty terminal markers on single-page and multi-page sweeps, incoming empty state, empty pages with continuation, equal timestamps, writes behind the name cursor, restart after a partial sweep, and asynchronous failures across containers.

The existing scan tests use mocks, explicit timestamps, and some wall-clock delays. Prefer deterministic time control if changing that test infrastructure; do not use future timestamps and sleeps as evidence of real storage visibility or a transactional listing snapshot.

Targeted command from the repository root:

```powershell
dotnet test sdk\storage\Microsoft.Azure.WebJobs.Extensions.Storage.Blobs\tests\Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests.csproj --filter FullyQualifiedName~ScanBlobScanLogHybridPollingStrategyTests
```

Broaden the selection to the checkpoint, receipt, queue, or log tests when those surfaces change. Real-account integration scenarios matter because development storage selects a different strategy.

## Source map and references

| Area | Sources |
| --- | --- |
| Wiring and account ownership | [BlobListenerFactory](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/BlobListenerFactory.cs), [SharedBlobListenerFactory](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/SharedBlobListenerFactory.cs), [SharedBlobListener](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/SharedBlobListener.cs) |
| Hybrid scan algorithm | [ScanBlobScanLogHybridPollingStrategy](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/ScanBlobScanLogHybridPollingStrategy.cs), [ContainerScanInfo](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/ContainerScanInfo.cs) |
| Checkpoint persistence | [StorageBlobScanInfoManager](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/StorageBlobScanInfoManager.cs) |
| Analytics discovery | [PollLogsStrategy](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/PollLogsStrategy.cs), [BlobLogListener](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/BlobLogListener.cs), [StorageAnalyticsLogEntry](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/StorageAnalyticsLogEntry.cs), [StorageAnalyticsLogParser](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/StorageAnalyticsLogParser.cs) |
| Candidate-to-queue handoff | [BlobTriggerExecutor](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/BlobTriggerExecutor.cs), [BlobReceiptManager](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/BlobReceiptManager.cs), [BlobTriggerQueueWriter](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/BlobTriggerQueueWriter.cs), [BlobTriggerQueueWriterFactory](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/BlobTriggerQueueWriterFactory.cs) |
| Queue execution | [BlobQueueTriggerExecutor](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/BlobQueueTriggerExecutor.cs), [SharedBlobQueueListenerFactory](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/SharedBlobQueueListenerFactory.cs), [BlobsOptions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Config/BlobsOptions.cs) |
| Direct notifications and development storage | [BlobCommittedAction](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Bindings/BlobCommittedAction.cs), [ScanContainersStrategy](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/ScanContainersStrategy.cs) |
| Logging definitions | [Container scan events](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/ScanBlobScanLogHybridPollingStrategy.Logger.cs), [Log scan events](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/PollLogsStrategy.Logger.cs), [Receipt/queueing events](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Listeners/BlobTriggerExecutor.Logger.cs) |
| Scanner and checkpoint tests | [ScanBlobScanLogHybridPollingStrategyTests](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/tests/Listeners/ScanBlobScanLogHybridPollingStrategyTests.cs), [StorageBlobScanInfoManagerTests](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/tests/Listeners/StorageBlobScanInfoManagerTests.cs) |
| Queueing and execution tests | [BlobTriggerExecutorTests](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/tests/Listeners/BlobTriggerExecutorTests.cs), [BlobReciptManagerTests](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/tests/BlobReciptManagerTests.cs), [BlobQueueTriggerExecutorTests](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/tests/Listeners/BlobQueueTriggerExecutorTests.cs) |
| Analytics tests | [BlobLogListenerTests](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/tests/Listeners/BlobLogListenerTests.cs), [StorageAnalyticsLogParserTests](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/tests/Listeners/StorageAnalyticsLogParserTests.cs) |

For the public listening-strategy overview, see the [package README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/README.md). For deployment guidance, see [Azure Functions Blob trigger](https://learn.microsoft.com/azure/azure-functions/functions-bindings-storage-blob-trigger), [classic Storage Analytics logging](https://learn.microsoft.com/azure/storage/common/storage-analytics-logging), and [List Blobs](https://learn.microsoft.com/rest/api/storageservices/list-blobs).

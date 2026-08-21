# Reliable Telemetry for Short-Lived Applications

**Status:** Revision 3 — Phases 1–3 implemented, Phase 4 partially deferred
**Component:** `Azure.Monitor.OpenTelemetry.Exporter`
**Requested by:** .NET CLI team
**Reviewer:** Fable (r1 items 1–3 blocking, r2 item 1 blocking — all resolved)
**Date:** 2026-08-06

---

## 1. Problem

The .NET CLI team wants to instrument `dotnet` with the Azure Monitor OpenTelemetry Exporter. The
exporter is **network-first** and was designed for long-running services, so short-lived processes
lose telemetry. Five failures compound.

### 1.1 Nothing is exported before the process exits

| Signal  | Mechanism                       | Default interval |
| ------- | ------------------------------- | ---------------- |
| Traces  | `BatchActivityExportProcessor`  | 5 s              |
| Logs    | `BatchLogRecordExportProcessor` | 5 s              |
| Metrics | `PeriodicExportingMetricReader` | 60 s             |

A 2-second `dotnet build` reaches none of them. **The only export that ever happens is the one
triggered by shutdown.**

### 1.2 The shutdown export is an unbounded blocking POST

```csharp
// AzureMonitorTraceExporter.Export
exportResult = _transmitter.TrackAsync(..., async: false, ...).EnsureCompleted();
```

`AzureMonitorTransmitter.TrackAsync` issues the ingestion POST inline. Combined with the defaults,
the exit path is either slow or unbounded:

- `options.Retry.MaxRetries = 0` is forced, **but** `ClientOptions.Retry.NetworkTimeout` defaults to
  **100 seconds**.
- `TracerProvider.Shutdown()` defaults to `Timeout.Infinite`, so an explicit shutdown can block for
  the full 100 seconds.
- `TracerProviderSdk.Dispose()` calls `Processor.Shutdown(5000)`, which caps the wait at 5 seconds
  but still adds a full ingestion round trip to every invocation.

So a slow, throttled, or hung endpoint adds a round trip to every `dotnet` invocation, and can stall
exit for 5 seconds on `Dispose` or 100 seconds on an explicit `Shutdown`. Neither is acceptable for
a CLI.

### 1.3 If the process exits first, the batch is gone

Telemetry lives only in the batch processor's in-memory queue until a POST succeeds. Nothing durable
is written on the normal path. `Environment.Exit`, Ctrl-C, or a parent build system killing the
child drops it.

### 1.4 Data that reaches disk is never uploaded

Persistent storage is a **failure-only retry buffer**, not a spool.
`HttpPipelineHelper.ProcessTransmissionResult` writes a blob only when a POST *fails*, and
`TransmitFromStorageHandler` drains on a fixed timer:

```csharp
_transmitFromStorageTimer.Interval = 120000;   // first tick at t+120 s
int fileCount = 10;                            // 10 blobs/tick, one POST per blob
```

A CLI process never lives 120 seconds, so the drain **never runs**. The blob sits until
`FileBlobProvider`'s 2-day retention silently deletes it.

### 1.5 Leased blobs are stranded permanently

`FileBlob.OnTryLease` renames the file to `{name}.blob@{timestamp}.lock`. That name matches
**neither** `FileBlobProvider.OnGetBlobs`' `"*.blob"` filter **nor** `RemoveExpiredBlob`'s `.blob`
suffix check. The only thing that reclaims it is `OnMaintenanceEvent` — a **120-second timer**,
which never fires in a short-lived process.

So a CLI killed mid-drain strands that blob **forever**: invisible to future drains, never
retention-deleted, and counting against the 50 MB `DirectorySizeTracker` cap. Once that cap is hit,
`CreateFileBlob` returns `null` and **new telemetry is silently dropped** — there is no oldest-first
eviction.

> This bug exists **today** for any process that dies mid-retry, independent of this feature.
> Reclamation is a hard prerequisite for any disk-based design.

### 1.6 Net impact

For a short-lived process telemetry is either **lost outright** or **silently stranded on disk**, and
the only lever available today — blocking on the network at exit — is unacceptable for a CLI.

---

## 2. Goals / Non-goals

**Goals**

- No telemetry loss for short-lived processes.
- Effectively zero added process-exit latency — disk write only, no network on the exit path.
- Works out of the box: no configuration, no "short-lived process" detection.
- No new public API surface (`api/*.cs` unchanged).
- No behavioral regression for long-running services.

**Non-goals**

- A separate uploader binary or spawned background process.
- Changing the storage directory hashing (`StorageHelper` stays as-is; CLI process name is stable).
- Guaranteed delivery for a machine that runs the CLI exactly once and never again.

---

## 3. Proposed solution

**`Shutdown` and `Dispose` mean: persist to durable storage, then fire-and-forget the upload.**

The exit path performs one small file write and returns. The upload is kicked off but not waited on.
Correctness comes from the disk, not from winning a race with process exit — **a blob is deleted
only after HTTP 200**. The second half of the fix makes the on-disk backlog actually drain, so run
*N+1* uploads run *N*'s telemetry.

```
         today                                    proposed
  ┌──────────────────┐                    ┌──────────────────────┐
  │ Dispose()        │                    │ Dispose()            │
  │  └─ drain queue  │                    │  └─ open persist     │
  │      └─ POST ────┼─► 0–100 s          │      scope           │
  │         (blocks) │    or lost         │  └─ drain queue      │
  └──────────────────┘                    │      └─ write blob ──┼─► ~1 ms
                                          │  └─ close scope      │
                                          │  └─ drain (F&F) ─────┼─► opportunistic
                                          └──────────────────────┘
                                                     │
                                          next run drains backlog
```

### 3.1 The constraint that shapes the design

`BaseExportProcessor<T>.OnShutdown` **drains the queue and calls `exporter.Export(...)` before it
calls `exporter.Shutdown(...)`**. `BaseExportingMetricReader.OnShutdown` behaves the same way
(`Collect()` → then `exporter.Shutdown()`).

Consequence: **overriding the exporter alone is too late.** By the time
`AzureMonitorTraceExporter.OnShutdown` runs, the final blocking POST has already happened. The
persist-only switch must flip one level up, at the **processor / metric reader**, before
`base.OnShutdown` drains.

### 3.2 Scope of the semantic change — `Shutdown`/`Dispose` only

`ForceFlush` is **not** covered by default. Job hosts and Functions-style workloads call
`ForceFlush()` per invocation expecting *delivery*; converting those into disk writes drained by a
background timer would silently change telemetry freshness and introduce disk I/O where there was
none — with no opt-out, since this design has no configuration. A 2-second `dotnet build` never
calls `ForceFlush` anyway, so covering it adds nothing for the CLI.

Two `AppContext` switches (precedent: `StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName`;
not public API surface):

| Switch | Default | Purpose |
| ------ | ------- | ------- |
| `Azure.Monitor.OpenTelemetry.Exporter.PersistOnForceFlush` | `false` | Opt in to extending persist-only to `ForceFlush` |
| `Azure.Monitor.OpenTelemetry.Exporter.DisablePersistOnShutdown` | `false` | Support kill switch reverting to today's blocking shutdown |

### 3.3 The wait rule

"Honor the timeout OpenTelemetry passes" would reintroduce §1.2 verbatim, because
`TracerProvider.Shutdown()` defaults to `Timeout.Infinite`. The rule is:

> Wait `min(remainingTimeout, internalDrainBudget)` on the fire-and-forget drain, where
> `remainingTimeout` is the caller's timeout **less the time already consumed by `base.OnShutdown`
> draining to disk** — stopwatch around the base call.
> **`Timeout.Infinite` or a negative timeout means do not wait at all.**

`Shutdown()` (infinite) → exits immediately. `Dispose()` passes 5000 and a host calling
`Shutdown(5000)` gets a bounded wait, so graceful-shutdown windows are used rather than overshot.
The budget is consumed once: `AzureMonitorTransmitter.Dispose` waits only the remainder.

This rule governs waiting on a drain that is **backed by durable storage**. It does **not** apply to
the §4 fallback path.

### 3.4 Drain and disposal lifecycle

`DrainStorage` launches, then provider disposal tears down processor → exporter → transmitter →
`HttpPipeline`, killing the drain milliseconds in. Decision, stated explicitly rather than left to
chance:

- `AzureMonitorTransmitter` tracks `_inFlightDrain`. `Dispose(bool)` waits whatever remains of the
  budget from §3.3 before tearing down the pipeline.
- On the `Shutdown()` path that budget is **zero**, so teardown is immediate and the drain is
  aborted. `ObjectDisposedException` from the aborted drain is caught and logged at verbose — it is
  expected, not an error.
- **Documented consequence:** in-process drain of a process's *own* telemetry is opportunistic. Run
  *N+1* is the delivery mechanism. Hosts with a graceful-shutdown window do complete it.
- Because an aborted drain leaves a leased blob, §1.5 lease reclamation is a **hard prerequisite**.

### 3.5 Two independent budgets

| Budget | May be zero | Applies to |
| ------ | ----------- | ---------- |
| `internalDrainBudget` (§3.3) | **Yes** | Waiting on a drain whose data is already durable on disk |
| `internalFallbackPostBudget` | **No** (~3 s) | The §4 fallback POST, where the POST *is* the durability |

Conflating these is a data-loss bug: `Dispose()` resolves the drain budget to zero, and applying that
to the fallback would cancel the POST instantly with no disk behind it. Statsbeat is exempt from
both (Phase 2.8).

---

## 4. Implementation

### Phase 1 — Persist-only scope on the transmitter

1. Add internal members to `ITransmitter`: `IDisposable BeginPersistOnlyScope()` (ref-counted) and
   `void DrainStorage(int waitMilliseconds)`. Update `MockTransmitter`.
2. In `AzureMonitorTransmitter.TrackAsync`, when the scope count is > 0: serialize via
   `HttpPipelineHelper.GetSerializedContent`, call `PersistentStorageExtensions.SaveTelemetry`,
   return `Success`. No HTTP, no `TransmissionStateManager` back-off.
3. **Fallback path.** When `_fileBlobProvider` is `null` — `DisableOfflineStorage = true`, storage
   init failure, or a **read-only container filesystem** — the scope is a no-op and today's blocking
   POST runs. Cap it with a `CancellationTokenSource` on **`internalFallbackPostBudget`**, *not* the
   §3.3 drain budget, which is zero on the `Dispose()` path and would cancel the POST instantly.
   Today this path inherits the 100 s `NetworkTimeout` with no configuration lever.
4. **Stats accounting.** Persisted-via-scope counts as **retry, once**. A later successful drain
   counts as **success, once**. Do not also record success at persist time.

### Phase 2 — Flip the scope at the right moment *(depends on Phase 1)*

5. Internal `AzureMonitorBatchActivityExportProcessor : BatchActivityExportProcessor` overriding
   `OnShutdown` (and `OnForceFlush` only when the §3.2 switch is on): open scope → `base.*` → close
   scope → `DrainStorage(waitBudget)`. Stopwatch the `base` call per §3.3.
6. Logs: same overrides on the existing `LogFilteringProcessor` (already a
   `BatchLogRecordExportProcessor` subclass) plus a sibling for the non-filtering path.
7. Metrics: `AzureMonitorPeriodicExportingMetricReader : PeriodicExportingMetricReader` overriding
   `OnShutdown` only. `MetricReader.OnCollect` cannot distinguish `ForceFlush` from the periodic
   tick — **documented limitation**, and moot given §3.2.
8. Swap construction sites: `src/ExporterRegistrationHostedService.cs`,
   `src/AzureMonitorExporterExtensions.cs`, `src/OpenTelemetryBuilderExtensions.cs`.
   **Exclude `AzureMonitorStatsbeat.BuildMeterProvider`** — it already sets
   `DisableOfflineStorage = true` with a separate connection string, so persist-only is a no-op
   there and it would instead land on the capped fallback POST, adding exit latency on every CLI run
   for internal telemetry whose loss is acceptable. Statsbeat keeps today's reader and is exempt from
   both budgets.
9. The exporters deliberately do **not** override `OnShutdown`. An earlier revision did so as
   belt-and-braces for callers supplying their own processor, but it fired a second `DrainStorage`
   inside the first, clobbering the tracked in-flight drain task, and it added `OnShutdown` to the
   public API listing. Callers with their own processor keep today's behavior; their backlog is
   drained by the periodic timer and by the next process's eager pass.

> All `protected` overrides live on internal processor and reader types, so **`api/*.cs` is
> unchanged**. Note that the API listing *does* include `protected override` members on public sealed
> classes (`Dispose(bool)` is listed today), so overriding anything on the exporters themselves would
> be a public surface change.

### Phase 3 — Make the backlog drainable

File: `src/Internals/TransmitFromStorageHandler.cs`

10. **Lease reclamation — prerequisite, see §1.5.** The eager pass renames
    `*.blob@{expired-timestamp}.lock` back to `.blob` itself, because `RemoveExpiredLease` is
    internal to the storage package and only runs on the 120 s maintenance timer. Race rules:
    - **(a)** Reclaim only leases whose **embedded timestamp has expired** (parse after the last `@`).
    - **(b)** Two processes may reclaim the same lock concurrently — one `File.Move` wins, the loser
      swallows the failure and moves on.
    - **(c)** The drain's own lease must satisfy **`leasePeriod ≥ drainPostBudget + margin`**.
      Today's `TryLease(120000)` leaves only 20 s over the 100 s `NetworkTimeout`; coalescing plus
      drain-until-empty can exceed it, turning rare kill-window duplicates into routine ones.

    File an upstream issue in parallel, but do not depend on it.
11. **Eager first pass** shortly after construction instead of t+120 s. This is what makes run *N+1*
    upload run *N*'s telemetry.
12. **Startup cost controls.** Jitter the first pass and cap per-process drain work. Parallel MSBuild
    nodes mean a dozen processes hit one directory at once, and `OnGetBlobs` performs a directory
    enumeration per `TryGetBlob` call.
    *Implemented as jitter plus a blob/byte/time cap. Below-normal thread priority was dropped: the
    drain runs on the thread pool, where lowering priority would leak to unrelated work.*
13. **Drain oldest-first.** `OnGetBlobs` uses `OrderByDescending(f => f)` over
    `{utcTimestamp}-{guid}.blob`, i.e. **newest-first**, so the oldest blobs starve and age out. Use
    the public `PersistentBlobProvider.GetBlobs()` and order ascending ourselves.
14. **Coalesce blobs.**
    - **Compression: resolved.** There is no gzip anywhere — `ApplicationInsightsRestClient.CreateRequest`
      sends `Content-Type: application/json` with raw NDJSON, and `TransmitFromStorageHandler` already
      does `Encoding.UTF8.GetString(data).Split('\n')` directly on blob bytes, which only works on
      plain text. Concatenation is safe; multi-member gzip is a non-issue.
    - Bound the coalesced payload by the **ingestion byte limit**, not a blob count.
    - **206 index mapping:** `HandlePartialSuccess` splits the request content on `'\n'` and indexes
      into it, so indices map naturally onto the coalesced item order; the retryable subset is
      re-persisted as a new blob. Delete originals only after the response is fully processed.
    - **Poison isolation:** a top-level non-retriable failure on a coalesced batch falls back to
      sending constituents individually — otherwise one malformed blob destroys the good blobs
      batched with it. A blob that deterministically fails non-retriably **in isolation** is deleted.
    - **No attempt counter.** There is no sidecar metadata, and encoding one in the filename breaks
      `GetDateTimeFromBlobName` (`Substring(0, LastIndexOf('-'))` over a timestamp that already
      contains dashes), yielding `DateTime.MinValue` — which makes `OnGetBlobs` skip the blob *and*
      `RemoveExpiredBlob` delete it. Retention and the size cap bound repeated retriable failures.
15. **Bounded drain-until-empty** (time budget + blob cap) replacing `fileCount = 10`; run on a
    background task, removing `.Result` from the caller's thread.
16. **Storage retention stays at the package default of two days.** Extending it was considered and
    rejected: ingestion rejects telemetry whose timestamp is more than 48 hours old, so a longer
    retention would only hold payloads that are guaranteed to be refused, consuming the size cap and
    wasting drain requests. This does bound the last-invocation gap — telemetry from a run whose
    machine stays idle for more than two days is unrecoverable regardless of what this exporter
    does.
17. **Oldest-first eviction, exporter-side.** `DirectorySizeTracker` and the null-return-at-cap are
    internal to the storage package, so this cannot be fixed where it lives. On `SaveTelemetry`
    failure: enumerate `GetBlobs()` ascending, `TryDelete` oldest until under a soft cap, retry the
    save. Viable because `OnGetBlobs` returns `new FileBlob(file, this.directorySizeTracker)`, so
    `TryDelete` decrements the tracker.
    **Eviction must be gated on the directory actually being at capacity.** A write can also fail
    for permission, disk, or locking reasons, and evicting then would destroy the backlog without
    saving anything. Applied only on the persist path, where the storage directory and cap are
    known; the retry paths in `HttpPipelineHelper` keep the plain save.

### Phase 4 — Security, atomicity, durability

18. **Storage directory location is settled — do not change it.** Earlier revisions of this plan
    proposed moving off the `/tmp` fallback on Linux to `$XDG_STATE_HOME`. That was wrong on two
    counts: the location and the hashed subdirectory (instrumentation key + user + process name +
    application directory) have already been through security review and cleared, and changing
    either is a breaking change that orphans every existing customer's backlog.
    The only residual question worth confirming, rather than changing, is whether the cleared design
    also covers the *permissions* the directory is created with — this change increased the volume
    written there from failed transmissions only to every run's pending telemetry, which is a
    quantitative rather than qualitative shift in exposure.
19. **Atomicity: verified already safe.** `FileBlob.OnTryWriteSpan` writes to `FullPath + ".tmp"`
    then `File.Move`, and `OnGetBlobs` filters `"*.blob"`, so a truncated `.tmp` can never be
    drained. Add regression tests anyway, since the new path makes this load-bearing.
20. **Durability caveat.** There is no `fsync`. Process kill is covered by temp-then-rename; **power
    loss is not** and can lose the final write. "Correctness comes from the disk" is scoped to
    process termination.
21. At-least-once semantics: duplicates are possible if the process is killed between a 200 response
    and the blob delete.

---

## 5. Files touched

| File | Change |
| ---- | ------ |
| `src/Internals/ITransmitter.cs` | Persist-only scope + drain members |
| `src/Internals/AzureMonitorTransmitter.cs` | Persist-only branch; `_inFlightDrain` lifecycle; fallback POST budget; `FileBlobProvider` tuning |
| `src/Internals/TransmitFromStorageHandler.cs` | Lease reclamation, eager jittered pass, oldest-first, coalescing, poison isolation, eviction |
| `src/Internals/LogFilteringProcessor.cs` | `OnShutdown` override |
| `src/AzureMonitorTraceExporter.cs` / `LogExporter.cs` / `MetricExporter.cs` | `OnShutdown` |
| `src/ExporterRegistrationHostedService.cs` | Processor / reader construction |
| `src/AzureMonitorExporterExtensions.cs` | Processor / reader construction |
| `src/OpenTelemetryBuilderExtensions.cs` | Metric reader construction |
| `src/Internals/PersistentStorage/StorageHelper.cs` | Directory selection + permissions |
| `tests/.../CommonTestFramework/MockTransmitter.cs` | New interface members |
| `CHANGELOG.md` | Release note |

---

## 6. Verification

1. `TracerProvider.Dispose()` against a **hanging** endpoint returns immediately and persists 100 %
   of spans, with zero HTTP calls on the shutdown path.
2. `Timeout.Infinite` Dispose path does not wait on the drain; `Shutdown(5000)` waits
   `min(remaining, budget)` measured *after* `base.OnShutdown`.
3. Steady-state periodic export still POSTs directly; `ForceFlush()` unchanged unless the
   `AppContext` switch is set; `DisablePersistOnShutdown` restores today's behavior.
4. `DisableOfflineStorage = true` and a **read-only filesystem** both fall back to a POST capped by
   `internalFallbackPostBudget` — nonzero, and it delivers.
5. **Lease reclamation:** kill a process mid-drain, then assert the next process reclaims the `.lock`
   and uploads the blob.
6. **Concurrent lease reclamation:** two processes reclaim the same expired `.lock`; one wins, the
   loser continues without error, no duplicate upload.
7. **`leasePeriod ≥ drainPostBudget + margin`** asserted as an invariant.
8. **N concurrent processes** with eager drains on one directory — no starvation, bounded contention.
9. **Poison blob:** a deterministic non-retriable failure is isolated, deleted, and does not destroy
   the good blobs coalesced with it.
10. **Truncated `.tmp`** is never picked up by the drain.
11. *N* blobs → one coalesced POST → *N* deletes; 206 re-persists only the retryable subset.
12. Oldest-first drain order; eviction at the size cap drops oldest, not newest.
13. Stats: one item never double-counted across CustomerSdkStats and Statsbeat.
14. Statsbeat shutdown adds no measurable exit latency.
15. Wire capture (Fiddler) confirming requests are uncompressed NDJSON.
16. Console E2E harness (modelled on `Azure.Monitor.OpenTelemetry.Exporter.Demo`): run 1 emits *M*
    spans and exits → *M* items on disk; run 2 against a mock ingestion server → all uploaded,
    directory empty.
17. **Exit-latency and startup-latency benchmarks** in
    `Azure.Monitor.OpenTelemetry.Exporter.Benchmarks` — the CLI team cares about both ends.
18. Cross-platform storage directory and permission assertions in `StorageHelperTests.cs`.

---

## 7. Accepted trade-offs

- The final invocation on a machine leaves telemetry on disk until the next run. If that next run is
  more than 48 hours later the telemetry is unrecoverable, because ingestion rejects timestamps older
  than that. A separate uploader process was considered and rejected.
- In-process drain of a process's own telemetry is opportunistic (§3.4).
- Power loss can lose the final write (item 20).
- Metric `ForceFlush` is not hookable (Phase 2.7) — moot given §3.2.

## 8. Rejected

- **Persist-always** (classic `ServerTelemetryChannel` spooling). Uniform and removes the Phase 2
  ordering machinery, but adds a disk write to every export for high-throughput servers and breaks
  outright in the read-only-filesystem environments from Phase 1.3. Earns its keep only with a full
  disk-backed channel, which this plan deliberately is not.
- **Env-var / heuristic "short-lived process" detection.** Must work with zero configuration.
- **Attempt counter encoded in the blob filename** (Phase 3.14) — silently deletes telemetry.
- **Extending storage retention past two days** — ingestion rejects telemetry older than 48 hours, so
  the retained payloads would be refused on arrival.

## 9. Follow-ups (tracked, not in v1)

- **Gzip on the drain path only**, leaving steady-state untouched. Coalescing is precisely where
  payloads get large. Requires confirming Breeze accepts `Content-Encoding: gzip` on `/v2.1/track`.
- **Upstream issues** against `OpenTelemetry.PersistentStorage.FileSystem`: lease reclamation outside
  the maintenance timer, and oldest-first eviction instead of drop-at-cap.

---

## 10. Notes for the CLI team (not changed by this plan)

Pre-existing costs a latency-sensitive CLI will want to configure:

- `EnableLiveMetrics` defaults to `true` on the `UseAzureMonitorExporter` path and spawns a dedicated
  background thread.
- Statsbeat builds a **second** `MeterProvider` and can reach IMDS (`http://169.254.169.254/...`).
- The default sampler is `RateLimitedSampler` at `TracesPerSecond = 5.0`. "All the telemetry" requires
  `OTEL_TRACES_SAMPLER=microsoft.fixed_percentage` + `OTEL_TRACES_SAMPLER_ARG=1.0`, already supported
  by `DefaultAzureMonitorExporterOptions`.
- `EnablePerformanceCounters` and `EnableStandardMetrics` default to `true`.

---

## 11. Review history

| Rev | Outcome |
| --- | ------- |
| r1 | Blocking: ForceFlush scope, `Timeout.Infinite` wait rule, drain/disposal lifecycle. Resolved in §3.2–§3.4. |
| r2 | Blocking: fallback POST inheriting a zero budget. Resolved in §3.5 / Phase 1.3. Lease race rules, exporter-side eviction, statsbeat exclusion, timeout accounting added. Attempt-counter suggestion rejected as harmful. |
| r3 | Eviction gated on real capacity exhaustion; duplicate drain removed with the exporter overrides; 206 with an unreadable body no longer discards the batch; transient read failures no longer delete blobs; standard metrics moved onto the persisting reader. Confirmed the API listing *does* include protected overrides on sealed classes — an earlier claim to the contrary was wrong. |

## 12. Implementation status

Phases 1–3 are implemented. 864 tests pass and `api/*.cs` is unchanged, confirming no public surface
change. New coverage lives in `tests/.../PersistOnShutdownTests.cs` (transmitter and drain) and
`tests/.../PersistOnShutdownProviderTests.cs` (real `TracerProvider` pipeline).

Three things were corrected during implementation:

- `TracerProviderSdk.Dispose` calls `Processor.Shutdown(5000)`, **not** `Shutdown(Timeout.Infinite)`
  as §3.3 assumed. `Dispose()` therefore does grant the drain a budget, so an upload may be
  attempted on that path. `Shutdown()` with no argument is the `Timeout.Infinite` case. Both are
  bounded; neither blocks on the network.
- The drain budget was being spent twice — once in `DrainStorage` and again in
  `AzureMonitorTransmitter.Dispose`. Dispose now waits only the remainder, so total shutdown is
  bounded by one budget.
- The API listing *does* include `protected override` members on public sealed classes, contrary to
  an earlier assumption in this document. Anything overridden on the exporters themselves is a
  public surface change; the overrides therefore live only on internal processor and reader types.

### Verified by test

| # | Item | Test |
| - | ---- | ---- |
| 1 | Shutdown persists, zero HTTP on the export path | `ShutdownPersistsPendingTelemetryWithoutTransmitting`, `ShutdownDoesNotBlockOnAHangingEndpoint` |
| 3 | Steady state and ForceFlush unchanged; both switches | `ForceFlushTransmitsByDefault`, `ForceFlushPersistsWhenSwitchIsEnabled`, `DisableSwitchRestoresBlockingTransmissionOnShutdown`, `PersistOnlyScopeIsScopedToTheUsingBlock` |
| 5 | Lease reclamation, expired and unexpired | `DrainReclaimsAnExpiredLeaseLeftByAKilledProcess`, `DrainLeavesAnUnexpiredLeaseAlone` |
| 9 | Poison isolation | `DrainIsolatesConstituentsWhenCoalescedBatchIsRejected`, `DrainDeletesABlobIngestionWillNeverAccept` |
| 11 | Coalescing and 206 handling | `DrainCoalescesStoredBlobsIntoASingleRequest`, `DrainRePersistsOnlyTheRetryableSubsetOfAPartialSuccess`, `DrainKeepsTheBatchWhenAPartialSuccessCannotBeRead` |
| — | Shared transmitter lifetime and single in-flight drain | `SharedTransmitterSurvivesUntilEveryExporterIsDisposed`, `ConcurrentShutdownsShareASingleInFlightDrain` |
| — | Eviction gated on real capacity exhaustion | `SaveEvictsOldestTelemetryWhenStorageIsFull`, `SaveDoesNotEvictWhenTheFailureIsNotCapacity` |

### Partially covered

- **(2)** `ResolveDrainWaitNeverBlocksIndefinitely` pins the wait rule as a unit, but no test asserts
  that `Shutdown(5000)` actually waits `min(remaining, budget)` end to end.
- **(4)** `PersistOnlyScopeTransmitsWhenOfflineStorageIsDisabled` proves the fallback transmits, but
  nothing asserts the fallback budget actually caps a hung request, and a read-only filesystem is
  never simulated.
- **(12)** Eviction is covered; that it removes the *oldest* specifically, and that the drain
  processes oldest-first, are not asserted.

### Not covered

- **(6, 8)** Not planned. Consumers with parallel process topologies can partition storage with the
  `StorageDirectory` option, so contention and throughput are a configuration concern rather than
  something the exporter should arbitrate. Correctness under concurrent access rests on the blob
  lease being an atomic rename and on `leasePeriod > drainPostBudget`, which is asserted by
  `LeasePeriodOutlastsASingleDrainRequest`.
- **(7)** `leasePeriod >= drainPostBudget + margin` as an asserted invariant.
- **(10)** Truncated `.tmp` ignored by the drain — guaranteed upstream by the `"*.blob"` filter, but
  nothing pins it.
- **(13, 14)** CustomerSdkStats / Statsbeat double-counting, and Statsbeat exit latency.
- **(15)** Wire capture confirming uncompressed NDJSON. Code inspection is conclusive.
- **(16, 17)** Console end-to-end harness and exit/startup latency benchmarks. **These matter most
  for the CLI team, since exit latency is the number they will measure.**
- **(18)** Not applicable. The storage directory location and naming are settled by security review
  and changing them would be breaking — see Phase 4 item 18.

# Shutdown and startup cost

What an application pays to start the exporter and to shut it down. This matters most for
short-lived processes such as CLI tools, which pay both costs on every invocation and have no
opportunity to amortise them.

Measured with BenchmarkDotNet on .NET 8.0.30, X64 RyuJIT, `RunStrategy=Monitoring`. Ingestion is a
loopback stub ([LocalIngestionServer.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Benchmarks/LocalIngestionServer.cs))
with a configurable response delay, so the numbers isolate the exporter from real network variance.
Run them with:

```dotnetcli
dotnet run -c Release -f net8.0 --filter *ShutdownBenchmarks*
dotnet run -c Release -f net8.0 --filter *StartupBenchmarks*
```

`DrainBudgetOverride` is applied through `AppDomain.CurrentDomain.SetData`, which writes to the store
`AppContext` reads from, so the parameter takes effect on every target framework including net462.

## Why shutdown has a cost at all

Uploading takes an ingestion round trip, and real ingestion can take several seconds to answer. A
process that exits before that completes loses whatever was buffered. Shutdown therefore writes
pending telemetry to disk first and leaves delivery to a background drain.

How long shutdown then waits for that drain depends on the timeout OpenTelemetry passes, which is
not the same for every path:

| Path | Timeout passed | Wait granted to the drain |
| --- | --- | --- |
| `Shutdown()` | `Timeout.Infinite` | none — blocking exit on the network is the thing being avoided |
| `Dispose()` | 5000 ms | `min(remaining, drain budget)`, so 2000 ms by default |
| Container or host teardown | 5000 ms | same as `Dispose()` |
| Failed `Build()` | 0 | none |

This is why `Dispose()` and `Shutdown()` measure differently below, and why the drain budget only
moves the `Dispose()` number.

## Shutdown

`DisposeProvider` builds a provider, records 10 spans, and disposes it. `DrainBudgetOverride` of
`-1` means the default budget is left in place; `BlockingShutdown` selects the previous behaviour,
where shutdown transmits inline and waits for the response.

| BlockingShutdown | DrainBudgetOverride | Ingestion delay | Mean | Allocated |
| --- | --- | --- | ---: | ---: |
| False | -1 (default 2000) | 0 ms | 6.918 ms | 149.82 KB |
| False | -1 (default 2000) | 2000 ms | **2,011.802 ms** | 148.02 KB |
| False | **0** | 0 ms | **2.614 ms** | 36.88 KB |
| False | **0** | 2000 ms | **2.729 ms** | 36.88 KB |
| True | -1 | 0 ms | 1.659 ms | 98.02 KB |
| True | -1 | 2000 ms | 2,010.282 ms | 98.23 KB |
| True | 0 | 0 ms | 1.719 ms | 97.58 KB |
| True | 0 | 2000 ms | 2,007.451 ms | 97.29 KB |

Reading the table:

- **Default budget, healthy ingestion — 6.9 ms.** The telemetry is persisted, the drain starts, and
  it finishes well inside the budget.
- **Default budget, slow ingestion — 2,011 ms.** The budget is spent waiting. Exit tracks ingestion
  latency up to the 2000 ms ceiling. This is the number a CLI cannot afford.
- **Budget 0 — 2.6 to 2.7 ms regardless of ingestion.** Exit costs the file write and nothing else.
  The drain still starts, it is simply not waited on.
- **Blocking path is unaffected by the budget**, because there is no drain to wait for. With slow
  ingestion it pays the full 2000 ms either way, and it is bounded only by `Retry.NetworkTimeout`,
  which defaults to 100 seconds.

`Shutdown()` rather than `Dispose()` was measured separately at **2.6 ms** with healthy ingestion and
**3.1 ms** against a 2000 ms delay: it passes `Timeout.Infinite`, which never waits, so ingestion
latency does not reach it.

## Startup

`BuildProvider` builds a provider and disposes it. Statsbeat is a parameter because it constructs a
second `MeterProvider`.

| EnableStatsbeat | Mean | Allocated |
| --- | ---: | ---: |
| False | 1.804 ms | 203.77 KB |
| True | 3.025 ms | 558.67 KB |

Statsbeat roughly doubles the time and nearly triples the allocation. For a CLI invoked thousands of
times in a build this is charged on every invocation.

## What this implies for configuration

| Application shape | Setting | Expected exit cost |
| --- | --- | --- |
| CLI, invoked frequently | `ShutdownDrainBudgetMilliseconds` = 0 | ~2.7 ms |
| CLI, invoked rarely | `ShutdownDrainBudgetMilliseconds` = 500 | up to 500 ms |
| Long-running service | default | up to 2000 ms, once per process |
| Single-run CI job | `DisablePersistOnShutdown` plus a bounded `Retry.NetworkTimeout` | until ingestion answers |

A budget of `0` buys exit latency at the cost of delivery: the drain is started but the process
exits before it finishes, so the telemetry waits on disk for a later run. That is the right trade
when runs are frequent, and the wrong one when they are not, because ingestion rejects telemetry
older than 48 hours. A single-run CI job has no later run at all — the agent is usually discarded
when the job ends — so it should block instead of persisting.

## Notes on the harness

- Both benchmarks disable the eager startup drain. Without that, blobs left by an earlier iteration
  would be uploaded while the next one is being measured.
- `ShutdownBenchmarks` rebuilds the provider in `IterationSetup`, which is outside the measured
  region.
- `StartupBenchmarks` reuses a single connection string, because the transmitter is cached per
  connection string. A fresh one per iteration would leak a timer and a blob provider each time;
  reusing one means disposal releases the last reference so the next iteration constructs a real
  provider rather than measuring a cache hit.

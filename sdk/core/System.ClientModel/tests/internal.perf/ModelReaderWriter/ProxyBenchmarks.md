# ModelReaderWriter proxy benchmarks

Run from the repository root in PowerShell:

```powershell
$project = 'sdk\core\System.ClientModel\tests\internal.perf\System.ClientModel.Tests.Internal.Perf.csproj'
$env:UseProjectReferenceToAzureClients = 'true' # Also inherited by generated BenchmarkDotNet builds.
dotnet build $project -c Release -f net10.0 /p:UseProjectReferenceToAzureClients=true

# Smoke test only: verifies all fixtures, not performance evidence.
dotnet run --no-build --project $project -c Release -f net10.0 -- --filter '*ProxyResolutionBenchmark*' --job Dry --artifacts '.\BenchmarkDotNet.Artifacts\proxy-smoke'

# Measurement: existing out-of-process job, MemoryDiagnoser, calibrated invocation counts.
# The proxy-specific job configuration prevents automatic power-plan changes.
dotnet run --no-build --project $project -c Release -f net10.0 -- --filter '*ProxyResolutionBenchmark*' --launchCount 2 --warmupCount 5 --iterationCount 15 --exporters json --artifacts '.\BenchmarkDotNet.Artifacts\proxy-measurement'

# Separate retained-registration-storage and construction-allocation measurement.
dotnet run --no-build --project $project -c Release -f net10.0 -- --proxy-registration-storage
```

The proxy benchmark's job mutator does not enforce a power plan; the configuration
of other benchmarks is unchanged. Stock BenchmarkDotNet raises only its own
benchmark child process to High priority (no supported priority setting exists
in version 0.15.8); obtain approval if the host disallows this.
`--proxy-registration-storage`
is an isolated diagnostic mode, not a BenchmarkDotNet serialization benchmark.
Check `--help` for BenchmarkDotNet options supported by the installed version.

## Workload and counts

Every timed operation uses public generic `ModelReaderWriter.Read<T>(BinaryData, options)`
or `Write<T>(model, options)`, JSON (`J`) format, the **same seven-property class,
payload and serialization helpers**, and reused caller-owned options. There are
no collections. Payload/model construction, proxy registration, reflection-cache
warmup and validation occur in global setup, outside measured operations.
The operation-local options copy performed by the library remains in the hot path.

| Suffix | Total registrations | Distinct model keys | Matching position |
| --- | ---: | ---: | --- |
| NoProxy | 0 | 0 | none |
| Direct_1Key | 1 | 1 | first, unconditional |
| Direct_10Keys | 10 | 10 | one target entry plus nine unrelated keys |
| LookupMiss_1OtherKey | 1 | 1 | no target key |
| LookupMiss_10OtherKeys | 10 | 10 | no target key |
| Conditional_1Entry | 1 | 1 | first (= last) |
| Conditional_FirstOf10 | 10 | 1 | first |
| Conditional_LastOf10 | 10 | 1 | tenth |
| AllDecline_1Entry | 1 | 1 | none; one predicate checked |
| AllDecline_10Entries | 10 | 1 | none; ten predicates checked |

The meeting left "miss" ambiguous. `LookupMiss` measures an unrelated-model-key
lookup miss with registrations elsewhere. `AllDecline` measures a same-key
conditional chain whose candidates all decline, then model fallback. These are
two interpretations of that question, not two separately stated requirements.

Conditional reads inspect the real UTF-8 `"type"` discriminator using
`Utf8JsonReader`; writes compare the actual model discriminator ordinally.
The discriminator is first in this representative payload. Its position and
predicate implementation affect cost; these results do not cover every possible
predicate. Proxies and fallback deserialize/serialize identical property sets.
Global setup exercises a separate instrumented instance of each configuration,
asserting exact predicate and proxy-call counts, every deserialized property,
byte-for-byte write output, and that caller options have no leaked proxy state.
Instrumented subclasses/counters are **not** used by measured operations.
Unrelated-key proxy methods throw if incorrectly invoked.

## Interpreting memory and timing

- BenchmarkDotNet `Allocated` is **bytes allocated per read/write**, not retained
  registration storage. Its Gen0 column is collections per 1,000 operations.
- Runtime/JIT inlining and escape analysis can eliminate other temporary wrappers
  differently between call sites. An observed net allocation delta is not
  necessarily the size of the options copy alone. Use allocation traces and
  source-level accounting before attributing every byte to proxy resolution.
- Storage mode roots 10,000 options graphs and samples full-GC heap differences
  five times per configuration. It separately samples thread allocation during
  construction. Root arrays are excluded, and proxy implementations, discriminator
  buffers and model keys are shared/precreated. Subtract the zero-registration
  result to estimate incremental registry storage. Report samples/ranges because
  heap snapshots are approximate; do not equate construction allocations with
  retained bytes (dictionary/list growth can leave dead backing arrays).
- Storage `Direct` is one direct target plus unrelated keys; `LookupMiss` is all
  unrelated keys; `AllDecline` is one same-key conditional chain. Retention depends
  on key/chain shape and container capacity, not just entry count.
- Read/write baselines are grouped separately so ratios never compare a read
  against a write or a different model/payload.
- The meeting's near-baseline 2–3% timing and roughly 40 bytes per registration
  were expectations, **not acceptance thresholds** or a 40-byte-per-operation goal.
- Inspect Mean, Error (99.9% confidence-interval half-width), StdDev, Median,
  allocation and run warnings. Shared-host timing is noisy; a small point estimate
  is not proof of zero overhead. A short/dry job verifies execution only.
- Prior gist results used a different commit/runtime/machine/job/model; they are
  context, not a valid cross-run percentage comparison.
- If host policy forbids stock BenchmarkDotNet's automatic process-priority
  change, defer its timed runs. A normal-priority runner invoking these fixtures
  can provide exploratory batch distributions and thread-allocation measurements,
  but is not a substitute for BenchmarkDotNet calibration, isolation or statistical
  analysis. Report its controls, invocation counts, warmup, ordering and limitations,
  and do not use it to certify a 2–3% difference.

# Cosmos DB .NET SDK V4 — Rust Driver Interop Design

<!-- cspell:ignore cbindgen Cdecl Conv Convs MSVC PPAF slnx -->

> Status: **Draft / Proposal**
> Scope: .NET SDK V4 that delegates request execution to the Azure Cosmos DB Rust driver (Gateway-mode only).
> Owners: Cosmos DB .NET SDK team
> Location: `sdk/cosmosdb/Azure.Data.Cosmos/design/` in `azure-sdk-for-net`. Ported from the [original draft](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/users/kundadebdatta/build_rust_interop_for_net/docs/V4-RustInterop-Design.md) in `azure-cosmos-dotnet-v3` and updated to this repository's layout.

---

## 1. Goals and Non-Goals

### 1.1 Goals

1. Build a new **`Azure.Data.Cosmos` (V4)** package whose public API surface is idiomatic .NET, but whose request execution path is routed through the **Cosmos DB Rust driver** via P/Invoke / FFI interop.
2. Support **Gateway mode only** (matches Rust driver capability today).
3. Deliver a single, **cross-platform** managed assembly, targeting the two most recent .NET releases (`net10.0` to start; no .NET Framework or .NET Standard), that loads the appropriate **native Rust library** (`.dll` / `.so` / `.dylib`) on Windows / Linux / macOS, x64 / arm64.
4. Preserve a familiar V3-like surface for: `CosmosClient`, `Database`, `Container`, `Item CRUD`, `Query`, `ChangeFeed`, `Batch (TransactionalBatch)`, `Bulk`.
5. Keep the **diagnostics, telemetry, and error contract** consistent with Cosmos DB conventions (`CosmosException`, `Diagnostics`, sub-status codes, retry-after, activity ids, region info).
6. Provide a stable, versioned **C ABI boundary** between managed and native — independent of internal Rust types.
7. Ship as a **NuGet package** with native binaries packed via runtime-specific folders (`runtimes/<rid>/native/`).

### 1.2 Non-Goals

- **Direct (TCP) mode** — the Rust driver is gateway-only; V4 will not expose direct mode.
- **Client-side encryption** packages on day 1 (`Microsoft.Azure.Cosmos.Encryption*`) — out of scope for V1; can be revisited later.
- **Bringing forward all V3 surface area verbatim.** V4 is a chance to clean up obsolete APIs, deprecated overloads, and legacy types.
- **Replacing V3.** V3 continues to ship and is supported; V4 is a separate, parallel package.
- **Hosting the Rust source in this repo.** Rust source lives in its own repository; we consume signed/published binaries.

---

## 2. High-Level Architecture

```
┌──────────────────────────────────────────────────────────┐
│  User Application (.NET 10+)                             │
└──────────────────────────────────────────────────────────┘
                     │  Public V4 API
                     ▼
┌──────────────────────────────────────────────────────────┐
│  Azure.Data.Cosmos (V4) — Managed Facade                 │
│  • CosmosClient / Database / Container / Item APIs       │
│  • Serialization (System.Text.Json default)              │
│  • Diagnostics aggregation                               │
│  • ChangeFeed / Query LINQ / Batch builders              │
└──────────────────────────────────────────────────────────┘
                     │  Internal Interop Layer (managed)
                     ▼
┌──────────────────────────────────────────────────────────┐
│  Interop layer (internal, src/Interop/)                  │
│  • SafeHandles for native objects                        │
│  • Marshalling (UTF-8, spans, callbacks, error codes)    │
│  • Async bridge: native completion → TaskCompletionSource│
│  • Native logging / tracing pump                         │
└──────────────────────────────────────────────────────────┘
                     │  P/Invoke (LibraryImport, C ABI)
                     ▼
┌──────────────────────────────────────────────────────────┐
│  cosmos_native.{dll|so|dylib}  (Rust C-ABI shim)         │
│  • Thin `extern "C"` wrappers over the Rust driver       │
│  • Stable, versioned C header (cosmos_native.h)          │
└──────────────────────────────────────────────────────────┘
                     │  Rust function calls
                     ▼
┌──────────────────────────────────────────────────────────┐
│  azure_data_cosmos (Rust driver crate)                   │
│  • Gateway HTTP client                                   │
│  • Auth, retry, partition routing, query pipeline        │
└──────────────────────────────────────────────────────────┘
                     │  HTTPS
                     ▼
              Cosmos DB Gateway
```

**Key principle:** The managed layer is **a thin, idiomatic .NET facade**. All wire protocol, retry policy, partition resolution, query pipeline, and account topology handling live in Rust. The managed side handles the `Task`-based async pattern, IDisposable lifecycle, JSON (de)serialization, LINQ-to-query, and exception translation.

---

## 3. Why This Architecture

| Concern | Decision | Rationale |
|---|---|---|
| Interop boundary | **C ABI** (not COM, not C++/CLI) | Portable across OS/arch, easy to evolve, broad tool support, matches `cbindgen` output. |
| Marshalling style | **`LibraryImport` (source-generated)** | Trim/AOT friendly, no reflection, faster than legacy `DllImport`. |
| Async bridge | **Native callback + `TaskCompletionSource`** | Avoids polling; matches `tokio` task completion in Rust. |
| Buffer handoff | **UTF-8 byte spans / pinned buffers** | Eliminates UTF-16↔UTF-8 conversions on hot path; Rust is UTF-8 native. |
| Object lifetime | **`SafeHandle` per native object** | Deterministic cleanup, finalizer safety, matches GC semantics. |
| Versioning | **`cosmos_native_abi_version()` probe at load** | Detects mismatched native/managed packages early. |
| Error model | Native returns `int32` code + opaque error handle → managed throws `CosmosException` | Avoids exceptions across FFI; preserves rich error details. |
| Logging | Native pushes events into a managed callback (`tracing` → `EventSource`) | Single, unified diagnostics pipeline. |

---

## 4. Public API Surface (V4)

The public surface stays close to V3 to minimize migration cost, but cleans up legacy debt. Indicative shape:

```csharp
namespace Azure.Data.Cosmos;

public sealed class CosmosClient : IAsyncDisposable
{
    public CosmosClient(string connectionString, CosmosClientOptions? options = null);
    public CosmosClient(string accountEndpoint, TokenCredential credential, CosmosClientOptions? options = null);
    public CosmosClient(string accountEndpoint, AzureKeyCredential credential, CosmosClientOptions? options = null);

    public Database GetDatabase(string id);
    public Task<DatabaseResponse> CreateDatabaseAsync(string id, ThroughputProperties? throughput = null, RequestOptions? options = null, CancellationToken ct = default);
    public Task<DatabaseResponse> CreateDatabaseIfNotExistsAsync(...);
    public AsyncPageable<DatabaseProperties> GetDatabaseQueryIterator(...);
    public ValueTask DisposeAsync();
}

public sealed class Container
{
    public Task<ItemResponse<T>> CreateItemAsync<T>(T item, PartitionKey? pk = null, ItemRequestOptions? options = null, CancellationToken ct = default);
    public Task<ItemResponse<T>> ReadItemAsync<T>(string id, PartitionKey pk, ...);
    public Task<ItemResponse<T>> ReplaceItemAsync<T>(T item, string id, PartitionKey? pk = null, ...);
    public Task<ItemResponse<T>> UpsertItemAsync<T>(T item, PartitionKey? pk = null, ...);
    public Task<ItemResponse<T>> PatchItemAsync<T>(string id, PartitionKey pk, IReadOnlyList<PatchOperation> patchOperations, ...);
    public Task<ItemResponse<T>> DeleteItemAsync<T>(string id, PartitionKey pk, ...);

    public AsyncPageable<T> GetItemQueryIterator<T>(QueryDefinition query, string? continuationToken = null, QueryRequestOptions? options = null);
    public ChangeFeedIterator<T> GetChangeFeedIterator<T>(ChangeFeedStartFrom startFrom, ChangeFeedMode mode, ChangeFeedRequestOptions? options = null);

    public TransactionalBatch CreateTransactionalBatch(PartitionKey pk);
    // Bulk surfaces via CosmosClientOptions.AllowBulkExecution
}
```

Naming differences vs V3 (final list TBD in API review):

- Use `AsyncPageable<T>` (Azure SDK convention) instead of `FeedIterator<T>` for query/listing returns.
- Use `TokenCredential` directly — drop `AuthorizationTokenProvider`.
- Drop deprecated overloads, `dynamic` returns, and obsolete query options.
- Default JSON serializer is **`System.Text.Json`**; opt-in JSON.NET via package extension.

---

## 5. Native ABI Surface

A **stable, hand-curated C header** (`cosmos_native.h`) is the contract. The Rust shim crate produces it (via `cbindgen`) and exports the `extern "C"` entry points. We commit the header to this repository (`sdk/cosmosdb/Azure.Data.Cosmos/native/cosmos_native.h`) for review/diffing.

### 5.1 Conventions

- All strings cross the boundary as **UTF-8 byte pointer + length** (`const uint8_t*`, `size_t`). No null-terminated strings.
- All function calls are **non-blocking**. Long-running work returns immediately and completes via a callback.
- Every native object is wrapped in an opaque handle (`cosmos_client_t*`, `cosmos_request_t*`, `cosmos_response_t*`, …).
- Each handle has a matching `*_release` function. Managed side wraps in `SafeHandle`.
- Errors: every call returns `int32_t cosmos_status_t` (0 = OK, non-zero = error). On error, an opaque `cosmos_error_t*` is produced that can be queried for status code, sub-status, message, retry-after, activity id, diagnostics JSON.
- A single global ABI version: `uint32_t cosmos_native_abi_version(void)`.

### 5.2 Initial Function Set (illustrative)

```c
// Lifecycle
uint32_t        cosmos_native_abi_version(void);
cosmos_status_t cosmos_runtime_init(const cosmos_runtime_options_t* opts, cosmos_runtime_t** out);
void            cosmos_runtime_release(cosmos_runtime_t* rt);

// Logging / tracing pump
typedef void (*cosmos_log_callback)(int32_t level, const uint8_t* msg, size_t len, void* ctx);
cosmos_status_t cosmos_runtime_set_log_callback(cosmos_runtime_t*, cosmos_log_callback, void* ctx);

// Client
cosmos_status_t cosmos_client_create(
    cosmos_runtime_t* rt,
    const uint8_t* endpoint, size_t endpoint_len,
    const cosmos_credential_t* cred,
    const cosmos_client_options_t* opts,
    cosmos_client_t** out);
void cosmos_client_release(cosmos_client_t*);

// Async completion callback
typedef void (*cosmos_completion)(cosmos_response_t* resp, cosmos_error_t* err, void* ctx);

// Item operations (one entry point per operation, or a generic dispatcher)
cosmos_status_t cosmos_item_read(
    cosmos_client_t*,
    const uint8_t* db, size_t db_len,
    const uint8_t* container, size_t container_len,
    const uint8_t* id, size_t id_len,
    const uint8_t* pk_json, size_t pk_len,
    const cosmos_request_options_t* opts,
    cosmos_completion cb, void* ctx);

cosmos_status_t cosmos_item_create(...);
cosmos_status_t cosmos_item_replace(...);
cosmos_status_t cosmos_item_upsert(...);
cosmos_status_t cosmos_item_patch(...);
cosmos_status_t cosmos_item_delete(...);

// Query
cosmos_status_t cosmos_query_create(cosmos_client_t*, /* params */, cosmos_query_t** out);
cosmos_status_t cosmos_query_next_page(cosmos_query_t*, cosmos_completion cb, void* ctx);
void            cosmos_query_release(cosmos_query_t*);

// Change feed
cosmos_status_t cosmos_changefeed_create(cosmos_client_t*, /* params */, cosmos_changefeed_t** out);
cosmos_status_t cosmos_changefeed_next_page(cosmos_changefeed_t*, cosmos_completion cb, void* ctx);
void            cosmos_changefeed_release(cosmos_changefeed_t*);

// Batch
cosmos_status_t cosmos_batch_create(cosmos_client_t*, /* params */, cosmos_batch_t** out);
cosmos_status_t cosmos_batch_add_operation(cosmos_batch_t*, cosmos_op_kind_t, /* payload */);
cosmos_status_t cosmos_batch_execute(cosmos_batch_t*, cosmos_completion cb, void* ctx);
void            cosmos_batch_release(cosmos_batch_t*);

// Response inspection
cosmos_status_t cosmos_response_status(cosmos_response_t*, int32_t* http_status, int32_t* sub_status);
cosmos_status_t cosmos_response_body(cosmos_response_t*, const uint8_t** out_ptr, size_t* out_len);
cosmos_status_t cosmos_response_header(cosmos_response_t*, const uint8_t* name, size_t name_len, const uint8_t** out_val, size_t* out_len);
cosmos_status_t cosmos_response_diagnostics_json(cosmos_response_t*, const uint8_t** out_ptr, size_t* out_len);
void            cosmos_response_release(cosmos_response_t*);

// Error
void cosmos_error_details(cosmos_error_t*, cosmos_error_details_t* out);
void cosmos_error_release(cosmos_error_t*);
```

### 5.3 Async Bridge Pattern

Native callbacks run on a Rust thread (likely a `tokio` worker). On completion:

1. Native invokes `cosmos_completion(response, error, ctx)`.
2. `ctx` is a `GCHandle.ToIntPtr(handle)` of a managed continuation (e.g. a `CosmosCompletion` object holding a `TaskCompletionSource`).
3. The managed callback runs on the Rust worker thread; it must do **minimal work**: capture pointers into `SafeHandle`s and call `tcs.TrySetResult` / `TrySetException`. No user code runs on the native thread.
4. The awaiting `Task` continuation resumes on the captured `SynchronizationContext` / thread pool per normal .NET rules.

```csharp
[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
private static unsafe void OnCompletion(IntPtr response, IntPtr error, IntPtr ctx)
{
    GCHandle handle = GCHandle.FromIntPtr(ctx);
    var completion = (CosmosCompletion)handle.Target!;
    handle.Free();

    if (error != IntPtr.Zero)
    {
        completion.SetException(NativeError.ToCosmosException(error));
    }
    else
    {
        completion.SetResult(new ResponseHandle(response));
    }
}
```

---

## 6. Managed Layer Internals

### 6.1 Repository Hosting & Package Name

**Hosting repository:** [github.com/Azure/azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net) — the official Azure SDK for .NET monorepo. **V4 does not live in `azure-cosmos-dotnet-v3`.**

**Rationale for moving to `azure-sdk-for-net`:**

- V4 is a **clean break** from V3 (new public API conventions, gateway-only, native-backed) and aligns naturally with the modern Azure SDK shape (`Azure.*` namespaces, `AsyncPageable<T>`, `TokenCredential`, unified `ClientOptions` / `RequestContext` / pipeline diagnostics).
- The `azure-sdk-for-net` repo provides the shared infrastructure V4 needs out of the box: `Azure.Core` types, the SDK build/release pipelines, the `eng/` engineering system, common analyzers, API review automation (`apiview.dev`), changelog tooling, snippet validation, and the standard NuGet release workflow.
- Discovery: customers searching for "Azure SDK for .NET → Cosmos" expect to land in the Azure SDK monorepo.
- V3 stays in [`azure-cosmos-dotnet-v3`](https://github.com/Azure/azure-cosmos-dotnet-v3) and continues to be maintained on its current cadence — the two SDKs ship side by side from separate repos.

> **Gap:** the engineering system doesn't pack custom per-RID native binaries for any package today. Existing P/Invoke usage in this repo only calls OS libraries (for example, `Azure.Core` identity helpers and `Azure.Storage.Common` BCrypt interop). Staging, packing, signing, and binary scanning of `runtimes/<rid>/native/` assets is new `eng/` work (see Section 7).

**Package name:** **`Azure.Data.Cosmos`**

| Candidate | Pros | Cons | Verdict |
|---|---|---|---|
| **`Azure.Data.Cosmos`** | Follows current Azure SDK family naming (`Azure.Data.Tables`, `Azure.Data.AppConfiguration`); matches the Rust crate name `azure_data_cosmos`; clear separation from V3's `Microsoft.Azure.Cosmos`. | Slightly different from V3's customer-recognized id. | **Recommended; used by the scaffold.** |
| `Azure.Cosmos` | Short, clean. | Id already taken on NuGet by the unlisted `4.0.0-preview3` package (published from `azure-cosmos-dotnet-v3`); potential confusion with that archived history. | Backup. |
| `Microsoft.Azure.Cosmos` (4.x) | Continuity with V3. | Requires shipping a 4.x major from a different repo than 3.x; namespace collision in side-by-side install. | Rejected. |

**Repository sub-folder:** `sdk/cosmosdb/Azure.Data.Cosmos/`

Following the standard `azure-sdk-for-net` layout, each service lives under `sdk/<service>/` with one folder per package, and a service's data-plane, management-plane, and provisioning packages share that folder (for example `sdk/keyvault`, `sdk/appconfiguration`, `sdk/containerregistry`). The Cosmos DB service directory is `sdk/cosmosdb/`, which already holds `Azure.ResourceManager.CosmosDB` and `Azure.Provisioning.CosmosDB`. There is no `sdk/cosmos/` folder in this repository.

**Namespace:** `Azure.Data.Cosmos` (root) — matches the package id per Azure SDK convention (as with `Azure.Data.Tables`) and drops the `Microsoft.` prefix used by V3.

```csharp
using Azure.Data.Cosmos;                   // CosmosClient, Database, Container, ...
using Azure.Data.Cosmos.Diagnostics;       // CosmosDiagnostics
using Azure.Data.Cosmos.ChangeFeed;        // ChangeFeedIterator, ...
```

**Cross-repo coordination:**

- Native `cosmos_native` Rust shim lives in **its own repository** (proposed name: **`azure-cosmos-native`** under the `Azure` GitHub org). It produces signed binaries per RID and publishes them to an internal feed. This repository consumes pinned versions, and the `cosmos_native.h` header is committed here for reviewability.
- This doc lives at `sdk/cosmosdb/Azure.Data.Cosmos/design/V4-RustInterop-Design.md`. It was ported from the [original draft](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/users/kundadebdatta/build_rust_interop_for_net/docs/V4-RustInterop-Design.md) in `azure-cosmos-dotnet-v3`.

### 6.2 Project Layout

```
azure-sdk-for-net/                                       # github.com/Azure/azure-sdk-for-net
└── sdk/
    └── cosmosdb/                                        # Cosmos DB service directory (shared with mgmt plane)
        ├── ci.yml                                       # Data-plane pipeline (SDKType: client)
        ├── ci.mgmt.yml                                  # Existing, generated mgmt-plane pipeline
        ├── platform-matrix.json                         # net10.0-only CI test matrix (used by ci.yml)
        ├── service.projects                             # SDKType → project filter
        ├── test-resources.json                          # Live-test ARM template (currently empty)
        ├── tests.yml                                    # Planned — live/emulator test pipeline
        ├── Azure.ResourceManager.CosmosDB/              # Existing — management plane
        ├── Azure.Provisioning.CosmosDB/                 # Existing — Bicep provisioning
        └── Azure.Data.Cosmos/                           # V4 package
            ├── README.md
            ├── CHANGELOG.md
            ├── Azure.Data.Cosmos.slnx
            ├── Directory.Build.props                    # Pins net10.0 for src + tests
            ├── MigrationGuide.md                        # Planned — V3 → V4 guide
            ├── native-versions.props                    # Planned — pinned cosmos_native version
            ├── api/                                     # Generated public API listing
            │   └── Azure.Data.Cosmos.net10.0.cs
            ├── design/
            │   ├── V4-RustInterop-Design.md             # This doc
            │   └── V4-NativeAbi.md                      # Planned
            ├── native/
            │   └── cosmos_native.h                      # Planned — committed C ABI header
            ├── src/
            │   ├── Azure.Data.Cosmos.csproj
            │   ├── Properties/AssemblyInfo.cs           # InternalsVisibleTo for tests and Moq
            │   ├── Public/                              # Planned — CosmosClient, Database, Container, ...
            │   ├── Query/
            │   ├── ChangeFeed/
            │   ├── Batch/
            │   ├── Diagnostics/
            │   ├── Serialization/
            │   └── Interop/                             # Planned (Part 3)
            │       ├── NativeMethods.cs                 # LibraryImport declarations
            │       ├── NativeLibraryLoader.cs
            │       ├── CosmosCompletion.cs              # async bridge
            │       ├── NativeError.cs                   # error translation
            │       ├── NativeLogPump.cs                 # tracing pump
            │       ├── Handles/
            │       │   ├── CosmosRuntimeHandle.cs
            │       │   ├── CosmosClientHandle.cs
            │       │   ├── CosmosResponseHandle.cs
            │       │   └── ...
            │       └── Marshalling/
            │           ├── Utf8.cs
            │           └── SpanWriter.cs
            ├── tests/                                   # One sub-folder per test project
            │   ├── Azure.Data.Cosmos.Tests/             # Unit tests (NUnit); snippet code under Samples/
            │   ├── Azure.Data.Cosmos.Emulator.Tests/    # Planned
            │   ├── Azure.Data.Cosmos.Interop.Tests/     # Planned — FFI contract tests + test-only native shim
            │   └── Azure.Data.Cosmos.Parity.Tests/      # Planned — twin-client V3↔V4 comparison
            ├── samples/                                 # Planned — sample markdown
            │   ├── README.md
            │   ├── Sample1_HelloWorld.md
            │   ├── Sample2_Crud.md
            │   ├── Sample3_Query.md
            │   └── ...
            ├── perf/                                    # Planned — Azure SDK perf framework
            │   └── Azure.Data.Cosmos.Perf.csproj
            └── runtimes/                                # Planned — staged from native CI artifacts; not committed
                ├── win-x64/native/cosmos_native.dll
                ├── win-arm64/native/cosmos_native.dll
                ├── linux-x64/native/libcosmos_native.so
                ├── linux-arm64/native/libcosmos_native.so
                ├── osx-x64/native/libcosmos_native.dylib
                └── osx-arm64/native/libcosmos_native.dylib
```

This layout follows the `azure-sdk-for-net` standard: `api/`, `src/`, `tests/`, `samples/`, `perf/`, top-level `README.md` + `CHANGELOG.md`, and a `.slnx` per package. Repository-specific notes:

- **Pipelines are per service directory, not per package.** `sdk/cosmosdb/ci.yml` sets `SDKType: client`, and `sdk/cosmosdb/service.projects` limits that pipeline to `Azure.Data.Cosmos*` projects. The generated `ci.mgmt.yml` is left unchanged; it sets no `SDKType` (defaults to `all`), so it also builds and tests this package but doesn't release it.- **Test matrix.** The repository's default matrix runs tests with `--framework net8.0`, `net9.0`, and `net462`, which fail for a `net10.0`-only project. `ci.yml` therefore points `MatrixConfigs` at `sdk/cosmosdb/platform-matrix.json` (Linux, Windows, macOS on `net10.0`); the PR pipeline picks this up from package properties. For pipelines that still use the default matrix (`ci.mgmt.yml`), `service.projects` drops `Azure.Data.Cosmos*` projects from any leg whose target framework isn't `net10.0`.- **Target frameworks** are set once in `Azure.Data.Cosmos/Directory.Build.props` (`net10.0` for src and tests). Without it, the repository defaults would add `net8.0` and `netstandard2.0` to the library, and `net8.0`, `net9.0`, and `net462` (on Windows) to test projects.
- **Test project names must end in `.Tests`** (for example `Azure.Data.Cosmos.Emulator.Tests`) for the engineering system to classify them as test projects. Each lives in its own sub-folder so SDK-style globbing doesn't pull one project's files into another.
- **Samples** follow the repository snippet convention: markdown under `samples/`, compiled snippet code under `tests/Azure.Data.Cosmos.Tests/Samples/`, kept in sync by `eng/scripts/Update-Snippets.ps1`.
- **Ownership:** `.github/CODEOWNERS` has no entry covering `sdk/cosmosdb/Azure.Data.Cosmos/` yet.

### 6.3 Native Library Loading

- Use `NativeLibrary.SetDllImportResolver` to control which native binary is loaded.
- Probe `runtimes/<RID>/native/` first; fall back to system path.
- On load: call `cosmos_native_abi_version()` and verify it matches the managed-side expected major version. Fail fast with a clear error if mismatched.
- Wrap `cosmos_runtime_init` in a singleton (one runtime per process by default; configurable via `CosmosClientOptions`).

### 6.4 SafeHandle Pattern

```csharp
internal sealed partial class CosmosClientHandle : SafeHandle
{
    public CosmosClientHandle() : base(IntPtr.Zero, ownsHandle: true) { }
    public override bool IsInvalid => handle == IntPtr.Zero;

    protected override bool ReleaseHandle()
    {
        NativeMethods.cosmos_client_release(handle);
        return true;
    }
}
```

Every native object that survives a single call uses a `SafeHandle`. Per-call objects (responses, errors) use `SafeHandle` too — wrapped in `using` for deterministic release.

### 6.5 Serialization

- Default: `System.Text.Json` with a Cosmos-tuned `JsonSerializerOptions` (camelCase, ignore nulls on write, etc.).
- Items are serialized **in managed memory** to a pooled `ArrayBufferWriter<byte>` (UTF-8) and handed to native as `(ptr, len)`.
- Responses come back as a UTF-8 span pointing into the response handle's owned buffer; deserialized in managed.
- Pluggable: `CosmosClientOptions.Serializer` allows custom (e.g. `Newtonsoft.Json`) implementations, mirroring V3.

### 6.6 Diagnostics

- Native exposes a `cosmos_response_diagnostics_json(...)` returning a structured JSON blob (regions contacted, retries, latencies, request charges).
- Managed wraps this into a `CosmosDiagnostics` object with the V3 contract preserved (string `ToString()`, structured properties).
- Native logs flow through `cosmos_runtime_set_log_callback` into an `EventSource` (`Azure-Cosmos-Operation`) so they show up in standard .NET tracing tooling (PerfView, dotnet-trace, OpenTelemetry).

### 6.7 Exception Translation

| Native | Managed |
|---|---|
| `cosmos_status_t != 0` with `cosmos_error_t*` having HTTP status | `CosmosException` (StatusCode, SubStatusCode, ActivityId, RetryAfter, Diagnostics) |
| Cancellation observed via `CancellationToken` registration | `OperationCanceledException` |
| ABI-level failure (panic, invariant) | `CosmosInteropException` (new; non-retriable, fatal) |

Never let exceptions propagate **across** the FFI boundary in either direction.

### 6.8 Cancellation

`CancellationToken` is bridged by registering a callback that calls `cosmos_request_cancel(request_handle)`. The Rust side observes the cancellation, aborts in-flight HTTP, and completes the callback with a cancellation error.

---

## 7. Build & Packaging

### 7.1 Native Binary Sourcing

- Rust `cosmos_native` shim is built in the **`azure-cosmos-native`** repository on its own pipeline.
- That pipeline publishes signed binaries per RID to an internal Azure Artifacts feed.
- The `azure-sdk-for-net` build for `Azure.Data.Cosmos` pulls a pinned version (recorded in `sdk/cosmosdb/Azure.Data.Cosmos/native-versions.props`) and stages assets into `sdk/cosmosdb/Azure.Data.Cosmos/runtimes/<rid>/native/` before pack. Staged binaries aren't committed.
- The `Azure.Data.Cosmos.csproj` declares each native asset as `<Content>` with `PackagePath="runtimes/<rid>/native/"` so .NET runtime resolves them automatically.

### 7.2 NuGet Layout

```
Azure.Data.Cosmos.<version>.nupkg
├── lib/
│   └── net10.0/Azure.Data.Cosmos.dll    # Next .NET release added when it ships; oldest dropped
└── runtimes/
    ├── win-x64/native/cosmos_native.dll
    ├── win-arm64/native/cosmos_native.dll
    ├── linux-x64/native/libcosmos_native.so
    ├── linux-arm64/native/libcosmos_native.so
    ├── osx-x64/native/libcosmos_native.dylib
    └── osx-arm64/native/libcosmos_native.dylib
```

### 7.3 Pipelines

- Builds run on the standard `azure-sdk-for-net` engineering system (`eng/`). Registration is via `sdk/cosmosdb/ci.yml` (`SDKType: client`, net10.0-only `MatrixConfigs` from `sdk/cosmosdb/platform-matrix.json`), with `sdk/cosmosdb/service.projects` limiting that pipeline to `Azure.Data.Cosmos*` projects. The generated `sdk/cosmosdb/ci.mgmt.yml` stays as is.
- No step in the standard templates downloads native artifacts today. A pre-build step that pulls the pinned `cosmos_native` artifacts from the internal feed has to be added (Part 1).
- Emulator-driven integration tests can reuse the existing `eng/common/pipelines/templates/steps/cosmos-emulator.yml` step. Live tests are registered through `sdk/cosmosdb/tests.yml` (planned) with resources in `sdk/cosmosdb/test-resources.json`.
- BinSkim scanning in `eng/pipelines/templates/stages/1es-redirect.yml` analyzes every `.dll`/`.exe`; the native binaries must pass it or be explicitly excluded there (as is done for a few third-party native DLLs today).
- Release pipeline reuses the standard Azure SDK release pipeline (signing, NuGet push, GitHub release).

### 7.4 Signing

- Native binaries are Authenticode-signed (Windows) and notarized (macOS) by the **`azure-cosmos-native`** pipeline before publication to the consumed feed.
- Managed `Azure.Data.Cosmos.dll` is strong-named via the standard `azure-sdk-for-net` signing keys.

---

## 8. Testing Strategy

| Layer | Tests | Coverage |
|---|---|---|
| **Interop unit** | A test-only native shim (in C or Rust) that lets us validate marshalling, callbacks, cancellation, error translation deterministically without hitting any backend. | High; runs on every PR. |
| **Managed unit** | NUnit tests (repository standard) in `Azure.Data.Cosmos.Tests` for facade types, options validation, serialization, LINQ-to-query. Native methods mocked with Moq behind an `INativeApi` seam. | High. |
| **Emulator integration** | Scenarios ported from V3's [Microsoft.Azure.Cosmos.EmulatorTests](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/main/Microsoft.Azure.Cosmos/tests/Microsoft.Azure.Cosmos.EmulatorTests), in `Azure.Data.Cosmos.Emulator.Tests`. Runs full V4 stack against the Cosmos DB Emulator. | Medium-high; CI gate. |
| **Live multi-region** | Off by default; gated to a manual lab pipeline. Validates failover, hedging, retry behavior delegated to Rust. | Pre-release gate. |
| **Contract / parity** | A test suite that runs the **same scenarios** against V3 and V4, compares observable behavior (status codes, sub-status, diagnostics shape, retry-after honor). | Pre-release gate. |
| **AOT / trim** | The engineering system's AOT compatibility check (`eng/scripts/compatibility/Check-AOT-Compatibility.ps1`) publishes a `PublishAot=true` app against the package; it must pass with no warnings. | CI gate. |
| **Fuzz / soak** | Long-running soak in a scale lab to catch leaks (handle, native memory, GCHandle). Use `dotnet-counters` and Rust `tracing` to monitor. | Pre-release gate. |

A new project, `tests/Azure.Data.Cosmos.Interop.Tests`, hosts a tiny `cosmos_native_test.{dll,so,dylib}` exporting the same ABI for deterministic tests.

---

## 9. Compatibility, Versioning, Side-by-side

- **Repository:** Hosted in [`azure-sdk-for-net`](https://github.com/Azure/azure-sdk-for-net) under `sdk/cosmosdb/Azure.Data.Cosmos/`. V3 remains in [`azure-cosmos-dotnet-v3`](https://github.com/Azure/azure-cosmos-dotnet-v3).
- **Side-by-side:** V4 ships as a **new package id `Azure.Data.Cosmos`** (preview → GA), independent of V3's `Microsoft.Azure.Cosmos`. Both packages can be installed in the same project.
- **Namespace:** `Azure.Data.Cosmos` (Azure SDK convention). Distinct from V3's `Microsoft.Azure.Cosmos` — no aliasing required.
- **Target frameworks:** the two most recent .NET releases, starting with `net10.0` only; no .NET Framework or .NET Standard. Set in `Azure.Data.Cosmos/Directory.Build.props`. The repository requires Azure SDK architect approval for client libraries that drop `netstandard2.0`.
- **ABI versioning:** Managed expects `cosmos_native_abi_version() >= MinAbi && < MaxAbi+1`. Bumping ABI major requires a coordinated release of native and managed.
- **Public API versioning:** Same SemVer rules used today. The public surface is tracked in `api/Azure.Data.Cosmos.net10.0.cs` (regenerated with `eng/scripts/Export-API.ps1`) and, after the first GA, enforced by ApiCompat through `ApiCompatVersion` in the csproj.
- **Migration guide:** Authored alongside V4 GA as `MigrationGuide.md` at the package root (as `Azure.Data.Tables` does). Highlights breaking changes vs V3 and the gateway-only constraint.

---

## 10. Risks and Mitigations

| Risk | Impact | Mitigation |
|---|---|---|
| Rust driver feature gaps vs V3 (e.g. specific query features, telemetry fields). | API parity hole; can block GA. | Build a parity matrix early. Track gaps as work items in the Rust repo. Use **preview status** until matrix is green. |
| Native crash brings down the .NET process. | Severe — hard to diagnose. | All native code wrapped in `catch_unwind` in Rust; ABI returns error code instead of unwinding. Crash-dump tests in CI. |
| Marshalling overhead dominates small-payload latency. | Perf regression vs V3. | Use UTF-8 spans and pooled buffers. Benchmark V4 in `perf/Azure.Data.Cosmos.Perf` against V3 baselines from [Microsoft.Azure.Cosmos.Performance.Tests](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/main/Microsoft.Azure.Cosmos/tests/Microsoft.Azure.Cosmos.Performance.Tests). |
| GCHandle leaks on cancelled operations. | Slow memory leak in long-running services. | Use a single `CompletionRegistry` keyed by request id; ensure the registry frees on **every** terminal callback (success, error, cancel). Add leak tests. |
| Native binary distribution / signing complexity. | Ship blocker per OS/arch. | Establish RID matrix and signing workflow in pipeline templates **before** writing the managed code. |
| AOT/trim incompatibility. | Loss of a key V4 selling point. | `LibraryImport` source generators + no reflection in the interop layer; AOT smoke test in CI. |
| Diagnostics shape divergence between V3 and V4. | Customer telemetry breakage. | Define diagnostics JSON schema in the ABI doc; contract-test against V3 outputs. |
| Gateway-only constraint surprises customers. | Adoption friction. | Up-front documentation, package description, and `CosmosClientOptions.ConnectionMode` only accepts `Gateway`; throw with a clear message otherwise. |

---

## 11. Phased Development Plan

The plan is broken into **eight phases**. Each phase has clear exit criteria, no time estimates per project convention.

### Phase 0 — Foundations & Alignment

**Exit criteria:**
- [ ] This design doc reviewed and signed off by SDK + Rust + product leads.
- [ ] V4 vs V3 public API delta proposal drafted; API review scheduled.
- [ ] RID matrix locked: `win-x64`, `win-arm64`, `linux-x64`, `linux-arm64`, `osx-x64`, `osx-arm64`.
- [ ] Native binary distribution & signing pipeline owned and prototyped (round-trip a hello-world Rust `.dll`/`.so`/`.dylib` into a NuGet package).

### Phase 1 — Native ABI Specification

**Exit criteria:**
- [ ] `cosmos_native.h` v0.1 committed under `sdk/cosmosdb/Azure.Data.Cosmos/native/` (with a mirror in this design doc) covering: lifecycle, client create/release, item CRUD, query, change feed, batch, response, error, diagnostics, log callback, cancellation, ABI version probe.
- [ ] Async/cancellation/error model documented with examples.
- [ ] Diagnostics JSON schema versioned and committed.
- [ ] Rust shim crate skeleton exists and produces the header via `cbindgen`, validated against the committed copy.

### Phase 2 — Managed Skeleton & Interop Plumbing

**Exit criteria:**
- [x] New project `Azure.Data.Cosmos.csproj` builds for `net10.0`.
- [ ] `LibraryImport` declarations for the Phase 1 ABI compile and pass source-generator validation.
- [ ] `NativeLibrary.SetDllImportResolver` correctly loads the binary from `runtimes/<rid>/native/` in dev and packed scenarios.
- [ ] `cosmos_native_abi_version()` probe runs on first use; mismatched version throws a clean `CosmosInteropException`.
- [ ] All `SafeHandle` types implemented with finalizer tests.
- [ ] `CosmosCompletion` async bridge round-trips a no-op call with a test-only native shim.

### Phase 3 — Item CRUD End-to-End

**Exit criteria:**
- [ ] `CosmosClient`, `Database`, `Container` types implemented with constructors/factory methods.
- [ ] Item Create / Read / Replace / Upsert / Patch / Delete fully functional against the emulator.
- [ ] `CosmosException` translation complete (status, sub-status, activity id, retry-after, diagnostics).
- [ ] `CancellationToken` flows native-side and aborts in-flight requests.
- [ ] Diagnostics object populated from native diagnostics JSON; `ToString()` parity-tested vs V3 for the same operations.
- [ ] Emulator test suite covers item CRUD with green CI.

### Phase 4 — Query & Change Feed

**Exit criteria:**
- [ ] `AsyncPageable<T>` implementation backed by `cosmos_query_*` ABI.
- [ ] Continuation tokens round-trip correctly (string-typed; opaque to managed).
- [ ] LINQ provider produces a `QueryDefinition` understood by Rust query pipeline.
- [ ] Change feed (latest-version + all-versions-and-deletes) functional via `cosmos_changefeed_*`.
- [ ] Emulator parity tests for queries from V3's [Microsoft.Azure.Cosmos.Samples/Usage/Queries](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/main/Microsoft.Azure.Cosmos.Samples/Usage/Queries).

### Phase 5 — Batch, Bulk, Auth Modes

**Exit criteria:**
- [ ] `TransactionalBatch` builder + execute fully functional.
- [ ] Bulk execution path implemented (managed-side batching feeds into the Rust driver bulk pipeline).
- [ ] Auth: account key, resource token, AAD (`TokenCredential`) all wired through `cosmos_credential_t`.
- [ ] Account-management surface (create database, create container, throughput) implemented.

### Phase 6 — Diagnostics, Telemetry, OTel

**Exit criteria:**
- [ ] Native log pump → `EventSource` and OpenTelemetry-friendly traces.
- [ ] Activity propagation: `System.Diagnostics.Activity` correlation IDs flow into native and surface on responses.
- [ ] Metrics surface (request charge, latency, region) reachable from `CosmosDiagnostics` and from `Meter` instrumentation.
- [ ] OTel sample added under `sdk/cosmosdb/Azure.Data.Cosmos/samples/`.

### Phase 7 — Hardening, Performance, AOT

**Exit criteria:**
- [ ] Soak test (24h, multi-region) passes with stable handle/memory counts.
- [ ] Benchmarks in `perf/Azure.Data.Cosmos.Perf` within agreed bounds vs V3 gateway mode.
- [ ] Crash-injection tests (forced panic in Rust) produce a clean `CosmosInteropException` with no process crash.
- [ ] The engineering system's AOT compatibility check passes for `Azure.Data.Cosmos` with no warnings.

### Phase 8 — Preview, Feedback, GA

**Exit criteria:**
- [ ] Preview NuGet (`-preview.N`) published; migration guide drafted.
- [ ] Customer / internal partner adoption signed off (≥ 2 design partners).
- [ ] Parity matrix vs V3 fully green (or each gap explicitly waived in the migration guide).
- [ ] Security review and threat-model review completed for the FFI boundary.
- [ ] GA release published; V4 public docs live.

---

## 12. Detailed Implementation Plan (Part-by-Part)

This section converts the phased plan in Section 11 into concrete, ordered implementation parts. Each part lists **what will be built**, the **files / projects touched**, and **how it will be verified**. Parts are sequential where dependencies require it; independent work within a part can be parallelized.

### Part 1 — Repo & Pipeline Foundations

**What will be built:**
1. **Done.** New package directory `sdk/cosmosdb/Azure.Data.Cosmos/` in the [`azure-sdk-for-net`](https://github.com/Azure/azure-sdk-for-net) monorepo, registered in `sdk/cosmosdb/ci.yml` (`SDKType: client`, net10.0-only test matrix in `sdk/cosmosdb/platform-matrix.json`) with `sdk/cosmosdb/service.projects` filtering the build to `Azure.Data.Cosmos*` projects and keeping them out of non-`net10.0` legs.
2. **Done.** Standard Azure SDK package skeleton: `src/Azure.Data.Cosmos.csproj`, `Azure.Data.Cosmos.slnx`, `Directory.Build.props` (`net10.0` only), `README.md`, `CHANGELOG.md`, `api/`, `src/`, `tests/Azure.Data.Cosmos.Tests/`. `samples/` and `perf/` are added with the first sample and benchmark.
3. New `sdk/cosmosdb/Azure.Data.Cosmos/native-versions.props` pinning the consumed `cosmos_native` build version (single source of truth for native ↔ managed pairing).
4. CI scaffolding on top of the standard `eng/` pipelines:
   - New pre-build step (not in the standard templates today) that downloads pinned native artifacts (per RID) from the internal feed into `sdk/cosmosdb/Azure.Data.Cosmos/runtimes/<rid>/native/`.
   - `sdk/cosmosdb/tests.yml` for live/emulator test runs.
   - Standard release pipeline used as-is.
5. `.github/CODEOWNERS` entry for `/sdk/cosmosdb/Azure.Data.Cosmos/`.
6. End-to-end "hello-world" pipeline: a stub managed assembly P/Invokes one symbol from a stub native binary; pack + restore + run on each RID confirms the loader + packaging works.

**Verification:**
- Nightly pipeline green on all 6 RIDs.
- A consumer test project restores the local `.nupkg` and successfully calls the stub native function.

---

### Part 2 — Native ABI Specification (Header First)

**What will be built:**
1. `sdk/cosmosdb/Azure.Data.Cosmos/native/cosmos_native.h` — committed C header. Initial scope:
   - ABI version probe.
   - Runtime lifecycle + log callback.
   - Client create / release.
   - Item CRUD (create, read, replace, upsert, patch, delete).
   - Query create / next page / release.
   - Change feed create / next page / release.
   - Batch create / add op / execute / release.
   - Response inspection (status, body, header, diagnostics JSON).
   - Error inspection / release.
   - Cancellation.
2. `sdk/cosmosdb/Azure.Data.Cosmos/design/V4-NativeAbi.md` describing: calling conventions, threading, lifetime rules, error model, async/cancellation contract, diagnostics JSON schema, log event schema.
3. Coordination with the Rust team to produce `cbindgen` output that exactly matches the committed header (CI gate compares them).

**Verification:**
- Header compiles cleanly under MSVC, Clang, GCC.
- `cbindgen`-generated header diff is empty against the committed copy.
- Doc reviewed and signed off by both .NET and Rust leads.

---

### Part 3 — Managed Interop Skeleton

**What will be built:**
1. `src/Azure.Data.Cosmos.csproj` (exists) gains the interop code below under `src/Interop/`.
2. `Interop/NativeMethods.cs` — `LibraryImport` declarations for every entry point from Part 2. Marked `partial`; source-generated marshallers.
3. `Interop/NativeLibraryLoader.cs` — installs `NativeLibrary.SetDllImportResolver` to probe `runtimes/<RID>/native/` and validates `cosmos_native_abi_version()` on first load.
4. `Interop/Handles/*` — one `SafeHandle` subclass per native opaque type (`CosmosRuntimeHandle`, `CosmosClientHandle`, `CosmosResponseHandle`, `CosmosErrorHandle`, `CosmosQueryHandle`, `CosmosChangeFeedHandle`, `CosmosBatchHandle`).
5. `Interop/CosmosCompletion.cs` — async bridge:
   - Holds a `TaskCompletionSource<ResponseHandle>`.
   - Allocates a `GCHandle` for the native callback `ctx`.
   - `[UnmanagedCallersOnly]` static callback signature.
6. `Interop/NativeError.cs` — translates `cosmos_error_t*` → `CosmosException` (status, sub-status, activity id, retry-after, diagnostics).
7. `Interop/Marshalling/Utf8.cs` — pooled UTF-8 buffer writer helpers; zero-copy span conversions.
8. `Interop/NativeLogPump.cs` — registers a single `cosmos_log_callback` and forwards events to an `EventSource` (`Azure-Cosmos-V4`).

**Verification:**
- Unit tests in `Azure.Data.Cosmos.Tests` exercise loader version-mismatch, `SafeHandle` finalization, GCHandle lifetime, and error translation.
- A test-only native shim (Part 4) round-trips a no-op completion call asynchronously.

---

### Part 4 — Test-Only Native Shim & Interop Test Harness

**What will be built:**
1. New project `tests/Azure.Data.Cosmos.Interop.Tests/` with a `native_shim/` sub-folder — a tiny C (or Rust) library that implements the same `cosmos_native.h` ABI deterministically for tests:
   - Configurable per-call latency.
   - Programmable success / error / cancellation outcomes.
   - Counters for handle leaks (created vs released).
   - Echo-back of input payloads to validate marshalling.
2. CMake / cargo build wired into the test pipeline; outputs placed where the loader will find them.
3. NUnit project `Azure.Data.Cosmos.Interop.Tests` exercising:
   - 100k concurrent completions to validate the async bridge under load.
   - Cancellation timing (token cancelled before / during / after the call).
   - Forced "panic" path (shim returns a fatal status) → `CosmosInteropException`.
   - Long-running soak (handle / GCHandle counts stable).

**Verification:**
- Soak test runs 1h in nightly with stable counts.
- Cancellation tests pass on all RIDs.

---

### Part 5 — `CosmosClient` & Account-Level APIs

**What will be built:**
1. Public types: `CosmosClient`, `CosmosClientOptions`, `CosmosClientBuilder` (if kept), `Database`, `DatabaseProperties`, `DatabaseResponse`, `ThroughputProperties`, `Headers`, `RequestOptions`.
2. Constructors:
   - `CosmosClient(string connectionString, CosmosClientOptions?)`.
   - `CosmosClient(string accountEndpoint, TokenCredential, CosmosClientOptions?)`.
   - `CosmosClient(string accountEndpoint, AzureKeyCredential, CosmosClientOptions?)`.
3. Internally: each constructor parses options, builds a `cosmos_credential_t`, calls `cosmos_client_create`, stores a `CosmosClientHandle`.
4. `IAsyncDisposable` semantics — releases the handle and the runtime ref-count.
5. `ConnectionMode` validated to `Gateway` only; throw `NotSupportedException` otherwise with a clear message.
6. Account / database management surface: create/read/delete database, list databases, throughput operations.

**Verification:**
- Unit tests with mocked native API (`INativeApi` seam).
- Emulator integration test in `Azure.Data.Cosmos.Emulator.Tests` creates/reads/deletes databases.

---

### Part 6 — Item CRUD End-to-End

**What will be built:**
1. Public `Container` type and `ItemRequestOptions`, `ItemResponse<T>`, `PartitionKey`, `PatchOperation` types.
2. Implementation of:
   - `CreateItemAsync<T>`, `ReadItemAsync<T>`, `ReplaceItemAsync<T>`, `UpsertItemAsync<T>`, `PatchItemAsync<T>`, `DeleteItemAsync<T>`.
   - Stream-overload variants (`*StreamAsync`) that bypass managed serialization.
3. Serialization layer:
   - Default `System.Text.Json`-backed `ICosmosSerializer` writing to a pooled `ArrayBufferWriter<byte>` (UTF-8).
   - Pluggable via `CosmosClientOptions.Serializer`.
4. Response decoding:
   - Read body span from `cosmos_response_body`, deserialize, copy headers needed for `ItemResponse<T>`.
5. Diagnostics:
   - Read `cosmos_response_diagnostics_json`, parse into a typed `CosmosDiagnostics` object.
6. Exception translation wired in for non-success responses.

**Verification:**
- Emulator parity tests for each CRUD verb against the same scenarios used by V3's [Microsoft.Azure.Cosmos.Samples/Usage/ItemManagement](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/main/Microsoft.Azure.Cosmos.Samples/Usage/ItemManagement).
- Diagnostics `ToString()` parity test vs V3 (golden-file based; fields tolerant of timing).
- Cancellation test: cancellation token cancels in-flight request and surfaces `OperationCanceledException`.

---

### Part 7 — Query & LINQ

**What will be built:**
1. `QueryDefinition` (parameter binding), `QueryRequestOptions`.
2. `AsyncPageable<T>` and `Page<T>` types (matches Azure SDK convention).
3. Backing implementation:
   - `cosmos_query_create` once per `GetItemQueryIterator` call.
   - `cosmos_query_next_page` per `IAsyncEnumerator<T>` move.
   - Continuation tokens are opaque `string`s round-tripped to/from native.
4. LINQ provider:
   - Reuse the existing V3 LINQ-to-SQL translator if cleanly extractable (lives in V3's [Microsoft.Azure.Cosmos/src/Linq](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/main/Microsoft.Azure.Cosmos/src/Linq)); otherwise fork into the V4 namespace.
   - LINQ produces a `QueryDefinition` — Rust pipeline executes it.
5. Streaming overloads (`GetItemQueryStreamIterator`).

**Verification:**
- Port the query test suite from V3's `Microsoft.Azure.Cosmos.EmulatorTests` query tests to `Azure.Data.Cosmos.Emulator.Tests`.
- LINQ → SQL string equivalence tests against V3 outputs.

---

### Part 8 — Change Feed

**What will be built:**
1. `ChangeFeedStartFrom`, `ChangeFeedMode` (LatestVersion, AllVersionsAndDeletes), `ChangeFeedRequestOptions`, `ChangeFeedIterator<T>`.
2. Backing implementation over `cosmos_changefeed_*`.
3. Continuation token handling (string).
4. Change feed processor (`ChangeFeedProcessorBuilder`) — managed-side orchestration of partitioned iterators, lease store reads via the same V4 `Container` APIs.

**Verification:**
- Emulator tests that exercise both modes and continuation resumption.
- Long-running processor test against a feed producer.

---

### Part 9 — TransactionalBatch & Bulk

**What will be built:**
1. `TransactionalBatch` builder and `TransactionalBatchResponse`.
2. Backing via `cosmos_batch_create` / `cosmos_batch_add_operation` / `cosmos_batch_execute`.
3. Bulk execution path:
   - `CosmosClientOptions.AllowBulkExecution = true` opt-in.
   - Managed-side batcher groups operations and feeds into the Rust driver bulk pipeline (or, if the Rust driver exposes bulk natively, just routes through it).
   - Per-item `Task<ItemResponse<T>>` completions resolved as native callbacks fire.

**Verification:**
- Emulator parity tests for batch (mixed CRUD, partial failure, ETag conflicts).
- Bulk perf benchmark in `perf/Azure.Data.Cosmos.Perf` vs a V3 baseline.

---

### Part 10 — Diagnostics, Telemetry, OpenTelemetry

**What will be built:**
1. Finalized `CosmosDiagnostics` type with parity fields vs V3.
2. `EventSource` (`Azure-Cosmos-V4`) emits structured events for: request start/stop, retry, region failover, native log entries.
3. `System.Diagnostics.Activity` integration:
   - Outgoing requests carry the current `Activity` id; native echoes it back into diagnostics.
4. `Meter` instruments for: request charge, latency, retry count, region.
5. OTel sample under `sdk/cosmosdb/Azure.Data.Cosmos/samples/` demonstrating exporter wiring (Console + OTLP).

**Verification:**
- OTel sample produces expected spans / metrics.
- Diagnostics schema versioned and contract-tested.

---

### Part 11 — Hardening: AOT, Trim, Perf, Crash-safety

**What will be built:**
1. Ensure all `LibraryImport` partials produce no AOT/trim warnings; annotate any reflection with `RequiresUnreferencedCode` if unavoidable (target: zero warnings).
2. Keep the package passing the engineering system's AOT compatibility check (`eng/scripts/compatibility/Check-AOT-Compatibility.ps1`), which publishes a `PublishAot=true` app against it in CI. Don't set `AotCompatOptOut`.
3. Benchmarks in `perf/Azure.Data.Cosmos.Perf` (Azure SDK perf framework) for:
   - Point read / write small payload.
   - Query first-page latency.
   - Bulk throughput.
4. Compare results against V3 gateway-mode baseline; record regressions, optimize hot paths (buffer pooling, span avoidance of allocations).
5. Crash-injection tests: shim produces fatal status / simulated panic — assert no process crash and clean `CosmosInteropException`.
6. 24-hour soak in scale lab measuring handle counts, GCHandle counts, native RSS.

**Verification:**
- AOT publish succeeds with no warnings.
- Benchmark report attached to the PR; regressions ≤ agreed threshold.
- Soak passes with stable counts.

---

### Part 12 — Parity Test Suite vs V3

**What will be built:**
1. New project `tests/Azure.Data.Cosmos.Parity.Tests`. It references V3's `Microsoft.Azure.Cosmos` package, which needs a `PackageVersion` entry in `eng/centralpackagemanagement/Directory.Packages.props` (none exists today).
2. Test fixture creates **two clients** for each scenario — one V3, one V4 — pointed at the same emulator account.
3. Scenarios cover: CRUD, query, change feed, batch, throttling, conflict, not-found, large items, special characters, multi-PK.
4. Assertions on:
   - HTTP status code + sub-status code.
   - Response headers preserved (request charge, etag, session token, activity id).
   - Diagnostics JSON shape (field presence; values tolerant of timing).
5. Output: a published parity matrix (markdown) consumed by Section 11 Phase 8 exit criteria.

**Verification:**
- Parity matrix published per nightly run.
- Any red cell either fixed or explicitly waived in `sdk/cosmosdb/Azure.Data.Cosmos/MigrationGuide.md`.

---

### Part 13 — Documentation, Samples, Migration Guide

**What will be built:**
1. `sdk/cosmosdb/Azure.Data.Cosmos/MigrationGuide.md` — every breaking change vs V3, mapped to the new V4 API.
2. `sdk/cosmosdb/Azure.Data.Cosmos/design/V4-NativeAbi.md` — finalized, tagged with the released ABI version.
3. Public API listing under `sdk/cosmosdb/Azure.Data.Cosmos/api/` (generated via the standard `azure-sdk-for-net` API tooling — `eng/scripts/Export-API.ps1`).
4. Samples under `sdk/cosmosdb/Azure.Data.Cosmos/samples/` covering: getting started, CRUD, query, change feed, batch, AAD auth, OTel. Snippet code lives in `tests/Azure.Data.Cosmos.Tests/Samples/` and is synced into the markdown with `eng/scripts/Update-Snippets.ps1`.
5. README updates linking to V3 vs V4 guidance.

**Verification:**
- Samples run as part of nightly CI.
- Doc review by DX writer.

---

### Part 14 — Preview Release & Feedback

**What will be built:**
1. Publish `Azure.Data.Cosmos <x.y.z>-preview.1` to NuGet via the standard `azure-sdk-for-net` release pipeline.
2. Internal partner onboarding: pair with ≥ 2 design partners, capture feedback in tracked issues.
3. Iterate on API surface (preview window allows breaking changes) until partner sign-off.

**Verification:**
- Both partners able to migrate a real workload to V4 preview.
- Open issue triage burned down to zero blockers.

---

### Part 15 — GA & Maintenance Posture

**What will be built:**
1. GA release of V4.
2. Lock public API surface (contract files become immutable per SemVer).
3. Define and document:
   - Native ↔ managed ABI version compatibility policy.
   - V3 vs V4 support matrix.
   - SLA for Rust driver fixes flowing into V4 patch releases.
4. Move V4 official pipeline to the same release cadence as V3.

**Verification:**
- GA release published.
- Support / on-call playbooks updated with V4-specific guidance (handle leak diagnosis, ABI mismatch errors, native crash dumps).

---

### Dependency Graph

```
Part 1 ─┬─► Part 2 ─► Part 3 ─┬─► Part 4 ─┐
        │                     │           │
        │                     ├─► Part 5 ─┼─► Part 6 ─┬─► Part 7 ─┐
        │                     │           │           │           │
        │                     │           │           ├─► Part 8 ─┤
        │                     │           │           │           │
        │                     │           │           └─► Part 9 ─┤
        │                     │           │                       │
        │                     │           └──────────────► Part 10┤
        │                     │                                   │
        └─────────────────────┴───────────────────────► Part 11 ──┤
                                                                  ▼
                                            Part 12 ─► Part 13 ─► Part 14 ─► Part 15
```

Parts 6–10 can run in parallel once Part 5 is done; Parts 11–13 can begin as soon as the corresponding feature parts (6–10) are functional.

---

## 13. Open Questions

1. **Package naming:** the scaffold uses `Azure.Data.Cosmos` for both the package id and root namespace (see D-8); still needs API review board confirmation.
2. **Single shared runtime vs per-client runtime** in Rust? Recommend single shared, but expose advanced opt-out.
3. **JSON serializer default:** lock to `System.Text.Json` only, or keep Newtonsoft compatibility shim in core?
4. **Encryption packages:** can their providers wrap the V4 client surface, or do they need a separate plumbing path through Rust?
5. **Per-Partition-Automatic-Failover (PPAF) parity:** confirm Rust driver supports the same gateway-mode PPAF/circuit-breaker semantics described in [PerPartitionAutomaticFailoverDesign.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/PerPartitionAutomaticFailoverDesign.md). Track gaps.
6. **Cross-region request hedging:** confirm parity with [Cross Region Request Hedging.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/Cross%20Region%20Request%20Hedging.md). Surface options in `CosmosClientOptions`.
7. **Rust source location & release cadence:** confirm publishing pipeline and version-pinning strategy.

---

## 14. Appendix — Decision Log

| # | Decision | Why |
|---|---|---|
| D-1 | Gateway mode only | Matches Rust driver capability; avoids reimplementing direct mode in Rust on day 1. |
| D-2 | C ABI (not COM, not C++/CLI) | Portable, no Windows-only dependency, easy to maintain. |
| D-3 | `LibraryImport` source generators | AOT/trim friendly; no runtime reflection in hot path. |
| D-4 | UTF-8 byte spans across the boundary | Eliminates UTF-16 conversions; matches Rust string model. |
| D-5 | Native does retry/partition routing | Single source of truth for resiliency policy across SDKs. |
| D-6 | Managed owns serialization & LINQ | Idiomatic .NET DX; type-system features (`IAsyncEnumerable`, `Span<T>`, JSON source generation). |
| D-7 | Public API close to V3 | Lower migration cost. Cleanups limited to deprecated/legacy surface. |
| D-8 | Package and root namespace `Azure.Data.Cosmos`, at `sdk/cosmosdb/Azure.Data.Cosmos/` | Namespace matches package id (Azure SDK convention); `sdk/cosmosdb/` is the existing Cosmos DB service directory. |
| D-9 | Target the two latest .NET releases (`net10.0` to start); no .NET Framework or .NET Standard | Native interop, `LibraryImport`, and AOT need modern .NET. Pending Azure SDK architect approval for dropping `netstandard2.0`. |
| D-10 | NUnit for all test projects | Repository standard; xUnit isn't in central package management. |

---

## 15. References

- [SdkDesign.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/SdkDesign.md) — current V3 architecture overview.
- [PerPartitionAutomaticFailoverDesign.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/PerPartitionAutomaticFailoverDesign.md) — gateway-mode failover semantics V4 must preserve.
- [Cross Region Request Hedging.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/Cross%20Region%20Request%20Hedging.md) — hedging behavior expected from the Rust driver.
- [observability.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/observability.md) — diagnostics conventions to mirror.
- [versioning.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/versioning.md) — V3 versioning rules.
- [Native driver POC](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/users/ananth/poc-native-async-spike/tools/Microsoft.Azure.Cosmos.NativeDriverPoc) — .NET host over the Rust `azure_data_cosmos_driver_native` crate.
- [Directory.Build.props](../Directory.Build.props) — package-level MSBuild settings (target frameworks).
- [ci.yml](../../ci.yml) and [service.projects](../../service.projects) — data-plane pipeline registration and project filter.

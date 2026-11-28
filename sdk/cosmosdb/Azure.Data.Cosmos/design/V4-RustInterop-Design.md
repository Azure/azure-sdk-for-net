# Cosmos DB .NET SDK V4 — Rust Driver Interop Design

<!-- cspell:ignore cbindgen cdylib Cdecl Conv Convs MSVC PPAF slnx staticlib -->

> Status: **Draft / Proposal**
> Scope: .NET SDK V4 that delegates request execution to the Azure Cosmos DB Rust driver (Gateway-mode only).
> Owners: Cosmos DB .NET SDK team
> Location: `sdk/cosmosdb/Azure.Data.Cosmos/design/` in `azure-sdk-for-net`. Ported from the [original draft](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/users/kundadebdatta/build_rust_interop_for_net/docs/V4-RustInterop-Design.md) in `azure-cosmos-dotnet-v3` and updated to this repository's layout.

---

## 1. Goals and Non-Goals

### 1.1 Goals

1. Build a new **`Azure.Data.Cosmos` (V4)** package whose public API surface is idiomatic .NET, but whose request execution path is routed through the **Cosmos DB Rust driver** via P/Invoke / FFI interop.
2. Support **Gateway mode only** (matches Rust driver capability today).
3. Deliver a single, **cross-platform** managed assembly, targeting `net10.0` at GA and then the two most recent .NET LTS releases (no .NET Framework or .NET Standard; see C-1), that loads the appropriate **native Rust library** (`.dll` / `.so` / `.dylib`) on Windows / Linux / macOS, x64 / arm64.
4. Preserve a familiar V3-like surface for: `CosmosClient`, `Database`, `Container`, `Item CRUD`, `Query`, `ChangeFeed`, `Batch (TransactionalBatch)`, `Bulk`.
5. Keep the **diagnostics, telemetry, and error contract** consistent with Cosmos DB conventions (`CosmosException`, `Diagnostics`, sub-status codes, retry-after, activity ids, region info).
6. Provide a stable, versioned **C ABI boundary** between managed and native — independent of internal Rust types.
7. Ship as a **NuGet package** with native binaries packed via runtime-specific folders (`runtimes/<rid>/native/`).

### 1.2 Non-Goals

- **Direct (TCP) mode** — the Rust driver is gateway-only; V4 will not expose direct mode.
- **Client-side encryption** packages on day 1 (`Microsoft.Azure.Cosmos.Encryption*`) — out of scope for V1; can be revisited later.
- **Bringing forward all V3 surface area verbatim.** V4 is a chance to clean up obsolete APIs, deprecated overloads, and legacy types.
- **Replacing V3.** V3 continues to ship and is supported; V4 is a separate, parallel package.
- **Hosting the Rust source in this repo.** The Rust SDK, driver, and native wrapper live in [`azure-sdk-for-rust` under `sdk/cosmos`](https://github.com/Azure/azure-sdk-for-rust/tree/main/sdk/cosmos); we consume signed/published binaries.

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
│  • Marshalling (UTF-8, byte views, error codes)          │
│  • Async bridge: native completion → TaskCompletionSource│
│  • Completion-queue pump (one thread per CQ)             │
└──────────────────────────────────────────────────────────┘
                     │  P/Invoke (LibraryImport, C ABI)
                     ▼
┌──────────────────────────────────────────────────────────┐
│  azurecosmosdriver.{dll|so|dylib}  (Rust C-ABI shim)     │
│  • Thin `extern "C"` wrappers over the Rust driver       │
│  • Stable, versioned C header (azurecosmosdriver.h)      │
└──────────────────────────────────────────────────────────┘
                     │  Rust function calls
                     ▼
┌──────────────────────────────────────────────────────────┐
│  azure_data_cosmos_driver (Rust driver crate)            │
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
| Marshalling style | **`LibraryImport` (source-generated)** (the POC uses `DllImport`) | Trim/AOT friendly, no reflection, faster than legacy `DllImport`. |
| Async bridge | **Completion queue + one pump thread per queue + `TaskCompletionSource`** (as in the POC) | No callbacks cross the FFI boundary: Rust posts completions and the host decides how to schedule them, so no managed code runs on Rust threads. |
| Buffer handoff | **NUL-terminated UTF-8 for names/ids; byte views (pointer + length) for bodies** | Rust is UTF-8 native; the library copies borrowed buffers during submit, so they only need to stay valid for one call. |
| Object lifetime | **`SafeHandle` per native object** (the POC uses raw `IntPtr` with a staged build and ordered `Dispose`) | Deterministic cleanup, finalizer safety, matches GC semantics. |
| Versioning | **Pin one exact native release; `cosmos_version()` available for a load-time check** (unused in the POC; Q8) | Upstream uses the native crate's SemVer as the compatibility contract. |
| Error model | Synchronous calls return `CosmosErrorCode`; async failures arrive inline on the completion (status, sub-status, activity id, session token, etag, retry-after) → managed exception | Avoids exceptions across FFI; preserves rich error details. |
| Logging | **No logging callback** (the ABI is callback-free); managed tracing is emitted from completion and diagnostics data | Keeps the boundary callback-free; single .NET diagnostics pipeline (`EventSource`, OpenTelemetry). |

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

The C header is the contract. The Rust crate [`azure_data_cosmos_driver_native`](https://github.com/Azure/azure-sdk-for-rust/tree/main/sdk/cosmos/azure_data_cosmos_driver_native) generates it with `cbindgen` and checks it in upstream as [`include/azurecosmosdriver.h`](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/azure_data_cosmos_driver_native/include/azurecosmosdriver.h). We vendor the copy that matches the pinned native release at `sdk/cosmosdb/Azure.Data.Cosmos/native/azurecosmosdriver.h` for review/diffing.

> This section follows the binding in the [native driver POC](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/users/ananth/poc-native-async-spike/tools/Microsoft.Azure.Cosmos.NativeDriverPoc/README.md), which targets the header from Rust [PR #4515](https://github.com/Azure/azure-sdk-for-rust/pull/4515) (commit `4be377483`). The model is described upstream in [spec 0019](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/specs/0019-native-wrapper.md), [spec 0020](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/specs/0020-native-async-invocation.md), [spec 0029](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/specs/0029-native-feed-cursor.md), and [ADR 0005](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/adrs/0005-flat-native-abi-data-model.md). Upstream `main` has changed since the POC; see 5.4.

### 5.1 Conventions

- Library `azurecosmosdriver`; every export is prefixed `cosmos_` and uses the C (`cdecl`) calling convention.
- Native objects are opaque handles (`cosmos_runtime_t`, `cosmos_account_ref_t`, `cosmos_database_ref_t`, `cosmos_driver_t`, `cosmos_container_ref_t`, `cosmos_partition_key_t`, `cosmos_feed_range_t`, `cosmos_completion_queue_t`, `cosmos_operation_handle_t`), each with a matching `*_free` function.
- Names, ids, and keys are NUL-terminated UTF-8 strings. Request bodies are byte views (pointer + length). Strings returned by the library are released with `cosmos_string_free`.
- Pointers inside a request only need to stay valid for the duration of the submit call; the library deep-copies them before returning.
- Synchronous calls return a `CosmosErrorCode`: 0 = success, 1–2 argument validation, 2xxx HTTP status from the service, 3xxx client-side, 4xxx wrapper/fatal, 5xxx non-fatal warnings. Many also take an optional rich-error out-parameter.
- **No callbacks cross the boundary** (the one exception on upstream `main` is the AAD token provider; see 6.9). Asynchronous work is submitted with an opaque `user_data` cookie and completes by posting to a completion queue that the host drains.
- `cosmos_version()` returns the library version string.

### 5.2 Function Set (as bound by the POC)

| Area | Functions |
|---|---|
| Version / memory | `cosmos_version`, `cosmos_string_free` |
| Runtime | `cosmos_runtime_options_default`, `cosmos_runtime_build`, `cosmos_runtime_free` |
| Completion queue | `cosmos_completion_queue_create` / `_wait` / `_free_completions` / `_shutdown` / `_state` / `_free`; `cosmos_completion_take_driver`, `cosmos_completion_take_container` |
| Account / database | `cosmos_account_ref_with_master_key`, `cosmos_account_ref_clone`, `cosmos_account_ref_free`, `cosmos_database_ref_create`, `cosmos_database_ref_free` |
| Driver / container | `cosmos_driver_get_or_create_blocking` / `_submit`, `cosmos_driver_resolve_container_blocking` / `_submit`, `cosmos_driver_free`, `cosmos_container_ref_free` |
| Partition keys / feed ranges | `cosmos_partition_key_create` / `_empty` / `_component_count` / `_is_empty` / `_free`; `cosmos_feed_range_for_partition_key`, `cosmos_feed_range_free` |
| Operations | `cosmos_operation_options_default`, `cosmos_submit_singleton_operation` (point operations), `cosmos_submit_operation` (feed / paginated operations) |
| Operation handle | `cosmos_operation_handle_cancel` / `_state` / `_free` |
| Errors | `cosmos_error_status_code` / `_sub_status` / `_is_from_wire` / `_message` / `_activity_id` / `_session_token` / `_etag` / `_retry_after_ms` / `_backtrace` / `_free` |

Every operation is described by one flat request struct (`CosmosOperationRequest`: operation kind, references, ids, partition key, body, tokens, precondition, options) plus a flat options struct (`CosmosOperationOptions`, tri-state fields where 0 means "inherit"). `CosmosOperationKind` covers 24 kinds: database, container, and offer operations; item create/read/upsert/replace/delete/patch; read-all and query items; and batch.

The handles form one object graph, built in this order and freed children first:

```
runtime → account → database → container
   │                              │
   └──► driver ──► operation ────►┴─► submit ──► completion queue ──► completion
                                         │
                                         └──► operation handle (cancel / free)
```

### 5.3 Async Model: Completion Queue

The library never calls into managed code. Instead (as implemented by the POC's `CompletionQueueLoop` and `NativeAsyncOperation`):

1. Each client creates one completion queue (`cosmos_completion_queue_create`) and one background pump thread.
2. For each operation the host allocates a `NativeAsyncOperation` (an id plus a `TaskCompletionSource` created with `RunContinuationsAsynchronously`) and passes `GCHandle.ToIntPtr(GCHandle.Alloc(op))` as `user_data`.
3. Submit returns an operation handle immediately. If it returns NULL (pre-flight rejection), no completion will arrive, so the host frees the `GCHandle` itself and fails the task.
4. The pump blocks in `cosmos_completion_queue_wait` (200 ms timeout), recovers the operation from `user_data`, copies every field out of the completion, settles the task (`Ok` → result, `Error` → exception, `Cancelled` → canceled), releases the slot with `cosmos_completion_queue_free_completions`, and frees the `GCHandle` exactly once.
5. When the task settles, a continuation frees the operation handle.
6. On dispose: `cosmos_completion_queue_shutdown`, keep draining until the queue reports a terminal state (Rust posts a completion for every in-flight operation), then `cosmos_completion_queue_free`.

The `GCHandle` is the routing mechanism; there is no central dictionary of pending operations.

```csharp
private bool DrainOne(uint timeoutMs)
{
    CosmosCompletion slot = default;
    if (cosmos_completion_queue_wait(this.cqHandle, ref slot, (UIntPtr)1, timeoutMs) == UIntPtr.Zero)
    {
        return false;
    }

    try
    {
        GCHandle gch = GCHandle.FromIntPtr(slot.UserData);
        var op = (NativeAsyncOperation)gch.Target!;
        try
        {
            Settle(op, ref slot); // TrySetResult / TrySetException / TrySetCanceled
        }
        finally
        {
            gch.Free();
        }
    }
    finally
    {
        cosmos_completion_queue_free_completions(ref slot, (UIntPtr)1);
    }

    return true;
}
```

### 5.4 Upstream Changes Since the POC

Compared with the header the POC binds, `azure_data_cosmos_driver_native` 0.3.0 on upstream `main`:

- Removes on-demand cancellation: `cosmos_operation_handle_cancel` is gone, the `Cancelled` outcome is reserved, and `cosmos_operation_handle_status` was added.
- Returns error details as a `cosmos_error_t` struct with fields instead of the `cosmos_error_*` accessor functions.
- Adds cursors for query, read-feed, and change feed (`cosmos_cursor_*`, with their own queue).
- Adds diagnostics accessors (`cosmos_diagnostics_*`, including `cosmos_diagnostics_to_json`).
- Adds AAD through a host token-provider callback (`cosmos_account_ref_with_credential`, `cosmos_token_request_complete`), driver options (`cosmos_driver_options_*`), and fault-injection helpers.

The managed binding follows the header of the pinned release (Part 2), so these differences are absorbed when the first release is pinned.

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

- The Rust SDK (`azure_data_cosmos`), driver (`azure_data_cosmos_driver`), and native C ABI wrapper (`azure_data_cosmos_driver_native`) live in [`azure-sdk-for-rust` under `sdk/cosmos`](https://github.com/Azure/azure-sdk-for-rust/tree/main/sdk/cosmos) ([ADR 0001](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/adrs/0001-sdk-driver-native-layering.md)). The native crate builds a `cdylib` + `staticlib` named `azurecosmosdriver` and isn't published to crates.io; native releases follow its [versioning and release policy](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/azure_data_cosmos_driver_native/docs/NATIVE_VERSIONING_AND_RELEASES.md).
- **Release cadence:** Rust Cosmos releases ship every 1–2 months, moving to roughly every 3 months once stable. `Azure.Data.Cosmos` pins one native release at a time and picks up new ones on its own schedule.
- This repository consumes pinned native releases, and the matching `azurecosmosdriver.h` header is vendored here for reviewability.
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
            ├── native-versions.props                    # Planned — pinned native driver release
            ├── api/                                     # Generated public API listing
            │   └── Azure.Data.Cosmos.net10.0.cs
            ├── design/
            │   ├── V4-RustInterop-Design.md             # This doc
            │   └── V4-NativeAbi.md                      # Planned
            ├── native/
            │   └── azurecosmosdriver.h                  # Planned — vendored C ABI header
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
            │       ├── CompletionQueueLoop.cs           # completion-queue pump (from the POC)
            │       ├── NativeAsyncOperation.cs          # GCHandle user_data + TaskCompletionSource
            │       ├── CosmosOperationRequestBuilder.cs # builds and pins the flat request for submit
            │       ├── NativeError.cs                   # error translation
            │       ├── Handles/
            │       │   ├── CosmosRuntimeHandle.cs
            │       │   ├── CosmosDriverHandle.cs
            │       │   ├── CosmosOperationHandle.cs
            │       │   └── ...
            │       └── Marshalling/
            │           └── Utf8.cs
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
                ├── win-x64/native/azurecosmosdriver.dll
                ├── win-arm64/native/azurecosmosdriver.dll
                ├── linux-x64/native/libazurecosmosdriver.so
                ├── linux-arm64/native/libazurecosmosdriver.so
                ├── osx-x64/native/libazurecosmosdriver.dylib
                └── osx-arm64/native/libazurecosmosdriver.dylib
```

This layout follows the `azure-sdk-for-net` standard: `api/`, `src/`, `tests/`, `samples/`, `perf/`, top-level `README.md` + `CHANGELOG.md`, and a `.slnx` per package. Repository-specific notes:

- **Pipelines are per service directory, not per package.** `sdk/cosmosdb/ci.yml` sets `SDKType: client`, and `sdk/cosmosdb/service.projects` limits that pipeline to `Azure.Data.Cosmos*` projects. The generated `ci.mgmt.yml` is left unchanged; it sets no `SDKType` (defaults to `all`), so it also builds and tests this package but doesn't release it.
- **Test matrix.** The repository's default matrix runs tests with `--framework net8.0`, `net9.0`, and `net462`, which fail for a `net10.0`-only project. `ci.yml` therefore points `MatrixConfigs` at `sdk/cosmosdb/platform-matrix.json` (Linux, Windows, macOS on `net10.0`); the PR pipeline picks this up from package properties. For pipelines that still use the default matrix (`ci.mgmt.yml`), `service.projects` drops `Azure.Data.Cosmos*` projects from any leg whose target framework isn't `net10.0`.
- **Target frameworks** are set once in `Azure.Data.Cosmos/Directory.Build.props` (`net10.0` for src and tests). Without it, the repository defaults would add `net8.0` and `netstandard2.0` to the library, and `net8.0`, `net9.0`, and `net462` (on Windows) to test projects.
- **Test project names must end in `.Tests`** (for example `Azure.Data.Cosmos.Emulator.Tests`) for the engineering system to classify them as test projects. Each lives in its own sub-folder so SDK-style globbing doesn't pull one project's files into another.
- **Samples** follow the repository snippet convention: markdown under `samples/`, compiled snippet code under `tests/Azure.Data.Cosmos.Tests/Samples/`, kept in sync by `eng/scripts/Update-Snippets.ps1`.
- **Ownership:** `.github/CODEOWNERS` has no entry covering `sdk/cosmosdb/Azure.Data.Cosmos/` yet.

### 6.3 Native Library Loading

- Library name `azurecosmosdriver` (`[LibraryImport("azurecosmosdriver")]`), same as the POC.
- Packaged: binaries under `runtimes/<rid>/native/` are resolved by the .NET host from the app's dependency manifest, so consumers need no custom resolver.
- Development and tests: `NativeLibrary.SetDllImportResolver` can point at a locally built library. (The POC instead copies `azurecosmosdriver.dll` from `DriverNativeArtifactDir` next to its executable.)
- On first use, compare `cosmos_version()` with the pinned release and fail fast on a mismatch (pending Q8; the POC declares `cosmos_version()` but doesn't call it).
- Runtime: the POC builds one runtime per client with `cosmos_runtime_build`; whether to share one per process is Q2.

### 6.4 SafeHandle Pattern

```csharp
internal sealed partial class CosmosDriverHandle : SafeHandle
{
    public CosmosDriverHandle() : base(IntPtr.Zero, ownsHandle: true) { }
    public override bool IsInvalid => handle == IntPtr.Zero;

    protected override bool ReleaseHandle()
    {
        NativeMethods.cosmos_driver_free(handle);
        return true;
    }
}
```

Every long-lived native object (runtime, account, database, driver, container, partition key, completion queue) uses a `SafeHandle`. As in the POC, the graph is built in a staged way (anything created before a failure is freed) and children are freed before parents. Operation handles and rich errors are released as soon as the operation settles.

### 6.5 Serialization

- Default: `System.Text.Json` with a Cosmos-tuned `JsonSerializerOptions` (camelCase, ignore nulls on write, etc.).
- Items are serialized **in managed memory** to a pooled `ArrayBufferWriter<byte>` (UTF-8) and handed to native as a byte view (pointer + length).
- Response bodies are copied out of the completion before its slot is released (as in the POC), then deserialized in managed code.
- Pluggable: `CosmosClientOptions.Serializer` allows custom (e.g. `Newtonsoft.Json`) implementations, mirroring V3.

### 6.6 Diagnostics

- The POC reads status, sub-status, request charge, activity id, session token, etag, and continuation from each completion. Upstream `main` adds `cosmos_diagnostics_*` accessors, including `cosmos_diagnostics_to_json` (regions contacted, retries, latency, request charge).
- Managed wraps this into a `CosmosDiagnostics` object with the V3 contract preserved (string `ToString()`, structured properties).
- The ABI has no logging callback. Managed code emits an `EventSource` (`Azure-Data-Cosmos`) and OpenTelemetry data from completion and diagnostics fields, so they show up in standard .NET tracing tooling (PerfView, dotnet-trace, OpenTelemetry).

### 6.7 Exception Translation

| Native | Managed |
|---|---|
| Completion outcome `Error`, or a non-zero `CosmosErrorCode` with a rich error | `CosmosException` (StatusCode, SubStatusCode, ActivityId, SessionToken, ETag, RetryAfter, Diagnostics). The POC uses `CosmosNativeException`. |
| Completion outcome `Cancelled`, or cancellation observed via `CancellationToken` | `OperationCanceledException` |
| Wrapper/fatal codes (4xxx, e.g. queue shutdown, driver not initialized, runtime build failed) | `CosmosInteropException` (new; non-retriable, fatal) |

Never let exceptions propagate **across** the FFI boundary in either direction.

### 6.8 Cancellation

As in the POC, `CancellationToken.Register` calls `cosmos_operation_handle_cancel(operationHandle)`. Either the operation hasn't finished and Rust posts a `Cancelled` completion, or it already finished and the normal result arrives; both are valid. A continuation unregisters the token and frees the operation handle once the task settles.

Upstream `main` has since removed on-demand cancellation (5.4). Until it returns, cancellation only stops the managed wait: the task is canceled, and the completion that arrives later is drained and discarded.

### 6.9 Authentication

- **Account key / connection string:** `cosmos_account_ref_with_master_key` (as in the POC).
- **AAD (`TokenCredential`):** upstream `main` adds `cosmos_account_ref_with_credential` with a host token provider. Rust asks the host for a token through a callback; managed code calls `TokenCredential.GetTokenAsync` off that thread and answers with `cosmos_token_request_complete`. This is the only callback into managed code, so it must do minimal work and never block the Rust thread. Not in the POC.
- **Resource tokens:** not supported upstream yet.

### 6.10 Configuration Mapping

- `CosmosClientOptions` → runtime options (`cosmos_runtime_options_default` + overrides such as the user-agent suffix, as in the POC) and, on upstream `main`, driver options (`cosmos_driver_options_*`): preferred regions, consistency, timeouts, retries.
- Request options → the flat `CosmosOperationOptions`, where 0 means "inherit from the client".
- The field-by-field mapping is defined against the pinned header in `V4-NativeAbi.md` (Part 2).
- Azure.Core's `HttpPipeline` is bypassed (C-2): the Rust driver sends all HTTP requests, so Azure.Core pipeline settings (transport, retry policy, custom policies) have no effect. Their equivalents are configured through the driver options.

### 6.11 Threading and Scale

- The POC creates one Rust runtime, one completion queue, and one pump thread per client.
- Many clients therefore means many threads. Recommendation (Q2): one shared runtime per process, and clients reused as singletons (same guidance as V3). Several queues can share one runtime because `CompletionQueueLoop` takes the runtime as input.
- The pump never runs user code: tasks use `RunContinuationsAsynchronously`.

### 6.12 Feed Operations (Query, Read Feed, Change Feed)

- Point operations use `cosmos_submit_singleton_operation`.
- In the POC, feeds use `cosmos_submit_operation`, one page per submit, with the continuation token round-tripped as an opaque string.
- Upstream `main` adds cursors (`cosmos_cursor_open_submit` / `_next_submit` / `_checkpoint_submit`) with their own queue. `AsyncPageable<T>` maps one page to one `next` call. Which model to bind is decided when the first release is pinned (Q8).
- Known gap seen in the POC: cross-partition `ORDER BY` returns `400/1004` (`CrossPartitionQueryNotServable`).

---

## 7. Build & Packaging

### 7.1 Native Binary Sourcing

- The `azurecosmosdriver` native library is built from [`azure_data_cosmos_driver_native`](https://github.com/Azure/azure-sdk-for-rust/tree/main/sdk/cosmos/azure_data_cosmos_driver_native) in `azure-sdk-for-rust` by its [native release pipeline](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/azure_data_cosmos_driver_native/pipeline/native-driver.yml), following the [release guide](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/azure_data_cosmos_driver_native/docs/RELEASE_GUIDE.md). Releases come from protected source tags, every 1–2 months (about every 3 months once stable).
- **Gap:** that pipeline currently targets Go: it publishes static libraries for Linux (glibc and musl, x64 and arm64) and macOS arm64 to [`Azure/azure-cosmos-driver`](https://github.com/Azure/azure-cosmos-driver), with Windows deferred and no macOS x64. .NET needs signed shared libraries (`cdylib`) for every RID in 7.2, published somewhere this repository's build can download them from (Q9).
- The `azure-sdk-for-net` build for `Azure.Data.Cosmos` pulls a pinned version (recorded in `sdk/cosmosdb/Azure.Data.Cosmos/native-versions.props`) and stages assets into `sdk/cosmosdb/Azure.Data.Cosmos/runtimes/<rid>/native/` before pack. Staged binaries aren't committed.
- The `Azure.Data.Cosmos.csproj` declares each native asset as `<Content>` with `PackagePath="runtimes/<rid>/native/"` so .NET runtime resolves them automatically.

### 7.2 NuGet Layout

```
Azure.Data.Cosmos.<version>.nupkg
├── lib/
│   └── net10.0/Azure.Data.Cosmos.dll    # Next .NET release added when it ships; oldest dropped
└── runtimes/
    ├── win-x64/native/azurecosmosdriver.dll
    ├── win-arm64/native/azurecosmosdriver.dll
    ├── linux-x64/native/libazurecosmosdriver.so
    ├── linux-arm64/native/libazurecosmosdriver.so
    ├── osx-x64/native/libazurecosmosdriver.dylib
    └── osx-arm64/native/libazurecosmosdriver.dylib
```

### 7.3 Pipelines

- Builds run on the standard `azure-sdk-for-net` engineering system (`eng/`). Registration is via `sdk/cosmosdb/ci.yml` (`SDKType: client`, net10.0-only `MatrixConfigs` from `sdk/cosmosdb/platform-matrix.json`), with `sdk/cosmosdb/service.projects` limiting that pipeline to `Azure.Data.Cosmos*` projects. The generated `sdk/cosmosdb/ci.mgmt.yml` stays as is.
- No step in the standard templates downloads native artifacts today. A pre-build step that pulls the pinned `azurecosmosdriver` release artifacts has to be added (Part 1).
- Emulator-driven integration tests can reuse the existing `eng/common/pipelines/templates/steps/cosmos-emulator.yml` step. Live tests are registered through `sdk/cosmosdb/tests.yml` (planned) with resources in `sdk/cosmosdb/test-resources.json`.
- BinSkim scanning in `eng/pipelines/templates/stages/1es-redirect.yml` analyzes every `.dll`/`.exe`; the native binaries must pass it or be explicitly excluded there (as is done for a few third-party native DLLs today).
- Release pipeline reuses the standard Azure SDK release pipeline (signing, NuGet push, GitHub release).

### 7.4 Signing

- Native binaries must be Authenticode-signed (Windows) and notarized (macOS) by the Rust native release pipeline before this repository consumes them. That pipeline already produces checksums and signed SPDX provenance; code signing of shared libraries for .NET is still to be confirmed with the Rust team (Q9).
- Managed `Azure.Data.Cosmos.dll` is strong-named via the standard `azure-sdk-for-net` signing keys.

---

## 8. Testing Strategy

| Layer | Tests | Coverage |
|---|---|---|
| **Interop unit** | A test-only native build (shim, or the upstream crate with its `test-abi` feature) that lets us validate marshalling, the completion-queue pump, cancellation, and error translation deterministically without hitting any backend. | High; runs on every PR. |
| **Managed unit** | NUnit tests (repository standard) in `Azure.Data.Cosmos.Tests` for facade types, options validation, serialization, LINQ-to-query. Native methods mocked with Moq behind an `INativeApi` seam. | High. |
| **Emulator integration** | Scenarios ported from V3's [Microsoft.Azure.Cosmos.EmulatorTests](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/main/Microsoft.Azure.Cosmos/tests/Microsoft.Azure.Cosmos.EmulatorTests), in `Azure.Data.Cosmos.Emulator.Tests`. Runs full V4 stack against the Cosmos DB Emulator. | Medium-high; CI gate. |
| **Live multi-region** | Off by default; gated to a manual lab pipeline. Validates failover, hedging, retry behavior delegated to Rust. | Pre-release gate. |
| **Contract / parity** | A test suite that runs the **same scenarios** against V3 and V4, compares observable behavior (status codes, sub-status, diagnostics shape, retry-after honor). | Pre-release gate. |
| **AOT / trim** | The engineering system's AOT compatibility check (`eng/scripts/compatibility/Check-AOT-Compatibility.ps1`) publishes a `PublishAot=true` app against the package; it must pass with no warnings. | CI gate. |
| **Fuzz / soak** | Long-running soak in a scale lab to catch leaks (handle, native memory, GCHandle). Use `dotnet-counters` and Rust `tracing` to monitor. | Pre-release gate. |

A new project, `tests/Azure.Data.Cosmos.Interop.Tests`, exercises the same ABI deterministically. The upstream crate already has a `test-abi` feature (in-memory emulator plus `__test_only_*` helpers used by its C tests), which may replace a hand-written shim.

---

## 9. Compatibility, Versioning, Side-by-side

- **Repository:** Hosted in [`azure-sdk-for-net`](https://github.com/Azure/azure-sdk-for-net) under `sdk/cosmosdb/Azure.Data.Cosmos/`. V3 remains in [`azure-cosmos-dotnet-v3`](https://github.com/Azure/azure-cosmos-dotnet-v3).
- **Side-by-side:** V4 ships as a **new package id `Azure.Data.Cosmos`** (preview → GA), independent of V3's `Microsoft.Azure.Cosmos`. Both packages can be installed in the same project.
- **Namespace:** `Azure.Data.Cosmos` (Azure SDK convention). Distinct from V3's `Microsoft.Azure.Cosmos` — no aliasing required.
- **Target frameworks:** `net10.0` at GA, then the two most recent .NET LTS releases (C-1); no .NET Framework or .NET Standard. Set in `Azure.Data.Cosmos/Directory.Build.props`. The repository requires Azure SDK architect approval for client libraries that drop `netstandard2.0`.
- **ABI versioning:** The upstream policy uses the native crate's SemVer as the compatibility contract instead of a separate ABI version (pre-`1.0.0`, any C FFI change requires a minor bump). Managed pins an exact native release in `native-versions.props`; whether to also probe the version at load is open (Q8).
- **Public API versioning:** Same SemVer rules used today. The public surface is tracked in `api/Azure.Data.Cosmos.net10.0.cs` (regenerated with `eng/scripts/Export-API.ps1`) and, after the first GA, enforced by ApiCompat through `ApiCompatVersion` in the csproj.
- **Migration guide:** Authored alongside V4 GA as `MigrationGuide.md` at the package root (as `Azure.Data.Tables` does). Highlights breaking changes vs V3 and the gateway-only constraint.

**Long-term maintenance:**

| Topic | Plan |
|---|---|
| Target frameworks | `net10.0` at GA. Then the two most recent .NET LTS releases: add each new LTS when it ships, drop the oldest, and publish the schedule up front (C-1). |
| Rust release intake | Rust ships every 1–2 months (about every 3 months once stable). Each intake: bump `native-versions.props`, re-vendor and diff `azurecosmosdriver.h`, update the bindings, run the full test suite. Security fixes are taken out of band. |
| Prerelease versions | `-beta.N` (repository convention), starting at `1.0.0-beta.1`. |
| Release cadence | Set by the service team, independent of V3 and of the standard Azure SDK cadence; any release that adds public API needs API review first (C-6). A native intake normally ships in the next V4 release. |
| V3 | Continues on its own cadence (replacing V3 is a non-goal); the migration guide ships with V4 GA. |

---

## 10. Risks and Mitigations

| Risk | Impact | Mitigation |
|---|---|---|
| Rust driver feature gaps vs V3 (e.g. specific query features, telemetry fields). | API parity hole; can block GA. | Build a parity matrix early. Track gaps as work items in `azure-sdk-for-rust`. Use **preview status** until matrix is green. |
| Native crash brings down the .NET process. | Severe — hard to diagnose. | All native code wrapped in `catch_unwind` in Rust; ABI returns error code instead of unwinding. Crash-dump tests in CI. |
| Marshalling overhead dominates small-payload latency. | Perf regression vs V3. | Use UTF-8 spans and pooled buffers. Benchmark V4 in `perf/Azure.Data.Cosmos.Perf` against V3 baselines from [Microsoft.Azure.Cosmos.Performance.Tests](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/main/Microsoft.Azure.Cosmos/tests/Microsoft.Azure.Cosmos.Performance.Tests). |
| GCHandle leaks on cancelled operations. | Slow memory leak in long-running services. | Follow the POC: the `GCHandle` passed as `user_data` is freed exactly once, by the pump after settling the task, or by the submitter when submit is rejected; no central registry. Add leak tests. |
| Native binary distribution / signing complexity. | Ship blocker per OS/arch. | Settle the RID matrix and signing workflow (Q9) in parallel with the internal interop work; native packaging (PR 3) lands before the first public API (PR 5). |
| AOT/trim incompatibility. | Loss of a key V4 selling point. | `LibraryImport` source generators + no reflection in the interop layer; AOT smoke test in CI. |
| Diagnostics shape divergence between V3 and V4. | Customer telemetry breakage. | Define diagnostics JSON schema in the ABI doc; contract-test against V3 outputs. |
| Gateway-only constraint surprises customers. | Adoption friction. | Up-front documentation, package description, and `CosmosClientOptions.ConnectionMode` only accepts `Gateway`; throw with a clear message otherwise. |

---

## 11. Phased Development Plan

The plan is broken into **nine phases (0–8)**. Each phase has clear exit criteria, no time estimates per project convention.

### Phase 0 — Foundations & Alignment

**Exit criteria:**
- [ ] This design doc reviewed and signed off by SDK + Rust + product leads.
- [ ] V4 vs V3 public API delta proposal drafted; API review scheduled.
- [ ] RID matrix locked: `win-x64`, `win-arm64`, `linux-x64`, `linux-arm64`, `osx-x64`, `osx-arm64`.
- [ ] Native binary distribution & signing pipeline owned and prototyped (round-trip a hello-world Rust `.dll`/`.so`/`.dylib` into a NuGet package).
- [ ] Security/compliance approval for shipping the native (FFI) dependency in the NuGet package (C-4).

### Phase 1 — Native ABI Specification

**Exit criteria:**
- [ ] `azurecosmosdriver.h` from the pinned native release vendored under `sdk/cosmosdb/Azure.Data.Cosmos/native/`, and its coverage checked against: runtime lifecycle; account, database, driver, and container handles; operation submit (item CRUD, query, change feed, batch); completion queue; errors; diagnostics; version string; cancellation.
- [ ] Async/cancellation/error model documented with examples.
- [ ] Diagnostics JSON schema versioned and committed.
- [x] Rust native crate (`azure_data_cosmos_driver_native`) exists and generates `azurecosmosdriver.h` via `cbindgen` (checked in upstream).
- [ ] Vendored header validated against the pinned release tag.

### Phase 2 — Managed Skeleton & Interop Plumbing

**Exit criteria:**
- [x] New project `Azure.Data.Cosmos.csproj` builds for `net10.0`.
- [ ] `LibraryImport` declarations for the Phase 1 ABI compile and pass source-generator validation.
- [ ] The native library loads from `runtimes/<rid>/native/` when packed, and through the `SetDllImportResolver` override in dev and test.
- [ ] `cosmos_version()` checked against the pinned release on first use; a mismatch throws a clean `CosmosInteropException` (pending Q8).
- [ ] All `SafeHandle` types implemented with finalizer tests.
- [ ] `CompletionQueueLoop` round-trips an operation against a test build of the native library.

### Phase 3 — Item CRUD End-to-End

**Exit criteria:**
- [ ] `CosmosClient`, `Database`, `Container` types implemented with constructors/factory methods.
- [ ] Item Create / Read / Replace / Upsert / Patch / Delete fully functional against the emulator.
- [ ] `CosmosException` translation complete (status, sub-status, activity id, retry-after, diagnostics).
- [ ] `CancellationToken` flows native-side and aborts in-flight requests (needs upstream cancellation support; see 5.4).
- [ ] Diagnostics object populated from native diagnostics JSON; `ToString()` parity-tested vs V3 for the same operations.
- [ ] Emulator test suite covers item CRUD with green CI.

### Phase 4 — Query & Change Feed

**Exit criteria:**
- [ ] `AsyncPageable<T>` implementation backed by feed operations (`cosmos_submit_operation`, or cursors on upstream `main`; see 6.12).
- [ ] Continuation tokens round-trip correctly (string-typed; opaque to managed).
- [ ] LINQ provider produces a `QueryDefinition` understood by Rust query pipeline.
- [ ] Change feed (latest-version + all-versions-and-deletes) functional via feed operations or cursors.
- [ ] Emulator parity tests for queries from V3's [Microsoft.Azure.Cosmos.Samples/Usage/Queries](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/main/Microsoft.Azure.Cosmos.Samples/Usage/Queries).

### Phase 5 — Batch, Bulk, Auth Modes

**Exit criteria:**
- [ ] `TransactionalBatch` builder + execute fully functional.
- [ ] Bulk execution path implemented (managed-side batching feeds into the Rust driver bulk pipeline).
- [ ] Auth: account key (`cosmos_account_ref_with_master_key`) and AAD (`TokenCredential` via `cosmos_account_ref_with_credential`; see 6.9); resource tokens once supported upstream.
- [ ] Account-management surface (create database, create container, throughput) implemented (Part 5).

### Phase 6 — Diagnostics, Telemetry, OTel

**Exit criteria:**
- [ ] Managed `EventSource` and OpenTelemetry traces built from completion and diagnostics data (the ABI has no logging callback).
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
- [ ] Beta NuGet (`-beta.N`) published; migration guide drafted.
- [ ] Customer / internal partner adoption signed off (≥ 2 design partners).
- [ ] Parity matrix vs V3 fully green (or each gap explicitly waived in the migration guide).
- [ ] Security review and threat-model review completed for the FFI boundary (C-4).
- [ ] GA release published; V4 public docs live.

---

## 12. Detailed Implementation Plan (Part-by-Part)

This section converts the phased plan in Section 11 into concrete, ordered implementation parts. Each part lists **what will be built**, the **files / projects touched**, and **how it will be verified**. Parts are sequential where dependencies require it; independent work within a part can be parallelized.

### Phase ↔ Part Map

| Phase | Parts |
|---|---|
| 0 — Foundations | 1 |
| 1 — Native ABI | 2 |
| 2 — Interop plumbing | 3, 4 |
| 3 — Item CRUD | 5, 6 |
| 4 — Query & change feed | 7, 8 |
| 5 — Batch, bulk, auth | 9 (batch, bulk); 5 (auth, account management) |
| 6 — Diagnostics | 10 |
| 7 — Hardening | 11, 12 |
| 8 — Preview & GA | 13, 14, 15 |

### Delivery Sequence (PRs)

| PR | Scope | Parts | Blocked by |
|---|---|---|---|
| 1 | Skeleton + CI wiring ([#64393](https://github.com/Azure/azure-sdk-for-net/pull/64393)) | 1 (items 1–2) | Architect OK for `net10.0`-only (D-9) |
| 2 | Internal interop plumbing, no real binary | 3 | PR 1 |
| 3 | Native binary download + packaging | 1 (items 3–6) | Q9 |
| 4 | Interop test harness | 4 | PR 2 |
| 5 | `CosmosClient`, auth, account management (first public API) | 5 | PRs 2–3, API review |
| 6 | Item CRUD | 6 | PR 5 |
| 7 | Query, change feed, batch/bulk, diagnostics (parallel PRs) | 7–10 | PR 6 |
| 8 | Hardening, parity suite | 11, 12 | PR 7 |
| 9 | Docs and samples, beta, GA | 13–15 | PR 8 |

### Part 1 — Repo & Pipeline Foundations

**What will be built:**
1. **Done.** New package directory `sdk/cosmosdb/Azure.Data.Cosmos/` in the [`azure-sdk-for-net`](https://github.com/Azure/azure-sdk-for-net) monorepo, registered in `sdk/cosmosdb/ci.yml` (`SDKType: client`, net10.0-only test matrix in `sdk/cosmosdb/platform-matrix.json`) with `sdk/cosmosdb/service.projects` filtering the build to `Azure.Data.Cosmos*` projects and keeping them out of non-`net10.0` legs.
2. **Done.** Standard Azure SDK package skeleton: `src/Azure.Data.Cosmos.csproj`, `Azure.Data.Cosmos.slnx`, `Directory.Build.props` (`net10.0` only), `README.md`, `CHANGELOG.md`, `api/`, `src/`, `tests/Azure.Data.Cosmos.Tests/`. `samples/` and `perf/` are added with the first sample and benchmark.
3. New `sdk/cosmosdb/Azure.Data.Cosmos/native-versions.props` pinning the consumed `azure_data_cosmos_driver_native` release (single source of truth for native ↔ managed pairing).
4. CI scaffolding on top of the standard `eng/` pipelines:
   - New pre-build step (not in the standard templates today) that downloads the pinned native release artifacts (per RID) into `sdk/cosmosdb/Azure.Data.Cosmos/runtimes/<rid>/native/`.
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
1. `sdk/cosmosdb/Azure.Data.Cosmos/native/azurecosmosdriver.h` — vendored from the pinned `azure_data_cosmos_driver_native` release. Required coverage:
   - Version string (`cosmos_version`) and string release.
   - Runtime lifecycle.
   - Account, database, driver, container, partition key, and feed range handles.
   - Flat operation request and options; singleton and feed submit.
   - Item CRUD and patch, batch, query, read-feed, and change feed (operation kinds and cursors).
   - Completion queue: create, wait, free completions, shutdown, state.
   - Completion fields (status, body, headers, diagnostics).
   - Error codes and rich errors.
   - Operation handle state and cancellation.
2. `sdk/cosmosdb/Azure.Data.Cosmos/design/V4-NativeAbi.md` describing: calling conventions, threading, lifetime rules, error model, completion-queue and cancellation contract, diagnostics JSON schema.
3. CI gate that compares the vendored header with the one at the pinned upstream release tag (upstream already regenerates it with `cbindgen` on every build).

**Verification:**
- Header compiles cleanly under MSVC, Clang, GCC.
- Vendored header diff is empty against the pinned upstream release tag.
- Doc reviewed and signed off by both .NET and Rust leads; the native contract gets general approval from the central team (API review covers only the public C# API; C-5).

---

### Part 3 — Managed Interop Skeleton

**What will be built:**
1. `src/Azure.Data.Cosmos.csproj` (exists) gains the interop code below under `src/Interop/`.
2. `Interop/NativeMethods.cs` — `LibraryImport` declarations for every entry point from Part 2, ported from the POC's `NativeMethods.cs` (which uses `DllImport`). Marked `partial`; source-generated marshallers.
3. `Interop/NativeLibraryLoader.cs` — dev/test override via `NativeLibrary.SetDllImportResolver` (packaged binaries resolve from `runtimes/<RID>/native/`), and the `cosmos_version()` check on first load.
4. `Interop/Handles/*` — one `SafeHandle` subclass per native opaque type (`CosmosRuntimeHandle`, `CosmosAccountRefHandle`, `CosmosDatabaseRefHandle`, `CosmosDriverHandle`, `CosmosContainerRefHandle`, `CosmosPartitionKeyHandle`, `CosmosFeedRangeHandle`, `CosmosCompletionQueueHandle`, `CosmosOperationHandle`).
5. `Interop/CompletionQueueLoop.cs` and `Interop/NativeAsyncOperation.cs` — the POC's completion-queue pump:
   - One background thread per completion queue draining `cosmos_completion_queue_wait`.
   - `user_data` = `GCHandle` to a `NativeAsyncOperation` holding a `TaskCompletionSource` (`RunContinuationsAsynchronously`).
   - Polite shutdown: `cosmos_completion_queue_shutdown`, then drain until the queue is terminal.
6. `Interop/CosmosOperationRequestBuilder.cs` — builds the flat `CosmosOperationRequest` and keeps borrowed UTF-8 strings and body bytes alive for the submit call.
7. `Interop/NativeError.cs` — translates `CosmosErrorCode` and completion error fields → `CosmosException` (status, sub-status, activity id, session token, etag, retry-after).
8. `Interop/Marshalling/Utf8.cs` — pooled UTF-8 buffer helpers.

**Verification:**
- Unit tests in `Azure.Data.Cosmos.Tests` exercise loader version-mismatch, `SafeHandle` finalization, `GCHandle` lifetime (including pre-flight rollback), and error translation.
- A test build of the native library (Part 4) round-trips an operation through the completion queue.

---

### Part 4 — Test-Only Native Shim & Interop Test Harness

**What will be built:**
1. New project `tests/Azure.Data.Cosmos.Interop.Tests/` with a `native_shim/` sub-folder — a tiny C (or Rust) library that implements the same `azurecosmosdriver.h` ABI deterministically for tests (or the upstream crate built with its `test-abi` feature):
   - Configurable per-call latency.
   - Programmable success / error / cancellation outcomes.
   - Counters for handle leaks (created vs released).
   - Echo-back of input payloads to validate marshalling.
2. CMake / cargo build wired into the test pipeline; outputs placed where the loader will find them.
3. NUnit project `Azure.Data.Cosmos.Interop.Tests` exercising:
   - 100k concurrent completions to validate the async bridge under load.
   - Cancellation timing (token cancelled before / during / after the call; needs upstream cancellation, see 5.4).
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
3. Internally, as in the POC: each constructor parses options, builds the runtime (`cosmos_runtime_build`) and account reference (`cosmos_account_ref_with_master_key`; AAD uses `cosmos_account_ref_with_credential` upstream), gets or creates the driver (`cosmos_driver_get_or_create_*`), creates the completion queue, and stores the handles.
4. `IAsyncDisposable` semantics — releases the handle and the runtime ref-count.
5. `ConnectionMode` validated to `Gateway` only; throw `NotSupportedException` otherwise with a clear message.
6. Account management surface: create/read/delete/list databases and containers, throughput operations.
7. Authentication (6.9): key and connection string via `cosmos_account_ref_with_master_key`; `TokenCredential` via the token-provider bridge; resource tokens once supported upstream.
8. Client options mapped onto runtime, driver, and operation options (6.10).

**Verification:**
- Unit tests with mocked native API (`INativeApi` seam).
- Emulator integration test in `Azure.Data.Cosmos.Emulator.Tests` creates/reads/deletes databases and containers.

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
   - Copy status, body, and the headers needed for `ItemResponse<T>` out of the completion before its slot is released, then deserialize.
5. Diagnostics:
   - Build a typed `CosmosDiagnostics` object from completion fields (and from `cosmos_diagnostics_*` once the pinned release has them).
6. Exception translation wired in for non-success responses.

**Verification:**
- Emulator parity tests for each CRUD verb against the same scenarios used by V3's [Microsoft.Azure.Cosmos.Samples/Usage/ItemManagement](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/main/Microsoft.Azure.Cosmos.Samples/Usage/ItemManagement).
- Diagnostics `ToString()` parity test vs V3 (golden-file based; fields tolerant of timing).
- Cancellation test: cancellation token cancels in-flight request and surfaces `OperationCanceledException` (native abort needs upstream cancellation, see 5.4).

---

### Part 7 — Query & LINQ

**What will be built:**
1. `QueryDefinition` (parameter binding), `QueryRequestOptions`.
2. `AsyncPageable<T>` and `Page<T>` types (matches Azure SDK convention).
3. Backing implementation (6.12):
   - As in the POC, each page is a feed submit (`cosmos_submit_operation`, kind `QueryItems`); on upstream `main`, a cursor (`cosmos_cursor_open_submit` / `cosmos_cursor_next_submit`) per iterator.
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
2. Backing implementation over feed operations or cursors (6.12).
3. Continuation token handling (string).
4. Change feed processor (`ChangeFeedProcessorBuilder`) — managed-side orchestration of partitioned iterators, lease store reads via the same V4 `Container` APIs.

**Verification:**
- Emulator tests that exercise both modes and continuation resumption.
- Long-running processor test against a feed producer.

---

### Part 9 — TransactionalBatch & Bulk

**What will be built:**
1. `TransactionalBatch` builder and `TransactionalBatchResponse`.
2. Backing via the `Batch` operation kind (one submit per batch).
3. Bulk execution path:
   - `CosmosClientOptions.AllowBulkExecution = true` opt-in.
   - Managed-side batcher groups operations and feeds into the Rust driver bulk pipeline (or, if the Rust driver exposes bulk natively, just routes through it).
   - Per-item `Task<ItemResponse<T>>` completions resolved as their completions are drained.

**Verification:**
- Emulator parity tests for batch (mixed CRUD, partial failure, ETag conflicts).
- Bulk perf benchmark in `perf/Azure.Data.Cosmos.Perf` vs a V3 baseline.

---

### Part 10 — Diagnostics, Telemetry, OpenTelemetry

**What will be built:**
1. Finalized `CosmosDiagnostics` type with parity fields vs V3.
2. `EventSource` (`Azure-Data-Cosmos`) emits structured events for: request start/stop, retry, region failover, and driver diagnostics.
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
2. `sdk/cosmosdb/Azure.Data.Cosmos/design/V4-NativeAbi.md` — finalized, tagged with the pinned native release version.
3. Public API listing under `sdk/cosmosdb/Azure.Data.Cosmos/api/` (generated via the standard `azure-sdk-for-net` API tooling — `eng/scripts/Export-API.ps1`).
4. Samples under `sdk/cosmosdb/Azure.Data.Cosmos/samples/` covering: getting started, CRUD, query, change feed, batch, AAD auth, OTel. Snippet code lives in `tests/Azure.Data.Cosmos.Tests/Samples/` and is synced into the markdown with `eng/scripts/Update-Snippets.ps1`.
5. README updates linking to V3 vs V4 guidance.

**Verification:**
- Samples run as part of nightly CI.
- Doc review by DX writer.

---

### Part 14 — Preview Release & Feedback

**What will be built:**
1. Publish `Azure.Data.Cosmos <x.y.z>-beta.1` to NuGet via the standard `azure-sdk-for-net` release pipeline.
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
   - Native ↔ managed version compatibility policy (which native releases each managed release supports).
   - V3 vs V4 support matrix.
   - SLA for Rust driver fixes flowing into V4 patch releases.
4. Set the V4 release cadence (see Long-term maintenance in Section 9).

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

## 13. Clarifications from Central Team

| # | Question | Answer | Applied in |
|---|---|---|---|
| C-1 | Which .NET versions must V4 support? | `net10.0` only at GA. Afterwards, support the two most recent LTS releases (N and N−2, N even): add each new LTS when it ships, drop the oldest, and document the policy up front. Assumes a three-year deprecation period from V4 GA. | Goal 3, Section 9, D-9 |
| C-2 | Can V4 bypass Azure.Core's `HttpPipeline`? The Rust driver sends all HTTP requests. | Yes. | 6.10, D-13 |
| C-3 | Which Azure.Core version do we pin to? | The centrally managed version (`eng/centralpackagemanagement/Directory.Packages.props`). | Already the case in `Azure.Data.Cosmos.csproj` |
| C-4 | Does a security/compliance review apply to the Rust dependency? | Probably; details TBD. Approval is needed for the FFI NuGet dependency. | Phase 0, Phase 8 |
| C-5 | Does API review cover the C#↔Rust contract, or only the public C# API? | Only the public C# API; the native contract needs general approval. | Part 2 |
| C-6 | Does V4 follow the standard Azure SDK release cadence? | No; the service team sets its own cadence. Any release that exposes new public API needs API review. | Section 9 |
| C-7 | Are we doing AOT because Azure.Identity credential types use reflection that Native AOT can't handle? | Not answered yet. | Q11 |

**.NET support timeline (C-1).** LTS releases ship in November of odd years and are supported for three years.

| When | New .NET LTS | V4 supports | Dropped |
|---|---|---|---|
| V4 GA | — | .NET 10 | — |
| Nov 2027 | .NET 12 | .NET 12, .NET 10 | — |
| Nov 2029 | .NET 14 | .NET 14, .NET 12 | .NET 10 |
| Nov 2031 | .NET 16 | .NET 16, .NET 14 | .NET 12 |

The original answer listed November 2028, 2030, and 2032; the dates above follow the .NET release schedule (.NET 10 shipped in November 2025). Under this window a version stays targeted for about a year after its end of support (.NET 10 ends in November 2028 but is dropped in November 2029), which conflicts with "actively drop unsupported targets" (Q12).

---

## 14. Open Questions

1. **Package naming:** the scaffold uses `Azure.Data.Cosmos` for both the package id and root namespace (see D-8); still needs API review board confirmation.
2. **Single shared runtime vs per-client runtime** in Rust? The POC builds one runtime and one completion queue per client. Recommend single shared runtime, but expose advanced opt-out.
3. **JSON serializer default:** lock to `System.Text.Json` only, or keep Newtonsoft compatibility shim in core?
4. **Encryption packages:** can their providers wrap the V4 client surface, or do they need a separate plumbing path through Rust?
5. **Per-Partition-Automatic-Failover (PPAF) parity:** confirm Rust driver supports the same gateway-mode PPAF/circuit-breaker semantics described in [PerPartitionAutomaticFailoverDesign.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/PerPartitionAutomaticFailoverDesign.md); compare with Rust [spec 0008](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/specs/0008-partition-level-failover.md). Track gaps.
6. **Cross-region request hedging:** confirm parity with [Cross Region Request Hedging.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/Cross%20Region%20Request%20Hedging.md) and Rust [spec 0009](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/specs/0009-cross-region-hedging.md). Surface options in `CosmosClientOptions`.
7. **Resolved — Rust source location & release cadence:** source is [`azure-sdk-for-rust/sdk/cosmos`](https://github.com/Azure/azure-sdk-for-rust/tree/main/sdk/cosmos); releases every 1–2 months, about every 3 months once stable (see D-11).
8. **Version check and upstream drift:** this doc follows the POC's binding model (Section 5, D-12). Remaining: whether to check `cosmos_version()` against the pinned release at load, and how to absorb the upstream changes in 5.4 (notably the removal of on-demand cancellation).
9. **Native binaries for .NET:** who builds, signs (Authenticode, notarization), and publishes `azurecosmosdriver` shared libraries for all six RIDs, and where `azure-sdk-for-net` downloads them from. The current native release pipeline only produces Go-oriented static libraries and defers Windows.
10. **Mockability:** the Section 4 sketch uses `sealed` classes, but Azure SDK guidelines expect mockable clients (non-sealed, protected constructor, virtual methods). Decide at API review.
11. **AOT motivation (C-7):** is AOT support driven by Azure.Identity reflection concerns? For reference: V4 takes the `TokenCredential` abstraction and doesn't reference Azure.Identity; in this repository Azure.Identity doesn't opt out of the AOT compatibility check and has no `RequiresUnreferencedCode` / `RequiresDynamicCode` annotations.
12. **Dropping out-of-support .NET versions (C-1):** drop a version when it reaches end of support, or keep the N/N−2 window (about a year past end of support)?

---

## 15. Appendix — Decision Log

| # | Decision | Why |
|---|---|---|
| D-1 | Gateway mode only | Matches Rust driver capability; avoids reimplementing direct mode in Rust on day 1. |
| D-2 | C ABI (not COM, not C++/CLI) | Portable, no Windows-only dependency, easy to maintain. |
| D-3 | `LibraryImport` source generators | AOT/trim friendly; no runtime reflection in hot path. |
| D-4 | UTF-8 across the boundary (NUL-terminated strings for names/ids, byte views for bodies) | Eliminates UTF-16 conversions; matches Rust string model and the POC. |
| D-5 | Native does retry/partition routing | Single source of truth for resiliency policy across SDKs. |
| D-6 | Managed owns serialization & LINQ | Idiomatic .NET DX; type-system features (`IAsyncEnumerable`, `Span<T>`, JSON source generation). |
| D-7 | Public API close to V3 | Lower migration cost. Cleanups limited to deprecated/legacy surface. |
| D-8 | Package and root namespace `Azure.Data.Cosmos`, at `sdk/cosmosdb/Azure.Data.Cosmos/` | Namespace matches package id (Azure SDK convention); `sdk/cosmosdb/` is the existing Cosmos DB service directory. |
| D-9 | Target `net10.0` at GA, then the two most recent .NET LTS releases (N and N−2); no .NET Framework or .NET Standard | Native interop, `LibraryImport`, and AOT need modern .NET; LTS-only keeps the support window predictable (C-1). Pending Azure SDK architect approval for dropping `netstandard2.0`. |
| D-10 | NUnit for all test projects | Repository standard; xUnit isn't in central package management. |
| D-11 | Native layer is `azure_data_cosmos_driver_native` (library `azurecosmosdriver`) from `azure-sdk-for-rust/sdk/cosmos`; `Azure.Data.Cosmos` pins one native release at a time | Single Rust source of truth shared with other language SDKs. Rust releases every 1–2 months (about every 3 months once stable). |
| D-12 | Follow the POC's binding model: completion queue drained by one pump thread per queue, `GCHandle` as `user_data`, flat request struct with two submit functions | Callback-free and proven end to end in the POC; the same model as the upstream native crate. |
| D-13 | Bypass Azure.Core's `HttpPipeline`; the Rust driver owns HTTP | Confirmed by the central team (C-2). Azure.Core is still used for shared types (`TokenCredential`, `AzureKeyCredential`, `AsyncPageable<T>`). |

---

## 16. References

- [SdkDesign.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/SdkDesign.md) — current V3 architecture overview.
- [PerPartitionAutomaticFailoverDesign.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/PerPartitionAutomaticFailoverDesign.md) — gateway-mode failover semantics V4 must preserve.
- [Cross Region Request Hedging.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/Cross%20Region%20Request%20Hedging.md) — hedging behavior expected from the Rust driver.
- [observability.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/observability.md) — diagnostics conventions to mirror.
- [versioning.md](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/main/docs/versioning.md) — V3 versioning rules.
- [Native driver POC](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/users/ananth/poc-native-async-spike/tools/Microsoft.Azure.Cosmos.NativeDriverPoc) — .NET host over the Rust `azure_data_cosmos_driver_native` crate.
- [Rust Cosmos SDK](https://github.com/Azure/azure-sdk-for-rust/tree/main/sdk/cosmos) — SDK, driver, and native wrapper source.
- Rust native wrapper design: [spec 0019](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/specs/0019-native-wrapper.md), [spec 0020](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/specs/0020-native-async-invocation.md), [spec 0029](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/specs/0029-native-feed-cursor.md), [ADR 0001](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/adrs/0001-sdk-driver-native-layering.md), [ADR 0005](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/adrs/0005-flat-native-abi-data-model.md).
- [Rust diagnostics contract (spec 0018)](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/docs/specs/0018-diagnostics-contract.md) — source for the diagnostics JSON schema.
- [Native driver versioning and releases](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/azure_data_cosmos_driver_native/docs/NATIVE_VERSIONING_AND_RELEASES.md) and [release guide](https://github.com/Azure/azure-sdk-for-rust/blob/main/sdk/cosmos/azure_data_cosmos_driver_native/docs/RELEASE_GUIDE.md).
- [Directory.Build.props](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cosmosdb/Azure.Data.Cosmos/Directory.Build.props) — package-level MSBuild settings (target frameworks).
- [ci.yml](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cosmosdb/ci.yml) and [service.projects](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cosmosdb/service.projects) — data-plane pipeline registration and project filter.

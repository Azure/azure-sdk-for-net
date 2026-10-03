# Design Proposal: Blob Upload → Confidential Ledger Digest Registration (.NET SDK)

**Status:** Draft proposal (analysis + recommendation, no production code)
**Target repo:** `Azure/azure-sdk-for-net`
**Audience:** Confidential Ledger SDK owners, Azure SDK architecture board reviewers

---

## 1. Summary

We want a **client-side** .NET workflow that:

1. Uploads content directly to **Azure Blob Storage**.
2. Computes a cryptographic **digest** of the uploaded content.
3. Registers `{ digest, hashAlgorithm, blobUri, metadata }` into **Azure
   Confidential Ledger** as an immutable, tamper-evident record.
4. Returns a **structured result** that supports **recovery** when the blob upload
   succeeds but ledger registration fails — including an explicit **idempotent
   resume/retry** registration API.

This is a **composition of existing operations**. It introduces **no** new service
endpoint, URI, request/response schema, API version, or server-side behavior. The
ledger record is carried inside the ledger's **existing free-form `contents`
field**, so the Confidential Ledger REST specification does **not** change.

**Recommendation (Section 8):** Ship a **new integration package
`Azure.Security.ConfidentialLedger.Storage`** that depends on
`Azure.Security.ConfidentialLedger` and `Azure.Storage.Blobs`, exposing a
handwritten orchestration client. This keeps the core single-service clients clean,
gives independent versioning, and matches Azure SDK layering conventions.

---

## 2. Hard architectural constraint

This proposal treats the following as non-negotiable and validates every design
decision against them:

- **No new service surface.** No new endpoint, URI, request schema, response
  schema, API version, or server-side behavior.
- **No REST spec change** to Confidential Ledger unless a concrete requirement is
  proven unimplementable with existing operations (Section 9 confirms none is
  required).
- The workflow is **pure client-side orchestration** over existing Blob Storage and
  Confidential Ledger operations.

### 2.1 Why no service change is required

The Confidential Ledger write operation accepts an arbitrary application-defined
`contents` **string**, plus an optional `collectionId` and optional tags (verified
from the shipped README snippets — see `PostLedgerEntry` with
`new { contents = "...", collectionId = "..." }`). The registration record is simply
a JSON document serialized **into that existing `contents` string**:

```jsonc
// value of the EXISTING free-form "contents" field — not a new schema
{
  "schema": "azure.confidentialledger.blobdigest/v1", // client-owned convention
  "blobUri": "https://acct.blob.core.windows.net/container/blob",
  "hashAlgorithm": "SHA-256",
  "digest": "base64url(...)",
  "contentLength": 10485760,
  "eTag": "\"0x8D...\"",              // optional Blob ETag captured at upload time
  "versionId": "2026-01-01T00:00:00Z", // optional Blob version, if versioning is on
  "metadata": { "app": "...", "tenant": "..." }
}
```

Because this JSON is opaque to the service (it is just a string), **the server
schema, API version, and validation are unchanged.** The `"schema"` discriminator
is a *client-side* convention owned by this SDK, not a service contract.

---

## 3. Operation taxonomy (labeling every referenced operation)

Every operation the workflow touches is explicitly classified. Only the
**orchestration layer** is new.

| # | Operation | Classification | Change? |
|---|-----------|----------------|---------|
| 1 | `BlobClient.Upload` / `UploadAsync`, `BlockBlobClient.Upload*`, `StageBlock`/`CommitBlockList` | **Existing Blob Storage SDK operation** | Reused as-is |
| 2 | `BlobClient.OpenWrite` (streaming write) | **Existing Blob Storage SDK operation** | Reused as-is |
| 3 | `ConfidentialLedgerClient.PostLedgerEntry(WaitUntil, RequestContent, collectionId?, ...)` | **Existing Confidential Ledger SDK operation** (protocol method) | Reused as-is |
| 4 | `ConfidentialLedgerClient.GetTransactionStatus` | **Existing Confidential Ledger SDK operation** (protocol method) | Reused as-is |
| 5 | `ConfidentialLedgerClient.GetReceipt` | **Existing Confidential Ledger SDK operation** (protocol method) | Reused as-is |
| 6 | Underlying REST: `POST /app/transactions`, `GET /app/transactions/{txnId}/status`, `GET .../receipt` | **REST protocol operation (generated from service spec)** | **Unchanged** |
| 7 | `UploadAndRegisterBlob` / `RegisterUploadedBlob` (+ async) | **Handwritten SDK convenience / orchestration API (new, this proposal)** | **New** |
| 8 | `BlobDigestRegistrationResult`, `...Options`, `RecoverableRegistration` types | **Handwritten SDK convenience / orchestration API (new, this proposal)** | **New** |

**Key point:** rows 1–6 are untouched. Only rows 7–8 are added, and they live
purely in the SDK client layer.

---

## 4. Packaging options

The request asks us to evaluate three options. Each is scored against: (a) whether a
cross-service workflow belongs in the core client, (b) dependencies/versioning,
(c) discoverability, (d) .NET conventions, (e) auth for both services,
(f) streaming/large blob, (g) single-read digest, (h) sync/async shape,
(i) cancellation. The per-dimension detail is in Section 6; here we summarize the
packaging tradeoffs.

### Option 1 — Add the workflow to `Azure.Security.ConfidentialLedger`

Put `UploadAndRegisterBlob` directly on (or beside) `ConfidentialLedgerClient`.

- **Cross-service fit:** ✗ Poor. A single-service data-plane client would take a
  hard dependency on Blob Storage and gain responsibilities outside its service
  boundary. Azure SDK guidelines expect a client to wrap **one** service.
- **Dependencies/versioning:** ✗ Forces **every** Confidential Ledger consumer to
  pull `Azure.Storage.Blobs` (+ its transitive graph) even if they never touch
  blobs. Ledger releases would now be coupled to Storage releases; a Storage
  security bump could force a Ledger patch and vice-versa.
- **Discoverability:** ~ Good for *this* workflow (it's on the main client) but
  pollutes the core client's IntelliSense with storage concepts.
- **.NET conventions:** ✗ Violates single-service client scoping and the
  "no surprising transitive dependencies" principle.
- **Verdict:** Rejected. The coupling cost is borne by all consumers for a feature
  only some need.

### Option 2 — New integration package `Azure.Security.ConfidentialLedger.Storage`

A dedicated package depending on both `Azure.Security.ConfidentialLedger` and
`Azure.Storage.Blobs`, exposing the orchestration client.

- **Cross-service fit:** ✓ Correct home. The integration/composition concern lives
  in its own package; each core client stays single-service.
- **Dependencies/versioning:** ✓ Only consumers who opt in take the Storage
  dependency. The integration package versions independently and can widen its
  dependency ranges without forcing core-client releases.
- **Discoverability:** ✓ Name communicates intent (`ConfidentialLedger.Storage`);
  discoverable via NuGet search and the ledger package README "related packages".
- **.NET conventions:** ✓ Matches the established `Azure.<Family>.<Service>.<Facet>`
  naming and the precedent of separate integration/extension packages in the SDK.
- **Auth:** ✓ Can accept independent credentials/clients for each service
  (Section 6.1).
- **Verdict:** **Recommended.**

### Option 3 — Alternative boundaries (considered)

- **3a. Extension-method package** (e.g. `Azure.Storage.Blobs.ConfidentialLedger`
  adding `UploadAndRegisterAsync` extensions on `BlobClient`). Rejected: hides a
  second-service (ledger) dependency behind an extension on a Storage type, which is
  *more* surprising, and splits ownership across two service teams awkwardly.
- **3b. No package — documentation recipe only.** Rejected for the stated
  requirements: the recovery/resume semantics, structured result, and idempotency
  are non-trivial and error-prone to reimplement per consumer; a shipped, tested
  surface is warranted.
- **3c. Samples-only in the ledger package.** Same rejection as 3b.

**Conclusion:** Option 2 is the only boundary that satisfies the constraints and
conventions. The rest either couple all consumers (Option 1) or push non-trivial
recovery logic onto callers (Option 3b/3c).

---

## 5. Proposed API shape (sketch)

All types live in `Azure.Security.ConfidentialLedger.Storage`. Names are
illustrative and subject to API review.

### 5.1 Orchestration client

```csharp
namespace Azure.Security.ConfidentialLedger.Storage;

public class ConfidentialLedgerBlobClient
{
    // Compose from already-constructed, independently-authenticated clients.
    // This is the primary, most flexible constructor.
    public ConfidentialLedgerBlobClient(
        ConfidentialLedgerClient ledgerClient,
        BlobContainerClient blobContainerClient,
        ConfidentialLedgerBlobClientOptions options = null);

    // Step 1 + 2 + 3 in one call: upload, hash-while-streaming, register.
    public virtual Response<BlobDigestRegistrationResult> UploadAndRegisterBlob(
        string blobName,
        Stream content,
        UploadAndRegisterBlobOptions options = null,
        CancellationToken cancellationToken = default);

    public virtual Task<Response<BlobDigestRegistrationResult>> UploadAndRegisterBlobAsync(
        string blobName,
        Stream content,
        UploadAndRegisterBlobOptions options = null,
        CancellationToken cancellationToken = default);

    // Recovery: idempotently (re)register a blob that was already uploaded.
    // Accepts the recoverable state carried by a prior result, OR explicit inputs.
    public virtual Response<BlobDigestRegistrationResult> RegisterUploadedBlob(
        RecoverableBlobRegistration recoverable,
        CancellationToken cancellationToken = default);

    public virtual Task<Response<BlobDigestRegistrationResult>> RegisterUploadedBlobAsync(
        RecoverableBlobRegistration recoverable,
        CancellationToken cancellationToken = default);
}
```

### 5.2 Result and state types

```csharp
public enum BlobDigestRegistrationStatus
{
    UploadedAndRegistered,     // both steps succeeded, transaction committed
    UploadedRegistrationPending, // uploaded; entry posted but commit not confirmed
    UploadedRegistrationFailed,  // uploaded; ledger registration failed -> recoverable
    NotUploaded,                 // upload itself failed -> nothing to recover
}

public class BlobDigestRegistrationResult
{
    public BlobDigestRegistrationStatus Status { get; }
    public Uri BlobUri { get; }
    public string HashAlgorithm { get; }            // e.g. "SHA-256"
    public ReadOnlyMemory<byte> Digest { get; }
    public long ContentLength { get; }
    public ETag? BlobETag { get; }                  // captured at upload
    public string BlobVersionId { get; }            // if versioning enabled
    public string TransactionId { get; }            // null until registered
    public string CollectionId { get; }             // ledger collection used

    // Present when Status is UploadedRegistrationFailed/Pending. Carries everything
    // required to resume without re-reading or re-uploading the blob.
    public RecoverableBlobRegistration Recoverable { get; }
}

// Serializable so callers can persist it across process/host restarts.
public class RecoverableBlobRegistration
{
    public Uri BlobUri { get; }
    public string HashAlgorithm { get; }
    public ReadOnlyMemory<byte> Digest { get; }
    public long ContentLength { get; }
    public ETag? BlobETag { get; }
    public string BlobVersionId { get; }
    public string CollectionId { get; }
    public IReadOnlyDictionary<string, string> Metadata { get; }
    // Deterministic identity used for idempotent registration (Section 6.9).
    public string IdempotencyKey { get; }

    public BinaryData Serialize();
    public static RecoverableBlobRegistration Deserialize(BinaryData data);
}
```

### 5.3 Options

```csharp
public class UploadAndRegisterBlobOptions
{
    public HashAlgorithmName HashAlgorithm { get; set; } = HashAlgorithmName.SHA256;
    public string CollectionId { get; set; }
    public IDictionary<string, string> Metadata { get; }          // -> record + blob metadata
    public BlobUploadOptions BlobUploadOptions { get; set; }       // pass-through to Storage
    public WaitUntil LedgerWaitUntil { get; set; } = WaitUntil.Completed;
    public bool OverwriteBlob { get; set; }
}
```

**Notes on shape**

- Every async method has a **`CancellationToken`** and a sync sibling
  (Azure SDK convention). Return type is `Response<T>` so callers can inspect the
  raw HTTP response of the terminal ledger call.
- The client **composes provided clients** rather than re-implementing credential
  handling — see Section 6.1. A convenience constructor taking two endpoints + one
  or two `TokenCredential`s can be added, but the client-composition constructor is
  primary because the two services frequently need **different** credentials.

---

## 6. Cross-cutting analysis (per required dimension)

### 6.1 Authentication & authorization for both services

- **Two distinct authorization domains.** Blob Storage uses Storage RBAC data
  roles (e.g. *Storage Blob Data Contributor*), SAS, or shared key. Confidential
  Ledger uses AAD identities mapped to ledger roles (Administrator/Contributor/
  Reader) **or** a client certificate via mutual TLS. These are configured
  independently in the service and frequently use **different** principals.
- **Design decision:** the orchestration client **accepts already-constructed
  `BlobContainerClient` and `ConfidentialLedgerClient` instances**, so each carries
  its own credential, options, retry policy, and (for the ledger) the TLS identity
  verification (`VerifyConnection`, failover) behavior. The orchestration layer
  **never conflates or downgrades** credentials.
- A convenience overload accepting `(Uri ledgerUri, Uri blobContainerUri,
  TokenCredential credential)` is offered **only** for the common case where one
  AAD identity is authorized on both services; docs must state that mixed-auth
  scenarios use the client-composition constructor.
- The orchestration layer performs **no** additional authorization; it inherits
  exactly what each underlying client enforces. Least-privilege guidance: the
  workflow principal needs blob write + ledger contributor, nothing more.

### 6.2 Streaming & large-blob support

- Content is accepted as a `Stream` and forwarded to the Storage SDK's chunked/
  parallel upload path (`BlockBlobClient` staged blocks / `BlobClient.Upload`
  with `TransferOptions`), so **multi-GB blobs stream** and never require the full
  payload in memory.
- The digest is computed **incrementally over the same bytes being uploaded**
  (Section 6.3), so large-blob support and single-read hashing are the same
  mechanism.
- `BlobUploadOptions.TransferOptions` (parallelism, initial/maximum transfer size)
  is exposed pass-through so callers keep full control of chunking.

### 6.3 Digest calculation without unnecessary buffering or duplicate reads

This is the crux of the design. Three candidate strategies:

1. **Storage-computed `ContentHash` (rejected as the digest of record).** Blob
   upload returns a `ContentHash`, but it is **MD5** and is a transport-integrity
   check, not a caller-chosen cryptographic digest. It is unsuitable when the
   requirement is a specific algorithm (SHA-256/384/512) and independent
   verifiability. We may still capture it as a secondary integrity signal.
2. **Read twice (rejected).** Hash the stream, rewind, upload. Requires a seekable
   stream and reads the payload twice — unacceptable for large or non-seekable
   sources.
3. **Hash-while-uploading via a pass-through stream (chosen).** Wrap the caller's
   source `Stream` in a hashing delegating stream that updates an
   `IncrementalHash` (`System.Security.Cryptography.IncrementalHash`) as the
   Storage SDK reads bytes to upload. When upload completes, finalize the hash.
   **The content is read exactly once and never fully buffered.**

```csharp
// Sketch: read-once hashing wrapper
internal sealed class HashingReadStream : Stream
{
    private readonly Stream _inner;
    private readonly IncrementalHash _hash;
    public override int Read(byte[] buffer, int offset, int count)
    {
        int n = _inner.Read(buffer, offset, count);
        if (n > 0) _hash.AppendData(buffer.AsSpan(offset, n));
        return n;
    }
    public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken ct)
    {
        int n = await _inner.ReadAsync(buffer, ct).ConfigureAwait(false);
        if (n > 0) _hash.AppendData(buffer.Span.Slice(0, n));
        return n;
    }
    // Length/Position/Seek delegate to _inner; Seek is only used by Storage retry
    // logic on seekable sources (see 6.3.1).
}
```

**6.3.1 Retry correctness.** The Storage SDK may **seek and re-read** a seekable
source when retrying a failed chunk. A naive hashing wrapper would hash replayed
bytes twice and corrupt the digest. Mitigations, in order of preference:

- **Preferred:** compute the digest **per-block deterministically** by aligning
  hashing to the block-staging boundaries the Storage SDK uses, so a re-staged
  block re-hashes only that block. Concretely, for large uploads use
  `BlockBlobClient.StageBlock` + `CommitBlockList` directly in the orchestration
  layer, hashing each block as it is first produced and treating block IDs as the
  dedupe key. This gives exact-once hashing even under chunk retries.
- **Alternative for small/one-shot uploads:** disable seek-based re-read by using a
  forward-only wrapper and let the transport retry re-invoke the whole upload from a
  re-openable source factory the caller provides; re-create the `IncrementalHash`
  on each full retry.
- **Fallback:** if only a `Stream` is available and neither is feasible, document
  that the digest is computed from the forward byte sequence and require the upload
  path to disable mid-stream seeking (single PUT for < single-shot threshold).

The final design should implement the block-aligned approach for large blobs and the
single-shot approach below the single-PUT threshold, selecting automatically by
length — mirroring how the Storage SDK itself chooses paths.

### 6.4 Two-step ordering and the "register-after-upload" invariant

The digest of record is the digest of the **bytes actually persisted**. Therefore:

1. Upload first; obtain `ContentLength`, finalized digest, `ETag`, `VersionId`.
2. Post the ledger entry referencing that immutable blob (ideally pinned by
   `VersionId`/`ETag` so the record provably refers to a specific blob state).

This ordering is what makes the "upload succeeded, registration failed" recovery
scenario both possible and meaningful (Section 6.9).

### 6.5 Sync + async API shape

- Full sync/async pairs for every public operation (`UploadAndRegisterBlob` /
  `...Async`, `RegisterUploadedBlob` / `...Async`).
- Async is the primary/optimized path; sync delegates through the Storage and
  Ledger sync paths (no sync-over-async).
- Return `Response<T>` to expose the terminal HTTP response and headers, consistent
  with Azure SDK conventions.

### 6.6 Cancellation (deep analysis)

Cancellation spans a **non-atomic, two-service** operation, so semantics must be
defined precisely rather than "just pass the token down."

- **Single token, propagated everywhere.** The caller's `CancellationToken` flows
  into the Storage upload, the hashing stream reads, and the ledger `PostLedgerEntry`
  call. Note the ledger client treats caller cancellation as terminal (it explicitly
  **does not** trigger failover/discovery on cancellation — verified from README),
  which is the desired behavior.
- **Cancellation is observed at await/read boundaries.** Because hashing happens
  inline with stream reads, a cancel during upload stops further reads promptly;
  `IncrementalHash` is discarded.
- **Phase-aware outcome, not just an exception.** The critical design point:
  - Cancel **before/**during upload → nothing durable was created (or the blob
    write is abandoned/overwritten later); surface `OperationCanceledException`.
    Optionally, `UploadAndRegisterBlobOptions` can request **best-effort cleanup**
    (delete the partially/fully uploaded blob) on cancellation.
  - Cancel **after upload commit but before/at ledger post** → the blob **is
    durable**. Rather than losing that fact, the client throws
    `OperationCanceledException` **but** first captures the `RecoverableBlob
    registration` state. To make this recoverable state reachable even on
    cancellation, the SDK surfaces it via an
    `OperationCanceledException.Data["RecoverableRegistration"]` entry (or a typed
    `BlobRegistrationCanceledException : OperationCanceledException` carrying
    `Recoverable`). This prevents a canceled call from silently orphaning a durable
    blob.
  - Cancel **after ledger commit** → operation already succeeded; cancellation is
    ignored for the terminal result (standard "already completed" race).
- **`WaitUntil` interaction.** With `LedgerWaitUntil.Completed`, cancellation while
  waiting for commit yields `UploadedRegistrationPending` recoverable state (the
  entry may still commit server-side); the resume API is safe to call because it is
  idempotent (6.9). With `WaitUntil.Started`, the method returns as soon as the
  entry is accepted.
- **No partial-cleanup surprises.** The SDK never deletes a committed ledger entry
  (immutable by design) and only deletes blobs when explicitly opted in.

### 6.7 Retry & durability

- Each underlying client keeps its own retry pipeline; the orchestration layer does
  **not** add a competing outer retry that could double-upload.
- For ledger durability, `WaitUntil.Completed` already blocks until committed;
  `GetTransactionStatus` polling is available for `WaitUntil.Started` callers and is
  used by the resume path to confirm prior attempts.

### 6.8 Idempotent recovery / resume API

The resume path must be safe to call repeatedly (retries, crash-restart, queue
redelivery). Strategy:

- **Deterministic idempotency key.** Derive `IdempotencyKey` from
  `hash(algorithm || digest || blobVersionId || collectionId)`. Identical inputs →
  identical key, independent of process/host.
- **Check-then-write against the ledger.** `RegisterUploadedBlob` first attempts a
  cheap lookup for an existing entry bearing that key (e.g. a tag/collection
  convention using existing `GetLedgerEntry`/query operations) and returns the prior
  `TransactionId` if found (`UploadedAndRegistered`) instead of writing a duplicate.
  Only if absent does it `PostLedgerEntry`.
- **At-least-once honesty.** Confidential Ledger append is not natively
  deduplicated, so under adversarial concurrency two identical entries could still
  be written. The record is content-addressed by digest, so **duplicates are
  benign** (same digest → same meaning); the lookup makes duplicates rare, and
  callers can treat the earliest committed `transactionId` as canonical. This
  tradeoff is documented rather than hidden.
- **No blob re-read on resume.** `RecoverableBlobRegistration` already carries the
  finalized digest/length/ETag, so resume performs **only** the ledger write — no
  re-download, no re-hash.

### 6.9 Recovery scenario end-to-end

1. `UploadAndRegisterBlob` uploads (success) → ledger post fails (transient/network).
2. Result returns `Status = UploadedRegistrationFailed` with a populated
   `Recoverable` (also retrievable from the exception on cancellation).
3. Caller persists `Recoverable.Serialize()` (queue/DB) if crossing process
   boundaries.
4. Later, caller invokes `RegisterUploadedBlob(recoverable)` — idempotent, no
   re-upload — yielding `UploadedAndRegistered` with the `TransactionId`.

---

## 7. Compatibility with Azure SDK for .NET conventions

- **Naming:** `Azure.Security.ConfidentialLedger.Storage` follows
  `Azure.<Group>.<Service>.<Facet>`; client `ConfidentialLedgerBlobClient` follows
  `<Noun>Client`.
- **Client design:** constructor composition, `virtual` methods for mockability,
  sync+async pairs, `CancellationToken` last parameter, `Response<T>` returns,
  options bag pattern (`...Options`), `ClientOptions`-derived
  `ConfidentialLedgerBlobClientOptions`.
- **Dependencies:** depends only on GA'd `Azure.Security.ConfidentialLedger` and
  `Azure.Storage.Blobs`; `Azure.Core` shared.
- **Diagnostics:** reuse `Azure.Core` `ClientDiagnostics`/activity source; emit one
  span for the composite operation with child spans inherited from each client.
- **Testability:** recorded tests can span both services via the test proxy;
  ship samples mirroring the ledger package's snippet style.

---

## 8. Recommendation

**Adopt Option 2:** a new package **`Azure.Security.ConfidentialLedger.Storage`**
exposing `ConfidentialLedgerBlobClient` with `UploadAndRegisterBlob(Async)` and an
idempotent `RegisterUploadedBlob(Async)` resume API, plus the structured
`BlobDigestRegistrationResult` / `RecoverableBlobRegistration` types.

Rationale: it is the only boundary that (a) keeps each core client single-service,
(b) avoids forcing a Storage dependency on all Ledger consumers, (c) versions
independently, (d) matches .NET SDK naming/layering, and (e) cleanly supports the
recovery requirement — all **without any service or REST-spec change**.

---

## 9. REST-spec impact assessment (explicit)

We evaluated whether any requirement forces a Confidential Ledger REST change:

| Requirement | Met by existing operation? | Spec change? |
|---|---|---|
| Store digest + algorithm + blobUri + metadata | Yes — serialized into existing free-form `contents` | **No** |
| Immutable/tamper-evident record | Yes — inherent to ledger append | **No** |
| Retrieve/verify registration | Yes — `GetLedgerEntry`/`GetReceipt`/`GetTransactionStatus` | **No** |
| Idempotent resume | Yes — client-side lookup + existing write; content-addressed | **No** |
| Grouping/indexing of records | Yes — existing `collectionId`/tags | **No** |

**Conclusion:** No concrete requirement is unimplementable with existing
operations. **The Confidential Ledger REST specification must not be modified.**

---

## 10. Risks & open questions

- **Digest-vs-retry correctness (6.3.1)** is the highest-risk area; the block-aligned
  hashing implementation must be carefully tested against Storage retry paths.
- **Duplicate ledger entries under concurrency (6.8):** accepted as benign
  (content-addressed) but should be validated with the Ledger team; confirm the
  cheapest existing query for the idempotency lookup.
- **Two-team ownership:** package likely owned by the Confidential Ledger team with
  a Storage dependency; confirm ownership and CODEOWNERS.
- **Convenience single-credential constructor:** confirm demand vs. risk of
  encouraging over-privileged single identities.
- **Blob pinning:** decide whether `VersionId` pinning is required (recommended when
  blob versioning is enabled) or best-effort via `ETag`.
- **Cancellation exception type (6.6):** choose between enriching
  `OperationCanceledException.Data` vs. a dedicated
  `BlobRegistrationCanceledException`; the latter is more discoverable but adds a
  public type — defer to API review.

---

## 11. Appendix — verified grounding

- `ConfidentialLedgerClient(Uri, TokenCredential, options)`; AAD via
  `DefaultAzureCredential` **or** mutual-TLS client certificate.
- `PostLedgerEntry(WaitUntil, RequestContent, collectionId?, ...)` → `Operation`
  with `transactionId`; free-form `{ contents, collectionId }` body.
- `GetTransactionStatus` (Pending → Committed), `GetReceipt`, `GetLedgerEntry`.
- Ledger client: caller cancellation is terminal and does **not** trigger
  failover/discovery.
- Blob: `BlobClient`/`BlockBlobClient` `Upload(Async)` (`Stream`/`BinaryData`),
  `StageBlock`/`CommitBlockList`, `OpenWrite`; upload returns `BlobContentInfo`
  with MD5 `ContentHash` (integrity check, not the cryptographic digest of record).

*(Grounding drawn from the shipped `Azure.Security.ConfidentialLedger` README and
public API docs; exact signatures to be reconfirmed against the target package
version during API review.)*

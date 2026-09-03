# Multi-Tenant Trace Export — Open Questions

Everything here is either waiting on a decision or knowingly unaddressed. Nothing in this list is a
bug in the current code; bugs found during review were fixed and are recorded in `plan.md`.

**Status at time of writing:** Phases 0 through 5 complete. 981 tests passing on `net8.0`.

---

## 1. Waiting on you

*(All four questions in this section were answered on 2026-09-03. See section 2.)*

---

## 2. Decided

### 2.1 Connection pooling lifetime — **resolved: use what ClientOptions gives us**

The brief called for a short `PooledConnectionLifetime` (~2 minutes) because regional ingestion
endpoints are DNS-mobile. Decision: do not invent a transport. Whatever `ClientOptions` supplies is
what we use, same as the single-tenant path. Stale-IP exposure is accepted and no code is needed.

### 2.2 Redirect-cache fix — **still open, see section 1**

### 2.3 Silent partial drops — **resolved: silence is correct**

Only a fraction of tenants enable observability, so the majority of Activities reaching the exporter
legitimately carry no routing tags. Dropping them is the **designed steady state**, not a
misconfiguration, and logging or counting per drop would put overhead on the majority path and emit
constant noise.

Consequence, now corrected in code: `Export` used to return `Failure` when every Activity in a batch
was dropped. Under this model a batch containing only non-observability tenants is normal, so that
reported a routine outcome as an export failure and would have made the OpenTelemetry SDK log
failures continuously. All-dropped now returns `Success`. This reverses a change made earlier in
response to review finding P1-4, which assumed all-dropped meant total misconfiguration.

### 2.4 `net462` — **resolved: unsupported, no gate**

Not supported and not verified. The code may continue to compile for that target; no runtime check
refuses to enable the gate there.

### 2.5 AAD is out of scope — fail loudly or stay silent?

Out of scope as of this decision. The residual risk: `BearerTokenAuthenticationPolicy` attaches a
token for the **exporter's own** `AadAudience` to every request, including requests to other tenants'
endpoints. A tenant whose endpoint sits in a different AAD tenant is rejected at ingestion, silently
and permanently, for that tenant only.

Options: throw at construction when `options.Credential` is set and the gate is on; write a one-time
warning; or leave it entirely undocumented in code.

### 2.6 Standard metrics stay host-scoped

Confirmed out of scope. `StandardMetricsExtractionProcessor` still derives request and dependency
metrics from tenant-routed Activities and exports them under the host's connection string, and still
stamps `_MS.ProcessedByMetricExtractors` on the tenant's Activity. Recording it here so it is a known
property of the feature rather than a surprise in a support case.

### 2.7 Reserved tag names apply in both modes

`microsoft.instrumentation_key` and `microsoft.ingestion_endpoint` are registered in
`SemanticSlotMap` unconditionally, so they are stripped from custom dimensions even when the gate is
off. Deliberate — the alternative froze a static dictionary before tests could flip the switch — but
it is a behaviour change for anyone already using those exact tag names.

---

## 3. Not yet started

### 3.1 CHANGELOG

No entry written. Needs a PR number, and should cover both the AppContext switch (user-visible knob)
and the redirect fix (user-visible bug fix affecting single-tenant).

### 3.2 Storage cap is per endpoint

Phase 3 gives each ingestion endpoint its own storage partition, each with its own 50 MB
`StorageMaxSizeBytes` cap. A process talking to many regions can therefore exceed the process-wide
intent. Partitions are capped at 64, which bounds the worst case at 64 x 50 MB. A shared
`DirectorySizeTracker` across partitions is the real fix and is more work than the rest of Phase 3
was.

### 3.3 AOT app and benchmarks

The AOT compatibility app has not been run against these changes, and no benchmark scenario was
added for 1, 3, and 25 endpoints. Neither is expected to be a problem — the routing path uses no
reflection — but neither has been verified.

---

## 4. Known gaps, accepted

These are recorded so they are not rediscovered as surprises. None is currently worth fixing.

### 4.0 Raised by the Phase 3 review, not fixed

1. **Orphaned partition directories are never drained.** A partition is only opened by `TryGet`, which
   is only called for an endpoint routed in *this* run. A directory written by a previous run for an
   endpoint no longer in use has no handler and no retention timer, so its blobs sit until the
   provider's retention deletes them, and it does not count against the 64-partition cap. Fixing this
   means recovering the endpoint from the directory, which a one-way SHA-256 hash cannot do — it
   would need a manifest file per partition.
2. **`Retry-After` is not clamped.** A hostile or buggy endpoint returning a very large `Retry-After`
   opens that partition's back-off for far longer than the intended one-hour maximum, during which
   everything for that endpoint persists but never drains. Predates this branch on the single-tenant
   path; multi-tenant makes it per-endpoint.
3. **Statsbeat's `host` dimension can carry a tenant-identifying hostname.** If tenants are routed to
   per-tenant hostnames such as `tenant-123.gateway.example`, that name reaches Microsoft-exported
   statsbeat. The instrumentation key never does. Worth a decision if per-tenant hostnames are a real
   deployment shape.
4. **Failure persistence uses `SaveTelemetry`, not `SaveTelemetryWithEviction`.** At partition
   capacity the newest failed group is discarded rather than evicting the oldest blob, while the
   exception and back-off paths do evict. Inconsistent; lives in shared code.

### 4.1 Design limits

1. **Sequential sends.** `AZC0102` forbids blocking on a genuinely asynchronous task, so groups are
   sent one at a time. At the expected one to three regions this costs one extra round trip each. At
   tens of regions the latency adds up and would need a properly asynchronous export path.
2. **Endpoint normalization cache** holds the first 256 accepted spellings with no eviction. Past
   that, normalization still works but is recomputed per Activity.
3. **Pooled `Group` objects are never trimmed.** The largest export ever seen sets a permanent floor
   on retained `List` and `HashSet` capacity for the exporter's lifetime.
4. **Concurrent `Export` calls** beyond the first allocate a fresh `EndpointRouteBatch` rather than
   sharing a pool.
5. **Logs and metrics remain single-tenant.** Routing tags on a `LogRecord` are ignored. The tag
   contract is defined so the same routing lifts into `AzureMonitorLogExporter` later without a new
   design — but whether that is wanted is unasked.
6. **An endpoint that changes mid-process** orphans its storage partition; it ages out through
   existing retention rather than being reclaimed eagerly.
7. **Storage partitions are capped at 64.** Past that, a group transmits with no persistence
   fallback, so a failure loses it.

# Draft original-subject model attribution

The experimental `AAAS005` API captures the platform's `x-ms-original-subject`
dictionary for the current invocation. `FoundryAgentRequestContext.Current.OriginalSubject`
and `PlatformContext.OriginalSubject` expose the immutable snapshot; absent,
partial, and empty fields remain distinct. The `oid`, `tid`, and `idtype`
assertions are not proof of identity, do not change model credentials, and
must not be used for authorization or billing. The model service must establish
their provenance and invocation binding.

Use `FoundryAgentRequestContext.Current.ModelAttributionHeaders()` only for a
model endpoint whose owner has explicitly enabled this draft contract. Apply
the result to a **fresh per-call** `System.ClientModel.Primitives.RequestOptions`,
for example:

```csharp
#pragma warning disable AAAS005 // Opt in to the experimental draft contract.
var options = new System.ClientModel.Primitives.RequestOptions();
foreach (var header in FoundryAgentRequestContext.Current.ModelAttributionHeaders())
{
    options.SetHeader(header.Key, header.Value);
}
// Pass options to the model SDK's per-call protocol operation.
#pragma warning restore AAAS005
```

Never put these headers in shared client defaults or send them to arbitrary,
external/BYO, tool, or storage endpoints. The helper does not patch clients or
remove headers already configured on a client. It replaces stale reserved
assertions in the supplied per-call header collection, preserves unrelated
headers and baggage, and emits one percent-encoded dictionary in
`x-ms-foundry-baggage`. A complete, HTTP-safe tuple is required; incomplete or
oversized attribution raises rather than silently dropping the subject. Without
a subject, the helper removes reserved attribution and does not add the call ID.
The existing `PlatformHeaders()` method remains call-ID-only.

This draft requires owner and security review before rollout. The SDK does not
implement receiver verification or enforce attribution. It does not persist the
subject in its Responses recovery payload. Recovered tasks, detached work, and
queued non-streaming Responses steering turns do not retain attribution; a
WebSocket's subject is fixed for its connection. Do not rely on these paths for
attributed model calls. Custom providers must not persist the subject.

The Core middleware currently rejects malformed subject metadata on **all**
requests using HTTP 400, including health endpoints and WebSocket upgrade
requests. This differs from Python's invocation-scoped behavior and its
WebSocket close after upgrade; compatibility must be reviewed before rollout.
Raw subject values must not be logged.

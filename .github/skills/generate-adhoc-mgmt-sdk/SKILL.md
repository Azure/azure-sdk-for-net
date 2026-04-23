---
name: generate-adhoc-mgmt-sdk
description: Hand-write a minimal "adhoc" Azure management-plane .NET SDK for one or more operations selected from a Swagger (OpenAPI) document. The agent (not a code generator) reads the swagger, picks the chosen operations, and emits thin C# client + model files into a destination folder. No csproj, no generator invocation, no Resource/ResourceCollection scaffolding — just enough code to call the operations.
---

# Skill: generate-adhoc-mgmt-sdk

Produce a small, hand-written Azure **management-plane** .NET SDK that exposes a chosen subset of operations from a Swagger (OpenAPI v2) document. The skill is intended for quick experimentation, repros, and prototyping — **not** for shipping.

The agent does the work itself by reading the swagger and writing C# files. **No code generator (AutoRest, TypeSpec, http-client-csharp-mgmt) is invoked.**

## When Invoked

Trigger phrases:

- "generate adhoc SDK"
- "adhoc mgmt sdk"
- "hand-write SDK for operation \<id\>"
- "scaffold mgmt client for these operations from swagger"

## Required Inputs

The user must provide (ask via `ask_user` if missing):

| Input | Description |
|-------|-------------|
| `swaggerPath` | Absolute path to the Swagger (OpenAPI v2) JSON file. |
| `operationIds` | One or more `operationId` values from the swagger (e.g., `VirtualMachines_Get`, `VirtualMachines_CreateOrUpdate`). |
| `destination` | Absolute path to the folder where `.cs` files will be written. Folder is created if missing. |
| `namespace` | C# namespace for the generated files (e.g., `Azure.ResourceManager.Compute.Adhoc`). |

Optional:

| Input | Default | Description |
|-------|---------|-------------|
| `clientClassName` | `AdhocClient` | Name of the thin client class that hosts the operation methods. |
| `apiVersion` | swagger's `info.version` | API version sent on the wire as `?api-version=...`. |

## Output Shape

The skill writes only `.cs` files into `destination`. **No** `.csproj`, **no** tests, **no** `Resource` / `ResourceCollection` / `RestOperations` partial-class scaffolding.

For the chosen operations, produce:

1. **`<ClientClassName>.cs`** — a single thin client class with one method per operation (sync + async pair). Mgmt-style:
   - Constructors accept `Uri endpoint`, `TokenCredential credential`, optional `<ClientClassName>Options options` (derived from `ClientOptions`).
   - Internally builds a `HttpPipeline` using `HttpPipelineBuilder.Build` with `BearerTokenAuthenticationPolicy` (scope `https://management.azure.com/.default`).
   - Each method returns:
     - **Non-LRO**: `Response<T>` / `Task<Response<T>>` (or `Response` if the operation has no body).
     - **LRO** (operation has `x-ms-long-running-operation: true`): `ArmOperation<T>` / `Task<ArmOperation<T>>` (or `ArmOperation` if no final body), with a `WaitUntil` parameter as the **first** argument.
   - Use `ClientDiagnostics` + `using var scope = _clientDiagnostics.CreateScope("<ClientClassName>.<MethodName>")` around each call.
2. **`<ClientClassName>Options.cs`** — derived from `Azure.Core.ClientOptions`, exposes `ServiceVersion` enum + `Version` property.
3. **Model classes** — one `.cs` file per swagger schema reachable from the chosen operations' parameters and responses. Models are **plain DTOs** with public read/write properties; no `IUtf8JsonSerializable` / `IJsonModel` interfaces, no `ModelReaderWriter` plumbing — just `internal static` `Deserialize<TypeName>(JsonElement)` and `void Write(Utf8JsonWriter)` helpers used by the client methods.
4. **`<ClientClassName>RestClient.cs`** — internal helper that owns request construction (`CreateXxxRequest(...)` returning `HttpMessage`), kept separate from the public client for readability. This mirrors generated mgmt SDK structure but is hand-written and minimal.

Do **not** emit anything for swagger schemas that aren't reached transitively from the chosen operations.

## Process

### 1. Resolve and validate inputs

- Verify `swaggerPath` exists and parses as JSON. If it's a file with `$ref`s to sibling files (common-types, examples), resolve them relative to the swagger file. If a `$ref` cannot be resolved locally, fail loudly — do not silently inline `object`.
- Verify each `operationId` exists somewhere in `paths.*.<verb>.operationId`. Build a map `{ operationId -> { path, verb, operation } }`.
- Create `destination` if missing.

### 2. Compute the schema closure

Starting from each selected operation's `parameters` (body / query / path / header) and each `responses.*.schema`, walk all `$ref`s transitively. The resulting set is the **schema closure** — the only models that need to be emitted.

Common-types refs (e.g., `ErrorResponse`, `SystemData`, `TrackedResource`, `Resource`, `ProxyResource`) should be **mapped to their existing `Azure.ResourceManager` equivalents** rather than re-emitted:

| Swagger schema | Use this .NET type |
|----------------|--------------------|
| `Resource` / `ProxyResource` | `Azure.ResourceManager.Models.ResourceData` |
| `TrackedResource` | `Azure.ResourceManager.Models.TrackedResourceData` |
| `SystemData` | `Azure.ResourceManager.Models.SystemData` |
| `ErrorResponse` / `ErrorDetail` | `Azure.ResponseError` (and let `RequestFailedException` carry it) |
| `Sku` (common-types) | `Azure.ResourceManager.Models.ResourceSku` (or skip and use a local DTO if shape differs) |

If a model in the closure derives from one of the above, generate it as a partial DTO that contains the *additional* properties only and document the base mapping in a `// Maps to: <swagger name> (extends <CommonType>)` comment at the top of the file.

### 3. Emit files

Write files in this order so reviewers can follow the dependency chain:

1. Models (one file per type), sorted alphabetically.
2. `<ClientClassName>RestClient.cs`.
3. `<ClientClassName>Options.cs`.
4. `<ClientClassName>.cs`.

All files share the user-supplied `namespace`. Add this header to each file:

```csharp
// <auto-generated-by-agent />
// Adhoc SDK produced by the generate-adhoc-mgmt-sdk skill.
// Source swagger: <relative-or-absolute-path>
// Operations: <comma-separated operationIds>
```

### 4. LRO handling

For operations with `x-ms-long-running-operation: true`:

- Use `Azure.ResourceManager.ArmOperation<T>` (final-state-via response body) or `ArmOperation` (no body).
- The implementation should construct the operation via the standard pattern:
  ```csharp
  var operation = new <FinalStateOperationSource>().CreateArmOperation(
      _clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.<FromHeader>);
  if (waitUntil == WaitUntil.Completed) await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
  return operation;
  ```
- Honor `x-ms-long-running-operation-options.final-state-via` (`location`, `azure-async-operation`, `original-uri`). Default to `Location` if unspecified.

For non-LRO operations, return `Response<T>.FromValue(model, response)`.

### 5. Request construction conventions

In `<ClientClassName>RestClient.cs`, build requests using `RequestUriBuilder` and the `HttpPipeline`:

```csharp
internal HttpMessage CreateXxxRequest(string subscriptionId, string resourceGroupName, ...)
{
    var message = _pipeline.CreateMessage();
    var request = message.Request;
    request.Method = RequestMethod.<Verb>;
    var uri = new RawRequestUriBuilder();
    uri.Reset(_endpoint);
    uri.AppendPath("/subscriptions/", false);
    uri.AppendPath(subscriptionId, true);
    // ... remaining path segments (escape user-supplied segments, do not escape literals)
    uri.AppendQuery("api-version", _apiVersion, true);
    request.Uri = uri;
    request.Headers.Add("Accept", "application/json");
    if (<has body>) {
        request.Headers.Add("Content-Type", "application/json");
        var content = new Utf8JsonRequestContent();
        body.Write(content.JsonWriter);
        request.Content = content;
    }
    return message;
}
```

Path parameters: use `AppendPath(value, true)` (escape) for user values and `AppendPath("/literal/", false)` for literals. Query parameters: `AppendQuery(name, value, true)`.

### 6. Verify

- Re-read every emitted file and confirm:
  - All referenced types are in the closure or in the common-type mapping table.
  - No `using` directive references a namespace that isn't actually used.
  - Each operation appears in `<ClientClassName>` exactly once with sync + async overloads.
- Print a summary: number of files written, list of operations, list of models, list of common-type mappings used.

Do **not** attempt to `dotnet build` — the destination folder has no `.csproj`. Build verification is out of scope for this skill (a follow-up skill can add that once the shape stabilizes).

## Out of Scope (initial version)

- TypeSpec input (Swagger only for now).
- Data-plane SDK style.
- `Resource` / `ResourceCollection` / extension-method scaffolding.
- `csproj`, samples, tests.
- Invoking any code generator.
- `IJsonModel` / `IPersistableModel` interface implementations.
- API compatibility checks against an existing released package.

These can be added in follow-up iterations as the shape of the output stabilizes.

## Open Questions / Known Gaps

These are intentionally left open for future iteration — when the user next invokes the skill, refine these from real usage:

1. **Polymorphism (`discriminator`)** — current plan emits a base DTO + derived DTOs but doesn't implement a discriminator-based deserializer. Decide whether to require all derived types in the closure or fail loudly when a discriminator is encountered.
2. **`x-ms-pageable`** — currently each list operation returns a single `Response<T>`. Decide whether to expose `Pageable<T>` / `AsyncPageable<T>` for paged list operations.
3. **`x-ms-client-flatten`** — currently ignored (properties stay nested). Decide whether to honor it.
4. **Examples** — swagger `x-ms-examples` are ignored. Decide whether to emit XML doc comments referencing them.
5. **Naming** — current plan keeps swagger PascalCase names verbatim. Decide on a casing/renaming policy (e.g., `Properties` → flatten, `Id` → `ResourceIdentifier`).

When iterating on this skill, update the table above as decisions are made and move resolved items into the main body.

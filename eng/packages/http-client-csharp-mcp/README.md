# TypeSpec MCP tools generator prototype

`@azure-typespec/mcp-tools` generates MCP tools from existing service TypeSpec.
For predictable generated ARM SDK surfaces it computes the stock management
providers, generates SDK-bound adapters, and validates complete calls against
the referenced shipped SDK. **No prewritten per-operation convenience service
or handwritten SDK map is required.**

The Storage REST-shaped partial-service path remains an explicit escape hatch
for handwritten/customized convenience workflows. It is not the prerequisite
or preferred binding path for the generated ARM example.

## SDK-bound read-only ARM example

The example uses **`Azure.ResourceManager.AppNetwork` 1.0.0-beta.2**, with its
matching upstream `client.tsp` and namespace configuration pinned by the
[AppNetwork location file](generator/TestProjects/Local/AppNetwork/tsp-location.yaml).
The [small overlay](emitter/test/fixtures/appnetwork.tsp) selects exactly:

| Operation | Tool | Stock SDK target |
| --- | --- | --- |
| `Microsoft.AppLink.AppLinks.get` | `appnetwork applink get` | `AppLinkResource.GetAsync(CancellationToken)` |
| `Microsoft.AppLink.AppLinks.listByResourceGroup` | `appnetwork applink list` | `AppLinkCollection.GetAllAsync(CancellationToken)` |
| `Microsoft.AppLink.AppLinks.listBySubscription` | `appnetwork applink subscription list` | `AppNetworkExtensions.GetAppLinksAsync(SubscriptionResource, CancellationToken)` |

The overlay contains identity/title annotations, not CLR names or SDK member
mappings. The frontend uses the stock management emitter's resource detection,
client customizations, and ARM metadata. The backend constructs the normal
management `TypeProvider` graph in memory, associates methods with their
`ScmMethodProvider.ServiceMethod` identities, and derives resource/collection/
extension navigation from those providers. **It never emits a replacement
HTTP client.** Mutation/LRO/credential/key operations are outside this path.
The bounded adapter supports the shown resource-group/subscription navigation
and path-only read inputs, not arbitrary ARM scopes or extra method arguments.

SDK references come from the consumer project's actual MSBuild `ReferencePath`
closure, including restored NuGet assets, not a guessed DLL in its build folder.
The backend checks the expected public SDK signatures and uses Roslyn to compile
the complete generated SDK adapters and DTO conversions against that closure
before emitting them. A mismatch reports the operation, expected stock signature,
and available referenced candidates. It fails rather than selecting a similar
overload or silently generating a partial stub.
For an operation needing a handwritten override, leave that operation unselected
and register its ordinary handwritten command alongside the generated tools.
The generator does not turn a failed SDK binding into a successful stub.

Each operation produces an `Options`, `Result`, `SdkAdapter`, `Command`,
`JsonContext`, and `Catalog` file in the service's `Microsoft.AppLink` namespace.
One shared continuation helper brings the total to **19 generated files**.
See [the actual generated output](generator/TestProjects/Local/AppNetwork/src/Generated).

Options are normal flat MCP options: nullable `Subscription`/`Tenant` use the
existing profile/environment resolver; resource-group-scoped tools require
`ResourceGroup`; Get also requires `AppLink`; lists accept `ContinuationToken`.
Names and name-pattern validation derive from the service/path metadata.
Scalar resource path arguments also reject exact `.`/`..` segments and control
characters before the shared subscription hook or SDK, rather than letting URI
normalization or permissive end-of-line regex matching change their scope.
SDK identifier factories convert those inputs; SDK resource **data** is projected
through its verified typed `IPersistableModel<T>.Write` contract into AOT-safe `JsonElement`
results, never by serializing resource clients, credentials, or pipelines.
Get returns `Data`; lists return `Items` and `ContinuationToken`. The dynamic data projection preserves the SDK's resource JSON. ARM commands
expose source-generated `ResultTypeInfo` for the standard output envelope/schema;
the projected resource-data contents remain dynamic rather than a new typed model.

Commands derive from the existing `SubscriptionCommand<TOptions,TResult>` and
options implement `ISubscriptionOption`. Their constructor takes the logger,
`ISubscriptionResolver`, and two **shared**, not per-operation, hooks:

```csharp
Func<string, string?, CancellationToken, Task<SubscriptionResource>> getSubscription
Func<Uri> getArmEndpoint
```

The MCP consumer can bind these directly to `IAzureService.GetSubscription`
and `IAzureService.CloudConfiguration.ArmEnvironment.Endpoint`. Resource/collection
handles use the same `ArmClient`; deriving a resource-group handle makes no
extra resource-group GET request. The generator does not construct new credentials,
guess the cloud, or require a handwritten service wrapper for each tool.

### Explicit one-page behavior

Lists call the shipped SDK's `AsPages` and return **one page only**. They do not
enumerate all pages or expose a made-up maximum/page-size contract. A returned
opaque token is bound to the original operation and subscription/resource-group
path. Resuming reconstructs the absolute SDK token only under the same configured
ARM endpoint. Raw URL tokens, cross-operation/scope tokens, and SDK links outside
the configured endpoint are rejected. Cancellation is forwarded to the SDK.

The originally investigated ResourceConnector 1.0.0-beta.5 has a real shipped
first-page continuation defect: it yields the previous token before reading
the response `nextLink`. DNS Resolver 1.3.0-beta.2 has the same defect.
AppNetwork's released SDK has corrected behavior, proven with its actual DLL.
No service-specific response-parsing workaround or fake pageable implementation
is used to hide those defects.

### Generate and validate the ARM example

Use the same repository-pinned `tsp-client` setup described below. From this
package directory:

```powershell
npm run generate:arm
npm run test:arm
```

The fixture restores the shipped SDK, uses actual `tsp-client sync`/`generate`,
compiles the complete emitted source, and executes Get, resource-group page/resume,
and subscription List through the real SDK with an in-memory HTTP transport.
It checks one-request-per-page behavior, resource-data projection, cancellation,
name/token validation, byte-stable regeneration, and explicit binding failure
when the stock TypeSpec resource name does not exist in the referenced SDK.
The transport is mocked; the SDK and all SDK calls are real. No Azure provisioning
or live calls are needed.

The emitter option `"management-plane": true` selects this path and preserves
the upstream SDK namespace/configuration. The existing default remains the
partial-service path below. In both cases handwritten consumer tools remain
default-on unless the consumer explicitly opts into generated replacements.

## Repository ownership

- The reusable emitter, C# backend, and shared decorators live in this package.
- Authoritative service TypeSpec stays in `Azure/azure-rest-api-specs`.
- The MCP consumer owns its small operation-selection overlay, generation
  configuration, handwritten partial implementation, and opt-in switch.
- MCP runtime attributes and base classes remain in `microsoft/mcp`.

TypeSpec does not contain CLR type names, assembly paths, output namespaces,
handler references, or execution statements. Generated namespaces and names
derive from the actual service operation.

## TypeSpec authoring

The [Storage overlay](emitter/test/fixtures/storage.tsp) imports the staged
upstream `main.tsp` and decorates its existing operation:

```typespec
@@tool(
  Storage.Blob.Container.create,
  "f5088334-e630-4df0-a5be-ac87787acad0",
  "storage blob container create",
  "Create Storage Blob Container"
);
@@idempotent(Storage.Blob.Container.create, false);
@@openWorld(Storage.Blob.Container.create, false);
```

`@tool` takes a stable identity, path, and optional title. The title otherwise
uses the existing operation summary/name. Existing `@service` supplies ownership.
The five primitive decorators are declared in [lib/main.tsp](lib/main.tsp).
Safety decorators override conservative HTTP defaults; they are MCP hints,
not authorization controls. Omitting a boolean argument means `true`.

## Storage partial-service escape hatch

`Storage.Blob.Container.create` produces seven files in namespace `Storage.Blob`:

| File | Responsibility |
| --- | --- |
| `ContainerCreateRequest.cs` | Client endpoint/API version and operation parameters, with typed JSON properties, requiredness, defaults, and documentation. |
| `ContainerCreateResponse.cs` | HTTP status and optional response headers. Body-returning operations also get a typed `Body` property. |
| `ContainerCreateService.cs` | Required partial service declaration; no fabricated implementation. |
| `ContainerCreateCommand.cs` | Metadata, JSON validation, cancellation forwarding, service invocation, serialization, logging, and exception policy. |
| `ContainerCreateOptions.cs` | One required string `Request` option containing the complete JSON request. |
| `ContainerCreateJsonContext.cs` | Source-generated request/result JSON metadata. |
| `ContainerCreateCatalog.cs` | Stable registration, path, identity, and safety. |

Additional selected request/response models are generated as needed. See the
[actual checked-in outputs](generator/TestProjects/Local/Storage/src/Generated).

The service declaration is:

```csharp
public partial class ContainerCreateService
{
    public partial Task<ContainerCreateResponse> CreateContainerAsync(
        ContainerCreateRequest request, CancellationToken cancellationToken);
}
```

Without an implementing partial, C# compilation fails with `CS8795`. Generation
itself succeeds before that source exists. Implement the member and any
constructor/dependency injection in a separate non-generated partial file.
Regeneration preserves that file and the generated defining declaration.

The backend does not search for an existing `IStorageService` or copy its
signature. REST client parameters are included rather than assuming a service
endpoint already exists in handwritten convenience code.

### Raw request versus convenience behavior

The selected REST operation accepts a container URL, API version, client request
ID, timeout, metadata, public-access setting, and encryption-scope settings. It
returns status/headers, **not** a `ContainerInfo` body.

The raw MCP prototype accepts that contract as JSON, for example:

```json
{
  "url": "https://account.blob.core.windows.net/container",
  "metadata": { "owner": "example" }
}
```

This intentionally differs from the earlier account/container/tenant convenience
schema. A raw generated tool must not be advertised as catalog/schema parity
with the handwritten tool. Handwritten remains the consumer default.

`Request` is a string because the MCP runtime's flat option binder does not
support URI/dictionary properties. Generated JSON metadata handles typed URI,
metadata dictionaries, arrays, optional fields, and open-enum wire values.
Missing/null required fields, unknown members, and malformed JSON fail before
dispatch with a structured validation error. Service/serialization failures
continue through the normal exception policy, not input-validation handling.

Authentication, endpoint allowlisting, safe public/sovereign-cloud handling,
SDK calls, retries, private-access policy, and optional follow-up properties reads
belong in the handwritten implementation/shared infrastructure. They are not
inferred from one REST declaration. A raw result wraps the response envelope in
the command's positional result record; no `ResultTypeInfo` override is added.

### Optional customizations

A unique static source class named `<Interface><Operation>Customization` can
provide accessible string constants `Description`, `RequestDescription`, and
`DefaultErrorMessage`, plus `static string? GetErrorMessage(Exception)`.
These members are optional and type/accessibility checked. An error-policy
result of `null` falls back to the authenticated base policy.

No customization class is needed to generate the service contract.

## Standard generation with tsp-client

Source acquisition and commit wiring use the repository-pinned `tsp-client`,
not a bespoke downloader/cache. The [Storage location file](generator/TestProjects/Local/Storage/tsp-location.yaml)
records `repo`, immutable `commit`, `directory`, and the overlay entry point.
The upstream sources are no longer vendored here.

From the repository root, install the standard client once:

```powershell
npm ci --prefix eng\common\tsp-client
```

The integration fixture invokes the pinned CLI's **`sync` and `generate`**
commands. It stages the overlay/configuration beside the acquired upstream
`main.tsp`, preserving all upstream TypeSpec. Local generation uses
`--skip-install` and standard package self-reference to this private emitter
under its own `temp` directory. Only the CLI-created temporary package manifests
are removed so compiler/libraries/emitter share one physical pinned installation.
No symlinks, import rewrites, or module-resolution hooks are used.

The [emitter selection manifest](emitter-package.json) selects the local private
package for this development workflow; it is not a published installation
contract. Run the CLI from the client project containing its location file, not
from the `eng\common\tsp-client` installation directory.

The consumer's thin wrapper should delegate to the same standard workflow, take
a .NET checkout path for local development, preserve its complete configuration
and license, require fresh output, and verify exact inventory/raw bytes.

Compiling the pinned unchanged Blob service produces 41 upstream TCGC
`conflict-access-override` warnings. They are not suppressed or fixed by altering
the service. The published Blob .NET SDK still uses Swagger/AutoRest.

## Build, test, and regenerate

Prerequisites: repository-selected .NET SDK (10.0.401 or compatible), Node.js 22,
npm, PowerShell 7 for regeneration, the installed pinned `tsp-client`, and network
access for its standard source sync.

From this package directory:

```powershell
npm ci
npm run build
npm test
npm run lint
npm run prettier
npm run test:storage
```

The Storage fixture uses actual `tsp-client` source sync/generation. It starts
with only framework references and no service source, checks the required-partial
compiler diagnostic, then adds a handwritten partial and compiles/executes the
output. It covers raw parameters/defaults, metadata, no-body status/headers,
JSON validation and roundtrips, cancellation forwarding, and exception behavior.
An unrelated typed/recursive model proves generation is not Storage-specific.
Local framework doubles are not live Azure or real MCP runtime evidence.

Normal tests compare fresh generated files with snapshots without updating them.
Intentionally regenerate only through:

```powershell
npm run generate:storage
```

The generation script builds, syncs/generates through the tested standard client,
compiles, and executes before copying actual output. Never edit generated C#
by hand.

## Boundaries and runtime references

The partial-service path supports JSON primitive types, nullable values,
dictionaries, arrays, open-enum wire values, and ordinary recursive models.
Unsupported scopes, closed enums/literals, inheritance/polymorphism/open models,
streaming, paging, and LROs fail explicitly on that path. The SDK-bound ARM path
instead handles the bounded paging scenario described above. Contract/output
name collisions are errors.

The backend currently evaluates the sole consumer `src\*.csproj` and references
its built MCP framework assemblies. The ARM path additionally resolves its actual
MSBuild references for SDK binding. A framework baseline build is still required,
but a convenience interface/implementation is not. Runtime references are added
by the generator, never specified in TypeSpec.

A versioned reusable MCP runtime package would remove this bootstrap limitation.
Those core projects are not currently packaged for that use; this prototype
does not publish or introduce a cross-checkout project dependency. Generated
consumers still require compatible MCP runtime references.

The frontend uses stock `@typespec/http-client-csharp`; the MEF backend uses
TypeProviders and narrow syntax adapters for required/nullable properties,
primary constructors, and positional records. The normal `emitter-extension-path`
stages the pinned host under `dist\generator`.

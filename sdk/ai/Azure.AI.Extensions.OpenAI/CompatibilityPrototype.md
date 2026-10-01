# Extensions 2.0 compatibility prototype

This prototype preserves the **released `Azure.AI.Extensions.OpenAI` 2.0.0 assembly contract**
while using the 3.x implementation and its upstream OpenAI dependency. It is not a commitment to
preserve all 2.x previews or the already-published 3.x preview surface.

This is an independent Extensions-only prototype based on `main`. It does not include or require
the separate Agents compatibility prototype.

The library now enables ApiCompat against 2.0.0. The prototype passes that check without a
compatibility suppression file on `netstandard2.0`, `net8.0`, and `net10.0`. This establishes the
checked assembly surface, not universal source, behavior, service, or dependency compatibility.

## What is retained

- The 11 removed public type identities, hidden with `EditorBrowsable(Never)`.
- The original `AgentResponseItem` base and its model interfaces, inherited members, conversion
  entry points, factories, and protected serialization signatures.
- The 19 existing concrete response-item classes' original relationship to `AgentResponseItem`.
  They also remain usable as native `OpenAI.Responses.ResponseItem` values.
- The original `ProjectResponsesClientOptions : ProjectOpenAIClientOptions` relationship.
- Legacy conversation operation signatures, including synchronous and asynchronous results,
  pagination, and the implicit conversation-to-ID conversion.
- The original `AzureAIExtensions` container for the request/result `Agent` and
  `AgentConversationId` extension properties.
- Legacy workflow `Kind`, memory `UpdatedAt`, and model-factory contracts.

## Inheritance and conversion tradeoffs

### Response items: a bridge is possible, but not an empty base class

The response-item hierarchy is now:

```text
BingGroundingToolCall (and the other retained response-item classes)
    -> AgentResponseItem
        -> OpenAI.Responses.ResponseItem
```

The bridge retains the old virtual methods returning `AgentResponseItem`. Those methods use
separate legacy virtual slots rather than covariant return overrides, so they also work on
`netstandard2.0`. Explicit model-interface implementations bridge the legacy and native read/write
paths. Custom deserializers retain item IDs, agent attribution, and unknown JSON fields that would
otherwise be lost when the generator sees a custom base class.

This retains the original protected customization surface, but adds serialization and context
registration code that must be maintained alongside generator and upstream changes. Reflection
that inspects exact base classes, declaring types, interface sets, or private serialization fields
can observe the new hierarchy and implementation.

### Conversion operators: binary entry points versus newly compiled behavior

2.0 declared implicit conversions **both ways** between `AgentResponseItem` and `ResponseItem`.
Normal C# operator syntax does not permit declaring those conversions once one type inherits from
the other. The prototype retains their CLR `op_Implicit` entry points using `[SpecialName]`
methods. An unchanged 2.0 consumer still calls those methods and retains the old snapshot conversion.
This is an unusual, deliberately metadata-level compatibility technique that needs API/runtime
review before production adoption.

There is an unavoidable recompile distinction with this inheritance design:

```csharp
ResponseItem native = legacyItem;
```

Old compiled code calls the snapshot operator. Newly compiled code uses the built-in reference
upcast and gets the **same object**. C# will not let the old operator override that built-in
conversion. Use `legacyItem.AsResponseResultItem()` when an independent representation is required.
Consequently, this prototype does not claim identical identity/mutation behavior after recompilation.

### Client options: both sibling hierarchies cannot be inherited

The following two contracts cannot both be satisfied by one class through ordinary .NET class
inheritance:

```text
2.0: ProjectResponsesClientOptions -> ProjectOpenAIClientOptions -> OpenAI.OpenAIClientOptions
3.x: ProjectResponsesClientOptions -> OpenAI.Responses.ResponsesClientOptions
```

The upstream option classes are on separate inheritance branches. The prototype restores the
2.0 hierarchy and converts to native response-client options internally **after the pipeline has
captured the original options and custom policies**. Copying public option values alone would lose
policy lists; the ordering is part of the implementation contract.

A 3.x preview consumer that passed `ProjectResponsesClientOptions` directly to an upstream
`ResponsesClient` must instead use upstream `ResponsesClientOptions`. This cannot be fixed by
claiming the project options object inherits both classes.

## Conversation API tradeoffs

C# cannot declare two methods with the same name and parameter list that differ only in their
return type. The original method names therefore retain their 2.0 return types, and the native
3.x convenience paths have distinct names:

| Legacy operation, retained and hidden | Native-model operation |
| --- | --- |
| `CreateProjectConversation[Async]` | `CreateProjectConversationResource[Async]` |
| `GetProjectConversation[Async]` | `GetProjectConversationResource[Async]` |
| `GetProjectConversations[Async]` | `GetProjectConversationResources[Async]` |
| `UpdateProjectConversation[Async]` | `UpdateProjectConversationResource[Async]` |
| `GetProjectConversationItem[Async]` | `GetProjectResponseItem[Async]` |
| `GetProjectConversationItems[Async]` | `GetProjectResponseItems[Async]` |

The legacy wrappers preserve raw responses and use lazy page adapters; they do not fetch an entire
collection up front. They add model materialization/allocation work and can deserialize a page more
than once. Existing native conversation operations remain available through the renamed convenience
methods and inherited upstream client APIs. The included 3.x sample sources use the new names.

This favors the GA contracts over the earlier 3.x preview signatures. Already-compiled 3.x preview
integrations are **not** the compatibility baseline and can require recompilation and source edits.
The same applies to preview model-factory signatures and inherited option assignability.

The old request/result extension properties are restored to `AzureAIExtensions` rather than
declared twice, which would introduce ambiguous extension-property lookup. The newer containers
retain forwarding CLR accessor methods for common compiled preview calls, but their compiler-generated
extension marker types and reflection layout are not promised to remain unchanged.

## Model and source tradeoffs

- `EditorBrowsable(Never)` changes discovery, not C# name resolution or CLR accessibility. The legacy
  models and compatibility entry points are still public and must continue to be serviced.
- The combined Agents and Extensions prototypes have **27 overlapping public model names** across
  their namespaces. Restoring Extensions' `ContentFilterConfiguration` adds a collision with the
  current Agents model. The count of 27 is from the separate combined-prototype experiment, not a
  claim about the standalone Extensions change. Applications importing both namespaces must qualify
  conflicting names or use aliases.
- `AsAgentResponseItem` restores the 2.0 model view. For example, it returns the legacy SharePoint
  spelling and legacy memory-search model. Newer memory-command kinds remain lossless opaque values
  in that legacy view. The native context and response normalization continue producing the modern
  strongly typed models.
- Legacy `AgentWorkflowPreviewActionResponseItem.Kind` is a workflow-action string. Native item
  discrimination uses `((ResponseItem)item).Kind`; `CSDLActionKind` remains the modern explicit name.
  A preview caller expecting the native kind through the concrete class may need to adjust.
- The current 3.x experimental annotations are not removed wholesale. They do not stop old binaries,
  but newly compiled source can need additional diagnostic acknowledgements.
- Compatibility conversions can create snapshots, incur allocations, and require careful handling
  of mutable metadata, unknown fields, nulls, and JSON formats. Maintaining a finite legacy surface
  does not make future adapter maintenance free.

## What this prototype does not establish

It does not preserve the 98 type names removed from the later 2.1 previews, or promise that every
upstream OpenAI 2.x API remains compatible. Changes to APIs declared in the upstream assembly cannot
be repaired merely by adding members to this assembly. Shared dependency resolution must still
select versions compatible with the application as a whole.

It also cannot restore retired service behavior, guarantee that old payloads remain accepted by
every future service version, or eliminate the Agents prototype's separate source-name ambiguity.
No live-service validation is implied by the mocked protocol and serialization checks.

## Validation scope

The checked cases cover the old assembly surface, all 19 response-item bridges in JSON and wire
formats, all restored type identities, legacy factories, protected serialization overrides, metadata,
conversion behavior, lazy pagination, service errors, and custom pipeline policies. Existing native
normalization and deserialization coverage is retained separately from legacy-view assertions.

An external consumer compiled only against Extensions 2.0.0 was run unchanged against both the
released DLL and this 3.x implementation. It exercised old implicit conversions, a precompiled
derived serialization override, extension-property entry points, old option assignability, and
mocked conversation operations. This evidence is stronger than recompiling the same consumer,
but is still a representative local experiment, not a committed regression fixture or proof of
every possible application behavior.

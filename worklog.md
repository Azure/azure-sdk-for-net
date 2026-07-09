# AgentServer / Extensions model consolidation worklog

## Goal

The target architecture is non-negotiable:

```text
OpenAI SDK
  -> Azure.AI.Extensions.OpenAI
      -> Azure.AI.AgentServer.Responses
```

`Azure.AI.AgentServer.Responses` must not reference or depend on OpenAI directly. Any OpenAI model adaptation should be owned by `Azure.AI.Extensions.OpenAI`; AgentServer should consume Extensions-owned/facade types.

## Current strict TypeSpec shape

The active spec spike is in:

```text
/root/github/azure-rest-api-specs-agentserver-extensions/specification/ai-foundry/data-plane/Foundry/src/sdk-csharp-azure-ai-agent-contracts/client.tsp
```

It keeps AgentServer on Extensions-only alternates, for example:

```tsp
@@alternateType(A2AToolCall, {
  identity: "Azure.AI.Extensions.OpenAI.A2AToolCall",
  package: "Azure.AI.Extensions.OpenAI",
  minVersion: "3.0.0-beta.1"
}, "csharp");
```

It intentionally does **not** alternate AgentServer models directly to `OpenAI.*` types.

## Work completed

- Added local-spec support to `sdk/agentserver/scripts/Generate-Contracts.ps1` so AgentServer can be regenerated from the TypeSpec worktree.
- Updated AgentServer `tsp-location.yaml` to point at the renamed TypeSpec package from the draft spec PR.
- Added `Azure.AI.Extensions.OpenAI` as the AgentServer Responses dependency target.
- Removed the stale direct OpenAI package-version override from `Azure.AI.AgentServer.Responses`.
- Verified production `Azure.AI.AgentServer.Responses/src` has no direct `OpenAI` namespace or package references after cleanup.
- Added Extensions custom constructor suppressions so Extensions can continue to own/adapt OpenAI response item leaves while building successfully.
- Reproduced the strict architecture generation blocker.

## Test-only OpenAI usage

`Azure.AI.AgentServer.Responses/tests` still contains pre-existing OpenAI SDK interop/proxy tests and samples. That is test-only validation code, not a shipping package dependency. If the architecture rule is later interpreted to include tests as well, those tests should be migrated to validate through `Azure.AI.Extensions.OpenAI` instead of referencing OpenAI directly.

## Blocking emitter issue

Running:

```bash
cd /root/github/azure-sdk-for-net/sdk/agentserver
PIP_BREAK_SYSTEM_PACKAGES=1 pwsh -NoProfile -File ./scripts/Generate-Contracts.ps1 \
  -LocalSpecRepoPath /root/github/azure-rest-api-specs-agentserver-extensions/specification/ai-foundry/data-plane/Foundry/src/sdk-csharp-azure-ai-agent-contracts
```

fails in the C# emitter:

```text
Emitter "@typespec/http-client-csharp" crashed! This is a bug.

Object reference not set to an instance of an object.
   at Microsoft.TypeSpec.Generator.Statements.SwitchStatement.Accept(LibraryVisitor visitor, MethodProvider method)
   at Microsoft.TypeSpec.Generator.Statements.IfStatement.Accept(LibraryVisitor visitor, MethodProvider method)
   at Microsoft.TypeSpec.Generator.Statements.MethodBodyStatements.Accept(LibraryVisitor visitor, MethodProvider methodProvider)
   at Microsoft.TypeSpec.Generator.Providers.MethodProvider.Accept(LibraryVisitor visitor)
   at Microsoft.TypeSpec.Generator.LibraryVisitor.VisitTypeCore(TypeProvider typeProvider)
   at Microsoft.TypeSpec.Generator.LibraryVisitor.VisitLibrary(OutputLibrary library)
   at Microsoft.TypeSpec.Generator.CSharpGen.ExecuteAsync()
```

This occurs when AgentServer keeps a local generated polymorphic hierarchy but selected concrete variants are external `@@alternateType` references to `Azure.AI.Extensions.OpenAI`.

## Workaround assessment

An attempted workaround was to alternate AgentServer base models directly to OpenAI SDK types. That avoided this emitter crash, but it violates the required architecture because AgentServer would reference OpenAI directly. It also broke AgentServer custom builders because they expect local protocol/event types such as `OutputItem`, `ResponseOutputItemAddedEvent`, and `ResponseOutputItemDoneEvent`.

That workaround has been rejected and should not be used as the final path.

## Next meaningful step

The next blocker to resolve is emitter support for one of these strict-architecture shapes:

1. AgentServer keeps local protocol/event wrappers while concrete shared models are external Extensions alternates; or
2. Extensions exposes the full shared/facade hierarchy AgentServer needs, and AgentServer alternates consistently to Extensions-owned types.

Until the emitter crash is fixed or a supported Extensions-owned facade hierarchy is available, AgentServer generated files cannot be regenerated into the final strict architecture shape.

# AgentServer Extensions model alternate repro

This spike reproduces a C# emitter crash for the full model-consolidation architecture where `Azure.AI.AgentServer.Responses` keeps its local protocol/event model surface but consumes shared concrete Azure/Foundry models from `Azure.AI.Extensions.OpenAI`.

## Branches / working trees

- SDK repo: `/root/github/azure-sdk-for-net`
  - Branch: `shiva/agentserver-extensions-models`
- Spec worktree: `/root/github/azure-rest-api-specs-agentserver-extensions`
  - Branch: `shiva/agentserver-extensions`

The spec worktree is intentionally used instead of editing the main `azure-rest-api-specs` checkout directly.

## Architecture being tested

Desired dependency direction:

```text
OpenAI SDK
  -> Azure.AI.Extensions.OpenAI
      -> Azure.AI.AgentServer.Responses
```

The important part of this repro is that AgentServer still generates local protocol/base/event models such as `OutputItem` and response stream events, but selected concrete Azure-specific models are externalized with `@@alternateType` to `Azure.AI.Extensions.OpenAI`.

Example shape in:

```text
/root/github/azure-rest-api-specs-agentserver-extensions/specification/ai-foundry/data-plane/Foundry/src/sdk-csharp-azure-ai-agent-contracts/client.tsp
```

```tsp
@@alternateType(A2AToolCall, {
  identity: "Azure.AI.Extensions.OpenAI.A2AToolCall",
  package: "Azure.AI.Extensions.OpenAI",
  minVersion: "3.0.0-beta.1"
}, "csharp");
```

## Repro command

From the SDK repo:

```bash
cd /root/github/azure-sdk-for-net/sdk/agentserver
PIP_BREAK_SYSTEM_PACKAGES=1 pwsh -NoProfile -File ./scripts/Generate-Contracts.ps1 \
  -LocalSpecRepoPath /root/github/azure-rest-api-specs-agentserver-extensions/specification/ai-foundry/data-plane/Foundry/src/sdk-csharp-azure-ai-agent-contracts
```

## Actual result

TypeSpec compilation succeeds, but `@typespec/http-client-csharp` crashes during C# generation:

```text
Emitter "@typespec/http-client-csharp" crashed! This is a bug.
Please file an issue at https://github.com/Microsoft/typespec/issues

Error: Error: Failed to generate the library. Exit code: 1.
StackTrace:
Object reference not set to an instance of an object.
   at Microsoft.TypeSpec.Generator.Statements.SwitchStatement.Accept(LibraryVisitor visitor, MethodProvider method) in /mnt/vss/_work/1/s/packages/http-client-csharp/generator/Microsoft.TypeSpec.Generator/src/Statements/SwitchStatement.cs:line 57
   at Microsoft.TypeSpec.Generator.Statements.IfStatement.Accept(LibraryVisitor visitor, MethodProvider method) in /mnt/vss/_work/1/s/packages/http-client-csharp/generator/Microsoft.TypeSpec.Generator/src/Statements/IfStatement.cs:line 62
   at Microsoft.TypeSpec.Generator.Statements.MethodBodyStatements.Accept(LibraryVisitor visitor, MethodProvider methodProvider) in /mnt/vss/_work/1/s/packages/http-client-csharp/generator/Microsoft.TypeSpec.Generator/src/Statements/MethodBodyStatements.cs:line 37
   at Microsoft.TypeSpec.Generator.Providers.MethodProvider.Accept(LibraryVisitor visitor) in /mnt/vss/_work/1/s/packages/http-client-csharp/generator/Microsoft.TypeSpec.Generator/src/Providers/MethodProvider.cs:line 176
   at Microsoft.TypeSpec.Generator.LibraryVisitor.VisitTypeCore(TypeProvider typeProvider) in /mnt/vss/_work/1/s/packages/http-client-csharp/generator/Microsoft.TypeSpec.Generator/src/LibraryVisitor.cs:line 40
   at Microsoft.TypeSpec.Generator.LibraryVisitor.VisitTypeCore(TypeProvider typeProvider) in /mnt/vss/_work/1/s/packages/http-client-csharp/generator/Microsoft.TypeSpec.Generator/src/LibraryVisitor.cs:line 80
   at Microsoft.TypeSpec.Generator.LibraryVisitor.VisitLibrary(OutputLibrary library) in /mnt/vss/_work/1/s/packages/http-client-csharp/generator/Microsoft.TypeSpec.Generator/src/LibraryVisitor.cs:line 23
   at Microsoft.TypeSpec.Generator.CSharpGen.ExecuteAsync() in /mnt/vss/_work/1/s/packages/http-client-csharp/generator/Microsoft.TypeSpec.Generator/src/CSharpGen.cs:line 82
```

## Why this matters

The full architecture needs emitter support for this shape:

```text
local generated polymorphic base in AgentServer
  -> selected concrete derived variants supplied by external alternate types
```

If the AgentServer base types are also alternated to OpenAI/Extensions types, generation can avoid this crash, but AgentServer's handwritten builders then fail because they depend on local generated protocol/event types such as `OutputItem`, `ResponseOutputItemAddedEvent`, and `ResponseOutputItemDoneEvent`.

So the issue to inspect is the emitter's generated discriminator/switch path for a local polymorphic base with external alternate concrete variants.

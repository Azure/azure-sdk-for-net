# AgentServer Extensions model alternate repro

This spike reproduces a C# emitter crash for the full model-consolidation architecture where `Azure.AI.AgentServer.Responses` consumes shared OpenAI/Foundry response models through `Azure.AI.Extensions.OpenAI`, not the OpenAI SDK directly.

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

The important part of this repro is that AgentServer's dependency graph stays Extensions-only. The current spike alternates the shared OpenAI response/tool bases, enums, and Azure-specific concrete variants to `Azure.AI.Extensions.OpenAI` identities, and scopes imported service operations out of C# generation so the emitter only needs protocol models/OpenAPI validation output.

Example shape in:

```text
/root/github/azure-rest-api-specs-agentserver-extensions/specification/ai-foundry/data-plane/Foundry/src/sdk-csharp-azure-ai-agent-contracts/client.tsp
```

```tsp
@@alternateType(OpenAI.OutputItem, {
  identity: "Azure.AI.Extensions.OpenAI.OutputItem",
  package: "Azure.AI.Extensions.OpenAI",
  minVersion: "3.0.0-beta.1"
}, "csharp");

@@alternateType(A2AToolCall, {
  identity: "Azure.AI.Extensions.OpenAI.A2AToolCall",
  package: "Azure.AI.Extensions.OpenAI",
  minVersion: "3.0.0-beta.1"
}, "csharp");
```

## Repro command

From the SDK repo:

```bash
cd /root/github/azure-sdk-for-net
PIP_BREAK_SYSTEM_PACKAGES=1 pwsh -NoProfile -File ./sdk/agentserver/scripts/Generate-Contracts.ps1 \
  -LocalSpecRepoPath /root/github/azure-rest-api-specs-agentserver-extensions
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
AgentServer generated protocol package
  -> shared response/tool/event types supplied by Extensions alternate types
  -> Extensions is the only package that adapts OpenAI SDK types
```

Directly alternating AgentServer to `OpenAI.*` is not an acceptable workaround because it violates the required dependency direction. In addition, when tested, direct OpenAI alternates broke AgentServer's handwritten builders because they depend on protocol/event concepts such as `OutputItem`, `ResponseOutputItemAddedEvent`, and `ResponseOutputItemDoneEvent`.

The issue to inspect is the emitter's generated discriminator/switch path when a package consumes polymorphic response/event/tool models through external alternate types.

# AgentServer Extensions-only model alternate repro

This document records the earlier Extensions-only spike that reproduced a C# emitter crash when `Azure.AI.AgentServer.Responses` consumed all shared OpenAI/Foundry response models through `Azure.AI.Extensions.OpenAI`, not the OpenAI SDK directly.

Ryan later clarified that the intended model-consolidation shape is split-owner: AgentServer should consume official OpenAI concrete classes from `OpenAI` and Azure/Foundry-specific concrete classes from `Azure.AI.Extensions.OpenAI`. The split-owner branch gets past this emitter crash in direct TypeSpec compilation.

## Branches / working trees

- Prior SDK branch: `/root/github/azure-sdk-for-net`
  - Branch: `shiva/agentserver-extensions-models`
- Prior spec worktree: `/root/github/azure-rest-api-specs-agentserver-extensions`
  - Branch: `shiva/agentserver-extensions`
- Split-owner test branches:
  - SDK: `shiva/agentserver-openai-extension-concretes`
  - Spec: `shiva/agentserver-openai-extension-concretes`

The spec worktree is intentionally used instead of editing the main `azure-rest-api-specs` checkout directly.

## Architecture being tested

Desired dependency direction:

```text
OpenAI SDK owns official OpenAI concrete response models
Azure.AI.Extensions.OpenAI owns Azure/Foundry-specific concrete response models
Azure.AI.AgentServer.Responses consumes concrete models from both owning packages
```

The earlier failing repro kept AgentServer's dependency graph Extensions-only. It alternated the shared OpenAI response/tool bases, enums, and Azure-specific concrete variants to `Azure.AI.Extensions.OpenAI` identities, and scoped imported service operations out of C# generation so the emitter only needed protocol models/OpenAPI validation output.

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

The Extensions-only shape needed emitter support for this pattern:

```text
AgentServer generated protocol package
  -> all shared response/tool/event types supplied by Extensions alternate types
```

Ryan's corrected split-owner approach is different: only official OpenAI-owned models map to `OpenAI.*`; Azure-specific models still map to `Azure.AI.Extensions.OpenAI.*`.

That split-owner approach compiles without the `SwitchStatement.Accept` crash in direct TypeSpec compilation.

---
name: sdk-migration-mcp
description: MCP-tool-assisted migration for Azure SDK for .NET libraries. Uses the generator-agent MCP server for automated deterministic fixes during AutoRest/Swagger to TypeSpec migration. Use this skill alongside or instead of sdk-migration for tool-accelerated migrations.
---
# SDK Migration with MCP Tools

This skill drives Azure SDK migrations using MCP tools from the `generator-agent` server. The tools automate all deterministic, rule-based fixes (field renames, missing usings, type pattern replacements, nullable annotations, etc.) so the LLM only reasons about non-deterministic errors.

> **Relationship to `sdk-migration` skill**: The existing `sdk-migration` skill contains the full migration workflow (Phases 0–10), error classification trees, and customization patterns. This skill replaces **Phase 6 (Build-Fix Cycle)** and **Phase 8 (Test Build)** with a tool-driven approach. Use the `sdk-migration` skill for all other phases and for the domain knowledge (error classification, MPG/DPG patterns, spec fixes, customization guidance).

## When Invoked

Trigger phrases: "migrate with MCP tools", "use generator-agent tools", "tool-assisted migration", "MCP migration", "automated build fix".

Also invoke this skill when:
- The user is in Phase 6 (Build-Fix Cycle) of an `sdk-migration` and the MCP server is connected
- The user asks to "fix build errors automatically" or "apply deterministic fixes"
- The user wants to classify build errors before fixing them

## Prerequisites

1. **MCP Server must be running.** Start it with:
   ```bash
   dotnet run --project sdk/tools/Azure.GeneratorAgent/src/Azure.GeneratorAgent.csproj --framework net10.0 -- --mcp-server
   ```
   Or configure in `.vscode/mcp.json`:
   ```json
   {
     "servers": {
       "generator-agent": {
         "command": "dotnet",
         "args": ["run", "--project", "sdk/tools/Azure.GeneratorAgent/src/Azure.GeneratorAgent.csproj", "--framework", "net10.0", "--", "--mcp-server"]
       }
     }
   }
   ```

2. **The `sdk-migration` skill** should be available for domain knowledge (error classification, customization patterns, MPG/DPG-specific guidance).

3. **Repositories**: Same as `sdk-migration` — `azure-sdk-for-net` and `azure-rest-api-specs` side by side.

## Inputs

| Variable | Example | Description |
|----------|---------|-------------|
| `PROJECT_PATH` | `sdk/translation/Azure.AI.Translation.Document/src` | Path to the SDK src directory |
| `PACKAGE_NAME` | `Azure.AI.Translation.Document` | Full NuGet package name |
| `SERVICE_NAME` | `translation` | Folder name under `sdk/` |

---

## Available MCP Tools — When to Use Each

| Tool | When to Use | What It Does |
|------|-------------|--------------|
| `build_and_classify` | **First step of every build-fix iteration.** Call this to build the project and get classified errors. | Runs `dotnet build`, parses output, classifies each error as deterministic or requires-reasoning |
| `classify_error` / `classify_errors` | When you have error text but didn't use `build_and_classify`, or need to re-classify after partial fixes. | Classifies errors against the deterministic fix registry without building |
| `batch_fix` | **Immediately after `build_and_classify` returns deterministic errors.** Pass all deterministic fixes in one call. | Applies multiple deterministic fixes (regex, using add/remove, nullable) in one atomic call |
| `regex_replacement` | When `classify_errors` suggests `regex_replacement` tool, or when you identify a pattern substitution. Use for field renames (`_pipeline`→`Pipeline`), type replacements (`ResponseWithHeaders<T,H>`→`Response<T>`), namespace fixes (`Models.Models`→`Models`), `ToRequestContent` removal, `FromResponse` replacement, `FromCancellationToken` replacement. | Regex find/replace in a file |
| `add_using_directive` | When `classify_errors` suggests `add_using_directive`, or when you see CS0246/CS0103 for a known type. The registry knows 45+ type→namespace mappings (e.g., `HttpPipeline`→`Azure.Core.Pipeline`, `Response`→`Azure`, `ClientResult`→`System.ClientModel`). | Adds a missing `using` directive to a file |
| `remove_using_directive` | When `classify_errors` suggests `remove_using_directive`, or when you see CS0246 for `*.Rest.*` namespaces. | Removes `using` directives matching a pattern |
| `nullable_annotation_fix` | When you see CS8625 or CS8600 errors about null conversions. | Adds `?` nullable annotation to the type on the error line |
| `rename_codegen_type` | When you see CS0246 for `*ModelFactory` or `*ClientBuilderExtensions` with a mismatch between custom and generated names. | Updates the `[CodeGenType]` attribute to match the generated type |
| `fetch_to_fromlro` | When you see CS0103/CS1061 for `Fetch` method calls in custom LRO code. | Replaces `Fetch(response)` with `Model.FromLroResponse(response)` |
| `parse_build_output` | When you have raw build output text and need structured errors. Rarely needed — prefer `build_and_classify`. | Parses raw MSBuild output into structured error objects |
| `run_code_generation` | **After spec/TypeSpec changes or after modifying CodeGen* attributes.** Must regenerate before rebuilding. | Runs `dotnet build /t:generateCode` |
| `validate_tsp_config` | Before code generation, to ensure `tspconfig.yaml` has the correct emitter. | Validates and optionally fixes `tspconfig.yaml` emitter configuration |
| `commit_iteration` | At migration start, to find a spec commit with valid tspconfig. Usually called once. | Iterates through spec repo commits to find one with valid emitter config |
| `pregen_cleanup` | Before first code generation. Removes AutoRest artifacts from `.csproj`. | Removes `IncludeAutorestDependency` from `.csproj` files |
| `migrate_test_samples` | After src builds successfully, before building tests. | Moves test samples from `Generated/Samples/` to `Samples/` |
| `finalize_migration` | After ALL builds succeed (src and tests). Last step of migration. | Runs `Export-API.ps1` and `Update-Snippets.ps1` |

---

## Deterministic Fix Registry (35+ rules)

The registry maps error code + message pattern → tool + args. When `build_and_classify` returns classified errors, deterministic errors include the tool name and arguments to use.

| Error Pattern | Tool | Fix |
|--------------|------|-----|
| CS1061/CS0103: `_pipeline` | `regex_replacement` | `_pipeline` → `Pipeline` |
| CS1061/CS0103: `_clientDiagnostics` | `regex_replacement` | `_clientDiagnostics` → `ClientDiagnostics` |
| CS1061/CS0103: `_restClient`, `_endpoint`, `_credential`, `_apiVersion`, `_subscriptionId`, `_diagnostics` | `regex_replacement` | Remove `_` prefix, capitalize |
| CS1061/CS0103: `_serializedAdditionalRawData` | `regex_replacement` | → `_additionalBinaryDataProperties` |
| CS0246: known type (e.g., `HttpPipeline`, `Response`, `TokenCredential`) | `add_using_directive` | Add appropriate `using` (45+ known mappings) |
| CS0246: `*.Rest.*` pattern | `remove_using_directive` | Remove obsolete `*.Rest` namespaces |
| CS0246: `ResponseWithHeaders` | `regex_replacement` | `ResponseWithHeaders<T,H>` → `Response<T>` |
| CS0246: `Models.Models` | `regex_replacement` | `Models.Models.X` → `Models.X` |
| CS0246: `CodeGenModel` | `regex_replacement` | → `CodeGenType` (attribute rename) |
| CS0246: `CodeGenSerialization`/`CodeGenMemberSerialization` | `remove_using_directive` | Remove line with obsolete attribute |
| CS0246: `Autorest.CSharp.*` | `remove_using_directive` | Remove obsolete AutoRest using |
| CS8625/CS8600 | `nullable_annotation_fix` | Add `?` to type |
| CS0103: `ToRequestContent` | `regex_replacement` | Remove `.ToRequestContent()` |
| CS0103: `FromCancellationToken` | `regex_replacement` | → `.ToRequestContext()` |
| CS0103/CS1061: `FromResponse` | `regex_replacement` | `Type.FromResponse(r)` → `(Type)r` |
| CS0103: `Fetch` | `fetch_to_fromlro` | `Fetch(r)` → `Model.FromLroResponse(r)` |
| CS0246: `*ModelFactory` mismatch | `rename_codegen_type` | Update `[CodeGenType]` attribute |
| CS0246: `*ClientBuilderExtensions` mismatch | `rename_codegen_type` | Update `[CodeGenType]` attribute |
| CS0103: `MultipartFormDataRequestContent` | `regex_replacement` | Fix capitalization to `MultipartFormDataContent` |
| CS0103: `CanceledValue`/`CancelingValue` | `regex_replacement` | Fix US spelling `Cancelled`→`Canceled` |
| AZC0020: missing CancellationToken | hint only | Add `CancellationToken` parameter (LLM applies) |
| CS0104: ambiguous reference | hint only | Add full namespace qualification (LLM applies) |

---

## Full Migration Workflow (Tool-Driven)

This is the complete migration flow using MCP tools. **You (the LLM) are the orchestrator** — there is no compiled orchestrator. You call MCP tools directly and reason about what to do next.

### Phase A — Setup (run once)

```
1. Call `pregen_cleanup` with the project path
   → Removes IncludeAutorestDependency from .csproj

2. Call `validate_tsp_config` with the tspconfig.yaml path and SDK namespace
   → Ensures correct emitter configuration

3. Call `commit_iteration` with SDK path, tsp-location.yaml path, specs dir, and local specs path
   → Finds a spec commit with valid tspconfig (or creates fallback)

4. Call `run_code_generation` with the project path
   → Generates code from TypeSpec specs
```

### Phase B — Build-Fix Cycle (src)

**This is the core loop. Repeat until zero errors or max 10 iterations.**

```
STEP 1: Call `build_and_classify` with the src project path
        → Returns { buildResult: { success, errors }, classified: [...] }

STEP 2: IF zero errors → Go to Phase C

STEP 3: Separate errors into two buckets:
        a. Deterministic (classified[i].isDeterministic == true)
           → These have toolName and suggestedArgs ready to apply
        b. Requires-reasoning (isDeterministic == false)
           → These need your judgment

STEP 4: Apply ALL deterministic fixes:
        → Call `batch_fix` with all deterministic fixes at once
        → This is instant and doesn't need LLM reasoning

STEP 5: Call `build_and_classify` again to verify deterministic fixes
        → Some fixes may reveal new errors or resolve cascading issues

STEP 6: IF errors remain, analyze requires-reasoning errors:
        → Refer to the `sdk-migration` skill's Error Classification tree
        → Apply fixes based on root cause:
          - Spec issue (rename, accessibility) → edit client.tsp, then call `run_code_generation`
          - Customization issue → edit custom .cs files directly
          - Generator attribute change → edit custom code, then call `run_code_generation`
          - Generator bug → fix generator code, run Generate.ps1
        → After applying fixes, GOTO STEP 1

STEP 7: IF error count is not decreasing after 3 iterations:
        → Escalate to user with remaining error list
```

**Key decision points for regeneration:**
- After editing `[CodeGenType]`, `[CodeGenSuppress]`, or `[CodeGenMember]` attributes → call `run_code_generation` before rebuilding
- After editing `client.tsp` → call `run_code_generation` (with LocalSpecRepo if applicable) before rebuilding
- After editing only custom `.cs` code (no generator attributes) → just rebuild, no regeneration needed
- If build returns 0 errors but previous build had errors → verify no regressions by rebuilding once more

### Phase C — Test Build

```
1. Call `migrate_test_samples` with the test project path
   → Moves Generated/Samples/ to Samples/

2. Run `build_and_classify` on the test project path
   → Same build-fix loop as Phase B, but for test code
   → Test files are NOT generated — edit them directly
   → Max 10 iterations

3. When test project builds, run tests:
   dotnet test --no-build --filter "TestCategory!=Live"
```

### Phase D — Finalization

```
1. Call `finalize_migration` with the project path and service name
   → Runs Export-API.ps1 and Update-Snippets.ps1

2. Verify: git diff --stat to confirm expected scope of changes
```

---

## Adding New Deterministic Rules

To add a new fix pattern to the registry:

1. Open `sdk/tools/Azure.GeneratorAgent/src/Mcp/DeterministicFixRegistry.cs`
2. Add a new `FixRule` object to the `BuildRules()` method
3. **Ordering matters**: Specific rules (matching exact error messages) must come BEFORE generic catch-all rules (e.g., CS0246 type-to-namespace). The classifier returns the FIRST match.
4. For new type→namespace mappings, add to the `TypeToNamespace` dictionary instead
5. Add a corresponding test in `tests/DeterministicFixRegistryTests.cs`
6. Run tests: `dotnet test tests/Azure.GeneratorAgent.Tests.csproj --framework net10.0`

---

## Comparison: Skill-Only vs Skill+MCP

| Aspect | `sdk-migration` (Skill Only) | `sdk-migration-mcp` (Skill + MCP Tools) |
|--------|------------------------------|------------------------------------------|
| Build-fix loop | LLM reads errors, reasons about each, applies fixes manually | Tools classify errors instantly; LLM only reasons about non-deterministic ones |
| Field renames | LLM identifies and applies each rename | `regex_replacement` tool applies all at once via `batch_fix` |
| Missing usings | LLM looks up correct namespace | `add_using_directive` tool has 45+ mappings built-in |
| Speed | Slower — every fix requires LLM reasoning | Faster — deterministic fixes are instant |
| Accuracy | Depends on LLM context | Deterministic fixes are 100% reliable (same input → same output) |
| Non-deterministic errors | LLM handles all errors | Same — LLM still handles spec issues, customization logic, generator bugs |
| Domain knowledge | Full error classification, MPG/DPG patterns | Defers to `sdk-migration` skill for domain knowledge |

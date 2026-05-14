# TypeSpec Customization Workflow

The customization workflow is an AI-assisted process that applies TypeSpec decorators and code repairs to ensure SDK functionality. It uses a two-phase approach: **Phase A** applies `client.tsp` decorators (~80% of issues), **Phase B** applies code-level repairs when builds still fail (~10%), and the remaining ~10% receive manual guidance.

## Entry Points

The customization tool (`azure-sdk-mcp:azsdk_customized_code_update`) can be triggered from multiple sources:

| Entry Point | Description | Example |
|-------------|-------------|---------|
| **Build failures** | Compilation errors, analyzer violations, linting failures after SDK generation | `error CS0246: The type or namespace name 'FooModel' could not be found` |
| **Breaking changes** | Output from breaking changes analysis tools detecting renamed/removed properties, changed types | `Breaking changes detected: FooOptions.timeout property type changed from int to Duration` |
| **User prompts** | Natural language requests to modify SDK behavior | "Rename FooClient to BarClient for .NET" |
| **API review feedback** | Feedback from APIView or PR comments on SDK naming/structure | "Model name doesn't follow .NET casing conventions" |
| **.NET analyzer errors** | AZC0030 (naming violations), AZC0012 (generic type names), etc. | `AZC0030: Model name ends with 'Parameters'` |
| **Customization drift** | Existing customization code references renamed/removed TypeSpec entities | `cannot find symbol: method getField(String)` |
| **Duplicate field conflicts** | TypeSpec adds a property that already exists in manual customization code | `variable operationId is already defined in class AnalyzeOperationDetails` |

## When to Use

- Build fails after `azure-sdk-mcp:azsdk_package_build_code` with compilation errors
- Type name conflicts with reserved keywords or existing types
- Breaking changes from spec updates (renamed/removed properties, changed types)
- API surface changes that require `client.tsp` customizations
- .NET analyzer violations (AZC0030, AZC0012, etc.)
- Renaming clients, models, or operations for specific language SDKs
- Hiding internal operations from public SDK APIs
- Restructuring client architecture (e.g., creating subclients)
- Customization files reference entities that no longer exist after TypeSpec regeneration
- Duplicate fields between generated code and manual customization code

## Customization Steps

1. **Capture context** — Collect the build error output, user request, or API review feedback.
2. **Apply customization** — Run `azure-sdk-mcp:azsdk_customized_code_update` with the error/request context. The tool handles the full workflow internally:
   - Classifies the request (TypeSpec fix, code patch, or manual guidance)
   - Applies `client.tsp` decorators (Phase A)
   - Regenerates the SDK automatically
   - Builds to validate
   - If build still fails and customization files exist, applies code patches (Phase B)
   - Regenerates again (Java) and rebuilds
3. **Validate** — Run `azure-sdk-mcp:azsdk_package_run_check` and `azure-sdk-mcp:azsdk_package_run_tests` to verify no regressions.
4. **Review changes** — The tool leaves all changes uncommitted. Review with `git status`/`git diff` across both repos.

## Common Scenarios

| Scenario | Phase | Customization |
|----------|-------|--------------|
| Type name conflict with reserved keyword | A | Rename via `@@clientName` in `client.tsp` |
| Property renamed in new API version | A | Add `@@clientName` to preserve backward compatibility |
| .NET analyzer error (AZC0030, AZC0012) | A | Apply scoped `@@clientName` decorators to fix naming violations |
| Hide internal operation from SDK | A | Apply `@@access` decorator with language scope |
| Create subclient architecture | A | Use `@client` and `@clientInitialization` decorators |
| API review naming feedback | A | Apply scoped `@@clientName` for specific language |
| Duplicate field from customization conflict | B | Remove duplicate `addField()` from customization class |
| Customization references renamed property | B | Update references in `_patch.py`, `*Customization.java`, or partial classes |
| Feature request with no TypeSpec solution | Manual | Tool provides guidance to create customization infrastructure |

## Two-Phase Workflow

**Phase A — TypeSpec Customizations:**
Apply `client.tsp` decorators (e.g., `@@clientName`, `@@access`, `@client`), regenerate SDK, validate build. Handles ~80% of issues.

**Phase B — Code Customizations:**
Activates automatically when Phase A build fails AND customization files exist (Java: `*Customization.java`, Python: `*_patch.py`, .NET: partial classes). Applies mechanical code repairs: duplicate removal, reference updates, import fixes. Handles ~10% of issues.

**Manual Guidance:**
When neither phase resolves the issue, or no customization files exist, the tool returns structured guidance for manual implementation.

## Retry Logic

The tool handles retries internally with a two-pass classification approach:
1. First pass: classify feedback → apply TypeSpec fixes → regenerate → build
2. Second pass: re-classify remaining items with build error context → apply code patches → rebuild
3. If the tool response indicates build still failing, you can re-run `azure-sdk-mcp:azsdk_customized_code_update` with the updated error output
4. Max 2 attempts per phase (4 total iterations within the tool)

# Azure Generator Agent client library for .NET

An MCP (Model Context Protocol) server that exposes deterministic fix tools for automating Azure SDK code generation and migration workflows. A skill (LLM agent) calls these tools directly to handle rule-based fixes, keeping LLM usage for only non-deterministic reasoning.

## Getting started

### Prerequisites

- [.NET 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- Git (for repository operations)

### Build and run

Build from source within the azure-sdk-for-net repository:

```bash
cd sdk/tools/Azure.GeneratorAgent
dotnet build
```

## Key concepts

The Azure Generator Agent automates SDK code generation workflows, including code generation from service specifications and migration to new SDK patterns.

### Architecture

The agent uses a three-layer architecture:

- **MCP Server** — Exposes deterministic fix tools over the [Model Context Protocol](https://modelcontextprotocol.io/) via stdio transport. Tools are auto-discovered from the assembly at startup.
- **MCP Tools** — 18 individual tools covering regex replacements (field renames, type patterns), adding/removing using directives, nullable annotation fixes, build output parsing, error classification, code generation, test execution, commit iteration, and finalization. Each tool supports both MCP (JSON) and in-process invocation.
- **Skill-Driven Workflow** — The skill doc ([`sdk-migration`](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/sdk-migration/SKILL.md)) IS the orchestrator. The LLM reads it, calls MCP tools directly, and reasons about what to do next. No compiled C# orchestrator — the skill drives the build→classify→fix→rebuild loop.

### MCP Tools

| Tool | Description |
|------|-------------|
| `regex_replacement` | Perform regex-based find/replace in source files (field renames, type patterns, namespace fixes) |
| `add_using_directive` | Add a using directive to a C# file if not already present |
| `remove_using_directive` | Remove using directives matching a namespace pattern |
| `nullable_annotation_fix` | Fix CS8625/CS8600 by adding `?` nullable annotation on a specific line |
| `batch_fix` | Apply multiple deterministic fixes in a single call |
| `build_and_classify` | Run `dotnet build`, parse output, and classify each error as deterministic or requires-reasoning |
| `classify_errors` | Classify a batch of build errors against the deterministic fix registry |
| `run_code_generation` | Run `dotnet build /t:generateCode` for a project. Accepts optional `localSpecsPath` for local spec iteration. |
| `validate_tsp_config` | Validate that `tspconfig.yaml` has the correct emitter configuration |
| `commit_iteration` | Iterate through spec repo commits to find one with valid tspconfig. Accepts optional `commitOverride` to skip iteration. |
| `pregen_cleanup` | Remove `IncludeAutorestDependency` from `.csproj` files before first generation |
| `migrate_test_samples` | Move test samples from `Generated/Samples/` to `Samples/` |
| `finalize_migration` | Run `Export-API.ps1` and `Update-Snippets.ps1` after a successful migration |
| `run_tests` | Run `dotnet test` with configurable filter (defaults to excluding live tests). Returns structured pass/fail results. |
| `rename_codegen_type` | Fix mismatched `[CodeGenType]` attributes by matching generated counterparts |
| `fetch_to_fromlro` | Replace legacy `Fetch(response)` calls with `ResponseModel.FromLroResponse(response)` |

### Deterministic Fix Registry

The `DeterministicFixRegistry` contains rules that map error codes and message patterns to specific tool invocations. Rules cover:

- **Field renames** (9 mappings) — `_pipeline` → `Pipeline`, `_clientDiagnostics` → `ClientDiagnostics`, `_endpoint` → `Endpoint`, `_serializedAdditionalRawData` → `_additionalBinaryDataProperties`, etc.
- **Type pattern replacements** — `ResponseWithHeaders<T,H>` → `Response<T>`, `Rest.TypeName` → `TypeName`, `Models.Models.X` → `Models.X`, `CodeGenModel` → `CodeGenType`
- **Missing using directives** — 47 type-to-namespace mappings across `Azure.Core`, `Azure.Core.Pipeline`, `Azure`, `System.ClientModel`, `System.ClientModel.Primitives`, `Azure.ResourceManager`, and `Microsoft.TypeSpec.Generator.Customizations`
- **Obsolete using removal** — `Autorest.*`, `.Rest` namespaces
- **Nullable annotations** — CS8625/CS8600 fixes
- **Method call replacements** — `FromCancellationToken` → `ToRequestContext`, `Fetch(response)` → `FromLroResponse`, obsolete `.ToRequestContent()` removal

See [`.github/skills/sdk-migration/SKILL.md`](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/sdk-migration/SKILL.md) for the full rule list, tool usage guide, and the skill-driven workflow.

## Examples

### Use with a migration skill

The tools are designed to be called by the [`sdk-migration`](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/sdk-migration/SKILL.md) skill. The typical workflow is:

1. **Setup** — `pregen_cleanup` → `validate_tsp_config` → `commit_iteration` → `run_code_generation`
2. **Build-fix loop** — `build_and_classify` → `batch_fix` (for deterministic errors) → LLM reasoning (for non-deterministic errors) → rebuild
3. **Finalize** — `migrate_test_samples` → `run_tests` → `finalize_migration`

### Use with Copilot Chat

To trigger an MCP-assisted migration in Copilot Chat, use a prompt like:

```
Use the sdk-migration skill to migrate <repo-root>/sdk/<service>/<library>
The local specs repo is at <specs-root>/specification/<service>/<spec-directory>
```

For example:

```
Use the sdk-migration skill to migrate C:\git\azure-sdk-for-net\sdk\communication\Azure.Communication.Messages
The local specs repo is at C:\git\azure-rest-api-specs\specification\communication\Communication.Messages
```
If you wish you use specific commit id for tsp-location.yaml add to the message. For example:

```
Use the sdk-migration skill to migrate C:\git\azure-sdk-for-net\sdk\communication\Azure.Communication.Messages
The local specs repo is at C:\git\azure-rest-api-specs\specification\communication\Communication.Messages with commit id xyz
```

The skill will orchestrate the full migration by calling MCP tools automatically.

## Troubleshooting

### Common issues

- **Generation failures**: Check that all prerequisites are installed and the target directory has proper permissions
- **Authentication errors**: Ensure you're running within a properly configured Azure SDK repository
- **Missing dependencies**: Verify .NET 10.0 runtime is installed
- **ModelContextProtocol package not found**: The NuGet.Config must include a source mapping for the `ModelContextProtocol` package to nuget.org

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.

### Adding new deterministic fix rules

1. Open `src/Mcp/DeterministicFixRegistry.cs`
2. Add a new `FixRule` to the `BuildRules()` method
3. Add a corresponding test in `tests/DeterministicFixRegistryTests.cs`
4. For new type→namespace mappings, add to the `TypeToNamespace` dictionary

## Next steps

- Explore the [Azure SDK for .NET repository](https://github.com/Azure/azure-sdk-for-net)
- Learn about [Azure SDK design guidelines](https://azure.github.io/azure-sdk/)
- Read the [SDK migration skill](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/sdk-migration/SKILL.md) for the full migration workflow

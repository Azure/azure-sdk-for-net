# Azure Generator Agent client library for .NET

A command-line tool for automating Azure SDK code generation and migration workflows. Features an MCP server with deterministic fix tools that a skill (LLM agent) calls directly to handle rule-based fixes, keeping LLM usage for only non-deterministic reasoning.

<!-- Test comment: Testing new CI separation - only .NET 10.0 should be tested -->

## Getting started

### Install the package

Install as a .NET global tool:

```bash
dotnet tool install --global Azure.GeneratorAgent
```

### Prerequisites

- [.NET 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- Git (for repository operations)

### Authenticate the client

Authentication is handled automatically when working within Azure SDK repositories.

## Key concepts

The Azure Generator Agent automates SDK code generation workflows, including code generation from service specifications and migration to new SDK patterns.

### Architecture

The agent uses a three-layer architecture:

- **MCP Server** — Exposes deterministic fix tools over the [Model Context Protocol](https://modelcontextprotocol.io/) via stdio transport. Any MCP-compatible client can invoke these tools.
- **MCP Tools** — Individual tools for regex replacements (field renames, type patterns), adding/removing using directives, nullable annotation fixes, build output parsing, error classification, code generation, commit iteration, and finalization.
- **Skill-Driven Workflow** — The skill doc (`.github/skills/sdk-migration/SKILL.md`) IS the orchestrator. The LLM reads it, calls MCP tools directly, and reasons about what to do next. No compiled C# orchestrator — the skill drives the build→classify→fix→rebuild loop.

### Deterministic Fix Registry

The `DeterministicFixRegistry` contains rules that map error codes and message patterns to specific tool invocations. Rules cover:

- **Field renames** — `_pipeline` → `Pipeline`, `_clientDiagnostics` → `ClientDiagnostics`, `_endpoint` → `Endpoint`, etc.
- **Type pattern replacements** — `ResponseWithHeaders<T,H>` → `Response<T>`, `Rest.TypeName` → `TypeName`, `Models.Models.X` → `Models.X`
- **Missing using directives** — 45+ type-to-namespace mappings (e.g., `HttpPipeline` → `Azure.Core.Pipeline`, `ClientResult` → `System.ClientModel`)
- **Obsolete using removal** — Any `using X.Rest;` namespace
- **Nullable annotations** — CS8625/CS8600 fixes

See [`.github/skills/sdk-migration-mcp/SKILL.md`](../../../.github/skills/sdk-migration-mcp/SKILL.md) for the full rule list, tool usage guide, and the skill-driven workflow.

## Examples

### Migrate an SDK

```bash
azure-generator-agent migrate <sdk-path> <local-specs-path>
```

### Generate code for an SDK

```bash
azure-generator-agent generate <sdk-path> <local-specs-path>
```

### Start as an MCP server

```bash
azure-generator-agent --mcp-server
```

This starts a stdio-based MCP server that exposes all deterministic fix tools. Connect from any MCP client (e.g., VS Code, Claude Desktop).

Available tools: `regex_replacement`, `add_using_directive`, `remove_using_directive`, `nullable_annotation_fix`, `batch_fix`, `build_and_classify`, `parse_build_output`, `classify_error`, `classify_errors`, `run_code_generation`, `validate_tsp_config`, `commit_iteration`, `pregen_cleanup`, `migrate_test_samples`, `finalize_migration`, `rename_codegen_type`, `fetch_to_fromlro`.

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
- Read the [MCP migration skill](../../../.github/skills/sdk-migration-mcp/SKILL.md) for the tool-driven workflow

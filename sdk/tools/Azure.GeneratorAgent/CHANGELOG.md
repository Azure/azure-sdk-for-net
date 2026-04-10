# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial release of Azure.GeneratorAgent, an MCP (Model Context Protocol) server that exposes deterministic fix tools for automating Azure SDK code generation and migration workflows
- MCP server mode (`McpServerHost.RunAsync`) serving tools over stdio transport with auto-discovery from the assembly at startup
- `DeterministicFixRegistry` with 27 error-pattern-to-tool rules covering field renames, type pattern replacements, missing using directives, obsolete using removal, nullable annotations, and method call replacements
- 19 individual MCP tool classes including regex replacements, nullable annotation fixes, code generation, build output parsing, error classification, test execution, commit iteration, project discovery, generated code snapshots, `[CodeGenSuppress]` attribute insertion, and finalization
- `TestResult` structured return type for the `run_tests` tool with properties for `Success`, `ExitCode`, `Passed`, `Failed`, `Skipped`, `Total`, `Failures`, `Error`, and `RawOutput`
- Skill-driven workflow via `.github/skills/sdk-migration/SKILL.md` where the LLM reads the skill doc, calls MCP tools directly, and reasons about what to do next
- Cross-platform support with proper cancellation token handling
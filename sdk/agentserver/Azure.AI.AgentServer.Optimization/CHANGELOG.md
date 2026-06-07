# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial release of `Azure.AI.AgentServer.Optimization`.
- `OptimizationConfigLoader.LoadConfig()` and `LoadConfigAsync()` — resolves optimized agent configurations from environment variable, remote API, or local directory.
- `OptimizationConfig` — immutable config object with instructions, model, temperature, skills, and tool definitions.
- `Skill` — represents a single learned skill with name, description, and body.
- `LoadSkillsFromDirectory()` — loads skills on demand from a local directory of `SKILL.md` files.

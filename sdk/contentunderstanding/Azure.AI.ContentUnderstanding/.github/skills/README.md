# Azure SDK Agent Skills

This directory contains GitHub Copilot Agent Skills for Azure SDK development. These skills are designed to be **cross-language compatible** and can be adapted for Java, Python, .NET, and JavaScript SDKs.

## Design Principles

### 1. Naming Convention

```
sdkinternal-{language}-{action}[-{qualifier}]
```

| Pattern | Examples |
|---------|----------|
| `sdkinternal-{lang}-{action}` | `sdkinternal-dotnet-sdk-compile`, `sdkinternal-dotnet-env-setup` |
| `sdkinternal-{lang}-{action}-{qualifier}` | `sdkinternal-dotnet-test-record`, `sdkinternal-dotnet-test-playback` |

### 2. Directory Structure

Skills should define **what to do**, not **how to do it**:

| Abstraction | Content | Example |
|-------------|---------|---------|
| SKILL.md | Universal description, workflow, checklist | "Compile SDK" |
| scripts/ | Language-specific implementation | `compile.ps1` / `compile.sh` |

## Available Skills

### Core SDK Skills

| Skill | Description | Priority |
|-------|-------------|----------|
| [`sdkinternal-dotnet-env-setup`](sdkinternal-dotnet-env-setup/) | Load environment variables from .env file | P0 |
| [`sdkinternal-dotnet-sdk-compile`](sdkinternal-dotnet-sdk-compile/) | Compile SDK source code | P0 |
| [`sdkinternal-dotnet-test-record`](sdkinternal-dotnet-test-record/) | Run tests in RECORD mode | P0 |
| [`sdkinternal-dotnet-test-playback`](sdkinternal-dotnet-test-playback/) | Run tests in PLAYBACK mode | P0 |
| [`sdkinternal-dotnet-test-push-recordings`](sdkinternal-dotnet-test-push-recordings/) | Push session recordings to assets repo | P1 |
| [`sdkinternal-dotnet-sample-run`](sdkinternal-dotnet-sample-run/) | Run a single sample | P1 |
| [`sdkinternal-dotnet-sample-run-all-samples`](sdkinternal-dotnet-sample-run-all-samples/) | Run all samples | P2 |

### Workflow Skills

| Skill | Description | Steps |
|-------|-------------|-------|
| [`sdkinternal-dotnet-workflow-record-push`](sdkinternal-dotnet-workflow-record-push/) | Complete RECORD and PUSH workflow | setup → compile → record → push → playback |

### Review Skills

| Skill | Description |
|-------|-------------|
| [`sdkinternal-dotnet-workflow-review-sample-quality`](sdkinternal-dotnet-workflow-review-sample-quality/) | Review sample code quality |

## Quick Start

### 1. Setup Environment

```powershell
# Load environment variables from .env file
. .github/skills/sdkinternal-dotnet-env-setup/scripts/load-env.ps1
```

### 2. Compile SDK

```powershell
# Build the SDK
.github/skills/sdkinternal-dotnet-sdk-compile/scripts/compile.ps1
```

### 3. Run Tests

```powershell
# Run tests in PLAYBACK mode
.github/skills/sdkinternal-dotnet-test-playback/scripts/test-playback.ps1

# Run tests in RECORD mode (requires Azure credentials)
.github/skills/sdkinternal-dotnet-test-record/scripts/test-record.ps1
```

### 4. Push Recordings

```powershell
# Push recordings to Azure SDK Assets repo
.github/skills/sdkinternal-dotnet-test-push-recordings/scripts/push-recordings.ps1
```

## .NET-Specific Commands

| Action | Command |
|--------|---------|
| Compile | `dotnet build` |
| Test Record | `dotnet test` with `AZURE_TEST_MODE=Record` |
| Test Playback | `dotnet test` with `AZURE_TEST_MODE=Playback` |
| Push Recordings | `test-proxy push -a assets.json` |

## 📝 Contributing

When creating new skills:

1. **Follow naming convention**: `sdk-{action}[-{qualifier}]`
2. **Include SKILL.md**: With YAML front matter (name, description)
3. **Keep description under 1024 chars**: Copilot uses it for relevance matching
4. **Single responsibility**: One skill does one thing
5. **Self-contained**: Include all needed scripts/templates
6. **Cross-language when possible**: Language-specific only when necessary

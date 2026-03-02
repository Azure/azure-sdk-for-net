---
name: analyze-ci-failures
description: Analyze CI failures on Azure SDK for .NET pull requests and post a comment with how-to-fix instructions. Use when a PR has failing checks, CI is red, or someone asks for help fixing CI.
---

# Skill: analyze-ci-failures

Analyze CI failures on an Azure SDK for .NET pull request and post a GitHub comment with actionable fix instructions.

## When Invoked

Trigger phrases: "analyze CI failures", "fix CI", "why is CI failing", "help with CI", "analyze PR checks", "CI is red", "failing checks".

## Inputs

The user must provide a **PR number**, **PR URL**, or **pipeline build ID**. If not provided, ask the user.

## Workflow

### 1. Gather information

- Fetch PR details, check statuses, changed files, and workflow runs using GitHub MCP tools.
- Extract **service directory** and **package name** from changed file paths (`sdk/<service>/<package>/`).
- If a pipeline build ID is available (often in auto-generated PR descriptions), use `azure-sdk-mcp-azsdk_analyze_pipeline` for deeper log analysis.
- For failed GitHub Actions jobs, use `github-mcp-server-get_job_logs` with `return_content: true` to get logs.

### 2. Identify failures

Classify each failure using the CI check mapping and log symptom patterns below. Also inspect the PR's code directly (e.g., read generated files for compile errors, check for missing scaffolding files).

### 3. Post a comment

Compose a GitHub comment with:
- **Header**: `## 🔍 CI Failure Analysis for PR #<number>`
- **Summary table**: All checks with ✅ ❌ ⏳ status
- **Per-failure sections**: Specific to THIS PR — include actual error messages, affected files, and concrete fix commands with `<service>`/`<package>` filled in
- **Quick fix command** at the end if applicable

Before posting, check existing comments for `## 🔍 CI Failure Analysis` to avoid duplicates.

## CI Check Name → Failure Mapping

These are the Azure DevOps and GitHub checks that run on SDK PRs. The check names are repo-specific and not discoverable from general knowledge.

| Check Name Pattern | What It Validates | Key Script |
|---|---|---|
| `Build Analyze PRBatch` | Umbrella: code generation, API export, snippets, spelling, CPM, build + pack | `eng/scripts/CodeChecks.ps1` |
| `Verify Generated Code` | Generated code matches what the generator produces | `eng/scripts/CodeChecks.ps1` |
| `Validate CPM Compliance` | Central Package Management policy | `eng/scripts/Validate-CpmCompliance.ps1` |
| `Build` / `Pack` | Compilation + NuGet packaging (ApiCompat runs during pack only) | `dotnet pack` |
| `Analyze` | Samples, READMEs, snippets compile | `eng/scripts/Build-Snippets.ps1` |
| `check-spelling` | Spell-checking changed files | `cspell` via `eng/common/scripts/check-spelling-in-changed-files.ps1` |
| `verify-links` | Markdown link validation | `eng/common/scripts/Verify-Links.ps1` |
| `checkenforcer` | Meta-check: waits for all other checks to pass | `.github/workflows/event-processor.yml` |

## Log Symptom → Root Cause Mapping

These are exact strings/patterns to search for in CI logs. They are specific to this repo's scripts and not inferrable from general knowledge.

| Log symptom | Root cause | Category |
|---|---|---|
| `Generated code is not up to date` | Generated code out of sync | Regenerate code |
| `git diff --exit-code` failure in CodeChecks | Generated or API files changed after re-running scripts | Regenerate + export API |
| `error CS####:` | C# compilation error | Build failure — inspect the specific error code |
| `Build FAILED` | Compilation failure | Build failure |
| `MembersMustExist` / `TypesMustExist` | ApiCompat breaking change (only surfaces in `dotnet pack`) | API compatibility |
| `ManagePackageVersionsCentrally` / `VersionOverride` | CPM policy violation | CPM compliance |
| `cspell` unknown words | Spelling error in code or API surface | Spelling |
| `Spell check failed` | Spelling error in API surface files | Spelling |
| README instruction format / `NuGet\\Install-Package` | README uses wrong install format (must use `dotnet add package`) | README validation |
| `verify-links` broken URL | Broken markdown links | Link verification |
| Path length exceeded | File path > 210 chars | File path issue |

## New Package Checklist

For PRs that introduce a **new SDK package** (all files are `added`, no prior version exists), also check for these commonly missing scaffolding files:

- `CHANGELOG.md`
- `README.md`
- `Directory.Build.props` (must import parent props)
- `ci.mgmt.yml` (for management-plane) or CI pipeline config
- `api/*.cs` (public API surface listings — generated via `Export-API.ps1`)
- `assets.json` (test recording assets)

Without `ci.mgmt.yml`, the Azure DevOps CI pipeline won't trigger — this is a common reason for `checkenforcer` staying permanently pending.

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
- Identify the CI provider from each failed check URL before fetching logs:
  - For an Azure DevOps URL (`dev.azure.com`), extract the `buildId`. Use `azure-sdk-mcp:azsdk_analyze_pipeline` when available.
  - If that tool is unavailable, query the public Azure DevOps timeline API with `curl`:
    `https://dev.azure.com/<organization>/<project>/_apis/build/builds/<buildId>/timeline?api-version=7.1`.
    Inspect `issues` on failed task records first. If the issues are insufficient, fetch the failed record's `log.url`.
  - For a GitHub Actions URL, use `github-mcp-server-get_job_logs` with `return_content: true`.
- Do **not** use GitHub Actions job-log tools for Azure DevOps checks; their job IDs and run IDs are unrelated.

### 2. Identify failures

Classify each failure using the CI check mapping and log symptom patterns below. Also inspect the PR's code directly (e.g., read generated files for compile errors, check for missing scaffolding files).

Diagnosis must be based on the failed task's actual error text:

- Quote the decisive error and name the affected file or project.
- Do not infer the root cause from the check name, because `Build`/`Pack` jobs also run changelog verification, package validation, and ApiCompat.
- Do not call a failure transient or flaky unless the logs contain infrastructure evidence (for example, an agent disconnect, timeout, service outage, or network failure). A documentation-only last commit does not establish flakiness because packaging validates files such as `CHANGELOG.md`.
- If logs cannot be retrieved, state that the root cause is **unconfirmed** and provide the failed task link. Do not substitute a guessed compilation or ApiCompat diagnosis.

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
| `Build` / `Pack` | Compilation + package validation, including changelog verification and ApiCompat | `dotnet pack` |
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
| `changelog entry has the following sections with no content` | Release-dated changelog contains empty template sections | Changelog validation |
| `ChangeLog verification failed` / `Verify-ChangeLog.ps1` | Changelog format or content validation failed; use the preceding error for the exact issue | Changelog validation |
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

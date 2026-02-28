---
name: analyze-ci-failures
description: Analyze CI failures on Azure SDK for .NET pull requests and post a comment with how-to-fix instructions. Use when a PR has failing checks, CI is red, or someone asks for help fixing CI.
---

# Skill: analyze-ci-failures

Analyze CI failures on an Azure SDK for .NET pull request and post a GitHub comment with actionable fix instructions.

## When Invoked

Trigger phrases: "analyze CI failures", "fix CI", "why is CI failing", "help with CI", "analyze PR checks", "CI is red", "failing checks".

## Inputs

The user must provide one of:
- A **PR number** (e.g., `#56374` or `56374`)
- A **PR URL** (e.g., `https://github.com/Azure/azure-sdk-for-net/pull/56374`)
- A **pipeline build ID** (e.g., from Azure DevOps)

If not provided, ask the user.

## Step 1 — Fetch PR and CI Status

1. Use `github-mcp-server-pull_request_read` (method: `get`) to get PR details (title, branch, labels, head SHA).
2. Use `github-mcp-server-pull_request_read` (method: `get_status`) to get check statuses.
3. Use `github-mcp-server-actions_list` (method: `list_workflow_runs`) filtered by the PR's head branch to find workflow runs.
4. For each failed or in-progress workflow run, use `github-mcp-server-actions_list` (method: `list_workflow_jobs`) to get individual job results.

Identify which checks are failing. The main CI checks for SDK PRs are:

| Check Name Pattern | What It Validates |
|---|---|
| `Build Analyze PRBatch` | Code generation, API export, snippets, spelling, CPM compliance, build + pack |
| `Verify Generated Code` | Generated code is up-to-date (runs CodeChecks.ps1) |
| `Validate CPM Compliance` | Central Package Management policy |
| `Build` / `Pack` | Compilation and NuGet packaging (includes ApiCompat) |
| `Analyze` | Samples, READMEs, snippets |
| `check-spelling` | Spell-checking changed files |
| `verify-links` | Markdown link validation |
| `checkenforcer` | Meta-check waiting for all other checks |

## Step 2 — Analyze Each Failure

For each failed job:

1. Use `github-mcp-server-get_job_logs` with `return_content: true` and `tail_lines: 200` to get the job logs.
2. If a pipeline build ID is available (from PR description or check target URL), use `azure-sdk-mcp-azsdk_analyze_pipeline` for deeper analysis.
3. Classify the failure into one of the categories below.

### Failure Categories and Fix Instructions

#### Category 1: Generated Code Out of Sync

**Symptoms in logs:**
- `"Generated code is not up to date"`
- `git diff --exit-code` fails in CodeChecks.ps1
- Files under `src/Generated/` or `api/` show differences

**Root cause:** The PR contains generated code that doesn't match what the generator produces from the current spec + customizations.

**Fix instructions:**
```
## 🔧 Fix: Generated Code Out of Sync

Your generated code is not up to date. Run these commands locally:

1. Regenerate the client code:
   ```shell
   cd sdk/<service>/<package>/src
   dotnet build /t:GenerateCode
   ```

2. Export the API surface:
   ```shell
   pwsh eng/scripts/Export-API.ps1 <service>
   ```

3. Update snippets (if applicable):
   ```shell
   pwsh eng/scripts/Update-Snippets.ps1 <service>
   ```

4. Commit all changes (including files under `Generated/` and `api/`):
   ```shell
   git add -A
   git commit -m "Regenerate code and update API listings"
   ```
```

#### Category 2: API Surface Not Exported

**Symptoms in logs:**
- Diffs in `api/*.cs` files
- `Export-API.ps1` output shows changes

**Root cause:** Public API changes were made but `api/*.cs` listing files weren't updated.

**Fix instructions:**
```
## 🔧 Fix: API Surface Not Exported

The public API listing files are out of date. Run:

```shell
pwsh eng/scripts/Export-API.ps1 <service>
git add sdk/<service>/*/api/
git commit -m "Update API listings"
```
```

#### Category 3: Build Compilation Errors

**Symptoms in logs:**
- `error CS####:` messages (C# compiler errors)
- `Build FAILED` in MSBuild output

**Root cause:** Code doesn't compile. Common causes: missing types, wrong signatures, breaking changes from generation.

**Fix instructions:**
```
## 🔧 Fix: Build Compilation Errors

The build has compilation errors. Run locally to see them:

```shell
cd sdk/<service>/<package>/src
dotnet build 2>&1 | Select-String "error CS"
```

Common fixes:
- **CS0234** (type not found): A type was renamed. Add `@@clientName` in the spec's `client.tsp` or update custom code references.
- **CS0246** (type missing): A type was removed or restructured. Check if it was merged/flattened.
- **CS0051** (accessibility): A type became internal. Use `@@access` in `client.tsp` or `[CodeGenType]` in custom code.
- **CS0111** (duplicate): Duplicate method/type. Check for conflicting custom code with generated code.

After fixing, regenerate if you changed the spec:
```shell
dotnet build /t:GenerateCode
```
```

#### Category 4: API Compatibility (Breaking Changes)

**Symptoms in logs:**
- `MembersMustExist` or `TypesMustExist` errors
- Errors from `dotnet pack` (ApiCompat runs during pack, not build)

**Root cause:** The new code removes or changes public API members that existed in the previous version.

**Fix instructions:**
```
## 🔧 Fix: API Compatibility (Breaking Changes)

The pack step detected breaking API changes. Run locally:

```shell
cd sdk/<service>/<package>/src
dotnet pack --no-restore 2>&1 | Select-String "error"
```

**Do NOT use `ApiCompatBaseline.txt` to suppress these errors.** Instead, mitigate each breaking change:

- **Missing member (renamed):** Add `@@clientName` in `client.tsp` to restore the old name, or add a wrapper method in `src/Customization/`.
- **Missing member (removed):** Add a backward-compatible shim in `src/Customization/` using `[CodeGenSuppress]` + custom implementation.
- **Changed return type:** Suppress generated method with `[CodeGenSuppress]`, provide custom method with old signature.
- **Missing type:** Recreate the type in `src/Customization/` as a partial class.

After fixing, re-export the API surface:
```shell
pwsh eng/scripts/Export-API.ps1 <service>
```
```

#### Category 5: Spelling Errors

**Symptoms in logs:**
- `cspell` output with unknown words
- `"Spell check failed"` or similar messages

**Root cause:** New code or API surface contains words not in the dictionary.

**Fix instructions:**
```
## 🔧 Fix: Spelling Errors

The spell checker found unknown words. Options:

1. **Fix the typo** in your source code or spec.
2. **Add to custom dictionary** if it's a valid domain term:
   - Open `.vscode/cspell.json`
   - Add the word to the `"words"` array
   - Commit the change

Run locally to verify:
```shell
npx cspell "sdk/<service>/**/*.cs" --config .vscode/cspell.json
```
```

#### Category 6: CPM (Central Package Management) Violations

**Symptoms in logs:**
- `"ManagePackageVersionsCentrally"` error messages
- `"VersionOverride"` detected
- `Validate-CpmCompliance.ps1` failure

**Root cause:** Package version management rules are violated.

**Fix instructions:**
```
## 🔧 Fix: CPM Compliance

Central Package Management (CPM) policy is violated. Common fixes:

- **Do NOT set `ManagePackageVersionsCentrally=false`** in your project files.
- **Do NOT use `VersionOverride`** on `<PackageReference>` items.
- **Add package versions centrally** in `eng/centralpackagemanagement/Directory.Packages.props`:
  ```xml
  <PackageVersion Include="Package.Name" Version="1.0.0" />
  ```
- **Reference packages without versions** in your `.csproj`:
  ```xml
  <PackageReference Include="Package.Name" />
  ```

Run the compliance check locally:
```shell
pwsh eng/scripts/Validate-CpmCompliance.ps1
```
```

#### Category 7: Snippet Validation Failures

**Symptoms in logs:**
- Snippet-related errors
- Diffs in markdown files from snippet updates

**Root cause:** Code snippets in markdown docs are out of sync with source code.

**Fix instructions:**
```
## 🔧 Fix: Snippet Validation

Code snippets in documentation are out of sync. Run:

```shell
pwsh eng/scripts/Update-Snippets.ps1 <service>
git add sdk/<service>/
git commit -m "Update snippets"
```
```

#### Category 8: README Validation Failures

**Symptoms in logs:**
- README instruction format errors
- Missing or incorrect installation instructions

**Root cause:** README.md doesn't follow the required format.

**Fix instructions:**
```
## 🔧 Fix: README Validation

Your README.md has formatting issues. Ensure:

1. **Installation instructions** use `dotnet CLI` format (not NuGet Package Manager):
   ```
   dotnet add package <PackageName> --version <version>
   ```

2. **Version in README** must match the latest version in CHANGELOG.md:
   - GA release: use stable version without `--prerelease`
   - Beta release: include `--prerelease` flag

3. Required sections: Description, Getting Started, Key Concepts, Examples, Troubleshooting, Next Steps.
```

#### Category 9: Link Verification Failures

**Symptoms in logs:**
- Broken link warnings/errors
- `verify-links` check failure

**Root cause:** Markdown files contain broken URLs or relative links.

**Fix instructions:**
```
## 🔧 Fix: Broken Links

Markdown files contain broken links. Check:

1. External URLs are reachable and not returning 404.
2. Relative links point to files that exist in the repo.
3. Anchor links (e.g., `#section-name`) match actual heading text.

Update or remove broken links and commit the fix.
```

#### Category 10: File Path / Naming Issues

**Symptoms in logs:**
- Path length exceeded
- Invalid filename characters

**Root cause:** File paths exceed OS limits or contain invalid characters.

**Fix instructions:**
```
## 🔧 Fix: File Path Issues

File paths exceed the maximum length or contain invalid characters.

- Keep total file path under 210 characters from the repo root.
- Avoid special characters in file/directory names.
- Clone the repo to a short path (e.g., `C:\git`) on Windows.
```

## Step 3 — Build the Comment

Compose a single GitHub comment that includes:

1. **Header**: `## 🔍 CI Failure Analysis for PR #<number>`
2. **Summary table**: List all failing checks with status icons (✅ ❌ ⏳)
3. **Detailed fix sections**: One section per failure category (from Step 2), with:
   - Failure description specific to THIS PR (include actual error messages from logs)
   - The service directory and package name extracted from the PR
   - Commands with `<service>` and `<package>` placeholders filled in
4. **Quick fix command**: If applicable, a single combined command to fix the most common issues:
   ```
   ### ⚡ Quick Fix (run all at once)
   ```shell
   cd sdk/<service>/<package>/src
   dotnet build /t:GenerateCode && \
   cd ../../../.. && \
   pwsh eng/scripts/Export-API.ps1 <service> && \
   pwsh eng/scripts/Update-Snippets.ps1 <service>
   ```
   Then commit all changes.
   ```
## Step 4 — Post the Comment

Use `github-mcp-server-pull_request_read` (method: `get_comments`) to check if a previous analysis comment exists (look for the header pattern `## 🔍 CI Failure Analysis`).

- If a previous comment exists, **do not post a duplicate**. Inform the user the analysis is already posted.
- Otherwise, post the comment. Since there is no direct "create comment" MCP tool, inform the user of the analysis and ask if they want you to post it.

**Alternative**: If the `azure-sdk-mcp-azsdk_analyze_pipeline` tool is available and a build ID can be extracted from the PR, use it for deeper pipeline analysis before composing the comment.

## Extracting Service and Package Info from PR

To fill in `<service>` and `<package>` placeholders:

1. Use `github-mcp-server-pull_request_read` (method: `get_files`) to list changed files.
2. Extract the service directory from the first `sdk/<service>/` path segment.
3. Extract the package name from `sdk/<service>/<package>/` path segment.
4. If multiple packages are changed, list instructions for each.

## Example Output Comment

```markdown
## 🔍 CI Failure Analysis for PR #56374

| Check | Status | Details |
|---|---|---|
| Build Analyze PRBatch | ❌ Failed | Generated code out of sync |
| checkenforcer | ⏳ Pending | Waiting for all checks |

### ❌ Generated Code Out of Sync

The CI detected that generated code under `sdk/computebulkactions/Azure.ResourceManager.ComputeBulkActions/src/Generated/` is not up to date.

**Fix:** Run these commands locally and push the changes:

```shell
cd sdk/computebulkactions/Azure.ResourceManager.ComputeBulkActions/src
dotnet build /t:GenerateCode
cd ../../../..
pwsh eng/scripts/Export-API.ps1 computebulkactions
pwsh eng/scripts/Update-Snippets.ps1 computebulkactions
git add -A && git commit -m "Regenerate code and update API listings"
git push
```

### ⚡ Quick Fix

```shell
cd sdk/computebulkactions/Azure.ResourceManager.ComputeBulkActions/src
dotnet build /t:GenerateCode && cd ../../../.. && pwsh eng/scripts/Export-API.ps1 computebulkactions && pwsh eng/scripts/Update-Snippets.ps1 computebulkactions
```

```

## Notes

- Always extract **actual error messages** from logs when available — generic instructions without specific errors are less helpful.
- If the pipeline build ID is in the PR description (common for auto-generated PRs), use `azure-sdk-mcp-azsdk_analyze_pipeline` for richer analysis.
- For management-plane PRs (labeled `Mgmt`), also check for ApiCompat errors which only surface during `dotnet pack`.
- For PRs from the SDK generation pipeline (title contains `[AutoPR`), the most common failures are generated code out of sync and missing API exports.

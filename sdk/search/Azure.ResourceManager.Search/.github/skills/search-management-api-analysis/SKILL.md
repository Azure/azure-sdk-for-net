---
name: search-management-api-analysis
description: Analyze Azure Search Management API spec changes between versions to identify breaking changes, new features, and required SDK customizations. Use when preparing for a new API version, asked to regenerate the Search Management SDK, or before running the create-search-management-sdk skill.
---

# Search Management API Analysis

Compare two Search Management OpenAPI spec versions and write an analysis report to `create-search-management-sdk/references/api-analysis.md`.

> **Track rule**: Always compare within the same track — preview→preview or stable→stable. Never mix tracks.

## Workflow

### Step 1: Identify baseline version

Fetch the readme to find available tags and determine the baseline (same track as target):

```
fetch_webpage: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/search/resource-manager/Microsoft.Search/Search/readme.md
```

Tags under `preview/` are the preview track; tags under `stable/` are the stable track. Pick the most recent tag in the same track as your target.

### Step 2: Find the spec PR

Search GitHub for the PR introducing the new API version:

```
https://github.com/Azure/azure-rest-api-specs/pulls?q=is%3Apr+search+<VERSION>
```

Note the PR number.

### Step 3: Download both specs locally

Download each spec to a temporary directory for diffing:

```powershell
$baselineUrl = "https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/search/resource-manager/Microsoft.Search/Search/<track>/<BASELINE_VERSION>/search.json"
$newUrl      = "https://raw.githubusercontent.com/Azure/azure-rest-api-specs/refs/pull/<PR_NUMBER>/head/specification/search/resource-manager/Microsoft.Search/Search/<track>/<NEW_VERSION>/search.json"

$tmpDir = Join-Path $PWD "git-diff-search-compare"
New-Item -ItemType Directory -Force -Path $tmpDir | Out-Null

$baselineSpec = Join-Path $tmpDir "baseline.json"
$newSpec      = Join-Path $tmpDir "new.json"

Invoke-WebRequest -Uri $baselineUrl -OutFile $baselineSpec
Invoke-WebRequest -Uri $newUrl      -OutFile $newSpec
```

Replace `<track>` with `preview` or `stable`, and fill in the version and PR number.

### Step 4: Run `git diff`

Run `git diff --no-index` against the locally downloaded files and capture the output:

```powershell
$diffOutput = git diff --no-index $baselineSpec $newSpec
```

The output is a unified diff. Lines prefixed with `+` are additions in the new spec; lines prefixed with `-` are removals from the baseline spec. Context lines have no prefix.

### Step 5: Categorize changes from `git diff` output

Read the unified diff and classify each hunk by what changed:

| Change pattern in diff | Impact | Action |
|---|---|---|
| New `+` lines for a property/operation, no corresponding `-` | Low | None (auto-generated) |
| `-` line for a type/default value replaced by `+` line | Medium | Update customization |
| `-` line for a property/model name replaced by `+` line with new name | High | Rename-mapping or obsolete stub |
| `-` lines only (property/operation/model removed, no `+` replacement) | High | Obsolete stub for backward compat |

Focus on hunks where lines are only removed (`-` with no matching `+`) — these are the most likely breaking changes requiring explicit SDK customization.

### Step 6: Write the report


Create (or overwrite) the file:

```
sdk/search/Azure.ResourceManager.Search/skills/create-search-management-sdk/references/api-analysis.md
```

Use the template in [references/REPORT-TEMPLATE.md](references/REPORT-TEMPLATE.md). Include the raw `git diff` output as an appendix.

### Step 7: Clean up downloaded specs

Remove the temporary directory after the report is written:

```powershell
Remove-Item -Recurse -Force $tmpDir
```

> `git diff --no-index` exits with code 1 when differences are found (normal behavior). Ignore the non-zero exit code in automation.

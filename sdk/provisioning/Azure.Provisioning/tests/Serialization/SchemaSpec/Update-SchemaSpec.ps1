#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Downloads the latest TypeSpec schema files from the bterlson/azure-cdk repository.

.DESCRIPTION
    Fetches all .tsp files from the typespec/ directory in bterlson/azure-cdk (main branch)
    and writes them into the SchemaSpec directory alongside this script.
    Requires the GitHub CLI (gh) to be installed and authenticated with access to the private repo.

.PARAMETER Ref
    The git ref (branch, tag, or SHA) to download from. Defaults to "main".
#>
param(
    [string]$Ref = "main"
)

$ErrorActionPreference = "Stop"

$repo = "bterlson/azure-cdk"
$remotePath = "typespec"
$scriptDir = $PSScriptRoot

# Verify gh CLI is available
if (-not (Get-Command gh -ErrorAction SilentlyContinue)) {
    throw "GitHub CLI (gh) is required. Install from https://cli.github.com/"
}

# Get the resolved commit SHA for the ref
$sha = gh api "repos/$repo/commits/$Ref" --jq '.sha' 2>&1
if ($LASTEXITCODE -ne 0) {
    throw "Failed to resolve ref '$Ref': $sha"
}
Write-Host "Resolved ref '$Ref' to SHA: $sha"

# List .tsp files in the typespec/ directory
$jqExpr = '.tree[] | select(.path | startswith("typespec/")) | select(.path | endswith(".tsp")) | .path'
$tree = gh api "repos/$repo/git/trees/${sha}?recursive=1" --jq $jqExpr 2>&1
if ($LASTEXITCODE -ne 0) {
    throw "Failed to list files: $tree"
}
$files = $tree -split "`n" | Where-Object { $_ -match '\.tsp$' }

if ($files.Count -eq 0) {
    throw "No .tsp files found under '$remotePath/' in $repo at ref '$Ref'"
}

Write-Host "Found $($files.Count) .tsp file(s) to download"

foreach ($filePath in $files) {
    $fileName = Split-Path $filePath -Leaf
    $destPath = Join-Path $scriptDir $fileName

    # Fetch file content via GitHub API (base64-encoded)
    $json = gh api "repos/$repo/contents/${filePath}?ref=$sha" 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Warning "Failed to download $filePath — $json"
        continue
    }

    # Parse JSON and decode base64 content
    $parsed = $json | ConvertFrom-Json
    $bytes = [System.Convert]::FromBase64String($parsed.content)
    $content = [System.Text.Encoding]::UTF8.GetString($bytes)

    # Write with LF line endings
    [System.IO.File]::WriteAllText($destPath, $content)
    Write-Host "  Downloaded $fileName ($($content.Length) chars)"
}

# Update SOURCE.md
$sourcemd = Join-Path $scriptDir "SOURCE.md"
$today = (Get-Date).ToString("yyyy-MM-dd")
$sourceMdContent = @"
# Schema Source

These TypeSpec files define the Azure CDK serialization AST schema.

- **Repository**: ``bterlson/azure-cdk`` (private)
- **SHA**: $sha
- **Downloaded**: $today

To update, run from this directory:

``````pwsh
./Update-SchemaSpec.ps1
``````
"@
[System.IO.File]::WriteAllText($sourcemd, $sourceMdContent)
Write-Host "`nUpdated SOURCE.md (SHA: $sha, date: $today)"
Write-Host "Done."

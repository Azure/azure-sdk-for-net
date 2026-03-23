# cSpell:ignore CODEOWNERS
<#
  .SYNOPSIS
  Tests that specified CODEOWNERS sections are identical between two file versions.

  .DESCRIPTION
  Uses the azsdk CLI to export named sections from a "before" and "after" copy of
  the CODEOWNERS file.  If any of the specified sections differ between the two
  files the script exits with code 1.

  All filesystem and git setup (creating the before/after files, installing the
  CLI, etc.) is expected to be done by the calling pipeline step template.

  .PARAMETER AzsdkCliPath
  Path to the azsdk CLI executable.

  .PARAMETER BeforeFile
  Path to the CODEOWNERS file representing the base state (e.g. parent commit).

  .PARAMETER AfterFile
  Path to the CODEOWNERS file representing the current state (e.g. PR head).

  .PARAMETER Sections
  An array of section names to compare (e.g. "Client Libraries").

  .PARAMETER TempDirectory
  Scratch directory for intermediate section export files.
#>
[CmdletBinding()]
param (
  [Parameter(Mandatory)]
  [string] $AzsdkCliPath,

  [Parameter(Mandatory)]
  [string] $BeforeFile,

  [Parameter(Mandatory)]
  [string] $AfterFile,

  [Parameter(Mandatory)]
  [string[]] $Sections,

  [string] $TempDirectory = (Join-Path ([System.IO.Path]::GetTempPath()) "codeowners-check")
)

."$PSScriptRoot\common.ps1"

Set-StrictMode -Version 3
$ErrorActionPreference = "Stop"

# ---------------------------------------------------------------------------
# 1. Validate inputs
# ---------------------------------------------------------------------------
if (-not (Test-Path $BeforeFile)) {
  Write-Error "BeforeFile not found: $BeforeFile"
  exit 1
}
if (-not (Test-Path $AfterFile)) {
  Write-Error "AfterFile not found: $AfterFile"
  exit 1
}
if (-not (Test-Path $AzsdkCliPath)) {
  Write-Error "azsdk CLI not found: $AzsdkCliPath"
  exit 1
}

# ---------------------------------------------------------------------------
# 2. Export and compare each section
# ---------------------------------------------------------------------------
$failed = $false

$beforePath = Resolve-Path $BeforeFile
Write-Host "Before file: $beforePath"
$afterPath  = Resolve-Path $AfterFile
Write-Host "After file:  $afterPath"

foreach ($section in $Sections) {
  $safeName      = $section -replace ' ', '_'
  $beforeSection = Join-Path $TempDirectory "before.${safeName}.txt"
  $afterSection  = Join-Path $TempDirectory "after.${safeName}.txt"

  Write-Host "Exporting section '$section' from before file..."
  & $AzsdkCliPath config codeowners export-section --codeowners-path $beforePath --section $section --output-file $beforeSection
  if ($LASTEXITCODE) {
    LogError "Failed to export section '$section' from before file (exit code $LASTEXITCODE)."
    exit 1
  }

  Write-Host "Exporting section '$section' from after file..."
  & $AzsdkCliPath config codeowners export-section --codeowners-path $afterPath --section $section --output-file $afterSection
  if ($LASTEXITCODE) {
    LogError "Failed to export section '$section' from after file (exit code $LASTEXITCODE)."
    exit 1
  }

  $beforeContent = Get-Content -Path $beforeSection -Raw
  $afterContent  = Get-Content -Path $afterSection -Raw

  if ($beforeContent -ne $afterContent) {
    LogError "Protected CODEOWNERS section '$section' has been modified. Changes to this section are not allowed through normal PRs. To update CODEOWNERS, follow instructions at https://aka.ms/azsdk/codeowners"
    Write-Host "--- Diff for section '$section' ---"
    Write-Host ""
    git diff --no-index -- $beforeSection $afterSection
    $failed = $true
  } else {
    Write-Host "Section '$section' is unchanged."
  }
}

# ---------------------------------------------------------------------------
# 3. Exit
# ---------------------------------------------------------------------------
if ($failed) {
  Write-Host ""
  Write-Host "##vso[task.LogIssue type=error;]One or more protected CODEOWNERS sections have been modified. Please revert changes to the 'Client Libraries', 'Management Top Level Owners', and 'Management Libraries' sections."
  exit 1
}

Write-Host "All protected CODEOWNERS sections are unchanged. Check passed."
exit 0

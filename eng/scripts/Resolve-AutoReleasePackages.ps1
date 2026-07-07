<#
.SYNOPSIS
Determines which of a pipeline's packages should be auto-released after a labeled PR merge to main.

.DESCRIPTION
Intended to run in an internal post-merge CI run on 'main'. Given the build's merge commit, this script:
  1. Uses the shared Get-GitHubAutoReleasePullRequestForCommit policy to resolve the pull request for
     the commit: it selects the newest PR merged into the base branch (default 'main') and requires the
     'auto-release' label.
  2. Builds a PR diff object (New-GitHubPullRequestDiffObject) from the PR's changed files and reuses
     the repo's existing package-detection logic (Get-PrPkgProperties) to identify the changed packages
     (honoring triggering paths, deleted files, exclude paths and service-level changes), excluding
     validation-only packages.
  3. Intersects those packages with this pipeline's declared artifacts and emits Azure DevOps output
     variables consumed by the release stages.

The script FAILS CLOSED: on any error, or if no qualifying labeled PR / changed package is found, it
emits AutoReleaseLabelPresent=false and ReleaseArtifact_<safeName>=false for every artifact and exits 0
so the CI run is not failed.

.PARAMETER CommitSha
The build source version (merge commit) to resolve the pull request from. Typically $(Build.SourceVersion).

.PARAMETER RepoId
The GitHub repository id in '<owner>/<name>' form. Typically $(Build.Repository.Name).

.PARAMETER Artifacts
JSON array of the pipeline's declared artifacts. Each entry must have 'name' and 'safeName'.
Defaults to the AUTORELEASE_ARTIFACTS environment variable, which the pipeline sets to
'${{ convertToJson(parameters.Artifacts) }}' (passed via env because it is multi-line JSON).

.PARAMETER AuthToken
GitHub token used for API calls. Defaults to the GH_TOKEN environment variable produced by
login-to-github.yml (passed via env so the secret is not written to the task command line).

.PARAMETER AutoReleaseLabel
The GitHub PR label that opts a merged PR into auto-release. Defaults to 'auto-release'.

.PARAMETER BaseBranch
The base branch a PR must have been merged into to qualify. Defaults to 'main'.

.OUTPUTS
Azure DevOps output variables (reference cross-stage via dependencies.<stage>.outputs['<job>.<step>.<name>']):
  - AutoReleasePrNumber        : the resolved PR number, or empty
  - AutoReleaseLabelPresent    : 'true' if the resolved merged PR has the auto-release label
  - HasAutoReleaseArtifacts    : 'true' if at least one declared package is releasable
  - ReleaseArtifact_<safeName> : 'true'/'false' per declared artifact
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)][string] $CommitSha,
  [Parameter(Mandatory = $true)][string] $RepoId,
  [string] $Artifacts = $env:AUTORELEASE_ARTIFACTS,
  [string] $AuthToken = $env:GH_TOKEN,
  [string] $AutoReleaseLabel = 'auto-release',
  [string] $BaseBranch = 'main'
)

$ErrorActionPreference = 'Stop'

# Import shared logic unless a caller (e.g. a test harness) has already provided it. common.ps1 provides
# Get-PrPkgProperties, the GitHub helpers, Set-PipelineVariable, $RepoRoot and language settings;
# AutoRelease-Operations.ps1 provides the shared auto-release PR selection and diff helpers. StrictMode
# is intentionally not enabled here because the shared package-detection code is not written to run under it.
if (-not (Get-Command 'Get-PrPkgProperties' -ErrorAction SilentlyContinue)) {
  . (Join-Path $PSScriptRoot ".." "common" "scripts" "common.ps1")
}
if (-not (Get-Command 'Get-GitHubAutoReleasePullRequestForCommit' -ErrorAction SilentlyContinue)) {
  . (Join-Path $PSScriptRoot ".." "common" "scripts" "AutoRelease-Operations.ps1")
}

# Parse the declared artifacts for this pipeline.
$declaredArtifacts = @()
try {
  $parsed = $Artifacts | ConvertFrom-Json
  if ($null -ne $parsed) { $declaredArtifacts = @($parsed) }
}
catch {
  Write-Host "##[warning]Failed to parse -Artifacts JSON; treating as empty. $($_.Exception.Message)"
}

# Fail-closed defaults: nothing releases unless we positively determine otherwise below.
Set-PipelineVariable -Name 'AutoReleasePrNumber' -Value '' -IsOutput
Set-PipelineVariable -Name 'AutoReleaseLabelPresent' -Value 'false' -IsOutput
Set-PipelineVariable -Name 'HasAutoReleaseArtifacts' -Value 'false' -IsOutput
foreach ($artifact in $declaredArtifacts) {
  if ($artifact.PSObject.Properties['safeName'] -and $artifact.safeName) {
    Set-PipelineVariable -Name "ReleaseArtifact_$($artifact.safeName)" -Value 'false' -IsOutput
  }
}

function Invoke-AutoReleaseResolution {
  Write-Host "Resolving the auto-release pull request for commit '$CommitSha' in '$RepoId'..."
  $release = Get-GitHubAutoReleasePullRequestForCommit `
    -RepoId $RepoId `
    -CommitSha $CommitSha `
    -TargetBranch $BaseBranch `
    -RequiredLabel $AutoReleaseLabel `
    -AuthToken $AuthToken

  if ($release.PullRequestNumber) {
    Set-PipelineVariable -Name 'AutoReleasePrNumber' -Value "$($release.PullRequestNumber)" -IsOutput
  }

  if (-not $release.IsEligible) {
    Write-Host "Skipping auto-release: $($release.SkipReason)"
    return
  }

  $pr = $release.PullRequest
  Write-Host "PR #$($pr.number) is eligible for auto-release (merged into '$BaseBranch' with the '$AutoReleaseLabel' label)."
  Set-PipelineVariable -Name 'AutoReleaseLabelPresent' -Value 'true' -IsOutput

  if ($declaredArtifacts.Count -eq 0) {
    Write-Host "No declared artifacts for this pipeline. Nothing to auto-release."
    return
  }

  # Turn the PR's changed files into a diff object (Generate-PR-Diff.ps1 shape) and reuse the repo's
  # package-detection logic to identify the changed packages.
  Write-Host "Fetching changed files for PR #$($pr.number)..."
  $files = @(Get-GitHubPullRequestFiles -RepoId $RepoId -PullRequestNumber $pr.number -AuthToken $AuthToken)
  $diff = New-GitHubPullRequestDiffObject -PullRequestNumber $pr.number -PullRequestFiles $files
  Write-Host "PR #$($pr.number) changed $($diff.ChangedFiles.Count) file(s) and deleted $($diff.DeletedFiles.Count) file(s)."

  $diffPath = Join-Path ([System.IO.Path]::GetTempPath()) ("autorelease-diff-" + [System.Guid]::NewGuid().ToString('N') + ".json")
  $diff | ConvertTo-Json -Depth 10 | Set-Content -Path $diffPath -Encoding utf8

  try {
    $changedPackages = @(Get-PrPkgProperties -InputDiffJson $diffPath)
  }
  finally {
    Remove-Item -Path $diffPath -ErrorAction SilentlyContinue
  }

  # Only release packages that were actually changed (not pulled in solely for validation).
  $releasableNames = New-Object 'System.Collections.Generic.HashSet[string]' ([System.StringComparer]::OrdinalIgnoreCase)
  foreach ($package in $changedPackages) {
    if ($package.IncludedForValidation) { continue }
    if ($package.Name) { [void]$releasableNames.Add([string]$package.Name) }
    if ($package.PSObject.Properties['ArtifactName'] -and $package.ArtifactName) { [void]$releasableNames.Add([string]$package.ArtifactName) }
  }

  $anyReleasable = $false
  foreach ($artifact in $declaredArtifacts) {
    try {
      $name = $artifact.name
      $safeName = $artifact.safeName
      if (-not $name -or -not $safeName) {
        Write-Host "  Skipping artifact with missing name/safeName."
        continue
      }

      if ($releasableNames.Contains([string]$name)) {
        Write-Host "  [$name] changed by PR #$($pr.number) -> releasable."
        Set-PipelineVariable -Name "ReleaseArtifact_$safeName" -Value 'true' -IsOutput
        $anyReleasable = $true
      }
      else {
        Write-Host "  [$name] not changed by PR #$($pr.number)."
      }
    }
    catch {
      Write-Host "##[warning]Failed to evaluate an artifact; treating as not releasable. $($_.Exception.Message)"
    }
  }

  if ($anyReleasable) {
    Set-PipelineVariable -Name 'HasAutoReleaseArtifacts' -Value 'true' -IsOutput
    Write-Host "At least one package is releasable from PR #$($pr.number)."
  }
  else {
    Write-Host "PR #$($pr.number) changed no releasable package in this pipeline."
  }
}

try {
  Invoke-AutoReleaseResolution
}
catch {
  Write-Host "##[warning]Auto-release resolution failed; skipping auto-release. $($_.Exception.Message)"
}

exit 0

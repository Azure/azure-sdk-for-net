<#
.SYNOPSIS
Determines which of a pipeline's packages should be auto-released after a labeled PR merge to main.

.DESCRIPTION
Language-agnostic. Intended to run in an internal post-merge CI run on 'main'. Given the build's merge
commit, this script:
  1. Uses the shared Get-GitHubAutoReleasePullRequestForCommit policy to resolve the pull request for
     the commit: it selects the newest PR merged into the base branch (default 'main') and requires the
     'auto-release' label.
  2. Builds a PR diff object (New-GitHubPullRequestDiffObject) from the PR's changed files and reuses
     the repo's existing package-detection logic (Get-PrPkgProperties) to identify the changed packages
     (honoring triggering paths, deleted files and service-level changes), excluding
     validation-only packages. Get-PrPkgProperties delegates to each repo's own
     Get-AllPackageInfoFromRepo (language-settings.ps1), so this script works for any language repo.
  3. Intersects those packages with this pipeline's declared artifacts and emits Azure DevOps output
     variables consumed by the release stages. Both consumption styles are emitted:
       - per-artifact ReleaseArtifact_<safeName> booleans, for pipelines that loop over their
         compile-time Artifacts list and gate each entry (e.g. .NET);
       - AutoReleaseArtifactsJson, the matched declared-artifact objects serialized as a JSON array,
         for pipelines that iterate the releasable set at runtime (e.g. Java).

The script FAILS CLOSED: on any error, or if no qualifying labeled PR / changed package is found, it
emits HasAutoReleaseArtifacts=false, AutoReleaseArtifactsJson=[] and ReleaseArtifact_<safeName>=false
for every artifact, and exits 0 so the CI run is not failed.

.PARAMETER CommitSha
The build source version (merge commit) to resolve the pull request from. Typically $(Build.SourceVersion).

.PARAMETER RepoId
The GitHub repository id in '<owner>/<name>' form. Typically $(Build.Repository.Name).

.PARAMETER Artifacts
JSON array of the pipeline's declared artifacts. Each entry must have 'name' and 'safeName'; entries may
also carry a 'groupId' (used to disambiguate name collisions across groups) and any other fields the
consuming stage needs (they are passed through unchanged in AutoReleaseArtifactsJson).
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
  - HasAutoReleaseArtifacts    : 'true' if at least one declared package is releasable
  - AutoReleaseArtifactsJson   : JSON array of the matched declared-artifact objects (or '[]')
  - ReleaseArtifact_<safeName> : 'true'/'false' per declared artifact
HasAutoReleaseArtifacts is the single eligibility gate: it is 'true' only when a merged, auto-release-labeled
PR changed at least one declared package, and it is emitted last so any earlier failure fails closed.
#>
#Requires -Version 7.0
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
  . (Join-Path $PSScriptRoot "common.ps1")
}
if (-not (Get-Command 'Get-GitHubAutoReleasePullRequestForCommit' -ErrorAction SilentlyContinue)) {
  . (Join-Path $PSScriptRoot "AutoRelease-Operations.ps1")
}

# Parse the declared artifacts.
$declaredArtifacts = @()
try {
  $parsed = $Artifacts | ConvertFrom-Json
  if ($null -ne $parsed) { $declaredArtifacts = @($parsed) }
}
catch {
  LogWarning "Failed to parse -Artifacts JSON; treating as empty. $($_.Exception.Message)"
}

# Fail-closed defaults: nothing releases unless we positively determine otherwise below.
Set-PipelineVariable -Name 'HasAutoReleaseArtifacts' -Value 'false' -IsOutput
Set-PipelineVariable -Name 'AutoReleaseArtifactsJson' -Value '[]' -IsOutput
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

  if (-not $release.IsEligible) {
    Write-Host "Skipping auto-release: $($release.SkipReason)"
    return
  }

  $pr = $release.PullRequest
  # Prefer the PR's canonical html_url; fall back to constructing it so the log link stays clickable even
  # if the field is absent from the payload.
  $prLink = if ($pr.PSObject.Properties['html_url'] -and $pr.html_url) { "$($pr.html_url)" } else { "https://github.com/$RepoId/pull/$($pr.number)" }
  Write-Host "PR $prLink is eligible for auto-release (merged into '$BaseBranch' with the '$AutoReleaseLabel' label)."

  if ($declaredArtifacts.Count -eq 0) {
    LogWarning "PR $prLink has the '$AutoReleaseLabel' label but this pipeline declares no artifacts; nothing will be auto-released."
    return
  }

  # Turn the PR's changed files into a diff object (Generate-PR-Diff.ps1 shape) and reuse the repo's
  # package-detection logic to identify the changed packages.
  Write-Host "Fetching changed files for PR $prLink..."
  $files = @(Get-GitHubPullRequestFiles -RepoId $RepoId -PullRequestNumber $pr.number -AuthToken $AuthToken)
  $diff = New-GitHubPullRequestDiffObject -PullRequestNumber $pr.number -PullRequestFiles $files
  Write-Host "PR $prLink changed $($diff.ChangedFiles.Count) file(s) and deleted $($diff.DeletedFiles.Count) file(s)."

  $diffPath = Join-Path ([System.IO.Path]::GetTempPath()) ("autorelease-diff-" + [System.Guid]::NewGuid().ToString('N') + ".json")
  $diff | ConvertTo-Json -Depth 10 | Set-Content -Path $diffPath -Encoding utf8

  try {
    $changedPackages = @(Get-PrPkgProperties -InputDiffJson $diffPath)
  }
  finally {
    Remove-Item -Path $diffPath -ErrorAction SilentlyContinue
  }

  # Build the releasable key set. Add each changed package's name and, when the group is known, a
  # 'group/name' composite so that pipelines whose declared artifacts carry a groupId (e.g. Java) match
  # the correct group and are not confused by name collisions across groups. Packages pulled in solely
  # for validation are not releasable.
  $releasableKeys = New-Object 'System.Collections.Generic.HashSet[string]' ([System.StringComparer]::OrdinalIgnoreCase)
  foreach ($package in $changedPackages) {
    if ($package.IncludedForValidation) { continue }

    $names = @()
    if ($package.Name) { $names += [string]$package.Name }
    if ($package.PSObject.Properties['ArtifactName'] -and $package.ArtifactName) { $names += [string]$package.ArtifactName }

    $group = $null
    if ($package.PSObject.Properties['Group'] -and $package.Group) { $group = [string]$package.Group }

    foreach ($name in ($names | Sort-Object -Unique)) {
      [void]$releasableKeys.Add($name)
      if ($group) { [void]$releasableKeys.Add("$group/$name") }
    }
  }

  $matchedArtifacts = @()
  foreach ($artifact in $declaredArtifacts) {
    try {
      $name = $artifact.name
      $safeName = $artifact.safeName
      if (-not $name -or -not $safeName) {
        Write-Host "  Skipping artifact with missing name/safeName."
        continue
      }

      $groupId = $null
      if ($artifact.PSObject.Properties['groupId'] -and $artifact.groupId) { $groupId = [string]$artifact.groupId }

      # Prefer a group-qualified match when the artifact declares a group; otherwise match by name.
      if ($groupId) {
        $isMatch = $releasableKeys.Contains("$groupId/$name")
      }
      else {
        $isMatch = $releasableKeys.Contains([string]$name)
      }

      if ($isMatch) {
        Write-Host "  [$name] changed by PR $prLink -> releasable."
        Set-PipelineVariable -Name "ReleaseArtifact_$safeName" -Value 'true' -IsOutput
        $matchedArtifacts += $artifact
      }
      else {
        Write-Host "  [$name] not changed by PR $prLink."
      }
    }
    catch {
      LogWarning "Failed to evaluate an artifact; treating as not releasable. $($_.Exception.Message)"
    }
  }

  if ($matchedArtifacts.Count -gt 0) {
    # Pipe (not -InputObject) with -AsArray so a single match still serializes as a JSON array, '[{...}]'.
    $artifactsJson = $matchedArtifacts | ConvertTo-Json -Depth 100 -Compress -AsArray
    Set-PipelineVariable -Name 'AutoReleaseArtifactsJson' -Value $artifactsJson -IsOutput
    Write-Host "Auto-release packages from PR ${prLink}: $((@($matchedArtifacts | ForEach-Object { $_.name })) -join ', ')"
    Set-PipelineVariable -Name 'HasAutoReleaseArtifacts' -Value 'true' -IsOutput
  }
  else {
    LogWarning "PR $prLink has the '$AutoReleaseLabel' label but changed no releasable package in this pipeline; nothing will be auto-released."
  }
}

try {
  Invoke-AutoReleaseResolution
}
catch {
  # Re-emit the fail-closed defaults so a failure after any positive signal was set (e.g. after a
  # ReleaseArtifact_<safeName> flag was flipped to 'true') cannot leak a partial "release" decision to
  # downstream stages, regardless of how each consumer gates on the outputs.
  LogWarning "Auto-release resolution failed; skipping auto-release. $($_.Exception.Message)"
  Set-PipelineVariable -Name 'HasAutoReleaseArtifacts' -Value 'false' -IsOutput
  Set-PipelineVariable -Name 'AutoReleaseArtifactsJson' -Value '[]' -IsOutput
  foreach ($artifact in $declaredArtifacts) {
    if ($artifact.PSObject.Properties['safeName'] -and $artifact.safeName) {
      Set-PipelineVariable -Name "ReleaseArtifact_$($artifact.safeName)" -Value 'false' -IsOutput
    }
  }
}

exit 0

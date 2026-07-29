#Requires -Version 7.0
<#
.SYNOPSIS
Verifies that management-plane TypeSpec commits belong to azure-rest-api-specs/main.

.PARAMETER ServiceDirectory
The service directory under sdk. Use "auto" to scan all service directories.

.PARAMETER RepoRoot
The azure-sdk-for-net repository root.

.PARAMETER SpecRepoPath
An existing azure-rest-api-specs clone. Intended for local validation and tests.

.PARAMETER ChangedFilesOnly
Only validate management-plane tsp-location.yaml files changed by the pull request.
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string]$ServiceDirectory,
  [string]$RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot "../..")),
  [string]$SpecRepoPath,
  [string]$SpecRepoUrl = "https://github.com/Azure/azure-rest-api-specs.git",
  [switch]$ChangedFilesOnly,
  [string]$SourceCommittish = $env:SYSTEM_PULLREQUEST_SOURCECOMMITID,
  [string]$TargetCommittish = ("origin/$env:SYSTEM_PULLREQUEST_TARGETBRANCH" -replace "refs/heads/")
)

function Get-MgmtTypeSpecLocations {
  param(
    [Parameter(Mandatory = $true)]
    [string]$SdkPath,
    [Parameter(Mandatory = $true)]
    [string]$ServiceDirectory
  )

  $searchRoot = if ($ServiceDirectory -eq "auto") {
    $SdkPath
  }
  else {
    Join-Path $SdkPath $ServiceDirectory
  }

  if (-not (Test-Path $searchRoot -PathType Container)) {
    throw "SDK service directory does not exist: $searchRoot"
  }

  return @(Get-ChildItem -Path $searchRoot -Filter "tsp-location.yaml" -File -Recurse |
      Where-Object { $_.Directory.Name -like "Azure.ResourceManager.*" })
}

function Get-ChangedMgmtTypeSpecLocations {
  param(
    [Parameter(Mandatory = $true)]
    [string]$RepoRoot,
    [Parameter(Mandatory = $true)]
    [string]$ServiceDirectory,
    [Parameter(Mandatory = $true)]
    [string]$SourceCommittish,
    [Parameter(Mandatory = $true)]
    [string]$TargetCommittish
  )

  git -C $RepoRoot cat-file -e "$TargetCommittish^{commit}" 2>$null
  if ($LASTEXITCODE -ne 0 -and $TargetCommittish -match "^origin/(?<branch>.+)$") {
    $targetBranch = $matches["branch"]
    git -C $RepoRoot fetch --quiet --no-tags origin `
      "+refs/heads/${targetBranch}:refs/remotes/origin/${targetBranch}"
    if ($LASTEXITCODE -ne 0) {
      throw "Failed to fetch pull request target branch '$targetBranch'."
    }
  }

  $servicePath = if ($ServiceDirectory -eq "auto") { "sdk" } else { "sdk/$ServiceDirectory" }
  $changedFiles = @(git -C $RepoRoot diff "$TargetCommittish...$SourceCommittish" `
      --name-only --diff-filter=d -- $servicePath)
  if ($LASTEXITCODE -ne 0) {
    throw "Failed to get changed files between '$TargetCommittish' and '$SourceCommittish'."
  }

  return @($changedFiles |
      Where-Object {
        $_ -match '(^|/)Azure\.ResourceManager\.[^/]+/tsp-location\.yaml$'
      } |
      ForEach-Object { Get-Item (Join-Path $RepoRoot $_) })
}

function Get-SpecMainRef {
  param(
    [Parameter(Mandatory = $true)]
    [string]$RepositoryPath
  )

  foreach ($ref in @("refs/remotes/origin/main", "refs/heads/main")) {
    git -C $RepositoryPath show-ref --verify --quiet $ref
    if ($LASTEXITCODE -eq 0) {
      return $ref
    }
  }

  throw "The specs repository at '$RepositoryPath' does not contain a main branch."
}

function Test-SpecCommitOnMain {
  param(
    [Parameter(Mandatory = $true)]
    [string]$RepositoryPath,
    [Parameter(Mandatory = $true)]
    [string]$MainRef,
    [Parameter(Mandatory = $true)]
    [string]$Commit
  )

  git -C $RepositoryPath cat-file -e "$Commit^{commit}" 2>$null
  if ($LASTEXITCODE -ne 0) {
    return $false
  }

  git -C $RepositoryPath merge-base --is-ancestor $Commit $MainRef
  return $LASTEXITCODE -eq 0
}

function Invoke-MgmtTypeSpecCommitVerification {
  param(
    [Parameter(Mandatory = $true)]
    [string]$ServiceDirectory,
    [Parameter(Mandatory = $true)]
    [string]$RepoRoot,
    [string]$SpecRepoPath,
    [Parameter(Mandatory = $true)]
    [string]$SpecRepoUrl,
    [switch]$ChangedFilesOnly,
    [string]$SourceCommittish,
    [string]$TargetCommittish
  )

  $tspLocations = if ($ChangedFilesOnly) {
    Get-ChangedMgmtTypeSpecLocations `
      -RepoRoot $RepoRoot `
      -ServiceDirectory $ServiceDirectory `
      -SourceCommittish $SourceCommittish `
      -TargetCommittish $TargetCommittish
  }
  else {
    Get-MgmtTypeSpecLocations `
      -SdkPath (Join-Path $RepoRoot "sdk") `
      -ServiceDirectory $ServiceDirectory
  }

  if ($tspLocations.Count -eq 0) {
    Write-Host "No management-plane tsp-location.yaml files require validation for '$ServiceDirectory'."
    return
  }

  if (-not (Get-Command ConvertFrom-Yaml -ErrorAction Ignore)) {
    . (Join-Path $PSScriptRoot "../common/scripts/Helpers/PSModule-Helpers.ps1")
    Install-ModuleIfNotInstalled "powershell-yaml" "0.4.7" | Import-Module
  }

  $temporarySpecRepo = $null
  if (-not $SpecRepoPath) {
    $temporarySpecRepo = Join-Path ([IO.Path]::GetTempPath()) "azure-rest-api-specs-$([guid]::NewGuid())"
    git clone --quiet --filter=tree:0 --no-checkout --single-branch --branch main $SpecRepoUrl $temporarySpecRepo
    if ($LASTEXITCODE -ne 0) {
      throw "Failed to clone azure-rest-api-specs/main from '$SpecRepoUrl'."
    }
    $SpecRepoPath = $temporarySpecRepo
  }

  try {
    $mainRef = Get-SpecMainRef -RepositoryPath $SpecRepoPath
    $errors = [System.Collections.Generic.List[string]]::new()

    foreach ($tspLocation in $tspLocations) {
      $config = Get-Content -Path $tspLocation.FullName -Raw | ConvertFrom-Yaml
      $repo = $config["repo"]
      $commit = $config["commit"]

      if ($repo -ne "Azure/azure-rest-api-specs") {
        $errors.Add("$($tspLocation.FullName): repo must be 'Azure/azure-rest-api-specs', but is '$repo'.")
        continue
      }

      if ($commit -eq "main") {
        Write-Host "$($tspLocation.FullName): commit is main."
        continue
      }

      if ($commit -notmatch "^[0-9a-fA-F]{40}$") {
        $errors.Add("$($tspLocation.FullName): commit must be 'main' or a 40-character SHA, but is '$commit'.")
        continue
      }

      if (-not (Test-SpecCommitOnMain -RepositoryPath $SpecRepoPath -MainRef $mainRef -Commit $commit)) {
        $errors.Add("$($tspLocation.FullName): commit '$commit' does not belong to Azure/azure-rest-api-specs main.")
        continue
      }

      Write-Host "$($tspLocation.FullName): commit '$commit' belongs to Azure/azure-rest-api-specs main."
    }

    if ($errors.Count -gt 0) {
      throw ($errors -join [Environment]::NewLine)
    }
  }
  finally {
    if ($temporarySpecRepo -and (Test-Path $temporarySpecRepo)) {
      Remove-Item -Path $temporarySpecRepo -Recurse -Force
    }
  }
}

if ($MyInvocation.InvocationName -ne ".") {
  Invoke-MgmtTypeSpecCommitVerification `
    -ServiceDirectory $ServiceDirectory `
    -RepoRoot $RepoRoot `
    -SpecRepoPath $SpecRepoPath `
    -SpecRepoUrl $SpecRepoUrl `
    -ChangedFilesOnly:$ChangedFilesOnly `
    -SourceCommittish $SourceCommittish `
    -TargetCommittish $TargetCommittish
}

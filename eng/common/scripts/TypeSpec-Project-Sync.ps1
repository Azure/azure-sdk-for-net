# For details see https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/TypeSpec-Project-Scripts.md

[CmdletBinding()]
param (
  [Parameter(Position = 0)]
  [ValidateNotNullOrEmpty()]
  [string] $ProjectDirectory,
  [Parameter(Position = 1)]
  [string] $LocalSpecRepoPath
)

$ErrorActionPreference = "Stop"
. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.7" | Import-Module
$sparseCheckoutFile = ".git/info/sparse-checkout"

function AddSparseCheckoutPath([string]$subDirectory) {
  if (!(Test-Path $sparseCheckoutFile) -or !((Get-Content $sparseCheckoutFile).Contains($subDirectory))) {
    Write-Output $subDirectory >> .git/info/sparse-checkout
  }
}

function CopySpecToProjectIfNeeded([string]$specCloneRoot, [string]$mainSpecDir, [string]$dest, [string[]]$specAdditionalSubDirectories) {
  $source = Join-Path $specCloneRoot $mainSpecDir
  Copy-Item -Path $source -Destination $dest -Recurse -Force
  Write-Host "Copying spec from $source to $dest"

  foreach ($additionalDir in $specAdditionalSubDirectories) {
    $source = Join-Path $specCloneRoot $additionalDir
    Write-Host "Copying spec from $source to $dest"
    Copy-Item -Path $source -Destination $dest -Recurse -Force
  }
}

function UpdateSparseCheckoutFile([string]$mainSpecDir, [string[]]$specAdditionalSubDirectories) {
  AddSparseCheckoutPath $mainSpecDir
  foreach ($subDir in $specAdditionalSubDirectories) {
    Write-Host "Adding $subDir to sparse checkout"
    AddSparseCheckoutPath $subDir
  }
}

function GetGitRemoteValue([string]$repo) {
  Push-Location $ProjectDirectory
  $result = ""
  try {
    $gitRemotes = (git remote -v)
    foreach ($remote in $gitRemotes) {
      Write-Host "Checking remote $remote"
      if ($remote.StartsWith("origin") -or $remote.StartsWith("main")) {
        if ($remote -match 'https://(.*)?github.com/\S+') {
          $result = "https://github.com/$repo.git"
          break
        }
        elseif ($remote -match "(.*)?git@github.com:\S+") {
          $result = "git@github.com:$repo.git"
          break
        }
        else {
          throw "Unknown git remote format found: $remote"
        }
      }
    }
  }
  finally {
    Pop-Location
  }
  Write-Host "Found git remote $result"
  return $result
}

function InitializeSparseGitClone([string]$repo) {
  git clone --no-checkout --filter=tree:0 $repo .
  if ($LASTEXITCODE) { exit $LASTEXITCODE }
  git sparse-checkout init
  if ($LASTEXITCODE) { exit $LASTEXITCODE }
  Remove-Item $sparseCheckoutFile -Force
}

function GetSpecCloneDir([string]$projectName) {
  Push-Location $ProjectDirectory
  try {
    $root = git rev-parse --show-toplevel
  }
  finally {
    Pop-Location
  }

  $sparseSpecCloneDir = "$root/../sparse-spec/$projectName"
  New-Item $sparseSpecCloneDir -Type Directory -Force | Out-Null
  $createResult = Resolve-Path $sparseSpecCloneDir
  return $createResult
}

$typespecConfigurationFile = Resolve-Path "$ProjectDirectory/tsp-location.yaml"
Write-Host "Reading configuration from $typespecConfigurationFile"
$configuration = Get-Content -Path $typespecConfigurationFile -Raw | ConvertFrom-Yaml

$pieces = $typespecConfigurationFile.Path.Replace("\", "/").Split("/")
$projectName = $pieces[$pieces.Count - 2]

$specSubDirectory = $configuration["directory"]

# use local spec repo if provided
if ($LocalSpecRepoPath) {
  $specCloneDir = $LocalSpecRepoPath
}
elseif ($configuration["repo"] -and $configuration["commit"]) {
  # use sparse clone if repo and commit are provided
  $specCloneDir = GetSpecCloneDir $projectName
  $gitRemoteValue = GetGitRemoteValue $configuration["repo"]

  Write-Host "from tsplocation.yaml 'repo' is:"$configuration["repo"]
  Write-Host "Setting up sparse clone for $projectName at $specCloneDir"

  Push-Location $specCloneDir.Path
  try {
    if (!(Test-Path ".git")) {
      Write-Host "Initializing sparse clone for repo: $gitRemoteValue"
      InitializeSparseGitClone $gitRemoteValue
    }
    Write-Host "Updating sparse checkout file with directory:$specSubDirectory"
    UpdateSparseCheckoutFile $specSubDirectory $configuration["additionalDirectories"]
    $commit = $configuration["commit"]
    Write-Host "git checkout commit: $commit"
    git checkout $configuration["commit"]
    if ($LASTEXITCODE) { exit $LASTEXITCODE }
  }
  finally {
    Pop-Location
  }
}
else {
  # write error if neither local spec repo nor repo and commit are provided
  Write-Error "Must contain both 'repo' and 'commit' in tsp-location.yaml or input 'localSpecRepoPath' parameter."
  exit 1
}

$tempTypeSpecDir = "$ProjectDirectory/TempTypeSpecFiles"
New-Item $tempTypeSpecDir -Type Directory -Force | Out-Null
CopySpecToProjectIfNeeded `
  -specCloneRoot $specCloneDir `
  -mainSpecDir $specSubDirectory `
  -dest $tempTypeSpecDir `
  -specAdditionalSubDirectories $configuration["additionalDirectories"]

exit 0

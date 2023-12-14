# Description: This script is used to verify the specs used to generate SDK package point to the main branch of Azure/azure-rest-api-specs repository
[CmdletBinding()]
param (
  [Parameter(Position = 0)]
  [ValidateNotNullOrEmpty()]
  [string] $ServiceDirectory,
  [Parameter(Position = 1)]
  [ValidateNotNullOrEmpty()]
  [string] $PackageName
)

. $PSScriptRoot/common.ps1
. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

# This function is used to verify the 'require' and 'input-file' settings in autorest.md point to the main branch of Azure/azure-rest-api-specs repository
function Verify-AutorestMd([string]$fileUrl) {
  if($fileUrl -match "^https://github.com/(?<repo>[^/]*/azure-rest-api-specs)/blob/(?<commit>[0-9a-f]{40})/(?<path>.*)") {
    $repo = $matches['repo']
    $commit = $matches['commit']
    if($repo -ne "Azure/azure-rest-api-specs") {
      LogError "Invalid repo in the file url: $fileUrl. Repo should be 'Azure/azure-rest-api-specs'."
      exit 1
    }
    # check the commit hash belongs to main branch
    Verify-CommitFromMainBranch $commit
  }
  else{
    LogError "Invalid file url: $fileUrl"
    exit 1
  }
}

# This function is used to verify the 'repo' and 'commit' settings in tsp-location.yaml point to the main branch of Azure/azure-rest-api-specs repository
function Verify-TspLocation([System.Object]$tspLocationObj) {
  $repo = $tspLocationObj["repo"]
  $commit = $tspLocationObj["commit"]
  if($repo -ne "Azure/azure-rest-api-specs") {
    LogError "Invalid repo setting in the tsp-location.yaml: $repo. Repo should be 'Azure/azure-rest-api-specs'."
    exit 1
  }

  # check the commit hash belongs to main branch
  Verify-CommitFromMainBranch $commit
}

# This function is used to verify the specific 'commit' belongs to the main branch of Azure/azure-rest-api-specs repository
function Verify-CommitFromMainBranch([string]$commit) {
  $mainBranch = "main"
  $specRepoCloneDir = "./tmp_spec_repo"
  New-Item $specRepoCloneDir -Type Directory -Force | Out-Null
  Push-Location $specRepoCloneDir

  try {
    $repoRemoteUrl = Get-GitRemoteValue "Azure/azure-rest-api-specs"
    git clone -b main $repoRemoteUrl .
    if ($LASTEXITCODE) { exit $LASTEXITCODE }
    $result = git branch --contains $commit | Select-String -Pattern $mainBranch
    if($result) {
      LogDebug "Commit $commit is from $mainBranch branch."
    } else {
      LogError "Commit $commit is not from $mainBranch branch."
      exit 1
    }
  }
  finally {
    Pop-Location
    Remove-Item $specRepoCloneDir -Force -Recurse
  }
}

# This function is used to get the git remote value for the specific repo
function Get-GitRemoteValue([string]$repo) {
  $result = ""  
  $gitRemotes = (git remote -v)
  foreach ($remote in $gitRemotes) {
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
  
  LogDebug "Found git remote $result"
  return $result
}

try{
  $ServiceDir = Join-Path $RepoRoot 'sdk' $ServiceDirectory
  $PackageDirectory = Join-Path $ServiceDir $PackageName
  Push-Location $PackageDirectory

  # Load tsp-location.yaml if existed
  $tspLocationYamlPath = Join-Path $PackageDirectory "tsp-location.yaml"
  $autorestMdPath = Join-Path $PackageDirectory "src/autorest.md"
  #$autorestMdPath = ".\autorest1.md"
  #$Language = "dotnet"
  $tspLocationYaml = @{}
  if (Test-Path -Path $tspLocationYamlPath) {
    # typespec scenario
    $tspLocationYaml = Get-Content -Path $tspLocationYamlPath -Raw | ConvertFrom-Yaml
    Verify-TspLocation $tspLocationYaml
  }
  elseif ($Language -eq "dotnet") {
    # only dotnet language sdk uses 'autorest.md' to configure the sdk generation, ignore this validation for the other languages
    if (Test-Path -Path $autorestMdPath) {
      $autorestMdContent = Get-Content -Path $autorestMdPath -Raw
      $yamlContent = $autorestMdContent -split '``` yaml|```'
      $yamlSection = $yamlContent[1]
      if ($yamlSection) {
        $yamlobj = ConvertFrom-Yaml -Yaml $yamlSection
        $requireValue = $yamlobj["require"]
        $inputFileValue = $yamlobj["input-file"]
        if ($requireValue) {
          LogDebug "require is set as:$requireValue"
          Verify-AutorestMd $requireValue
        }
        elseif ($inputFileValue) {
          LogDebug "input-file is set as:$inputFileValue"
          foreach($inputFile in $inputFileValue) {
            Verify-AutorestMd $inputFile
          }
        }
        else {
          LogWarning "Both 'require' and 'input-file' haven't been found in $autorestMdPath."
          exit 0
        }
      }
    }
    else {
      LogWarning "autorest.md hasn't been found in $packageDir for language: $Language"
      exit 0
    }
    Write-Host "creating tsp-location.yaml in $packageDir"
  }
  else {
    LogWarning "tsp-location.yaml hasn't been found in $packageDir for language: $Language"
    exit 0
  }
}
finally {
  Pop-Location
}
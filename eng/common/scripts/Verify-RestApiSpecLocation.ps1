# Description: This script is used to verify the specs used to generate SDK package point to the main branch of Azure/azure-rest-api-specs repository
[CmdletBinding()]
param (
  [Parameter(Position = 0)]
  [ValidateNotNullOrEmpty()]
  [string] $ServiceDirectory,
  [Parameter(Position = 1)]
  [ValidateNotNullOrEmpty()]
  [string] $PackageName,
  [Parameter(Position = 2)]
  [ValidateNotNullOrEmpty()]
  [string]$GitHubPat
)

. $PSScriptRoot/common.ps1
. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
. $PSScriptRoot/Invoke-GitHubAPI.ps1
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
  try {
    $searchResult = Search-GitHubCommit -AuthToken $GitHubPat -CommitHash "0f39a2d56070d2bc4251494525cb8af88583a938" -RepoOwner "Azure" -RepoName "azure-rest-api-specs"
    if ($searchResult.total_count -lt 1) {
      LogError "Commit $commit doesn't exist in 'main' branch of Azure/azure-rest-api-specs repository."
      exit 1
    }
    else{
      LogDebug "Commit $commit exists in 'main' branch of Azure/azure-rest-api-specs repository."
    }
  }
  catch {
    LogError "Failed to search commit $commit with exception:`n$_"
    exit 1
  }
}

try{
  $ServiceDir = Join-Path $RepoRoot 'sdk' $ServiceDirectory
  $PackageDirectory = Join-Path $ServiceDir $PackageName
  Push-Location $PackageDirectory

  # Load tsp-location.yaml if existed
  $tspLocationYamlPath = Join-Path $PackageDirectory "tsp-location.yaml"
  $autorestMdPath = Join-Path $PackageDirectory "src/autorest.md"
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
      LogWarning "autorest.md hasn't been found in $PackageDirectory for language: $Language"
      exit 0
    }
  }
  else {
    LogWarning "tsp-location.yaml hasn't been found in $PackageDirectory for language: $Language"
    exit 0
  }
}
finally {
  Pop-Location
}
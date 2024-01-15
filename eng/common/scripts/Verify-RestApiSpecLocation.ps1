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
# input-file may be: 
# https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/purview/data-plane/Azure.Analytics.Purview.MetadataPolicies/preview/2021-07-01-preview/purviewMetadataPolicy.json
# or 
# https://github.com/Azure/azure-rest-api-specs/blob/0ebd4949e8e1cd9537ca5a07384c7661162cc7a6/specification/purview/data-plane/Azure.Analytics.Purview.Account/preview/2019-11-01-preview/account.json
function Verify-AutorestMd([string]$fileUrl) {
  if($fileUrl -match "^https://raw.githubusercontent.com/(?<repo>[^/]*/azure-rest-api-specs)/(?<commit>[^\/]+(\/[^\/]+)*|[0-9a-f]{40})/(?<path>specification/.*)") {
    $repo = $matches['repo']
    $commit = $matches['commit']
    if($repo -ne "Azure/azure-rest-api-specs") {
      LogError "ServiceDir:$ServiceDirectory, PackageName:$PackageName. Invalid repo in the file url: $fileUrl. Repo should be 'Azure/azure-rest-api-specs'."
      exit 1
    }
    # check the commit hash belongs to main branch
    Verify-CommitFromMainBranch $commit
  }
  elseif($fileUrl -match "^https://github.com/(?<repo>[^/]*/azure-rest-api-specs)/(blob|tree)/(?<commit>[^\/]+(\/[^\/]+)*|[0-9a-f]{40})/(?<path>specification/.*)") {
    $repo = $matches['repo']
    $commit = $matches['commit']
    if($repo -ne "Azure/azure-rest-api-specs") {
      LogError "ServiceDir:$ServiceDirectory, PackageName:$PackageName. Invalid repo in the file url: $fileUrl. Repo should be 'Azure/azure-rest-api-specs'."
      exit 1
    }
    # check the commit hash belongs to main branch
    Verify-CommitFromMainBranch $commit
  }
  else{
    LogError "ServiceDir:$ServiceDirectory, PackageName:$PackageName. Invalid file url: $fileUrl"
    exit 1
  }
}

# This function is used to verify the 'repo' and 'commit' settings in tsp-location.yaml point to the main branch of Azure/azure-rest-api-specs repository
function Verify-TspLocation([System.Object]$tspLocationObj) {
  $repo = $tspLocationObj["repo"]
  $commit = $tspLocationObj["commit"]
  if($repo -ne "Azure/azure-rest-api-specs") {
    LogError "Invalid repo setting in the tsp-location.yaml: $repo. Repo should be 'Azure/azure-rest-api-specs'. ServiceDir:$ServiceDirectory, PackageName:$PackageName"
    exit 1
  }

  # check the commit hash belongs to main branch
  Verify-CommitFromMainBranch $commit
}

# This function is used to verify the specific 'commit' belongs to the main branch of Azure/azure-rest-api-specs repository
function Verify-CommitFromMainBranch([string]$commit) {
  if($commit -notmatch "^[0-9a-f]{40}$" -and $commit -ne "main") {
    LogError "Invalid commit hash or branch name: $commit. Branch name should be 'main' or the commit should be a 40-character SHA-1 hash. ServiceDir:$ServiceDirectory, PackageName:$PackageName"
    exit 1
  }
  if($commit -eq "main") {
    Write-Host "ServiceDir:$ServiceDirectory, PackageName:$PackageName. Branch is $commit branch of Azure/azure-rest-api-specs repository."
    return
  }
  try {
    $searchResult = Search-GitHubCommit -AuthToken $GitHubPat -CommitHash $commit -RepoOwner "Azure" -RepoName "azure-rest-api-specs"
    if ($searchResult.total_count -lt 1) {
      LogError "Commit $commit doesn't exist in 'main' branch of Azure/azure-rest-api-specs repository. ServiceDir:$ServiceDirectory, PackageName:$PackageName"
      exit 1
    }
    else{
      Write-Host "ServiceDir:$ServiceDirectory, PackageName:$PackageName. Commit $commit exists in 'main' branch of Azure/azure-rest-api-specs repository."
    }
  }
  catch {
    LogError "ServiceDir:$ServiceDirectory, PackageName:$PackageName. Failed to search commit $commit with exception:`n$_ "
    exit 1
  }
}

function Verify-Content([string]$markdownContent) {
  $splitString = '``` yaml|```yaml|```'
  $yamlContent = $markdownContent -split $splitString
  foreach($yamlSection in $yamlContent) {
    if ($yamlSection) {
      try {
        # remove the lines like: $(tag) == 'package-preview-2023-09'
        $yamlSection = $yamlSection -replace '^\s*\$\(.+\)\s*==.+', ''
        $yamlobj = ConvertFrom-Yaml -Yaml $yamlSection
        if($yamlobj) {
          $batchValue = $yamlobj["batch"]
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
          elseif ($batchValue) {
            # there are some services which use batch mode for sdk generation, e.g. Azure.AI.Language.QuestionAnswering
            foreach($batch in $batchValue) {
              $requireValue = $batch["require"]
              $inputFileValue = $batch["input-file"]
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
            }
          }
        }
      }
      catch {
        Write-Host "ServiceDir:$ServiceDirectory, PackageName:$PackageName. Failed to parse yaml section $yamlSection with exception:`n$_ "
      }
    }
  }
}

try{
  $ServiceDir = Join-Path $RepoRoot 'sdk' $ServiceDirectory
  $PackageDirectory = Join-Path $ServiceDir $PackageName
  Push-Location $PackageDirectory

  # Load tsp-location.yaml if existed
  $tspLocationYamlPath = Join-Path $PackageDirectory "tsp-location.yaml"
  $autorestMdPath = Join-Path $PackageDirectory "src/autorest.md"
  $swaggerReadmePath = Join-Path $PackageDirectory "swagger/README.md"
  $tspLocationYaml = @{}
  if (Test-Path -Path $tspLocationYamlPath) {
    # typespec scenario
    $tspLocationYaml = Get-Content -Path $tspLocationYamlPath -Raw | ConvertFrom-Yaml
    Verify-TspLocation $tspLocationYaml
  }
  elseif ($Language -eq "dotnet") {
    # only dotnet language sdk uses 'autorest.md' to configure the sdk generation
    if (Test-Path -Path $autorestMdPath) {
      try {
        $autorestMdContent = Get-Content -Path $autorestMdPath -Raw
        Verify-Content $autorestMdContent
      }
      catch {
        Write-Host "ServiceDir:$ServiceDirectory, PackageName:$PackageName. Failed to parse autorest.md file with exception:`n$_ "
      }
    }
  }
  elseif ($Language -eq "java" -or $Language -eq "js") {
    # java language sdk uses 'swagger/readme.md' to configure the sdk generation
    if (Test-Path -Path $swaggerReadmePath) {
      try {
        $swaggerReadmeContent = Get-Content -Path $swaggerReadmePath -Raw
        Verify-Content $swaggerReadmeContent
      }
      catch {
        Write-Host "ServiceDir:$ServiceDirectory, PackageName:$PackageName. Failed to parse swagger/readme.md file with exception:`n$_ "
      }
    }
  }
}
finally {
  Pop-Location
}
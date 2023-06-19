# For details see https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/TypeSpec-Project-Scripts.md

[CmdletBinding()]
param (
  [Parameter(Position = 0)]
  [ValidateNotNullOrEmpty()]
  [string] $TypeSpecProjectDirectory, # A directory of `tspconfig.yaml` or a remoteUrl of `tspconfig.yaml`
  [Parameter(Position = 1)]
  [string] $CommitHash,
  [Parameter(Position = 2)]
  [string] $RepoUrl
)

. $PSScriptRoot/common.ps1
. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

function CreateUpdate-TspLocation([System.Object]$tspConfig, [string]$TypeSpecProjectDirectory, [string]$CommitHash, [string]$repo, [string]$repoRoot) {
  $serviceDir = ""
  $additionalDirs = @()

  # Parse tspcofig.yaml to get service-dir, additionalDirectories, and package-dir
  if ($tspConfig["parameters"] -and $tspConfig["parameters"]["service-dir"]) {
    $serviceDir = $tspConfig["parameters"]["service-dir"]["default"];
  }
  else {
    Write-Error "Missing service-dir in parameters section of tspconfig.yaml."
    exit 1
  }
  if ($tspConfig["parameters"]["dependencies"] -and $tspConfig["parameters"]["dependencies"]["additionalDirectories"]) {
    $additionalDirs = $tspConfig["parameters"]["dependencies"]["additionalDirectories"];
  }

  $packageDir = Get-PackageDir $tspConfig

  # Create service-dir if not exist
  $serviceDir = Join-Path $repoRoot $serviceDir
  if (!(Test-Path -Path $serviceDir)) {
    New-Item -Path $serviceDir -ItemType Directory
    Write-Host "created service folder $serviceDir"
  }

  # Create package-dir if not exist
  $packageDir = Join-Path $serviceDir $packageDir
  if (!(Test-Path -Path $packageDir)) {
    New-Item -Path $packageDir -ItemType Directory
    Write-Host "created package folder $packageDir"
  }

  # Load tsp-location.yaml if exist
  $tspLocationYamlPath = Join-Path $packageDir "tsp-location.yaml"
  $tspLocationYaml = @{}
  if (Test-Path -Path $tspLocationYamlPath) {
    $tspLocationYaml = Get-Content -Path $tspLocationYamlPath -Raw | ConvertFrom-Yaml
  }
  else {
    Write-Host "creating tsp-location.yaml in $packageDir"
  }

  # Update tsp-location.yaml
  $tspLocationYaml["commit"] = $CommitHash
  $tspLocationYaml["repo"] = $repo
  $tspLocationYaml["directory"] = $TypeSpecProjectDirectory
  $tspLocationYaml["additionalDirectories"] = $additionalDirs
  $tspLocationYaml |ConvertTo-Yaml | Out-File $tspLocationYamlPath
  Write-Host "updated tsp-location.yaml in $packageDir"
  return $packageDir
}

function Get-PackageDir([System.Object]$tspConfig) {
  $emitterName = ""
  if (Test-Path "Function:$GetEmitterNameFn") {
    $emitterName = &$GetEmitterNameFn
  }
  else {
    Write-Error "Missing $GetEmitterNameFn function in {$Language} SDK repo script."
    exit 1
  }
  $packageDir = ""
  if ($tspConfig["options"] -and $tspConfig["options"]["$emitterName"] -and $tspConfig["options"]["$emitterName"]["package-dir"]) {
    $packageDir = $tspConfig["options"]["$emitterName"]["package-dir"]
  }
  else {
    Write-Error "Missing package-dir in $emitterName options of tspconfig.yaml."
    exit 1
  }
  return $packageDir
}

$repo = ""
if ($RepoUrl) {
  if ($RepoUrl -match "^https://github.com/(?<repo>[^/]*/azure-rest-api-specs(-pr)?).*") {
    $repo = $Matches["repo"]
  }
  else {
    Write-Host "Parameter 'RepoUrl' has incorrect value: $RepoUrl. It should be similar like 'https://github.com/Azure/azure-rest-api-specs'"
    exit 1
  }
}

$repoRootPath =  (Join-Path $PSScriptRoot .. .. ..)
$repoRootPath = Resolve-Path $repoRootPath
$repoRootPath = $repoRootPath -replace "\\", "/"
$tspConfigPath = Join-Path $repoRootPath 'tspconfig.yaml'
# example url of tspconfig.yaml: https://github.com/Azure/azure-rest-api-specs-pr/blob/724ccc4d7ef7655c0b4d5c5ac4a5513f19bbef35/specification/containerservice/Fleet.Management/tspconfig.yaml
if ($TypeSpecProjectDirectory -match '^https://github.com/(?<repo>Azure/azure-rest-api-specs(-pr)?)/blob/(?<commit>[0-9a-f]{40})/(?<path>.*)/tspconfig.yaml$') {
  try {
    $TypeSpecProjectDirectory = $TypeSpecProjectDirectory -replace "github.com", "raw.githubusercontent.com"
    $TypeSpecProjectDirectory = $TypeSpecProjectDirectory -replace "/blob/", "/"
    Invoke-WebRequest $TypeSpecProjectDirectory -OutFile $tspConfigPath -MaximumRetryCount 3
  }
  catch {
    Write-Host "Failed to download '$TypeSpecProjectDirectory'"
    Write-Error $_.Exception.Message
    return
  }
  $repo = $Matches["repo"]
  $TypeSpecProjectDirectory = $Matches["path"]
  $CommitHash = $Matches["commit"]
  # TODO support the branch name in url then get the commithash from branch name
} else {
  $tspConfigPath = Join-Path $TypeSpecProjectDirectory "tspconfig.yaml"
  if (!(Test-Path $tspConfigPath)) {
    Write-Error "Failed to find tspconfig.yaml in '$TypeSpecProjectDirectory'"
    exit 1
  }
}
$tspConfigYaml = Get-Content $tspConfigPath -Raw | ConvertFrom-Yaml
# call CreateUpdate-TspLocation function
$sdkProjectFolder = CreateUpdate-TspLocation $tspConfigYaml $TypeSpecProjectDirectory $CommitHash $repo $repoRootPath

# call TypeSpec-Project-Sync.ps1
& "$PSScriptRoot/TypeSpec-Project-Sync.ps1" $sdkProjectFolder
# call TypeSpec-Project-Generate.ps1
& "$PSScriptRoot/TypeSpec-Project-Generate.ps1" $sdkProjectFolder
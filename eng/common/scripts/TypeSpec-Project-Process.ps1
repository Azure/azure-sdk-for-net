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
  $additionalDirs = @()
  if ($tspConfig["parameters"]["dependencies"] -and $tspConfig["parameters"]["dependencies"]["additionalDirectories"]) {
    $additionalDirs = $tspConfig["parameters"]["dependencies"]["additionalDirectories"];
  }

  # Create service-dir if not exist
  $serviceDir = Get-ServiceDir $tspConfig $repoRoot
  if (!(Test-Path -Path $serviceDir)) {
    New-Item -Path $serviceDir -ItemType Directory | Out-Null
    Write-Host "created service folder $serviceDir"
  }

  # Create package-dir if not exist
  $packageDir = Get-PackageDir $tspConfig
  $packageDir = Join-Path $serviceDir $packageDir
  if (!(Test-Path -Path $packageDir)) {
    New-Item -Path $packageDir -ItemType Directory | Out-Null
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
  Write-Host "updated tsp-location.yaml commit to $CommitHash"
  $tspLocationYaml["repo"] = $repo
  Write-Host "updated tsp-location.yaml repo to $repo"
  $tspLocationYaml["directory"] = $TypeSpecProjectDirectory
  Write-Host "updated tsp-location.yaml directory to $TypeSpecProjectDirectory"
  $tspLocationYaml["additionalDirectories"] = $additionalDirs
  Write-Host "updated tsp-location.yaml additionalDirectories to $additionalDirs"
  $tspLocationYaml |ConvertTo-Yaml | Out-File $tspLocationYamlPath
  Write-Host "finished updating tsp-location.yaml in $packageDir"
  return $packageDir
}

function Get-ServiceDir([System.Object]$tspConfig, [string]$repoRoot) {
  $serviceDir = ""
  if ($tspConfig["parameters"] -and $tspConfig["parameters"]["service-dir"]) {
    $serviceDir = $tspConfig["parameters"]["service-dir"]["default"];
  }
  else {
    Write-Error "Missing service-dir in parameters section of tspconfig.yaml. Please refer to https://github.com/Azure/azure-rest-api-specs/blob/main/specification/contosowidgetmanager/Contoso.WidgetManager/tspconfig.yaml for the right schema."
    exit 1
  }

  # Create service-dir if not exist
  $serviceDir = Join-Path $repoRoot $serviceDir
  return $serviceDir
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
    Write-Error "Missing package-dir in $emitterName options of tspconfig.yaml. Please refer to https://github.com/Azure/azure-rest-api-specs/blob/main/specification/contosowidgetmanager/Contoso.WidgetManager/tspconfig.yaml for the right schema."
    exit 1
  }
  return $packageDir
}

function Get-TspLocationFolder([System.Object]$tspConfig, [string]$repoRoot) {
  $serviceDir = Get-ServiceDir $tspConfig $repoRoot
  $packageDir = Get-PackageDir $tspConfig
  $packageDir = Join-Path $serviceDir $packageDir
  return $packageDir
}

$sdkRepoRootPath =  (Join-Path $PSScriptRoot .. .. ..)
$sdkRepoRootPath = Resolve-Path $sdkRepoRootPath
$sdkRepoRootPath = $sdkRepoRootPath -replace "\\", "/"
$tspConfigPath = Join-Path $sdkRepoRootPath 'tspconfig.yaml'
$tmpTspConfigPath = $tspConfigPath
$repo = ""
$specRepoRoot = ""
$generateFromLocalTypeSpec = $false
# remote url scenario
# example url of tspconfig.yaml: https://github.com/Azure/azure-rest-api-specs-pr/blob/724ccc4d7ef7655c0b4d5c5ac4a5513f19bbef35/specification/containerservice/Fleet.Management/tspconfig.yaml
if ($TypeSpecProjectDirectory -match '^https://github.com/(?<repo>Azure/azure-rest-api-specs(-pr)?)/blob/(?<commit>[0-9a-f]{40})/(?<path>.*)/tspconfig.yaml$') {
  try {
    $TypeSpecProjectDirectory = $TypeSpecProjectDirectory -replace "https://github.com/(.*)/(tree|blob)", "https://raw.githubusercontent.com/`$1"
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
  # local path scenario
  $tspConfigPath = Join-Path $TypeSpecProjectDirectory "tspconfig.yaml"
  if (!(Test-Path $tspConfigPath)) {
    Write-Error "Failed to find tspconfig.yaml in '$TypeSpecProjectDirectory'"
    exit 1
  }
  $TypeSpecProjectDirectory = $TypeSpecProjectDirectory.Replace("\", "/")
  if ($TypeSpecProjectDirectory -match "(?<repoRoot>^.*)/(?<path>specification/.*)$") {
    $TypeSpecProjectDirectory = $Matches["path"]
    $specRepoRoot = $Matches["repoRoot"]
  } else {
    Write-Error "$TypeSpecProjectDirectory doesn't have 'specification' in path."
    exit 1
  }
  if (!$CommitHash -or !$RepoUrl) {
    Write-Warning "Parameter of Commithash or RepoUrl are not provided along with the local path of tspconfig.yaml, trying to re-generate sdk code based on the local type specs."
    $generateFromLocalTypeSpec = $true
  }
  
  if ($RepoUrl) {
    if ($RepoUrl -match "^https://github.com/(?<repo>[^/]*/azure-rest-api-specs(-pr)?).*") {
      $repo = $Matches["repo"]
    }
    else {
      Write-Error "Parameter 'RepoUrl' has incorrect value:$RepoUrl. It should be similar like 'https://github.com/Azure/azure-rest-api-specs'"
      exit 1
    }
  }
}

$tspConfigYaml = Get-Content $tspConfigPath -Raw | ConvertFrom-Yaml

# delete the tmporary tspconfig.yaml downloaded from github
if (Test-Path $tmpTspConfigPath) {
  Remove-Item $tspConfigPath
}

$sdkProjectFolder = ""
if ($generateFromLocalTypeSpec) {
  $sdkProjectFolder = Get-TspLocationFolder $tspConfigYaml $sdkRepoRootPath
  $tspLocationYamlPath = Join-Path $sdkProjectFolder "tsp-location.yaml"
  if (!(Test-Path -Path $tspLocationYamlPath)) {
    Write-Error "Failed to find tsp-location.yaml in '$sdkProjectFolder', please make sure to provide CommitHash and RepoUrl parameters along with the local path of tspconfig.yaml in order to create tsp-location.yaml."
    exit 1
  }
} else {
  # call CreateUpdate-TspLocation function
  $sdkProjectFolder = CreateUpdate-TspLocation $tspConfigYaml $TypeSpecProjectDirectory $CommitHash $repo $sdkRepoRootPath  
}

# call TypeSpec-Project-Sync.ps1
$syncScript = Join-Path $PSScriptRoot TypeSpec-Project-Sync.ps1
& $syncScript $sdkProjectFolder $specRepoRoot
if ($LASTEXITCODE) { exit $LASTEXITCODE }

# call TypeSpec-Project-Generate.ps1
$generateScript = Join-Path $PSScriptRoot TypeSpec-Project-Generate.ps1
& $generateScript $sdkProjectFolder
if ($LASTEXITCODE) { exit $LASTEXITCODE }

return $sdkProjectFolder
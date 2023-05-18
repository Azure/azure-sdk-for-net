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
if ($RepoUrl -and !$RepoUrl.StartsWith("https://github.com") -and ($RepoUrl.Split("/").Length -lt 4)) {
  Write-Host "Parameter 'RepoUrl' has incorrect value: $RepoUrl. It should be similar like 'https://github.com/Azure/azure-rest-api-specs'"
  exit
}

function CreateUpdate-TspLocation() {
  $serviceDir = ""
  $additionalDirs = @()

  # Parse tspcofig.yaml to get service-dir, additionalDirectories, and package-dir
  if ($tspConfigYaml["parameters"] -and $tspConfigYaml["parameters"]["service-dir"]) {
    $serviceDir = $tspConfigYaml["parameters"]["service-dir"]["default"];
  }
  else {
    Write-Host "Missing service-dir in parameters section of tspconfig.yaml."
    exit
  }
  if ($tspConfigYaml["dependencies"] -and $tspConfigYaml["dependencies"]["additionalDirectories"]) {
    $additionalDirs = $tspConfigYaml["dependencies"]["additionalDirectories"];
  }

  $packageDir = Get-PackageDir

  $repoRootPath =  (Join-Path $PSScriptRoot .. ..)
  $repoRootPath = Resolve-Path $repoRootPath
  $repoRootPath = $repoRootPath -replace "\\", "/"

  # Create service-dir if not exist
  $serviceDir = Join-Path $repoRootPath "sdk" $serviceDir
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
    $tspLocationYaml = Get-Content -Path $tspLocationYaml -Raw | ConvertFrom-Yaml
  }

  # Update tsp-location.yaml
  $tspLocationYaml["commit"] = $CommitHash
  $repo = ($RepoUrl -split "/")[3..4] -join "/"
  $tspLocationYaml["repo"] = $repo
  $tspLocationYaml["directory"] = $TypeSpecProjectDirectory
  $tspLocationYaml["additionalDirectories"] = $additionalDirs
  $tspLocationYaml |ConvertTo-Yaml | Out-File $tspLocationYamlPath
}

function Get-PackageDir() {
  if (Test-Path "Function:$GetEmitterNameFn") {
    $emitterName = &$GetEmitterNameFn
  }
  $packageDir = ""
  if ($tspConfigYaml["$emitterName"] -and $tspConfigYaml["$emitterName"]["package-dir"]) {
    $packageDir = $tspConfigYaml["$emitterName"]["package-dir"];
  }
  else {
    Write-Host "Missing package-dir in $emitterName options of tspconfig.yaml."
    exit
  }
  return $packageDir
}

$tspConfigContent = ""
# example url of tspconfig.yaml: https://github.com/Azure/azure-rest-api-specs-pr/blob/724ccc4d7ef7655c0b4d5c5ac4a5513f19bbef35/specification/containerservice/Fleet.Management/tspconfig.yaml
if ($TypeSpecProjectDirectory -match '^https://github.com/.*/tspconfig.yaml$') {
  try {
    Invoke-WebRequest $TypeSpecProjectDirectory -OutFile $tspConfigContent -MaximumRetryCount 3
  }
  catch {
    Write-Host "Failed to download '$TypeSpecProjectDirectory'"
    Write-Error $_.Exception.Message
    return
  }
  $RepoUrl = $TypeSpecProjectDirectory
  $regex = "(?<=specification/).*?(?=/tspconfig.yaml)"
  $TypeSpecProjectDirectory = [regex]::Match($TypeSpecProjectDirectory, $regex).Value
  # TODO get the commit hash from the url
} else {
  $TspConfigPath = Join-Path $TypeSpecProjectDirectory "tspconfig.yaml"
  if (!(Test-Path $TspConfigPath)) {
    Write-Host "Failed to find tspconfig.yaml in '$TypeSpecProjectDirectory'"
    return
  }
  $tspConfigContent = Get-Content $TspConfigPath -Raw
}
$tspConfigYaml = ConvertFrom-Yaml $tspConfigContent
# call CreateUpdate-TspLocation function
CreateUpdate-TspLocation

# TODO call TypeSpec-Project-Sync.ps1
# TODO call TypeSpec-Project-Generate.ps1
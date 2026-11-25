[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)][string] $PackageInfoFolder,
  [Parameter(Mandatory = $true)][ValidateSet('core', 'service')][string] $Scope,
  [Parameter()][string] $DefaultMatrixConfigs = '[]'
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '../..')).Path
$filterCache = @{}

function Test-DirectFallbackAllowed($info, $serviceDirectory) {
  $ciPattern = '^/?sdk/' + [regex]::Escape($serviceDirectory) + '/ci[^/]*\.yml$'
  $ciPath = @($info.ArtifactDetails.triggeringPaths | Where-Object { $_ -match $ciPattern } | Select-Object -Last 1)
  if ($ciPath.Count -eq 0) { return $true }
  $relativePath = $ciPath[0].TrimStart('/')
  if (-not $filterCache.ContainsKey($relativePath)) {
    . (Join-Path $repoRoot 'eng/common/scripts/Helpers/PSModule-Helpers.ps1')
    Install-ModuleIfNotInstalled 'powershell-yaml' '0.4.1' | Import-Module
    $yaml = Get-Content (Join-Path $repoRoot $relativePath) -Raw | ConvertFrom-Yaml
    $filterCache[$relativePath] = @($yaml.extends.parameters.MatrixFilters | Where-Object { $_ })
  }
  $values = @{
    AdditionalTestArguments = '/p:UseProjectReferenceToAzureClients=true'
    TestTargetFramework = 'net8.0'
    BuildConfiguration = 'Debug'
    Pool = [string]$env:LINUXPOOL
    OSVmImage = [string]$env:LINUXVMIMAGE
  }
  foreach ($filter in $filterCache[$relativePath]) {
    if ($filter -notmatch '^(.+?)=(.+)$') { throw "Invalid matrix filter '$filter' in '$relativePath'." }
    $key, $pattern = $Matches[1], $Matches[2]
    if ([string]$values[$key] -notmatch $pattern) { return $false }
  }
  return $true
}

$packages = @(Get-ChildItem -Path $PackageInfoFolder -Filter '*.json' -File -Recurse | ForEach-Object {
  $info = Get-Content $_.FullName -Raw | ConvertFrom-Json -AsHashtable
  $path = [string]$info.DirectoryPath -replace '\\', '/'
  $service = if ($path -match '^(?:\./)?sdk/([^/]+)/.+') { $Matches[1] }
  [PSCustomObject]@{ File = $_; Info = $info; Service = $service; IsService = ($service -and $service -ne 'core') }
})

foreach ($package in $packages) {
  if (($Scope -eq 'service') -ne $package.IsService) {
    Remove-Item $package.File.FullName -Force
    continue
  }

  if ($Scope -eq 'service') {
    if (-not $package.Info.CIParameters) { $package.Info.CIParameters = @{} }
    $configs = @($package.Info.CIParameters.CIMatrixConfigs | Where-Object { $_ })
    if ($configs.Count -eq 0) {
      $configs = @(ConvertFrom-Json -InputObject $DefaultMatrixConfigs -AsHashtable)
      if ($configs.Count -eq 0) { throw 'Default matrix configurations are required for service packages.' }
    }
    $defaultPath = 'eng/pipelines/templates/stages/platform-matrix.json'
    $fallbackPath = 'eng/pipelines/templates/stages/pr-service-projectref-matrix.json'
    $needsFallback = $package.Info.IncludedForValidation -eq $true -or (
      @($configs | Where-Object { $_.Path -eq $defaultPath }).Count -gt 0 -and
      (Test-DirectFallbackAllowed $package.Info $package.Service)
    )
    if ($needsFallback -and -not ($configs | Where-Object { $_.Path -eq $fallbackPath })) {
      $configs += @{
        Name = 'NET_ci_service_projectref'
        Path = $fallbackPath
        Selection = 'sparse'
        GenerateVMJobs = $true
      }
      $package.Info.CIParameters.CIMatrixConfigs = $configs
      $package.Info | ConvertTo-Json -Depth 100 | Set-Content $package.File.FullName
    }
  }
}

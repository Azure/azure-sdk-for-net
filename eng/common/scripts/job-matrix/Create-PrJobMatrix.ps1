<#
.SYNOPSIS
Generates a combined PR job matrix from a package properties folder. It is effectively a combination of
Create-JobMatrix and distribute-packages-to-matrix.

.DESCRIPTION
Create-JobMatrix has a limitation in that it accepts one or multiple matrix files, but it doesn't allow runtime
selection of the matrix file based on what is being built. Due to this, this script exists to provide exactly
that mapping.

It should be called from a PR build only.

It generates the matrix by the following algorithm:
  - load all package properties files
  - group the package properties by their targeted CI Matrix Configs
    - for each package group, generate the matrix for each matrix config in the group (remember MatrixConfigs is a list not a single object)
      - for each matrix config, generate the matrix
        - calculate if batching is necessary for this matrix config
        - for each batch
          - create combined property name for the batch
          - walk each matrix item
            - add suffixes for batch and matrix config if nececessary to the job name
            - add the combined property name to the parameters of the matrix item
            - add the matrix item to the overall result

.PARAMETER IndirectFilters
Any array of strings representing filters that will only be applied to the matrix generation for indirect packages. This is useful for
filtering out OTHER parameter settings othan than PRMatrixSetting that are only relevant to direct packages.

For .NET, this value will be AdditionalTestArguments=/p:UseProjectReferenceToAzureClients=true

.EXAMPLE
./eng/common/scripts/job-matrix/Create-PrJobMatrix.ps1 `
  -PackagePropertiesFolder "path/to/populated/PackageInfo" `
  -PrMatrixSetting "<Name of variable to set in the matrix>"
#>

[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)][string] $PackagePropertiesFolder,
  [Parameter(Mandatory = $true)][string] $PRMatrixFile,
  [Parameter(Mandatory = $true)][string] $PRMatrixSetting,
  [Parameter(Mandatory = $False)][string] $DisplayNameFilter,
  [Parameter(Mandatory = $False)][array] $Filters,
  [Parameter(Mandatory = $False)][array] $IndirectFilters,
  [Parameter(Mandatory = $False)][array] $Replace,
  [Parameter(Mandatory = $False)][bool] $SparseIndirect = $true,
  [Parameter(Mandatory = $False)][int] $PackagesPerPRJob = 10,
  [Parameter()][switch] $CI = ($null -ne $env:SYSTEM_TEAMPROJECTID)
)

Set-StrictMode -Version 4
. $PSScriptRoot/job-matrix-functions.ps1

if (!(Test-Path $PackagePropertiesFolder)) {
  Write-Error "Package Properties folder doesn't exist"
  exit 1
}

if (!(Test-Path $PRMatrixFile)) {
  Write-Error "PR Matrix file doesn't exist"
  exit 1
}

Write-Host "Generating PR job matrix for $PackagePropertiesFolder"

$configs = Get-Content -Raw $PRMatrixFile | ConvertFrom-Json

# get all the package property objects loaded
$packageProperties = Get-ChildItem -Recurse "$PackagePropertiesFolder" *.json `
| ForEach-Object { Get-Content -Path $_.FullName | ConvertFrom-Json }

# enhance the package props with a default matrix config if one isn't present
$packageProperties | ForEach-Object {
  if (-not $_.CIMatrixConfigs) {
    $_.CIMatrixConfigs = $configs
  }
}

$directPackages = $packageProperties | Where-Object { $_.IncludedForValidation -eq $false }
$indirectPackages = $packageProperties | Where-Object { $_.IncludedForValidation -eq $true }

$OverallResult = @()
if ($directPackages) {
  Write-Host "Discovered $($directPackages.Length) direct packages"
  foreach($artifact in $directPackages) {
    Write-Host "-> $($artifact.ArtifactName)"
  }
  $OverallResult += GeneratePRMatrixForBatch -Packages $directPackages -BatchSize $BatchSize
}
if ($indirectPackages) {
  Write-Host "Discovered $($indirectPackages.Length) indirect packages"
  foreach($artifact in $indirectPackages) {
    Write-Host "-> $($artifact.ArtifactName)"
  }
  $OverallResult += GeneratePRMatrixForBatch -Packages $indirectPackages -BatchSize $BatchSize -FullSparseMatrix (-not $SparseIndirect)
}
$serialized = SerializePipelineMatrix $OverallResult

Write-Output $serialized.pretty

if ($CI) {
  Write-Output "##vso[task.setVariable variable=matrix;isOutput=true]$($serialized.compressed)"
}

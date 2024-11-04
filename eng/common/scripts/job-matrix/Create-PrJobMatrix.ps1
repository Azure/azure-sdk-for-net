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
  [Parameter(Mandatory = $False)][array] $Replace,
  [Parameter()][switch] $CI = ($null -ne $env:SYSTEM_TEAMPROJECTID)
)

. $PSScriptRoot/job-matrix-functions.ps1
. $PSScriptRoot/../Helpers/Package-Helpers.ps1
$BATCHSIZE = 10

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

# calculate general targeting information and create our batches prior to generating any matrix
$packageProperties = Get-ChildItem -Recurse "$PackagePropertiesFolder" *.json `
| ForEach-Object { Get-Content -Path $_.FullName | ConvertFrom-Json }

# set default matrix config for each package if there isn't an override
$packageProperties | ForEach-Object {
  if (-not $_.CIMatrixConfigs) {
    $_.CIMatrixConfigs = $configs
  }
}

# The key here is that after we group the packages by the matrix config objects, we can use the first item's MatrixConfig
# to generate the matrix for the group, no reason to have to parse the key value backwards to get the matrix config.
$matrixBatchesByConfig = Group-ByObjectKey $packageProperties "CIMatrixConfigs"

$OverallResult = @()
foreach ($matrixBatchKey in $matrixBatchesByConfig.Keys) {
  $matrixBatch = $matrixBatchesByConfig[$matrixBatchKey]
  $matrixConfigs = $matrixBatch | Select-Object -First 1 -ExpandProperty CIMatrixConfigs

  $matrixResults = @()
  foreach ($matrixConfig in $matrixConfigs) {
    Write-Host "Generating config for $($matrixConfig.Path)"
    $matrixResults = GenerateMatrixForConfig `
      -ConfigPath $matrixConfig.Path `
      -Selection $matrixConfig.Selection `
      -DisplayNameFilter $DisplayNameFilter `
      -Filters $Filters `
      -Replace $Replace

    $packageBatches = Split-ArrayIntoBatches -InputArray $matrixBatch -BatchSize $BATCHSIZE

    # we only need to modify the generated job name if there is more than one matrix config or batch in the matrix
    $matrixSuffixNecessary = $matrixConfigs.Count -gt 1
    $batchSuffixNecessary = $packageBatches.Length -gt 1
    $batchCounter = 1

    foreach ($batch in $packageBatches) {
      # to understand this iteration, one must understand that the matrix is a list of hashtables, each with a couple keys:
      # [
      #  { "name": "jobname", "parameters": { matrixSetting1: matrixValue1, ...} },
      # ]
      foreach ($matrixOutputItem in $matrixResults) {
        $namesForBatch = ($batch | ForEach-Object { $_.ArtifactName }) -join ","
        # we just need to iterate across them, grab the parameters hashtable, and add the new key
        # if there is more than one batch, we will need to add a suffix including the batch name to the job name
        $matrixOutputItem["parameters"]["$PRMatrixSetting"] = $namesForBatch

        if ($matrixSuffixNecessary) {
          $matrixOutputItem["name"] = $matrixOutputItem["name"] + $matrixConfig.Name
        }

        if ($batchSuffixNecessary) {
          $matrixOutputItem["name"] = $matrixOutputItem["name"] + "b$batchCounter"
        }

        $OverallResult += $matrixOutputItem
      }
      $batchCounter += 1
    }
  }
}

$serialized = SerializePipelineMatrix $OverallResult

Write-Output $serialized.pretty

if ($CI) {
  Write-Output "##vso[task.setVariable variable=matrix;isOutput=true]$($serialized.compressed)"
}

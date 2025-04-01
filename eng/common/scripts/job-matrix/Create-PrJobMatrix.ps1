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
  [Parameter(Mandatory = $false)][string] $DisplayNameFilter,
  [Parameter(Mandatory = $false)][array] $Filters,
  [Parameter(Mandatory = $false)][array] $IndirectFilters,
  [Parameter(Mandatory = $false)][array] $Replace,
  [Parameter(Mandatory = $false)][string] $PRMatrixKey = "ArtifactName",
  [Parameter(Mandatory = $false)][bool] $SparseIndirect = $true,
  [Parameter(Mandatory = $false)][int] $PackagesPerPRJob = 10,
  [Parameter()][switch] $CI = ($null -ne $env:SYSTEM_TEAMPROJECTID)
)

Set-StrictMode -Version 4
. $PSScriptRoot/job-matrix-functions.ps1
. $PSScriptRoot/../Helpers/Package-Helpers.ps1
. $PSScriptRoot/../Package-Properties.ps1
$BATCHSIZE = $PackagesPerPRJob

# this function takes an array of objects, takes a copy of the first item, and moves that item to the back of the array
function QueuePop([ref]$queue) {

  if ($queue.Value.Length -eq 1) {
    return ($queue.Value[0] | ConvertTo-Json -Depth 100 | ConvertFrom-Json -AsHashtable)
  }

  # otherwise we can rotate stuff
  $first = $queue.Value[0]
  $rest = $queue.Value[1..($queue.Value.Length - 1)]

  $queue.Value = $rest + $first

  return ($first | ConvertTo-Json -Depth 100 | ConvertFrom-Json -AsHashtable)
}

function GeneratePRMatrixForBatch {
  param (
    [Parameter(Mandatory = $true)][array] $Packages,
    [Parameter(Mandatory = $true)][array] $MatrixKey,
    [Parameter(Mandatory = $false)][bool] $FullSparseMatrix = $false
  )

  $OverallResult = @()
  if (!$Packages) {
    Write-Host "Unable to generate matrix for empty package list"
    return ,$OverallResult
  }

  # this check assumes that we have properly separated the direct and indirect package lists
  $directBatch = $Packages[0].IncludedForValidation -eq $false
  Write-Host "Generating matrix for $($directBatch ? 'direct' : 'indirect') packages"

  $batchNamePrefix = $($directBatch ? 'b' : 'ib')

  # The key here is that after we group the packages by the matrix config objects, we can use the first item's MatrixConfig
  # to generate the matrix for the group, no reason to have to parse the key value backwards to get the matrix config.
  $matrixBatchesByConfig = Group-ByObjectKey $Packages "CIMatrixConfigs"

  foreach ($matrixBatchKey in $matrixBatchesByConfig.Keys) {
    # recall that while we have grouped the package info by the matrix config object, each package still has knowledge about
    # every other matrix that it belongs to.
    # so we actually need to get a valid matrix config object from the first package in the batch, but we need to be certain
    # that the matrix config object we get is the SAME ONE that we are iterating through
    $matrixBatch = $matrixBatchesByConfig[$matrixBatchKey]
    $allPossibleMatrixConfigsForFirstPackage = $matrixBatch | Select-Object -First 1 -ExpandProperty CIMatrixConfigs
    $matrixConfig = $allPossibleMatrixConfigsForFirstPackage | Where-Object { (Get-ObjectKey $_) -eq $matrixBatchKey }
    $matrixResults = @()

    if (!$matrixConfig) {
      Write-Error "Unable to find matrix config for $matrixBatchKey. Check the package properties for the package $($matrixBatch[0].($MatrixKey))."
      exit 1
    }

    Write-Host "Generating config for $($matrixConfig.Path)"
    $nonSparse = $matrixConfig.PSObject.Properties['NonSparseParameters'] ? $matrixConfig.NonSparseParameters : @()

    if ($directBatch) {
      $matrixResults = GenerateMatrixForConfig `
        -ConfigPath $matrixConfig.Path `
        -Selection $matrixConfig.Selection `
        -DisplayNameFilter $DisplayNameFilter `
        -Filters $Filters `
        -Replace $Replace `
        -NonSparseParameters $nonSparse

      if ($matrixResults) {
        Write-Host "We have the following direct matrix results: "
        Write-Host ($matrixResults | Out-String)
      }
    }
    else {
      $matrixResults = GenerateMatrixForConfig `
        -ConfigPath $matrixConfig.Path `
        -Selection $matrixConfig.Selection `
        -DisplayNameFilter $DisplayNameFilter `
        -Filters ($Filters + $IndirectFilters) `
        -Replace $Replace `
        -NonSparseParameters $nonSparse

      if ($matrixResults) {
        Write-Host "We have the following indirect matrix results: "
        Write-Host ($matrixResults | Out-String)
      }
      else {
        Write-Host "No indirect matrix results found for $($matrixConfig.Path)"
        continue
      }
    }

    if ($matrixConfig.PSObject.Properties['PRBatching'] -and $matrixResults) {
      # if we are doing a PR Batch, we need to just add the matrix items directly to the OverallResult
      # as the users have explicitly disabled PR batching for this matrix.
      if (!$matrixConfig.PRBatching) {
        Write-Host "The matrix config $($matrixConfig.Path) with name $($matrixConfig.Name) has PRBatch set to false, the matrix members will be directly added without batching by $PRMatrixSetting."
        $OverallResult += $matrixResults
        continue
      }
    }

    $packageBatches = Split-ArrayIntoBatches -InputArray $matrixBatch -BatchSize $BATCHSIZE

    # we only need to modify the generated job name if there is more than one matrix config + batch
    $matrixSuffixNecessary = $matrixBatchesByConfig.Keys.Count -gt 1

    # if we are doing direct packages (or a full indirect matrix), we need to walk the batches and duplicate the matrix config for each batch, fully assigning
    # the each batch's packages to the matrix config. This will generate a _non-sparse_ matrix for the incoming packages
    if ($directBatch -or $FullSparseMatrix) {
      $batchSuffixNecessary = $packageBatches.Length -gt $($directBatch ? 1 : 0)
      $batchCounter = 1

      foreach ($batch in $packageBatches) {
        $namesForBatch = ($batch | ForEach-Object { $_.($MatrixKey) }) -join ","

        foreach ($matrixOutputItem in $matrixResults) {
          # we need to clone this, as each item is an object with possible children
          $outputItem = $matrixOutputItem | ConvertTo-Json -Depth 100 | ConvertFrom-Json -AsHashtable
          # we just need to iterate across them, grab the parameters hashtable, and add the new key
          # if there is more than one batch, we will need to add a suffix including the batch name to the job name
          $outputItem["parameters"]["$PRMatrixSetting"] = $namesForBatch

          if ($matrixSuffixNecessary) {
            $outputItem["name"] = $outputItem["name"] + "_" + $matrixConfig.Name
          }

          if ($batchSuffixNecessary) {
            $outputItem["name"] = $outputItem["name"] + "_$batchNamePrefix$batchCounter"
          }

          $OverallResult += $outputItem
        }
        $batchCounter += 1
      }
    }
    # in the case of indirect packages, instead of walking the batches and duplicating their matrix config entirely,
    # we instead will walk each each matrix, create a parameter named for the PRMatrixSetting, and add the targeted packages
    # as an array. This will generate a _sparse_ matrix for for whatever the incoming packages are
    else {
      $batchSuffixNecessary = $packageBatches.Length -gt 0
      $batchCounter = 1
      foreach ($batch in $packageBatches) {
        $namesForBatch = ($batch | ForEach-Object { $_.($MatrixKey) }) -join ","
        $outputItem = QueuePop -queue ([ref]$matrixResults)

        $outputItem["parameters"]["$PRMatrixSetting"] = $namesForBatch

        if ($matrixSuffixNecessary) {
          $outputItem["name"] = $outputItem["name"] + "_" + $matrixConfig.Name
        }

        if ($batchSuffixNecessary) {
          $outputItem["name"] = $outputItem["name"] + "_$batchNamePrefix$batchCounter"
        }
        # now we need to take an item from the front of the matrix results, clone it, and add it to the back of the matrix results
        # we will add the cloned version to OverallResult
        $OverallResult += $outputItem
        $batchCounter += 1
      }
    }
  }

  return ,$OverallResult
}

if (!(Test-Path $PackagePropertiesFolder)) {
  Write-Error "Package Properties folder doesn't exist"
  exit 1
}

if (!(Test-Path $PRMatrixFile)) {
  Write-Error "PR Matrix file doesn't exist"
  exit 1
}

Write-Host "Generating PR job matrix for $PackagePropertiesFolder using accesskey $PRMatrixKey to determine artifact batches."

$configs = Get-Content -Raw $PRMatrixFile | ConvertFrom-Json

# get all the package property objects loaded
$packageProperties = Get-ChildItem -Recurse "$PackagePropertiesFolder" *.json `
| ForEach-Object { Get-Content -Path $_.FullName | ConvertFrom-Json }
| ForEach-Object { Add-Member -InputObject $_ -MemberType NoteProperty -Name CIMatrixConfigs -Value $_.CIParameters.CIMatrixConfigs -PassThru }

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
    Write-Host "-> $($artifact.($PRMatrixKey))"
  }
  $OverallResult += (GeneratePRMatrixForBatch -Packages $directPackages -MatrixKey $PRMatrixKey) ?? @()
}
if ($indirectPackages) {
  Write-Host "Discovered $($indirectPackages.Length) indirect packages"
  foreach($artifact in $indirectPackages) {
    Write-Host "-> $($artifact.($PRMatrixKey))"
  }
  $OverallResult += (GeneratePRMatrixForBatch -Packages $indirectPackages -MatrixKey $PRMatrixKey -FullSparseMatrix (-not $SparseIndirect)) ?? @()
}
$serialized = SerializePipelineMatrix $OverallResult

Write-Output $serialized.pretty

if ($CI) {
  Write-Output "##vso[task.setVariable variable=matrix;isOutput=true]$($serialized.compressed)"
}

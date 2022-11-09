param(
    [string]$matrixFilePath,
    [string]$Selection,
    [Parameter(Mandatory=$False)][string]$DisplayNameFilter,
    [Parameter(Mandatory=$False)][array]$Filters,
    [Parameter(Mandatory=$False)][array]$Replace,
    [Parameter(Mandatory=$False)][array]$NonSparseParameters
)

$ErrorActionPreference = 'Stop'

function GenerateScenarioMatrix(
    [Parameter(Mandatory=$True)][string]$matrixFilePath,
    [Parameter(Mandatory=$True)][string]$Selection,
    [Parameter(Mandatory=$False)][string]$DisplayNameFilter,
    [Parameter(Mandatory=$False)][array]$Filters,
    [Parameter(Mandatory=$False)][array]$Replace,
    [Parameter(Mandatory=$False)][array]$NonSparseParameters
) {
    $yamlConfig = Get-Content $matrixFilePath -Raw

    $prettyMatrix = &"$PSScriptRoot/../job-matrix/Create-JobMatrix.ps1" `
        -ConfigPath $matrixFilePath `
        -Selection $Selection `
        -DisplayNameFilter $DisplayNameFilter `
        -Filters $Filters `
        -Replace $Replace `
        -NonSparseParameters $NonSparseParameters `
        -CI:$False

    Write-Host "=================================================="
    Write-Host "Generated matrix for $matrixFilePath"
    Write-Host $prettyMatrix
    Write-Host "=================================================="
    $matrixObj = $prettyMatrix | ConvertFrom-Json

    $scenariosMatrix = @()
    foreach($permutation in $matrixObj.psobject.properties) {
        $entry = @{}
        $entry.Name = $permutation.Name -replace '_', '-'
        $entry.Scenario = $entry.Name
        $entry.Remove("Name")
        foreach ($param in $permutation.value.psobject.properties) {
            $entry.add($param.Name, $param.value)
        }
        $scenariosMatrix += $entry
    }

    $valuesConfig = Join-Path (Split-Path $matrixFilePath) 'values.yaml'
    $values = [ordered]@{}
    if (Test-Path $valuesConfig) {
        $valuesYaml = Get-Content -Raw $valuesConfig
        $values = $valuesYaml | ConvertFrom-Yaml -Ordered
        if (!$values) {$values = @{}}

        if ($values.Contains('Scenarios')) {
            throw "Please remove the 'Scenarios' key from $valuesConfig as it is deprecated."
        }
    }

    $values.scenarios = $scenariosMatrix
    $generatedValues = Join-Path (Split-Path $matrixFilePath) 'generatedValues.yaml'
    $values | ConvertTo-Yaml | Out-File -FilePath $generatedValues
}

function NewStressTestPackageInfo(
    [hashtable]$chart,
    [System.IO.FileInfo]$chartFile,
    [switch]$CI,
    [object]$namespaceOverride
) {
    $namespace = if ($namespaceOverride) {
        $namespaceOverride
    } elseif ($CI) {
        $chart.annotations.namespace
    } else {
        GetUsername
    }

    return [StressTestPackageInfo]@{
        Namespace = $namespace.ToLower()
        Directory = $chartFile.DirectoryName
        ReleaseName = $chart.name
        Dockerfile = $chart.annotations.dockerfile
        DockerBuildDir = $chart.annotations.dockerbuilddir
    }
}

# Don't call functions when the script is being dot sourced
if ($MyInvocation.InvocationName -ne ".") {
    GenerateScenarioMatrix `
        -matrixFilePath $matrixFilePath `
        -Selection $Selection `
        -DisplayNameFilter $DisplayNameFilter `
        -Filters $Filters `
        -Replace $Replace `
        -NonSparseParameters $NonSparseParameters
}

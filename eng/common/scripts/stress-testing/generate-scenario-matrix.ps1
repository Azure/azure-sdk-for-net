param(
    [string]$matrixFilePath,
    [string]$Selection,
    [Parameter(Mandatory=$False)][string]$DisplayNameFilter,
    [Parameter(Mandatory=$False)][array]$Filters,
    [Parameter(Mandatory=$False)][array]$Replace,
    [Parameter(Mandatory=$False)][array]$NonSparseParameters
)

function GenerateScenarioMatrix(
    [string]$matrixFilePath,
    [string]$Selection,
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
        -NonSparseParameters $NonSparseParameters
    Write-Host $prettyMatrix
    $prettyMatrix = $prettyMatrix | ConvertFrom-Json

    $scenariosMatrix = @()
    foreach($permutation in $prettyMatrix.psobject.properties) {
        $entry = @{}
        $entry.Name = $permutation.Name -replace '_', '-'
        $entry.Scenario = $entry.Name
        $entry.Remove("Name")
        foreach ($param in $permutation.value.psobject.properties) {
            $entry.add($param.Name, $param.value)
        }
        $scenariosMatrix += $entry
    }

    $valuesYaml = Get-Content -Raw (Join-Path (Split-Path $matrixFilePath) 'values.yaml')
    $values = $valuesYaml | ConvertFrom-Yaml -Ordered
    if (!$values) {$values = @{}}

    if ($values.ContainsKey('Scenarios')) {
        throw "Please use matrix generation for stress test scenarios."
    }

    $values.scenarios = $scenariosMatrix
    $values | ConvertTo-Yaml | Out-File -FilePath (Join-Path $matrixFilePath '../generatedValues.yaml')
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

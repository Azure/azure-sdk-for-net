param(
    [string]$searchDirectory = '.',
    [hashtable]$filters = @{}
)

class StressTestPackageInfo {
    [string]$Namespace
    [string]$Directory
    [string]$ReleaseName
    [string]$Dockerfile
    [string]$DockerBuildDir
    [string]$Deployer
}

. $PSScriptRoot/../job-matrix/job-matrix-functions.ps1

function FindStressPackages(
    [string]$directory,
    [hashtable]$filters = @{},
    [switch]$CI,
    [string]$namespaceOverride,
    [string]$MatrixSelection,
    [Parameter(Mandatory=$False)][string]$MatrixDisplayNameFilter,
    [Parameter(Mandatory=$False)][array]$MatrixFilters,
    [Parameter(Mandatory=$False)][array]$MatrixReplace,
    [Parameter(Mandatory=$False)][array]$MatrixNonSparseParameters
) {
    # Bare minimum filter for stress tests
    $filters['stressTest'] = 'true'

    $packages = @()
    $chartFiles = Get-ChildItem -Recurse -Filter 'Chart.yaml' $directory 
    foreach ($chartFile in $chartFiles) {
        $chart = ParseChart $chartFile
        if (matchesAnnotations $chart $filters) {
            $matrixFilePath = (Join-Path $chartFile.Directory.FullName '/matrix.yaml')
            if (Test-Path $matrixFilePath) {
                ScenariosMatrixGeneration `
                    -matrixFilePath $matrixFilePath `
                    -Selection $MatrixSelection `
                    -DisplayNameFilter $MatrixDisplayNameFilter `
                    -Filters $MatrixFilters `
                    -Replace $MatrixReplace `
                    -NonSparseParameters $MatrixNonSparseParameters
            }

            $packages += NewStressTestPackageInfo `
                            -chart $chart `
                            -chartFile $chartFile `
                            -CI:$CI `
                            -namespaceOverride $namespaceOverride
        }
    }

    return $packages
}

function ParseChart([string]$chartFile) {
    return ConvertFrom-Yaml (Get-Content -Raw $chartFile)
}

function MatchesAnnotations([hashtable]$chart, [hashtable]$filters) {
    foreach ($filter in $filters.GetEnumerator()) {
        if (!$chart.annotations -or $chart.annotations[$filter.Key] -ne $filter.Value) {
            return $false
        }
    }

    return $true
}

function GetUsername() {
    # Check GITHUB_USER for users in codespaces environments, since the default user is `codespaces` and
    # we would like to avoid namespace overlaps for different codespaces users.
    $stressUser = $env:GITHUB_USER ?? $env:USER ?? $env:USERNAME
    # Remove spaces, underscores, etc. that may be in $namespace.
    # Value must be a valid RFC 1123 DNS label: https://kubernetes.io/docs/concepts/overview/working-with-objects/names/#dns-label-names
    $stressUser = $stressUser -replace '_|\W', '-'

    return $stressUser.ToLower()
}

function ScenariosMatrixGeneration(
    [string]$matrixFilePath,
    [string]$Selection,
    [Parameter(Mandatory=$False)][string]$DisplayNameFilter,
    [Parameter(Mandatory=$False)][array]$Filters,
    [Parameter(Mandatory=$False)][array]$Replace,
    [Parameter(Mandatory=$False)][array]$NonSparseParameters
) {
    $yamlConfig = Get-Content $matrixFilePath -Raw

    $prettySerializedMatrix = &"$PSScriptRoot/../job-matrix/Create-JobMatrix.ps1" `
        -ConfigPath $matrixFilePath `
        -Selection $Selection `
        -DisplayNameFilter $DisplayNameFilter `
        -Filters $Filters `
        -Replace $Replace `
        -NonSparseParameters $NonSparseParameters

    $prettyMatrix = $prettySerializedMatrix | ConvertFrom-Json -AsHashtable

    $scenariosMatrix = @()
    foreach($permutation in $prettyMatrix.GetEnumerator()) {
        $entry = @{}
        $entry.Name = $permutation.key -replace '_', '-'
        $entry.Scenario = $entry.Name
        $entry.Remove("Name")
        foreach ($param in $permutation.value.GetEnumerator()) {
            $entry.add($param.key, $param.value)
        }
        $scenariosMatrix += $entry
    }

    $valuesYaml = Get-Content (Join-Path $matrixFilePath '../values.yaml') -Raw
    $values = $valuesYaml | ConvertFrom-Yaml
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
    FindStressPackages $searchDirectory $filters
}

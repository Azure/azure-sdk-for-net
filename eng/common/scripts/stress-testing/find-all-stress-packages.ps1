param(
    [string]$searchDirectory = '.',
    [hashtable]$filters = @{}
)

class StressTestPackageInfo {
    [string]$Namespace
    [string]$Directory
    [string]$ReleaseName
}

function FindStressPackages([string]$directory, [hashtable]$filters = @{}) {
    # Bare minimum filter for stress tests
    $filters['stressTest'] = 'true'

    $packages = @()
    $chartFiles = Get-ChildItem -Recurse -Filter 'Chart.yaml' $directory 
    foreach ($chartFile in $chartFiles) {
        $chart = ParseChart $chartFile
        if (matchesAnnotations $chart $filters) {
            $packages += NewStressTestPackageInfo $chart $chartFile
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

function NewStressTestPackageInfo([hashtable]$chart, [System.IO.FileInfo]$chartFile) {
    return [StressTestPackageInfo]@{
        Namespace = $chart.annotations.namespace
        Directory = $chartFile.DirectoryName
        ReleaseName = $chart.name
    }
}

# Don't call functions when the script is being dot sourced
if ($MyInvocation.InvocationName -ne ".") {
    FindStressPackages $searchDirectory $filters
}

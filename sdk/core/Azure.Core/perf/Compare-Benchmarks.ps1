# Compare-Benchmarks.ps1

$overallPassed = $true

function Extract-BaseName($fullName) {
    # Extracts the method name without the Local/Nuget prefix
    $regex = [regex]'\.(Local|Nuget)[_.]?(.+)$'
    $match = $regex.Match($fullName)
    if ($match.Success) {
        return $match.Groups[2].Value
    }
    # get the last part after the last dot
    return ($fullName -split '\.')[-1]
}

function Get-MeanMap($filename) {
    $json = Get-Content $filename -Raw | ConvertFrom-Json
    $means = @{}
    foreach ($b in $json.Benchmarks) {
        $name = $b.FullName
        $base = Extract-BaseName $name
        $mean = $b.Statistics.Mean
        $unit = $b.Statistics.Unit
        if (-not $unit -and $b.Unit) { $unit = $b.Unit } # fallback if unit is at root
        # Normalize to nanoseconds
        switch ($unit) {
            "ns" { $mean_ns = $mean }
            "us" { $mean_ns = $mean * 1000 }
            "ms" { $mean_ns = $mean * 1000 * 1000 }
            default { $mean_ns = $mean } # assume ns if unknown
        }
        $means[$base] = $mean_ns
    }
    return $means
}

$localDir = "BenchmarkDotNet.Artifacts/results/local/results"
$nugetDir = "BenchmarkDotNet.Artifacts/results/nuget/results"

$localFiles = Get-ChildItem -Path $localDir -Filter "Azure.Core.Perf.*.json"
foreach ($localFile in $localFiles) {
    $fileName = $localFile.Name
    $nugetFilePath = Join-Path $nugetDir $fileName
    if (-not (Test-Path $nugetFilePath)) {
        Write-Host "Nuget result file missing for $fileName"
        $overallPassed = $false
        continue
    }

    $localMeans = Get-MeanMap $localFile.FullName
    $nugetMeans = Get-MeanMap $nugetFilePath

    foreach ($base in $localMeans.Keys) {
        if (-not $nugetMeans.ContainsKey($base)) {
            Write-Host "[$fileName] Nuget result missing for '$base'"
            $overallPassed = $false
            continue
        }
        $localMean = $localMeans[$base]
        $nugetMean = $nugetMeans[$base]
        $percentThreshold = 10
        $absoluteThresholdNs = 1000  # 1000 nanoseconds
        $percentDiff = (($localMean - $nugetMean) / $nugetMean) * 100
        $absoluteDiff = [math]::Abs($localMean - $nugetMean)
        if ($percentDiff -gt $percentThreshold -and $absoluteDiff -gt $absoluteThresholdNs) {
            Write-Host "[$fileName] FAIL: [$base]: Local is slower by $([math]::Round($percentDiff,2))% ($([math]::Round($absoluteDiff,2)) ns)"
            $overallPassed = $false
        } else {
            Write-Host "[$fileName] PASS: [$base]: Local is within $percentThreshold% or $absoluteThresholdNs ns of Nuget (diff: $([math]::Round($percentDiff,2))%, $([math]::Round($absoluteDiff,2)) ns)"
        }
    }
}

if (-not $overallPassed) {
    exit 1
}

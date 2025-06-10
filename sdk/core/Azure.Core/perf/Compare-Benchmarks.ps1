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

function Process-File($filename) {
    $json = Get-Content $filename -Raw | ConvertFrom-Json
    $pairs = @{}

    foreach ($b in $json.Benchmarks) {
        $name = $b.FullName
        $mean = $b.Statistics.Mean
        if ($name -like '*Local*') {
            $base = Extract-BaseName $name
            if (-not $pairs.ContainsKey($base)) { $pairs[$base] = @{} }
            $pairs[$base]['local'] = $mean
        } elseif ($name -like '*Nuget*') {
            $base = Extract-BaseName $name
            if (-not $pairs.ContainsKey($base)) { $pairs[$base] = @{} }
            $pairs[$base]['nuget'] = $mean
        }
    }

    $allPassed = $true
    foreach ($base in $pairs.Keys) {
        $localMean = $pairs[$base]['local']
        $nugetMean = $pairs[$base]['nuget']
        if ($null -eq $localMean -or $null -eq $nugetMean) {
            Write-Host "[$filename] Could not find both Local and Nuget for '$base' in results."
            $allPassed = $false
            continue
        }
        $diffSec = ($localMean - $nugetMean) / 1000000000
        if ($diffSec -gt 1.0) {
            Write-Host "[$filename] FAIL: [$base]: Local is slower by $([math]::Round($diffSec,2)) seconds (local: $localMean, nuget: $nugetMean)"
            $allPassed = $false
        } else {
            Write-Host "[$filename] PASS: [$base]: Local is within 1 second of Nuget (diff: $([math]::Round($diffSec,2)) seconds)"
        }
    }
    return $allPassed
}

foreach ($file in Get-ChildItem -Path "BenchmarkDotNet.Artifacts/results" -Filter "Azure.Core.Perf.*.json") {
    if (-not (Process-File $file.FullName)) {
        $overallPassed = $false
    }
}

if (-not $overallPassed) {
    exit 1
}

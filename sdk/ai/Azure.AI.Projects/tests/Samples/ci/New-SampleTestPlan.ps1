# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

[CmdletBinding()]
param(
    [Parameter(Mandatory)] [ValidateSet('sample-path', 'test-id')] [string] $SelectionKind,
    [Parameter(Mandatory)] [ValidateNotNullOrEmpty()] [string] $Selection,
    [ValidateRange(1, 4)] [int] $QueueCount = 4,
    [Parameter(Mandatory)] [string] $OutputDirectory,
    [Parameter(Mandatory)] [string] $Pool,
    [Parameter(Mandatory)] [string] $Image,
    [switch] $NoBuild
)

$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'SampleTestPlanHelpers.ps1')
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '../../../../../..')).Path
$packages = @('Azure.AI.Projects', 'Azure.AI.Projects.Agents', 'Azure.AI.Extensions.OpenAI')
if (Test-Path -LiteralPath $OutputDirectory) { throw 'Sample plan output already exists; refusing to reuse discovery.' }
$null = New-Item -ItemType Directory -Path $OutputDirectory
$items = @($Selection -split ';' | ForEach-Object { $_.Trim() } | Where-Object { $_ })
if ($items.Count -eq 0) { throw 'Sample selection cannot be empty.' }
$tree = $null
$classes = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
if ($SelectionKind -eq 'test-id') {
    $tree = ConvertTo-SampleSelectionTree -Selection ('(' + ($items -join '|') + ')')
} else {
    foreach ($item in $items) {
        $relative = $item.Replace('\', '/')
        if ($relative -notmatch '^(Azure\.AI\.(Projects(?:\.Agents)?|Extensions\.OpenAI))/tests/Samples(?:/|$)' -or
            @($relative.Split('/') | Where-Object { $_ -in @('.', '..') }).Count -gt 0) {
            throw "Sample path must be under a supported package's tests/Samples directory: $item"
        }
        $path = Join-Path (Join-Path $repoRoot 'sdk/ai') $relative
        if (-not (Test-Path -LiteralPath $path)) { throw "Sample path does not exist: $item" }
        $files = if (Test-Path -LiteralPath $path -PathType Container) {
            @(Get-ChildItem -LiteralPath $path -Filter '*.cs' -Recurse -File)
        } else {
            @(Get-Item -LiteralPath $path)
        }
        foreach ($file in $files) {
            if ($file.Extension -ne '.cs') { throw 'Sample selection must identify C# source files or folders.' }
            $source = Get-Content -LiteralPath $file.FullName -Raw
            $namespace = [regex]::Match($source, '(?m)^namespace\s+([\w.]+)\s*[;{]').Groups[1].Value
            foreach ($match in [regex]::Matches($source, '\bpublic\s+(?:partial\s+)?class\s+(\w+)')) {
                $null = $classes.Add("$namespace.$($match.Groups[1].Value)")
            }
        }
    }
    if ($classes.Count -eq 0) { throw 'No sample classes were found in the selected paths.' }
}

$selected = [System.Collections.Generic.List[hashtable]]::new()
Push-Location $repoRoot
try {
    foreach ($package in $packages) {
        $project = Join-Path $repoRoot "sdk/ai/$package/tests/$package.Tests.csproj"
        $dumpDirectory = Join-Path $repoRoot "artifacts/bin/$package.Tests/Debug/net10.0/Dump"
        $dumpPath = Join-Path $dumpDirectory "D_$package.Tests.dll.dump"
        if (Test-Path -LiteralPath $dumpPath) { Remove-Item -LiteralPath $dumpPath }
        $arguments = @('test', $project, '--framework', 'net10.0', '--configuration', 'Debug',
            '--list-tests', '/p:UseProjectReferenceToAzureClients=false')
        if ($NoBuild) { $arguments += @('--no-build', '--no-restore') }
        $arguments += @('--', 'NUnit.DumpXmlTestDiscovery=true')
        $output = @(& dotnet @arguments 2>&1)
        if ($LASTEXITCODE -ne 0) {
            $output | Write-Host
            throw "NUnit discovery failed for $package."
        }
        if (-not (Test-Path -LiteralPath $dumpPath)) { throw "NUnit discovery XML was not produced for $package." }
        Copy-Item -LiteralPath $dumpPath -Destination (Join-Path $OutputDirectory "$package.discovery.xml")
        [xml] $discovery = Get-Content -LiteralPath $dumpPath -Raw
        foreach ($case in $discovery.SelectNodes('//test-case')) {
            if ($case.classname -notlike "$package.Tests.Samples.*" -or
                $case.fullname -notmatch '\(False\)\.' -or $case.runstate -ne 'Runnable' -or
                $case.SelectNodes("ancestor-or-self::*/properties/property[@name='Category' and @value='Manually']").Count -gt 0) { continue }
            $test = @{ package = $package; fullName = [string] $case.fullname; name = [string] $case.name }
            $isSelected = if ($SelectionKind -eq 'test-id') { Test-SampleSelection -Tree $tree -Test $test } else {
                $classes.Contains([string] $case.classname)
            }
            if ($isSelected) { $selected.Add($test) }
        }
    }
} finally {
    Pop-Location
}
if ($selected.Count -eq 0) { throw 'No runnable sync samples matched the selection.' }
$plan = New-SampleQueuePlan -Tests $selected.ToArray() -QueueCount $QueueCount -Pool $Pool -Image $Image
$attempt = if ($env:SYSTEM_JOBATTEMPT) { $env:SYSTEM_JOBATTEMPT } else { '1' }
foreach ($queueName in $plan.queues.Keys) {
    $plan.matrix[$queueName].SamplePlanArtifact = "sample-plan-$attempt"
    $directory = Join-Path $OutputDirectory $queueName
    $null = New-Item -ItemType Directory -Path $directory
    $plan.queues[$queueName] | ConvertTo-Json -Depth 10 |
        Set-Content -LiteralPath (Join-Path $directory 'selected-tests.json') -Encoding utf8
    Write-Host "${queueName}:"
    foreach ($test in $plan.queues[$queueName].selectedTests) { Write-Host "  $($test.fullName)" }
}
$matrixJson = $plan.matrix | ConvertTo-Json -Depth 5 -Compress
$matrixJson | Set-Content -LiteralPath (Join-Path $OutputDirectory 'queue-matrix.json') -Encoding utf8
Write-Host "##vso[task.setvariable variable=WorkerMatrix;isOutput=true]$matrixJson"

param(
    [Parameter(Mandatory = $true)]
    [ValidateSet('net8.0', 'net9.0', 'net10.0')]
    [string] $TestTargetFramework
)

$ErrorActionPreference = 'Stop'
$packageDirectory = Split-Path $PSScriptRoot -Parent
$project = Join-Path $PSScriptRoot 'Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests/Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.csproj'
$settings = Join-Path $packageDirectory 'multi-endpoint-routing-live.runsettings'
$resultsDirectory = Join-Path $env:AGENT_TEMPDIRECTORY "multi-endpoint-routing-$([Guid]::NewGuid().ToString('N'))"
Write-Host "##vso[task.setvariable variable=MultiEndpointResultsDirectory]$resultsDirectory"
$previousMode = $env:AZURE_TEST_MODE

try {
    $env:AZURE_TEST_MODE = 'Live'
    dotnet test $project --framework $TestTargetFramework --configuration Release `
        /p:UseProjectReferenceToAzureClients=true /p:CollectCoverage=false /p:EnableSourceLink=false `
        --filter 'TestCategory!=Manually & (FullyQualifiedName~MultiEndpointRoutingLiveTests)' `
        --settings $settings --logger trx --logger 'console;verbosity=normal' `
        --blame-crash-dump-type full --blame-hang-dump-type full --blame-hang-timeout 30minutes `
        --results-directory $resultsDirectory

    if ($LASTEXITCODE -ne 0) {
        throw "Multi-endpoint routing test command failed with exit code $LASTEXITCODE."
    }

    $results = @(
        foreach ($file in Get-ChildItem $resultsDirectory -Filter '*.trx' -Recurse) {
            [xml]$run = Get-Content $file.FullName -Raw
            $testIds = @($run.TestRun.TestDefinitions.UnitTest | Where-Object {
                $_.TestMethod.className -eq 'Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.MultiEndpointRoutingLiveTests(False)' -and
                $_.TestMethod.name -eq 'RoutesTracesAndLogsAcrossResourcesAndEndpoints'
            } | ForEach-Object { $_.id })
            $run.TestRun.Results.UnitTestResult | Where-Object { $_.testId -in $testIds }
        }
    )
    if ($results.Count -ne 1 -or $results[0].outcome -ne 'Passed') {
        throw "Expected one passed multi-endpoint routing test; found $($results.Count) result(s) with outcomes: $($results.outcome -join ', ')."
    }
    Write-Host 'Multi-endpoint routing test executed and passed.'
}
finally {
    $env:AZURE_TEST_MODE = $previousMode
}
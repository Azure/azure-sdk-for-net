<#
    .SYNOPSIS
        Downloads recording results from CI pipelines for a particular GitHub Pull Request. Use the Start-DevOpsRecordings.ps1 do start the recording.
        Waits for all active runs to finish.
        
    .PARAMETER PR
        The GitHub pull request id. For example 14153

    .PARAMETER NoWait
        Do not wait for all runs to finish, only downloads completed runs.

    .EXAMPLE
    .\eng\scripts\Download-DevOpsRecordings.ps1 14153
#>
[CmdletBinding()]
param ([Parameter(Mandatory=$True)][int] $PR, [switch] $NoWait = $false)

$repoRoot = Resolve-Path "$PSScriptRoot/../..";
$artifactsPath = Join-Path $repoRoot "artifacts"
$commonParameter = @("--organization", "https://dev.azure.com/azure-sdk", "--project", "internal", "-o", "json", "--only-show-errors")

$token = (az account get-access-token --resource=https://management.core.windows.net/ -o json | ConvertFrom-Json).accessToken

Write-Host "Processing builds for PR $PR"

if ($NoWait)
{
    $builds = az pipelines runs list @commonParameter --tags Recording --branch "refs/pull/$PR/merge" --status completed --query-order FinishTimeDesc  | ConvertFrom-Json;
}
else
{
    do
    {
        $allCompleted = $true;
        $builds = az pipelines runs list @commonParameter --tags Recording --branch "refs/pull/$PR/merge" --query-order FinishTimeDesc | ConvertFrom-Json;

        foreach ($build in $builds)
        {
            if ($build.status -ne "completed")
            {
                Write-Host "Waiting for '$($build.definition.name)' ($($build.status)) to finish - https://dev.azure.com/azure-sdk/internal/_build/results?buildId=$($build.id)"
                $allCompleted = $false;
            }
        }

        if (!$allCompleted)
        {
            Write-Host "Retrying after 30 seconds"
            Start-Sleep -s 30
        }
    }
    while(!$allCompleted -or $NoWait)
}

$ProcessedDefinitions = @();

foreach ($build in $builds)
{
    $definitionName = $build.definition.name;
    if ($ProcessedDefinitions -contains $definitionName)
    {
        continue;
    }
    $ProcessedDefinitions += $definitionName;

    Write-Host "Processing results from $definitionName"
    $artifacts = az pipelines runs artifact list @commonParameter --run-id $build.id | ConvertFrom-Json;

    foreach ($artifact in $artifacts)
    {
        $downloadUrl = $artifact.resource.downloadUrl
        if ($artifact.name -eq "SessionRecords")
        {
            $destination = Join-Path $artifactsPath "$definitionName.zip"

            Write-Host "Downloading artifact $downloadUrl to '$destination'"
            Invoke-WebRequest -Uri $downloadUrl -OutFile $destination -Headers @{Authorization="Bearer $token"}
            Expand-Archive -Path $destination -DestinationPath $artifactsPath -Force
        }
    }
}

$sessionRecordsPaths = Join-Path $artifactsPath "SessionRecords" "sdk"
Copy-Item -Path $sessionRecordsPaths -Filter "*.json" -Recurse -Destination $repoRoot -Container -Force
[CmdletBinding()]
param ([Parameter(Mandatory=$True)][int] $PR, [switch] $NoWait = $false)

$repoRoot = Resolve-Path "$PSScriptRoot/../..";
$artifactsPath = Join-Path $repoRoot "artifacts"

$token = (az account get-access-token --resource=https://management.core.windows.net/ -o json | ConvertFrom-Json).accessToken

Write-Host "Processing builds for PR $PR"
$builds = az pipelines runs list --organization https://dev.azure.com/azure-sdk --tags Recording --project internal --branch "refs/pull/$PR/merge" --query-order FinishTimeDesc -o json --only-show-errors | ConvertFrom-Json;

$allCompleted = $true;
do
{
    $builds = az pipelines runs list --organization https://dev.azure.com/azure-sdk --tags Recording --project internal --branch "refs/pull/$PR/merge" --query-order FinishTimeDesc -o json --only-show-errors | ConvertFrom-Json;

    foreach ($build in $builds)
    {
        if ($build.status -ne "completed")
        {
            Write-Host "Waiting for '$($build.definition.name)' to finish - https://dev.azure.com/azure-sdk/internal/_build/results?buildId=$($build.id)"
            $allCompleted = $false;
        }
    }

    if (!$allCompleted)
    {
        Write-Host "Retrying after 10 seconds"
        Start-Sleep -s 10
    }
}
while(!$allCompleted -or $NoWait)

$PRocessedDefinitions = @();

foreach ($build in $builds)
{
    $definitionName = $build.definition.name;
    if ($PRocessedDefinitions -contains $definitionName)
    {
        continue;
    }
    $PRocessedDefinitions += $definitionName;

    Write-Host "Processing results from $definitionName"
    $artifacts = az pipelines runs artifact list --organization https://dev.azure.com/azure-sdk --project internal --run-id $build.id -o json --only-show-errors | ConvertFrom-Json;

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

$sessionRecordsPaths = Join-Path $artifactsPath "SessionRecords"
Copy-Item -Path $sessionRecordsPaths -Filter "*.json" -Recurse -Destination $repoRoot -Container
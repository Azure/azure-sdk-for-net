param ($pr, $sdks)

$repoRoot = Resolve-Path "$PSScriptRoot/../..";
$artifactsPath = Join-Path $repoRoot "artifacts"

$token = (az account get-access-token --resource=https://management.core.windows.net/ -o json | ConvertFrom-Json).accessToken

Write-Host "Processing builds for PR $pr"
$builds = az pipelines runs list --organization https://dev.azure.com/azure-sdk --project internal --branch "refs/pull/$pr/merge" --query-order FinishTimeDesc --status completed -o json 2> $null | ConvertFrom-Json;
$processedDefinitions = @();

foreach ($build in $builds)
{
    $definitionName = $build.definition.name;
    if ($processedDefinitions -contains $definitionName)
    {
        continue;
    }
    $processedDefinitions += $definitionName;

    Write-Host "Processing results from $definitionName"
    $artifacts = az pipelines runs artifact list --organization https://dev.azure.com/azure-sdk --project internal --run-id $build.id -o json 2> $null | ConvertFrom-Json;

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
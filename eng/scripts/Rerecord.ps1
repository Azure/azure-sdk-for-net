param ($pr, $sdks)

Write-Host "Loading builds for PR $pr"
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
    #az pipelines runs artifact download --organization https://dev.azure.com/azure-sdk --project internal --run-id 493407 --artifact-name SessionRecords --path .
}
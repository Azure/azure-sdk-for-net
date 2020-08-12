[CmdletBinding()]
param ([Parameter(Mandatory=$True)][int] $PR, [Parameter(Mandatory=$True, ValueFromRemainingArguments=$true)][string[]]$SDKs)

$builds = az pipelines runs list --organization https://dev.azure.com/azure-sdk --tags Recording --project internal --branch "refs/pull/$PR/merge" --query-order FinishTimeDesc -o json --only-show-errors | ConvertFrom-Json;

$cancelPatchFile = New-TemporaryFile;
"{`"status`": `"Cancelling`"}" > $cancelPatchFile;

foreach ($build in $builds)
{
    if ($build.status -ne "completed")
    {
        Write-Host "Cancelling '$($build.definition.name)' - https://dev.azure.com/azure-sdk/internal/_build/results?buildId=$($build.id)"
        az devops invoke --organization https://dev.azure.com/azure-sdk --area build --resource builds --route-parameters "buildId=$($build.id)" project=internal --in-file $cancelPatchFile --http-method patch -o json > $null;
        $allCompleted = $false;
    }
}

foreach ($sdk in $SDKs)
{
    $pipeline = "net - $sdk - tests";
    Write-Host "Starting pipeline '$pipeline' for PR $PR"
    $build = az pipelines run --name $pipeline --organization https://dev.azure.com/azure-sdk --project internal --branch "refs/pull/$PR/merge" --variables Record=true -o json --only-show-errors | ConvertFrom-Json;
    az pipelines runs tag add  --organization https://dev.azure.com/azure-sdk --project internal --run-id $build.id --tags Recording --only-show-errors > $null;
    Write-Host "Started https://dev.azure.com/azure-sdk/internal/_build/results?buildId=$($build.id)"
}
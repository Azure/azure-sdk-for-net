<#
    .SYNOPSIS
        Starts CI pipelines in recording mode for a particular PR and a set of services. Use the Download-DevOpsRecordings.ps1 do download the results.
        
    .PARAMETER PR
        The GitHub pull request id. For example 14153
    .PARAMETER SDKs
        A set of directories under sdk to rerecord. For example iot, tables, storage
    .PARAMETER NoCancel
        When set doesn't cancel existing recording runs.

    .EXAMPLE
    .\eng\scripts\Start-DevOpsRecordings.ps1 14153 iot tables
#>
[CmdletBinding()]
param (
    [Parameter(Mandatory=$True)][int] $PR,
    [Parameter(Mandatory=$True, ValueFromRemainingArguments=$true)][string[]]$SDKs,
    [switch] $NoCancel = $false)


$invokeParameter = @("--organization", "https://dev.azure.com/azure-sdk", "-o", "json", "--only-show-errors")
$commonParameters =  $invokeParameter + @( "--project", "internal")

if (!$NoCancel)
{
    $builds = az pipelines runs list @commonParameters --tags Recording --branch "refs/pull/$PR/merge" --query-order FinishTimeDesc | ConvertFrom-Json;

    $cancelPatchFile = New-TemporaryFile;
    "{`"status`": `"Cancelling`"}" > $cancelPatchFile;

    foreach ($build in $builds)
    {
        if ($build.status -ne "completed")
        {
            Write-Warning "Cancelling existing recording run '$($build.definition.name)' before we start recordings - https://dev.azure.com/azure-sdk/internal/_build/results?buildId=$($build.id)"
            az devops invoke @invokeParameter --area build --resource builds --route-parameters "buildId=$($build.id)" project=internal --in-file $cancelPatchFile --http-method patch > $null;
        }
    }
}

foreach ($sdk in $SDKs)
{
    $pipeline = "net - $sdk - tests";
    Write-Host "Starting pipeline '$pipeline' for PR $PR"
    $build = az pipelines run --name $pipeline @commonParameters --branch "refs/pull/$PR/merge" --variables Record=true | ConvertFrom-Json;
    az pipelines runs tag add @commonParameters --run-id $build.id --tags Recording > $null;
    Write-Host "Started https://dev.azure.com/azure-sdk/internal/_build/results?buildId=$($build.id)"
}
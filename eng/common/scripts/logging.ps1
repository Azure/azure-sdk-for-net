function Test-SupportsDevOpsLogging()
{
    return ($null -ne $env:SYSTEM_TEAMPROJECTID)
}

function LogWarning
{
    if (Test-SupportsDevOpsLogging)
    {
        Write-Host "##vso[task.LogIssue type=warning;]$args"
    }
    else
    {
        Write-Warning "$args"
    }
}

function LogError
{
    if (Test-SupportsDevOpsLogging)
    {
        Write-Host "##vso[task.LogIssue type=error;]$args"
    }
    else
    {
        Write-Error "$args"
    }
}

function LogDebug
{
    if (Test-SupportsDevOpsLogging)
    {
        Write-Host "[debug]$args"
    }
    else
    {
        Write-Debug "$args"
    }
}

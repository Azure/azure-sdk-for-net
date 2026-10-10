#Requires -Version 7.6
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string]$PackagePath,
    [Parameter(Mandatory = $true)][string]$SdkRepoPath,
    [Parameter(Mandatory = $true)][string]$OutputJsonFile
)

# Isolate only the external registry response; the production entrypoint, restores and comparisons remain real.
function Invoke-RestMethod {
    [CmdletBinding()]
    param([string]$Uri, [string]$Method, [int]$TimeoutSec, [int]$MaximumRetryCount, [int]$RetryIntervalSec)

    if ($Uri -ne 'https://azuresearch-usnc.nuget.org/search/query?q=packageid%3ASdkChange.LargeFixture&skip=0&take=1000&sortBy=created-asc&semVerLevel=2.0.0&ignoreFilter=true') {
        throw "Unexpected registry request in the large-source fixture: $Uri"
    }
    return [pscustomobject]@{
        totalHits = 1
        data = @([pscustomobject]@{
            PackageRegistration = [pscustomobject]@{ Id = 'SdkChange.LargeFixture' }
            Version = '1.0.0'
            Listed = $true
        })
    }
}

& (Join-Path $SdkRepoPath 'eng' 'scripts' 'compatibility' 'Get-SdkChanges.ps1') @PSBoundParameters

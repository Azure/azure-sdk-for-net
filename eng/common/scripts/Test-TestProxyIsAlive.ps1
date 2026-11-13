<#
.SYNOPSIS
Tests if the Test Proxy is alive and responding to requests.

.DESCRIPTION
Tests if the Test Proxy is alive and responding to requests by sending a request to the /Admin/IsAlive endpoint.
If the Test Proxy is not responding, the script will retry up to 10 times with a 6 second delay between attempts.

.PARAMETER ProxyUrl
The URL of the Test Proxy to test. Passed from DevOps as a string.
#>
[CmdletBinding()]
Param(
    [Parameter(Mandatory = $True)]
    [string] $ProxyUrl
)

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'

for ($i = 0; $i -lt 10; $i++) {
    try {
        Write-Host "Invoke-WebRequest -Uri `"$ProxyUrl/Admin/IsAlive`" | Out-Null"
        Invoke-WebRequest -Uri "$ProxyUrl/Admin/IsAlive" | Out-Null
        Write-Host "Successfully connected to the test proxy at '$ProxyUrl'."
        exit 0
    }
    catch {
        Write-Warning "Failed to successfully connect to test proxy. Retrying..."
        Start-Sleep 6
    }
}
Write-Error "Could not connect to test proxy."
exit 1

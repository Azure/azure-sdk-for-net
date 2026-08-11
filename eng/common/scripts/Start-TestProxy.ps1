<#
.SYNOPSIS
Starts Test Proxy.

.DESCRIPTION
Starts Test Proxy, which is a tool used to record and playback HTTP requests for testing purposes.

.PARAMETER RootFolder
The root folder where the Test Proxy will store its recordings. Passed from DevOps as a string.

.PARAMETER ProxyUrl
The URL of the Test Proxy to start. Passed from DevOps as a string.

.PARAMETER BinariesDirectory
The directory where the Test Proxy binaries were installed. Passed from DevOps as a string.
#>
Param(
    [Parameter(Mandatory = $True)]
    [string] $RootFolder,
    [Parameter(Mandatory = $True)]
    [string] $ProxyUrl,
    [Parameter(Mandatory = $True)]
    [string] $BinariesDirectory
)

$invocation = @"
Start-Process $BinariesDirectory/test-proxy/test-proxy.exe
    -ArgumentList `"start -u --storage-location $RootFolder -- --urls $ProxyUrl`"
    -NoNewWindow -PassThru -RedirectStandardOutput $RootFolder/test-proxy.log
    -RedirectStandardError $RootFolder/test-proxy-error.log
"@
Write-Host $invocation

$Process = Start-Process $BinariesDirectory/test-proxy/test-proxy.exe `
    -ArgumentList "start -u --storage-location $RootFolder -- --urls $ProxyUrl" `
    -NoNewWindow -PassThru -RedirectStandardOutput $RootFolder/test-proxy.log `
    -RedirectStandardError $RootFolder/test-proxy-error.log

Write-Host "Setting PROXY_PID to $($Process.Id)"
Write-Host "##vso[task.setvariable variable=PROXY_PID]$($Process.Id)"

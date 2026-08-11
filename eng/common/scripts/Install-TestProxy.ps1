<#
.SYNOPSIS
Installs Test Proxy.

.DESCRIPTION
Installs Test Proxy, which is a tool used to record and playback HTTP requests for testing purposes.

.PARAMETER TemplateRoot
The root directory where the Test Proxy templates are located. Passed from DevOps as a string.

.PARAMETER BinariesDirectory
The directory where the Test Proxy binaries will be installed. Passed from DevOps as a string.

.PARAMETER RunProxy
Whether to run the Test Proxy after installation. Passed from DevOps as a boolean.
#>
Param(
    [Parameter(Mandatory = $True)]
    [string] $TemplateRoot,
    [Parameter(Mandatory = $True)]
    [string] $BinariesDirectory,
    [Parameter(Mandatory = $False)]
    [bool] $RunProxy = $true
)

$standardVersion = "$TemplateRoot/eng/common/testproxy/target_version.txt"
$overrideVersion = "$TemplateRoot/eng/target_proxy_version.txt"

$version = $(Get-Content $standardVersion -Raw).Trim()

if (Test-Path $overrideVersion) {
    $version = $(Get-Content $overrideVersion -Raw).Trim()
}

Write-Host "Installing test-proxy version $version"

$invocation = @"
dotnet tool install azure.sdk.tools.testproxy `
    --tool-path $BinariesDirectory/test-proxy `
    --add-source https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json `
    --version $version
"@
Write-Host $invocation

dotnet tool install azure.sdk.tools.testproxy `
    --tool-path $BinariesDirectory/test-proxy `
    --add-source https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json `
    --version $version

Write-Host "Prepending path with the test proxy tool install location: '$BinariesDirectory/test-proxy'"
Write-Host "##vso[task.prependpath]$BinariesDirectory/test-proxy"

if ($runProxy) {
    Write-Host "Configuring Kestrel and PROXY_MANUAL_START environment variables for Test Proxy"

    Write-Host "Setting ASPNETCORE_Kestrel__Certificates__Default__Path to '$TemplateRoot/eng/common/testproxy/dotnet-devcert.pfx'"
    Write-Host "##vso[task.setvariable variable=ASPNETCORE_Kestrel__Certificates__Default__Path]$TemplateRoot/eng/common/testproxy/dotnet-devcert.pfx"
    Write-Host "Setting ASPNETCORE_Kestrel__Certificates__Default__Password to 'password'"
    Write-Host "##vso[task.setvariable variable=ASPNETCORE_Kestrel__Certificates__Default__Password]password"
    Write-Host "Setting PROXY_MANUAL_START to 'true'"
    Write-Host "##vso[task.setvariable variable=PROXY_MANUAL_START]true"
}

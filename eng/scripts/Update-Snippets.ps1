[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory,

    [Parameter()]
    [switch] $StrictMode
)

$root = "$PSScriptRoot/../../sdk"

# special casing * here because single invocation of SnippetGenerator is much faster than
# running it per service directory
if ($ServiceDirectory -and ($ServiceDirectory -ne "*")) {
    $root += '/' + $ServiceDirectory
}

if (-not (Test-Path env:TF_BUILD)) { $StrictMode = $true }

dotnet tool install --global `
 --add-source "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json" `
 --version 1.0.0-dev.20210730.3 `
 Azure.Sdk.Tools.SnippetGenerator


try
{
    if($StrictMode) {
        Resolve-Path "$root" | %{ snippet-generator -b "$_" -sm}
    } else {
        Resolve-Path "$root" | %{ snippet-generator -b "$_" }
    }
}
catch
{
    Write-Error "snippet-generator run failed."
    exit 1
}
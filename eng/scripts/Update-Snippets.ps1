[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory,

    [Parameter()]
    [switch] $StrictMode,

    [Parameter()]
    [string] $SnippetToolPath=''
)

$root = "$PSScriptRoot/../../sdk"

# special casing * here because single invocation of SnippetGenerator is much faster than
# running it per service directory
if ($ServiceDirectory -and ($ServiceDirectory -ne "*")) {
    $root += '/' + $ServiceDirectory
}

if (-not (Test-Path Env:TF_BUILD)) 
{
    $StrictMode = $true

    dotnet tool install --global `
    --add-source "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json" `
    --version "1.0.0-dev.20211119.1" `
    "Azure.Sdk.Tools.SnippetGenerator"
}
else
{
    if ($Env:AGENT_OS -match "Windows.*")
    {
        $SnippetToolPath = "%USERPROFILE%\.dotnet\tools\"
    }
    else
    {
        $SnippetToolPath = "$HOME/.dotnet/tools/"
    }
}

if($StrictMode) {
    Resolve-Path "$root" | %{ & "${SnippetToolPath}snippet-generator" -b "$_" -sm}
} else {
    Resolve-Path "$root" | %{ & "${SnippetToolPath}snippet-generator" -b "$_" }
}
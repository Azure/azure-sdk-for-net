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

nuget install SnippetGenerator -Source azure-sdk-tools@DevOps -PreRelease -OutputDirectory .
$generatorAssembly = Resolve-Path -Path ".\SnippetGenerator*\tools\**\SnippetGenerator.dll"

if (Test-Path $generatorAssembly)
{
    if($StrictMode) {
        Resolve-Path "$root" | %{ dotnet $generatorAssembly -b "$_" -sm}
    } else {
        Resolve-Path "$root" | %{ dotnet $generatorAssembly -b "$_" }
    }
    git clean ".\SnippetGenerator*" -xfd
}
else
{
    Write-Error "Could not find assembly at ${generatorAssembly}"
    exit 1
}

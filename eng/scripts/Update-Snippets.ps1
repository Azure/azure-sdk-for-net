[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory,

    [Parameter()]
    [switch] $StrictMode
)

$generatorProject = "$PSScriptRoot/../SnippetGenerator/SnippetGenerator.csproj";
$root = "$PSScriptRoot/../../sdk"

# special casing * here because single invocation of SnippetGenerator is much faster than
# running it per service directory
if ($ServiceDirectory -and ($ServiceDirectory -ne "*")) {
    $root += '/' + $ServiceDirectory
}

if (-not (Test-Path env:TF_BUILD)) { $StrictMode = $true }

if($StrictMode) {
    Resolve-Path "$root" | %{ dotnet run -p $generatorProject -b "$_" -sm -c Release }
} else {
    Resolve-Path "$root" | %{ dotnet run -p $generatorProject -b "$_" -c Release }
}

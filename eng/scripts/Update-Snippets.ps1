[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory
)

$generatorProject = "$PSScriptRoot/../SnippetGenerator/SnippetGenerator.csproj";
$root = "$PSScriptRoot/../../sdk"

# special casing * here because single invocation of SnippetGenerator is much faster than
# running it per service directory
if ($ServiceDirectory -and ($ServiceDirectory -ne "*")) {
    $root += '/' + $ServiceDirectory
}

Resolve-Path "$root" | %{ dotnet run -p $generatorProject -b "$_" }

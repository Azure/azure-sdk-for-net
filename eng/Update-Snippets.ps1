[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory
)

$generatorProject = "$PSScriptRoot/SnippetGenerator/SnippetGenerator.csproj";
$root = "$PSScriptRoot/../sdk"
if ($ServiceDirectory) {
    $root += '/' + $ServiceDirectory
}

$repoRoot = Resolve-Path "$root"

dotnet run -p $generatorProject -b "$repoRoot"

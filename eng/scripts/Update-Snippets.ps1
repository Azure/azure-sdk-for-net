[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory,

    [Parameter()]
    [switch] $StrictMode = !(Test-Path Env:TF_BUILD)
)

$root = "$PSScriptRoot/../../sdk"

# special casing * here because single invocation of SnippetGenerator is much faster than
# running it per service directory
if ($ServiceDirectory -and ($ServiceDirectory -ne '*')) {
    $root += '/' + $ServiceDirectory
}

[string[]] $additionalArgs = @()
if ($StrictMode) {
    $additionalArgs += '-sm'
}

dotnet tool restore
Resolve-Path $root | ForEach-Object {
    dotnet tool run snippet-generator -b "$_" $additionalArgs
}

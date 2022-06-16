[CmdletBinding()]
param (
    [Parameter()]
    [string] $ServiceDirectory,
    [Parameter()]
    [string] $AutorestPath
)

$sdkRootPath = Resolve-Path "$PSScriptRoot/../../sdk/$ServiceDirectory"

$currentPath = Get-Location
$files = Get-ChildItem -Path $sdkRootPath -Recurse -Filter autorest.md | %{$_.FullName}
foreach ($file in $files) {
    if ($file.Contains("Azure.ResourceManager")) {
        $workPath = Split-Path -Path $file -Parent
        Set-Location -Path $workPath
        
        if ([string]::IsNullOrWhitespace($AutorestPath)) { 
            dotnet build /t:GenerateCode
        }
        else {
            autorest .\autorest.md --use:$AutorestPath
        }
    }
}
Set-Location -Path $currentPath

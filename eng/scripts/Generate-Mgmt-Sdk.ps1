[CmdletBinding()]
param (
    [Parameter()]
    [string] $ServiceDirectory,
    [Parameter()]
    [string] $AutorestPath
)

$ErrorActionPreference = "Stop"
try {
    $sdkRootPath = Resolve-Path "$PSScriptRoot/../../sdk/$ServiceDirectory"
} catch {
    Write-Error -Message "Invalid '$ServiceDirectory' service."
}


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

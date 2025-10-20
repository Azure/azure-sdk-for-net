[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory,
    [string] $SDKType = "all",
    [switch] $SpellCheckPublicApiSurface
)

if ($SpellCheckPublicApiSurface -and -not (Get-Command 'npx')) {
    Write-Error "Could not locate npx. Install NodeJS (includes npm and npx) https://nodejs.org/en/download/"
    exit 1
}

$servicesProj = Resolve-Path "$PSScriptRoot/../service.proj"

$debugLogging = $env:SYSTEM_DEBUG -eq "true"
$logsFolder = $env:BUILD_ARTIFACTSTAGINGDIRECTORY
$diagnosticArguments =  "/binarylogger:$logsFolder/exportapi.binlog"

dotnet build /t:ExportApi /p:RunApiCompat=false /p:InheritDocEnabled=false /p:GeneratePackageOnBuild=false /p:Configuration=Release /p:IncludeSamples=false /p:IncludePerf=false /p:IncludeStress=false /p:IncludeTests=false /p:Scope="$ServiceDirectory" /p:SDKType=$SDKType /restore $servicesProj $diagnosticArguments

# Normalize line endings to LF in generated API listing files
Write-Host "Normalizing line endings in API listing files"
$apiListingFiles = Get-ChildItem -Path "$PSScriptRoot/../../sdk/$ServiceDirectory/*/api/*.cs" -ErrorAction SilentlyContinue
foreach ($file in $apiListingFiles) {
    $content = Get-Content -Path $file.FullName -Raw
    if ($content) {
        # Replace CRLF with LF
        $content = $content -replace "`r`n", "`n"
        # Replace any remaining CR with LF
        $content = $content -replace "`r", "`n"
        # Write back without adding extra newline
        Set-Content -Path $file.FullName -Value $content -NoNewline
    }
}

if ($SpellCheckPublicApiSurface) {
    Write-Host "Spell check public API surface"
    &"$PSScriptRoot/../common/spelling/Invoke-Cspell.ps1" `
        -CSpellConfigPath "$PSScriptRoot/../../.vscode/cspell.json" `
        -ScanGlobs "sdk/$ServiceDirectory/*/api/*.cs"

    if ($LASTEXITCODE) {
        Write-Host "##vso[task.LogIssue type=error;]Spelling errors detected. To correct false positives or learn about spell checking see: https://aka.ms/azsdk/engsys/spellcheck"
    }
}

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

dotnet build /t:ExportApi /p:RunApiCompat=false /p:InheritDocEnabled=false /p:GeneratePackageOnBuild=false /p:Configuration=Release /p:IncludeSamples=false /p:IncludePerf=false /p:IncludeStress=false /p:IncludeTests=false /p:Scope="$ServiceDirectory" /p:SDKType=$SDKType /restore $servicesProj

if ($SpellCheckPublicApiSurface) { 
    Write-Host "Spell check public API surface"
    npx cspell lint `
        --config "$PSScriptRoot/../../.vscode/cspell.json" `
        "$PSScriptRoot/../../sdk/$ServiceDirectory/*/api/*.cs"
    if ($LASTEXITCODE) { 
        Write-Host "##vso[task.LogIssue type=error;]Spelling errors detected. To correct false positives or learn about spell checking see: https://aka.ms/azsdk/engsys/spellcheck"
    }
}

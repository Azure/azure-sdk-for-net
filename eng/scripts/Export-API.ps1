[CmdletBinding()]
param (
    [Parameter(Position=0)]

    [Parameter(Mandatory=$true, ParameterSetName='ServiceDirectory')]
    [string] $ServiceDirectory,

    [string] $SDKType = "all",
    [switch] $SpellCheckPublicApiSurface,

    [Parameter(Mandatory=$true, ParameterSetName='PackagePath')]
    [string] $PackagePath,
    [Parameter(Mandatory=$true, ParameterSetName='PackagePath')]
    [string] $SdkRepoPath
)

if ($SpellCheckPublicApiSurface -and -not (Get-Command 'npx')) {
    Write-Error "Could not locate npx. Install NodeJS (includes npm and npx) https://nodejs.org/en/download/"
    exit 1
}
$relativePackagePath = $ServiceDirectory
$apiListingFilesFilter = "$PSScriptRoot/../../sdk/$ServiceDirectory/*/api/*.cs"

if ($PSCmdlet.ParameterSetName -eq 'PackagePath') {
    $relativePackagePath = Resolve-Path -Relative -RelativeBasePath (Join-Path $SdkRepoPath "sdk") -Path $PackagePath
    $apiListingFilesFilter = "$PSScriptRoot/../../sdk/$relativePackagePath/api/*.cs"
}

$servicesProj = Resolve-Path "$PSScriptRoot/../service.proj"

$debugLogging = $env:SYSTEM_DEBUG -eq "true"
$logsFolder = $env:BUILD_ARTIFACTSTAGINGDIRECTORY
$diagnosticArguments = ($debugLogging -and $logsFolder) ? "/binarylogger:$logsFolder/exportapi.binlog" : ""

dotnet build `
    /t:ExportApi `
    /p:RunApiCompat=false `
    /p:InheritDocEnabled=false `
    /p:GeneratePackageOnBuild=false `
    /p:Configuration=Release `
    /p:IncludeSamples=false `
    /p:IncludePerf=false `
    /p:IncludeStress=false `
    /p:IncludeTests=false `
    /p:Scope="$relativePackagePath" `
    /p:SDKType=$SDKType `
    /restore `
    $servicesProj `
    $diagnosticArguments

if ($LASTEXITCODE) {
    Write-Host "##vso[task.LogIssue type=error;]API export failed. See the build logs for details."
    exit $LASTEXITCODE
}

# Normalize line endings to LF in generated API listing files
Write-Host "Normalizing line endings in API listing files"
$apiListingFiles = Get-ChildItem -Path $apiListingFilesFilter
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

    if ($PSCmdlet.ParameterSetName -eq 'PackagePath') {
        &"$PSScriptRoot/spell-check-public-api.ps1" `
            -RelativePackagePath $relativePackagePath
    } else {
        &"$PSScriptRoot/spell-check-public-api.ps1" `
            -ServiceDirectory $relativePackagePath
    }

    if ($LASTEXITCODE) {
        Write-Host "##vso[task.LogIssue type=error;]Spelling errors detected. To correct false positives or learn about spell checking see: https://aka.ms/azsdk/engsys/spellcheck"
    }
}

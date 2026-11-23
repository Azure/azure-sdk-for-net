#Requires -Version 7.0
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [string] $RepoRoot,
    [Parameter(Mandatory)] [string] $SourceVersion,
    [Parameter(Mandatory)] [string] $PreviousVersion,
    [switch] $ForceUpdate
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$path = 'eng/azure-typespec-http-client-csharp-emitter-package.json'

function Get-Pin([string] $commit) {
    if ($commit -notmatch '^[0-9a-f]{40}$') { throw 'Expected a full git commit ID.' }
    $raw = & git -C $RepoRoot show "${commit}:$path"
    if ($LASTEXITCODE -ne 0) { throw "Could not read the approved emitter descriptor at $commit." }
    $manifest = ($raw -join "`n") | ConvertFrom-Json -AsHashtable
    $version = $manifest.dependencies['@azure-typespec/http-client-csharp']
    if (-not ($version -is [string])) { throw 'The approved branded emitter pin is missing.' }
    try { [void][System.Management.Automation.SemanticVersion]::Parse($version) }
    catch { throw 'The approved branded emitter pin must be an exact version.' }
    return $version
}

$current = Get-Pin $SourceVersion
$previous = Get-Pin $PreviousVersion
Write-Host "Approved branded emitter: $previous -> $current"
Write-Host "##vso[task.setvariable variable=emitterVersion;isOutput=true]$current"
Write-Host "##vso[task.setvariable variable=pinChanged;isOutput=true]$($ForceUpdate -or $current -cne $previous)"

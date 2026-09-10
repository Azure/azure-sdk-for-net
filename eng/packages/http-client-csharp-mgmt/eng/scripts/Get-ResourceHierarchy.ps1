#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Analyzes an Azure SDK management-plane library DLL and outputs the resource
    hierarchy as JSON.

.DESCRIPTION
    Thin PowerShell wrapper around the .NET 10 ResourceHierarchyTool. The actual
    reflection runs in a child `dotnet` process (.NET 10 host) so it can load
    *any* current Azure.ResourceManager version regardless of the PowerShell
    host's runtime. This is what allows callers — in particular
    Get-PreviousGaResourceHierarchy.ps1 — to point the tool at DLLs whose
    transitive dependencies (e.g. System.Text.Json v10) the host runtime
    cannot satisfy.

    Diagnostic messages are written to stderr; the JSON result to stdout.

    Azure.ResourceManager + Azure.Core (and their transitive closure) ship
    next to the reflection tool, so the typical caller just passes a
    DLL path and gets a result back. The DLL's own directory is also
    probed automatically. Use -ProbeDir / -ProbeFile only as an escape
    hatch when an input DLL references a less common dependency that
    isn't already resolvable.

.PARAMETER DllPath
    Path to the Azure.ResourceManager.<RP>.dll to analyze.

.PARAMETER ProbeDir
    Optional list of additional directories to search for dependency
    assemblies. Rarely needed — the tool already ships with Azure.Core
    and Azure.ResourceManager beside it.

.PARAMETER ProbeFile
    Optional list of explicit dependency DLL paths. Takes precedence
    over ProbeDir. Rarely needed for the same reason.

.EXAMPLE
    pwsh Get-ResourceHierarchy.ps1 ./publish/Azure.ResourceManager.Compute.dll > hierarchy.json
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, Position = 0)]
    [string] $DllPath,

    [Parameter()]
    [string[]] $ProbeDir = @(),

    [Parameter()]
    [string[]] $ProbeFile = @()
)

$ErrorActionPreference = 'Stop'

if (-not (Test-Path -LiteralPath $DllPath)) {
    [Console]::Error.WriteLine("Error: File not found: $DllPath")
    exit 1
}
$DllPath = (Resolve-Path -LiteralPath $DllPath).ProviderPath

$thisDir = Split-Path -Parent $PSCommandPath
$toolProj = Join-Path $thisDir 'ResourceHierarchyTool/ResourceHierarchyTool.csproj'
$toolDll  = Join-Path $thisDir 'ResourceHierarchyTool/bin/Release/net10.0/ResourceHierarchyTool.dll'

# Build (or rebuild) the tool when stale. Cheap when up-to-date.
$needsBuild = $true
if (Test-Path -LiteralPath $toolDll) {
    $dllStamp  = (Get-Item -LiteralPath $toolDll).LastWriteTimeUtc
    $sources   = Get-ChildItem -LiteralPath (Split-Path -Parent $toolProj) -Recurse -File `
                    -Include *.cs, *.csproj, *.props, *.targets -ErrorAction SilentlyContinue
    $newest    = ($sources | ForEach-Object { $_.LastWriteTimeUtc } | Sort-Object -Descending | Select-Object -First 1)
    if ($newest -le $dllStamp) { $needsBuild = $false }
}
if ($needsBuild) {
    [Console]::Error.WriteLine("Building ResourceHierarchyTool ...")
    & dotnet build $toolProj -c Release --nologo --verbosity quiet | Out-Null
    if ($LASTEXITCODE -ne 0) { throw "dotnet build of ResourceHierarchyTool failed (exit $LASTEXITCODE)" }
}

$toolArgs = @('exec', $toolDll, '--dll', $DllPath)
foreach ($d in $ProbeDir)  { if ($d) { $toolArgs += @('--probe-dir',  $d) } }
foreach ($f in $ProbeFile) { if ($f) { $toolArgs += @('--probe-file', $f) } }

& dotnet @toolArgs
exit $LASTEXITCODE

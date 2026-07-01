<#
.SYNOPSIS
    Validates that samples under the top-level /samples directory are self-contained.

.DESCRIPTION
    Samples published to the Azure samples browser are downloaded scoped to their own
    directory (samples/<service>/<sample>). A sample that references projects outside of
    its own directory is broken for anyone who downloads it standalone.

    This static analysis flags, for every project under /samples:
      SAMPLE-001: A ProjectReference or Import whose path escapes the sample's own
                  directory (e.g. reaches into sdk/ or another sample).
      SAMPLE-002: A ProjectReference or Import that relies on an MSBuild property
                  ($(...)) to locate a project, which cannot be resolved standalone.

    References that stay within the sample's own directory (for example a tests project
    referencing a sibling src project) are allowed.
#>

[CmdletBinding()]
param (
    [Parameter()]
    [string] $SamplesDirectory
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

$RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot "..\..")).Path.TrimEnd('\', '/')
$SamplesRoot = if ($SamplesDirectory) { (Resolve-Path (Join-Path $RepoRoot $SamplesDirectory)).Path.TrimEnd('\', '/') } else { Join-Path $RepoRoot "samples" }

if (-not (Test-Path $SamplesRoot)) {
    Write-Host "Samples directory not found, nothing to scan: $SamplesRoot"
    exit 0
}

[string[]] $errors = @()

function LogError([string]$message) {
    if ($env:TF_BUILD) {
        Write-Host ("##vso[task.logissue type=error]$message" -replace "`n", "%0D%0A")
    }
    Write-Host -ForegroundColor Red "error: $message"
    $script:errors += $message
}

function LogInfo([string]$message) {
    Write-Host -ForegroundColor Cyan $message
}

function Get-RelativePath([string]$fullPath) {
    return $fullPath.Substring($RepoRoot.Length + 1).Replace('\', '/')
}

# The sample's own directory is samples/<service>/<sample>. A project file deeper than
# that (e.g. samples/<service>/<sample>/src) still belongs to the same sample root.
function Get-SampleRoot([string]$projectFullPath) {
    $relativeToSamples = $projectFullPath.Substring($SamplesRoot.Length).TrimStart('\', '/').Replace('\', '/')
    $segments = $relativeToSamples.Split('/')
    if ($segments.Count -lt 3) {
        # Not inside a samples/<service>/<sample>/ subtree; treat the file's own folder as the root.
        return (Split-Path $projectFullPath -Parent)
    }
    return (Join-Path (Join-Path $SamplesRoot $segments[0]) $segments[1])
}

function Get-ReferencePaths([string]$projectFullPath) {
    try {
        [xml]$xml = Get-Content -Path $projectFullPath -Raw
    }
    catch {
        LogError "SAMPLE-000: Unable to parse project file $(Get-RelativePath $projectFullPath): $($_.Exception.Message)"
        return @()
    }

    $refs = @()
    foreach ($node in $xml.SelectNodes("//*[local-name()='ProjectReference']")) {
        if ($node.Include) { $refs += [pscustomobject]@{ Kind = 'ProjectReference'; Path = $node.Include } }
    }
    foreach ($node in $xml.SelectNodes("//*[local-name()='Import']")) {
        if ($node.Project) { $refs += [pscustomobject]@{ Kind = 'Import'; Path = $node.Project } }
    }
    return $refs
}

$projectFiles = Get-ChildItem -Path $SamplesRoot -Recurse -Include '*.csproj' |
    Where-Object { $_.FullName -notmatch '[\\/](artifacts|node_modules|\.git|bin|obj)[\\/]' }
LogInfo "Found $($projectFiles.Count) sample project(s) to scan under $(Get-RelativePath $SamplesRoot)."

foreach ($project in $projectFiles) {
    $projectDir = Split-Path $project.FullName -Parent
    $sampleRoot = (Get-SampleRoot $project.FullName).TrimEnd('\', '/')
    $sampleRootPrefix = $sampleRoot + [System.IO.Path]::DirectorySeparatorChar

    foreach ($ref in Get-ReferencePaths $project.FullName) {
        $rel = Get-RelativePath $project.FullName

        if ($ref.Path -match '\$\(') {
            LogError "SAMPLE-002: $($ref.Kind) '$($ref.Path)' in $rel relies on an MSBuild property and cannot be resolved when the sample is downloaded standalone."
            continue
        }

        $normalized = $ref.Path.Replace('\', [System.IO.Path]::DirectorySeparatorChar).Replace('/', [System.IO.Path]::DirectorySeparatorChar)
        $resolved = [System.IO.Path]::GetFullPath([System.IO.Path]::Combine($projectDir, $normalized))

        if (-not ($resolved.StartsWith($sampleRootPrefix, [System.StringComparison]::OrdinalIgnoreCase) -or $resolved.Equals($sampleRoot, [System.StringComparison]::OrdinalIgnoreCase))) {
            $sampleRootRel = Get-RelativePath $sampleRoot
            LogError "SAMPLE-001: $($ref.Kind) '$($ref.Path)' in $rel escapes the sample directory '$sampleRootRel'. Samples must be self-contained for the Azure samples browser."
        }
    }
}

Write-Host ""
if ($errors.Count -gt 0) {
    Write-Host -ForegroundColor Red "Sample self-containment check failed with $($errors.Count) error(s):"
    foreach ($err in $errors) {
        Write-Host -ForegroundColor Red "  - $err"
    }
    exit 1
}
else {
    Write-Host -ForegroundColor Green "Sample self-containment check passed. No violations found."
    exit 0
}

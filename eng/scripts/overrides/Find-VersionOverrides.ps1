#requires -version 5

[CmdletBinding()]
param(
    # Root of the repo. Defaults to the repo root relative to this script location.
    [Parameter()]
    [string]$RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot .. .. ..)).Path,

    # Relative paths under RepoRoot to search (e.g. "sdk", "common", "samples").
    [Parameter()]
    [string[]]$SearchPaths = @("sdk"),

    # Optional JSON output path (absolute or relative to RepoRoot).
    [Parameter()]
    [string]$OutputJsonPath,

    # If set, exits with code 1 when findings are present.
    [Parameter()]
    [switch]$FailOnFindings
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

function Get-RelativePath([string]$basePath, [string]$fullPath)
{
    $base = [System.IO.Path]::GetFullPath($basePath).TrimEnd([System.IO.Path]::DirectorySeparatorChar, [System.IO.Path]::AltDirectorySeparatorChar)
    $full = [System.IO.Path]::GetFullPath($fullPath)

    if ($full.StartsWith($base, [System.StringComparison]::OrdinalIgnoreCase))
    {
        $rel = $full.Substring($base.Length).TrimStart([System.IO.Path]::DirectorySeparatorChar, [System.IO.Path]::AltDirectorySeparatorChar)
        return $rel.Replace('\', '/')
    }

    return $full.Replace('\', '/')
}

function Resolve-OutputPath([string]$repoRoot, [string]$path)
{
    if ([string]::IsNullOrWhiteSpace($path))
    {
        return $null
    }

    if ([System.IO.Path]::IsPathRooted($path))
    {
        return $path
    }

    return (Join-Path $repoRoot $path)
}

$outputPathResolved = Resolve-OutputPath -repoRoot $RepoRoot -path $OutputJsonPath

$csprojFiles = New-Object System.Collections.Generic.List[System.IO.FileInfo]

foreach ($searchPath in $SearchPaths)
{
    $rootToSearch = Join-Path $RepoRoot $searchPath
    if (-not (Test-Path $rootToSearch))
    {
        Write-Verbose "Skipping missing search path: $rootToSearch"
        continue
    }

    Get-ChildItem -Path $rootToSearch -Recurse -File -Filter "*.csproj" `
        | Where-Object {
            $p = $_.FullName.Replace('\','/')
            ($p -notmatch '/bin/') -and ($p -notmatch '/obj/')
        } `
        | ForEach-Object { $csprojFiles.Add($_) }
}

$results = New-Object System.Collections.Generic.List[object]
$seen = New-Object 'System.Collections.Generic.HashSet[string]' ([System.StringComparer]::Ordinal)

foreach ($file in $csprojFiles)
{
    try
    {
        $doc = [System.Xml.Linq.XDocument]::Load($file.FullName)
    }
    catch
    {
        throw "Failed to load XML for '$($file.FullName)': $($_.Exception.Message)"
    }

    $packageRefs = $doc.Descendants() | Where-Object { $_.Name.LocalName -eq "PackageReference" }

    foreach ($pr in $packageRefs)
    {
        $voAttr = $pr.Attribute([System.Xml.Linq.XName]::Get("VersionOverride"))
        $voElem = $null
        if ($voAttr -eq $null)
        {
            $voElem = $pr.Elements() | Where-Object { $_.Name.LocalName -eq "VersionOverride" } | Select-Object -First 1
        }

        $versionOverride = $null
        if ($voAttr -ne $null)
        {
            $versionOverride = $voAttr.Value
        }
        elseif ($voElem -ne $null)
        {
            $versionOverride = $voElem.Value
        }

        if ([string]::IsNullOrWhiteSpace($versionOverride))
        {
            continue
        }

        $includeAttr = $pr.Attribute([System.Xml.Linq.XName]::Get("Include"))
        $updateAttr = $pr.Attribute([System.Xml.Linq.XName]::Get("Update"))
        $conditionAttr = $pr.Attribute([System.Xml.Linq.XName]::Get("Condition"))
        if ($conditionAttr -eq $null -and $pr.Parent -ne $null -and $pr.Parent.Name.LocalName -eq "ItemGroup")
        {
            $conditionAttr = $pr.Parent.Attribute([System.Xml.Linq.XName]::Get("Condition"))
        }

        $packageId = $null
        $referenceKind = $null
        if ($includeAttr -ne $null -and -not [string]::IsNullOrWhiteSpace($includeAttr.Value))
        {
            $packageId = $includeAttr.Value
            $referenceKind = "Include"
        }
        elseif ($updateAttr -ne $null -and -not [string]::IsNullOrWhiteSpace($updateAttr.Value))
        {
            $packageId = $updateAttr.Value
            $referenceKind = "Update"
        }
        else
        {
            $packageId = "<unknown>"
            $referenceKind = "<unknown>"
        }

        $projectPath = (Get-RelativePath -basePath $RepoRoot -fullPath $file.FullName)
        $conditionValue = if ($conditionAttr -ne $null -and -not [string]::IsNullOrWhiteSpace($conditionAttr.Value)) { $conditionAttr.Value } else { $null }

        $key = "$projectPath`n$packageId`n$versionOverride`n$referenceKind`n$conditionValue"
        if ($seen.Add($key))
        {
            $results.Add([pscustomobject]@{
                Project         = $projectPath
                PackageId       = $packageId
                VersionOverride = $versionOverride
                ReferenceKind   = $referenceKind
                Condition       = $conditionValue
            })
        }
    }
}

$sorted = $results `
    | Sort-Object Project, PackageId, VersionOverride, ReferenceKind, Condition

Write-Host "Found $($sorted.Count) PackageReference VersionOverride entr$(if ($sorted.Count -eq 1) { 'y' } else { 'ies' })."

if ($sorted.Count -gt 0)
{
    # Keep output stable and CI-friendly.
    $sorted `
        | Format-Table Project, PackageId, VersionOverride, ReferenceKind, Condition -AutoSize `
        | Out-String -Width 260 `
        | Write-Host
}

if ($outputPathResolved)
{
    $outDir = Split-Path -Parent $outputPathResolved
    if ($outDir -and -not (Test-Path $outDir))
    {
        New-Item -ItemType Directory -Force -Path $outDir | Out-Null
    }

    $payload = @(
        foreach ($row in $sorted)
        {
            [pscustomobject]@{
                project         = $row.Project
                packageId       = $row.PackageId
                versionOverride = $row.VersionOverride
                referenceKind   = $row.ReferenceKind
                condition       = $row.Condition
            }
        }
    )

    $payload | ConvertTo-Json -Depth 6 | Set-Content -Path $outputPathResolved -Encoding UTF8
    Write-Host "Wrote JSON to: $($outputPathResolved.Replace('\','/'))"
}

if ($FailOnFindings -and $sorted.Count -gt 0)
{
    exit 1
}


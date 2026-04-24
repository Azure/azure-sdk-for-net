#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Compares two resource-hierarchy JSON files (previous GA vs newly
    generated) and reports structural drift and class-name renames.

.DESCRIPTION
    Inputs are produced by:
      - Get-PreviousGaResourceHierarchy.ps1  (previous GA, via reflection)
      - Get-ResourceHierarchyFromTspCodeModel.ps1 (newly generated, via tspCodeModel.json)

    Verification is strict: every GA resource must be present in the new SDK
    with the same:
      - ARM ResourceType  (e.g. Microsoft.Foo/bars/bazes)
      - Parent set        (parent ARM resource types)
      - Scope set         (Subscription / ResourceGroup / Tenant / ManagementGroup)
      - Singleton flag
      - C# resource class name

    Class-name differences alone are reported as "renames" — they should be
    resolved via spec-side `@@clientName(..., "csharp")` so the whole ARM
    surface (resource class, collection, extension methods, parent references)
    follows. They exit with a distinct exit code (2) so callers can decide
    whether to block or to proceed with the rest of the migration.

.PARAMETER GAJson
    Path to the previous-GA hierarchy JSON.

.PARAMETER NewJson
    Path to the newly-generated hierarchy JSON.

.PARAMETER OutFile
    Optional path to write the machine-readable report. Defaults to stdout.

.EXAMPLE
    pwsh Compare-ResourceHierarchy.ps1 -GAJson ga.json -NewJson new.json

.OUTPUTS
    JSON: { missing, structuralMismatches, renames }
    Exit codes:
        0 - hierarchies match (no missing, no structural mismatches, no renames)
        1 - structural drift (missing resource / parent / scope / singleton)
        2 - structural hierarchy intact, but one or more class-name renames
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, Position = 0)]
    [string] $GAJson,

    [Parameter(Mandatory = $true, Position = 1)]
    [string] $NewJson,

    [Parameter()]
    [string] $OutFile
)

$ErrorActionPreference = 'Stop'

function Read-Hierarchy {
    param([string] $Path)
    if (-not (Test-Path -LiteralPath $Path)) {
        throw "Hierarchy file not found: $Path"
    }
    $raw = Get-Content -LiteralPath $Path -Raw
    if ([string]::IsNullOrWhiteSpace($raw)) { return @() }
    $obj = $raw | ConvertFrom-Json
    if ($null -eq $obj) { return @() }
    if ($obj -is [System.Array]) { return $obj }
    return @($obj)
}

function Build-ParentTypeMap {
    # For a hierarchy whose entries only carry ParentResources (class names),
    # we resolve each parent class name to its ResourceType using the same
    # hierarchy as the lookup table. Returns a hashtable keyed by the entry's
    # ResourceType, whose value is the (string[]) set of parent ResourceTypes.
    param([object[]] $Entries)

    $byName = @{}
    foreach ($e in $Entries) {
        if ($e.Name -and $e.ResourceType) { $byName[[string]$e.Name] = [string]$e.ResourceType }
    }

    $result = @{}
    foreach ($e in $Entries) {
        $rt = [string]$e.ResourceType
        if (-not $rt) { continue }

        # Prefer ParentResourceTypes when present (new-side script emits it).
        $parentTypes = New-Object System.Collections.Generic.List[string]
        if ($e.PSObject.Properties.Name -contains 'ParentResourceTypes' -and $e.ParentResourceTypes) {
            foreach ($t in $e.ParentResourceTypes) {
                if ($t) { [void] $parentTypes.Add([string]$t) }
            }
        }
        elseif ($e.ParentResources) {
            foreach ($p in $e.ParentResources) {
                $pName = [string]$p
                if ($byName.ContainsKey($pName)) { [void] $parentTypes.Add($byName[$pName]) }
            }
        }
        $result[$rt] = $parentTypes.ToArray()
    }
    return $result
}

function ConvertTo-Set {
    param([string[]] $Values)
    $set = New-Object 'System.Collections.Generic.HashSet[string]' ([System.StringComparer]::Ordinal)
    if ($null -eq $Values) { return $set }
    foreach ($v in $Values) {
        if ($null -ne $v) { [void] $set.Add([string]$v) }
    }
    return $set
}

function Test-SetsEqual {
    param([System.Collections.Generic.HashSet[string]] $A, [System.Collections.Generic.HashSet[string]] $B)
    if ($A.Count -ne $B.Count) { return $false }
    foreach ($x in $A) { if (-not $B.Contains($x)) { return $false } }
    return $true
}

# --- Load both sides ------------------------------------------------------------

$gaEntries  = @(Read-Hierarchy -Path $GAJson)
$newEntries = @(Read-Hierarchy -Path $NewJson)

[Console]::Error.WriteLine("GA  hierarchy: $($gaEntries.Count) resources from $GAJson")
[Console]::Error.WriteLine("New hierarchy: $($newEntries.Count) resources from $NewJson")

$gaParentMap  = Build-ParentTypeMap -Entries $gaEntries
$newParentMap = Build-ParentTypeMap -Entries $newEntries

$newByType = @{}
foreach ($e in $newEntries) {
    if ($e.ResourceType) { $newByType[[string]$e.ResourceType] = $e }
}

# --- Compare --------------------------------------------------------------------

$missing               = New-Object System.Collections.Generic.List[object]
$structuralMismatches  = New-Object System.Collections.Generic.List[object]
$renames               = New-Object System.Collections.Generic.List[object]

foreach ($ga in $gaEntries) {
    $gaType = [string]$ga.ResourceType
    if (-not $gaType) { continue }   # skip degenerate entries

    if (-not $newByType.ContainsKey($gaType)) {
        $missing.Add([pscustomobject]@{
            ResourceType = $gaType
            GAName       = [string]$ga.Name
        }) | Out-Null
        continue
    }

    $new = $newByType[$gaType]
    $issues = New-Object System.Collections.Generic.List[string]

    # Singleton flag.
    $gaSingleton  = [bool]$ga.IsSingleton
    $newSingleton = [bool]$new.IsSingleton
    if ($gaSingleton -ne $newSingleton) {
        $issues.Add("singleton: GA=$gaSingleton new=$newSingleton") | Out-Null
    }

    # Parent set (by ResourceType, not class name).
    $gaParents  = ConvertTo-Set $gaParentMap[$gaType]
    $newParents = ConvertTo-Set $newParentMap[$gaType]
    if (-not (Test-SetsEqual $gaParents $newParents)) {
        $issues.Add("parents: GA=[$([string]::Join(',', @($gaParents)))] new=[$([string]::Join(',', @($newParents)))]") | Out-Null
    }

    # Scope set: every GA scope must still be present on the new resource.
    # Since the GA reflection tool propagates scopes down the parent chain,
    # both top-level and nested resources should have non-empty scopes.
    $gaScopes = ConvertTo-Set ([string[]]@($ga.Scopes))
    if ($gaScopes.Count -gt 0) {
        $newScopes = ConvertTo-Set ([string[]]@($new.Scopes))
        $missingScopes = New-Object System.Collections.Generic.List[string]
        foreach ($s in $gaScopes) { if (-not $newScopes.Contains($s)) { [void] $missingScopes.Add($s) } }
        if ($missingScopes.Count -gt 0) {
            $issues.Add("scopes missing in new: [$([string]::Join(',', $missingScopes))]") | Out-Null
        }
    }

    if ($issues.Count -gt 0) {
        $structuralMismatches.Add([pscustomobject]@{
            ResourceType = $gaType
            GAName       = [string]$ga.Name
            NewName      = [string]$new.Name
            Issues       = $issues.ToArray()
        }) | Out-Null
        # Don't double-count rename below: a structural mismatch already
        # implies action is needed, and the rename can be addressed together.
        continue
    }

    # Class-name rename.
    $GAName  = [string]$ga.Name
    $newName = [string]$new.Name
    if ($GAName -and $newName -and $GAName -ne $newName) {
        $renames.Add([pscustomobject]@{
            ResourceType = $gaType
            GAName       = $GAName
            NewName      = $newName
        }) | Out-Null
    }
}

# --- Emit human-readable summary on stderr -------------------------------------

[Console]::Error.WriteLine("")
[Console]::Error.WriteLine("=== Resource hierarchy comparison ===")
[Console]::Error.WriteLine("Missing resources       : $($missing.Count)")
[Console]::Error.WriteLine("Structural mismatches   : $($structuralMismatches.Count)")
[Console]::Error.WriteLine("Class-name renames      : $($renames.Count)")

if ($missing.Count -gt 0) {
    [Console]::Error.WriteLine("")
    [Console]::Error.WriteLine("Missing in new SDK:")
    foreach ($m in $missing) {
        [Console]::Error.WriteLine("  - $($m.ResourceType)  (was $($m.GAName))")
    }
}
if ($structuralMismatches.Count -gt 0) {
    [Console]::Error.WriteLine("")
    [Console]::Error.WriteLine("Structural mismatches:")
    foreach ($s in $structuralMismatches) {
        [Console]::Error.WriteLine("  - $($s.ResourceType)  (GA=$($s.GAName) new=$($s.NewName))")
        foreach ($i in $s.Issues) { [Console]::Error.WriteLine("      * $i") }
    }
}
if ($renames.Count -gt 0) {
    [Console]::Error.WriteLine("")
    [Console]::Error.WriteLine("Class-name renames (fix via spec-side @@clientName so the whole ARM surface follows):")
    foreach ($r in $renames) {
        [Console]::Error.WriteLine("  - $($r.ResourceType): $($r.GAName) -> $($r.NewName)")
    }
}

# --- Emit JSON report on stdout / file -----------------------------------------

$report = [pscustomobject]@{
    missing               = $missing.ToArray()
    structuralMismatches  = $structuralMismatches.ToArray()
    renames               = $renames.ToArray()
}

$json = $report | ConvertTo-Json -Depth 6
if ($OutFile) {
    $json | Set-Content -LiteralPath $OutFile -Encoding UTF8
    [Console]::Error.WriteLine("Wrote: $OutFile")
}
else {
    $json
}

# --- Exit code -----------------------------------------------------------------

if ($missing.Count -gt 0 -or $structuralMismatches.Count -gt 0) { exit 1 }
if ($renames.Count -gt 0) { exit 2 }
exit 0

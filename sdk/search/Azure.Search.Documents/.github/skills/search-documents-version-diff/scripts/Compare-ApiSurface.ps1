<#
.SYNOPSIS
    Compares the current Azure.Search.Documents public API surface against a previous baseline
    and emits a structured JSON diff that the search-documents-version-diff skill consumes.

.DESCRIPTION
    Resolves a previous baseline (git tag, ref, or local .nupkg), extracts the public API
    listing from both sides, parses types + members, and writes added/removed/changed buckets
    plus side metadata (version, channel, tsp commit) to a single JSON file.

    The JSON is intentionally structured for LLM consumption: every entry includes its symbol
    path so the calling agent can classify without re-parsing.

.PARAMETER PreviousRef
    Git tag/branch/SHA, or path to a .nupkg. Required.

.PARAMETER RepoRoot
    Repo root. Defaults to the azure-sdk-for-net root resolved from the script's location.

.PARAMETER OutputPath
    Where to write the JSON report. Defaults to artifacts/search-version-diff.json.

.EXAMPLE
    ./Compare-ApiSurface.ps1 -PreviousRef Azure.Search.Documents_11.6.0-beta.6
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [string] $PreviousRef,
    [string] $RepoRoot,
    [string] $OutputPath
)

$ErrorActionPreference = 'Stop'

if (-not $RepoRoot) {
    $RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..\..\..\..\..')).Path
}
$pkgRoot = Join-Path $RepoRoot 'sdk/search/Azure.Search.Documents'
$apiRel = 'api/Azure.Search.Documents.netstandard2.0.cs'
$tspRel = 'tsp-location.yaml'
$csprojRel = 'src/Azure.Search.Documents.csproj'

if (-not $OutputPath) {
    $OutputPath = Join-Path $pkgRoot 'artifacts/search-version-diff.json'
}
New-Item -ItemType Directory -Force -Path (Split-Path $OutputPath) | Out-Null

function Get-CsprojVersion([string]$Text) {
    if ($Text -match '<Version>([^<]+)</Version>') { return $Matches[1] }
    return $null
}

function Get-Channel([string]$Version) {
    if ($Version -and $Version -match 'beta|alpha|preview|rc') { return 'preview' }
    return 'GA'
}

function Get-TspCommit([string]$Text) {
    foreach ($line in $Text -split "`n") {
        if ($line -match '^\s*commit:\s*(\S+)') { return $Matches[1] }
    }
    return $null
}

function Read-FromGit([string]$Ref, [string]$RelPath) {
    Push-Location $RepoRoot
    try {
        $full = "sdk/search/Azure.Search.Documents/$RelPath"
        $out = git show "${Ref}:$full" 2>$null
        if ($LASTEXITCODE -ne 0) { return $null }
        return ($out -join "`n")
    } finally { Pop-Location }
}

# --- Resolve previous side -------------------------------------------------
$prev = @{ ref = $PreviousRef }
if (Test-Path $PreviousRef -PathType Leaf) {
    throw ".nupkg baselines are not yet implemented in this script. Use a git tag, branch, or commit SHA, or follow the manual fallback documented in SKILL.md."
}
$prev.api = Read-FromGit -Ref $PreviousRef -RelPath $apiRel
if (-not $prev.api) { throw "Could not read $apiRel from '$PreviousRef'. Check that the ref exists." }
$prev.csproj = Read-FromGit -Ref $PreviousRef -RelPath $csprojRel
$prev.tspYaml = Read-FromGit -Ref $PreviousRef -RelPath $tspRel
$prev.version = Get-CsprojVersion $prev.csproj
$prev.channel = Get-Channel $prev.version
$prev.tspCommit = Get-TspCommit $prev.tspYaml

# --- Resolve current side --------------------------------------------------
$curr = @{ ref = 'working tree' }
$curr.api = Get-Content (Join-Path $pkgRoot $apiRel) -Raw
$curr.csproj = Get-Content (Join-Path $pkgRoot $csprojRel) -Raw
$curr.tspYaml = Get-Content (Join-Path $pkgRoot $tspRel) -Raw
$curr.version = Get-CsprojVersion $curr.csproj
$curr.channel = Get-Channel $curr.version
$curr.tspCommit = Get-TspCommit $curr.tspYaml

# --- Parse API surface -----------------------------------------------------
# We treat the api/*.cs listing as the source of truth (it is the export the SDK ships
# to ApiCompat). For each public type we capture: kind, full name, declared base, and
# every public member's signature line. Internals are skipped (we trust the listing).

function ConvertTo-Symbols([string]$ListingText) {
    $symbols = [System.Collections.Generic.Dictionary[string,object]]::new()
    if (-not $ListingText) { return $symbols }

    $lines = $ListingText -split "`r?`n"
    $nsStack = New-Object System.Collections.Stack
    $typeStack = New-Object System.Collections.Stack
    $braceDepth = 0
    $currentType = $null

    for ($i = 0; $i -lt $lines.Length; $i++) {
        $raw = $lines[$i]
        $line = $raw.TrimStart()

        if ($line -match '^namespace\s+([\w\.]+)') {
            $nsStack.Push($Matches[1])
            continue
        }

        if ($line -match '^public\s+(?:(?:static|sealed|abstract|partial|readonly|ref)\s+)*(class|struct|enum|interface|delegate)\s+([\w<>,\s]+?)(?:\s*:\s*(.+?))?(?:\s*where\b.*)?\s*$') {
            $kind = $Matches[1]
            $name = ($Matches[2] -split '\s')[0].Trim()
            $base = if ($Matches[3]) { $Matches[3].Trim().TrimEnd('{').Trim() } else { $null }
            $ns = if ($nsStack.Count) { $nsStack.Peek() } else { '' }
            $fullName = if ($ns) { "$ns.$name" } else { $name }
            $currentType = @{
                kind = $kind
                fullName = $fullName
                base = $base
                members = New-Object System.Collections.Generic.List[string]
            }
            $symbols[$fullName] = $currentType
            $typeStack.Push($currentType)
            continue
        }

        if ($line -eq '{') { $braceDepth++; continue }
        if ($line -eq '}') {
            $braceDepth--
            if ($typeStack.Count -gt 0) {
                $typeStack.Pop() | Out-Null
                $currentType = if ($typeStack.Count) { $typeStack.Peek() } else { $null }
            } elseif ($nsStack.Count -gt 0) {
                $nsStack.Pop() | Out-Null
            }
            continue
        }

        if ($currentType -and $line -match '^public\s' -and $line -notmatch '^public\s+(class|struct|enum|interface|delegate|static\s+class|partial\s+class|partial\s+struct|abstract\s+(?:partial\s+)?class|sealed\s+(?:partial\s+)?class|static\s+(?:partial\s+)?class|readonly\s+(?:partial\s+)?struct)\b') {
            $sig = ($line -replace '\s+', ' ').TrimEnd(';').TrimEnd(' {')
            $currentType.members.Add($sig)
        }
    }

    return $symbols
}

$prevSymbols = ConvertTo-Symbols $prev.api
$currSymbols = ConvertTo-Symbols $curr.api

# --- Compute deltas --------------------------------------------------------
$addedTypes = New-Object System.Collections.Generic.List[object]
$removedTypes = New-Object System.Collections.Generic.List[object]
$changedTypes = New-Object System.Collections.Generic.List[object]
$addedMembers = New-Object System.Collections.Generic.List[object]
$removedMembers = New-Object System.Collections.Generic.List[object]

$allTypes = ($prevSymbols.Keys + $currSymbols.Keys) | Sort-Object -Unique
foreach ($t in $allTypes) {
    $inPrev = $prevSymbols.ContainsKey($t)
    $inCurr = $currSymbols.ContainsKey($t)

    if (-not $inPrev) {
        $addedTypes.Add(@{ fullName = $t; kind = $currSymbols[$t].kind; base = $currSymbols[$t].base })
        foreach ($m in $currSymbols[$t].members) { $addedMembers.Add(@{ type = $t; signature = $m }) }
        continue
    }
    if (-not $inCurr) {
        $removedTypes.Add(@{ fullName = $t; kind = $prevSymbols[$t].kind; base = $prevSymbols[$t].base })
        foreach ($m in $prevSymbols[$t].members) { $removedMembers.Add(@{ type = $t; signature = $m }) }
        continue
    }

    $p = $prevSymbols[$t]
    $c = $currSymbols[$t]
    $kindChanged = $p.kind -ne $c.kind
    $baseChanged = $p.base -ne $c.base

    $prevSet = [System.Collections.Generic.HashSet[string]]::new($p.members)
    $currSet = [System.Collections.Generic.HashSet[string]]::new($c.members)
    $missing = $p.members | Where-Object { -not $currSet.Contains($_) }
    $extra = $c.members | Where-Object { -not $prevSet.Contains($_) }

    foreach ($m in $missing) { $removedMembers.Add(@{ type = $t; signature = $m }) }
    foreach ($m in $extra) { $addedMembers.Add(@{ type = $t; signature = $m }) }

    if ($kindChanged -or $baseChanged) {
        $changedTypes.Add(@{ fullName = $t; previousKind = $p.kind; currentKind = $c.kind; previousBase = $p.base; currentBase = $c.base })
    }
}

# --- Comparison mode -------------------------------------------------------
$mode = "$($prev.channel)->$($curr.channel)"  # e.g. preview->preview

# --- Emit ------------------------------------------------------------------
$report = [ordered]@{
    schemaVersion = 1
    generatedAt = (Get-Date).ToUniversalTime().ToString('o')
    previous = @{
        ref = $prev.ref
        version = $prev.version
        channel = $prev.channel
        tspCommit = $prev.tspCommit
    }
    current = @{
        ref = $curr.ref
        version = $curr.version
        channel = $curr.channel
        tspCommit = $curr.tspCommit
    }
    comparisonMode = $mode
    summary = @{
        addedTypes = $addedTypes.Count
        removedTypes = $removedTypes.Count
        changedTypes = $changedTypes.Count
        addedMembers = $addedMembers.Count
        removedMembers = $removedMembers.Count
    }
    addedTypes = $addedTypes
    removedTypes = $removedTypes
    changedTypes = $changedTypes
    addedMembers = $addedMembers
    removedMembers = $removedMembers
}

$report | ConvertTo-Json -Depth 8 | Set-Content -Encoding UTF8 -Path $OutputPath
Write-Host "Wrote $OutputPath"
Write-Host "Mode: $mode  |  removed: $($removedTypes.Count) types, $($removedMembers.Count) members  |  added: $($addedTypes.Count) types, $($addedMembers.Count) members"

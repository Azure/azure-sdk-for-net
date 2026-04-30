#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Parses a tspCodeModel.json (produced by the http-client-csharp-mgmt
    emitter with save-inputs=true) and outputs the management-plane resource
    hierarchy as JSON.

.DESCRIPTION
    Walks every child client and inspects the ARM URL templates of its
    operations to derive, for each resource:

        * ARM ResourceType (e.g. "Microsoft.Foo/bars/bazes")
        * ResourceId template
        * Parent chain (ordered list of parent ResourceTypes)
        * Scope (ResourceGroup / Subscription / Tenant / ManagementGroup /
          ServiceGroup / Extension)
        * IsSingleton

    The output schema is intentionally compatible with
    Get-ResourceHierarchy.ps1 so the two can be compared directly. C# class
    names ("BazResource") are derived heuristically by default; pass
    -GeneratedDir to enrich results with the actual class names by scanning
    the generated *Resource.cs files for their literal `ResourceType` value.

    Diagnostics are written to stderr; the JSON result is written to stdout.

.PARAMETER TspCodeModelPath
    Path to a tspCodeModel.json file, or to a project directory that contains
    one (script will search for src/TempTypeSpecFiles/tspCodeModel.json,
    obj/TempTypeSpecFiles/tspCodeModel.json, or a top-level tspCodeModel.json).

.PARAMETER GeneratedDir
    Optional path to the SDK src/Generated/ directory. When supplied, the
    script reads each *Resource.cs to map ResourceType -> actual class name,
    overriding the heuristic naming.

.PARAMETER OutFile
    Optional path to write the hierarchy JSON. Defaults to stdout.

.EXAMPLE
    pwsh Get-ResourceHierarchyFromTspCodeModel.ps1 `
        -TspCodeModelPath sdk/foo/Azure.ResourceManager.Foo/src `
        -GeneratedDir   sdk/foo/Azure.ResourceManager.Foo/src/Generated `
        -OutFile        new-hierarchy.json
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, Position = 0)]
    [string] $TspCodeModelPath,

    [Parameter()]
    [string] $GeneratedDir,

    [Parameter()]
    [string] $OutFile
)

$ErrorActionPreference = 'Stop'

function Resolve-TspCodeModelFile {
    param([string] $Path)
    if (-not (Test-Path -LiteralPath $Path)) {
        throw "Path not found: $Path"
    }
    $item = Get-Item -LiteralPath $Path
    if (-not $item.PSIsContainer) { return $item.FullName }
    $candidates = @(
        Join-Path $item.FullName 'tspCodeModel.json'
        Join-Path $item.FullName 'TempTypeSpecFiles/tspCodeModel.json'
        Join-Path $item.FullName 'src/TempTypeSpecFiles/tspCodeModel.json'
        Join-Path $item.FullName 'obj/TempTypeSpecFiles/tspCodeModel.json'
    )
    foreach ($c in $candidates) { if (Test-Path -LiteralPath $c) { return (Resolve-Path -LiteralPath $c).ProviderPath } }
    throw "Could not locate tspCodeModel.json under $($item.FullName). Generate with SaveInputs=true."
}

# Heuristic singularizer for ARM segment names ("storageSyncServices" -> "StorageSyncService").
function Get-Singular {
    param([string] $Word)
    if ([string]::IsNullOrEmpty($Word)) { return $Word }
    if ($Word -match 'ies$') { return ($Word -replace 'ies$', 'y') }
    if ($Word -match '([sxz]|ch|sh)es$') { return ($Word -replace 'es$', '') }
    if ($Word -match 's$' -and $Word -notmatch 'ss$') { return ($Word -replace 's$', '') }
    return $Word
}

function ConvertTo-Pascal {
    param([string] $Word)
    if ([string]::IsNullOrEmpty($Word)) { return $Word }
    return ($Word.Substring(0, 1).ToUpperInvariant() + $Word.Substring(1))
}

function Get-DefaultClassName {
    param([string] $LeafSegment)
    $singular = Get-Singular $LeafSegment
    return (ConvertTo-Pascal $singular) + 'Resource'
}

# Strip the scope prefix from a tokenized URL template. Returns the scope
# label and the remaining tokens.
# Scope prefixes recognized at the start of a resource template, in priority
# order (most specific first). Each pattern is a sequence of expected tokens;
# `{*}` matches any single placeholder token like `{subscriptionId}`.
# `ConsumeMatch = $false` leaves the matched tokens in the remaining body
# (used by `Tenant`, where the matching `providers` segment is also part of
# the resource path).
$script:ScopePatterns = @(
    @{ Scope = 'ResourceGroup';   Tokens = @('subscriptions', '{*}', 'resourceGroups', '{*}') },
    @{ Scope = 'Subscription';    Tokens = @('subscriptions', '{*}') },
    @{ Scope = 'ManagementGroup'; Tokens = @('providers', 'Microsoft.Management', 'managementGroups', '{*}') },
    @{ Scope = 'ServiceGroup';    Tokens = @('providers', 'Microsoft.Management', 'serviceGroups', '{*}') },
    @{ Scope = 'Extension';       Tokens = @('{scope}') },
    @{ Scope = 'Extension';       Tokens = @('{resourceUri}') },
    @{ Scope = 'Extension';       Tokens = @('{resourceScope}') },
    @{ Scope = 'Extension';       Tokens = @('{parentProviderNamespace}', '{parentResourceType}', '{parentResourceName}') },
    @{ Scope = 'Tenant';          Tokens = @('providers'); ConsumeMatch = $false }
)

function Get-ScopePrefix {
    param([string[]] $Tokens)

    foreach ($pattern in $script:ScopePatterns) {
        $expected = $pattern.Tokens
        if ($Tokens.Count -lt $expected.Count) { continue }

        $isMatch = $true
        for ($k = 0; $k -lt $expected.Count; $k++) {
            $exp = $expected[$k]
            $act = $Tokens[$k]
            if ($exp -eq '{*}') {
                if ($act -notmatch '^\{[^}]+\}$') { $isMatch = $false; break }
            }
            elseif ($exp -ne $act) {
                $isMatch = $false; break
            }
        }
        if (-not $isMatch) { continue }

        $consume = if ($pattern.ContainsKey('ConsumeMatch') -and -not $pattern.ConsumeMatch) { 0 } else { $expected.Count }
        $rest = if ($consume -ge $Tokens.Count) { @() } else { @($Tokens[$consume..($Tokens.Count - 1)]) }
        return @{ Scope = $pattern.Scope; Rest = $rest }
    }
    return @{ Scope = 'Unknown'; Rest = @($Tokens) }
}

# Parse the post-scope portion of a URL template into a sequence of
# resource-type segments. Each segment captures: provider, type segment, and
# whether it has a name parameter (or a literal singleton segment).
#
# For `providers/<RP>/<seg1>/{name1}/<seg2>/{name2}/providers/<RP2>/<seg3>` we
# return a flat list:
#   { Provider=<RP>; Segment=<seg1>; HasName=true;  NameToken='{name1}'   }
#   { Provider=<RP>; Segment=<seg2>; HasName=true;  NameToken='{name2}'   }
#   { Provider=<RP2>; Segment=<seg3>; HasName=false; NameToken=$null      }
function Get-ResourceSegments {
    param([string[]] $Tokens)

    $segments = New-Object System.Collections.Generic.List[object]
    $i = 0
    $currentProvider = $null
    while ($i -lt $Tokens.Count) {
        $t = $Tokens[$i]
        if ($t -eq 'providers' -and ($i + 1) -lt $Tokens.Count) {
            $currentProvider = $Tokens[$i + 1]
            $i += 2
            continue
        }
        if ($null -eq $currentProvider) { $i++; continue }
        # type segment
        $typeSeg = $t
        $i++
        $nameToken = $null
        $isLiteralSingleton = $false
        if ($i -lt $Tokens.Count) {
            $next = $Tokens[$i]
            if ($next -match '^\{[^}]+\}$') {
                $nameToken = $next
                $i++
            }
            elseif ($next -ne 'providers') {
                # Literal segment after the type — treat as singleton (e.g. "default", "current").
                $isLiteralSingleton = $true
                $nameToken = $next
                $i++
            }
        }
        $segments.Add([pscustomobject]@{
            Provider           = $currentProvider
            Segment            = $typeSeg
            HasName            = ($null -ne $nameToken)
            NameToken          = $nameToken
            IsLiteralSingleton = $isLiteralSingleton
        }) | Out-Null
    }
    return $segments
}

# Build a synthetic ResourceId template from the original tokens up to the
# end of a given segment index.
function Get-ResourceIdTemplate {
    param([string[]] $Tokens, [int] $LastSegmentIndex, [int[]] $SegmentEndTokenIndex)
    if ($LastSegmentIndex -lt 0 -or $LastSegmentIndex -ge $SegmentEndTokenIndex.Count) { return $null }
    $end = $SegmentEndTokenIndex[$LastSegmentIndex]
    if ($end -lt 0) { return $null }
    return '/' + ($Tokens[0..$end] -join '/')
}

# Same as Get-ResourceSegments but also records the token index where each
# segment's name (or singleton literal) sits, so we can rebuild ResourceId
# templates.
function Get-ResourceSegmentsWithIndex {
    param([string[]] $Tokens)

    $segments = New-Object System.Collections.Generic.List[object]
    $endIdx   = New-Object System.Collections.Generic.List[int]
    $i = 0
    $currentProvider = $null
    while ($i -lt $Tokens.Count) {
        $t = $Tokens[$i]
        if ($t -eq 'providers' -and ($i + 1) -lt $Tokens.Count) {
            $currentProvider = $Tokens[$i + 1]
            $i += 2
            # Special-case: parameterized parent provider triple
            # (`{parentProviderNamespace}/{parentResourceType}/{parentResourceName}`)
            # is not a real resource segment — it's an extension marker.
            # Skip the parameterized type+name pair too.
            if ($currentProvider -match '^\{[^}]+\}$' -and ($i + 1) -lt $Tokens.Count `
                -and $Tokens[$i] -match '^\{[^}]+\}$' -and $Tokens[$i + 1] -match '^\{[^}]+\}$') {
                $i += 2
                $currentProvider = $null
            }
            continue
        }
        if ($null -eq $currentProvider) { $i++; continue }
        $typeSeg = $t
        $typeIdx = $i
        $i++
        $nameToken = $null
        $isLiteralSingleton = $false
        $segEnd = $typeIdx
        if ($i -lt $Tokens.Count) {
            $next = $Tokens[$i]
            if ($next -match '^\{[^}]+\}$') {
                $nameToken = $next
                $segEnd = $i
                $i++
            }
            elseif ($next -ne 'providers') {
                $isLiteralSingleton = $true
                $nameToken = $next
                $segEnd = $i
                $i++
            }
        }
        $segments.Add([pscustomobject]@{
            Provider           = $currentProvider
            Segment            = $typeSeg
            HasName            = ($null -ne $nameToken -and -not $isLiteralSingleton)
            NameToken          = $nameToken
            IsLiteralSingleton = $isLiteralSingleton
        }) | Out-Null
        $endIdx.Add($segEnd) | Out-Null
    }
    return @{ Segments = $segments.ToArray(); EndIndex = $endIdx.ToArray() }
}

# Builds the cumulative ResourceType for segment index k:
# joins all providers + segments up to and including k, but consecutive
# segments under the same provider don't repeat the provider.
# e.g. providers=[RP, RP, RP2], segs=[a,b,c] -> "RP/a", "RP/a/b", "RP2/c"
function Get-CumulativeResourceTypes {
    param($Segments)
    $result = New-Object System.Collections.Generic.List[string]
    $currentProvider = $null
    $currentParts = $null
    foreach ($s in $Segments) {
        if ($s.Provider -ne $currentProvider) {
            $currentProvider = $s.Provider
            $currentParts = @($s.Provider, $s.Segment)
        }
        else {
            $currentParts += $s.Segment
        }
        $result.Add(($currentParts -join '/')) | Out-Null
    }
    # Return a .NET string[] so PowerShell pipeline behavior doesn't reshape it.
    return $result.ToArray()
}

# === Main =====================================================================

$tspFile = Resolve-TspCodeModelFile -Path $TspCodeModelPath
[Console]::Error.WriteLine("Reading: $tspFile")

$json = Get-Content -LiteralPath $tspFile -Raw | ConvertFrom-Json

# Optional: scan src/Generated/*Resource.cs to map ResourceType -> class name.
$resourceTypeToClassName = @{}
if ($GeneratedDir) {
    if (-not (Test-Path -LiteralPath $GeneratedDir)) {
        [Console]::Error.WriteLine("Warning: -GeneratedDir not found: $GeneratedDir (falling back to heuristic naming)")
    }
    else {
        $resourceCsFiles = Get-ChildItem -Path $GeneratedDir -Filter '*Resource.cs' -File -ErrorAction SilentlyContinue
        foreach ($f in $resourceCsFiles) {
            $content = Get-Content -LiteralPath $f.FullName -Raw
            $m = [regex]::Match($content, 'public\s+static\s+readonly\s+ResourceType\s+ResourceType\s*=\s*"([^"]+)"\s*;')
            if (-not $m.Success) { continue }
            $rt = $m.Groups[1].Value
            $cls = [System.IO.Path]::GetFileNameWithoutExtension($f.Name)
            if (-not $resourceTypeToClassName.ContainsKey($rt)) {
                $resourceTypeToClassName[$rt] = $cls
            }
        }
        [Console]::Error.WriteLine("Found $($resourceTypeToClassName.Count) Resource.cs class -> ResourceType mappings in $GeneratedDir")
    }
}

# Walk all child clients of the top-level service client(s).
$childClients = New-Object System.Collections.Generic.List[object]
foreach ($top in $json.clients) {
    if ($top.children) {
        foreach ($c in $top.children) { $childClients.Add($c) | Out-Null }
    }
}
[Console]::Error.WriteLine("Found $($childClients.Count) child clients")

# Aggregate by ResourceType — multiple clients can target the same resource.
$resourcesByType = @{}

foreach ($client in $childClients) {
    $allPaths = @($client.methods | ForEach-Object { $_.operation.path } | Where-Object { $_ } | Select-Object -Unique)
    if ($allPaths.Count -eq 0) { continue }

    foreach ($path in $allPaths) {
        $tokens = $path.TrimStart('/').Split('/')
        $scopeInfo = Get-ScopePrefix -Tokens $tokens
        $rest      = $scopeInfo.Rest
        if (-not $rest -or $rest.Count -lt 2) { continue }

        # Need at least one provider/segment block.
        if (-not ($rest -contains 'providers')) { continue }

        $parsed   = Get-ResourceSegmentsWithIndex -Tokens $rest
        $segs     = @($parsed.Segments)
        $segEnds  = @($parsed.EndIndex)
        if ($segs.Count -eq 0) { continue }

        # If the path included a parameterized parent (`/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/`)
        # nested under a real subscription/RG scope, treat the resulting
        # resource as an extension on top of that scope.
        $effectiveScope = $scopeInfo.Scope
        if ($path -match '/\{parentProviderNamespace\}/\{parentResourceType\}/\{parentResourceName\}/') {
            $effectiveScope = 'Extension'
        }

        # Heuristic: a segment is the canonical "resource" only if it has a
        # name parameter or is a literal singleton. Skip pure action paths
        # (e.g. /providers/MgmtTypeSpec/operations).
        for ($k = 0; $k -lt $segs.Count; $k++) {
            $seg = $segs[$k]
            if (-not $seg.HasName -and -not $seg.IsLiteralSingleton) { continue }

            $segSlice    = New-Object System.Collections.Generic.List[object]
            for ($j = 0; $j -le $k; $j++) { $segSlice.Add($segs[$j]) | Out-Null }
            [string[]] $cumulative = Get-CumulativeResourceTypes -Segments $segSlice
            $resourceType  = [string]$cumulative[$cumulative.Length - 1]
            if ($cumulative.Length -gt 1) {
                [string[]] $parentChain = $cumulative[0..($cumulative.Length - 2)]
            }
            else {
                [string[]] $parentChain = @()
            }

            # Compute the prefix-of-rest length corresponding to segment k.
            # The original `rest` token array carries the indices we recorded.
            $endTokenInRest = $segEnds[$k]
            $resourceIdTemplate = $null
            if ($endTokenInRest -ge 0) {
                # Reconstruct the full path up to segment k by combining the
                # scope prefix consumed earlier with the rest tokens up to
                # endTokenInRest.
                $consumedScopeTokens = $tokens.Count - $rest.Count
                $globalEnd           = $consumedScopeTokens + $endTokenInRest
                $resourceIdTemplate  = '/' + ($tokens[0..$globalEnd] -join '/')
            }

            $isSingleton = $seg.IsLiteralSingleton -or (-not $seg.HasName)

            if (-not $resourcesByType.ContainsKey($resourceType)) {
                $defaultClassName = Get-DefaultClassName -LeafSegment $seg.Segment
                $className = if ($resourceTypeToClassName.ContainsKey($resourceType)) {
                    $resourceTypeToClassName[$resourceType]
                } else { $defaultClassName }

                $resourcesByType[$resourceType] = [pscustomobject]@{
                    Name                = $className
                    ResourceType        = $resourceType
                    ResourceId          = $resourceIdTemplate
                    IsSingleton         = $isSingleton
                    ParentResourceTypes = @($parentChain)
                    ParentResources     = @()
                    Scopes              = @($effectiveScope)
                    SourceClients       = @($client.name)
                    OriginalNameDefault = $defaultClassName
                }
            }
            else {
                $existing = $resourcesByType[$resourceType]
                if (-not (@($existing.Scopes) -contains $effectiveScope)) {
                    $existing.Scopes = @($existing.Scopes) + $effectiveScope
                }
                if (-not (@($existing.SourceClients) -contains $client.name)) {
                    $existing.SourceClients = @($existing.SourceClients) + $client.name
                }
                if (@($parentChain).Count -gt @($existing.ParentResourceTypes).Count) {
                    $existing.ParentResourceTypes = @($parentChain)
                }
            }
        }
    }
}

# Build ParentResources (class names) from ParentResourceTypes by lookup.
[Console]::Error.WriteLine("Discovered $($resourcesByType.Count) resources")

foreach ($key in @($resourcesByType.Keys)) {
    $r = $resourcesByType[$key]
    $parentNames = New-Object System.Collections.Generic.List[string]
    if ($null -ne $r.ParentResourceTypes) {
        foreach ($prt in $r.ParentResourceTypes) {
            if ([string]::IsNullOrEmpty($prt)) { continue }
            if ($resourcesByType.ContainsKey($prt)) {
                $parentNames.Add($resourcesByType[$prt].Name) | Out-Null
            }
            else {
                $parentNames.Add($prt) | Out-Null
            }
        }
    }
    $r.ParentResources = $parentNames.ToArray()
}

$result = @($resourcesByType.Values | Sort-Object Name)
if ($GeneratedDir -and $resourceTypeToClassName.Count -gt 0) {
    $result = @($result | Where-Object { $resourceTypeToClassName.ContainsKey($_.ResourceType) })
    [Console]::Error.WriteLine("Filtered to $($result.Count) resources with generated *Resource.cs")
}

# Drop internal-only fields before output to keep the JSON tight.
$out = @($result | ForEach-Object {
    [pscustomobject]@{
        Name                = $_.Name
        ResourceType        = $_.ResourceType
        ResourceId          = $_.ResourceId
        IsSingleton         = $_.IsSingleton
        ParentResourceTypes = @($_.ParentResourceTypes)
        ParentResources     = @($_.ParentResources)
        Scopes              = @($_.Scopes)
    }
})
$json = $out | ConvertTo-Json -Depth 8
if ($OutFile) {
    $json | Set-Content -LiteralPath $OutFile -Encoding UTF8
    [Console]::Error.WriteLine("Wrote: $OutFile")
}
else {
    $json
}

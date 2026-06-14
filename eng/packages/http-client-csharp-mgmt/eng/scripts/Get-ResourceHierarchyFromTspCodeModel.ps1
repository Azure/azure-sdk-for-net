#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Parses a tspCodeModel.json (produced by the http-client-csharp-mgmt
    emitter with save-inputs=true) and outputs the management-plane resource
    hierarchy as JSON.

.DESCRIPTION
    Reads the ARM provider schema emitted into tspCodeModel.json and reports,
    for each resource:

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

function Convert-ScopeMetadataToHierarchyScope {
    param([object] $ScopeMetadata)

    if ($null -eq $ScopeMetadata -or -not ($ScopeMetadata.PSObject.Properties.Name -contains 'kind')) {
        return 'Unknown'
    }

    $kind = [string] $ScopeMetadata.kind
    if ($kind -eq 'Extension') {
        return 'ArmClient'
    }

    return $kind
}

function Get-LeafResourceInfoFromTemplate {
    param([string] $Path)

    if ([string]::IsNullOrWhiteSpace($Path)) { return $null }

    $tokens = $Path.TrimStart('/').Split('/')
    $scopeInfo = Get-ScopePrefix -Tokens $tokens
    $rest = $scopeInfo.Rest
    if (-not $rest -or $rest.Count -lt 2 -or -not ($rest -contains 'providers')) { return $null }

    $parsed = Get-ResourceSegmentsWithIndex -Tokens $rest
    $segments = @($parsed.Segments)
    if ($segments.Count -eq 0) { return $null }

    [string[]] $cumulative = Get-CumulativeResourceTypes -Segments $segments
    $leaf = $segments[$segments.Count - 1]
    return [pscustomobject]@{
        ResourceType = [string]$cumulative[$cumulative.Length - 1]
        IsSingleton  = ($leaf.IsLiteralSingleton -or (-not $leaf.HasName))
    }
}

function Get-ArmProviderSchemaResources {
    param($CodeModel)

    $resources = New-Object System.Collections.Generic.List[object]
    foreach ($client in @($CodeModel.clients)) {
        foreach ($decorator in @($client.decorators)) {
            if ($decorator.name -eq 'Azure.ClientGenerator.Core.@armProviderSchema' -and $decorator.arguments.resources) {
                foreach ($resource in @($decorator.arguments.resources)) {
                    $resources.Add($resource) | Out-Null
                }
            }
        }
    }
    return $resources.ToArray()
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

# The ARM provider schema emitted in tspCodeModel.json is the source of truth
# for resource hierarchy metadata.
$providerResources = New-Object System.Collections.Generic.List[object]
foreach ($top in $json.clients) {
    foreach ($decorator in @($top.decorators)) {
        if ($decorator.name -ne 'Azure.ClientGenerator.Core.@armProviderSchema') { continue }
        foreach ($resource in @($decorator.arguments.resources)) {
            if ($resource.resourceType) {
                $providerResources.Add($resource) | Out-Null
            }
        }
    }
}
if ($providerResources.Count -eq 0) {
    throw "No Azure.ClientGenerator.Core.@armProviderSchema resource metadata found in $tspFile."
}
[Console]::Error.WriteLine("Found $($providerResources.Count) ARM provider schema resource metadata entries")

$resourceTypeByIdPattern = @{}
foreach ($resource in $providerResources) {
    if ($resource.resourceIdPattern -and $resource.resourceType) {
        $resourceTypeByIdPattern[[string] $resource.resourceIdPattern] = [string] $resource.resourceType
    }
}

$resourcesByType = @{}
foreach ($resource in $providerResources) {
    $resourceType = [string] $resource.resourceType
    if ([string]::IsNullOrWhiteSpace($resourceType)) { continue }

    $parentChain = @()
    if ($resource.parentResourceId) {
        $parentResourceId = [string] $resource.parentResourceId
        if ($resourceTypeByIdPattern.ContainsKey($parentResourceId)) {
            $parentChain = @($resourceTypeByIdPattern[$parentResourceId])
        }
        else {
            $parentChain = @($parentResourceId)
        }
    }

    $leafSegment = ($resourceType -split '/')[-1]
    $defaultClassName = Get-DefaultClassName -LeafSegment $leafSegment
    $className = if ($resourceTypeToClassName.ContainsKey($resourceType)) {
        $resourceTypeToClassName[$resourceType]
    } else { $defaultClassName }
    $resourceScope = Convert-ScopeMetadataToHierarchyScope -ScopeMetadata $resource.scope

    $resourcesByType[$resourceType] = [pscustomobject]@{
        Name                = $className
        ResourceType        = $resourceType
        ResourceId          = [string] $resource.resourceIdPattern
        IsSingleton         = -not [string]::IsNullOrWhiteSpace([string] $resource.singletonResourceName)
        ParentResourceTypes = @($parentChain)
        ParentResources     = @()
        Scopes              = @($resourceScope)
        SourceClients       = @()
        OriginalNameDefault = $defaultClassName
    }
}

# Build ParentResources (class names) from ParentResourceTypes by lookup.
[Console]::Error.WriteLine("Discovered $($resourcesByType.Count) resources")

# Prefer the ARM provider schema when it is present. The path scan above is
# intentionally broad so it can discover scopes from generated clients, but
# action paths such as `/webhooks/generateUri` can otherwise look like literal
# singleton resources. The provider schema carries the canonical resource ID
# pattern and direct parent resource ID emitted by the ARM decorators.
$schemaResources = @(Get-ArmProviderSchemaResources -CodeModel $json)
if ($schemaResources.Count -gt 0) {
    $schemaResourceIdToType = @{}
    foreach ($schemaResource in $schemaResources) {
        if ($schemaResource.resourceIdPattern -and $schemaResource.resourceType) {
            $schemaResourceIdToType[[string]$schemaResource.resourceIdPattern] = [string]$schemaResource.resourceType
        }
    }

    foreach ($schemaResource in $schemaResources) {
        $resourceType = [string]$schemaResource.resourceType
        if (-not $resourceType -or -not $resourcesByType.ContainsKey($resourceType)) { continue }

        $resource = $resourcesByType[$resourceType]
        if ($schemaResource.resourceIdPattern) {
            $resource.ResourceId = [string]$schemaResource.resourceIdPattern
            $leafInfo = Get-LeafResourceInfoFromTemplate -Path ([string]$schemaResource.resourceIdPattern)
            if ($null -ne $leafInfo) {
                $resource.IsSingleton = [bool]$leafInfo.IsSingleton
            }
        }

        $parentType = $null
        $parentResourceId = [string]$schemaResource.parentResourceId
        if ($parentResourceId) {
            if ($schemaResourceIdToType.ContainsKey($parentResourceId)) {
                $parentType = $schemaResourceIdToType[$parentResourceId]
            }
            else {
                $parentInfo = Get-LeafResourceInfoFromTemplate -Path $parentResourceId
                if ($null -ne $parentInfo) { $parentType = [string]$parentInfo.ResourceType }
            }
        }
        $resource.ParentResourceTypes = if ($parentType) { @($parentType) } else { @() }
    }
}

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

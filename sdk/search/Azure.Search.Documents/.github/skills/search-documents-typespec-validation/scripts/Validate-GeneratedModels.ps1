<#
.SYNOPSIS
    Validates generated model files against the public API listing for Azure.Search.Documents.

.DESCRIPTION
    Cross-references all generated model files in src/Generated/Models/ against the public API
    listing to detect models that are public but missing from the API, or internal models that
    should be verified as intentionally hidden.

    This script is used by the search-documents-typespec-validation skill to perform exhaustive
    automated verification of the SDK surface.

.PARAMETER PackageRoot
    Path to the Azure.Search.Documents package root directory.
    Defaults to the package root relative to this script's location.

.PARAMETER ApiListingPath
    Path to the API listing file to validate against.
    Defaults to api/Azure.Search.Documents.netstandard2.0.cs under PackageRoot.

.PARAMETER TypeNames
    Optional array of specific type names to verify exist in the API listing.
    Use this to batch-check TypeSpec model names (after @@clientName renames) against the SDK.

.PARAMETER Format
    Output format: 'summary' for human-readable, 'json' for agent consumption.
    Default: json.

.EXAMPLE
    ./Validate-GeneratedModels.ps1

.EXAMPLE
    ./Validate-GeneratedModels.ps1 -TypeNames @("SearchIndex", "SearchField", "SearchIndexer")

.EXAMPLE
    ./Validate-GeneratedModels.ps1 -Format summary
#>

[CmdletBinding()]
param(
    [string]$PackageRoot = (Resolve-Path "$PSScriptRoot/../../../../").Path,

    [string]$ApiListingPath,

    [string[]]$TypeNames,

    [ValidateSet('json', 'summary')]
    [string]$Format = 'json'
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

# Resolve API listing path
if (-not $ApiListingPath) {
    $ApiListingPath = Join-Path $PackageRoot 'api/Azure.Search.Documents.netstandard2.0.cs'
    if (-not (Test-Path $ApiListingPath)) {
        $ApiListingPath = Join-Path $PackageRoot 'api/Azure.Search.Documents.net10.0.cs'
    }
}

if (-not (Test-Path $ApiListingPath)) {
    Write-Error "API listing file not found. Run 'eng/scripts/Export-API.ps1 search' first."
    return
}

$apiContent = Get-Content $ApiListingPath -Raw
$genDir = Join-Path $PackageRoot 'src/Generated/Models'

if (-not (Test-Path $genDir)) {
    Write-Error "Generated models directory not found at: $genDir"
    return
}

# Cross-reference generated models against API listing
$publicFound = 0
$publicMissing = @()
$internalCount = 0
$internalTypes = @()

Get-ChildItem $genDir -Filter '*.cs' |
    Where-Object { $_.Name -notmatch '\.Serialization\.cs$' } |
    ForEach-Object {
        $fc = Get-Content $_.FullName -Raw
        $m = [regex]::Match($fc, '(public|internal)\s+(readonly\s+)?(partial\s+)?(static\s+)?(abstract\s+)?(class|struct|enum|interface)\s+(\w+)')
        if ($m.Success) {
            $access = $m.Groups[1].Value
            $typeName = $m.Groups[7].Value
            if ($access -eq 'internal') {
                $internalCount++
                $internalTypes += $typeName
            }
            else {
                if ($apiContent -match "\b$typeName\b") {
                    $publicFound++
                }
                else {
                    $publicMissing += $typeName
                }
            }
        }
    }

# Batch-check specific type names if provided
$typeCheckResults = @()
if ($TypeNames) {
    foreach ($tn in $TypeNames) {
        $typeCheckResults += [PSCustomObject]@{
            TypeName = $tn
            InApi    = [bool]($apiContent -match "\b$tn\b")
        }
    }
}

# Verify skill/analyzer/tokenizer/token-filter presence
$skillFiles = Get-ChildItem $genDir -Filter '*Skill.cs' -Name | Where-Object { $_ -notmatch 'Serialization' }
$tokenizerFiles = Get-ChildItem $genDir -Filter '*Tokenizer.cs' -Name | Where-Object { $_ -notmatch 'Serialization' }
$tokenFilterFiles = Get-ChildItem $genDir -Filter '*TokenFilter.cs' -Name | Where-Object { $_ -notmatch 'Serialization' }

if ($Format -eq 'json') {
    $result = [ordered]@{
        apiListingFile  = $ApiListingPath
        publicFound     = $publicFound
        publicMissing   = $publicMissing
        internalCount   = $internalCount
        internalTypes   = $internalTypes
        skillFiles      = @($skillFiles)
        tokenizerFiles  = @($tokenizerFiles)
        tokenFilterFiles = @($tokenFilterFiles)
    }
    if ($TypeNames) {
        $result.typeCheckResults = $typeCheckResults
    }
    $result | ConvertTo-Json -Depth 3
}
else {
    Write-Host "=== Generated Model Validation ===" -ForegroundColor Cyan
    Write-Host "API listing: $ApiListingPath"
    Write-Host "Public found in API:   $publicFound" -ForegroundColor Green
    Write-Host "Internal (by design):  $internalCount" -ForegroundColor Yellow
    Write-Host "Public MISSING from API: $($publicMissing.Count)" -ForegroundColor $(if ($publicMissing.Count -gt 0) { 'Red' } else { 'Green' })

    if ($publicMissing) {
        $publicMissing | ForEach-Object { Write-Host "  MISSING: $_" -ForegroundColor Red }
    }

    if ($TypeNames) {
        Write-Host "`n=== Type Name Checks ===" -ForegroundColor Cyan
        $missing = $typeCheckResults | Where-Object { -not $_.InApi }
        if ($missing) {
            $missing | ForEach-Object { Write-Host "  NOT IN SDK: $($_.TypeName)" -ForegroundColor Red }
        }
        else {
            Write-Host "  All specified types found in API listing." -ForegroundColor Green
        }
    }

    Write-Host "`n=== Generated Specializations ===" -ForegroundColor Cyan
    Write-Host "Skills:        $($skillFiles.Count)"
    Write-Host "Tokenizers:    $($tokenizerFiles.Count)"
    Write-Host "Token Filters: $($tokenFilterFiles.Count)"
}

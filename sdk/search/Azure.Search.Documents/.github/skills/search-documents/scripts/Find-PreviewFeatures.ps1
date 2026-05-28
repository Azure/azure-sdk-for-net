<#
.SYNOPSIS
    Finds all preview-marked features in the Azure.Search.Documents SDK source.

.DESCRIPTION
    Scans for `// search-preview:<api-version>` comment markers in the SDK source
    (excludes tests, samples, and generated code). Reports both single-line markers
    and block markers (paired `{ ... }` delimiters).

    Output is structured JSON suitable for agent consumption.

.PARAMETER SourcePath
    Path to the SDK src directory. Defaults to the Azure.Search.Documents/src folder.

.PARAMETER ApiVersion
    Optional filter — only return markers for this specific API version.

.PARAMETER IncludeGenerated
    If set, also scans Generated/ folders (normally excluded).

.PARAMETER Format
    Output format: 'json' (default, structured) or 'summary' (human-readable table).

.EXAMPLE
    # List all preview features
    pwsh Find-PreviewFeatures.ps1

.EXAMPLE
    # Filter to a specific API version
    pwsh Find-PreviewFeatures.ps1 -ApiVersion "2026-05-01-preview"

.EXAMPLE
    # Human-readable summary
    pwsh Find-PreviewFeatures.ps1 -Format summary
#>

param(
    [string]$SourcePath,
    [string]$ApiVersion,
    [switch]$IncludeGenerated,
    [ValidateSet('json', 'summary')]
    [string]$Format = 'json'
)

# Resolve source path
if (-not $SourcePath) {
    $scriptDir = $PSScriptRoot
    $SourcePath = Resolve-Path (Join-Path $scriptDir "../../../../src")
}

if (-not (Test-Path $SourcePath)) {
    Write-Error "Source path not found: $SourcePath"
    exit 1
}

# Pattern: // search-preview:<version> or // search-preview:<version> {  or // search-preview:<version> }
$markerPattern = '//\s*search-preview:(?<version>[^\s\{\}]+)\s*(?<delim>\{|\})?'

# Collect all .cs files (exclude Generated/ by default, always exclude tests)
$files = Get-ChildItem -Path $SourcePath -Filter "*.cs" -Recurse | Where-Object {
    $rel = $_.FullName.Substring($SourcePath.Length)
    if (-not $IncludeGenerated -and $rel -match '[/\\]Generated[/\\]') { return $false }
    return $true
}

$features = [System.Collections.Generic.List[object]]::new()
$blocks = [System.Collections.Generic.List[object]]::new()

# Stack for tracking open blocks per file
foreach ($file in $files) {
    $relativePath = $file.FullName.Substring($SourcePath.Length).TrimStart('\', '/')
    $lines = Get-Content $file.FullName
    $openBlocks = @{}  # version -> line number of opening marker

    for ($i = 0; $i -lt $lines.Count; $i++) {
        $line = $lines[$i]
        if ($line -match $markerPattern) {
            $version = $Matches['version']
            $delim = $Matches['delim']

            # Apply version filter
            if ($ApiVersion -and $version -ne $ApiVersion) { continue }

            if ($delim -eq '{') {
                # Block open
                $openBlocks[$version] = $i + 1  # 1-based line number
            }
            elseif ($delim -eq '}') {
                # Block close — emit the block
                $startLine = $openBlocks[$version]
                if ($startLine) {
                    # Collect the content lines between the markers
                    $contentLines = @()
                    for ($j = $startLine; $j -lt $i; $j++) {
                        $contentLines += $lines[$j].Trim()
                    }

                    $blocks.Add([PSCustomObject]@{
                        type        = 'block'
                        file        = $relativePath
                        apiVersion  = $version
                        startLine   = $startLine
                        endLine     = $i + 1
                        lineCount   = $i - $startLine
                        content     = ($contentLines | Where-Object { $_ -ne '' }) -join '; '
                        symbols     = ($contentLines | ForEach-Object {
                            if ($_ -match '(?:public|internal|private|protected)\s+.*?\s+(\w+)\s*[\{\(;=]') {
                                $Matches[1]
                            }
                        }) | Where-Object { $_ }
                    })
                    $openBlocks.Remove($version)
                }
            }
            else {
                # Single-line marker — capture the line it annotates
                # The marker is either on the same line as code, or the next line has the code
                $codeLine = $line -replace '//\s*search-preview:[^\s]+\s*', '' | ForEach-Object { $_.Trim() }
                if (-not $codeLine -or $codeLine -match '^\s*$') {
                    # Marker is on its own line — the next non-empty, non-comment line is the feature
                    for ($j = $i + 1; $j -lt $lines.Count; $j++) {
                        $candidate = $lines[$j].Trim()
                        if ($candidate -and $candidate -notmatch '^//') {
                            $codeLine = $candidate
                            break
                        }
                    }
                }

                $symbol = $null
                if ($codeLine -match '(?:public|internal|private|protected)\s+.*?\s+(\w+)\s*[\{\(;=]') {
                    $symbol = $Matches[1]
                }
                elseif ($codeLine -match '(\w+)\s*=') {
                    $symbol = $Matches[1]
                }

                $features.Add([PSCustomObject]@{
                    type       = 'line'
                    file       = $relativePath
                    apiVersion = $version
                    line       = $i + 1
                    symbol     = $symbol
                    code       = $codeLine
                })
            }
        }
    }
}

# Combine and sort
$allItems = @($features) + @($blocks) | Sort-Object apiVersion, file, { if ($_.line) { $_.line } else { $_.startLine } }

# Output
if ($Format -eq 'summary') {
    $grouped = $allItems | Group-Object apiVersion
    foreach ($group in $grouped) {
        Write-Host "`n=== API Version: $($group.Name) ===" -ForegroundColor Cyan
        Write-Host "  Total markers: $($group.Count)"
        Write-Host ""

        foreach ($item in $group.Group) {
            if ($item.type -eq 'block') {
                $symbolList = if ($item.symbols) { ($item.symbols -join ', ') } else { '(no named symbols)' }
                Write-Host "  [BLOCK] $($item.file):$($item.startLine)-$($item.endLine)  ($($item.lineCount) lines)" -ForegroundColor Yellow
                Write-Host "          Symbols: $symbolList"
            }
            else {
                $sym = if ($item.symbol) { $item.symbol } else { '(statement)' }
                Write-Host "  [LINE]  $($item.file):$($item.line)  $sym" -ForegroundColor Green
                Write-Host "          $($item.code)"
            }
        }
    }

    Write-Host "`n--- Total: $($allItems.Count) preview markers across $($files.Count) files ---" -ForegroundColor White
}
else {
    $result = [PSCustomObject]@{
        scanPath    = $SourcePath
        scannedFiles = $files.Count
        totalMarkers = $allItems.Count
        apiVersions = ($allItems | Select-Object -ExpandProperty apiVersion -Unique)
        features    = $allItems
    }
    $result | ConvertTo-Json -Depth 5
}

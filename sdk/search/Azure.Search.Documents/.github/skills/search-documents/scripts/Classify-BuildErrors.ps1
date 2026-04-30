<#
.SYNOPSIS
    Classifies C# build errors into root-cause groups for efficient batch resolution.

.DESCRIPTION
    Runs `dotnet build` on the Azure.Search.Documents project, parses all errors,
    deduplicates across target frameworks, and groups them by (errorCode, targetSymbol).
    Outputs a structured JSON report to stdout.

    Each group represents ONE root cause that can be fixed in a single batch —
    the agent reads one generated file, then applies fixes to all affected call sites
    via multi_replace_string_in_file.

.PARAMETER ProjectPath
    Path to the .csproj file. Defaults to the Azure.Search.Documents src project.

.PARAMETER RepoRoot
    Root of the azure-sdk-for-net repository. Defaults to the repo root relative to this script.

.EXAMPLE
    pwsh .github/skills/search-documents/scripts/Classify-BuildErrors.ps1
#>

param(
    [string]$ProjectPath,
    [string]$RepoRoot
)

# Resolve paths
if (-not $RepoRoot) {
    $RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot "../../../../../../..")).Path
}
if (-not $ProjectPath) {
    $ProjectPath = Join-Path $RepoRoot "sdk/search/Azure.Search.Documents/src/Azure.Search.Documents.csproj"
}

# Run build and capture output
$buildOutput = dotnet build $ProjectPath 2>&1 | Out-String

# Parse error lines — match pattern: file(line,col): error CSxxxx: message [project]
$errorPattern = '(?<file>[^(]+)\((?<line>\d+),(?<col>\d+)\):\s+error\s+(?<code>CS\d+):\s+(?<message>.+?)\s*\['
$parsed = [System.Collections.Generic.List[hashtable]]::new()

foreach ($line in ($buildOutput -split "`n")) {
    if ($line -match $errorPattern) {
        $file = $Matches['file'].Trim()
        # Normalize to repo-relative path
        $relFile = $file
        if ($file.StartsWith($RepoRoot, [System.StringComparison]::OrdinalIgnoreCase)) {
            $relFile = $file.Substring($RepoRoot.Length).TrimStart('\', '/')
        }
        # Strip target framework suffix from file path (some MSBuild outputs include it)
        $relFile = $relFile -replace '::TargetFramework=.+$', ''

        $parsed.Add(@{
            file    = $relFile
            line    = [int]$Matches['line']
            col     = [int]$Matches['col']
            code    = $Matches['code']
            message = $Matches['message'].Trim()
        })
    }
}

if ($parsed.Count -eq 0) {
    # No errors — output success
    @{
        status  = "success"
        summary = @{ totalErrors = 0; uniqueErrors = 0; rootCauseGroups = 0 }
        groups  = @()
    } | ConvertTo-Json -Depth 10
    exit 0
}

# Deduplicate across target frameworks: same (file, line, code) = one error
$deduped = $parsed |
    Sort-Object { "$($_.file)|$($_.line)|$($_.code)" } -Unique |
    ForEach-Object { $_ }

# Extract target symbol from error message using single-quoted strings.
# C# compiler messages universally use single quotes for symbol references.
# The last quoted string is consistently the most specific symbol (the type,
# constructor, or member being referenced). No per-error-code logic needed.
function Get-TargetSymbol {
    param([string]$Message)

    # Extract all single-quoted strings from the message
    $quoted = [regex]::Matches($Message, "'([^']+)'") | ForEach-Object { $_.Groups[1].Value }

    if ($quoted.Count -eq 0) {
        # Fallback: use first 80 chars of message as grouping key
        return $Message.Substring(0, [Math]::Min(80, $Message.Length))
    }

    # Use the last quoted string — it's the most specific symbol
    $sym = $quoted[-1]
    # Normalize: strip parameter list  "Type.Ctor(params...)" -> "Type.Ctor"
    $sym = $sym -replace '\(.*\)$', ''
    return $sym
}

# Classify whether a file is generated or custom
$generatedDir = "sdk/search/Azure.Search.Documents/src/Generated/"
function Test-IsGenerated {
    param([string]$RelPath)
    return $RelPath -replace '\\', '/' -like "${generatedDir}*"
}

# Try to find the generated file that defines a target symbol
function Find-GeneratedFile {
    param([string]$TargetSymbol, [string]$Root)

    # Extract the type name (last segment before any method)
    $typeName = ($TargetSymbol -split '\.' | Select-Object -Last 1) -replace ':.*', ''
    if (-not $typeName -or $typeName.Length -lt 3) { return $null }

    $genPath = Join-Path $Root $generatedDir
    # Search for file named after the type
    $candidates = Get-ChildItem -Path $genPath -Filter "$typeName.cs" -Recurse -ErrorAction SilentlyContinue
    if ($candidates.Count -gt 0) {
        $found = $candidates[0].FullName
        if ($found.StartsWith($Root, [System.StringComparison]::OrdinalIgnoreCase)) {
            return $found.Substring($Root.Length).TrimStart('\', '/')
        }
        return $found
    }

    # Try partial match
    $candidates = Get-ChildItem -Path $genPath -Filter "*$typeName*" -Recurse -ErrorAction SilentlyContinue |
        Where-Object { $_.Name -notlike "*.Serialization.cs" } |
        Select-Object -First 1
    if ($candidates) {
        $found = $candidates.FullName
        if ($found.StartsWith($Root, [System.StringComparison]::OrdinalIgnoreCase)) {
            return $found.Substring($Root.Length).TrimStart('\', '/')
        }
        return $found
    }

    return $null
}

# Group by (errorCode, targetSymbol)
$groups = [System.Collections.Generic.List[hashtable]]::new()
$grouped = $deduped | Group-Object { "$($_.code)|$(Get-TargetSymbol $_.message)" }

foreach ($g in $grouped) {
    $parts = $g.Name -split '\|', 2
    $errorCode = $parts[0]
    $targetSymbol = $parts[1]

    $callSites = $g.Group | ForEach-Object {
        @{
            file    = $_.file -replace '\\', '/'
            line    = $_.line
            message = $_.message
        }
    }

    # Separate generated vs custom call sites
    $customSites = @($callSites | Where-Object { -not (Test-IsGenerated $_.file) })
    $generatedSites = @($callSites | Where-Object { Test-IsGenerated $_.file })

    # Find the generated file that defines the changed symbol
    $genFile = Find-GeneratedFile -TargetSymbol $targetSymbol -Root $RepoRoot

    $groups.Add(@{
        errorCode       = $errorCode
        targetSymbol    = $targetSymbol
        generatedFile   = $genFile
        fixableSites    = $customSites
        generatedSites  = $generatedSites
        totalCount      = $callSites.Count
        fixableCount    = $customSites.Count
    })
}

# Sort by fixable count descending (biggest bang first)
$sortedGroups = $groups | Sort-Object { -$_.fixableCount }

# Build summary
$byCode = @{}
foreach ($e in $deduped) {
    $c = $e.code
    if ($byCode.ContainsKey($c)) { $byCode[$c]++ } else { $byCode[$c] = 1 }
}

$report = @{
    status  = "errors"
    summary = @{
        totalErrors     = $parsed.Count
        uniqueErrors    = $deduped.Count
        rootCauseGroups = $sortedGroups.Count
        errorsByCode    = $byCode
    }
    groups  = @($sortedGroups)
}

$report | ConvertTo-Json -Depth 10

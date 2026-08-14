# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

<#
.SYNOPSIS
Converts an APIView token JSON file into a markdown file.

.DESCRIPTION
Reads an APIView token JSON file (tree-style format) and renders its ReviewLines into
a fenced markdown code block. This script is language-agnostic and works with token
files produced by any APIView parser.

.PARAMETER TokenJsonPath
Required. Path to the input APIView token JSON file.

.PARAMETER OutputPath
Required. Path to write the output markdown file. If a directory is given, the file will be
named api.md inside that directory.

.EXAMPLE
./Export-APIViewMarkdown.ps1 -TokenJsonPath ./azure-core_python.json -OutputPath ./api.md

.EXAMPLE
./Export-APIViewMarkdown.ps1 -TokenJsonPath ./azure-sdk_java.json -OutputPath ./output/
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$TokenJsonPath,

    [Parameter(Mandatory = $true)]
    [string]$OutputPath
)

Set-StrictMode -Version 3
$ErrorActionPreference = 'Stop'

function Render-Token {
    <#
    .SYNOPSIS
    Renders a single ReviewToken object to a string, applying HasPrefixSpace and HasSuffixSpace.
    #>
    param([PSCustomObject]$Token)

    $prefix = if ($Token.HasPrefixSpace -eq $true) { " " } else { "" }
    $suffix = if ($Token.HasSuffixSpace -eq $true) { " " } else { "" }
    return "$prefix$($Token.Value)$suffix"
}

function Render-ReviewLines {
    <#
    .SYNOPSIS
    Recursively renders a list of ReviewLine objects into an array of strings.
    #>
    param(
        [object[]]$ReviewLines,
        [int]$IndentLevel = 0
    )

    $result = [System.Collections.Generic.List[string]]::new()
    $indent = "    " * $IndentLevel

    foreach ($line in $ReviewLines) {
        $tokens = @($line.Tokens)

        if ($tokens.Count -eq 0) {
            # Blank line
            $result.Add("")
        }
        else {
            $lineText = ($tokens | ForEach-Object { Render-Token $_ }) -join ""
            if ($lineText.Trim() -ne "") {
                $result.Add("$indent$lineText")
            }
            else {
                $result.Add("")
            }
        }

        # Recursively render children with increased indentation
        $childrenProp = $line.PSObject.Properties.Item('Children')
        if ($null -ne $childrenProp -and $null -ne $childrenProp.Value -and $childrenProp.Value.Count -gt 0) {
            $childLines = Render-ReviewLines -ReviewLines $childrenProp.Value -IndentLevel ($IndentLevel + 1)
            foreach ($childLine in $childLines) {
                $result.Add($childLine)
            }
        }
    }

    return $result
}

# --- Main ---

if (-not (Test-Path $TokenJsonPath)) {
    Write-Error "Token JSON file not found: $TokenJsonPath"
    exit 1
}

$tokenJson = Get-Content -Path $TokenJsonPath -Raw | ConvertFrom-Json

if (-not $tokenJson.ReviewLines) {
    Write-Error "The token JSON file does not contain a 'ReviewLines' property."
    exit 1
}

# Resolve output path: if a directory is given, default filename to api.md
if (Test-Path $OutputPath -PathType Container) {
    $OutputPath = Join-Path $OutputPath "api.md"
}
elseif (-not [System.IO.Path]::HasExtension($OutputPath)) {
    $OutputPath = Join-Path $OutputPath "api.md"
}

# Read language from the token JSON, falling back to empty string
$language = if ($tokenJson.PSObject.Properties.Item('Language') -and $tokenJson.Language) {
    $tokenJson.Language.ToLower()
} else {
    ""
}

# Map full language names to common code fence identifiers
$languageAliases = @{
    "python"     = "py"
    "javascript" = "js"
    "typescript" = "ts"
}
if ($languageAliases.ContainsKey($language)) {
    $language = $languageAliases[$language]
}

$reviewLines = @($tokenJson.ReviewLines)
$renderedLines = Render-ReviewLines -ReviewLines $reviewLines

$fenceOpen = "``````$language"
$fenceClose = "``````"

$outputLines = [System.Collections.Generic.List[string]]::new()
$outputLines.Add($fenceOpen)
foreach ($line in $renderedLines) {
    $outputLines.Add($line)
}
$outputLines.Add($fenceClose)

$outputContent = $outputLines -join "`n"

$outputDir = Split-Path -Parent $OutputPath
if ($outputDir -and -not (Test-Path $outputDir)) {
    New-Item -ItemType Directory -Path $outputDir -Force | Out-Null
}

Set-Content -Path $OutputPath -Value $outputContent -NoNewline -Encoding utf8

Write-Host "Generated markdown: $OutputPath"

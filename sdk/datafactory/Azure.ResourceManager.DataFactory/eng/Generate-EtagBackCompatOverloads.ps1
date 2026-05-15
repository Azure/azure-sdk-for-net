# Generates back-compat string overloads for ETag? ifMatch/ifNoneMatch parameters.
#
# The MPG generator's MatchConditionsHeadersVisitor converts single If-Match or
# If-None-Match header parameters from string to ETag?, but the previous SDK
# surface used string. To preserve back-compat, emit partial-class string
# overloads (marked [EditorBrowsable(Never)]) that convert and delegate to the
# new ETag? methods.

[CmdletBinding()]
param(
    [string] $GeneratedRoot = (Join-Path $PSScriptRoot '..\src\Generated'),
    [string] $CustomRoot    = (Join-Path $PSScriptRoot '..\src\Custom')
)

$ErrorActionPreference = 'Stop'
$generatedRoot = (Resolve-Path $GeneratedRoot).Path

if (-not (Test-Path $CustomRoot)) {
    New-Item -ItemType Directory -Path $CustomRoot -Force | Out-Null
}

# Regex pattern: capture full method signature lines for ETag? overloads.
# Matches a method declaration that contains ETag? ifMatch or ETag? ifNoneMatch.
$methodPattern = '(?ms)^\s*public virtual (?:async )?(?<return>[A-Za-z0-9_\.<>,?\s]+?) (?<method>[A-Za-z0-9_]+)\s*\((?<params>[^)]*?ETag\? if(Match|NoneMatch)[^)]*?)\)\s*$'

$processedFiles = 0
$filesWritten = @()

# Discover all generated files that have ETag? ifMatch/ifNoneMatch parameters.
$candidates = Get-ChildItem -Path $generatedRoot -Filter '*.cs' -File -Recurse |
    Where-Object {
        $name = $_.Name
        ($name -match 'Collection\.cs$' -or $name -match 'Resource\.cs$' -or $name -eq 'MockableDataFactoryResourceGroupResource.cs') -and
        (Select-String -Path $_.FullName -Pattern 'ETag\?\s+if(Match|NoneMatch)' -Quiet)
    }

foreach ($file in $candidates) {
    $className = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)
    $relativePath = Resolve-Path $file.FullName -Relative
    $text = [System.IO.File]::ReadAllText($file.FullName)

    # Find namespace
    $nsMatch = [regex]::Match($text, '(?m)^namespace\s+([\w\.]+)')
    if (-not $nsMatch.Success) { continue }
    $namespace = $nsMatch.Groups[1].Value

    # Extract method signatures
    $methods = @()
    foreach ($match in [regex]::Matches($text, $methodPattern)) {
        $returnType = $match.Groups['return'].Value.Trim()
        $methodName = $match.Groups['method'].Value.Trim()
        $paramText  = $match.Groups['params'].Value.Trim()

        # Replace ETag? ifMatch = default / ETag? ifNoneMatch = default with string version (no default)
        $newParams = $paramText `
            -replace 'ETag\?\s+ifMatch\s*=\s*default(?:\(ETag\?\))?', 'string ifMatch' `
            -replace 'ETag\?\s+ifNoneMatch\s*=\s*default(?:\(ETag\?\))?', 'string ifNoneMatch' `
            -replace 'ETag\?\s+ifMatch\b', 'string ifMatch' `
            -replace 'ETag\?\s+ifNoneMatch\b', 'string ifNoneMatch'

        # Build call argument list: same param names but convert ifMatch/ifNoneMatch from string to ETag?
        # Strip default values and types from each param to get arg list
        $argList = @()
        foreach ($p in $paramText -split ',') {
            $p = $p.Trim()
            # Match optional default: "Type name = default" or "Type name"
            if ($p -match '\s(\w+)(\s*=.*)?$') {
                $name = $matches[1]
                if ($name -eq 'ifMatch' -or $name -eq 'ifNoneMatch') {
                    $argList += "$name != null ? new ETag($name) : (ETag?)null"
                } else {
                    $argList += $name
                }
            }
        }
        $argsExpr = ($argList -join ', ')

        $isAsync = $match.Value -match '\basync\b'
        $asyncMod = if ($isAsync) { 'async ' } else { '' }
        $awaitExpr = if ($isAsync) { ' await' } else { '' }
        $configAwait = if ($isAsync) { '.ConfigureAwait(false)' } else { '' }

        $methods += [PSCustomObject]@{
            Return   = $returnType
            Name     = $methodName
            NewParams = $newParams
            Args     = $argsExpr
            IsAsync  = $isAsync
        }
    }

    if ($methods.Count -eq 0) { continue }

    # Generate the Custom partial file
    $sb = [System.Text.StringBuilder]::new()
    [void]$sb.AppendLine('// Copyright (c) Microsoft Corporation. All rights reserved.')
    [void]$sb.AppendLine('// Licensed under the MIT License.')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine('#nullable disable')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine('using System;')
    [void]$sb.AppendLine('using System.ComponentModel;')
    [void]$sb.AppendLine('using System.Threading;')
    [void]$sb.AppendLine('using System.Threading.Tasks;')
    [void]$sb.AppendLine('using Azure;')
    [void]$sb.AppendLine('using Azure.ResourceManager;')
    [void]$sb.AppendLine('using Azure.ResourceManager.DataFactory.Models;')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine('#pragma warning disable CS1591')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine("namespace $namespace")
    [void]$sb.AppendLine('{')
    [void]$sb.AppendLine("    public partial class $className")
    [void]$sb.AppendLine('    {')

    for ($i = 0; $i -lt $methods.Count; $i++) {
        $m = $methods[$i]
        $modifiers = if ($m.IsAsync) { 'async ' } else { '' }
        $awaitKw   = if ($m.IsAsync) { 'await ' } else { '' }
        $configAwait = if ($m.IsAsync) { '.ConfigureAwait(false)' } else { '' }

        [void]$sb.AppendLine('        [EditorBrowsable(EditorBrowsableState.Never)]')
        [void]$sb.AppendLine("        public virtual $modifiers$($m.Return) $($m.Name)($($m.NewParams))")
        [void]$sb.AppendLine('        {')
        [void]$sb.AppendLine("            return $awaitKw$($m.Name)($($m.Args))$configAwait;")
        [void]$sb.AppendLine('        }')
        # Add separating blank line between methods, but NOT after the last method
        if ($i -lt ($methods.Count - 1)) {
            [void]$sb.AppendLine('')
        }
    }

    [void]$sb.AppendLine('    }')
    [void]$sb.AppendLine('}')

    $outPath = Join-Path $CustomRoot ($className + '.cs')
    [System.IO.File]::WriteAllText($outPath, $sb.ToString())
    $filesWritten += $outPath
    $processedFiles++
}

Write-Host "Generated $processedFiles back-compat ETag overload files:"
$filesWritten | ForEach-Object { Write-Host "  $_" }

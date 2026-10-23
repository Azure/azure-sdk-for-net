# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

#requires -Version 7.5

[CmdletBinding()]
param(
    [string] $EnvFile = (Join-Path (Split-Path -Parent $PSScriptRoot) '.env')
)

$variables = @{}
$lineNumber = 0
foreach ($line in Get-Content -LiteralPath $EnvFile -ErrorAction Stop) {
    $lineNumber++
    $line = $line.Trim()
    if (-not $line -or $line.StartsWith('#')) {
        continue
    }
    if ($line -notmatch '^([A-Za-z_][A-Za-z0-9_]*)\s*=(.*)$') {
        throw "Invalid assignment at line $lineNumber in '$EnvFile'. Expected NAME=value."
    }
    $name = $Matches[1]
    $value = $Matches[2].Trim()
    if ($variables.ContainsKey($name)) {
        throw "Duplicate variable '$name' at line $lineNumber."
    }
    if ($value.StartsWith('"') -or $value.StartsWith("'")) {
        if ($value.Length -lt 2 -or $value[-1] -ne $value[0]) {
            throw "Unmatched quote at line $lineNumber."
        }
        $value = $value.Substring(1, $value.Length - 2)
    }
    $variables[$name] = $value
}

foreach ($name in $variables.Keys) {
    [Environment]::SetEnvironmentVariable($name, $variables[$name], 'Process')
}
Write-Host "Loaded $($variables.Count) environment variables into the current process."

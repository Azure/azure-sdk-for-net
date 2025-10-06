#!/usr/bin/env pwsh
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

param(
    [Parameter(Mandatory=$true)]
    [string]$FilePath
)

if (Test-Path $FilePath) {
    $content = Get-Content -Path $FilePath -Raw
    # Replace CRLF with LF
    $content = $content -replace "`r`n", "`n"
    # Replace any remaining CR with LF
    $content = $content -replace "`r", "`n"
    # Write back without adding extra newline
    Set-Content -Path $FilePath -Value $content -NoNewline
}

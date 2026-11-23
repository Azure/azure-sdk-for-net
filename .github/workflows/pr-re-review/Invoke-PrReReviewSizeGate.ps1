#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param(
    # About the largest read set a replay has finished (#63806, 668,320 characters). Raise it only after replays of
    # larger pull requests finish; the largest ones don't fit in one run's context.
    [long]$MaxCharacters = 700000
)

$ErrorActionPreference = 'Stop'
if (!$env:GITHUB_OUTPUT) {
    throw 'Missing GITHUB_OUTPUT.'
}

# Measure with the exporter itself, so the limit applies to exactly what the agent would have to read.
$root = Join-Path ([IO.Path]::GetTempPath()) "pr-re-review-size-$([guid]::NewGuid())"
$env:REVIEW_INPUT_DIR = Join-Path $root 'input'
$env:REVIEW_INPUT_MARKERS = Join-Path $root 'markers' 'markers.json'
try {
    & (Join-Path $PSScriptRoot 'Invoke-PrReReviewInputExport.ps1')
    $readSet = (ConvertFrom-Json ([IO.File]::ReadAllText((Join-Path $env:REVIEW_INPUT_DIR 'files.json')))).readSet
} finally {
    Remove-Item -LiteralPath $root -Recurse -Force -ErrorAction SilentlyContinue
}
if ($null -eq $readSet.characters) {
    throw "The exporter did not report the read set's size."
}

$characters = [long]$readSet.characters
$withinCap = $characters -le $MaxCharacters
Add-Content -LiteralPath $env:GITHUB_OUTPUT -Value "characters=$characters", "within_cap=$("$withinCap".ToLowerInvariant())"
$size = [string]::Format([cultureinfo]::InvariantCulture, '{0:N0} characters, against a limit of {1:N0}', $characters, $MaxCharacters)
if ($withinCap) {
    Write-Host "The re-review's read set is $size."
} else {
    $message = "Skipping the re-review: its read set is $size, too large for one run."
    Write-Host "::notice::$message"
    if ($env:GITHUB_STEP_SUMMARY) {
        Add-Content -LiteralPath $env:GITHUB_STEP_SUMMARY -Value $message
    }
}

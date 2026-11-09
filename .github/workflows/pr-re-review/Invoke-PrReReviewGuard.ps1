#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1')

if (!$env:AGENT_OUTPUT) {
    throw 'Missing AGENT_OUTPUT.'
}
$output = ConvertFrom-PrReReviewJson ([IO.File]::ReadAllText($env:AGENT_OUTPUT))
Write-Host (Assert-PrReReviewOutput -AgentOutput $output)

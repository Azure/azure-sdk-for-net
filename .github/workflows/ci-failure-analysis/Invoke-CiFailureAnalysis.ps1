#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [ValidateSet('Prepare', 'BeginAnalysis', 'GuardOutput', 'Finalize', IgnoreCase = $false)]
    [string]$Action
)

$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'CiFailureAnalysis.psm1')
$context = Get-CiContext

if ($Action -cne 'Prepare') {
    if (!$env:ANALYSIS_CONTEXT) {
        throw 'Missing ANALYSIS_CONTEXT.'
    }
    $prepared = ConvertFrom-CiJson $env:ANALYSIS_CONTEXT
    if ($prepared -isnot [System.Collections.IDictionary]) {
        throw 'Invalid ANALYSIS_CONTEXT.'
    }
}

switch -CaseSensitive ($Action) {
    'Prepare' {
        $null = Initialize-CiFailureAnalysis -Context $context
    }
    'BeginAnalysis' {
        $null = Start-CiFailureAnalysis -Context $context -Prepared $prepared
    }
    'GuardOutput' {
        if (!$env:AGENT_OUTPUT) {
            throw 'Missing AGENT_OUTPUT.'
        }
        $output = ConvertFrom-CiJson ([IO.File]::ReadAllText($env:AGENT_OUTPUT))
        $result = Protect-CiAnalysisOutput -Context $context -Prepared $prepared -AgentOutput $output
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-CiJson $result.agentOutput), [Text.UTF8Encoding]::new($false))
    }
    'Finalize' {
        if (@('success', 'failure', 'cancelled', 'skipped') -cnotcontains $env:ANALYSIS_RESULT) {
            throw 'Invalid ANALYSIS_RESULT.'
        }
        Complete-CiFailureAnalysis -Context $context -Prepared $prepared -JobResults @{ analyze = $env:ANALYSIS_RESULT }
    }
}

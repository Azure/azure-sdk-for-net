#Requires -Version 7.5
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1') -Force
    function Write-ToolResult([string]$Path, [string]$Content) {
        $event = @{type = 'tool.execution_complete'; data = @{success = $true; result = @{content = $Content}}}
        [IO.File]::WriteAllText($Path, ((ConvertTo-Json $event -Depth 10 -Compress) + "`n"))
    }
}

Describe 'Downloaded Copilot agent artifact read evidence' {
    BeforeEach {
        $root = Join-Path $TestDrive ([guid]::NewGuid())
        $null = [IO.Directory]::CreateDirectory($root)
        $script:SessionDirectory = Join-Path $root 'sandbox/agent/logs/copilot-session-state'
        $null = [IO.Directory]::CreateDirectory((Join-Path $script:SessionDirectory '93547d02-0aa6-4623-8e9b-cea75a59fd0b'))
        $null = [IO.Directory]::CreateDirectory((Join-Path $script:SessionDirectory '150547d0-41c5-4765-a195-0a1596cafed6'))
        [IO.File]::WriteAllText((Join-Path $root 'agent-stdio.log'), "Human-readable console output`nRead patch 1`n")
        $script:MarkersPath = Join-Path $root 'markers.json'
        $script:ApiPath = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs'
        $script:Expected = @{
            Scope = 'api'; AnalyzedHeadSha = 'a' * 40; HeadSha = 'a' * 40; ChangedFiles = 1; ChangedApiFiles = 1
            ApiFilePaths = @($script:ApiPath); InlineTargets = @()
        }
        $markers = @{scope = 'api'; headSha = 'a' * 40; files = @(@{path = $script:ApiPath; marker = '0123456789abcdef'; chunks = @(@{content = 'Exact exported chunk one'}, @{content = 'Exact exported chunk two'})})}
        [IO.File]::WriteAllText($script:MarkersPath, (ConvertTo-Json $markers -Depth 10))
        $script:Output = @{errors = @(); items = @(@{type = 'submit_pull_request_review'; event = 'COMMENT'; body = 'API coverage: 1/1 API files reviewed'})}
    }
    It 'uses the actual session-state layout and considers all session event logs' {
        Write-ToolResult (Join-Path $script:SessionDirectory '93547d02-0aa6-4623-8e9b-cea75a59fd0b/events.jsonl') 'Exact exported chunk one'
        Write-ToolResult (Join-Path $script:SessionDirectory '150547d0-41c5-4765-a195-0a1596cafed6/events.jsonl') 'Exact exported chunk two'
        { Assert-PrReReviewReadCoverage $script:Output $script:MarkersPath $script:SessionDirectory -Expected $script:Expected } | Should -Not -Throw
    }
    It 'fails closed when the session-state directory contains no event logs' {
        { Assert-PrReReviewReadCoverage $script:Output $script:MarkersPath $script:SessionDirectory -Expected $script:Expected } | Should -Throw '*event*'
    }
    It 'rejects incomplete content in event logs even if the console log exists' {
        Write-ToolResult (Join-Path $script:SessionDirectory '93547d02-0aa6-4623-8e9b-cea75a59fd0b/events.jsonl') 'Exact exported chunk one'
        Write-ToolResult (Join-Path $script:SessionDirectory '150547d0-41c5-4765-a195-0a1596cafed6/events.jsonl') 'Exact exported chunk'
        { Assert-PrReReviewReadCoverage $script:Output $script:MarkersPath $script:SessionDirectory -Expected $script:Expected } | Should -Throw '*missing*'
    }
}

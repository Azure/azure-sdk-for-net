#Requires -Version 7.5
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewInput.psm1') -Force
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1') -Force
}

Describe 'API capture, read evidence and publication guard integration' {
    BeforeEach {
        $script:OldEnvironment = @{}
        foreach ($name in 'GITHUB_REPOSITORY', 'GH_TOKEN', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'PR_UPDATED_AT', 'REVIEW_INPUT_DIR', 'REVIEW_INPUT_MARKERS', 'AGENT_OUTPUT', 'AGENT_SESSION_LOG', 'GITHUB_OUTPUT', 'GITHUB_STEP_SUMMARY') {
            $script:OldEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
        }
        $root = Join-Path $TestDrive ([guid]::NewGuid())
        $null = [IO.Directory]::CreateDirectory($root)
        $env:GITHUB_REPOSITORY = 'Azure/azure-sdk-for-net'
        $env:GH_TOKEN = 'synthetic-only'
        $env:PR_NUMBER = '123'
        $env:PR_HEAD_SHA = 'a' * 40
        $env:PR_BASE_SHA = 'b' * 40
        $env:PR_UPDATED_AT = '2026-01-01T00:00:00Z'
        $env:REVIEW_INPUT_DIR = Join-Path $root 'input'
        $env:REVIEW_INPUT_MARKERS = Join-Path $root 'private/markers.json'
        $env:AGENT_OUTPUT = Join-Path $root 'output.json'
        $env:AGENT_SESSION_LOG = Join-Path $root 'session.jsonl'
        $env:GITHUB_OUTPUT = $null
        $env:GITHUB_STEP_SUMMARY = $null
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi { throw 'Unexpected network request in offline integration test.' }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/pulls/123' } {
            ConvertTo-Json -Compress @{changed_files = 3; head = @{sha = $env:PR_HEAD_SHA}; base = @{sha = $env:PR_BASE_SHA}}
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            $files = @(
                @{filename = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs'; status = 'modified'; patch = "@@ -1 +1 @@`n-old`n+new"; additions = 1; deletions = 1}
                @{filename = 'sdk/widgets/Azure.Widgets/src/Generated/Widget.cs'; status = 'modified'; patch = "@@ -10 +10 @@`n-old`n+new"; additions = 1; deletions = 1}
                @{filename = '.github/workflows/unrelated.lock.yml'; status = 'modified'; patch = ('large lock text ' * 10000); additions = 1; deletions = 1}
            )
            ConvertTo-Json -InputObject (,$files) -Depth 6 -Compress
        }
        & (Join-Path $PSScriptRoot 'Invoke-PrReReviewInputExport.ps1')
        $markers = Get-Content $env:REVIEW_INPUT_MARKERS -Raw | ConvertFrom-Json
        $events = foreach ($file in $markers.files) {
            foreach ($chunk in $file.chunks) {
                ConvertTo-Json -Depth 10 -Compress @{type = 'tool.execution_complete'; data = @{success = $true; result = @{content = $chunk.content}}}
            }
        }
        [IO.File]::WriteAllText($env:AGENT_SESSION_LOG, (($events -join "`n") + "`n"))
        $script:Items = @(
            @{type = 'create_pull_request_review_comment'; body = 'Finding'; path = 'sdk/widgets/Azure.Widgets/src/Generated/Widget.cs'; line = 10; pull_request_number = 123}
            @{type = 'submit_pull_request_review'; event = 'COMMENT'; body = 'API coverage: 1/1 API files reviewed'; pull_request_number = 123}
        )
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json -Depth 10 -Compress @{errors = @(); items = $script:Items}))
    }
    AfterEach {
        foreach ($name in $script:OldEnvironment.Keys) { [Environment]::SetEnvironmentVariable($name, $script:OldEnvironment[$name]) }
    }
    It 'accepts a source finding against the real API selector, marker and changed-line contracts' {
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewGuard.ps1') -ApiOnly } | Should -Not -Throw
    }
    It 'rejects a line outside the actual changed source diff, even when the API file was read' {
        $script:Items[0].line = 11
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json -Depth 10 -Compress @{errors = @(); items = $script:Items}))
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewGuard.ps1') -ApiOnly } | Should -Throw '*not in the available source diff*'
    }
    It 'rejects publication when the API read evidence is missing' {
        [IO.File]::WriteAllText($env:AGENT_SESSION_LOG, '')
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewGuard.ps1') -ApiOnly } | Should -Throw '*missing*'
    }
}

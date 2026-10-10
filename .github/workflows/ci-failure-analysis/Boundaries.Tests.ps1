#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'CiFailureAnalysis.psm1')
    . (Join-Path $PSScriptRoot 'TestHelpers.ps1')
    $script:Entry = Join-Path $PSScriptRoot 'Invoke-CiFailureAnalysis.ps1'
}

Describe 'PowerShell runtime boundaries' -Tag 'Boundary' {
    BeforeEach {
        $script:Fixture = New-CiFixture $TestDrive
        $script:PreviousEnvironment = Set-CiFixtureEnvironment $Fixture
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis {
            param($Uri, $Method, $Headers, $Body, $ContentType, $MaximumRedirection)
            Invoke-FakeCiRequest $Fixture.State $Uri $Method $Headers $Body $ContentType $MaximumRedirection
        }
    }

    AfterEach {
        Restore-TestEnvironment $PreviousEnvironment
    }

    It 'preserves exact timestamp <Timestamp> through the entry, REST, output file and report' -ForEach @(
        @{ Timestamp = '2026-09-10T18:00:00Z' }
        @{ Timestamp = '2026-09-10T18:00:00.000Z' }
        @{ Timestamp = '2026-09-10T18:00:00.1234567890Z' }
    ) {
        $Fixture.Context.payload.check_run.completed_at = $Timestamp
        $Fixture.State.check.completed_at = $Timestamp
        Write-TestJson $Fixture.EventPath $Fixture.Context.payload
        & $Entry -Action Prepare
        $outputs = Get-CiTestOutputs $Fixture
        $prepared = ConvertFrom-CiJson $outputs.analysis_context
        $prepared.completedAt | Should -BeOfType [string]
        $prepared.completedAt | Should -BeExactly $Timestamp
        $outputs.completed_at | Should -BeExactly $Timestamp
        $Fixture.State.claims[0].external_id | Should -BeExactly "ci-failure-analysis:789:42:$('a' * 40):123:$Timestamp"
        $env:ANALYSIS_CONTEXT = $outputs.analysis_context
        & $Entry -Action BeginAnalysis
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'true'
        Write-TestJson $Fixture.AgentOutputPath (New-CiAgentOutput)
        & $Entry -Action GuardOutput
        $json = ConvertFrom-CiJson ([IO.File]::ReadAllText($Fixture.AgentOutputPath))
        $json.items[0].body.EndsWith(":$Timestamp -->", [StringComparison]::Ordinal) | Should -BeTrue
    }

    It 'does not normalize timestamps while resolving and revalidating fallback PRs' {
        $Fixture.Context.payload.check_run.pull_requests = @()
        $Fixture.State.prs[0].updated_at = '2026-09-10T18:00:00.000Z'
        $pr = Copy-TestJson $Fixture.State.prs[0]
        $pr.number = 43
        $pr.updated_at = '2026-09-10T18:00:00Z'
        $Fixture.State.prs.Add($pr)
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).prNumber | Should -Be 43
    }

    It 'preserves JSON numeric and Boolean output types and UTF-8 without BOM' {
        & $Entry -Action Prepare
        $prepared = ConvertFrom-CiJson (Get-CiTestOutputs $Fixture).analysis_context
        $prepared.eligible | Should -BeOfType [bool]
        foreach ($field in @('prNumber', 'claimId', 'workflowRunId', 'workflowRunAttempt')) {
            $prepared[$field] | Should -BeOfType [long]
        }
        @($prepared.Keys | Sort-Object) | Should -Be @('claimId', 'completedAt', 'eligible', 'headSha', 'prNumber', 'workflowRunAttempt', 'workflowRunId')
        $bytes = [IO.File]::ReadAllBytes($Fixture.OutputPath)
        [Convert]::ToHexString($bytes[0..2]) | Should -Not -BeExactly 'EFBBBF'
        $Fixture.State.claims[0].details_url | Should -BeExactly 'https://github.com/Azure/azure-sdk-for-net/actions/runs/1000/attempts/1'
    }

    It 'preserves singleton and empty JSON arrays without enumeration' {
        foreach ($json in @('[]', '[1]')) {
            $value = ConvertFrom-CiJson $json
            ($value -is [array]) | Should -BeTrue
            ConvertTo-CiJson $value | Should -BeExactly $json
        }
    }

    It 'preserves other safe output items, metadata, Unicode and the exact report header' {
        $prepared = New-CiPrepared $Fixture
        $output = New-CiAgentOutput
        $output['metadata'] = @{ timestamp = '2026-09-10T18:00:00.000Z'; text = '➡️ résumé — 検証' }
        $output.items += @(
            @{ type = 'missing_data'; message = 'No further data'; details = @('a', 'b') }
            @{ type = 'missing_tool'; tool = 'optional' }
            @{ type = 'noop'; message = 'Other checks unchanged' }
        )
        $original = ConvertTo-CiJson $output
        Write-TestJson $Fixture.AgentOutputPath $output
        $env:ANALYSIS_CONTEXT = ConvertTo-CiJson $prepared
        & $Entry -Action GuardOutput
        $bytes = [IO.File]::ReadAllBytes($Fixture.AgentOutputPath)
        [Convert]::ToHexString($bytes[0..2]) | Should -Not -BeExactly 'EFBBBF'
        $actual = ConvertFrom-CiJson ([Text.Encoding]::UTF8.GetString($bytes))
        $actual.items.Count | Should -Be 4
        ConvertTo-CiJson $actual.metadata | Should -BeExactly (ConvertTo-CiJson $output.metadata)
        ConvertTo-CiJson $actual.items[1..3] | Should -BeExactly (ConvertTo-CiJson $output.items[1..3])
        $actual.items[0].body | Should -BeExactly ($output.items[0].body + "`n`n<!-- ci-failure-analysis:789:42:$('a' * 40):123:2026-09-10T18:00:00Z -->")
        ConvertTo-CiJson $output | Should -BeExactly $original
    }

    It 'preserves JSON metadata whose names overlap dictionary members' {
        $prepared = New-CiPrepared $Fixture
        $output = ConvertFrom-CiJson '{"Keys":"top-level metadata","Count":7,"items":[{"type":"add_comment","Keys":"item metadata","body":"## 🔍 CI Failure Analysis for PR #42\n\nActual error."}]}'
        $result = Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput $output
        $result.agentOutput['Keys'] | Should -BeExactly 'top-level metadata'
        $result.agentOutput['Count'] | Should -Be 7
        $result.agentOutput['items'][0]['Keys'] | Should -BeExactly 'item metadata'
    }

    It 'rejects event JSON property name casing instead of coercing it' {
        $Fixture.Context.payload.check_run = ConvertFrom-CiJson (
            (ConvertTo-CiJson $Fixture.Context.payload.check_run).Replace('"id":', '"ID":'))
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*Invalid CI check run ID*'
        $Fixture.State.claims.Count | Should -Be 0
    }

    It 'rejects output JSON property name casing instead of coercing it' {
        $prepared = New-CiPrepared $Fixture
        $output = ConvertFrom-CiJson '{"items":[{"TYPE":"add_comment","body":"## 🔍 CI Failure Analysis for PR #42\n\nActual error."}]}'
        { Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput $output } |
            Should -Throw '*Unexpected CI analysis output item*'
    }

    It 'rejects malformed numeric ID <Label> before contacting GitHub' -ForEach @(
        @{ Label = 'numeric string'; Value = '123' }
        @{ Label = 'Boolean'; Value = $true }
        @{ Label = 'zero'; Value = 0 }
        @{ Label = 'negative'; Value = -1 }
        @{ Label = 'fractional'; Value = 1.5 }
        @{ Label = 'unsafe integer'; Value = 9007199254740992 }
        @{ Label = 'null'; Value = $null }
    ) {
        $Fixture.Context.payload.check_run.id = $Value
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*Invalid CI check run ID*'
        Should -Invoke Invoke-WebRequest -ModuleName CiFailureAnalysis -Times 0 -Exactly
    }

    It 'does not coerce malformed <Label> into an eligible PR or current check' -ForEach @(
        @{ Label = 'draft string'; Change = { param($f) $f.State.prs[0].draft = 'false' } }
        @{ Label = 'draft number'; Change = { param($f) $f.State.prs[0].draft = 0 } }
        @{ Label = 'missing draft'; Change = { param($f) $f.State.prs[0].Remove('draft') } }
        @{ Label = 'base ID string'; Change = { param($f) $f.State.prs[0].base.repo.id = '789' } }
        @{ Label = 'check ID string'; Change = { param($f) $f.State.check.id = '123' } }
        @{ Label = 'PR state casing'; Change = { param($f) $f.State.prs[0].state = 'OPEN' } }
        @{ Label = 'check state casing'; Change = { param($f) $f.State.check.status = 'COMPLETED' } }
        @{ Label = 'check name casing'; Change = { param($f) $f.State.check.name = 'Net - pullrequest' } }
        @{ Label = 'check conclusion casing'; Change = { param($f) $f.State.check.conclusion = 'FAILURE' } }
    ) {
        & $Change $Fixture
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeFalse
        $Fixture.State.claims.Count | Should -Be 0
    }

    It 'rejects malformed <Label> in caller context' -ForEach @(
        @{ Label = 'PR number'; Field = 'prNumber'; Value = '42' }
        @{ Label = 'claim ID'; Field = 'claimId'; Value = $true }
        @{ Label = 'workflow run'; Field = 'workflowRunId'; Value = '1000' }
        @{ Label = 'workflow attempt'; Field = 'workflowRunAttempt'; Value = '1' }
    ) {
        $prepared = New-CiPrepared $Fixture
        $prepared[$Field] = $Value
        { Start-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared } | Should -Throw
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
    }

    It 'rejects malformed repository and associated PR IDs' {
        $Fixture.Context.payload.repository.id = '789'
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*Invalid repository ID*'
        $Fixture.Context.payload.repository.id = 789
        $Fixture.Context.payload.check_run.pull_requests[0].number = $true
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*Invalid pull request number*'
    }

    It 'does not suppress analysis for <Label>' -ForEach @(
        @{ Label = 'bot login casing'; Change = { param($c) $c.user.login = 'GitHub-actions[bot]' } }
        @{ Label = 'bot type casing'; Change = { param($c) $c.user.type = 'bot' } }
        @{ Label = 'a user impersonating the login'; Change = { param($c) $c.user.type = 'User' } }
        @{ Label = 'header casing'; Change = { param($c) $c.body = $c.body.Replace('CI Failure Analysis', 'CI failure analysis') } }
        @{ Label = 'header not at the beginning'; Change = { param($c) $c.body = 'Intro' + $c.body } }
        @{ Label = 'a different PR header'; Change = { param($c) $c.body = $c.body.Replace('PR #42', 'PR #43') } }
        @{ Label = 'a different completion marker'; Change = { param($c) $c.body = $c.body.Replace('18:00:00Z', '19:00:00Z') } }
        @{ Label = 'a missing completion marker'; Change = { param($c) $c.body = ($c.body -split '<!--')[0] } }
    ) {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        & $Change $Fixture.State.comments[0]
        $Fixture.State.claims.Clear()
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeTrue
    }

    It 'rejects a claim whose <Field> differs by case or identity' -ForEach @(
        @{ Field = 'name'; Value = 'Azure .NET CI failure analysis' }
        @{ Field = 'head_sha'; Value = 'A' * 40 }
        @{ Field = 'external_id'; Value = 'CI-failure-analysis:789:42' }
        @{ Field = 'details_url'; Value = 'https://github.com/Azure/azure-sdk-for-net/actions/runs/1000/attempts/2' }
    ) {
        $prepared = New-CiPrepared $Fixture
        $Fixture.State.claims[0][$Field] = $Value
        { Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput (New-CiAgentOutput) } |
            Should -Throw '*does not belong*'
    }

    It 'does not retry an existing claim with status <Status>' -ForEach @(
        @{ Status = 'queued' }
        @{ Status = 'in_progress' }
        @{ Status = 'completed' }
    ) {
        $null = New-CiPrepared $Fixture
        $Fixture.State.claims[0].status = $Status
        $Fixture.State.claims[0]['conclusion'] = 'failure'
        $Fixture.Context.runId++
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeFalse
        $Fixture.State.claims.Count | Should -Be 1
    }

    It 'blocks startup when the exact bot report was published after preparation' {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        Start-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared | Should -BeFalse
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
    }

    It 'rejects publication for an inactive claim rather than rewriting the artifact' {
        $prepared = New-CiPrepared $Fixture
        $Fixture.State.claims[0].status = 'completed'
        Write-TestJson $Fixture.AgentOutputPath (New-CiAgentOutput)
        $original = [IO.File]::ReadAllText($Fixture.AgentOutputPath)
        $env:ANALYSIS_CONTEXT = ConvertTo-CiJson $prepared
        { & $Entry -Action GuardOutput } | Should -Throw '*no longer active*'
        [IO.File]::ReadAllText($Fixture.AgentOutputPath) | Should -BeExactly $original
    }

    It 'rejects malformed or unsupported safe output shapes and values' {
        $prepared = New-CiPrepared $Fixture
        foreach ($json in @(
            '{"items":{"type":"add_comment","body":"## 🔍 CI Failure Analysis for PR #42\n"}}'
            '{"items":[null]}'
            '{"items":[{"type":"ADD_COMMENT","body":"## 🔍 CI Failure Analysis for PR #42\n"}]}'
            '{"items":[{"type":"add_comment","body":42}]}'
            '{"items":[{"type":"add_comment","body":"## 🔍 CI Failure Analysis for PR #42\r\n"}]}'
            '{"items":[{"type":"add_comment","body":"## 🔍 CI Failure Analysis for PR #42"}]}'
            '{"items":[{"type":"noop","message":"Done"}]}'
            '{"items":[{"type":true}]}'
        )) {
            $output = ConvertFrom-CiJson $json
            { Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput $output } | Should -Throw
        }
    }

    It 'preserves report_incomplete even if the PR is stale or the output also contains a comment' {
        $prepared = New-CiPrepared $Fixture
        $Fixture.State.prs[0].state = 'closed'
        $output = New-CiAgentOutput
        $output.items += @{ type = 'report_incomplete'; reason = 'Required logs unavailable' }
        $result = Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput $output
        $result.disposition | Should -BeExactly 'incomplete'
        ConvertTo-CiJson $result.agentOutput | Should -BeExactly (ConvertTo-CiJson $output)
    }

    It 'marks cancellation as a failure even if a report exists' {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        { Complete-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared -JobResults @{ analyze = 'cancelled' } } |
            Should -Throw '*failed in: analyze*'
        $Fixture.State.claims[0].conclusion | Should -BeExactly 'failure'
    }

    It 'leaves an already completed claim unchanged on finalization' {
        $prepared = New-CiPrepared $Fixture
        $Fixture.State.claims[0].status = 'completed'
        $Fixture.State.claims[0]['conclusion'] = 'failure'
        Complete-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared -JobResults @{ analyze = 'success' }
        $Fixture.State.claims[0].conclusion | Should -BeExactly 'failure'
        @($Fixture.State.calls | Where-Object { $_.name -ceq 'checks.update' }).Count | Should -Be 0
    }

    It 'does not let an untrusted report make finalization successful' {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        $Fixture.State.comments[0].user.login = 'contributor'
        { Complete-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared -JobResults @{ analyze = 'success' } } |
            Should -Throw '*expected report*'
        $Fixture.State.claims[0].conclusion | Should -BeExactly 'failure'
    }

    It 'executes the actual finalizer run block successfully only after report verification' {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        Invoke-CiWorkflowStep 'ci-failure-analysis-trigger.yml' 'Complete the CI analysis check' $Fixture $prepared
        $Fixture.State.claims[0].conclusion | Should -BeExactly 'success'
    }

    It 'fails entry validation for missing or malformed runtime data' {
        { & $Entry -Action BeginAnalysis } | Should -Throw '*Missing ANALYSIS_CONTEXT*'
        $env:ANALYSIS_CONTEXT = '[]'
        { & $Entry -Action BeginAnalysis } | Should -Throw '*Invalid ANALYSIS_CONTEXT*'
        $env:ANALYSIS_CONTEXT = '{'
        { & $Entry -Action BeginAnalysis } | Should -Throw
        $env:ANALYSIS_CONTEXT = ConvertTo-CiJson (New-CiPrepared $Fixture)
        $env:ANALYSIS_RESULT = 'SUCCESS'
        { & $Entry -Action Finalize } | Should -Throw '*Invalid ANALYSIS_RESULT*'
        $env:AGENT_OUTPUT = ''
        { & $Entry -Action GuardOutput } | Should -Throw '*Missing AGENT_OUTPUT*'
    }

    It 'fails entry validation for malformed runner IDs without coercion' {
        foreach ($value in @('true', '1.5', '0', '-1', '9007199254740992', '1;malicious')) {
            $env:GITHUB_RUN_ATTEMPT = $value
            { & $Entry -Action Prepare } | Should -Throw '*Invalid workflow run attempt*'
        }
        Should -Invoke Invoke-WebRequest -ModuleName CiFailureAnalysis -Times 0 -Exactly
    }

    It 'returns exit zero and writes eligible=false for a legitimate skip in a real pwsh process' {
        $Fixture.Context.payload.check_run.conclusion = 'success'
        Write-TestJson $Fixture.EventPath $Fixture.Context.payload
        $pwsh = Join-Path $PSHOME $(if ($IsWindows) { 'pwsh.exe' } else { 'pwsh' })
        $result = Invoke-CiTestProcess $pwsh @('-NoProfile', '-NonInteractive', '-File', $Entry, '-Action', 'Prepare') @{} $TestDrive
        $result.ExitCode | Should -Be 0 -Because $result.Stderr
        $result.Stdout | Should -Match 'Skipping event'
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
    }

    It 'returns nonzero and eligible=false for invalid event data in a real pwsh process' {
        $Fixture.Context.payload.check_run.id = '123'
        Write-TestJson $Fixture.EventPath $Fixture.Context.payload
        $pwsh = Join-Path $PSHOME $(if ($IsWindows) { 'pwsh.exe' } else { 'pwsh' })
        $result = Invoke-CiTestProcess $pwsh @('-NoProfile', '-NonInteractive', '-File', $Entry, '-Action', 'Prepare') @{} $TestDrive
        $result.ExitCode | Should -Not -Be 0
        $result.Stderr | Should -Match 'Invalid CI check run ID'
        ($result.Stderr + $result.Stdout) | Should -Not -Match 'offline-test-token'
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
    }
}

Describe 'PowerShell GitHub REST adapter' -Tag 'Boundary' {
    BeforeEach {
        $script:Fixture = New-CiFixture $TestDrive
        $script:PreviousEnvironment = Set-CiFixtureEnvironment $Fixture
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis {
            param($Uri, $Method, $Headers, $Body, $ContentType, $MaximumRedirection)
            Invoke-FakeCiRequest $Fixture.State $Uri $Method $Headers $Body $ContentType $MaximumRedirection
        }
    }

    AfterEach {
        Restore-TestEnvironment $PreviousEnvironment
    }

    It 'uses the configured API base, explicit authentication, JSON bytes and no credential-bearing redirects' {
        $Fixture.Context.apiUrl = 'https://github.example.invalid/api/v3'
        $Fixture.Context.serverUrl = 'https://github.example.invalid'
        $null = New-CiPrepared $Fixture
        foreach ($call in $Fixture.State.calls) {
            $call.uri.StartsWith('https://github.example.invalid/api/v3/repos/', [StringComparison]::Ordinal) | Should -BeTrue
            $call.headers.Authorization | Should -BeExactly 'Bearer offline-test-token'
            $call.headers.Accept | Should -BeExactly 'application/vnd.github+json'
            $call.headers['X-GitHub-Api-Version'] | Should -BeExactly '2022-11-28'
            $call.maximumRedirection | Should -Be 0
        }
        $post = $Fixture.State.calls | Where-Object { $_.name -ceq 'checks.create' }
        ($post.bodyBytes -is [byte[]]) | Should -BeTrue
        $post.contentType | Should -BeExactly 'application/json; charset=utf-8'
        $post.args.status | Should -BeExactly 'in_progress'
        $post.args.head_sha | Should -BeExactly ('a' * 40)
        $Fixture.State.claims[0].details_url | Should -Match '^https://github.example.invalid/'
        $list = $Fixture.State.calls | Where-Object { $_.name -ceq 'checks.listForRef' }
        $list.uri | Should -Match 'check_name=Azure%20.NET%20CI%20Failure%20Analysis&filter=all&per_page=100'
    }

    It 'does not call GitHub without an explicit token' {
        $env:GITHUB_TOKEN = ''
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*Missing GITHUB_TOKEN*'
        Should -Invoke Invoke-WebRequest -ModuleName CiFailureAnalysis -Times 0 -Exactly
    }

    It 'follows check-run pagination before deciding whether the completion was claimed' {
        $null = New-CiPrepared $Fixture
        $script:PageCalls = 0
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis -ParameterFilter { $Uri -match '/commits/.*/check-runs' } {
            $script:PageCalls++
            if ($PageCalls -eq 1) {
                return @{
                    Content = '{"check_runs":[]}'
                    Headers = @{ Link = '<https://api.github.com/repos/Azure/azure-sdk-for-net/commits/ref/check-runs?page=2>; rel="next"' }
                }
            }
            $Uri | Should -Match '\?page=2$'
            return @{ Content = ConvertTo-CiJson @{ check_runs = $Fixture.State.claims.ToArray() }; Headers = @{} }
        }
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeFalse
        $PageCalls | Should -Be 2
        $Fixture.State.claims.Count | Should -Be 1
    }

    It 'follows PR pagination and orders all matching PRs by the original updated_at strings' {
        $Fixture.Context.payload.check_run.pull_requests = @()
        $second = Copy-TestJson $Fixture.State.prs[0]
        $second.number = 43
        $second.updated_at = '2026-09-10T19:00:00.000Z'
        $Fixture.State.prs.Add($second)
        $script:PageCalls = 0
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis -ParameterFilter { $Uri -match '/pulls\?' } {
            $script:PageCalls++
            if ($PageCalls -eq 1) {
                return @{
                    Content = ConvertTo-CiJson @($Fixture.State.prs[0])
                    Headers = @{ Link = @('<https://api.github.com/repos/Azure/azure-sdk-for-net/pulls?page=2>; rel="next"', '<https://api.github.com/repos/Azure/azure-sdk-for-net/pulls?page=2>; rel="last"') }
                }
            }
            return @{ Content = ConvertTo-CiJson @($Fixture.State.prs[1]); Headers = @{} }
        }
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).prNumber | Should -Be 43
        $PageCalls | Should -Be 2
    }

    It 'follows comment pagination before authorizing publication or marking success' {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        $script:PageCalls = 0
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis -ParameterFilter { $Uri -match '/issues/42/comments' } {
            $script:PageCalls++
            if ($Uri -notmatch 'page=2') {
                return @{
                    Content = '[]'
                    Headers = @{ Link = '<https://api.github.com/repos/Azure/azure-sdk-for-net/issues/42/comments?page=2>; rel="next"' }
                }
            }
            return @{ Content = ConvertTo-CiJson $Fixture.State.comments.ToArray(); Headers = @{} }
        }
        $result = Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput (New-CiAgentOutput)
        $result.disposition | Should -BeExactly 'duplicate'
        Complete-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared -JobResults @{ analyze = 'success' }
        $Fixture.State.claims[0].conclusion | Should -BeExactly 'success'
        $PageCalls | Should -Be 4
    }

    It 'propagates a failure on a later API page without publishing or claiming' {
        $script:PageCalls = 0
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis -ParameterFilter { $Uri -match '/issues/42/comments' } {
            $script:PageCalls++
            if ($PageCalls -eq 1) {
                return @{
                    Content = '[]'
                    Headers = @{ Link = '<https://api.github.com/repos/Azure/azure-sdk-for-net/issues/42/comments?page=2>; rel="next"' }
                }
            }
            throw 'GitHub second page unavailable'
        }
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*second page unavailable*'
        $Fixture.State.claims.Count | Should -Be 0
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
    }

    It 'rejects an off-origin pagination link before sending credentials' {
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis -ParameterFilter { $Uri -match '/issues/42/comments' } {
            return @{ Content = '[]'; Headers = @{ Link = '<https://untrusted.invalid/comments?page=2>; rel="next"' } }
        }
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*Invalid GitHub API pagination URL*'
        Should -Invoke Invoke-WebRequest -ModuleName CiFailureAnalysis -ParameterFilter { $Uri -match 'untrusted.invalid' } -Times 0 -Exactly
    }

    It 'rejects a repeating pagination link instead of looping' {
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis -ParameterFilter { $Uri -match '/issues/42/comments' } {
            return @{
                Content = '[]'
                Headers = @{ Link = '<https://api.github.com/repos/Azure/azure-sdk-for-net/issues/42/comments?page=2>; rel="next"' }
            }
        }
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*Repeated GitHub API pagination URL*'
    }

    It 'rejects malformed API collection JSON rather than treating it as empty' {
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis -ParameterFilter { $Uri -match '/commits/.*/check-runs' } {
            return @{ Content = '{"check_runs":{}}'; Headers = @{} }
        }
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*Malformed GitHub API collection*'
        $Fixture.State.claims.Count | Should -Be 0
    }

    It 'propagates malformed JSON from the REST boundary' {
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis { return @{ Content = '{'; Headers = @{} } }
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
    }

    It 'propagates check creation failures without eligible=true or retry' {
        $Fixture.State.failureOperation = 'checks.create'
        $Fixture.State.failureMessage = 'GitHub refused the claim'
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*refused the claim*'
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
        @($Fixture.State.calls | Where-Object { $_.name -ceq 'checks.create' }).Count | Should -Be 1
    }

    It 'rejects a malformed claim ID returned by GitHub' {
        Mock Invoke-WebRequest -ModuleName CiFailureAnalysis -ParameterFilter { $Method -ceq 'POST' } {
            return @{ Content = '{"id":"900"}'; Headers = @{} }
        }
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*Invalid analysis check ID*'
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
    }

    It 'propagates report-verification API failure without completing the claim as success' {
        $prepared = New-CiPrepared $Fixture
        $Fixture.State.failureOperation = 'issues.listComments'
        $Fixture.State.failureMessage = 'Comments unavailable'
        { Complete-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared -JobResults @{ analyze = 'success' } } |
            Should -Throw '*Comments unavailable*'
        $Fixture.State.claims[0].status | Should -BeExactly 'in_progress'
        @($Fixture.State.calls | Where-Object { $_.name -ceq 'checks.update' }).Count | Should -Be 0
    }
}

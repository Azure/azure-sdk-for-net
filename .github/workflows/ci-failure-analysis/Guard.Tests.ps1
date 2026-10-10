#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'CiFailureAnalysis.psm1')
    . (Join-Path $PSScriptRoot 'TestHelpers.ps1')
    $script:SuccessfulJobs = [ordered]@{ activation = 'success'; agent = 'success'; detection = 'success'; safe_outputs = 'success' }
}

Describe 'CI failure analysis original behavior' -Tag 'Original' {
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

    It '[G01] compiled backend admits a failed CI app event without requiring a repository team role' {
        $lines = Get-CiWorkflowLines 'ci-failure-analysis.lock.yml'
        $pre = Get-CiJobLines $lines 'pre_activation'
        $values = @{
            github = @{ event_name = 'check_run'; event = $Fixture.Context.payload }
            steps = @{
                check_membership = @{ outputs = @{ is_team_member = 'false' } }
                start = @{ outcome = 'success'; outputs = @{ eligible = 'true' } }
            }
            needs = @{ pre_activation = @{ outputs = @{ eligible = 'true' } } }
        }
        $values.needs.pre_activation.outputs.activated = [string](Invoke-CiWorkflowExpression (Get-CiYamlProperty $pre 'activated') $values)
        Invoke-CiWorkflowExpression (Get-CiYamlProperty (Get-CiJobLines $lines 'activation') 'if') $values | Should -BeTrue
    }

    It '[<Id>] compiled agent condition handles <Label> even with reused activation outputs' -ForEach @(
        @{ Id = 'G02'; Label = 'original attempt'; RunId = 1000; RunAttempt = 1; Expected = $true }
        @{ Id = 'G03'; Label = 'partial failed-job rerun'; RunId = 1000; RunAttempt = 2; Expected = $false }
        @{ Id = 'G04'; Label = 'another workflow run'; RunId = 1001; RunAttempt = 1; Expected = $false }
    ) {
        $prepared = New-CiPrepared $Fixture
        $values = @{
            github = @{ run_id = [string]$RunId; run_attempt = [string]$RunAttempt }
            needs = @{ activation = @{ result = 'success'; outputs = @{ daily_ai_credits_exceeded = 'false' } } }
            inputs = @{ analysis_context = ConvertTo-CiJson $prepared }
        }
        $agent = Get-CiJobLines (Get-CiWorkflowLines 'ci-failure-analysis.lock.yml') 'agent'
        Invoke-CiWorkflowExpression (Get-CiYamlProperty $agent 'if') $values | Should -Be $Expected
    }

    It '[<Id>] compiled backend rejects <Label> CI even from an alternative caller' -ForEach @(
        @{ Id = 'G05'; Label = 'pending'; Change = { param($event) $event.check_run.status = 'in_progress' } }
        @{ Id = 'G06'; Label = 'rerequested'; Change = { param($event) $event.action = 'rerequested' } }
    ) {
        & $Change $Fixture.Context.payload
        $values = @{
            github = @{ event_name = 'check_run'; event = $Fixture.Context.payload }
            needs = @{ pre_activation = @{ outputs = @{ activated = 'true'; eligible = 'true' } } }
        }
        $activation = Get-CiJobLines (Get-CiWorkflowLines 'ci-failure-analysis.lock.yml') 'activation'
        Invoke-CiWorkflowExpression (Get-CiYamlProperty $activation 'if') $values | Should -BeFalse
    }

    It '[G07] the actual trigger script claims a qualifying event through the tested helper' {
        Invoke-CiWorkflowStep 'ci-failure-analysis-trigger.yml' 'Claim the completed CI failure' $Fixture
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'true'
        $Fixture.State.claims.Count | Should -Be 1
        $Fixture.State.calls[0].headers.Authorization | Should -BeExactly 'Bearer offline-workflow-token'
    }

    It '[G08] the actual compiled publication script guards and stamps the runtime artifact' {
        $prepared = New-CiPrepared $Fixture
        Write-TestJson $Fixture.AgentOutputPath (New-CiAgentOutput)
        Invoke-CiWorkflowStep 'ci-failure-analysis.lock.yml' 'Revalidate CI identity before publishing' $Fixture $prepared
        $output = ConvertFrom-CiJson ([IO.File]::ReadAllText($Fixture.AgentOutputPath))
        $output.items[0].body | Should -Match '<!-- ci-failure-analysis:'
    }

    It '[G09] the actual compiled startup script blocks failed-job reruns before the agent' {
        $prepared = New-CiPrepared $Fixture
        $env:GITHUB_RUN_ATTEMPT = '2'
        { Invoke-CiWorkflowStep 'ci-failure-analysis.lock.yml' 'Validate the claimed analysis before starting the agent' $Fixture $prepared } |
            Should -Throw '*workflow run*'
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
    }

    It '[G10] the actual finalization script fails a failed reusable workflow instead of publishing success' {
        $prepared = New-CiPrepared $Fixture
        { Invoke-CiWorkflowStep 'ci-failure-analysis-trigger.yml' 'Complete the CI analysis check' $Fixture $prepared 'failure' } |
            Should -Throw '*failed*'
        $Fixture.State.claims[0].conclusion | Should -BeExactly 'failure'
    }

    It '[G11] repository-wide failure analysis does not require management or provisioning paths' {
        $prepared = New-CiPrepared $Fixture
        $claim = $Fixture.State.claims[0]
        $claim.status | Should -BeExactly 'in_progress'
        $claim.head_sha | Should -BeExactly ('a' * 40)
        $claim.external_id | Should -Match ':123:'
        $outputs = Get-CiTestOutputs $Fixture
        $outputs.eligible | Should -BeExactly 'true'
        $outputs.pr_number | Should -BeExactly '42'
        $outputs.head_sha | Should -BeExactly ('a' * 40)
        $outputs.completed_at | Should -BeExactly '2026-09-10T18:00:00Z'
        $json = ConvertFrom-CiJson $outputs.analysis_context
        $json.headSha | Should -BeExactly $outputs.head_sha
        $json.completedAt | Should -BeExactly $outputs.completed_at
        $prepared.workflowRunId | Should -Be $Fixture.Context.runId
        $prepared.workflowRunAttempt | Should -Be $Fixture.Context.runAttempt
        @($Fixture.State.calls | Where-Object { $_.uri -match '/files' }).Count | Should -Be 0
    }

    It '[<Id>] does not analyze <Label>' -ForEach @(
        @{ Id = 'G12'; Label = 'success'; Change = { param($f) $f.Context.payload.check_run.conclusion = 'success' } }
        @{ Id = 'G13'; Label = 'cancelled'; Change = { param($f) $f.Context.payload.check_run.conclusion = 'cancelled' } }
        @{ Id = 'G14'; Label = 'neutral'; Change = { param($f) $f.Context.payload.check_run.conclusion = 'neutral' } }
        @{ Id = 'G15'; Label = 'pending'; Change = { param($f) $f.Context.payload.check_run.status = 'in_progress' } }
        @{ Id = 'G16'; Label = 'other check'; Change = { param($f) $f.Context.payload.check_run.name = 'Build' } }
        @{ Id = 'G17'; Label = 'rerequested event'; Change = { param($f) $f.Context.payload.action = 'rerequested' } }
        @{ Id = 'G18'; Label = 'manual event'; Change = { param($f) $f.Context.eventName = 'workflow_dispatch' } }
        @{ Id = 'G19'; Label = 'workflow run event'; Change = { param($f) $f.Context.eventName = 'workflow_run' } }
    ) {
        & $Change $Fixture
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeFalse
        $Fixture.State.calls.Count | Should -Be 0
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
    }

    It '[<Id>] skips <Label> using current API data' -ForEach @(
        @{ Id = 'G20'; Label = 'draft PR'; Change = { param($f) $f.State.prs[0].draft = $true } }
        @{ Id = 'G21'; Label = 'closed PR'; Change = { param($f) $f.State.prs[0].state = 'closed' } }
        @{ Id = 'G22'; Label = 'superseded PR head'; Change = { param($f) $f.State.prs[0].head.sha = 'b' * 40 } }
        @{ Id = 'G23'; Label = 'different base repository'; Change = { param($f) $f.State.prs[0].base.repo.id = 999 } }
        @{ Id = 'G24'; Label = 'CI now successful'; Change = { param($f) $f.State.check.conclusion = 'success' } }
        @{ Id = 'G25'; Label = 'CI rerunning'; Change = { param($f) $f.State.check.status = 'in_progress' } }
        @{ Id = 'G26'; Label = 'newer CI attempt'; Change = { param($f) $f.State.check.completed_at = '2026-09-10T19:00:00Z' } }
    ) {
        & $Change $Fixture
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeFalse
        $Fixture.State.claims.Count | Should -Be 0
    }

    It '[<Id>] fails explicitly for malformed CI <Field>' -ForEach @(
        @{ Id = 'G27'; Field = 'id'; Value = '123;malicious' }
        @{ Id = 'G28'; Field = 'head_sha'; Value = '$(malicious)' }
        @{ Id = 'G29'; Field = 'completed_at'; Value = 'not-a-time' }
    ) {
        $Fixture.Context.payload.check_run[$Field] = $Value
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*Invalid*'
        $Fixture.State.claims.Count | Should -Be 0
    }

    It '[G30] resolves an unassociated Azure DevOps check to the most recently updated matching open PR' {
        $Fixture.Context.payload.check_run.pull_requests = @()
        $Fixture.State.check.pull_requests = @()
        $pr = Copy-TestJson $Fixture.State.prs[0]
        $pr.number = 43
        $pr.updated_at = '2026-09-10T19:00:00Z'
        $Fixture.State.prs.Add($pr)
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).prNumber | Should -Be 43
    }

    It '[G31] skips an unassociated check with no matching PR' {
        $Fixture.Context.payload.check_run.pull_requests = @()
        $Fixture.State.check.pull_requests = @()
        $Fixture.State.prs.Clear()
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeFalse
    }

    It '[G32] does not turn a GitHub read failure into a successful no-op' {
        $Fixture.State.failureOperation = 'checks.get'
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*GitHub unavailable*'
    }

    It '[G33] does not hide an inaccessible associated PR' {
        $Fixture.State.prs.Clear()
        { Initialize-CiFailureAnalysis -Context $Fixture.Context } | Should -Throw '*PR not found*'
    }

    It '[G34] serial duplicate deliveries and workflow reruns cannot claim the same CI attempt' {
        $null = New-CiPrepared $Fixture
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeFalse
        $Fixture.Context.runId++
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeFalse
        $Fixture.Context.runAttempt++
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeFalse
        $Fixture.State.claims.Count | Should -Be 1
    }

    It '[G35] backend startup admits only an active, current claim before any agent execution' {
        $prepared = New-CiPrepared $Fixture
        Start-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared | Should -BeTrue
        $Fixture.State.claims[0].status = 'completed'
        $Fixture.State.claims[0].conclusion = 'failure'
        Start-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared | Should -BeFalse
        (Get-CiTestOutputs $Fixture).eligible | Should -BeExactly 'false'
    }

    It '[G36] backend startup skips a head that advanced after the trigger prepared it' {
        $prepared = New-CiPrepared $Fixture
        $Fixture.State.prs[0].head.sha = 'b' * 40
        Start-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared | Should -BeFalse
    }

    It '[G37] rerunning failed jobs with reused prepare outputs cannot run the agent again' {
        $prepared = New-CiPrepared $Fixture
        $Fixture.Context.runAttempt++
        { Start-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared } | Should -Throw '*workflow run*'
    }

    It '[G38] workflow attempt identity uses GITHUB_RUN_ATTEMPT when the toolkit omits runAttempt' {
        $env:GITHUB_RUN_ATTEMPT = '3'
        $Fixture.Context.Remove('runAttempt')
        $null = New-CiPrepared $Fixture
        $Fixture.State.claims[0].details_url | Should -Match '/attempts/3$'
    }

    It '[G39] a later completed CI attempt on the same check ID gets its own identity' {
        $null = New-CiPrepared $Fixture
        $Fixture.Context.payload.check_run.completed_at = '2026-09-10T19:00:00Z'
        $Fixture.State.check.completed_at = '2026-09-10T19:00:00Z'
        $Fixture.Context.runId++
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeTrue
        $Fixture.State.claims.Count | Should -Be 2
        $Fixture.State.claims[0].external_id | Should -Not -BeExactly $Fixture.State.claims[1].external_id
    }

    It '[G40] distinct check run IDs on the same head are not conflated' {
        $null = New-CiPrepared $Fixture
        $Fixture.State.check.id++
        $Fixture.Context.payload.check_run.id = $Fixture.State.check.id
        $Fixture.Context.runId++
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeTrue
        $Fixture.State.claims[0].external_id | Should -Not -BeExactly $Fixture.State.claims[1].external_id
    }

    It '[G41] existing bot analysis survives ledger loss without another analysis' {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        $Fixture.State.claims.Clear()
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeFalse
    }

    It '[G42] a comment from an untrusted author cannot suppress analysis' {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        $Fixture.State.comments[0].user = @{ login = 'contributor'; type = 'User' }
        $Fixture.State.claims.Clear()
        (Initialize-CiFailureAnalysis -Context $Fixture.Context).eligible | Should -BeTrue
    }

    It '[G43] safe-output guard stamps a report with immutable PR, head and CI attempt identity' {
        $prepared = New-CiPrepared $Fixture
        $result = Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput (New-CiAgentOutput)
        $result.disposition | Should -BeExactly 'publish'
        $result.agentOutput.items[0].body | Should -Match '<!-- ci-failure-analysis:'
        $result.agentOutput.items[0].body | Should -Match ('a' * 40)
        $result.agentOutput.items[0].body | Should -Match '2026-09-10T18:00:00Z'
        $result.agentOutput.items[0].body.StartsWith('## 🔍 CI Failure Analysis for PR #42', [StringComparison]::Ordinal) | Should -BeTrue
    }

    It '[<Id>] safe-output guard drops stale feedback when <Label>' -ForEach @(
        @{ Id = 'G44'; Label = 'head advances'; Change = { param($f) $f.State.prs[0].head.sha = 'b' * 40 } }
        @{ Id = 'G45'; Label = 'PR closes'; Change = { param($f) $f.State.prs[0].state = 'closed' } }
        @{ Id = 'G46'; Label = 'PR becomes draft'; Change = { param($f) $f.State.prs[0].draft = $true } }
        @{ Id = 'G47'; Label = 'CI starts another attempt'; Change = { param($f) $f.State.check.status = 'in_progress' } }
        @{ Id = 'G48'; Label = 'CI completes again'; Change = { param($f) $f.State.check.completed_at = '2026-09-10T19:00:00Z' } }
    ) {
        $prepared = New-CiPrepared $Fixture
        & $Change $Fixture
        $result = Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput (New-CiAgentOutput)
        $result.disposition | Should -BeExactly 'skip'
        $result.agentOutput.items.Count | Should -Be 1
        $result.agentOutput.items[0].type | Should -BeExactly 'noop'
    }

    It '[G49] safe-output guard suppresses an already published report for the same completion' {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        $result = Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput (New-CiAgentOutput)
        $result.disposition | Should -BeExactly 'duplicate'
        $result.agentOutput.items.Count | Should -Be 1
        $result.agentOutput.items[0].type | Should -BeExactly 'noop'
    }

    It '[G50] safe-output guard rejects a claim belonging to another workflow run' {
        $prepared = New-CiPrepared $Fixture
        $Fixture.Context.runId++
        { Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput (New-CiAgentOutput) } |
            Should -Throw '*claim*'
    }

    It '[G51] safe-output guard rejects caller context from a different head or CI attempt' {
        $prepared = New-CiPrepared $Fixture
        foreach ($change in @(@{ headSha = 'b' * 40 }, @{ completedAt = '2026-09-10T19:00:00Z' })) {
            $invalid = Copy-TestJson $prepared
            foreach ($key in $change.Keys) { $invalid[$key] = $change[$key] }
            { Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $invalid -AgentOutput (New-CiAgentOutput) } |
                Should -Throw '*context*'
        }
    }

    It '[G52] safe-output guard rejects malformed, extra, wrong-PR and missing reports' {
        $prepared = New-CiPrepared $Fixture
        foreach ($output in @(
            $null
            @{}
            @{ items = @() }
            @{ items = @((New-CiAgentOutput).items[0], (New-CiAgentOutput).items[0]) }
            (New-CiAgentOutput 43)
            @{ items = @(@{ type = 'submit_pull_request_review'; body = 'Not a CI analysis' }) }
        )) {
            { Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput $output } | Should -Throw
        }
    }

    It '[G53] report_incomplete remains a failure signal rather than being replaced by a no-op' {
        $prepared = New-CiPrepared $Fixture
        $output = @{ items = @(@{ type = 'report_incomplete'; reason = 'GitHub unavailable' }) }
        $result = Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $prepared -AgentOutput $output
        ConvertTo-CiJson $result.agentOutput | Should -BeExactly (ConvertTo-CiJson $output)
        $result.disposition | Should -BeExactly 'incomplete'
    }

    It '[G54] finalizer marks success only after verifying a published bot report' {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        Complete-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared -JobResults $SuccessfulJobs
        $Fixture.State.claims[0].status | Should -BeExactly 'completed'
        $Fixture.State.claims[0].conclusion | Should -BeExactly 'success'
    }

    It '[G55] finalizer fails when a nominally successful agent produces no report' {
        $prepared = New-CiPrepared $Fixture
        { Complete-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared -JobResults $SuccessfulJobs } |
            Should -Throw '*expected report*'
        $Fixture.State.claims[0].conclusion | Should -BeExactly 'failure'
    }

    It '[<Id>] finalizer preserves <Job> failures' -ForEach @(
        @{ Id = 'G56'; Job = 'activation' }
        @{ Id = 'G57'; Job = 'agent' }
        @{ Id = 'G58'; Job = 'detection' }
        @{ Id = 'G59'; Job = 'safe_outputs' }
    ) {
        $prepared = New-CiPrepared $Fixture
        $jobs = Copy-TestJson $SuccessfulJobs
        $jobs[$Job] = 'failure'
        { Complete-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared -JobResults $jobs } | Should -Throw "*$Job*"
        $Fixture.State.claims[0].conclusion | Should -BeExactly 'failure'
    }

    It '[G60] finalizer closes stale analysis as skipped without commenting' {
        $prepared = New-CiPrepared $Fixture
        $Fixture.State.prs[0].head.sha = 'b' * 40
        Complete-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared -JobResults $SuccessfulJobs
        $Fixture.State.claims[0].conclusion | Should -BeExactly 'skipped'
    }

    It '[G61] finalizer propagates check publication errors' {
        $prepared = New-CiPrepared $Fixture
        Add-CiPublishedReport $Fixture $prepared
        $Fixture.State.failureOperation = 'checks.update'
        $Fixture.State.failureMessage = 'Check update failed'
        { Complete-CiFailureAnalysis -Context $Fixture.Context -Prepared $prepared -JobResults $SuccessfulJobs } |
            Should -Throw '*Check update failed*'
    }
}

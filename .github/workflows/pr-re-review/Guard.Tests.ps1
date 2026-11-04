#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    $script:GuardDirectory = $PSScriptRoot
    $script:RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..')).Path
    $script:Complete = 'Coverage: 64/64 threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed'

    # Terminal output of run 40400877253: it read one 50-thread page of 64, skipped Steps 2 and 3,
    # and its review still published while every job passed.
    $script:Run40400877253 = @'
{"items":[{"type":"submit_pull_request_review","body":"Re-review of head ba3cac1. I fetched only the first 50 of 64 review threads and did not check the other 14. Of those 50, 14 are unresolved and none are outdated. I did not verify those 14 against current file content, so I left them open and took no reply, resolve or reopen action on any thread. I also did not do a fresh full pass over the 32 changed files, so this review reports no new findings only because none were looked for.","event":"COMMENT"}],"errors":[]}
'@

    function New-Review {
        param([AllowNull()]$Body)

        return @{ type = 'submit_pull_request_review'; body = $Body; event = 'COMMENT' }
    }

    function New-AgentOutput {
        param([object[]]$Items)

        return @{ items = $Items; errors = @() }
    }

    function Get-YamlBlock {
        param([string[]]$Lines, [string]$Header, [int]$Indent)

        $start = [array]::IndexOf($Lines, (' ' * $Indent) + $Header)
        if ($start -lt 0) { throw "Missing '$Header' at indent $Indent." }
        $end = $start + 1
        while ($end -lt $Lines.Count -and ([string]::IsNullOrWhiteSpace($Lines[$end]) -or $Lines[$end] -cmatch "^ {$($Indent + 1)}")) { $end++ }
        if ($end -eq $start + 1) { return ,[string[]]@() }
        return ,[string[]]$Lines[($start + 1)..($end - 1)]
    }

    function Get-CompiledJob {
        $lock = [IO.File]::ReadAllLines((Join-Path $script:GuardDirectory '..' 'pr-re-review.lock.yml'))
        return ,(Get-YamlBlock (Get-YamlBlock $lock 'jobs:' 0) 'safe_outputs:' 2)
    }

    function Get-CompiledSteps {
        $steps = [System.Collections.Generic.List[object]]::new()
        foreach ($line in (Get-YamlBlock (Get-CompiledJob) 'steps:' 4)) {
            if ($line.StartsWith('      - ', [StringComparison]::Ordinal)) {
                $name = if ($line -cmatch '^      - name: (.+)$') { $Matches[1] } else { '' }
                $steps.Add([pscustomobject]@{ Name = $name; Lines = [System.Collections.Generic.List[string]]::new() })
            } elseif ($steps.Count -gt 0) {
                $steps[$steps.Count - 1].Lines.Add($line)
            }
        }
        return ,$steps.ToArray()
    }

    function Get-StepProperty {
        param($Step, [string]$Key)

        foreach ($line in $Step.Lines) {
            $match = [regex]::Match($line, "^        $([regex]::Escape($Key)):(?: (?<value>.*))?$")
            if ($match.Success) { return $match.Groups['value'].Value }
        }
        return $null
    }

    function Get-StepMapping {
        param($Step, [string]$Key)

        $mapping = [ordered]@{}
        foreach ($line in (Get-YamlBlock $Step.Lines.ToArray() "${Key}:" 8)) {
            if ($line -cmatch '^          ([A-Za-z0-9_-]+): (.*)$') { $mapping[$Matches[1]] = $Matches[2] }
        }
        return $mapping
    }
}

Describe 'Assert-PrReReviewOutput' {
    BeforeAll {
        Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1') -Force
    }

    It 'rejects run 40400877253, which reviewed 50 of 64 threads and skipped Steps 2 and 3' {
        { Assert-PrReReviewOutput (ConvertFrom-PrReReviewJson $script:Run40400877253) } |
            Should -Throw -ExpectedMessage '*exactly one Coverage line*'
    }

    It 'rejects run 40400877253 even when it states its real coverage' {
        $line = 'Coverage: 50/64 threads fetched, 0/14 unresolved threads verified, 0/32 changed files reviewed'
        { Assert-PrReReviewOutput (New-AgentOutput @(New-Review "Re-review of head ba3cac1.`n`n$line")) } |
            Should -Throw -ExpectedMessage '*incomplete*'
    }

    It 'accepts a complete coverage line written as <Label>' -ForEach @(
        @{ Label = 'plain text'; Line = 'Coverage: 64/64 threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed' }
        @{ Label = 'a bold label'; Line = '**Coverage:** 64/64 threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed' }
        @{ Label = 'inline code'; Line = '`Coverage: 64/64 threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed`' }
        @{ Label = 'a blockquote'; Line = '> Coverage: 64/64 threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed' }
        @{ Label = 'a list item'; Line = '- Coverage: 64/64 threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed' }
        @{ Label = 'a lowercase sentence'; Line = 'coverage: 64/64 threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed.' }
        @{ Label = 'a first re-review with no threads'; Line = 'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 5/5 changed files reviewed' }
    ) {
        $output = New-AgentOutput @(New-Review "Re-review of head abc1234.`r`n`r`n$Line`r`n`r`nNo new findings.")
        { Assert-PrReReviewOutput $output } | Should -Not -Throw
    }

    It 'rejects a review whose coverage line <Label>' -ForEach @(
        @{ Label = 'leaves threads unfetched'; Line = 'Coverage: 63/64 threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed'; Message = '*incomplete*' }
        @{ Label = 'leaves unresolved threads unverified'; Line = 'Coverage: 64/64 threads fetched, 13/14 unresolved threads verified, 32/32 changed files reviewed'; Message = '*incomplete*' }
        @{ Label = 'leaves changed files unreviewed'; Line = 'Coverage: 64/64 threads fetched, 14/14 unresolved threads verified, 31/32 changed files reviewed'; Message = '*incomplete*' }
        @{ Label = 'claims more unresolved threads than threads'; Line = 'Coverage: 3/3 threads fetched, 4/4 unresolved threads verified, 1/1 changed files reviewed'; Message = '*more unresolved threads*' }
        @{ Label = 'is missing a count'; Line = 'Coverage: 64/64 threads fetched, 14/14 unresolved threads verified'; Message = '*does not match*' }
        @{ Label = 'is prose'; Line = 'Coverage: all threads fetched and verified, full diff reviewed'; Message = '*does not match*' }
        @{ Label = 'keeps a placeholder'; Line = 'Coverage: <fetched>/<total> threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed'; Message = '*does not match*' }
        @{ Label = 'is buried mid-sentence'; Line = 'Re-review complete. Coverage: 64/64 threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed'; Message = '*exactly one Coverage line*' }
    ) {
        { Assert-PrReReviewOutput (New-AgentOutput @(New-Review "Re-review of head abc1234.`n`n$Line")) } |
            Should -Throw -ExpectedMessage $Message
    }

    It 'rejects a review with two coverage lines' {
        $body = "Re-review of head abc1234.`n`n$script:Complete`n$script:Complete"
        { Assert-PrReReviewOutput (New-AgentOutput @(New-Review $body)) } | Should -Throw -ExpectedMessage '*exactly one Coverage line*'
    }

    It 'rejects a review whose body is <Label>' -ForEach @(
        @{ Label = 'missing'; Body = $null }
        @{ Label = 'not text'; Body = 42 }
    ) {
        { Assert-PrReReviewOutput (New-AgentOutput @(New-Review $Body)) } | Should -Throw -ExpectedMessage '*body*'
    }

    It 'rejects a complete-looking review submitted alongside <Type>' -ForEach @(
        @{ Type = 'report_incomplete' }
        @{ Type = 'missing_tool' }
        @{ Type = 'missing_data' }
    ) {
        $output = New-AgentOutput @((New-Review "Done.`n$script:Complete"), @{ type = $Type; reason = 'Thread page 2 failed.' })
        { Assert-PrReReviewOutput $output } | Should -Throw -ExpectedMessage '*reported incomplete work*'
    }

    It 'rejects inline review comments recorded alongside <Type>' -ForEach @(
        @{ Type = 'report_incomplete' }
        @{ Type = 'missing_tool' }
        @{ Type = 'missing_data' }
    ) {
        $output = New-AgentOutput @(
            @{ type = 'create_pull_request_review_comment'; path = 'src/Client.cs'; line = 10; body = 'Finding.' }
            @{ type = $Type; reason = 'Ran out of time after 20 of 32 files.' }
        )
        { Assert-PrReReviewOutput $output } | Should -Throw -ExpectedMessage '*reported incomplete work*'
    }

    It 'lets <Type> without a review through so terminal validation fails the run' -ForEach @(
        @{ Type = 'report_incomplete' }
        @{ Type = 'missing_tool' }
        @{ Type = 'missing_data' }
    ) {
        $output = New-AgentOutput @(
            @{ type = 'reply_to_pull_request_review_comment'; comment_id = 1; body = 'Fixed in abc1234.' }
            @{ type = 'resolve_pull_request_review_thread'; thread_id = 'PRRT_1' }
            @{ type = $Type; reason = 'Ran out of time after 40 of 64 threads.' }
        )
        { Assert-PrReReviewOutput $output } | Should -Not -Throw
    }

    It 'rejects output with <Label>' -ForEach @(
        @{ Label = 'only a noop'; Types = @('noop') }
        @{ Label = 'only replies and resolutions'; Types = @('reply_to_pull_request_review_comment', 'resolve_pull_request_review_thread') }
        @{ Label = 'only inline review comments'; Types = @('create_pull_request_review_comment') }
        @{ Label = 'no items'; Types = @() }
        @{ Label = 'two reviews'; Types = @('submit_pull_request_review', 'submit_pull_request_review') }
    ) {
        $items = @(foreach ($type in $Types) { if ($type -ceq 'submit_pull_request_review') { New-Review "Done.`n$script:Complete" } else { @{ type = $type } } })
        { Assert-PrReReviewOutput (New-AgentOutput $items) } | Should -Throw -ExpectedMessage '*exactly one submit_pull_request_review*'
    }

    It 'accepts a complete review alongside inline comments and thread actions' {
        $output = New-AgentOutput @(
            @{ type = 'create_pull_request_review_comment'; path = 'src/Client.cs'; line = 10; body = 'Finding.' }
            @{ type = 'reply_to_pull_request_review_comment'; comment_id = 1; body = 'Fixed in abc1234.' }
            @{ type = 'resolve_pull_request_review_thread'; thread_id = 'PRRT_1' }
            @{ type = 'unresolve_review_thread'; comment_id = '2'; reason = 'Not addressed.' }
            (New-Review "Re-review of head abc1234.`n`n$script:Complete")
        )
        { Assert-PrReReviewOutput $output } | Should -Not -Throw
    }

    It 'rejects <Label>' -ForEach @(
        @{ Label = 'output that is not an object'; Json = '[]'; Message = '*malformed*' }
        @{ Label = 'null output'; Json = 'null'; Message = '*malformed*' }
        @{ Label = 'output without items'; Json = '{"errors":[]}'; Message = '*malformed*' }
        @{ Label = 'output with ingestion errors'; Json = '{"items":[{"type":"submit_pull_request_review","body":"Done.\nCoverage: 1/1 threads fetched, 1/1 unresolved threads verified, 1/1 changed files reviewed","event":"COMMENT"}],"errors":["reply_to_pull_request_review_comment: missing body"]}'; Message = '*ingestion*' }
        @{ Label = 'output without an errors array'; Json = '{"items":[{"type":"submit_pull_request_review","body":"Done.\nCoverage: 1/1 threads fetched, 1/1 unresolved threads verified, 1/1 changed files reviewed","event":"COMMENT"}]}'; Message = '*ingestion*' }
        @{ Label = 'an item without a type'; Json = '{"items":[{"body":"Done."}],"errors":[]}'; Message = '*invalid item*' }
        @{ Label = 'a null item'; Json = '{"items":[null],"errors":[]}'; Message = '*invalid item*' }
    ) {
        { Assert-PrReReviewOutput (ConvertFrom-PrReReviewJson $Json) } | Should -Throw -ExpectedMessage $Message
    }
}

Describe 'Invoke-PrReReviewGuard.ps1' {
    BeforeEach {
        $script:PreviousAgentOutput = $env:AGENT_OUTPUT
    }

    AfterEach {
        $env:AGENT_OUTPUT = $script:PreviousAgentOutput
    }

    It 'fails when the agent output path is missing' {
        $env:AGENT_OUTPUT = $null
        { & (Join-Path $script:GuardDirectory 'Invoke-PrReReviewGuard.ps1') } | Should -Throw -ExpectedMessage 'Missing AGENT_OUTPUT.'
    }
}

Describe 'Compiled re-review publication guard' {
    BeforeAll {
        $script:Steps = Get-CompiledSteps
        $script:StepNames = [string[]]@($script:Steps | ForEach-Object Name)

        function Get-Step {
            param([string]$Name)

            $matching = @($script:Steps | Where-Object Name -ceq $Name)
            if ($matching.Count -ne 1) { throw "Expected one '$Name' step in safe_outputs; found $($matching.Count)." }
            return $matching[0]
        }

        function Invoke-CompiledGuard {
            param([string]$AgentOutputPath)

            $guard = Get-Step 'Require complete re-review coverage before publishing'
            Get-StepProperty $guard 'shell' | Should -BeExactly 'pwsh'
            $environment = Get-StepMapping $guard 'env'
            $environment.Count | Should -Be 1
            $environment['AGENT_OUTPUT'] | Should -BeExactly '${{ steps.setup-agent-output-env.outputs.GH_AW_AGENT_OUTPUT }}'
            $previous = $env:AGENT_OUTPUT
            $env:AGENT_OUTPUT = $AgentOutputPath
            Push-Location $script:RepoRoot
            try {
                & ([scriptblock]::Create((Get-StepProperty $guard 'run')))
            } finally {
                Pop-Location
                $env:AGENT_OUTPUT = $previous
            }
        }
    }

    It 'checks out the guard from the workflow commit without persisting credentials' {
        $checkout = Get-Step 'Checkout trusted re-review publication guard'
        Get-StepProperty $checkout 'uses' | Should -BeExactly 'actions/checkout@3d3c42e5aac5ba805825da76410c181273ba90b1 # v7.0.1'
        $with = Get-StepMapping $checkout 'with'
        $with['ref'] | Should -BeExactly '${{ github.sha }}'
        $with['persist-credentials'] | Should -BeExactly 'false'
        $with['sparse-checkout'] | Should -BeExactly '.github/workflows/pr-re-review'
    }

    It 'grants the publishing job read access for that checkout' {
        $permissions = Get-YamlBlock (Get-CompiledJob) 'permissions:' 4
        $permissions | Should -Contain '      contents: read'
        $permissions | Should -Contain '      pull-requests: write'
    }

    It 'runs after the agent output is located and before anything is published' {
        $located = [array]::IndexOf($script:StepNames, 'Setup agent output environment variable')
        $checkout = [array]::IndexOf($script:StepNames, 'Checkout trusted re-review publication guard')
        $guard = [array]::IndexOf($script:StepNames, 'Require complete re-review coverage before publishing')
        $publish = [array]::IndexOf($script:StepNames, 'Process Safe Outputs')
        $located | Should -BeGreaterOrEqual 0
        $checkout | Should -BeGreaterThan $located
        $guard | Should -BeGreaterThan $checkout
        $publish | Should -BeGreaterThan $guard
    }

    It '<Name> has no condition or continue-on-error that could bypass a failed guard' -ForEach @(
        @{ Name = 'Checkout trusted re-review publication guard' }
        @{ Name = 'Require complete re-review coverage before publishing' }
        @{ Name = 'Process Safe Outputs' }
    ) {
        $step = Get-Step $Name
        Get-StepProperty $step 'if' | Should -BeNullOrEmpty
        Get-StepProperty $step 'continue-on-error' | Should -BeNullOrEmpty
    }

    It 'blocks run 40400877253 when the compiled step runs the guard' {
        $path = Join-Path $TestDrive 'agent_output.json'
        [IO.File]::WriteAllText($path, $script:Run40400877253)
        { Invoke-CompiledGuard $path } | Should -Throw -ExpectedMessage '*exactly one Coverage line*'
    }

    It 'passes a complete re-review when the compiled step runs the guard' {
        $path = Join-Path $TestDrive 'agent_output.json'
        $output = New-AgentOutput @(New-Review "Re-review of head abc1234.`n`n$script:Complete`n`nNo new findings.")
        [IO.File]::WriteAllText($path, (ConvertTo-Json -InputObject $output -Depth 10 -Compress))
        { Invoke-CompiledGuard $path } | Should -Not -Throw
    }
}

Describe 'Re-review prompt' {
    BeforeAll {
        Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1') -Force
        $script:Frontmatter, $script:PromptBody = ([IO.File]::ReadAllText((Join-Path $script:GuardDirectory '..' 'pr-re-review.md')) -split '(?m)^---\s*$', 3)[1, 2]
        $script:Step4 = [regex]::Match($script:PromptBody, '(?ms)^## Step 4\b.*?(?=^## |\z)').Value
    }

    It 'asks for the exact coverage line the guard enforces' {
        $prompt = [IO.File]::ReadAllText((Join-Path $script:GuardDirectory '..' 'pr-re-review.md'))
        $prompt.Contains((Get-PrReReviewCoverageTemplate), [StringComparison]::Ordinal) | Should -BeTrue
    }

    It 'accepts that coverage line once every placeholder is a matching count' {
        $line = (Get-PrReReviewCoverageTemplate) -replace '<fetched>|<total>', '7' -replace '<verified>|<unresolved>', '3' -replace '<reviewed>|<changed>', '12'
        { Assert-PrReReviewOutput (New-AgentOutput @(New-Review "Done.`n`n$line")) } | Should -Not -Throw
    }

    It 'reads GitHub through the MCP tools, not the unauthenticated gh CLI' {
        $script:PromptBody | Should -Not -Match '\bgh\s+(?:pr\s+(?:diff|view)|api\s+graphql)\b'
        $script:PromptBody | Should -Match '\bpull_request_read\b'
    }

    It 'pages review threads with the get_review_comments cursor' {
        $script:PromptBody | Should -Match '\bget_review_comments\b'
        $script:PromptBody | Should -Match '`after`'
    }

    It 'states the same time limit as timeout-minutes' {
        $minutes = [regex]::Match($script:Frontmatter, '(?m)^timeout-minutes:\s*(\d+)\s*$').Groups[1].Value
        $minutes | Should -Not -BeNullOrEmpty
        $stated = @([regex]::Matches($script:PromptBody, '\b(\d+)[- ]minutes?\b') | ForEach-Object { $_.Groups[1].Value })
        $stated | Should -Not -BeNullOrEmpty
        $stated | Select-Object -Unique | Should -Be $minutes
    }

    It 'reserves report_incomplete for failures that happen, not a size estimate' {
        $script:Step4 | Should -Match '\breport_incomplete\b'
        $script:Step4 | Should -Match '(?i)\bestimate\b'
        $script:Step4 | Should -Match '(?i)\blist the files you reviewed\b'
    }
}

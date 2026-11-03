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

    # Terminal output of run 41426389667 (PR #64312 at e2a7df7): its coverage line claims all 110 changed
    # files, but it read only file names, and it missed the empty CHANGELOG.md a human reviewer flagged.
    $script:Run41426389667 = @'
{"items":[{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKIo"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKHU"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKH-"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKIV"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKI-"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKIx"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKJY"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKJq"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKJ_"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKKO"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKKc"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKK7"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6xbKKs"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6x0m3j"},{"type":"resolve_pull_request_review_thread","thread_id":"PRRT_kwDOACyxMM6x0nPs"},{"type":"submit_pull_request_review","body":"Re-review of head e2a7df7.\n\nPrior threads: 15 resolved because they are addressed, 1 left open, 0 reopened.\n- Addressed:\n  - Tests were added (`tests/RecommendVmSkuTests.cs`).\n  - The naming findings were fixed. Public types now carry the `RecommendVmSku*` prefix, `ShouldInclude*` is used for the booleans, and `WeightPrecision.Int8`/`Int4` are exposed.\n  - `sdk/aiinfraoptimization/cspell.yaml` now exists.\n  - The Custom/ rename thread is resolved on the basis that the renames now come from the regenerated output; I did not re-verify the TypeSpec side.\n- Still open: the async `HttpMessage` disposal thread. It is a shared management-generator issue the author already acknowledged, and it needs a generator fix rather than a change in this PR.\n\nNew findings from the fresh pass: none.\n\nCoverage: 16/16 threads fetched, 16/16 unresolved threads verified, 110/110 changed files reviewed","event":"COMMENT"}],"errors":[]}
'@
    $script:Run41426389667Paths = @('sdk/aiinfraoptimization/Azure.ResourceManager.AIInfraOptimization/CHANGELOG.md') +
        @(1..109 | ForEach-Object { "sdk/aiinfraoptimization/Azure.ResourceManager.AIInfraOptimization/src/Generated/File$_.cs" })

    function New-ReviewInputMarkers {
        param([string[]]$Paths)

        $files = @(foreach ($path in $Paths) {
            [ordered]@{ path = $path; marker = [Convert]::ToHexString([Security.Cryptography.RandomNumberGenerator]::GetBytes(8)).ToLowerInvariant() }
        })
        $path = Join-Path $TestDrive "markers-$([guid]::NewGuid()).json"
        [IO.File]::WriteAllText($path, (ConvertTo-Json -InputObject ([ordered]@{ headSha = 'abc1234'; files = $files }) -Depth 5))
        return [pscustomobject]@{ Path = $path; Files = $files }
    }

    function New-SessionLog {
        param([object[]]$Events)

        $path = Join-Path $TestDrive "agent-session-$([guid]::NewGuid()).jsonl"
        [IO.File]::WriteAllLines($path, [string[]]@($Events | ForEach-Object { ConvertTo-Json -InputObject $_ -Depth 10 -Compress }))
        return $path
    }

    function New-ToolResult {
        param([string]$Content)

        return [ordered]@{ type = 'tool.execution_complete'; data = [ordered]@{ toolName = 'bash'; success = $true; result = [ordered]@{ content = $Content; detailedContent = $Content } } }
    }

    function New-PatchRead {
        param($File)

        return "+changed line`n# End of review input [$($File.marker)]"
    }

    # The tool log of a run that read nothing but file names, like run 41426389667.
    function New-NamesOnlySessionLog {
        return New-SessionLog @(
            (New-ToolResult "100`nsdk/aiinfraoptimization/Azure.ResourceManager.AIInfraOptimization/CHANGELOG.md added")
            (New-ToolResult 'Output too large to read at once (65.5 KB). Saved to: /tmp/1793614351891-copilot-tool-output-bf0e12.txt')
        )
    }

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
        param([string]$Name = 'safe_outputs')

        $lock = [IO.File]::ReadAllLines((Join-Path $script:GuardDirectory '..' 'pr-re-review.lock.yml'))
        return ,(Get-YamlBlock (Get-YamlBlock $lock 'jobs:' 0) "${Name}:" 2)
    }

    function Get-CompiledSteps {
        param([string]$Job = 'safe_outputs')

        $steps = [System.Collections.Generic.List[object]]::new()
        foreach ($line in (Get-YamlBlock (Get-CompiledJob $Job) 'steps:' 4)) {
            if ($line.StartsWith('      - ', [StringComparison]::Ordinal)) {
                $steps.Add([pscustomobject]@{ Name = ''; Lines = [System.Collections.Generic.List[string]]::new() })
                $line = '        ' + $line.Substring(8)
            }
            if ($steps.Count -gt 0) {
                $step = $steps[$steps.Count - 1]
                # The compiler sorts a custom step's keys, so `name:` is not always its first line.
                if (!$step.Name -and $line -cmatch '^        name: (.+)$') { $step.Name = $Matches[1] }
                $step.Lines.Add($line)
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

Describe 'Assert-PrReReviewReadCoverage' {
    BeforeAll {
        Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1') -Force
        $script:Paths = @('sdk/widgets/Azure.Widgets/CHANGELOG.md', 'sdk/widgets/Azure.Widgets/src/WidgetClient.cs', 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs')
        $script:CompleteOutput = New-AgentOutput @(New-Review "Re-review of head abc1234.`n`n$script:Complete")
    }

    It 'rejects run 41426389667, whose tool log shows none of the patches its coverage line claims' {
        $markers = New-ReviewInputMarkers $script:Run41426389667Paths
        { Assert-PrReReviewReadCoverage (ConvertFrom-PrReReviewJson $script:Run41426389667) -MarkersPath $markers.Path -SessionLogPath (New-NamesOnlySessionLog) } |
            Should -Throw -ExpectedMessage '*0 of 110*CHANGELOG.md*'
    }

    It 'accepts a review once every exported patch reached the agent in a tool result' {
        $markers = New-ReviewInputMarkers $script:Paths
        $log = New-SessionLog @(
            (New-ToolResult "$(New-PatchRead $markers.Files[0])`n$(New-PatchRead $markers.Files[1])")
            (New-ToolResult (New-PatchRead $markers.Files[2]))
        )
        { Assert-PrReReviewReadCoverage $script:CompleteOutput -MarkersPath $markers.Path -SessionLogPath $log } | Should -Not -Throw
    }

    It 'counts a patch as unread when <Label>' -ForEach @(
        @{ Label = 'its read was cut off as too large'; Event = { param($Marker) New-ToolResult 'Output too large to read at once (41.2 KB). Saved to: /tmp/1-copilot-tool-output-a.txt' } }
        @{ Label = 'only its start was read'; Event = { param($Marker) New-ToolResult "# Review input 3/3: sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs`n+public partial class WidgetClient" } }
        @{ Label = 'only the agent''s own message mentions it'; Event = { param($Marker) [ordered]@{ type = 'assistant.message'; data = [ordered]@{ content = "Reviewed every patch [$Marker]." } } } }
    ) {
        $markers = New-ReviewInputMarkers $script:Paths
        $log = New-SessionLog @(
            (New-ToolResult "$(New-PatchRead $markers.Files[0])`n$(New-PatchRead $markers.Files[1])")
            (& $Event $markers.Files[2].marker)
        )
        { Assert-PrReReviewReadCoverage $script:CompleteOutput -MarkersPath $markers.Path -SessionLogPath $log } |
            Should -Throw -ExpectedMessage '*2 of 3*Azure.Widgets.net8.0.cs*'
    }

    It 'leaves a run that submitted no review to terminal validation' {
        $markers = New-ReviewInputMarkers $script:Paths
        $output = New-AgentOutput @(@{ type = 'report_incomplete'; reason = 'Time limit close after 1 of 3 files.' })
        { Assert-PrReReviewReadCoverage $output -MarkersPath $markers.Path -SessionLogPath (New-NamesOnlySessionLog) } | Should -Not -Throw
    }

    It 'rejects a review when the <Label> is missing' -ForEach @(
        @{ Label = 'tool log'; Missing = 'log' }
        @{ Label = 'exported-patch markers'; Missing = 'markers' }
    ) {
        $markers = New-ReviewInputMarkers $script:Paths
        $markersPath = if ($Missing -eq 'markers') { Join-Path $TestDrive 'absent.json' } else { $markers.Path }
        $logPath = if ($Missing -eq 'log') { Join-Path $TestDrive 'absent.jsonl' } else { New-NamesOnlySessionLog }
        { Assert-PrReReviewReadCoverage $script:CompleteOutput -MarkersPath $markersPath -SessionLogPath $logPath } |
            Should -Throw -ExpectedMessage '*cannot verify*'
    }
}

Describe 'Invoke-PrReReviewGuard.ps1' {
    BeforeEach {
        $script:PreviousEnvironment = @{}
        foreach ($name in 'AGENT_OUTPUT', 'AGENT_SESSION_LOG', 'REVIEW_INPUT_MARKERS') {
            $script:PreviousEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
        }
    }

    AfterEach {
        foreach ($name in $script:PreviousEnvironment.Keys) {
            [Environment]::SetEnvironmentVariable($name, $script:PreviousEnvironment[$name])
        }
    }

    It 'fails when the agent output path is missing' {
        $env:AGENT_OUTPUT = $null
        { & (Join-Path $script:GuardDirectory 'Invoke-PrReReviewGuard.ps1') } | Should -Throw -ExpectedMessage 'Missing AGENT_OUTPUT.'
    }

    It 'rejects run 41426389667, whose coverage line claims 110 patches its tool log never shows' {
        $env:AGENT_OUTPUT = Join-Path $TestDrive 'agent_output.json'
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, $script:Run41426389667)
        $env:AGENT_SESSION_LOG = New-NamesOnlySessionLog
        $env:REVIEW_INPUT_MARKERS = (New-ReviewInputMarkers $script:Run41426389667Paths).Path
        { & (Join-Path $script:GuardDirectory 'Invoke-PrReReviewGuard.ps1') } | Should -Throw -ExpectedMessage '*0 of 110*'
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
            param([string]$AgentOutputPath, [string]$SessionLogPath, [string]$MarkersPath)

            $guard = Get-Step 'Require complete re-review coverage before publishing'
            Get-StepProperty $guard 'shell' | Should -BeExactly 'pwsh'
            $environment = Get-StepMapping $guard 'env'
            $environment.Count | Should -Be 3
            $environment['AGENT_OUTPUT'] | Should -BeExactly '${{ steps.setup-agent-output-env.outputs.GH_AW_AGENT_OUTPUT }}'
            $environment['AGENT_SESSION_LOG'] | Should -BeExactly '/tmp/gh-aw/agent-session.jsonl'
            $environment['REVIEW_INPUT_MARKERS'] | Should -BeExactly '${{ runner.temp }}/pr-re-review-input/markers.json'
            $values = @{ AGENT_OUTPUT = $AgentOutputPath; AGENT_SESSION_LOG = $SessionLogPath; REVIEW_INPUT_MARKERS = $MarkersPath }
            $previous = @{}
            foreach ($name in $values.Keys) {
                $previous[$name] = [Environment]::GetEnvironmentVariable($name)
                [Environment]::SetEnvironmentVariable($name, $values[$name])
            }
            Push-Location $script:RepoRoot
            try {
                & ([scriptblock]::Create((Get-StepProperty $guard 'run')))
            } finally {
                Pop-Location
                foreach ($name in $previous.Keys) { [Environment]::SetEnvironmentVariable($name, $previous[$name]) }
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

    It 'downloads the exported-patch markers the agent job uploaded' {
        $download = Get-Step 'Download exported-patch markers'
        Get-StepProperty $download 'uses' | Should -BeExactly 'actions/download-artifact@9000827ccba6bdab643e8b6fd33ac0654aef8333 # v8.0.2'
        $with = Get-StepMapping $download 'with'
        $with['name'] | Should -BeExactly 'pr-re-review-input'
        $with['path'] | Should -BeExactly '${{ runner.temp }}/pr-re-review-input'
    }

    It 'grants the publishing job read access for that checkout' {
        $permissions = Get-YamlBlock (Get-CompiledJob) 'permissions:' 4
        $permissions | Should -Contain '      contents: read'
        $permissions | Should -Contain '      pull-requests: write'
    }

    It 'runs after the agent output and markers are in place and before anything is published' {
        $located = [array]::IndexOf($script:StepNames, 'Setup agent output environment variable')
        $checkout = [array]::IndexOf($script:StepNames, 'Checkout trusted re-review publication guard')
        $markers = [array]::IndexOf($script:StepNames, 'Download exported-patch markers')
        $guard = [array]::IndexOf($script:StepNames, 'Require complete re-review coverage before publishing')
        $publish = [array]::IndexOf($script:StepNames, 'Process Safe Outputs')
        $located | Should -BeGreaterOrEqual 0
        $checkout | Should -BeGreaterThan $located
        $markers | Should -BeGreaterThan $located
        $guard | Should -BeGreaterThan $checkout
        $guard | Should -BeGreaterThan $markers
        $publish | Should -BeGreaterThan $guard
    }

    It '<Name> has no condition or continue-on-error that could bypass a failed guard' -ForEach @(
        @{ Name = 'Checkout trusted re-review publication guard' }
        @{ Name = 'Download exported-patch markers' }
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
        $markers = New-ReviewInputMarkers @('src/Client.cs')
        { Invoke-CompiledGuard $path (New-NamesOnlySessionLog) $markers.Path } | Should -Throw -ExpectedMessage '*exactly one Coverage line*'
    }

    It 'blocks run 41426389667 when the compiled step runs the guard' {
        $path = Join-Path $TestDrive 'agent_output.json'
        [IO.File]::WriteAllText($path, $script:Run41426389667)
        $markers = New-ReviewInputMarkers $script:Run41426389667Paths
        { Invoke-CompiledGuard $path (New-NamesOnlySessionLog) $markers.Path } | Should -Throw -ExpectedMessage '*0 of 110*'
    }

    It 'passes a complete re-review when the compiled step runs the guard' {
        $path = Join-Path $TestDrive 'agent_output.json'
        $output = New-AgentOutput @(New-Review "Re-review of head abc1234.`n`n$script:Complete`n`nNo new findings.")
        [IO.File]::WriteAllText($path, (ConvertTo-Json -InputObject $output -Depth 10 -Compress))
        $markers = New-ReviewInputMarkers @('src/Client.cs', 'CHANGELOG.md')
        $log = New-SessionLog @((New-ToolResult "$(New-PatchRead $markers.Files[0])`n$(New-PatchRead $markers.Files[1])"))
        { Invoke-CompiledGuard $path $log $markers.Path } | Should -Not -Throw
    }
}

Describe 'Compiled re-review input export' {
    BeforeAll {
        $script:AgentSteps = Get-CompiledSteps 'agent'
        $script:AgentStepNames = [string[]]@($script:AgentSteps | ForEach-Object Name)

        function Get-AgentStep {
            param([string]$Name)

            $matching = @($script:AgentSteps | Where-Object Name -ceq $Name)
            if ($matching.Count -ne 1) { throw "Expected one '$Name' step in agent; found $($matching.Count)." }
            return $matching[0]
        }
    }

    It 'exports from the base branch''s restored .github, then hides the markers before the agent starts' {
        $order = @(
            'Restore agent config folders from base branch'
            'Export changed-file patches for the re-review'
            'Upload exported-patch markers'
            'Remove exported-patch markers from the runner'
            'Start MCP Gateway'
            'Execute GitHub Copilot CLI'
        ) | ForEach-Object { [array]::IndexOf($script:AgentStepNames, $_) }
        $order[0] | Should -BeGreaterOrEqual 0
        for ($i = 1; $i -lt $order.Count; $i++) { $order[$i] | Should -BeGreaterThan $order[$i - 1] }
    }

    It 'writes the patches where the agent reads them and the markers where the guard downloads them' {
        $export = Get-AgentStep 'Export changed-file patches for the re-review'
        Get-StepProperty $export 'shell' | Should -BeExactly 'pwsh'
        Get-StepProperty $export 'run' | Should -BeExactly './.github/workflows/pr-re-review/Invoke-PrReReviewInputExport.ps1'
        $environment = Get-StepMapping $export 'env'
        $environment['GH_TOKEN'] | Should -BeExactly '${{ github.token }}'
        $environment['PR_NUMBER'] | Should -BeExactly '${{ github.event.pull_request.number }}'
        $environment['REVIEW_INPUT_DIR'] | Should -BeExactly '/tmp/gh-aw/pr-review-input'
        $environment['REVIEW_INPUT_MARKERS'] | Should -BeExactly '${{ runner.temp }}/pr-re-review-input/markers.json'

        $upload = Get-AgentStep 'Upload exported-patch markers'
        Get-StepProperty $upload 'uses' | Should -BeExactly 'actions/upload-artifact@cf430e030ddbb5b0abf93d22962f4752f3646cd9 # v7.0.2'
        $with = Get-StepMapping $upload 'with'
        $with['name'] | Should -BeExactly 'pr-re-review-input'
        $with['path'] | Should -BeExactly '${{ runner.temp }}/pr-re-review-input/markers.json'
        $with['if-no-files-found'] | Should -BeExactly 'error'

        Get-StepProperty (Get-AgentStep 'Remove exported-patch markers from the runner') 'run' | Should -BeExactly 'rm -rf "${RUNNER_TEMP}/pr-re-review-input"'
    }

    It '<Name> has no condition or continue-on-error that would start the agent without it' -ForEach @(
        @{ Name = 'Export changed-file patches for the re-review' }
        @{ Name = 'Upload exported-patch markers' }
        @{ Name = 'Remove exported-patch markers from the runner' }
    ) {
        $step = Get-AgentStep $Name
        Get-StepProperty $step 'if' | Should -BeNullOrEmpty
        Get-StepProperty $step 'continue-on-error' | Should -BeNullOrEmpty
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

    It 'points the agent at the patches the export step writes instead of get_files' {
        $steps = Get-CompiledSteps 'agent'
        $export = @($steps | Where-Object Name -ceq 'Export changed-file patches for the re-review')
        $export.Count | Should -Be 1
        $directory = (Get-StepMapping $export[0] 'env')['REVIEW_INPUT_DIR']
        $script:PromptBody.Contains("$directory/", [StringComparison]::Ordinal) | Should -BeTrue
        $script:PromptBody | Should -Not -Match '\bget_files\b'
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

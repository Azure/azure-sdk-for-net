#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    $script:Complete = 'Coverage: 64/64 threads fetched, 14/14 unresolved threads verified, 32/32 changed files reviewed'

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
            $marker = [Convert]::ToHexString([Security.Cryptography.RandomNumberGenerator]::GetBytes(8)).ToLowerInvariant()
            [ordered]@{ path = $path; marker = $marker; chunks = @(@{ content = "+changed line`n# End of review input [$marker]" }) }
        })
        $path = Join-Path $TestDrive "markers-$([guid]::NewGuid()).json"
        [IO.File]::WriteAllText($path, (ConvertTo-Json -InputObject ([ordered]@{ headSha = 'abc1234'; files = $files }) -Depth 10))
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

}

Describe 'Assert-PrReReviewReadCoverage' {
    BeforeAll {
        Import-Module (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'PrReReviewGuard.psm1') -Force
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

    It 'rejects an end-marker-only tool result even when the file is listed as reviewed' {
        $markers = New-ReviewInputMarkers $script:Paths
        $log = New-SessionLog @(
            (New-ToolResult "$(New-PatchRead $markers.Files[0])`n$(New-PatchRead $markers.Files[1])")
            (New-ToolResult "# End of review input [$($markers.Files[2].marker)]")
        )
        { Assert-PrReReviewReadCoverage $script:CompleteOutput -MarkersPath $markers.Path -SessionLogPath $log } |
            Should -Throw -ExpectedMessage '*2 of 3*Azure.Widgets.net8.0.cs*'
    }

    It 'does not count the text of a failed tool call as a read' {
        $markers = New-ReviewInputMarkers $script:Paths
        $failed = New-ToolResult (New-PatchRead $markers.Files[2])
        $failed.data.success = $false
        $log = New-SessionLog @(
            (New-ToolResult (New-PatchRead $markers.Files[0]))
            (New-ToolResult (New-PatchRead $markers.Files[1]))
            $failed
        )
        { Assert-PrReReviewReadCoverage $script:CompleteOutput -MarkersPath $markers.Path -SessionLogPath $log } |
            Should -Throw -ExpectedMessage '*2 of 3*Azure.Widgets.net8.0.cs*'
    }

    It 'requires every part of a large patch, even when its first and last parts were read' {
        $markers = New-ReviewInputMarkers $script:Paths
        $markers.Files[2].chunks = @(
            @{ content = 'part-one: unique start' }
            @{ content = 'part-two: omitted middle' }
            @{ content = 'part-three: unique end' }
        )
        [IO.File]::WriteAllText($markers.Path, (ConvertTo-Json -InputObject @{ headSha = 'abc1234'; files = $markers.Files } -Depth 10))
        $log = New-SessionLog @(
            (New-ToolResult (New-PatchRead $markers.Files[0]))
            (New-ToolResult (New-PatchRead $markers.Files[1]))
            (New-ToolResult 'part-one: unique start')
            (New-ToolResult 'part-three: unique end')
        )
        { Assert-PrReReviewReadCoverage $script:CompleteOutput -MarkersPath $markers.Path -SessionLogPath $log } |
            Should -Throw -ExpectedMessage '*2 of 3*Azure.Widgets.net8.0.cs*'
        $completeLog = New-SessionLog @(
            (New-ToolResult (New-PatchRead $markers.Files[0]))
            (New-ToolResult (New-PatchRead $markers.Files[1]))
            (New-ToolResult 'part-one: unique start')
            (New-ToolResult 'part-two: omitted middle')
            (New-ToolResult 'part-three: unique end')
        )
        { Assert-PrReReviewReadCoverage $script:CompleteOutput -MarkersPath $markers.Path -SessionLogPath $completeLog } | Should -Not -Throw
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

Describe 'Invoke-PrReReviewCoverageGuard.ps1' {
    BeforeEach {
        $script:PreviousEnvironment = @{}
        foreach ($envName in 'AGENT_OUTPUT', 'AGENT_SESSION_LOG', 'REVIEW_INPUT_MARKERS', 'GITHUB_REPOSITORY', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'GH_TOKEN', 'TEST_CURRENT_HEAD', 'TEST_CURRENT_BASE') {
            $script:PreviousEnvironment[$envName] = [Environment]::GetEnvironmentVariable($envName)
        }
        $env:GITHUB_REPOSITORY = 'Azure/azure-sdk-for-net'
        $env:PR_NUMBER = '1'
        $env:PR_HEAD_SHA = 'abc1234'
        $env:PR_BASE_SHA = 'base'
        $env:GH_TOKEN = 'synthetic-token'
        $env:TEST_CURRENT_HEAD = 'abc1234'
        $env:TEST_CURRENT_BASE = 'base'
        Import-Module (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'PrReReviewInput.psm1')
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi {
            ConvertTo-Json -Compress @{ head = @{ sha = $env:TEST_CURRENT_HEAD }; base = @{ sha = $env:TEST_CURRENT_BASE } }
        }
    }

    AfterEach {
        foreach ($envName in $script:PreviousEnvironment.Keys) {
            [Environment]::SetEnvironmentVariable($envName, $script:PreviousEnvironment[$envName])
        }
    }

    It 'rejects publication when the PR <Label> changed after export' -ForEach @(
        @{ Label = 'head'; CurrentHead = 'new-head'; CurrentBase = 'base' }
        @{ Label = 'base'; CurrentHead = 'abc1234'; CurrentBase = 'new-base' }
    ) {
        $env:TEST_CURRENT_HEAD = $CurrentHead
        $env:TEST_CURRENT_BASE = $CurrentBase
        $markers = New-ReviewInputMarkers @('a.cs')
        $env:REVIEW_INPUT_MARKERS = $markers.Path
        $env:AGENT_OUTPUT = Join-Path $TestDrive 'stale-review.json'
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json -InputObject (New-AgentOutput @(New-Review 'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 1/1 changed files reviewed')) -Depth 10))
        $env:AGENT_SESSION_LOG = New-SessionLog @((New-ToolResult (New-PatchRead $markers.Files[0])))
        { & (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'Invoke-PrReReviewCoverageGuard.ps1') } | Should -Throw -ExpectedMessage '*head*base*'
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 1 -Exactly -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' }
    }

    It 'blocks a stale <Type> from an incomplete run' -ForEach @(
        @{ Type = 'reply_to_pull_request_review_comment' }
        @{ Type = 'resolve_pull_request_review_thread' }
        @{ Type = 'unresolve_review_thread' }
    ) {
        $env:TEST_CURRENT_HEAD = 'new-head'
        $env:AGENT_OUTPUT = Join-Path $TestDrive 'stale-action.json'
        $output = New-AgentOutput @(@{ type = 'report_incomplete' }, @{ type = $Type })
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json -InputObject $output -Depth 10))
        { & (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'Invoke-PrReReviewCoverageGuard.ps1') } | Should -Throw -ExpectedMessage '*head*base*'
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 1 -Exactly -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' }
    }

    It 'does not query the PR when an incomplete run has no publishable action' {
        $env:AGENT_OUTPUT = Join-Path $TestDrive 'no-actions.json'
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json -InputObject (New-AgentOutput @(@{ type = 'report_incomplete' })) -Depth 10))
        { & (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'Invoke-PrReReviewCoverageGuard.ps1') } | Should -Not -Throw
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 0 -Exactly
    }

    It 'fails closed without <Name> before making a PR lookup' -ForEach @(
        @{ Name = 'GITHUB_REPOSITORY' }
        @{ Name = 'PR_NUMBER' }
        @{ Name = 'PR_HEAD_SHA' }
        @{ Name = 'PR_BASE_SHA' }
        @{ Name = 'GH_TOKEN' }
    ) {
        $markers = New-ReviewInputMarkers @('a.cs')
        $env:REVIEW_INPUT_MARKERS = $markers.Path
        $env:AGENT_OUTPUT = Join-Path $TestDrive 'missing-setting.json'
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json -InputObject (New-AgentOutput @(New-Review 'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 1/1 changed files reviewed')) -Depth 10))
        $env:AGENT_SESSION_LOG = New-SessionLog @((New-ToolResult (New-PatchRead $markers.Files[0])))
        [Environment]::SetEnvironmentVariable($Name, $null)
        { & (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'Invoke-PrReReviewCoverageGuard.ps1') } | Should -Throw -ExpectedMessage "*Missing $Name*"
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 0 -Exactly
    }

    It 'fails closed if the PR lookup fails' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi { throw 'lookup failed' }
        $markers = New-ReviewInputMarkers @('a.cs')
        $env:REVIEW_INPUT_MARKERS = $markers.Path
        $env:AGENT_OUTPUT = Join-Path $TestDrive 'lookup-failure.json'
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json -InputObject (New-AgentOutput @(New-Review 'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 1/1 changed files reviewed')) -Depth 10))
        $env:AGENT_SESSION_LOG = New-SessionLog @((New-ToolResult (New-PatchRead $markers.Files[0])))
        { & (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'Invoke-PrReReviewCoverageGuard.ps1') } | Should -Throw -ExpectedMessage '*lookup failed*'
    }

    It 'runs both output and read-coverage checks' {
        $markers = New-ReviewInputMarkers @('a.cs')
        $env:REVIEW_INPUT_MARKERS = $markers.Path
        $env:AGENT_OUTPUT = Join-Path $TestDrive 'review.json'
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json -InputObject (New-AgentOutput @(New-Review 'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 1/1 changed files reviewed')) -Depth 10))
        $env:AGENT_SESSION_LOG = New-SessionLog @((New-ToolResult (New-PatchRead $markers.Files[0])))
        { & (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'Invoke-PrReReviewCoverageGuard.ps1') } | Should -Not -Throw
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 1 -Exactly -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' }
        $env:AGENT_SESSION_LOG = New-SessionLog @((New-ToolResult "# End [$($markers.Files[0].marker)]"))
        { & (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'Invoke-PrReReviewCoverageGuard.ps1') } | Should -Throw -ExpectedMessage '*0 of 1*a.cs*'
    }
}

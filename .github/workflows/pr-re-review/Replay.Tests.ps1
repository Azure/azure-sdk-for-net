#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewInput.psm1') -Force
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1') -Force
    $script:HeadSha = 'a' * 40
    $script:BaseSha = 'b' * 40
    $script:MergeBaseSha = 'c' * 40
    $script:LaterSha = 'd' * 40
    $script:ReplayEnvironment = @(
        'GITHUB_EVENT_NAME', 'GITHUB_REPOSITORY', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'REPLAY_PULL_REQUEST', 'REPLAY_HEAD_SHA', 'REPLAY_BASE_SHA',
        'REPLAY_HISTORY_CUTOFF', 'REVIEW_INPUT_DIR', 'REVIEW_INPUT_MARKERS', 'AGENT_OUTPUT', 'AGENT_SESSION_LOG', 'REVIEW_REPLAY', 'REVIEW_REPLAY_RESULT', 'GITHUB_STEP_SUMMARY',
        'REVIEW_WORKFLOW_LOCK'
    )

    function New-WorkflowLock {
        param([string]$PublishEnvironment = "GH_AW_SAFE_OUTPUTS_STAGED: `${{ github.event_name == 'workflow_dispatch' }}")

        $path = Join-Path $TestDrive "pr-re-review-$([guid]::NewGuid()).lock.yml"
        [IO.File]::WriteAllLines($path, [string[]]@(
            'jobs:'
            '  agent:'
            '    steps:'
            '      - name: Execute GitHub Copilot CLI'
            '        env:'
            "          GH_AW_SAFE_OUTPUTS_STAGED: `${{ github.event_name == 'workflow_dispatch' }}"
            '  safe_outputs:'
            '    steps:'
            '      - name: Evaluate the replayed re-review'
            "        if: github.event_name == 'workflow_dispatch'"
            '      - name: Process Safe Outputs'
            '        env:'
            '          GH_AW_AGENT_OUTPUT: agent_output.json'
            "          $PublishEnvironment"
            '        with:'
            '          script: |'
            '            await main();'
        ))
        return $path
    }

    function New-ThreadComment {
        param([string]$Id, [string]$Created, [string]$Published = $Created)

        return @{
            author = @{ login = 'reviewer' }; body = "comment $Id"; createdAt = $Created; publishedAt = $Published
            url = "https://github.com/Azure/azure-sdk-for-net/pull/1#discussion_r$Id"; path = 'src/Client.cs'; line = 2; originalLine = 2
            pullRequestReview = @{ submittedAt = $Published }
        }
    }

    function New-ThreadsResponse {
        param([object[]]$Threads, [string]$EndCursor)

        $nodes = @(foreach ($thread in $Threads) {
            @{ id = $thread.Id; isResolved = $true; isOutdated = $false; isCollapsed = $false; comments = @{ totalCount = $thread.Comments.Count; nodes = $thread.Comments } }
        })
        $connection = @{ pageInfo = @{ hasNextPage = [bool]$EndCursor; endCursor = $EndCursor }; nodes = $nodes }
        return ConvertTo-Json -Depth 20 -Compress -InputObject @{ data = @{ repository = @{ pullRequest = @{ reviewThreads = $connection } } } }
    }

    function New-SessionLog {
        param([object[]]$Events)

        $path = Join-Path $TestDrive "agent-session-$([guid]::NewGuid()).jsonl"
        [IO.File]::WriteAllLines($path, [string[]]@($Events | ForEach-Object { ConvertTo-Json -InputObject $_ -Depth 10 -Compress }))
        return $path
    }

    function New-ToolCall {
        param([string]$Tool, [hashtable]$Arguments)

        $data = [ordered]@{ toolName = $Tool; arguments = $Arguments }
        if ($Tool -match '^(github|safeoutputs)-(.+)$') {
            $data.mcpServerName = $Matches[1]
            $data.mcpToolName = $Matches[2]
        }
        return [ordered]@{ type = 'tool.execution_start'; data = $data }
    }

    function Write-AgentOutput([string]$Coverage) {
        $review = @{ type = 'submit_pull_request_review'; event = 'COMMENT'; body = "Re-review.`n`n$Coverage" }
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json -Depth 10 -InputObject @{ items = @($review); errors = @() }))
    }
}

Describe 'Invoke-PrReReviewInputExport.ps1 replay' {
    BeforeEach {
        $script:SavedEnvironment = @{}
        foreach ($envName in $script:ReplayEnvironment) { $script:SavedEnvironment[$envName] = [Environment]::GetEnvironmentVariable($envName) }
        foreach ($envName in 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA') { [Environment]::SetEnvironmentVariable($envName, $null) }
        $root = Join-Path $TestDrive ([guid]::NewGuid())
        $env:GITHUB_EVENT_NAME = 'workflow_dispatch'
        $env:GITHUB_REPOSITORY = 'Azure/azure-sdk-for-net'
        $env:REPLAY_PULL_REQUEST = '1'
        $env:REPLAY_HEAD_SHA = $script:HeadSha
        $env:REPLAY_BASE_SHA = $script:BaseSha
        $env:REPLAY_HISTORY_CUTOFF = '2026-11-10T19:43:40Z'
        $env:REVIEW_INPUT_DIR = Join-Path $root 'input'
        $env:REVIEW_INPUT_MARKERS = Join-Path $root 'private' 'markers.json'
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi { throw "Unexpected gh api $($Arguments -join ' ')" }
    }

    AfterEach {
        foreach ($entry in $script:SavedEnvironment.GetEnumerator()) { [Environment]::SetEnvironmentVariable($entry.Key, $entry.Value) }
    }

    It 'exports the replayed commits'' diff and only the history visible at the cutoff' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains "repos/Azure/azure-sdk-for-net/compare/$('b' * 40)...$('a' * 40)?per_page=1" } {
            ConvertTo-Json -Depth 5 -Compress -InputObject @{
                merge_base_commit = @{ sha = 'c' * 40 }
                files = @(@{ filename = 'src/Client.cs'; status = 'modified'; additions = 2; deletions = 1; patch = "@@ -1 +1,2 @@`n-old`n+new`n+more" })
            }
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments[0] -ceq 'graphql' -and $Arguments -notcontains 'cursor=page2' } {
            New-ThreadsResponse -EndCursor 'page2' @(
                @{ Id = 'PRRT_before'; Comments = @((New-ThreadComment 100 '2026-11-10T15:49:00Z'), (New-ThreadComment 101 '2026-11-11T08:00:00Z')) }
                @{ Id = 'PRRT_submitted_later'; Comments = @(New-ThreadComment 102 '2026-11-10T19:00:00Z' '2026-11-10T20:00:00Z') }
            )
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments[0] -ceq 'graphql' -and $Arguments -contains 'cursor=page2' } {
            New-ThreadsResponse @(@{ Id = 'PRRT_after'; Comments = @(New-ThreadComment 103 '2026-11-11T09:00:00Z') })
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1/reviews?per_page=100' } {
            '[[{"id":1,"state":"COMMENTED","submitted_at":"2026-11-10T15:49:00Z","user":{"login":"glharper"},"body":"before"},{"id":2,"state":"COMMENTED","submitted_at":"2026-11-11T08:00:00Z","user":{"login":"m-nash"},"body":"after"},{"id":3,"state":"PENDING","user":{"login":"m-nash"},"body":"draft"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/issues/1/comments?per_page=100' } {
            '[[{"id":10,"created_at":"2026-11-10T10:00:00Z","user":{"login":"author"},"body":"before"}],[{"id":11,"created_at":"2026-11-12T10:00:00Z","user":{"login":"author"},"body":"after"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' } {
            ConvertTo-Json -Compress -InputObject @{ title = 'Title'; body = 'Body'; state = 'closed'; merged = $true; user = @{ login = 'author' }; base = @{ ref = 'main'; sha = 'f' * 40 }; head = @{ ref = 'feature'; sha = 'e' * 40 } }
        }

        & (Join-Path $PSScriptRoot 'Invoke-PrReReviewInputExport.ps1')

        $list = Get-Content (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json
        $list.headSha | Should -BeExactly $script:HeadSha
        @($list.files.path) | Should -Be @('src/Client.cs')
        $history = Join-Path $env:REVIEW_INPUT_DIR 'history'
        $pullRequest = Get-Content (Join-Path $history 'pull-request.json') -Raw | ConvertFrom-Json -AsHashtable
        $pullRequest.head.sha | Should -BeExactly $script:HeadSha
        $pullRequest.base.sha | Should -BeExactly $script:BaseSha
        $pullRequest.changed_files | Should -Be 1
        $pullRequest.state | Should -BeExactly 'open'
        $pullRequest.ContainsKey('merged') | Should -BeFalse
        $threads = Get-Content (Join-Path $history 'review-threads.json') -Raw | ConvertFrom-Json
        $threads.totalCount | Should -Be 1
        @($threads.review_threads.id) | Should -Be @('PRRT_before')
        @($threads.review_threads[0].comments.html_url) | Should -Be @('https://github.com/Azure/azure-sdk-for-net/pull/1#discussion_r100')
        @((Get-Content (Join-Path $history 'reviews.json') -Raw | ConvertFrom-Json).id) | Should -Be @(1)
        @((Get-Content (Join-Path $history 'issue-comments.json') -Raw | ConvertFrom-Json).id) | Should -Be @(10)
        $replay = Get-Content (Join-Path (Split-Path $env:REVIEW_INPUT_MARKERS) 'replay.json') -Raw | ConvertFrom-Json
        $replay.threads | Should -Be 1
        $replay.changedFiles | Should -Be 1
        $replay.mergeBaseSha | Should -BeExactly $script:MergeBaseSha
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 0 -Exactly -ParameterFilter { $Arguments -like '*/pulls/1/files*' }
    }

    It 'rejects <Setting> ''<Value>'' before calling GitHub' -ForEach @(
        @{ Setting = 'REPLAY_PULL_REQUEST'; Value = '1/../2'; Message = '*not a pull request number*' }
        @{ Setting = 'REPLAY_HEAD_SHA'; Value = 'main'; Message = '*REPLAY_HEAD_SHA*40-character*' }
        @{ Setting = 'REPLAY_BASE_SHA'; Value = 'abc1234'; Message = '*REPLAY_BASE_SHA*40-character*' }
        @{ Setting = 'REPLAY_HISTORY_CUTOFF'; Value = '2026-11-10 19:43'; Message = '*ISO 8601*' }
    ) {
        [Environment]::SetEnvironmentVariable($Setting, $Value)
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewInputExport.ps1') } | Should -Throw -ExpectedMessage $Message
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 0 -Exactly
    }

    It 'fails rather than replay a comparison GitHub may have cut off at 300 files' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/compare/*' } {
            ConvertTo-Json -Depth 5 -Compress -InputObject @{ merge_base_commit = @{ sha = 'c' * 40 }; files = @(1..300 | ForEach-Object { @{ filename = "f$_.cs"; status = 'added'; patch = '+x' } }) }
        }
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewInputExport.ps1') } | Should -Throw -ExpectedMessage '*300*'
    }
}

Describe 'Find-PrReReviewReplayContamination' {
    It 'flags <Label>' -ForEach @(
        @{ Label = 'reading the pull request through MCP'; Tool = 'github-pull_request_read'; Arguments = @{ method = 'get_review_comments'; pullNumber = 1 } }
        @{ Label = 'file contents at the default branch'; Tool = 'github-get_file_contents'; Arguments = @{ path = 'src/Client.cs' } }
        @{ Label = 'file contents at a later commit'; Tool = 'github-get_file_contents'; Arguments = @{ path = 'src/Client.cs'; ref = 'd' * 40 } }
        @{ Label = 'the MCP server run as a command'; Tool = 'bash'; Arguments = @{ command = 'github pull_request_read --method get_reviews --pullNumber 1' } }
        @{ Label = 'the pull request API'; Tool = 'bash'; Arguments = @{ command = 'curl -s https://api.github.com/repos/Azure/azure-sdk-for-net/pulls/1/comments' } }
        @{ Label = 'a branch file'; Tool = 'bash'; Arguments = @{ command = 'curl -s https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/src/Client.cs' } }
        @{ Label = 'a branch read chained after a pinned read'; Tool = 'bash'; Arguments = @{ command = "github get_file_contents --path src/A.cs --ref $('a' * 40); github get_file_contents --path src/B.cs --ref main" } }
        @{ Label = 'the pull request API chained after a pinned file'; Tool = 'bash'; Arguments = @{ command = "curl -s https://raw.githubusercontent.com/Azure/azure-sdk-for-net/$('a' * 40)/src/A.cs; curl -s https://api.github.com/repos/Azure/azure-sdk-for-net/pulls/1/comments" } }
        @{ Label = 'the pull request API chained after a shell publication'; Tool = 'bash'; Arguments = @{ command = 'safeoutputs submit_pull_request_review --event COMMENT --body "See https://github.com/Azure/azure-sdk-for-net/pull/2"; curl -s https://api.github.com/repos/Azure/azure-sdk-for-net/pulls/1/comments' } }
        @{ Label = 'the pull request API read inside a shell publication'; Tool = 'bash'; Arguments = @{ command = 'safeoutputs submit_pull_request_review --event COMMENT --body "$(curl -s https://api.github.com/repos/Azure/azure-sdk-for-net/pulls/1/comments)"' } }
        @{ Label = 'the pull request API read in a published heredoc that expands'; Tool = 'bash'; Arguments = @{ command = (@('cat > /tmp/body.md <<EOF', '$(curl -s https://api.github.com/repos/Azure/azure-sdk-for-net/pulls/1/comments)', 'EOF', 'safeoutputs submit_pull_request_review --event COMMENT --body "$(cat /tmp/body.md)"') -join "`n") } }
        @{ Label = 'a script written to a file and run'; Tool = 'bash'; Arguments = @{ command = (@('cat > /tmp/fetch.py <<''EOF''', 'import urllib.request', 'urllib.request.urlopen(''https://api.github.com/repos/Azure/azure-sdk-for-net/pulls/1/comments'')', 'EOF', 'python3 /tmp/fetch.py') -join "`n") } }
    ) {
        $log = New-SessionLog @(New-ToolCall $Tool $Arguments)
        $found = Find-PrReReviewReplayContamination -SessionLogPath $log -AllowedCommits @($script:HeadSha, $script:BaseSha, $script:MergeBaseSha)
        $found.Count | Should -Be 1
        $found[0] | Should -BeLike "$Tool *"
    }

    It 'allows reads pinned to the replayed commits, local files, and publication calls' {
        $log = New-SessionLog @(
            (New-ToolCall 'github-get_file_contents' @{ path = 'src/Client.cs'; ref = $script:HeadSha })
            (New-ToolCall 'github-get_file_contents' @{ path = 'src/Client.cs'; sha = $script:BaseSha.Substring(0, 7) })
            (New-ToolCall 'bash' @{ command = "curl -s https://raw.githubusercontent.com/Azure/azure-sdk-for-net/$($script:HeadSha)/src/Client.cs" })
            (New-ToolCall 'bash' @{ command = "github get_file_contents --path src/Client.cs --ref $($script:MergeBaseSha)" })
            (New-ToolCall 'bash' @{ command = 'cat /tmp/gh-aw/pr-review-input/history/review-threads.json' })
            (New-ToolCall 'view' @{ path = '/home/runner/work/azure-sdk-for-net/azure-sdk-for-net/.github/workflows/pr-re-review.md' })
            (New-ToolCall 'safeoutputs-submit_pull_request_review' @{ body = 'See https://github.com/Azure/azure-sdk-for-net/pull/2'; event = 'COMMENT' })
            (New-ToolCall 'bash' @{ command = 'safeoutputs submit_pull_request_review --event COMMENT --body "Fixed; see https://github.com/Azure/azure-sdk-for-net/pull/2"' })
            (New-ToolCall 'bash' @{ command = (@('safeoutputs submit_pull_request_review --event COMMENT --body "$(cat <<''EOF''', 'I don''t see a regression (see https://github.com/Azure/azure-sdk-for-net/pull/2); it''s fixed.', 'EOF', ')"') -join "`n") })
            (New-ToolCall 'bash' @{ command = (@('cat > /tmp/body.md <<''EOF''', 'See https://github.com/Azure/azure-sdk-for-net/pull/2#discussion_r1 for the earlier thread.', 'EOF', 'safeoutputs submit_pull_request_review --event COMMENT --body "$(cat /tmp/body.md)"') -join "`n") })
            (New-ToolCall 'bash' @{ command = (@('cat > /tmp/reply.md <<''EOF''', 'Fixed in https://github.com/Azure/azure-sdk-for-net/pull/2.', 'EOF') -join "`n") })
            (New-ToolCall 'bash' @{ command = 'safeoutputs reply_to_pull_request_review_comment --comment_id 1 --pull_request_number 1 --body "$(cat /tmp/reply.md)"' })
        )
        Find-PrReReviewReplayContamination -SessionLogPath $log -AllowedCommits @($script:HeadSha, $script:BaseSha, $script:MergeBaseSha) | Should -BeNullOrEmpty
    }
}

Describe 'Invoke-PrReReviewReplayGuard.ps1' {
    BeforeEach {
        $script:SavedEnvironment = @{}
        foreach ($envName in $script:ReplayEnvironment) { $script:SavedEnvironment[$envName] = [Environment]::GetEnvironmentVariable($envName) }
        $root = Join-Path $TestDrive ([guid]::NewGuid())
        [void][IO.Directory]::CreateDirectory($root)
        $env:REVIEW_REPLAY = Join-Path $root 'replay.json'
        $env:REVIEW_REPLAY_RESULT = Join-Path $root 'result' 'replay-result.json'
        $env:GITHUB_STEP_SUMMARY = Join-Path $root 'summary.md'
        [IO.File]::WriteAllText($env:REVIEW_REPLAY, (ConvertTo-Json -InputObject ([ordered]@{
            pullRequest = 1; headSha = $script:HeadSha; baseSha = $script:BaseSha; mergeBaseSha = $script:MergeBaseSha
            historyCutoff = '2026-11-10T19:43:40Z'; changedFiles = 1; threads = 2
        })))
        $marker = 'feedfacecafebeef'
        $env:REVIEW_INPUT_MARKERS = Join-Path $root 'markers.json'
        [IO.File]::WriteAllText($env:REVIEW_INPUT_MARKERS, (ConvertTo-Json -Depth 10 -InputObject @{ files = @(@{ path = 'src/Client.cs'; marker = $marker; chunks = @(@{ content = "+new`n# End of review input [$marker]" }) }) }))
        $script:PatchRead = [ordered]@{ type = 'tool.execution_complete'; data = [ordered]@{ toolName = 'bash'; success = $true; result = [ordered]@{ content = "+new`n# End of review input [$marker]" } } }
        $env:AGENT_SESSION_LOG = New-SessionLog @($script:PatchRead)
        $env:AGENT_OUTPUT = Join-Path $root 'agent_output.json'
        $env:REVIEW_WORKFLOW_LOCK = New-WorkflowLock
    }

    AfterEach {
        foreach ($entry in $script:SavedEnvironment.GetEnumerator()) { [Environment]::SetEnvironmentVariable($entry.Key, $entry.Value) }
    }

    It 'records a review whose totals <Label> the replayed history as <Outcome>, leaving it to staged safe outputs' -ForEach @(
        @{ Label = 'match'; Threads = 2; Outcome = 'would-publish' }
        @{ Label = 'differ from'; Threads = 3; Outcome = 'blocked' }
    ) {
        Write-AgentOutput "Coverage: $Threads/$Threads threads fetched, 1/1 unresolved threads verified, 1/1 changed files reviewed"
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewReplayGuard.ps1') } | Should -Not -Throw
        $result = Get-Content $env:REVIEW_REPLAY_RESULT -Raw | ConvertFrom-Json
        $result.outcome | Should -BeExactly $Outcome
        $result.coverage.passed | Should -Be ($Outcome -eq 'would-publish')
        $result.readCoverage.passed | Should -BeTrue
        $result.contaminated | Should -BeFalse
        $items = (Get-Content $env:REVIEW_REPLAY_RESULT -Raw | ConvertFrom-Json -AsHashtable).items
        $items -is [array] | Should -BeTrue
        @($items.type) | Should -Be @('submit_pull_request_review')
        Get-Content $env:GITHUB_STEP_SUMMARY -Raw | Should -Match "Outcome: \*\*$Outcome\*\*"
    }

    It 'records a run that read the current pull request as contaminated' {
        Write-AgentOutput 'Coverage: 2/2 threads fetched, 1/1 unresolved threads verified, 1/1 changed files reviewed'
        $env:AGENT_SESSION_LOG = New-SessionLog @((New-ToolCall 'github-pull_request_read' @{ method = 'get_reviews'; pullNumber = 1 }), $script:PatchRead)
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewReplayGuard.ps1') } | Should -Not -Throw
        $result = Get-Content $env:REVIEW_REPLAY_RESULT -Raw | ConvertFrom-Json
        $result.contaminated | Should -BeTrue
        @($result.contamination) | Should -HaveCount 1
    }

    It 'still records a result when the agent produced no output' {
        $env:AGENT_OUTPUT = ''
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewReplayGuard.ps1') } | Should -Not -Throw
        $result = Get-Content $env:REVIEW_REPLAY_RESULT -Raw | ConvertFrom-Json -AsHashtable
        $result.outcome | Should -BeExactly 'no-review'
        $result.items -is [array] | Should -BeTrue
        $result.items.Count | Should -Be 0
    }

    It 'records the result, then refuses to continue when <Label>' -ForEach @(
        @{ Label = 'Process Safe Outputs is not staged'; Lock = { New-WorkflowLock 'GH_AW_SAFE_OUTPUTS_HANDLER_CONFIG: "{}"' } }
        @{ Label = 'Process Safe Outputs is staged off'; Lock = { New-WorkflowLock 'GH_AW_SAFE_OUTPUTS_STAGED: "false"' } }
        @{ Label = 'the workflow lock is missing'; Lock = { Join-Path $TestDrive 'missing.lock.yml' } }
    ) {
        $env:REVIEW_WORKFLOW_LOCK = & $Lock
        Write-AgentOutput 'Coverage: 2/2 threads fetched, 1/1 unresolved threads verified, 1/1 changed files reviewed'
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewReplayGuard.ps1') } | Should -Throw -ExpectedMessage '*could publish*'
        (Get-Content $env:REVIEW_REPLAY_RESULT -Raw | ConvertFrom-Json).outcome | Should -BeExactly 'would-publish'
    }
}

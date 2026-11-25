#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    $script:Source = [IO.File]::ReadAllText((Join-Path $PSScriptRoot '..' 'pr-re-review.md'))
    $script:Lock = [IO.File]::ReadAllText((Join-Path $PSScriptRoot '..' 'pr-re-review.lock.yml'))
    $script:Head = 'a' * 40
    $script:Base = 'b' * 40

    function Get-NotificationJob {
        param([string]$Name, [string]$Text = $script:Source)

        $match = [regex]::Match($Text, "(?ms)^  $([regex]::Escape($Name)):\r?\n(.*?)(?=^  [a-z_]+:|^[^ #\r\n])")
        if (!$match.Success) { throw "Missing $Name job." }
        return $match.Groups[1].Value
    }

    function Get-NotificationScript {
        param([string]$Name = 'notify_manual_review', [string]$Text = $script:Source)

        $match = [regex]::Match((Get-NotificationJob $Name $Text), '(?m)^ {10}script: \|\r?\n((?: {12}.*\r?\n|\r?\n)+)')
        if (!$match.Success) { throw "Missing $Name script." }
        return (($match.Groups[1].Value -split '\r?\n' | ForEach-Object { if ($_.StartsWith('            ')) { $_.Substring(12) } else { $_ } }) -join "`n").TrimEnd()
    }

    function Invoke-NotificationScript {
        param([hashtable]$Options = @{})

        $job = if ($Options.completed) { 'update_manual_review' } else { 'notify_manual_review' }
        $inputJson = ConvertTo-Json -Depth 30 -Compress -InputObject @{ script = (Get-NotificationScript $job); options = $Options }
        $runner = @'
const fs = require('fs');
const vm = require('vm');
const { script, options } = JSON.parse(fs.readFileSync(0, 'utf8'));
const head = 'a'.repeat(40), base = 'b'.repeat(40);
const { oversized = false, output = { items: [{ type: 'report_incomplete' }], errors: [] }, outputTypes = 'report_incomplete', artifactFails = false, pr = { state: 'open', draft: false, head: { sha: head }, base: { sha: base } }, previous = [], failComment = false } = options;
const comments = [], updates = [], infos = [];
const env = { REVIEW_OVERSIZED: String(oversized), REVIEW_OUTPUT_TYPES: outputTypes, REVIEW_CHARACTERS: '700001', REVIEW_LIMIT: '700000', RUNNER_TEMP: '/tmp', GITHUB_SERVER_URL: 'https://github.com', GITHUB_REPOSITORY: 'Azure/azure-sdk-for-net', GITHUB_RUN_ID: '123', GITHUB_RUN_ATTEMPT: '2' };
const sandbox = {
  process: { env },
  require: name => name === 'fs' ? { readFileSync: () => { if (artifactFails) throw new Error('artifact unavailable'); return JSON.stringify(output); } } : require(name),
  context: { repo: { owner: 'Azure', repo: 'azure-sdk-for-net' }, payload: { pull_request: { number: 42, head: { sha: head }, base: { sha: base } } } },
  core: { info: message => infos.push(message), warning: message => infos.push(message) },
  github: {
    rest: {
      pulls: { get: async () => ({ data: pr }) },
      actions: { getWorkflowRunAttempt: async () => ({ data: { run_started_at: '2026-01-02T00:00:00Z' } }) },
      issues: { listComments: () => {}, createComment: async args => { if (failComment) throw new Error('comment API failed'); comments.push(args); }, updateComment: async args => updates.push(args) },
    },
    paginate: async () => previous,
  },
};
vm.createContext(sandbox);
(async () => {
  try { await vm.runInContext(`(async () => {\n${script}\n})()`, sandbox); }
  catch (error) { return { comments, updates, infos, error: error.message }; }
  return { comments, updates, infos };
})().then(result => process.stdout.write(JSON.stringify(result))).catch(error => { console.error(error); process.exitCode = 1; });
'@
        $result = $inputJson | & node -e $runner
        if ($LASTEXITCODE -ne 0) { throw "Notification script runner failed with exit code $LASTEXITCODE." }
        $parsed = ConvertFrom-Json -InputObject $result -AsHashtable
        if ($parsed.error -and !$Options.failComment) { throw $parsed.error }
        return $parsed
    }

    function New-TestPullRequest {
        param([string]$State = 'open', [bool]$Draft = $false, [string]$HeadSha = $script:Head, [string]$BaseSha = $script:Base)
        return @{ state = $State; draft = $Draft; head = @{ sha = $HeadSha }; base = @{ sha = $BaseSha } }
    }

    function New-TestComment {
        param([int]$Id, [string]$RunId, [string]$Body = 'Please request a manual review.', [string]$UpdatedAt = '2026-01-01T00:00:00Z', [string]$User = 'github-actions[bot]')
        return @{ id = $Id; body = "<!-- pr-re-review-manual-review:$RunId -->`n$Body"; updated_at = $UpdatedAt; user = @{ login = $User } }
    }
}

Describe 'PR re-review manual-review notifications' {
    It 'notifies for <Type> without publishing a review' -ForEach @(
        @{ Type = 'report_incomplete' }
        @{ Type = 'missing_tool' }
        @{ Type = 'missing_data' }
    ) {
        $result = Invoke-NotificationScript @{ outputTypes = $Type; output = @{ items = @(@{ type = $Type }); errors = @() } }
        $result.comments.Count | Should -Be 1
        $result.comments[0].body | Should -Match 'manual review'
        $result.comments[0].body | Should -Match 'did not complete'
        $result.comments[0].body | Should -Match 'actions/runs/123'
        $result.comments[0].body | Should -Match '&#45; by copilot$'
    }

    It 'notifies for <Type> from the artifact when collected types are unavailable' -ForEach @(
        @{ Type = 'report_incomplete' }
        @{ Type = 'missing_tool' }
        @{ Type = 'missing_data' }
    ) {
        $result = Invoke-NotificationScript @{ outputTypes = ''; output = @{ items = @(@{ type = $Type }); errors = @() } }
        $result.comments.Count | Should -Be 1
        $result.comments[0].body | Should -Match 'did not complete'
        $result.comments[0].body | Should -Match 'manual review'
    }

    It 'notifies for size skips with measured size and limit' {
        $result = Invoke-NotificationScript @{ oversized = $true }
        $result.comments.Count | Should -Be 1
        $result.comments[0].body | Should -Match '700,001'
        $result.comments[0].body | Should -Match '700,000'
        $result.comments[0].body | Should -Match 'manual review'
    }

    It 'does not mislabel a complete or malformed agent output' {
        foreach ($output in @(@{ items = @(@{ type = 'submit_pull_request_review' }); errors = @() }, @{ items = @(); errors = @() })) {
            $result = Invoke-NotificationScript @{ outputTypes = ''; output = $output }
            $result.comments.Count | Should -Be 0
        }
    }

    It 'does not post for a closed, draft, or superseded pull request' {
        foreach ($pr in @((New-TestPullRequest -State 'closed'), (New-TestPullRequest -Draft $true), (New-TestPullRequest -HeadSha ('b' * 40)))) {
            $result = Invoke-NotificationScript @{ pr = $pr }
            $result.comments.Count | Should -Be 0
        }
    }

    It 'notifies against the current base when only the base advanced' -ForEach @(
        @{ Oversized = $false }
        @{ Oversized = $true }
    ) {
        $result = Invoke-NotificationScript @{ oversized = $Oversized; pr = (New-TestPullRequest -BaseSha ('c' * 40)) }
        $result.comments.Count | Should -Be 1
        $result.comments[0].body | Should -Match $script:Base
        $result.comments[0].body | Should -Match 'base has changed'
        $result.comments[0].body | Should -Match 'current base'
        $result.comments[0].body | Should -Match 'manual review'
    }

    It 'does not duplicate a comment from this run' {
        $result = Invoke-NotificationScript @{ previous = @((New-TestComment -Id 22 -RunId '123')) }
        $result.comments.Count | Should -Be 0
    }

    It 'notifies from collected output types even when the artifact is unavailable' {
        $result = Invoke-NotificationScript @{ outputTypes = 'report_incomplete'; artifactFails = $true }
        $result.comments.Count | Should -Be 1
    }

    It 'updates this run notification after a successful rerun' {
        $result = Invoke-NotificationScript @{ completed = $true; previous = @((New-TestComment -Id 22 -RunId '123')) }
        $result.comments.Count | Should -Be 0
        $result.updates.Count | Should -Be 1
        $result.updates[0].comment_id | Should -Be 22
        $result.updates[0].body | Should -Match 'completed'
        $result.updates[0].body | Should -Not -Match 'please request a manual review'
    }

    It 'clears older warnings but not newer or unrelated comments after a later successful run' {
        $previous = @(
            (New-TestComment -Id 21 -RunId '122')
            (New-TestComment -Id 22 -RunId '124' -UpdatedAt '2026-01-03T00:00:00Z')
            (New-TestComment -Id 23 -RunId '121' -User 'someone-else')
        )
        $result = Invoke-NotificationScript @{ completed = $true; previous = $previous }
        $result.updates.Count | Should -Be 1
        $result.updates[0].comment_id | Should -Be 21
        $result.updates[0].body | Should -Match 'completed'
    }

    It 'reactivates a previously updated notification after a later incomplete attempt' {
        $result = Invoke-NotificationScript @{ previous = @((New-TestComment -Id 22 -RunId '123' -Body 'The automated re-review completed.')) }
        $result.comments.Count | Should -Be 0
        $result.updates.Count | Should -Be 1
        $result.updates[0].body | Should -Match 'please request a manual review'
    }

    It 'does not hide comment API failures' {
        $result = Invoke-NotificationScript @{ failComment = $true }
        $result.error | Should -Be 'comment API failed'
    }

    It 'preserves the live-only notification and completion gates in the compiled workflow' {
        foreach ($text in @($script:Source, $script:Lock)) {
            $job = Get-NotificationJob 'notify_manual_review' $text
            $job | Should -Match "github\.event_name != 'workflow_dispatch'"
            $job | Should -Match 'always\(\)'
            $job | Should -Match '!cancelled\(\)'
            $job | Should -Match "needs\.size_gate\.outputs\.within_cap == 'false'"
            $job | Should -Match "needs\.validate_agent_output\.result == 'failure'"
            $job | Should -Match 'issues: write'
            $job | Should -Match 'actions: read'
            $job | Should -Match 'pull-requests: read'
            $job | Should -Match 'Fail oversized re-review[\s\S]*always\(\)[\s\S]*exit 1'
            $job | Should -Match "Download terminal agent output[\s\S]*needs\.size_gate\.outputs\.within_cap != 'false'"

            $update = Get-NotificationJob 'update_manual_review' $text
            $update | Should -Match "github\.event_name != 'workflow_dispatch'"
            $update | Should -Match "needs\.validate_agent_output\.result == 'success'"
            $update | Should -Match "!contains\(needs\.agent\.outputs\.output_types, 'unresolve_review_thread'\)"
            $update | Should -Match "needs\.unresolve_review_thread\.result == 'skipped'"
            $update | Should -Not -Match "needs\.unresolve_review_thread\.result == 'success'"
            $update | Should -Match "needs\.detection\.outputs\.detection_conclusion == 'success'"
            $update | Should -Match "needs\.safe_outputs\.result == 'success'"
            $update | Should -Match "needs\.safe_outputs\.outputs\.process_safe_outputs_status == 'success'"
        }
        (Get-NotificationScript 'notify_manual_review' $script:Lock) | Should -BeExactly (Get-NotificationScript 'notify_manual_review' $script:Source)
        (Get-NotificationScript 'update_manual_review' $script:Lock) | Should -BeExactly (Get-NotificationScript 'update_manual_review' $script:Source)
    }

    It 'reports the same size limit the workflow passes to the helper' {
        foreach ($text in @($script:Source, $script:Lock)) {
            $gate = Get-NotificationJob 'size_gate' $text
            $gate | Should -Match 'MAX_CHARACTERS: [''"]?700000'
            $gate | Should -Match '& \$gate -MaxCharacters \(\[long\]\$env:MAX_CHARACTERS\)'
            $gate | Should -Match 'max_characters=\$env:MAX_CHARACTERS'
            $gate | Should -Match 'max_characters: \$\{\{ steps\.measure\.outputs\.max_characters \}\}'
        }
    }
}

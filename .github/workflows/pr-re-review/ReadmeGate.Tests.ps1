#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewReadmeGate.psm1') -Force

    function Save-Commit([string]$Message) {
        git -C $repository add -A
        git -C $repository commit -qm $Message
        return (git -C $repository rev-parse HEAD).Trim()
    }
}

Describe 'review completion receipts' {
    BeforeEach {
        $script:context = @{
            Repository = 'Azure/azure-sdk-for-net'; Number = 42; Head = ('a' * 40); Base = ('b' * 40)
            BaseRef = 'main'; BaseTip = ('d' * 40); WorkflowSha = ('e' * 40); RunId = 123; Attempt = 1; Event = 'pull_request'
        }
        $script:item = @{
            type = 'submit_pull_request_review'; repo = $context.Repository; number = 42; id = 456
            metadata = @{ review_id = 456; review_event = 'COMMENT'; review_state = 'COMMENTED' }
        }
        $script:review = @{
            id = 456; state = 'COMMENTED'; commit_id = $context.Head; submitted_at = '2026-01-01T00:00:00Z'
            user = @{ login = 'github-actions[bot]'; id = 777 }
            body = '> Re-reviewed by Pull Request Re-Review: https://github.com/Azure/azure-sdk-for-net/actions/runs/123'
        }
    }

    It 'records an actually published review' {
        $receipt = New-PrReReviewReceipt -Context $context -Items @($item) -Review $review -ServerUrl 'https://github.com'
        $receipt.review_id | Should -Be 456
        $receipt.head | Should -BeExactly $context.Head
        $receipt.base | Should -BeExactly $context.Base
        $receipt.base_tip | Should -BeExactly $context.BaseTip
        $receipt.workflow_sha | Should -BeExactly $context.WorkflowSha
    }

    It 'rejects a missing or wrong published review' -ForEach @(
        @{ Field = 'id'; Value = 457 }
        @{ Field = 'state'; Value = 'PENDING' }
        @{ Field = 'commit_id'; Value = ('c' * 40) }
        @{ Field = 'body'; Value = 'no run link' }
        @{ Field = 'submitted_at'; Value = $null }
    ) {
        $review[$Field] = $Value
        { New-PrReReviewReceipt -Context $context -Items @($item) -Review $review -ServerUrl 'https://github.com' } | Should -Throw
    }

    It 'rejects a fork workflow not executed at the trusted base tip' {
        $context.Event = 'pull_request_target'
        { New-PrReReviewReceipt -Context $context -Items @($item) -Review $review -ServerUrl 'https://github.com' } | Should -Throw
        $context.WorkflowSha = $context.BaseTip
        $receipt = New-PrReReviewReceipt -Context $context -Items @($item) -Review $review -ServerUrl 'https://github.com'
        $receipt.workflow_sha | Should -BeExactly $context.BaseTip
    }

    It 'records the publisher of the processor-verified review without requiring the default token' {
        $review.user.login = 'custom-publisher'
        $receipt = New-PrReReviewReceipt -Context $context -Items @($item) -Review $review -ServerUrl 'https://github.com'
        $receipt.publisher | Should -BeExactly 'custom-publisher'
        $receipt.publisher_id | Should -Be 777
    }

    It 'rejects a missing publisher, duplicate review result, or rerun' {
        $review.user.id = $null
        { New-PrReReviewReceipt -Context $context -Items @($item) -Review $review -ServerUrl 'https://github.com' } | Should -Throw
        $review.user.id = 777
        { New-PrReReviewReceipt -Context $context -Items @($item, $item) -Review $review -ServerUrl 'https://github.com' } | Should -Throw
        $context.Attempt = 2
        { New-PrReReviewReceipt -Context $context -Items @($item) -Review $review -ServerUrl 'https://github.com' } | Should -Throw
    }
}

Describe 'baseline provenance' {
    BeforeEach {
        $script:expected = @{ repository = 'Azure/azure-sdk-for-net'; number = 42; base = ('b' * 40); base_tip = ('d' * 40); base_ref = 'main'; event = 'pull_request' }
        $script:receipt = @{
            version = 1; repository = $expected.repository; number = 42; head = ('a' * 40); base = $expected.base
            base_tip = $expected.base_tip; base_ref = 'main'; workflow_sha = ('e' * 40); run_id = 123; attempt = 1; event = 'pull_request'; review_id = 456; publisher = 'github-actions[bot]'; publisher_id = 777
        }
        $script:run = @{ id = 123; status = 'completed'; conclusion = 'success'; run_attempt = 1; event = 'pull_request'; head_sha = $receipt.head; path = '.github/workflows/pr-re-review.lock.yml' }
        $script:jobs = @(
            @{ name = 'agent'; conclusion = 'success' }, @{ name = 'detection'; conclusion = 'success' },
            @{ name = 'safe_outputs'; conclusion = 'success'; steps = @(@{ name = 'Require complete re-review coverage before publishing'; conclusion = 'success' }, @{ name = 'Process Safe Outputs'; conclusion = 'success' }, @{ name = 'Upload Safe Outputs Items'; conclusion = 'success' }) }, @{ name = 'validate_agent_output'; conclusion = 'success' },
            @{ name = 'baseline-receipt'; conclusion = 'success'; steps = @(@{ name = 'Upload verified baseline'; conclusion = 'success' }, @{ name = 'Confirm baseline upload'; conclusion = 'success' }) }
        )
        $script:review = @{ id = 456; state = 'COMMENTED'; commit_id = $receipt.head; submitted_at = '2026-01-01T00:00:00Z'; user = @{ login = 'github-actions[bot]'; id = 777 }; body = '> Re-reviewed by Pull Request Re-Review: https://github.com/Azure/azure-sdk-for-net/actions/runs/123' }
    }

    It 'accepts a matching receipt and successful run' {
        Test-PrReReviewBaseline -Expected $expected -Receipt $receipt -Run $run -Jobs $jobs -Review $review -ServerUrl 'https://github.com' | Should -BeTrue
    }

    It 'rejects stale, failed, retried or mismatched evidence' -ForEach @(
        @{ Which = 'receipt'; Field = 'base'; Value = ('c' * 40) }
        @{ Which = 'receipt'; Field = 'base_tip'; Value = ('c' * 40) }
        @{ Which = 'receipt'; Field = 'attempt'; Value = 2 }
        @{ Which = 'run'; Field = 'conclusion'; Value = 'failure' }
        @{ Which = 'run'; Field = 'run_attempt'; Value = 2 }
        @{ Which = 'run'; Field = 'head_sha'; Value = ('c' * 40) }
        @{ Which = 'review'; Field = 'id'; Value = 999 }
        @{ Which = 'receipt'; Field = 'publisher_id'; Value = 999 }
    ) {
        switch ($Which) { 'receipt' { $receipt[$Field] = $Value } 'run' { $run[$Field] = $Value } 'review' { $review[$Field] = $Value } }
        Test-PrReReviewBaseline -Expected $expected -Receipt $receipt -Run $run -Jobs $jobs -Review $review -ServerUrl 'https://github.com' | Should -BeFalse
    }

    It 'rejects a missing or unsuccessful receipt publication job' {
        $jobs[-1].steps[0].conclusion = 'skipped'
        Test-PrReReviewBaseline -Expected $expected -Receipt $receipt -Run $run -Jobs $jobs -Review $review -ServerUrl 'https://github.com' | Should -BeFalse
    }

    It 'rejects a failed best-effort receipt upload even if its step conclusion is success' {
        $jobs[-1].steps[1].conclusion = 'skipped'
        Test-PrReReviewBaseline -Expected $expected -Receipt $receipt -Run $run -Jobs $jobs -Review $review -ServerUrl 'https://github.com' | Should -BeFalse
    }

    It 'rejects unverified safe-output artifact publication and a changed publisher identity' {
        $jobs[2].steps[2].conclusion = 'skipped'
        Test-PrReReviewBaseline -Expected $expected -Receipt $receipt -Run $run -Jobs $jobs -Review $review -ServerUrl 'https://github.com' | Should -BeFalse
        $jobs[2].steps[2].conclusion = 'success'
        $review.user.id = 888
        Test-PrReReviewBaseline -Expected $expected -Receipt $receipt -Run $run -Jobs $jobs -Review $review -ServerUrl 'https://github.com' | Should -BeFalse
    }
}

Describe 'README-only changes since a reviewed head' {
    BeforeEach {
        $script:repository = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        New-Item -ItemType Directory -Path $repository | Out-Null
        git -C $repository init -q
        git -C $repository config user.name test
        git -C $repository config user.email test@example.com
        [IO.File]::WriteAllText((Join-Path $repository 'code.cs'), 'original')
        [IO.File]::WriteAllText((Join-Path $repository 'README.md'), 'original')
        git -C $repository add .
        git -C $repository commit -qm initial
        $script:baseline = (git -C $repository rev-parse HEAD).Trim()
    }

    It 'accepts README-only commits across the entire range' {
        [IO.File]::AppendAllText((Join-Path $repository 'README.md'), ' one')
        $null = Save-Commit 'one'
        New-Item -ItemType Directory -Path (Join-Path $repository 'nested') | Out-Null
        [IO.File]::WriteAllText((Join-Path $repository 'nested/README.md'), 'two')
        $head = Save-Commit 'two'
        Test-PrReReviewReadmeOnlyChanges -RepositoryPath $repository -Baseline $baseline -Head $head | Should -BeTrue
    }

    It 'rejects a non-README change even if subsequently reverted' {
        [IO.File]::WriteAllText((Join-Path $repository 'code.cs'), 'changed')
        $null = Save-Commit 'change code'
        [IO.File]::WriteAllText((Join-Path $repository 'code.cs'), 'original')
        $head = Save-Commit 'revert code'
        Test-PrReReviewReadmeOnlyChanges -RepositoryPath $repository -Baseline $baseline -Head $head | Should -BeFalse
    }

    It 'rejects renames from or to a non-README path' {
        git -C $repository mv README.md notes.md
        $head = Save-Commit 'rename'
        Test-PrReReviewReadmeOnlyChanges -RepositoryPath $repository -Baseline $baseline -Head $head | Should -BeFalse
    }

    It 'rejects replacing a README with a symbolic link' {
        Remove-Item (Join-Path $repository 'README.md')
        New-Item -ItemType SymbolicLink -Path (Join-Path $repository 'README.md') -Target 'code.cs' | Out-Null
        $head = Save-Commit 'symlink'
        Test-PrReReviewReadmeOnlyChanges -RepositoryPath $repository -Baseline $baseline -Head $head | Should -BeFalse
    }

    It 'rejects missing commits and empty ranges' {
        Test-PrReReviewReadmeOnlyChanges -RepositoryPath $repository -Baseline ('f' * 40) -Head $baseline | Should -BeFalse
        Test-PrReReviewReadmeOnlyChanges -RepositoryPath $repository -Baseline $baseline -Head $baseline | Should -BeFalse
    }

    It 'rejects merge commits even when their net changes are README-only' {
        git -C $repository checkout -qb topic
        New-Item -ItemType Directory -Path (Join-Path $repository 'nested') | Out-Null
        [IO.File]::WriteAllText((Join-Path $repository 'nested/README.md'), 'topic')
        $null = Save-Commit 'topic'
        git -C $repository checkout -q -
        [IO.File]::AppendAllText((Join-Path $repository 'README.md'), ' current')
        $null = Save-Commit 'current'
        git -C $repository merge --no-ff -qm merge topic
        $head = (git -C $repository rev-parse HEAD).Trim()
        Test-PrReReviewReadmeOnlyChanges -RepositoryPath $repository -Baseline $baseline -Head $head | Should -BeFalse
    }

    It 'rejects a baseline which is not an ancestor' {
        git -C $repository checkout -qb other
        [IO.File]::AppendAllText((Join-Path $repository 'README.md'), ' other')
        $other = Save-Commit 'other'
        git -C $repository checkout -q -
        [IO.File]::AppendAllText((Join-Path $repository 'README.md'), ' current')
        $head = Save-Commit 'current'
        Test-PrReReviewReadmeOnlyChanges -RepositoryPath $repository -Baseline $other -Head $head | Should -BeFalse
    }
}

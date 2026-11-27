#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    $script:gateScript = Join-Path $PSScriptRoot 'Invoke-PrReReviewReadmeGate.ps1'
    $script:receiptScript = Join-Path $PSScriptRoot 'Invoke-PrReReviewReceipt.ps1'
    $script:savedEnvironment = @{}
    foreach ($name in @('PATH', 'GITHUB_REPOSITORY', 'GITHUB_SERVER_URL', 'GITHUB_EVENT_NAME', 'GITHUB_RUN_ID', 'GITHUB_RUN_ATTEMPT', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'PR_BASE_REF', 'GH_TOKEN', 'GITHUB_OUTPUT', 'RUNNER_TEMP', 'REVIEW_HEAD_REPOSITORY', 'REVIEW_HELPERS_REPOSITORY', 'REVIEW_ITEMS', 'RECEIPT_PATH', 'WORKFLOW_SHA', 'PR_GATE_FIXTURE', 'PR_GATE_ARCHIVE')) {
        $script:savedEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
    }
    function Save-Fixture {
        [IO.File]::WriteAllText($env:PR_GATE_FIXTURE, (ConvertTo-Json -InputObject $fixture -Depth 30 -Compress))
    }
    function Save-Archive {
        if (Test-Path $env:PR_GATE_ARCHIVE) { Remove-Item $env:PR_GATE_ARCHIVE }
        $zip = [IO.Compression.ZipFile]::Open($env:PR_GATE_ARCHIVE, [IO.Compression.ZipArchiveMode]::Create)
        try {
            $entry = $zip.CreateEntry('receipt.json')
            $writer = [IO.StreamWriter]::new($entry.Open())
            try { $writer.Write((ConvertTo-Json -InputObject $receipt -Depth 20 -Compress)) } finally { $writer.Dispose() }
        } finally { $zip.Dispose() }
    }
}

AfterAll {
    foreach ($name in $script:savedEnvironment.Keys) { [Environment]::SetEnvironmentVariable($name, $script:savedEnvironment[$name]) }
}

Describe 'README gate with GitHub and Git fixtures' {
    BeforeEach {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $repository = Join-Path $root 'repository'
        $bin = Join-Path $root 'bin'
        New-Item -ItemType Directory -Path $repository, $bin | Out-Null
        $fakeGh = @'
#!/usr/bin/env pwsh
$fixture = ConvertFrom-Json -AsHashtable ([IO.File]::ReadAllText($env:PR_GATE_FIXTURE))
$key = $args[1]
if (!$fixture.ContainsKey($key)) { [Console]::Error.WriteLine("Missing fixture: $key"); exit 1 }
if ($fixture[$key] -ceq '__archive__') {
    $bytes = [IO.File]::ReadAllBytes($env:PR_GATE_ARCHIVE)
    $stream = [Console]::OpenStandardOutput()
    $stream.Write($bytes, 0, $bytes.Length)
} else {
    [Console]::Out.Write((ConvertTo-Json -InputObject $fixture[$key] -Depth 30 -Compress))
}
'@
        $gh = Join-Path $bin 'gh'
        [IO.File]::WriteAllText($gh, $fakeGh, [Text.UTF8Encoding]::new($false))
        chmod +x $gh
        $env:PATH = "$bin$([IO.Path]::PathSeparator)$($script:savedEnvironment.PATH)"
        git -C $repository init -q
        git -C $repository config user.name test
        git -C $repository config user.email test@example.com
        New-Item -ItemType Directory -Path (Join-Path $repository '.github/workflows') -Force | Out-Null
        [IO.File]::WriteAllText((Join-Path $repository '.github/workflows/pr-re-review.lock.yml'), 'trusted workflow')
        [IO.File]::WriteAllText((Join-Path $repository 'README.md'), 'before')
        [IO.File]::WriteAllText((Join-Path $repository 'code.cs'), 'before')
        git -C $repository add .
        git -C $repository commit -qm baseline
        $baseline = (git -C $repository rev-parse HEAD).Trim()
        [IO.File]::AppendAllText((Join-Path $repository 'README.md'), ' after')
        git -C $repository add .
        git -C $repository commit -qm readme
        $head = (git -C $repository rev-parse HEAD).Trim()
        $env:GITHUB_REPOSITORY = 'Azure/azure-sdk-for-net'
        $env:GITHUB_SERVER_URL = 'https://github.com'
        $env:GITHUB_EVENT_NAME = 'pull_request'
        $env:GITHUB_RUN_ID = '123'
        $env:GITHUB_RUN_ATTEMPT = '1'
        $env:WORKFLOW_SHA = $head
        $env:PR_NUMBER = '42'
        $env:PR_HEAD_SHA = $head
        $env:PR_BASE_SHA = 'b' * 40
        $env:PR_BASE_REF = 'main'
        $env:GH_TOKEN = 'fixture'
        $env:GITHUB_OUTPUT = Join-Path $root 'output'
        $env:RUNNER_TEMP = $root
        $env:REVIEW_HEAD_REPOSITORY = $repository
        $env:REVIEW_HELPERS_REPOSITORY = $repository
        $env:PR_GATE_FIXTURE = Join-Path $root 'fixture.json'
        $env:PR_GATE_ARCHIVE = Join-Path $root 'receipt.zip'
        $env:REVIEW_ITEMS = Join-Path $root 'items.jsonl'
        $env:RECEIPT_PATH = Join-Path $root 'produced-receipt.json'
        $receipt = @{ version = 1; repository = $env:GITHUB_REPOSITORY; number = 42; head = $baseline; base = $env:PR_BASE_SHA; base_tip = $head; base_ref = 'main'; workflow_sha = $head; run_id = 123; attempt = 1; event = 'pull_request'; review_id = 456; publisher = 'github-actions[bot]'; publisher_id = 777 }
        $review = @{ id = 456; state = 'COMMENTED'; commit_id = $baseline; submitted_at = '2026-01-01T00:00:00Z'; user = @{ login = 'github-actions[bot]'; id = 777 }; body = '> Re-reviewed by Pull Request Re-Review: https://github.com/Azure/azure-sdk-for-net/actions/runs/123' }
        $pr = @{ state = 'open'; draft = $false; head = @{ sha = $head; repo = @{ id = 1 } }; base = @{ sha = $env:PR_BASE_SHA; ref = 'main'; repo = @{ id = 1; full_name = $env:GITHUB_REPOSITORY } } }
        $jobs = @(
            @{ name = 'agent'; conclusion = 'success' }, @{ name = 'detection'; conclusion = 'success' }, @{ name = 'safe_outputs'; conclusion = 'success'; steps = @(@{ name = 'Require complete re-review coverage before publishing'; conclusion = 'success' }, @{ name = 'Process Safe Outputs'; conclusion = 'success' }, @{ name = 'Upload Safe Outputs Items'; conclusion = 'success' }) },
            @{ name = 'validate_agent_output'; conclusion = 'success' }, @{ name = 'baseline-receipt'; conclusion = 'success'; steps = @(@{ name = 'Upload verified baseline'; conclusion = 'success' }, @{ name = 'Confirm baseline upload'; conclusion = 'success' }) }
        )
        $prefix = 'repos/Azure/azure-sdk-for-net'
        $fixture = @{}
        $fixture[$prefix] = @{ default_branch = 'main' }
        $fixture["$prefix/commits/main"] = @{ sha = $head }
        $fixture["$prefix/pulls/42"] = $pr
        $fixture["$prefix/pulls/42/reviews?per_page=100&page=1"] = @($review)
        $fixture["$prefix/pulls/42/reviews/456"] = $review
        $fixture["$prefix/actions/runs/123"] = @{ id = 123; repository = @{ full_name = $env:GITHUB_REPOSITORY }; path = '.github/workflows/pr-re-review.lock.yml'; status = 'completed'; conclusion = 'success'; run_attempt = 1; event = 'pull_request'; head_sha = $baseline }
        $fixture["$prefix/actions/runs/123/artifacts?per_page=100"] = @{ total_count = 1; artifacts = @(@{ id = 789; name = 'pr-re-review-baseline-v1-attempt-1'; size_in_bytes = 500; expired = $false }) }
        $fixture["$prefix/actions/artifacts/789/zip"] = '__archive__'
        $fixture["$prefix/actions/runs/123/jobs?per_page=100"] = @{ total_count = $jobs.Count; jobs = $jobs }
        Save-Fixture
        Save-Archive
    }

    It 'skips a verified README-only range' {
        & $gateScript
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT).Trim() | Should -BeExactly 'eligible=false'
    }

    It 'supports a bare PR object store without checking out PR files' {
        $bare = Join-Path $root 'bare.git'
        git clone --quiet --bare $repository $bare
        $env:REVIEW_HEAD_REPOSITORY = $bare
        & $gateScript
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT).Trim() | Should -BeExactly 'eligible=false'
    }

    It 'accepts a review published by a configured publisher' {
        $review.user.login = 'custom-publisher'
        $receipt.publisher = 'custom-publisher'
        Save-Fixture
        Save-Archive
        & $gateScript
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT).Trim() | Should -BeExactly 'eligible=false'
    }

    It 'accepts a trusted base-executed fork review even if its head has an older workflow' {
        $trusted = Join-Path $root 'trusted-base'
        New-Item -ItemType Directory -Path (Join-Path $trusted '.github/workflows') -Force | Out-Null
        git -C $trusted init -q
        git -C $trusted config user.name test
        git -C $trusted config user.email test@example.com
        [IO.File]::WriteAllText((Join-Path $trusted '.github/workflows/pr-re-review.lock.yml'), 'new trusted workflow')
        git -C $trusted add .
        git -C $trusted commit -qm base
        $tip = (git -C $trusted rev-parse HEAD).Trim()
        $env:REVIEW_HELPERS_REPOSITORY = $trusted
        $env:GITHUB_EVENT_NAME = 'pull_request_target'
        $pr.head.repo.id = 2
        $fixture["$prefix/commits/main"].sha = $tip
        $fixture["$prefix/actions/runs/123"].event = 'pull_request_target'
        $receipt.event = 'pull_request_target'
        $receipt.base_tip = $tip
        $receipt.workflow_sha = $tip
        Save-Fixture
        Save-Archive
        & $gateScript
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT).Trim() | Should -BeExactly 'eligible=false'
    }

    It 'exits successfully under the Actions wrapper after a GitHub API failure' {
        $fixture.Remove($prefix)
        Save-Fixture
        $command = "& '$gateScript'; if (Test-Path -LiteralPath variable:\LASTEXITCODE) { exit `$LASTEXITCODE }"
        & pwsh -NoLogo -NoProfile -Command $command
        $LASTEXITCODE | Should -Be 0
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT).Trim() | Should -BeExactly 'eligible=true'
    }

    It 'runs on a retry of the current event' {
        $env:GITHUB_RUN_ATTEMPT = '2'
        & $gateScript
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT).Trim() | Should -BeExactly 'eligible=true'
    }

    It 'runs when an artifact is missing or the base tip moved' -ForEach @('artifact', 'base') {
        if ($_ -ceq 'artifact') { $fixture["$prefix/actions/runs/123/artifacts?per_page=100"].artifacts = @(); $fixture["$prefix/actions/runs/123/artifacts?per_page=100"].total_count = 0 }
        else { $fixture["$prefix/commits/main"].sha = 'f' * 40 }
        Save-Fixture
        & $gateScript
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT).Trim() | Should -BeExactly 'eligible=true'
    }

    It 'runs when the receipt or the actual upload step cannot be verified' -ForEach @('receipt', 'upload', 'run') {
        switch ($_) {
            'receipt' { $receipt.review_id = 999; Save-Archive }
            'upload' { $jobs[-1].steps[1].conclusion = 'skipped' }
            'run' { $fixture["$prefix/actions/runs/123"].run_attempt = 2 }
        }
        Save-Fixture
        & $gateScript
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT).Trim() | Should -BeExactly 'eligible=true'
    }

    It 'runs when the intervening range contains code' {
        [IO.File]::AppendAllText((Join-Path $repository 'code.cs'), ' changed')
        git -C $repository add .
        git -C $repository commit -qm code
        $head = (git -C $repository rev-parse HEAD).Trim()
        $env:PR_HEAD_SHA = $head
        $pr.head.sha = $head
        $fixture["$prefix/commits/main"].sha = $head
        $receipt.base_tip = $head
        Save-Fixture
        Save-Archive
        & $gateScript
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT).Trim() | Should -BeExactly 'eligible=true'
    }

    It 'records a matching published review and live PR state' {
        $review.commit_id = $head
        $item = @{ type = 'submit_pull_request_review'; repo = $env:GITHUB_REPOSITORY; number = 42; id = 456; metadata = @{ review_id = 456; review_event = 'COMMENT'; review_state = 'COMMENTED' } }
        [IO.File]::WriteAllText($env:REVIEW_ITEMS, (ConvertTo-Json -InputObject $item -Depth 10 -Compress))
        Save-Fixture
        Push-Location $repository
        try { & $receiptScript } finally { Pop-Location }
        $produced = ConvertFrom-Json -AsHashtable ([IO.File]::ReadAllText($env:RECEIPT_PATH))
        $produced.head | Should -BeExactly $head
        $produced.base_tip | Should -BeExactly $head
        $produced.review_id | Should -Be 456
    }

    It 'keeps the receipt job successful after a handled native failure' {
        $trusted = Join-Path $root 'receipt-helpers'
        $helperDir = Join-Path $trusted '.github/workflows/pr-re-review'
        New-Item -ItemType Directory -Path $helperDir -Force | Out-Null
        Copy-Item $receiptScript, (Join-Path $PSScriptRoot 'PrReReviewReadmeGate.psm1') -Destination $helperDir
        git -C $trusted init -q
        git -C $trusted config user.name test
        git -C $trusted config user.email test@example.com
        git -C $trusted add .
        git -C $trusted commit -qm helpers
        $tip = (git -C $trusted rev-parse HEAD).Trim()
        $tree = (git -C $trusted rev-parse HEAD:.github/workflows/pr-re-review).Trim()
        $inputDir = Join-Path $root 'pr-re-review-receipt/input'
        New-Item -ItemType Directory -Path $inputDir -Force | Out-Null
        [IO.File]::WriteAllText((Join-Path $inputDir 'helpers-tree'), $tree)
        [IO.File]::WriteAllText((Join-Path $inputDir 'helpers-commit'), $tip)
        $fixture["$prefix/commits/main"].sha = $tip
        $fixture.Remove("$prefix/pulls/42/reviews/456")
        Save-Fixture
        $item = @{ type = 'submit_pull_request_review'; repo = $env:GITHUB_REPOSITORY; number = 42; id = 456; metadata = @{ review_id = 456; review_event = 'COMMENT'; review_state = 'COMMENTED' } }
        [IO.File]::WriteAllText($env:REVIEW_ITEMS, (ConvertTo-Json -InputObject $item -Depth 10 -Compress))

        # Execute the actual compiled run block with the Actions-style pwsh exit wrapper.
        $lines = [IO.File]::ReadAllLines((Join-Path $PSScriptRoot '..' 'pr-re-review.lock.yml'))
        $start = [Array]::IndexOf($lines, '      - name: Verify published review and prepare baseline')
        $run = $start + [Array]::IndexOf($lines[($start + 1)..($lines.Length - 1)], '        run: |') + 2
        $block = for ($i = $run; $i -lt $lines.Length -and $lines[$i].StartsWith('          '); $i++) { $lines[$i].Substring(10) }
        $wrapperPath = Join-Path $root 'receipt-wrapper.ps1'
        [IO.File]::WriteAllLines($wrapperPath, [string[]]$block)
        $command = ". '$wrapperPath'; if (Test-Path -LiteralPath variable:\LASTEXITCODE) { exit `$LASTEXITCODE }"
        Push-Location $trusted
        try { & pwsh -NoLogo -NoProfile -Command $command; $exitCode = $LASTEXITCODE } finally { Pop-Location }
        $exitCode | Should -Be 0
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT).Trim() | Should -BeExactly 'created=false'
        Test-Path $env:RECEIPT_PATH | Should -BeFalse
    }

    It 'does not record a stale or unpublished review' {
        $review.state = 'PENDING'
        $item = @{ type = 'submit_pull_request_review'; repo = $env:GITHUB_REPOSITORY; number = 42; id = 456; metadata = @{ review_id = 456; review_event = 'COMMENT'; review_state = 'COMMENTED' } }
        [IO.File]::WriteAllText($env:REVIEW_ITEMS, (ConvertTo-Json -InputObject $item -Depth 10 -Compress))
        Save-Fixture
        Push-Location $repository
        try { { & $receiptScript } | Should -Throw } finally { Pop-Location }
        Test-Path $env:RECEIPT_PATH | Should -BeFalse
    }
}

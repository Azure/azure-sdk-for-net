#Requires -Version 7.5
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    $script:WorkflowText = [IO.File]::ReadAllText((Join-Path $PSScriptRoot '..' 'pr-re-review.md'))
    $script:Frontmatter, $script:Prompt = ($script:WorkflowText -split '(?m)^---\s*$', 3)[1, 2]
}

Describe 'Full-PR local Git review input' {
    It 'fetches sufficient history for the PR merge base' {
        $checkout = [regex]::Match($script:Frontmatter, '(?m)^checkout:[ \t]*\r?\n(?<body>(?:[ \t]+[^\r\n]*\r?\n)*)').Groups['body'].Value
        ($checkout -match '(?m)^  fetch-depth:[ \t]*0[ \t]*\r?$') | Should -BeTrue
    }

    It 'compiles full history into the existing agent checkout before PR checkout and trusted restoration' {
        $lines = [IO.File]::ReadAllLines((Join-Path $PSScriptRoot '..' 'pr-re-review.lock.yml'))
        $agent = [array]::IndexOf($lines, '  agent:')
        $agent | Should -BeGreaterOrEqual 0
        $checkout = [array]::IndexOf($lines, '      - name: Checkout repository (gh-aw default)', $agent)
        $prCheckout = [array]::IndexOf($lines, '      - name: Checkout PR branch', $agent)
        $restore = [array]::IndexOf($lines, '      - name: Restore agent config folders from base branch', $agent)
        $execute = [array]::IndexOf($lines, '      - name: Execute GitHub Copilot CLI', $agent)
        $checkout | Should -BeGreaterThan $agent
        $prCheckout | Should -BeGreaterThan $checkout
        $restore | Should -BeGreaterThan $prCheckout
        $execute | Should -BeGreaterThan $restore
        $checkoutBlock = $lines[$checkout..($prCheckout - 1)] -join "`n"
        ($checkoutBlock -match '(?m)^          fetch-depth: 0$') | Should -BeTrue
        ($checkoutBlock -match '(?m)^          persist-credentials: false$') | Should -BeTrue
    }

    It 'enumerates and reviews changes from the event base and head using local Git' {
        ($script:Prompt -match 'git merge-base') | Should -BeTrue
        ($script:Prompt -match 'git diff --name-status -z --find-renames=50%') | Should -BeTrue
        ($script:Prompt -match 'git diff --binary --full-index --no-ext-diff --no-textconv') | Should -BeTrue
        ($script:Prompt -match 'github\.event\.pull_request\.base\.sha') | Should -BeTrue
        ($script:Prompt -match 'github\.event\.pull_request\.head\.sha') | Should -BeTrue
        ($script:Prompt -notmatch '(?m)^- `get_files`:') | Should -BeTrue
    }

    It 'preserves the full PR and existing review-thread coverage contract' {
        ($script:Prompt -match 'every changed file') | Should -BeTrue
        ($script:Prompt -match 'get_review_comments') | Should -BeTrue
        ($script:Prompt -match 'Coverage: <fetched>/<total> threads fetched, <verified>/<unresolved> unresolved threads verified, <reviewed>/<changed> changed files reviewed') | Should -BeTrue
    }

    It 'enumerates 3001 changed files with local Git and excludes unrelated base-branch changes' {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $null = [IO.Directory]::CreateDirectory($root)
        & git -C $root init --quiet
        if ($LASTEXITCODE -ne 0) { throw 'git init failed' }
        [IO.File]::WriteAllText((Join-Path $root 'common.txt'), "common`n")
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m common
        if ($LASTEXITCODE -ne 0) { throw 'common commit failed' }
        $common = (& git -C $root rev-parse HEAD).Trim()
        & git -C $root checkout --quiet -b base
        [IO.File]::WriteAllText((Join-Path $root 'base-only.txt'), "base`n")
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m base
        if ($LASTEXITCODE -ne 0) { throw 'base commit failed' }
        $base = (& git -C $root rev-parse HEAD).Trim()
        & git -C $root checkout --quiet -b feature $common
        foreach ($i in 1..3001) { [IO.File]::WriteAllText((Join-Path $root "file-$i.cs"), "file $i`n") }
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m feature
        if ($LASTEXITCODE -ne 0) { throw 'feature commit failed' }
        $head = (& git -C $root rev-parse HEAD).Trim()
        $merge = (& git -C $root merge-base $base $head).Trim()
        $merge | Should -BeExactly $common
        $path = Join-Path $TestDrive 'inventory.bin'
        & git -C $root diff --name-status -z --find-renames=50% --no-ext-diff --no-textconv $merge $head -- > $path
        if ($LASTEXITCODE -ne 0) { throw 'git inventory failed' }
        $bytes = [IO.File]::ReadAllBytes($path)
        $tokens = [Text.Encoding]::UTF8.GetString($bytes).Split([char]0, [StringSplitOptions]::RemoveEmptyEntries)
        $tokens.Count | Should -Be 6002
        @($tokens | Where-Object { $_ -ceq 'A' }).Count | Should -Be 3001
        $tokens | Should -Contain 'file-3001.cs'
        $tokens | Should -Not -Contain 'base-only.txt'
        $patchPath = Join-Path $TestDrive 'complete-diff.patch'
        & git -C $root diff --binary --full-index --no-ext-diff --no-textconv --find-renames=50% $merge $head -- > $patchPath
        if ($LASTEXITCODE -ne 0) { throw 'git diff failed' }
        $patch = [IO.File]::ReadAllText($patchPath)
        ([regex]::Matches($patch, '(?m)^diff --git ').Count) | Should -Be 3001
        ($patch -match '(?m)^diff --git a/file-3001\.cs b/file-3001\.cs$') | Should -BeTrue
        ($patch -match 'base-only\.txt') | Should -BeFalse
    }

    It 'finds the merge base after checking out a PR ref from a local bare remote' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $source = Join-Path $fixture 'source'
        $remote = Join-Path $fixture 'origin.git'
        $checkout = Join-Path $fixture 'checkout'
        $null = [IO.Directory]::CreateDirectory($source)
        & git -C $source init --quiet
        [IO.File]::WriteAllText((Join-Path $source 'common.txt'), "common`n")
        & git -C $source add --all
        & git -C $source -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m common
        if ($LASTEXITCODE -ne 0) { throw 'common commit failed' }
        $common = (& git -C $source rev-parse HEAD).Trim()
        & git -C $source checkout --quiet -b base
        [IO.File]::WriteAllText((Join-Path $source 'base-only.txt'), "base`n")
        & git -C $source add --all
        & git -C $source -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m base
        if ($LASTEXITCODE -ne 0) { throw 'base commit failed' }
        $base = (& git -C $source rev-parse HEAD).Trim()
        & git -C $source checkout --quiet -b feature $common
        [IO.File]::WriteAllText((Join-Path $source 'pr-only.txt'), "feature`n")
        & git -C $source add --all
        & git -C $source -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m feature
        if ($LASTEXITCODE -ne 0) { throw 'feature commit failed' }
        $head = (& git -C $source rev-parse HEAD).Trim()
        & git init --quiet --bare $remote
        if ($LASTEXITCODE -ne 0) { throw 'bare remote initialization failed' }
        $remoteUri = ([Uri]::new($remote, [UriKind]::Absolute)).AbsoluteUri
        & git -C $source push --quiet $remoteUri "${base}:refs/heads/main" "${head}:refs/pull/42/head"
        if ($LASTEXITCODE -ne 0) { throw 'local fixture push failed' }
        & git clone --quiet --no-local --branch main $remoteUri $checkout
        if ($LASTEXITCODE -ne 0) { throw 'local clone failed' }
        & git -C $checkout fetch --quiet origin refs/pull/42/head
        if ($LASTEXITCODE -ne 0) { throw 'local PR ref fetch failed' }
        & git -C $checkout checkout --quiet --detach FETCH_HEAD
        if ($LASTEXITCODE -ne 0) { throw 'local PR checkout failed' }
        (& git -C $checkout rev-parse HEAD).Trim() | Should -BeExactly $head
        (& git -C $checkout rev-parse --is-shallow-repository).Trim() | Should -BeExactly 'false'
        (& git -C $checkout merge-base --all $base $head).Trim() | Should -BeExactly $common
        $paths = @(& git -C $checkout diff --name-only --find-renames=50% $common $head --)
        if ($LASTEXITCODE -ne 0) { throw 'local PR diff failed' }
        $paths | Should -Contain 'pr-only.txt'
        $paths | Should -Not -Contain 'base-only.txt'
    }

    It 'keeps rename records and special paths intact in NUL and quoted inventories' {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $null = [IO.Directory]::CreateDirectory($root)
        & git -C $root init --quiet
        if ($LASTEXITCODE -ne 0) { throw 'git init failed' }
        $old = "old name`tfile.txt"
        $new = 'renamed file.txt'
        $added = "-new`n雪.txt"
        [IO.File]::WriteAllText((Join-Path $root $old), "unchanged content`n")
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m base
        if ($LASTEXITCODE -ne 0) { throw 'base commit failed' }
        $base = (& git -C $root rev-parse HEAD).Trim()
        & git -C $root mv -- $old $new
        [IO.File]::WriteAllText((Join-Path $root $added), "new content`n")
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m head
        if ($LASTEXITCODE -ne 0) { throw 'head commit failed' }
        $head = (& git -C $root rev-parse HEAD).Trim()
        $rawPath = Join-Path $TestDrive 'special-inventory.bin'
        & git -C $root diff --name-status -z --find-renames=50% --no-ext-diff --no-textconv $base $head -- > $rawPath
        if ($LASTEXITCODE -ne 0) { throw 'NUL inventory failed' }
        $tokens = [Text.UTF8Encoding]::new($false, $true).GetString([IO.File]::ReadAllBytes($rawPath)).Split([char]0, [StringSplitOptions]::RemoveEmptyEntries)
        $tokens.Count | Should -Be 5
        $tokens | Should -Contain 'R100'
        $tokens | Should -Contain $old
        $tokens | Should -Contain $new
        $tokens | Should -Contain $added
        $display = @(& git -C $root -c core.quotepath=true diff --name-status --find-renames=50% --no-ext-diff --no-textconv $base $head --)
        if ($LASTEXITCODE -ne 0) { throw 'quoted inventory failed' }
        $display.Count | Should -Be 2
        @($display | Where-Object { $_ -match '^R100\t' }).Count | Should -Be 1
    }
}

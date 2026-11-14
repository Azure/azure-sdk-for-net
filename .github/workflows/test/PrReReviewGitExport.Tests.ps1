#Requires -Version 7.5
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    $script:HelperDirectory = Join-Path $PSScriptRoot '..' 'pr-re-review'
    Import-Module (Join-Path $script:HelperDirectory 'PrReReviewInput.psm1') -Force
    Import-Module (Join-Path $script:HelperDirectory 'PrReReviewGuard.psm1') -Force

    function New-ReviewGitFixture {
        param([int]$AddedFiles, [switch]$SpecialPaths, [switch]$DivergedBase)
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $null = [IO.Directory]::CreateDirectory($root)
        & git -C $root init --quiet
        if ($LASTEXITCODE -ne 0) { throw 'git init failed' }
        $old = "old name`tfile.txt"
        if ($SpecialPaths) { [IO.File]::WriteAllText((Join-Path $root $old), "rename content`n") }
        [IO.File]::WriteAllText((Join-Path $root 'common.txt'), "common`n")
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m common
        if ($LASTEXITCODE -ne 0) { throw 'base commit failed' }
        $common = (& git -C $root rev-parse HEAD).Trim()
        $base = $common
        if ($DivergedBase) {
            & git -C $root checkout --quiet -b target-base
            [IO.File]::WriteAllText((Join-Path $root 'base-only.txt'), "base only`n")
            & git -C $root add --all
            & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m target-base
            if ($LASTEXITCODE -ne 0) { throw 'target-base commit failed' }
            $base = (& git -C $root rev-parse HEAD).Trim()
            & git -C $root checkout --quiet -b feature $common
        }
        if ($SpecialPaths) { & git -C $root mv -- $old 'renamed file.txt' }
        foreach ($i in 1..$AddedFiles) { [IO.File]::WriteAllText((Join-Path $root "file-$i.cs"), "file $i`n") }
        if ($SpecialPaths) { [IO.File]::WriteAllText((Join-Path $root "-new`n雪.txt"), "special`n") }
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m head
        if ($LASTEXITCODE -ne 0) { throw 'head commit failed' }
        return @{ Root = $root; Base = $base; Head = (& git -C $root rev-parse HEAD).Trim() }
    }
}

Describe 'Full-PR local Git export' {
    BeforeEach {
        $script:PreviousEnvironment = @{}
        foreach ($name in 'GITHUB_REPOSITORY', 'GITHUB_WORKSPACE', 'GH_TOKEN', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'REVIEW_INPUT_DIR', 'REVIEW_INPUT_MARKERS', 'REVIEW_INPUT_SOURCE') {
            $script:PreviousEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
        }
        $env:GITHUB_REPOSITORY = 'Azure/azure-sdk-for-net'
        $env:GH_TOKEN = 'synthetic-only'
        $env:PR_NUMBER = '42'
        $env:REVIEW_INPUT_SOURCE = 'git'
        $out = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $env:REVIEW_INPUT_DIR = Join-Path $out 'input'
        $env:REVIEW_INPUT_MARKERS = Join-Path $out 'private/markers.json'
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi {
            if ($Arguments -like '*/files*') { throw 'The capped PR-file endpoint must not be used.' }
            ConvertTo-Json -Compress @{changed_files = $global:GitReviewExpectedCount; head = @{sha = $global:GitReviewHead}; base = @{sha = $global:GitReviewBase}}
        }
    }
    AfterEach {
        foreach ($name in $script:PreviousEnvironment.Keys) { [Environment]::SetEnvironmentVariable($name, $script:PreviousEnvironment[$name]) }
        Remove-Variable GitReviewExpectedCount, GitReviewHead, GitReviewBase -Scope Global -ErrorAction SilentlyContinue
    }

    It 'exports every one of 3001 local changes without requesting the capped PR-file endpoint' {
        $repo = New-ReviewGitFixture -AddedFiles 3001
        $env:GITHUB_WORKSPACE = $repo.Root
        $env:PR_HEAD_SHA = $global:GitReviewHead = $repo.Head
        $env:PR_BASE_SHA = $global:GitReviewBase = $repo.Base
        $global:GitReviewExpectedCount = 3001
        { & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1') } | Should -Not -Throw
        $index = Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json
        $markers = Get-Content -LiteralPath $env:REVIEW_INPUT_MARKERS -Raw | ConvertFrom-Json
        @($index.files).Count | Should -Be 3001
        @($markers.files).Count | Should -Be 3001
        $last = @($index.files | Where-Object path -ceq 'file-3001.cs')
        $last.Count | Should -Be 1
        (Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $last[0].patchFile) -Raw) | Should -Match '\+file 3001'
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 0 -Exactly -ParameterFilter { $Arguments -like '*/files*' }
    }

    It 'exports renames and special paths and retains upstream read-coverage enforcement' {
        $repo = New-ReviewGitFixture -AddedFiles 1 -SpecialPaths
        $env:GITHUB_WORKSPACE = $repo.Root
        $env:PR_HEAD_SHA = $global:GitReviewHead = $repo.Head
        $env:PR_BASE_SHA = $global:GitReviewBase = $repo.Base
        $global:GitReviewExpectedCount = 3
        & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1')
        $index = Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json
        $markers = Get-Content -LiteralPath $env:REVIEW_INPUT_MARKERS -Raw | ConvertFrom-Json
        @($index.files).Count | Should -Be 3
        $rename = @($index.files | Where-Object path -ceq 'renamed file.txt')
        $rename.Count | Should -Be 1
        $rename[0].previousPath | Should -BeExactly "old name`tfile.txt"
        $renamePatch = Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $rename[0].patchFile) -Raw
        $renamePatch | Should -Match 'similarity index 100%'
        $renamePatch | Should -Match 'rename to renamed file\.txt'
        $special = @($index.files | Where-Object path -ceq "-new`n雪.txt")
        $special.Count | Should -Be 1
        (Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $special[0].patchFile) -Raw) | Should -Match '\+special'
        $normal = @($index.files | Where-Object path -ceq 'file-1.cs')
        (Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $normal[0].patchFile) -Raw) | Should -Match '\+file 1'
        $log = Join-Path $TestDrive 'session.jsonl'
        $events = foreach ($file in $markers.files) {
            foreach ($chunk in $file.chunks) {
                ConvertTo-Json -Compress -Depth 10 @{type = 'tool.execution_complete'; data = @{success = $true; result = @{content = $chunk.content}}}
            }
        }
        [IO.File]::WriteAllText($log, (($events -join "`n") + "`n"))
        $output = @{items = @(@{type = 'submit_pull_request_review'})}
        { Assert-PrReReviewReadCoverage -AgentOutput $output -MarkersPath $env:REVIEW_INPUT_MARKERS -SessionLogPath $log } | Should -Not -Throw
        [IO.File]::WriteAllText($log, '')
        { Assert-PrReReviewReadCoverage -AgentOutput $output -MarkersPath $env:REVIEW_INPUT_MARKERS -SessionLogPath $log } | Should -Throw '*missing*'
    }

    It 'exports from the merge base when the target branch has advanced' {
        $repo = New-ReviewGitFixture -AddedFiles 1 -DivergedBase
        $env:GITHUB_WORKSPACE = $repo.Root
        $env:PR_HEAD_SHA = $global:GitReviewHead = $repo.Head
        $env:PR_BASE_SHA = $global:GitReviewBase = $repo.Base
        $global:GitReviewExpectedCount = 1
        & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1')
        $index = Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json
        @($index.files.path) | Should -Be @('file-1.cs')
        (Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $index.files[0].patchFile) -Raw) | Should -Not -Match 'base-only\.txt'
    }

    It 'exports a valid empty diff without skipping the thread-review workflow' {
        $repo = New-ReviewGitFixture -AddedFiles 1
        & git -C $repo.Root checkout --quiet --detach $repo.Base
        if ($LASTEXITCODE -ne 0) { throw 'fixture checkout failed' }
        $env:GITHUB_WORKSPACE = $repo.Root
        $env:PR_HEAD_SHA = $global:GitReviewHead = $repo.Base
        $env:PR_BASE_SHA = $global:GitReviewBase = $repo.Base
        $global:GitReviewExpectedCount = 0
        & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1')
        $index = Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json
        $markers = Get-Content -LiteralPath $env:REVIEW_INPUT_MARKERS -Raw | ConvertFrom-Json
        @($index.files).Count | Should -Be 0
        @($markers.files).Count | Should -Be 0
    }

    It 'exports a regular-file-to-symlink change as one changed file' {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $null = [IO.Directory]::CreateDirectory($root)
        & git -C $root init --quiet
        [IO.File]::WriteAllText((Join-Path $root 'type.txt'), "regular`n")
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m base
        if ($LASTEXITCODE -ne 0) { throw 'base commit failed' }
        $base = (& git -C $root rev-parse HEAD).Trim()
        Remove-Item -LiteralPath (Join-Path $root 'type.txt')
        $null = New-Item -ItemType SymbolicLink -Path (Join-Path $root 'type.txt') -Target 'target.txt'
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m head
        if ($LASTEXITCODE -ne 0) { throw 'head commit failed' }
        $env:GITHUB_WORKSPACE = $root
        $env:PR_HEAD_SHA = $global:GitReviewHead = (& git -C $root rev-parse HEAD).Trim()
        $env:PR_BASE_SHA = $global:GitReviewBase = $base
        $global:GitReviewExpectedCount = 1
        & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1')
        $index = Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json
        @($index.files).Count | Should -Be 1
        $patch = Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $index.files[0].patchFile) -Raw
        $patch | Should -Match 'deleted file mode 100644'
        $patch | Should -Match 'new file mode 120000'
    }

    It 'keeps multiple type-change sections with the correct files and line counts' {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $null = [IO.Directory]::CreateDirectory($root)
        & git -C $root init --quiet
        [IO.File]::WriteAllText((Join-Path $root 'a.txt'), "old a`n")
        [IO.File]::WriteAllText((Join-Path $root 'm.txt'), "old m`n")
        $null = New-Item -ItemType SymbolicLink -Path (Join-Path $root 'z.txt') -Target 'old-target'
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m base
        if ($LASTEXITCODE -ne 0) { throw 'base commit failed' }
        $base = (& git -C $root rev-parse HEAD).Trim()
        Remove-Item -LiteralPath (Join-Path $root 'a.txt')
        $null = New-Item -ItemType SymbolicLink -Path (Join-Path $root 'a.txt') -Target 'new-target'
        [IO.File]::WriteAllText((Join-Path $root 'm.txt'), "new m`n")
        Remove-Item -LiteralPath (Join-Path $root 'z.txt')
        [IO.File]::WriteAllText((Join-Path $root 'z.txt'), "new z`n")
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m head
        if ($LASTEXITCODE -ne 0) { throw 'head commit failed' }
        $env:GITHUB_WORKSPACE = $root
        $env:PR_HEAD_SHA = $global:GitReviewHead = (& git -C $root rev-parse HEAD).Trim()
        $env:PR_BASE_SHA = $global:GitReviewBase = $base
        $global:GitReviewExpectedCount = 3
        & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1')
        $index = Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json
        @($index.files).Count | Should -Be 3
        foreach ($name in @('a.txt', 'z.txt')) {
            $file = @($index.files | Where-Object path -ceq $name)[0]
            $patch = Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $file.patchFile) -Raw
            ([regex]::Matches($patch, '(?m)^diff --git ').Count) | Should -Be 2
            $patch | Should -Match ('(?m)^diff --git a/' + [regex]::Escape($name) + ' b/' + [regex]::Escape($name) + '$')
            $file.additions | Should -Be 1
            $file.deletions | Should -Be 1
        }
        $middle = @($index.files | Where-Object path -ceq 'm.txt')[0]
        (Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $middle.patchFile) -Raw) | Should -Match '\+new m'
    }

    It 'rejects unexpected data before the first diff header' {
        $repo = New-ReviewGitFixture -AddedFiles 1
        $env:GITHUB_WORKSPACE = $repo.Root
        $env:PR_HEAD_SHA = $global:GitReviewHead = $repo.Head
        $env:PR_BASE_SHA = $global:GitReviewBase = $repo.Base
        $global:GitReviewExpectedCount = 1
        Mock -ModuleName PrReReviewInput Read-PrReReviewNativeOutput {
            if ($Arguments -contains '--is-shallow-repository') { return 'false' }
            if ($Arguments -contains 'rev-parse') { return $global:GitReviewHead }
            if ($Arguments -contains 'merge-base') { return $global:GitReviewBase }
            if ($Arguments -contains 'diff') { return "unexpected prefix`ndiff --git a/file-1.cs b/file-1.cs`n@@ -0,0 +1 @@`n+file 1`n" }
            throw 'Unexpected native command.'
        }
        { & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1') } | Should -Throw '*diff*'
    }

    It 'removes GitHub credentials while running Git and restores them afterwards' {
        $repo = New-ReviewGitFixture -AddedFiles 1
        $env:GITHUB_WORKSPACE = $repo.Root
        $env:PR_HEAD_SHA = $global:GitReviewHead = $repo.Head
        $env:PR_BASE_SHA = $global:GitReviewBase = $repo.Base
        $global:GitReviewExpectedCount = 1
        Mock -ModuleName PrReReviewInput Read-PrReReviewNativeOutput {
            $env:GH_TOKEN | Should -BeNullOrEmpty
            $env:GIT_ALLOW_PROTOCOL | Should -BeExactly 'file'
            if ($Arguments -contains '--is-shallow-repository') { return 'false' }
            if ($Arguments -contains 'rev-parse') { return $global:GitReviewHead }
            if ($Arguments -contains 'merge-base') { return $global:GitReviewBase }
            if ($Arguments -contains 'diff') { return "diff --git a/file-1.cs b/file-1.cs`n@@ -0,0 +1 @@`n+file 1`n" }
            throw 'Unexpected native command.'
        }
        & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1')
        $env:GH_TOKEN | Should -BeExactly 'synthetic-only'
    }

    It 'rejects a shallow checkout even if Git reports a merge base' {
        $repo = New-ReviewGitFixture -AddedFiles 1
        $env:GITHUB_WORKSPACE = $repo.Root
        $env:PR_HEAD_SHA = $global:GitReviewHead = $repo.Head
        $env:PR_BASE_SHA = $global:GitReviewBase = $repo.Base
        $global:GitReviewExpectedCount = 1
        Mock -ModuleName PrReReviewInput Read-PrReReviewNativeOutput {
            if ($Arguments -contains '--is-shallow-repository') { return 'true' }
            if ($Arguments -contains 'rev-parse') { return $global:GitReviewHead }
            if ($Arguments -contains 'merge-base') { return $global:GitReviewBase }
            if ($Arguments -contains 'diff') { return "diff --git a/file-1.cs b/file-1.cs`n@@ -0,0 +1 @@`n+file 1`n" }
            throw 'Unexpected native command.'
        }
        { & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1') } | Should -Throw '*shallow*'
    }

    It 'rejects a checkout that does not match the event head' {
        $repo = New-ReviewGitFixture -AddedFiles 1
        $env:GITHUB_WORKSPACE = $repo.Root
        $env:PR_HEAD_SHA = $global:GitReviewHead = ('a' * 40)
        $env:PR_BASE_SHA = $global:GitReviewBase = $repo.Base
        $global:GitReviewExpectedCount = 1
        { & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1') } | Should -Throw '*checkout*head*'
        Test-Path -LiteralPath $env:REVIEW_INPUT_DIR | Should -BeFalse
    }

    It 'rejects a changed-file count mismatch instead of exporting a partial review' {
        $repo = New-ReviewGitFixture -AddedFiles 1
        $env:GITHUB_WORKSPACE = $repo.Root
        $env:PR_HEAD_SHA = $global:GitReviewHead = $repo.Head
        $env:PR_BASE_SHA = $global:GitReviewBase = $repo.Base
        $global:GitReviewExpectedCount = 2
        { & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1') } | Should -Throw '*Git listed 1*GitHub reports 2*'
        Test-Path -LiteralPath $env:REVIEW_INPUT_DIR | Should -BeFalse
    }

    It 'rejects a base change while collecting the local diff' {
        $repo = New-ReviewGitFixture -AddedFiles 1
        $env:GITHUB_WORKSPACE = $repo.Root
        $env:PR_HEAD_SHA = $global:GitReviewHead = $repo.Head
        $env:PR_BASE_SHA = $global:GitReviewBase = $repo.Base
        $global:GitReviewExpectedCount = 1
        $global:GitReviewMetadataCalls = 0
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi {
            if ($Arguments -like '*/files*') { throw 'The capped PR-file endpoint must not be used.' }
            $global:GitReviewMetadataCalls++
            $base = if ($global:GitReviewMetadataCalls -gt 1) { 'b' * 40 } else { $global:GitReviewBase }
            ConvertTo-Json -Compress @{changed_files = $global:GitReviewExpectedCount; head = @{sha = $global:GitReviewHead}; base = @{sha = $base}}
        }
        try {
            { & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1') } | Should -Throw '*changed while reading*'
            Test-Path -LiteralPath $env:REVIEW_INPUT_DIR | Should -BeFalse
        } finally { Remove-Variable GitReviewMetadataCalls -Scope Global -ErrorAction SilentlyContinue }
    }

    It 'exports binary, mode, symlink, and submodule changes without omitting records' {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $null = [IO.Directory]::CreateDirectory($root)
        & git -C $root init --quiet
        [IO.File]::WriteAllBytes((Join-Path $root 'binary.bin'), [byte[]](0, 1, 2, 255))
        [IO.File]::WriteAllText((Join-Path $root 'mode.txt'), "mode`n")
        $null = New-Item -ItemType SymbolicLink -Path (Join-Path $root 'link') -Target 'mode.txt'
        & git -C $root add --all
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m base
        if ($LASTEXITCODE -ne 0) { throw 'base commit failed' }
        $base = (& git -C $root rev-parse HEAD).Trim()
        [IO.File]::WriteAllBytes((Join-Path $root 'binary.bin'), [byte[]](0, 9, 8, 255))
        [IO.File]::SetUnixFileMode((Join-Path $root 'mode.txt'), [IO.UnixFileMode]::UserRead -bor [IO.UnixFileMode]::UserWrite -bor [IO.UnixFileMode]::UserExecute -bor [IO.UnixFileMode]::GroupRead -bor [IO.UnixFileMode]::OtherRead)
        Remove-Item -LiteralPath (Join-Path $root 'link')
        $null = New-Item -ItemType SymbolicLink -Path (Join-Path $root 'link') -Target 'binary.bin'
        & git -C $root add --all
        & git -C $root update-index --add --cacheinfo "160000,$base,submodule"
        & git -C $root -c user.name=Fixture -c user.email=fixture@example.invalid commit --quiet -m head
        if ($LASTEXITCODE -ne 0) { throw 'head commit failed' }
        $env:GITHUB_WORKSPACE = $root
        $env:PR_HEAD_SHA = $global:GitReviewHead = (& git -C $root rev-parse HEAD).Trim()
        $env:PR_BASE_SHA = $global:GitReviewBase = $base
        $global:GitReviewExpectedCount = 4
        & (Join-Path $script:HelperDirectory 'Invoke-PrReReviewInputExport.ps1')
        $index = Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json
        @($index.files).Count | Should -Be 4
        foreach ($path in @('binary.bin', 'mode.txt', 'link', 'submodule')) { @($index.files | Where-Object path -ceq $path).Count | Should -Be 1 }
        $binary = @($index.files | Where-Object path -ceq 'binary.bin')[0]
        (Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $binary.patchFile) -Raw) | Should -Match 'GIT binary patch'
        $mode = @($index.files | Where-Object path -ceq 'mode.txt')[0]
        (Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $mode.patchFile) -Raw) | Should -Match 'new mode 100755'
        $submodule = @($index.files | Where-Object path -ceq 'submodule')[0]
        (Get-Content -LiteralPath (Join-Path $env:REVIEW_INPUT_DIR $submodule.patchFile) -Raw) | Should -Match 'Subproject commit'
    }
}

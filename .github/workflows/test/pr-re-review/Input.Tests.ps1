#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

param([string]$GuardModulePath = (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'PrReReviewGuard.psm1'))

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'PrReReviewInput.psm1') -Force
    Import-Module $GuardModulePath -Force

    function New-ChangedFile {
        param([string]$Path, [string]$Status = 'modified', [AllowNull()]$Patch = "@@ -1 +1 @@`n-old`n+new")

        $file = [ordered]@{ filename = $Path; status = $Status; additions = 1; deletions = 1 }
        if ($null -ne $Patch) { $file.patch = $Patch }
        return [pscustomobject]$file
    }

    function Invoke-Export {
        param([object[]]$Files)

        $root = Join-Path $TestDrive ([guid]::NewGuid())
        $inputDirectory = Join-Path $root 'pr-review-input'
        $markersPath = Join-Path $root 'pr-re-review-input' 'markers.json'
        Export-PrReReviewInput -Files $Files -Repository 'Azure/azure-sdk-for-net' -HeadSha 'abc1234' -MergeBaseSha 'base1234' -InputDirectory $inputDirectory -MarkersPath $markersPath
        $list = Get-Content (Join-Path $inputDirectory 'files.json') -Raw | ConvertFrom-Json
        return [pscustomobject]@{
            ListText = Get-Content (Join-Path $inputDirectory 'files.json') -Raw
            Files = @($list.files)
            Markers = @((Get-Content $markersPath -Raw | ConvertFrom-Json).files)
            InputDirectory = $inputDirectory
            MarkersPath = $markersPath
            Read = { param($Entry) Get-Content (Join-Path $inputDirectory $Entry.patchFile) -Raw }.GetNewClosure()
        }
    }
}

Describe 'Export-PrReReviewInput' {
    It 'writes each changed file''s patch to its own file, ending with that file''s marker' {
        $export = Invoke-Export @(
            (New-ChangedFile 'sdk/widgets/Azure.Widgets/CHANGELOG.md' -Status 'added' -Patch "@@ -0,0 +1,3 @@`n+# Release History`n+`n+## 1.0.0-beta.1 (Unreleased)")
            (New-ChangedFile 'sdk/widgets/Azure.Widgets/src/WidgetClient.cs')
        )
        $export.Files.Count | Should -Be 2
        $export.Markers.Count | Should -Be 2
        foreach ($entry in $export.Files) {
            $marker = @($export.Markers | Where-Object path -ceq $entry.path)[0].marker
            ((& $export.Read $entry).TrimEnd() -split "`n")[-1] | Should -Match ([regex]::Escape($marker))
        }
        & $export.Read $export.Files[0] | Should -Match '\+## 1\.0\.0-beta\.1 \(Unreleased\)'
    }

    It 'gives every file a different marker and keeps all of them out of the agent''s file list' {
        $export = Invoke-Export @(1..20 | ForEach-Object { New-ChangedFile "src/File$_.cs" })
        @($export.Markers.marker | Select-Object -Unique).Count | Should -Be 20
        foreach ($marker in $export.Markers.marker) { $export.ListText.Contains($marker) | Should -BeFalse }
    }

    It 'exports the head-commit content when GitHub omits a file''s patch' {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent { "// full content of $Path at $HeadSha" }
        $export = Invoke-Export @(New-ChangedFile 'src/Generated/Big.cs' -Patch $null)
        & $export.Read $export.Files[0] | Should -Match '// full content of src/Generated/Big\.cs at abc1234'
    }

    It 'includes removed text as well as head content when a modified file has no patch' {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent {
            if ($HeadSha -eq 'abc1234') { '// new declaration' } else { '// deleted declaration' }
        }
        $export = Invoke-Export @(New-ChangedFile 'src/Changed.cs' -Status 'modified' -Patch $null)
        $inputText = & $export.Read $export.Files[0]
        $inputText | Should -Match '// new declaration'
        $inputText | Should -Match '// deleted declaration'
    }

    It 'uses the previous path at the merge base when a renamed file has no patch' {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent { "content of $Path at $HeadSha" }
        $file = New-ChangedFile 'src/New.cs' -Status 'renamed' -Patch $null
        $file | Add-Member -NotePropertyName previous_filename -NotePropertyValue 'src/Old.cs'
        $export = Invoke-Export @($file)
        $inputText = & $export.Read $export.Files[0]
        $inputText | Should -Match 'content of src/Old\.cs at base1234'
        $inputText | Should -Match 'content of src/New\.cs at abc1234'
    }

    It 'notes a rename with identical blobs instead of exporting both copies' {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent { throw 'unexpected content fetch' }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi { '{"sha":"1111111111111111111111111111111111111111"}' }
        $file = New-ChangedFile 'tests/Samples/Sample.cs' -Status 'renamed' -Patch $null
        $file.additions = 0
        $file.deletions = 0
        $file | Add-Member -NotePropertyName sha -NotePropertyValue '1111111111111111111111111111111111111111'
        $file | Add-Member -NotePropertyName previous_filename -NotePropertyValue 'tests/Generated/Samples/Sample.cs'
        $export = Invoke-Export @($file)
        $inputText = & $export.Read $export.Files[0]
        $inputText | Should -Match 'renamed from tests/Generated/Samples/Sample\.cs'
        $inputText | Should -Match 'identical content'
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 1 -Exactly -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/contents/tests/Generated/Samples/Sample.cs?ref=base1234' }
    }

    It 'exports both sides of a binary rename with different blobs and no line changes' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi { '{"sha":"1111111111111111111111111111111111111111"}' }
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent { if ($HeadSha -eq 'base1234') { '// deleted declaration' } else { $null } }
        $file = New-ChangedFile 'src/New.cs' -Status 'renamed' -Patch $null
        $file.additions = 0
        $file.deletions = 0
        $file | Add-Member -NotePropertyName sha -NotePropertyValue '2222222222222222222222222222222222222222'
        $file | Add-Member -NotePropertyName previous_filename -NotePropertyValue 'src/Old.cs'
        $export = Invoke-Export @($file)
        $inputText = & $export.Read $export.Files[0]
        $inputText | Should -Match '// deleted declaration'
        $inputText | Should -Match 'no text content at the head commit'
    }

    It 'fails if the old blob metadata cannot be fetched for a zero-line rename' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi { throw 'metadata unavailable' }
        $file = New-ChangedFile 'src/New.cs' -Status 'renamed' -Patch $null
        $file.additions = 0
        $file.deletions = 0
        $file | Add-Member -NotePropertyName sha -NotePropertyValue '2222222222222222222222222222222222222222'
        $file | Add-Member -NotePropertyName previous_filename -NotePropertyValue 'src/Old.cs'
        { Invoke-Export @($file) } | Should -Throw -ExpectedMessage '*metadata unavailable*'
    }

    It 'fails if the old content cannot be fetched for a missing modified patch' {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent {
            if ($HeadSha -eq 'base1234') { throw 'base content unavailable' }
            '// new declaration'
        }
        { Invoke-Export @(New-ChangedFile 'src/Changed.cs' -Status 'modified' -Patch $null) } |
            Should -Throw -ExpectedMessage '*base content unavailable*'
    }

    It 'fails if a renamed file has no previous path and no patch' {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent { '// new content' }
        { Invoke-Export @(New-ChangedFile 'src/New.cs' -Status 'renamed' -Patch $null) } |
            Should -Throw -ExpectedMessage '*previous path*'
    }

    It 'fails if a <Status> file has no patch and no merge base' -ForEach @(
        @{ Status = 'modified' }
        @{ Status = 'removed' }
    ) {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent { '// new content' }
        $root = Join-Path $TestDrive ([guid]::NewGuid())
        { Export-PrReReviewInput -Files @(New-ChangedFile 'a.cs' -Status $Status -Patch $null) -Repository 'Azure/azure-sdk-for-net' -HeadSha 'abc1234' -InputDirectory (Join-Path $root 'input') -MarkersPath (Join-Path $root 'markers.json') } |
            Should -Throw -ExpectedMessage '*merge base*unavailable*'
    }

    It 'still ends a file''s export with its marker when <Label>' -ForEach @(
        @{ Label = 'it has no text content at the head commit'; Status = 'modified' }
        @{ Label = 'a removed file has no text content at the merge base'; Status = 'removed' }
    ) {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent { $null }
        $export = Invoke-Export @(New-ChangedFile 'assets/logo.png' -Status $Status -Patch $null)
        ((& $export.Read $export.Files[0]).TrimEnd() -split "`n")[-1] | Should -Match ([regex]::Escape($export.Markers[0].marker))
    }

    It 'exports bounded parts for a long patch without losing a surrogate pair at a boundary' {
        $header = "# Review input 1/1: src/Long.cs (modified, +1 -1)`n"
        $patch = ('x' * (3999 - $header.Length)) + [char]::ConvertFromUtf32(0x1F600) + ('y' * 8000)
        $export = Invoke-Export @(New-ChangedFile 'src/Long.cs' -Patch $patch)
        $entry = $export.Files[0]
        $entry.readFiles.Count | Should -BeGreaterThan 1
        $marker = $export.Markers[0]
        $marker.chunks.Count | Should -Be $entry.readFiles.Count
        $reassembled = ''
        for ($i = 0; $i -lt $entry.readFiles.Count; $i++) {
            $part = [IO.File]::ReadAllText((Join-Path $export.InputDirectory $entry.readFiles[$i]))
            $part | Should -BeExactly $marker.chunks[$i].content
            $reassembled += $part.Substring($part.IndexOf("`n") + 1, $part.LastIndexOf("`n# End of part") - $part.IndexOf("`n") - 1)
        }
        $reassembled | Should -BeExactly (& $export.Read $entry)
    }

    It 'cuts a long patch into parts only at line boundaries' {
        $patch = (1..400 | ForEach-Object { "+    public string Property$_ { get; set; }" }) -join "`n"
        $export = Invoke-Export @(New-ChangedFile 'src/Long.cs' -Patch $patch)
        $parts = @($export.Files[0].readFiles | ForEach-Object { [IO.File]::ReadAllText((Join-Path $export.InputDirectory $_)) })
        $parts.Count | Should -BeGreaterThan 1
        foreach ($part in $parts | Select-Object -SkipLast 1) {
            $part | Should -Match "`n`n# End of part \[[0-9a-f]{16}\]`n$"
        }
    }

    It 'verifies the actual exported parts as complete reads and rejects a missing part' {
        $export = Invoke-Export @(New-ChangedFile 'src/Long.cs' -Patch ('a' * 10000))
        $events = @(foreach ($path in $export.Files[0].readFiles) {
            @{ type = 'tool.execution_complete'; data = @{ success = $true; result = @{ content = [IO.File]::ReadAllText((Join-Path $export.InputDirectory $path)) } } } |
                ConvertTo-Json -Depth 10 -Compress
        })
        $session = Join-Path $TestDrive 'parts.jsonl'
        $output = @{ items = @(@{ type = 'submit_pull_request_review' }) }
        [IO.File]::WriteAllLines($session, [string[]]$events)
        { Assert-PrReReviewReadCoverage $output $export.MarkersPath $session } | Should -Not -Throw
        [IO.File]::WriteAllLines($session, [string[]]@($events[0], $events[-1]))
        { Assert-PrReReviewReadCoverage $output $export.MarkersPath $session } | Should -Throw -ExpectedMessage '*0 of 1*src/Long.cs*'
    }

    It 'fails if fetching a missing-patch file returns an API error' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi { throw 'rate limited' }
        { Invoke-Export @(New-ChangedFile 'src/New.cs' -Status 'added' -Patch $null) } |
            Should -Throw -ExpectedMessage '*rate limited*'
    }

    It 'exports a removed file when its deletion patch is available' {
        $export = Invoke-Export @(New-ChangedFile 'src/Deleted.cs' -Status 'removed' -Patch "@@ -1 +0,0 @@`n-deleted")
        & $export.Read $export.Files[0] | Should -Match '(?m)^-deleted$'
    }

    It 'exports the merge-base content of a removed file whose patch GitHub omitted' {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent { "content of $Path at $HeadSha" }
        $export = Invoke-Export @(New-ChangedFile 'src/Deleted.cs' -Status 'removed' -Patch $null)
        & $export.Read $export.Files[0] | Should -Match 'content of src/Deleted\.cs at base1234'
    }

    It 'refuses to write the markers where the agent can read them' {
        $inputDirectory = Join-Path $TestDrive 'visible'
        { Export-PrReReviewInput -Files @(New-ChangedFile 'a.cs') -Repository 'Azure/azure-sdk-for-net' -HeadSha 'abc1234' -InputDirectory $inputDirectory -MarkersPath (Join-Path $inputDirectory 'markers.json') } |
            Should -Throw -ExpectedMessage '*outside*'
    }
}

Describe 'Get-PrReReviewHeadContent' {
    It 'distinguishes an empty file from a file containing NUL' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi { '' }
        $content = Get-PrReReviewHeadContent -Repository 'Azure/azure-sdk-for-net' -HeadSha 'abc1234' -Path 'empty.txt'
        $content | Should -BeExactly ''
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi { "abc$([char]0)def" }
        Get-PrReReviewHeadContent -Repository 'Azure/azure-sdk-for-net' -HeadSha 'abc1234' -Path 'binary.dat' | Should -BeNullOrEmpty
    }
}

Describe 'Get-PrReReviewPullRequestInput' {
    It 'collects every page of changed files' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"a.cs","status":"modified","patch":"+a"}],[{"filename":"b.cs","status":"added","patch":"+b"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') } {
            '{"changed_files":2,"head":{"sha":"abc1234"},"base":{"sha":"base"}}'
        }
        $pullRequest = Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'abc1234' -ExpectedBaseSha 'base'
        $pullRequest.HeadSha | Should -BeExactly 'abc1234'
        @($pullRequest.Files.filename) | Should -Be @('a.cs', 'b.cs')
    }

    It 'resolves the immutable merge base when a <Status> file has no patch' -ForEach @(
        @{ Status = 'modified' }
        @{ Status = 'removed' }
    ) {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            "[[{`"filename`":`"a.cs`",`"status`":`"$Status`"}]]"
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/compare/*' } {
            '{"merge_base_commit":{"sha":"0123456789012345678901234567890123456789"}}'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') -and -not ($Arguments -like '*/compare/*') } {
            '{"changed_files":1,"head":{"sha":"abc1234"},"base":{"sha":"base"}}'
        }
        $pullRequest = Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'abc1234' -ExpectedBaseSha 'base'
        $pullRequest.MergeBaseSha | Should -BeExactly '0123456789012345678901234567890123456789'
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 1 -Exactly -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/compare/base...abc1234?per_page=1' }
    }

    It 'fails when the comparison does not provide a valid merge base' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"a.cs","status":"modified"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/compare/*' } { '{"merge_base_commit":{"sha":"not-a-commit"}}' }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') -and -not ($Arguments -like '*/compare/*') } {
            '{"changed_files":1,"head":{"sha":"abc1234"},"base":{"sha":"base"}}'
        }
        { Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'abc1234' -ExpectedBaseSha 'base' } |
            Should -Throw -ExpectedMessage '*valid merge-base*'
    }

    It 'does not query the merge base for <Label> without a patch' -ForEach @(
        @{ Label = 'an added file'; File = '{"filename":"a.cs","status":"added"}' }
    ) {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            "[[$File]]"
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/compare/*' } { throw 'unexpected comparison' }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') -and -not ($Arguments -like '*/compare/*') } {
            '{"changed_files":1,"head":{"sha":"abc1234"},"base":{"sha":"base"}}'
        }
        $pullRequest = Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'abc1234' -ExpectedBaseSha 'base'
        $pullRequest.MergeBaseSha | Should -BeExactly ''
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 0 -Exactly -ParameterFilter { $Arguments -like '*/compare/*' }
    }

    It 'resolves the merge base for a rename with no patch or line changes' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"b.cs","previous_filename":"a.cs","status":"renamed","additions":0,"deletions":0}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/compare/*' } {
            '{"merge_base_commit":{"sha":"0123456789012345678901234567890123456789"}}'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') -and -not ($Arguments -like '*/compare/*') } {
            '{"changed_files":1,"head":{"sha":"abc1234"},"base":{"sha":"base"}}'
        }
        $pullRequest = Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'abc1234' -ExpectedBaseSha 'base'
        $pullRequest.MergeBaseSha | Should -BeExactly '0123456789012345678901234567890123456789'
    }

    It 'rejects a head that differs from the event head' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"a.cs","status":"modified","patch":"+a"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') } {
            '{"changed_files":1,"head":{"sha":"new"},"base":{"sha":"base"}}'
        }
        { Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'old' -ExpectedBaseSha 'base' } |
            Should -Throw -ExpectedMessage '*head*old*new*'
    }

    It 'rejects a <Label> changed while paginating even when the file count is unchanged' -ForEach @(
        @{ Label = 'head'; Head = 'new'; Base = 'base' }
        @{ Label = 'base'; Head = 'abc1234'; Base = 'new-base' }
    ) {
        $global:PrReReviewPaginated = $false
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            $global:PrReReviewPaginated = $true
            '[[{"filename":"a.cs","status":"modified","patch":"+a"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') } {
            if ($global:PrReReviewPaginated) { "{`"changed_files`":1,`"head`":{`"sha`":`"$Head`"},`"base`":{`"sha`":`"$Base`"}}" }
            else { '{"changed_files":1,"head":{"sha":"abc1234"},"base":{"sha":"base"}}' }
        }
        { Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'abc1234' -ExpectedBaseSha 'base' } |
            Should -Throw -ExpectedMessage '*changed while listing files*'
        Remove-Variable PrReReviewPaginated -Scope Global
    }

    It 'fails rather than export a partial list when GitHub lists fewer files than changed_files' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"a.cs","status":"modified","patch":"+a"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') } {
            '{"changed_files":2,"head":{"sha":"abc1234"},"base":{"sha":"base"}}'
        }
        { Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'abc1234' -ExpectedBaseSha 'base' } | Should -Throw -ExpectedMessage '*1 of*2*'
    }
}

Describe 'Invoke-PrReReviewInputExport.ps1' {
    BeforeEach {
        $script:PreviousExportEnvironment = @{}
        foreach ($envName in 'GITHUB_REPOSITORY', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'REVIEW_INPUT_DIR', 'REVIEW_INPUT_MARKERS') {
            $script:PreviousExportEnvironment[$envName] = [Environment]::GetEnvironmentVariable($envName)
        }
    }

    AfterEach {
        foreach ($envName in $script:PreviousExportEnvironment.Keys) {
            [Environment]::SetEnvironmentVariable($envName, $script:PreviousExportEnvironment[$envName])
        }
    }

    It 'exports the old API text when a binary modification has no patch or line counts' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs","status":"modified","sha":"2222222222222222222222222222222222222222","additions":0,"deletions":0}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/compare/*' } {
            '{"merge_base_commit":{"sha":"0123456789012345678901234567890123456789"}}'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/contents/*ref=abc1234' } { "binary$([char]0)content" }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/contents/*ref=0123456789012345678901234567890123456789' } { '// deleted declaration' }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' } {
            '{"changed_files":1,"head":{"sha":"abc1234"},"base":{"sha":"base"}}'
        }
        $root = Join-Path $TestDrive ([guid]::NewGuid())
        $env:GITHUB_REPOSITORY = 'Azure/azure-sdk-for-net'
        $env:PR_NUMBER = '1'
        $env:PR_HEAD_SHA = 'abc1234'
        $env:PR_BASE_SHA = 'base'
        $env:REVIEW_INPUT_DIR = Join-Path $root 'input'
        $env:REVIEW_INPUT_MARKERS = Join-Path $root 'private' 'markers.json'
        & (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'Invoke-PrReReviewInputExport.ps1')
        $files = (Get-Content (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json).files
        $text = Get-Content (Join-Path $env:REVIEW_INPUT_DIR $files[0].patchFile) -Raw
        $text | Should -Match '// deleted declaration'
        $text | Should -Match 'no text content at the head commit'
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 1 -Exactly -ParameterFilter { $Arguments -like '*/compare/*' }
    }

    It 'passes the resolved merge base to the exporter when a modified API patch is absent' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs","status":"modified","additions":1,"deletions":1}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/compare/*' } {
            '{"merge_base_commit":{"sha":"0123456789012345678901234567890123456789"}}'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/contents/*ref=abc1234' } { '// new declaration' }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/contents/*ref=0123456789012345678901234567890123456789' } { '// deleted declaration' }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' } {
            '{"changed_files":1,"head":{"sha":"abc1234"},"base":{"sha":"base"}}'
        }
        $root = Join-Path $TestDrive ([guid]::NewGuid())
        $env:GITHUB_REPOSITORY = 'Azure/azure-sdk-for-net'
        $env:PR_NUMBER = '1'
        $env:PR_HEAD_SHA = 'abc1234'
        $env:PR_BASE_SHA = 'base'
        $env:REVIEW_INPUT_DIR = Join-Path $root 'input'
        $env:REVIEW_INPUT_MARKERS = Join-Path $root 'private' 'markers.json'
        & (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'Invoke-PrReReviewInputExport.ps1')
        $files = (Get-Content (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json).files
        $text = Get-Content (Join-Path $env:REVIEW_INPUT_DIR $files[0].patchFile) -Raw
        $text | Should -Match '// deleted declaration'
        $text | Should -Match '// new declaration'
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 1 -Exactly -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/contents/sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs?ref=0123456789012345678901234567890123456789' }
    }
}

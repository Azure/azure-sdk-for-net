#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewInput.psm1') -Force

    function New-ApiChangedFile {
        param(
            [string]$Path = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs',
            [string]$Status = 'modified',
            [AllowNull()]$Patch = "@@ -1 +1 @@`n-old`n+new",
            [string]$PreviousPath = ''
        )
        [pscustomobject]@{ filename = $Path; status = $Status; patch = $Patch; additions = 1; deletions = 1; previous_filename = $PreviousPath }
    }

    function Invoke-ApiExport {
        param([AllowEmptyCollection()][object[]]$Files, [hashtable]$Options = @{})

        $root = Join-Path $TestDrive ([guid]::NewGuid())
        $inputDirectory = Join-Path $root 'input'
        $markersPath = Join-Path $root 'private' 'markers.json'
        Export-PrReReviewInput -Files $Files -Repository 'Azure/azure-sdk-for-net' -HeadSha 'head' -InputDirectory $inputDirectory -MarkersPath $markersPath -ApiOnly @Options
        $index = Get-Content (Join-Path $inputDirectory 'files.json') -Raw | ConvertFrom-Json
        [pscustomobject]@{
            Index = $index
            IndexText = Get-Content (Join-Path $inputDirectory 'files.json') -Raw
            Markers = Get-Content $markersPath -Raw | ConvertFrom-Json
            Sources = Get-Content $index.sourceFilesPath -Raw | ConvertFrom-Json
            SourceText = Get-Content $index.sourceFilesPath -Raw
            InputDirectory = $inputDirectory
        }
    }
}

Describe 'API-only wrapper scope regression' {
    BeforeEach {
        $script:PreviousApiEnvironment = @{}
        foreach ($name in 'GITHUB_REPOSITORY', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'REVIEW_INPUT_DIR', 'REVIEW_INPUT_MARKERS') {
            $script:PreviousApiEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
        }
        $env:GITHUB_REPOSITORY = 'Azure/azure-sdk-for-net'
        $env:PR_NUMBER = '1'
        $env:PR_HEAD_SHA = 'head'
        $env:PR_BASE_SHA = 'base'
        $root = Join-Path $TestDrive ([guid]::NewGuid())
        $env:REVIEW_INPUT_DIR = Join-Path $root 'input'
        $env:REVIEW_INPUT_MARKERS = Join-Path $root 'private' 'markers.json'
    }

    AfterEach {
        foreach ($name in $script:PreviousApiEnvironment.Keys) {
            [Environment]::SetEnvironmentVariable($name, $script:PreviousApiEnvironment[$name])
        }
    }

    It 'excludes the huge unrelated workflow patch and source patch before exporting model input' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            $files = @(
                @{ filename = '.github/workflows/generated-lock.yml'; status = 'modified'; patch = ('+irrelevant-workflow-lock' * 52000); additions = 1; deletions = 1 }
                @{ filename = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs'; status = 'modified'; patch = "@@ -1 +1 @@`n-old api`n+new api"; additions = 1; deletions = 1 }
                @{ filename = 'sdk/widgets/Azure.Widgets/src/Generated/UnrelatedName.cs'; status = 'modified'; patch = "@@ -4,2 +4,3 @@`n same`n-old`n+new`n+new2"; additions = 2; deletions = 1 }
            )
            ConvertTo-Json -InputObject (,$files) -Depth 5 -Compress
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') } {
            '{"changed_files":3,"head":{"sha":"head"},"base":{"sha":"base"}}'
        }
        & (Join-Path $PSScriptRoot 'Invoke-PrReReviewInputExport.ps1')
        $index = Get-Content (Join-Path $env:REVIEW_INPUT_DIR 'files.json') -Raw | ConvertFrom-Json
        @($index.files.path) | Should -Be @('sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs')
        @(Get-ChildItem (Join-Path $env:REVIEW_INPUT_DIR 'patches') -File).Count | Should -Be 1
        $index.scope | Should -BeExactly 'api'
        $index.prChangedFiles | Should -Be 3
        $sources = Get-Content $index.sourceFilesPath -Raw | ConvertFrom-Json
        @($sources.files.path) | Should -Be @('sdk/widgets/Azure.Widgets/src/Generated/UnrelatedName.cs')
        $sources.files[0].lineRanges[0].start | Should -Be 4
        $sources.files[0].lineRanges[0].end | Should -Be 6
    }
}

Describe 'Test-PrReReviewApiPath' {
    It 'accepts the API listing <Path> without restricting TFMs or package naming' -ForEach @(
        @{ Path = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.netstandard2.0.cs' }
        @{ Path = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs' }
        @{ Path = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.net9.0.cs' }
        @{ Path = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs' }
        @{ Path = 'sdk/legacy/Microsoft.Azure.Management.Widgets/api/Microsoft.Azure.Management.Widgets.cs' }
    ) {
        Test-PrReReviewApiPath -Path $Path | Should -BeTrue
    }

    It 'rejects non-listing, incorrectly cased or unsafe path <Label>' -ForEach @(
        @{ Label = 'source'; Path = 'sdk/widgets/Azure.Widgets/src/Azure.Widgets.cs' }
        @{ Label = 'nested API file'; Path = 'sdk/widgets/Azure.Widgets/api/nested/Azure.Widgets.cs' }
        @{ Label = 'non C#'; Path = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.txt' }
        @{ Label = 'SDK case'; Path = 'SDK/widgets/Azure.Widgets/api/Azure.Widgets.cs' }
        @{ Label = 'API case'; Path = 'sdk/widgets/Azure.Widgets/Api/Azure.Widgets.cs' }
        @{ Label = 'extension case'; Path = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.CS' }
        @{ Label = 'outside sdk'; Path = 'tests/widgets/api/Azure.Widgets.cs' }
        @{ Label = 'absolute'; Path = '/sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs' }
        @{ Label = 'drive'; Path = 'C:/sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs' }
        @{ Label = 'backslash'; Path = 'sdk/widgets\Azure.Widgets/api/Azure.Widgets.cs' }
        @{ Label = 'UNC'; Path = '\\host/sdk/widgets/api/Azure.Widgets.cs' }
        @{ Label = 'parent'; Path = 'sdk/widgets/../Azure.Widgets/api/Azure.Widgets.cs' }
        @{ Label = 'dot'; Path = 'sdk/widgets/./Azure.Widgets/api/Azure.Widgets.cs' }
        @{ Label = 'empty segment'; Path = 'sdk//Azure.Widgets/api/Azure.Widgets.cs' }
        @{ Label = 'NUL'; Path = "sdk/widgets/Azure.Widgets/api/Bad$([char]0).cs" }
        @{ Label = 'newline'; Path = "sdk/widgets/Azure.Widgets/api/Bad`n.cs" }
        @{ Label = 'tab'; Path = "sdk/widgets/Azure.Widgets/api/Bad`t.cs" }
        @{ Label = 'trailing newline'; Path = "sdk/widgets/Azure.Widgets/api/Bad.cs`n" }
        @{ Label = 'empty'; Path = '' }
        @{ Label = 'null'; Path = $null }
    ) {
        Test-PrReReviewApiPath -Path $Path | Should -BeFalse
    }
}

Describe 'Get-PrReReviewApiScope selection and source allowlist' {
    It 'preserves input order and original metadata for adds, removals, all TFMs and renames both ways' {
        $files = @(
            (New-ApiChangedFile -Path '.github/workflows/lock.yml')
            (New-ApiChangedFile -Status 'added')
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.netstandard2.0.cs' -Status 'removed')
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.net9.0.cs')
            (New-ApiChangedFile -Path 'docs/OldListing.cs' -Status 'renamed' -PreviousPath 'sdk/widgets/Azure.Widgets/api/Old.cs')
            (New-ApiChangedFile -Path 'sdk/legacy/Microsoft.Azure.Management.Widgets/api/Microsoft.Azure.Management.Widgets.cs' -Status 'renamed' -PreviousPath 'docs/Listing.cs')
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/api/New.cs' -Status 'renamed' -PreviousPath 'sdk/old/Azure.Old/api/Old.cs')
        )
        $scope = Get-PrReReviewApiScope -Files $files
        @($scope.ApiFiles.filename) | Should -Be @($files[1..6].filename)
        $scope.ApiFiles.Count | Should -Be 6
        for ($i = 0; $i -lt $scope.ApiFiles.Count; $i++) {
            [object]::ReferenceEquals($scope.ApiFiles[$i], $files[$i + 1]) | Should -BeTrue
        }
        $scope.InlineTargets.Count | Should -Be 0
        $scope.ApiFiles | Should -BeOfType ([pscustomobject])
    }

    It 'uses package path bounds, not namespace or API type-name guesses, for generated and custom sources' {
        $files = @(
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/Generated/NotAnApiType.cs')
            (New-ApiChangedFile)
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/Customization/AnotherName.cs')
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/tests/Widget.cs')
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.WidgetsExtra/src/Widget.cs')
            (New-ApiChangedFile -Path 'sdk/other/Azure.Other/src/Widget.cs')
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/notes.txt')
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/Src/Widget.cs')
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/Widget.CS')
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/Widget.cs')
        )
        $scope = Get-PrReReviewApiScope -Files $files
        @($scope.InlineTargets.path) | Should -Be @($files[0].filename, $files[2].filename)
        @($scope.InlineTargets[0].Keys) | Should -Be @('path', 'lineRanges')
        $scope.InlineTargets[0].lineRanges[0].start | Should -Be 1
        $scope.InlineTargets[0].lineRanges[0].end | Should -Be 1
    }

    It 'includes changed sources in both API package roots after a cross-package rename' {
        $scope = Get-PrReReviewApiScope -Files @(
            (New-ApiChangedFile -Path 'sdk/new/Microsoft.New/api/New.cs' -Status 'renamed' -PreviousPath 'sdk/old/Microsoft.Old/api/Old.cs')
            (New-ApiChangedFile -Path 'sdk/old/Microsoft.Old/src/Generated/Old.cs')
            (New-ApiChangedFile -Path 'sdk/new/Microsoft.New/src/Custom.cs')
        )
        @($scope.InlineTargets.path) | Should -Be @('sdk/old/Microsoft.Old/src/Generated/Old.cs', 'sdk/new/Microsoft.New/src/Custom.cs')
    }

    It 'returns actual empty arrays when there are <Label>' -ForEach @(
        @{ Label = 'no files'; Files = @() }
        @{ Label = 'no API changes'; Files = @([pscustomobject]@{ filename = 'sdk/widgets/Azure.Widgets/src/OnlySource.cs' }) }
    ) {
        $scope = Get-PrReReviewApiScope -Files $Files
        $scope.ApiFiles | Should -HaveCount 0
        $scope.InlineTargets | Should -HaveCount 0
        $scope.ApiFiles.GetType().Name | Should -BeExactly 'Object[]'
        $scope.InlineTargets.GetType().Name | Should -BeExactly 'Object[]'
    }

    It 'rejects a duplicate API path' {
        { Get-PrReReviewApiScope -Files @((New-ApiChangedFile), (New-ApiChangedFile)) } | Should -Throw '*Duplicate API path*'
    }

    It 'rejects a duplicate source path' {
        { Get-PrReReviewApiScope -Files @((New-ApiChangedFile), (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/A.cs'), (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/A.cs')) } |
            Should -Throw '*Duplicate source path*'
    }

    It 'rejects unsafe paths used by a selected rename <Label>' -ForEach @(
        @{ Label = 'new path'; Path = '../docs/Listing.cs'; Previous = 'sdk/widgets/Azure.Widgets/api/Old.cs' }
        @{ Label = 'previous path'; Path = 'sdk/widgets/Azure.Widgets/api/New.cs'; Previous = '../docs/Listing.cs' }
    ) {
        { Get-PrReReviewApiScope -Files @(New-ApiChangedFile -Path $Path -PreviousPath $Previous -Status 'renamed') } | Should -Throw '*invalid repository-relative path*'
    }

    It 'rejects unsafe source path <Path>' -ForEach @(
        @{ Path = 'sdk/widgets/Azure.Widgets/src/../Other.cs' }
        @{ Path = 'sdk/widgets/Azure.Widgets/src/Bad\File.cs' }
        @{ Path = "sdk/widgets/Azure.Widgets/src/Bad`n.cs" }
    ) {
        { Get-PrReReviewApiScope -Files @((New-ApiChangedFile), (New-ApiChangedFile -Path $Path)) } | Should -Throw '*Invalid source path*'
    }
}

Describe 'Source new-side hunk ranges' {
    It 'keeps separate new-side spans including context, omitted counts, CRLF and no-newline annotations' {
        $patch = "@@ -4,2 +7,3 @@ method`r`n same`r`n-old`r`n+new`r`n+extra`r`n@@ -12 +20 @@`r`n-old2`r`n\ No newline at end of file`r`n+new2`r`n\ No newline at end of file`r`n"
        $scope = Get-PrReReviewApiScope -Files @((New-ApiChangedFile), (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/A.cs' -Patch $patch))
        $ranges = $scope.InlineTargets[0].lineRanges
        $ranges.Count | Should -Be 2
        $ranges[0].start | Should -Be 7
        $ranges[0].end | Should -Be 9
        $ranges[1].start | Should -Be 20
        $ranges[1].end | Should -Be 20
        $ranges[0].start | Should -BeOfType ([int])
        $ranges[0].end | Should -BeOfType ([int])
    }

    It 'has no invented lines for <Label>' -ForEach @(
        @{ Label = 'null patch'; Patch = $null }
        @{ Label = 'empty patch'; Patch = '' }
        @{ Label = 'non-text patch'; Patch = @{} }
        @{ Label = 'no hunks'; Patch = 'not a diff' }
        @{ Label = 'malformed header'; Patch = "@@ -1 +oops @@`n-old`n+new" }
        @{ Label = 'truncated body'; Patch = "@@ -1 +1,2 @@`n-old`n+new" }
        @{ Label = 'extra body lines'; Patch = "@@ -1 +1 @@`n-old`n+new`n+extra" }
        @{ Label = 'invalid body'; Patch = "@@ -1 +1 @@`nold`nnew" }
        @{ Label = 'mixed valid and malformed hunks'; Patch = "@@ -1 +1 @@`n-old`n+new`n@@ bad" }
        @{ Label = 'negative position'; Patch = "@@ -1 +-1 @@`n-old`n+new" }
        @{ Label = 'zero new position with positive count'; Patch = "@@ -1 +0 @@`n-old`n+new" }
        @{ Label = 'zero old position with positive count'; Patch = "@@ -0 +1 @@`n-old`n+new" }
        @{ Label = 'overflowed position'; Patch = "@@ -1 +2147483648 @@`n-old`n+new" }
        @{ Label = 'overflowed range'; Patch = "@@ -1 +2147483647,2 @@`n-old`n+new`n+extra" }
        @{ Label = 'whole file deletion ending at line zero'; Patch = "@@ -1,2 +0,0 @@`n-old`n-old2" }
        @{ Label = 'deletion hunk with nonzero new start'; Patch = "@@ -10,2 +9,0 @@`n-old`n-old2" }
    ) {
        $scope = Get-PrReReviewApiScope -Files @((New-ApiChangedFile), (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/A.cs' -Patch $Patch))
        $scope.InlineTargets.Count | Should -Be 1
        $scope.InlineTargets[0].lineRanges | Should -HaveCount 0
        $scope.InlineTargets[0].lineRanges.GetType().Name | Should -BeExactly 'Object[]'
    }

    It 'preserves valid new-side spans next to a deletion-only hunk' {
        $scope = Get-PrReReviewApiScope -Files @((New-ApiChangedFile), (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/A.cs' -Patch "@@ -1,2 +0,0 @@`n-old`n-old2`n@@ -8 +6 @@`n-old3`n+new"))
        $scope.InlineTargets[0].lineRanges.Count | Should -Be 1
        $scope.InlineTargets[0].lineRanges[0].start | Should -Be 6
        $scope.InlineTargets[0].lineRanges[0].end | Should -Be 6
    }

    It 'allows new files without inventing an old-side line' {
        $scope = Get-PrReReviewApiScope -Files @((New-ApiChangedFile), (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/A.cs' -Status 'added' -Patch "@@ -0,0 +1,2 @@`n+new`n+extra"))
        $scope.InlineTargets[0].lineRanges[0].start | Should -Be 1
        $scope.InlineTargets[0].lineRanges[0].end | Should -Be 2
    }
}

Describe 'API-only PR input validation and fallback scope' {
    BeforeEach {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' } {
            '{"changed_files":3,"head":{"sha":"head"},"base":{"sha":"base"}}'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/compare/*' } { throw 'unexpected unrelated comparison' }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/contents/*' } { throw 'unexpected source content fetch' }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"package-lock.json","status":"modified"}],[{"filename":"sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs","status":"modified","patch":"@@ -1 +1 @@\n-old\n+new"},{"filename":"sdk/widgets/Azure.Widgets/src/Generated/Huge.cs","status":"modified"}]]'
        }
    }

    It 'validates every page and retains the full PR count while excluding non-API missing patches before fallback' {
        $input = Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'head' -ExpectedBaseSha 'base' -ApiOnly
        $input.PrChangedFiles | Should -Be 3
        $input.PrChangedFiles | Should -BeOfType ([int])
        @($input.Files.filename) | Should -Be @('sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs')
        $input.MergeBaseSha | Should -BeExactly ''
        $input.InlineTargets.Count | Should -Be 1
        $input.InlineTargets[0].lineRanges | Should -HaveCount 0
        $export = Invoke-ApiExport -Files $input.Files -Options @{ PrChangedFiles = $input.PrChangedFiles; InlineTargets = $input.InlineTargets }
        $export.Index.prChangedFiles | Should -Be 3
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 1 -Exactly -ParameterFilter { $Arguments -contains '--paginate' -and $Arguments -contains '--slurp' }
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 2 -Exactly -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' }
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 0 -Exactly -ParameterFilter { $Arguments -like '*/compare/*' -or $Arguments -like '*/contents/*' }
    }

    It 'keeps the existing missing-patch fallback decisions for generic callers' {
        { Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'head' -ExpectedBaseSha 'base' } |
            Should -Throw '*unexpected unrelated comparison*'
    }

    It 'still rejects a full PR count mismatch rather than substituting the selected count' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' } {
            '{"changed_files":4,"head":{"sha":"head"},"base":{"sha":"base"}}'
        }
        { Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'head' -ExpectedBaseSha 'base' -ApiOnly } | Should -Throw '*3 of*4*'
    }

    It 'rejects a stale initial <Label> even in an empty API scope' -ForEach @(
        @{ Label = 'head'; Head = 'other'; Base = 'base' }
        @{ Label = 'base'; Head = 'head'; Base = 'other' }
    ) {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' } {
            "{`"changed_files`":3,`"head`":{`"sha`":`"$Head`"},`"base`":{`"sha`":`"$Base`"}}"
        }
        { Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'head' -ExpectedBaseSha 'base' -ApiOnly } | Should -Throw '*no longer matches*'
    }

    It 'rejects a <Label> changed while paginating before selecting an empty API scope' -ForEach @(
        @{ Label = 'head'; Head = 'other'; Base = 'base' }
        @{ Label = 'base'; Head = 'head'; Base = 'other' }
    ) {
        $global:ApiInputListed = $false
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            $global:ApiInputListed = $true
            '[[{"filename":"lock.json","status":"modified"},{"filename":"workflow.yml","status":"modified"},{"filename":"README.md","status":"modified"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' } {
            if ($global:ApiInputListed) { "{`"changed_files`":3,`"head`":{`"sha`":`"$Head`"},`"base`":{`"sha`":`"$Base`"}}" }
            else { '{"changed_files":3,"head":{"sha":"head"},"base":{"sha":"base"}}' }
        }
        try {
            { Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'head' -ExpectedBaseSha 'base' -ApiOnly } | Should -Throw '*changed while listing files*'
        } finally { Remove-Variable ApiInputListed -Scope Global }
    }

    It 'resolves a merge base for a selected <Status> API change without a patch' -ForEach @(
        @{ Status = 'modified' }
        @{ Status = 'removed' }
        @{ Status = 'renamed' }
    ) {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' } {
            '{"changed_files":1,"head":{"sha":"head"},"base":{"sha":"base"}}'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            "[[{`"filename`":`"sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs`",`"status`":`"$Status`"}]]"
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/compare/*' } {
            '{"merge_base_commit":{"sha":"0123456789012345678901234567890123456789"}}'
        }
        $input = Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'head' -ExpectedBaseSha 'base' -ApiOnly
        $input.MergeBaseSha | Should -BeExactly '0123456789012345678901234567890123456789'
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 1 -Exactly -ParameterFilter { $Arguments -like '*/compare/*' }
    }

    It 'resolves a merge base for a missing patch on a rename out of the API directory' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' } {
            '{"changed_files":1,"head":{"sha":"head"},"base":{"sha":"base"}}'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"docs/OldListing.cs","previous_filename":"sdk/widgets/Azure.Widgets/api/Old.cs","status":"renamed"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/compare/*' } {
            '{"merge_base_commit":{"sha":"0123456789012345678901234567890123456789"}}'
        }
        $input = Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'head' -ExpectedBaseSha 'base' -ApiOnly
        $input.Files.Count | Should -Be 1
        $input.Files[0].filename | Should -BeExactly 'docs/OldListing.cs'
        $input.MergeBaseSha | Should -BeExactly '0123456789012345678901234567890123456789'
    }

    It 'does not resolve a merge base for a selected added API listing' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -contains 'repos/Azure/azure-sdk-for-net/pulls/1' } {
            '{"changed_files":1,"head":{"sha":"head"},"base":{"sha":"base"}}'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs","status":"added"}]]'
        }
        $input = Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'head' -ExpectedBaseSha 'base' -ApiOnly
        $input.MergeBaseSha | Should -BeExactly ''
        $input.Files.Count | Should -Be 1
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 0 -Exactly -ParameterFilter { $Arguments -like '*/compare/*' }
    }

    It 'returns a valid empty scope without fallback when the entire PR has no API changes' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"lock.json","status":"modified"},{"filename":"workflow.yml","status":"modified"},{"filename":"README.md","status":"modified"}]]'
        }
        $input = Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 -ExpectedHeadSha 'head' -ExpectedBaseSha 'base' -ApiOnly
        $input.PrChangedFiles | Should -Be 3
        $input.Files | Should -HaveCount 0
        $input.InlineTargets | Should -HaveCount 0
        $input.MergeBaseSha | Should -BeExactly ''
        Assert-MockCalled Invoke-PrReReviewGhApi -ModuleName PrReReviewInput -Times 0 -Exactly -ParameterFilter { $Arguments -like '*/compare/*' }
    }
}

Describe 'API-only export artifacts and generic compatibility' {
    It 'reselects API changes from a full input and exports only metadata in a separate source index' {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent { throw 'unrelated missing patch must not fetch content' }
        $files = @(
            (New-ApiChangedFile -Path 'package-lock.json' -Patch $null)
            (New-ApiChangedFile)
            (New-ApiChangedFile -Path 'sdk/widgets/Azure.Widgets/src/Generated/NotFromNamespace.cs' -Patch "@@ -1 +1 @@`n-SECRET OLD SOURCE`n+SECRET NEW SOURCE")
        )
        $export = Invoke-ApiExport -Files $files
        $export.Index.scope | Should -BeExactly 'api'
        $export.Index.headSha | Should -BeExactly 'head'
        $export.Index.prChangedFiles | Should -Be 3
        @($export.Index.files.path) | Should -Be @($files[1].filename)
        $export.Markers.scope | Should -BeExactly 'api'
        $export.Markers.headSha | Should -BeExactly 'head'
        @($export.Markers.files.path) | Should -Be @($files[1].filename)
        [IO.Path]::IsPathFullyQualified($export.Index.sourceFilesPath) | Should -BeTrue
        $export.Index.sourceFilesPath | Should -BeExactly (Join-Path $export.InputDirectory 'source-files.json')
        $export.Sources.headSha | Should -BeExactly 'head'
        @($export.Sources.files.path) | Should -Be @($files[2].filename)
        @($export.Sources.files[0].PSObject.Properties.Name) | Should -Be @('path', 'lineRanges')
        $export.SourceText | Should -Not -Match 'SECRET|patch|body'
        $export.IndexText | Should -Not -Match 'NotFromNamespace|lineRanges|SECRET'
        Assert-MockCalled Get-PrReReviewHeadContent -ModuleName PrReReviewInput -Times 0 -Exactly
    }

    It 'accepts supplied targets without exposing any additional target or range properties' {
        $target = @{ path = 'sdk/widgets/Azure.Widgets/src/Custom.cs'; patch = 'secret'; body = 'secret'; lineRanges = @(@{ start = 10; end = 12; body = 'secret' }) }
        $export = Invoke-ApiExport -Files @(New-ApiChangedFile) -Options @{ PrChangedFiles = 1001; InlineTargets = @($target) }
        $export.Index.prChangedFiles | Should -Be 1001
        $export.Sources.files[0].lineRanges[0].start | Should -Be 10
        $export.Sources.files[0].lineRanges[0].end | Should -Be 12
        $export.SourceText | Should -Not -Match 'secret|patch|body'
    }

    It 'accepts integral ranges deserialized from the metadata index' {
        $target = '{"path":"sdk/widgets/Azure.Widgets/src/Custom.cs","lineRanges":[{"start":10,"end":12}]}' | ConvertFrom-Json
        $export = Invoke-ApiExport -Files @(New-ApiChangedFile) -Options @{ InlineTargets = @($target) }
        $export.Sources.files[0].lineRanges[0].start | Should -Be 10
        $export.Sources.files[0].lineRanges[0].end | Should -Be 12
    }

    It 'does not frontload or cap a large source allowlist' {
        $targets = @(1..1000 | ForEach-Object { @{ path = "sdk/widgets/Azure.Widgets/src/Generated/File$_.cs"; lineRanges = @() } })
        $export = Invoke-ApiExport -Files @(New-ApiChangedFile) -Options @{ PrChangedFiles = 1001; InlineTargets = $targets }
        $export.Sources.files.Count | Should -Be 1000
        $export.IndexText | Should -Not -Match 'Generated/File|lineRanges'
        @($export.Index.files).Count | Should -Be 1
    }

    It 'writes valid empty API indexes and marker arrays for <Label>' -ForEach @(
        @{ Label = 'a non-API PR'; Empty = $false }
        @{ Label = 'an empty file list'; Empty = $true }
    ) {
        $files = @()
        if (!$Empty) { $files = @(New-ApiChangedFile -Path 'README.md' -Patch $null) }
        $export = Invoke-ApiExport -Files $files -Options @{ PrChangedFiles = 5 }
        $export.Index.scope | Should -BeExactly 'api'
        $export.Index.prChangedFiles | Should -Be 5
        $export.Index.files | Should -HaveCount 0
        $export.Markers.scope | Should -BeExactly 'api'
        $export.Markers.files | Should -HaveCount 0
        $export.Sources.files | Should -HaveCount 0
        @(Get-ChildItem (Join-Path $export.InputDirectory 'patches') -File).Count | Should -Be 0
    }

    It 'still rejects a missing file argument rather than interpreting it as an empty scope' {
        { Invoke-ApiExport -Files $null } | Should -Throw
    }

    It 'rejects impossible full PR counts' {
        { Invoke-ApiExport -Files @(New-ApiChangedFile) -Options @{ PrChangedFiles = 0 } } | Should -Throw '*full PR changed-file count*'
    }

    It 'does not accept a selected-only count when a full file list was supplied' {
        { Invoke-ApiExport -Files @((New-ApiChangedFile), (New-ApiChangedFile -Path 'README.md')) -Options @{ PrChangedFiles = 1 } } |
            Should -Throw '*full PR changed-file count*'
    }

    It 'rejects duplicate supplied inline targets' {
        $target = @{ path = 'sdk/widgets/Azure.Widgets/src/Custom.cs'; lineRanges = @() }
        { Invoke-ApiExport -Files @(New-ApiChangedFile) -Options @{ InlineTargets = @($target, $target) } } | Should -Throw '*Duplicate inline target*'
    }

    It 'rejects supplied targets outside valid source scope <Path>' -ForEach @(
        @{ Path = 'sdk/other/Azure.Other/src/A.cs' }
        @{ Path = 'sdk/widgets/Azure.Widgets/tests/A.cs' }
        @{ Path = 'sdk/widgets/Azure.Widgets/api/A.cs' }
        @{ Path = 'sdk/widgets/Azure.Widgets/src/../A.cs' }
        @{ Path = '/sdk/widgets/Azure.Widgets/src/A.cs' }
        @{ Path = 'sdk/widgets/Azure.Widgets/src/Bad\A.cs' }
    ) {
        { Invoke-ApiExport -Files @(New-ApiChangedFile) -Options @{ InlineTargets = @(@{ path = $Path; lineRanges = @() }) } } | Should -Throw '*valid source path*'
    }

    It 'rejects invented or invalid supplied range <Label>' -ForEach @(
        @{ Label = 'line zero'; Start = 0; End = 1 }
        @{ Label = 'reversed'; Start = 5; End = 4 }
        @{ Label = 'fractional'; Start = 1.5; End = 4 }
        @{ Label = 'missing'; Start = $null; End = $null }
        @{ Label = 'overflow'; Start = 1; End = [long]2147483648 }
    ) {
        $target = @{ path = 'sdk/widgets/Azure.Widgets/src/A.cs'; lineRanges = @(@{ start = $Start; end = $End }) }
        { Invoke-ApiExport -Files @(New-ApiChangedFile) -Options @{ InlineTargets = @($target) } } | Should -Throw '*Invalid inline line range*'
    }

    It 'preserves API rename-out metadata rather than dropping the removal' {
        $file = New-ApiChangedFile -Path 'docs/OldListing.cs' -Status 'renamed' -PreviousPath 'sdk/widgets/Azure.Widgets/api/Old.cs'
        $export = Invoke-ApiExport -Files @($file)
        $export.Index.files[0].path | Should -BeExactly 'docs/OldListing.cs'
        $export.Index.files[0].previousPath | Should -BeExactly 'sdk/widgets/Azure.Widgets/api/Old.cs'
        $export.Markers.files[0].path | Should -BeExactly 'docs/OldListing.cs'
    }

    It 'preserves patch text, bounded chunk reconstruction and private markers in API mode' {
        $patch = ('+line ' * 900) + [char]::ConvertFromUtf32(0x1F600) + "`n" + ('+line2' * 900)
        $export = Invoke-ApiExport -Files @(New-ApiChangedFile -Patch $patch)
        $entry = $export.Index.files[0]
        $text = [IO.File]::ReadAllText((Join-Path $export.InputDirectory $entry.patchFile))
        $text | Should -Match ([regex]::Escape($patch))
        $entry.readFiles.Count | Should -BeGreaterThan 1
        $marker = $export.Markers.files[0]
        $export.IndexText.Contains($marker.marker) | Should -BeFalse
        $export.SourceText.Contains($marker.marker) | Should -BeFalse
        $reassembled = ''
        for ($i = 0; $i -lt $entry.readFiles.Count; $i++) {
            $part = [IO.File]::ReadAllText((Join-Path $export.InputDirectory $entry.readFiles[$i]))
            $part | Should -BeExactly $marker.chunks[$i].content
            $body = $part.Substring($part.IndexOf("`n") + 1, $part.LastIndexOf("`n# End of part") - $part.IndexOf("`n") - 1)
            $body.Length | Should -BeLessOrEqual 4000
            $reassembled += $body
        }
        $reassembled | Should -BeExactly $text
        ($text.TrimEnd() -split "`n")[-1] | Should -Match ([regex]::Escape($marker.marker))
    }

    It 'does not add API-only artifact properties for generic callers, including existing empty behavior' {
        foreach ($files in @(@((New-ApiChangedFile -Path '.github/workflows/test.yml')), @())) {
            $root = Join-Path $TestDrive ([guid]::NewGuid())
            Export-PrReReviewInput -Files $files -Repository 'Azure/azure-sdk-for-net' -HeadSha 'head' -InputDirectory (Join-Path $root 'input') -MarkersPath (Join-Path $root 'markers.json')
            $index = Get-Content (Join-Path $root 'input/files.json') -Raw | ConvertFrom-Json
            $markers = Get-Content (Join-Path $root 'markers.json') -Raw | ConvertFrom-Json
            @($index.PSObject.Properties.Name) | Should -Be @('headSha', 'files')
            @($markers.PSObject.Properties.Name) | Should -Be @('headSha', 'files')
            @($index.files).Count | Should -Be $files.Count
            Test-Path (Join-Path $root 'input/source-files.json') | Should -BeFalse
        }
    }
}

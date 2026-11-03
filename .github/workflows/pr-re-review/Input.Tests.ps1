#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewInput.psm1') -Force

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
        Export-PrReReviewInput -Files $Files -Repository 'Azure/azure-sdk-for-net' -HeadSha 'abc1234' -InputDirectory $inputDirectory -MarkersPath $markersPath
        $list = Get-Content (Join-Path $inputDirectory 'files.json') -Raw | ConvertFrom-Json
        return [pscustomobject]@{
            ListText = Get-Content (Join-Path $inputDirectory 'files.json') -Raw
            Files = @($list.files)
            Markers = @((Get-Content $markersPath -Raw | ConvertFrom-Json).files)
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

    It 'still ends a file''s export with its marker when <Label>' -ForEach @(
        @{ Label = 'it was removed without a patch'; Status = 'removed' }
        @{ Label = 'it has no text content at the head commit'; Status = 'modified' }
    ) {
        Mock -ModuleName PrReReviewInput Get-PrReReviewHeadContent { $null }
        $export = Invoke-Export @(New-ChangedFile 'assets/logo.png' -Status $Status -Patch $null)
        ((& $export.Read $export.Files[0]).TrimEnd() -split "`n")[-1] | Should -Match ([regex]::Escape($export.Markers[0].marker))
    }

    It 'refuses to write the markers where the agent can read them' {
        $inputDirectory = Join-Path $TestDrive 'visible'
        { Export-PrReReviewInput -Files @(New-ChangedFile 'a.cs') -Repository 'Azure/azure-sdk-for-net' -HeadSha 'abc1234' -InputDirectory $inputDirectory -MarkersPath (Join-Path $inputDirectory 'markers.json') } |
            Should -Throw -ExpectedMessage '*outside*'
    }
}

Describe 'Get-PrReReviewPullRequestInput' {
    It 'collects every page of changed files' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"a.cs","status":"modified","patch":"+a"}],[{"filename":"b.cs","status":"added","patch":"+b"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') } {
            '{"changed_files":2,"head":{"sha":"abc1234"}}'
        }
        $pullRequest = Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1
        $pullRequest.HeadSha | Should -BeExactly 'abc1234'
        @($pullRequest.Files.filename) | Should -Be @('a.cs', 'b.cs')
    }

    It 'fails rather than export a partial list when GitHub lists fewer files than changed_files' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"a.cs","status":"modified","patch":"+a"}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { -not ($Arguments -like '*/files*') } {
            '{"changed_files":2,"head":{"sha":"abc1234"}}'
        }
        { Get-PrReReviewPullRequestInput -Repository 'Azure/azure-sdk-for-net' -Number 1 } | Should -Throw -ExpectedMessage '*1 of*2*'
    }
}

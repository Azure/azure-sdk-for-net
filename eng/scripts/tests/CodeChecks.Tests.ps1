<#
.SYNOPSIS
    Unit tests for the PreparePr functionality in CodeChecks.ps1.

.DESCRIPTION
    Tests the helper functions that parse git porcelain output and produce the
    "what is new" summary when running CodeChecks with -PreparePr.

.How-To-Run
    Install Pester if needed:
        Install-Module Pester -Force

    Run these tests:
        Invoke-Pester -Output Detailed $PSScriptRoot/CodeChecks.Tests.ps1
#>

Import-Module Pester

BeforeAll {
    . "$PSScriptRoot/../CodeChecks.Helpers.ps1"
}

# ─────────────────────────────────────────────
# Get-PorcelainPaths
# ─────────────────────────────────────────────
Describe "Get-PorcelainPaths" -Tag "UnitTest" {

    Context "standard status codes" {
        It "parses modified file: '<line>'" -TestCases @(
            @{ line = " M sdk/foo/bar.cs";  expected = @("sdk/foo/bar.cs") }
            @{ line = "M  sdk/foo/bar.cs";  expected = @("sdk/foo/bar.cs") }
            @{ line = "MM sdk/foo/bar.cs";  expected = @("sdk/foo/bar.cs") }
        ) {
            Get-PorcelainPaths $line | Should -Be $expected
        }

        It "parses added file" {
            Get-PorcelainPaths "A  sdk/new/file.cs" | Should -Be @("sdk/new/file.cs")
        }

        It "parses deleted file" {
            Get-PorcelainPaths " D sdk/old/file.cs" | Should -Be @("sdk/old/file.cs")
        }

        It "parses untracked file" {
            Get-PorcelainPaths "?? sdk/untracked.cs" | Should -Be @("sdk/untracked.cs")
        }
    }

    Context "rename handling" {
        It "returns both old and new paths for a rename" {
            $result = Get-PorcelainPaths "R  sdk/old.cs -> sdk/new.cs"
            $result.Count | Should -Be 2
            $result[0]    | Should -Be "sdk/old.cs"
            $result[1]    | Should -Be "sdk/new.cs"
        }

        It "handles rename with spaces in path" {
            $result = Get-PorcelainPaths "R  sdk/my dir/old.cs -> sdk/my dir/new.cs"
            $result.Count | Should -Be 2
            $result[0]    | Should -Be "sdk/my dir/old.cs"
            $result[1]    | Should -Be "sdk/my dir/new.cs"
        }
    }

    Context "edge cases" {
        It "returns empty for null input" {
            Get-PorcelainPaths $null | Should -BeNullOrEmpty
        }

        It "returns empty for empty string" {
            Get-PorcelainPaths "" | Should -BeNullOrEmpty
        }

        It "returns empty for whitespace-only string" {
            Get-PorcelainPaths "   " | Should -BeNullOrEmpty
        }

        It "returns empty for line too short to contain a path" {
            Get-PorcelainPaths "M " | Should -BeNullOrEmpty
        }

        It "returns empty for exactly three characters (status only)" {
            Get-PorcelainPaths "M  " | Should -BeNullOrEmpty
        }
    }

    Context "paths with special characters" {
        It "handles path with parentheses" {
            Get-PorcelainPaths " M sdk/foo/bar(v2).cs" | Should -Be @("sdk/foo/bar(v2).cs")
        }

        It "handles deeply nested path" {
            $deep = " M sdk/storage/Azure.Storage.Blobs/src/Generated/Models/BlobItem.cs"
            Get-PorcelainPaths $deep | Should -Be @("sdk/storage/Azure.Storage.Blobs/src/Generated/Models/BlobItem.cs")
        }
    }
}

# ─────────────────────────────────────────────
# Get-CodeCheckSummary
# ─────────────────────────────────────────────
Describe "Get-CodeCheckSummary" -Tag "UnitTest" {

    Context "clean working tree before code checks" {
        It "reports all changes as new when there were no pre-existing changes" {
            $currentLines = @(
                " M sdk/foo/Generated/Client.cs",
                " M sdk/foo/api/Foo.netstandard2.0.cs"
            )

            $result = Get-CodeCheckSummary -CurrentStatusLines $currentLines -PreExistingChanges @()

            $result.NewStatusLines.Count | Should -Be 2
            $result.PreExistingCount      | Should -Be 0
        }
    }

    Context "dirty working tree before code checks" {
        It "filters out pre-existing changes and reports only new ones" {
            $currentLines = @(
                " M sdk/foo/src/MyClient.cs",
                " M sdk/foo/Generated/Client.cs",
                " M sdk/foo/api/Foo.netstandard2.0.cs"
            )
            $preExisting = @("sdk/foo/src/MyClient.cs")

            $result = Get-CodeCheckSummary -CurrentStatusLines $currentLines -PreExistingChanges $preExisting

            $result.NewStatusLines.Count | Should -Be 2
            $result.NewStatusLines[0]    | Should -BeLike "*Generated/Client.cs*"
            $result.NewStatusLines[1]    | Should -BeLike "*Foo.netstandard2.0.cs*"
            $result.PreExistingCount      | Should -Be 1
        }

        It "returns no new lines when every change was pre-existing" {
            $currentLines = @(
                " M sdk/foo/src/MyClient.cs",
                " M sdk/foo/src/Helper.cs"
            )
            $preExisting = @("sdk/foo/src/MyClient.cs", "sdk/foo/src/Helper.cs")

            $result = Get-CodeCheckSummary -CurrentStatusLines $currentLines -PreExistingChanges $preExisting

            $result.NewStatusLines.Count | Should -Be 0
            $result.PreExistingCount      | Should -Be 2
        }
    }

    Context "rename handling" {
        It "reports rename as new when destination path is not pre-existing" {
            $currentLines = @(
                "R  sdk/foo/OldName.cs -> sdk/foo/NewName.cs"
            )
            $preExisting = @("sdk/bar/Unrelated.cs")

            $result = Get-CodeCheckSummary -CurrentStatusLines $currentLines -PreExistingChanges $preExisting

            $result.NewStatusLines.Count | Should -Be 1
        }

        It "filters rename when destination path is pre-existing" {
            $currentLines = @(
                "R  sdk/foo/OldName.cs -> sdk/foo/NewName.cs"
            )
            $preExisting = @("sdk/foo/NewName.cs")

            $result = Get-CodeCheckSummary -CurrentStatusLines $currentLines -PreExistingChanges $preExisting

            $result.NewStatusLines.Count | Should -Be 0
        }
    }

    Context "mixed scenarios" {
        It "handles a realistic mix of modified, added, deleted, and untracked files" {
            $currentLines = @(
                " M sdk/ai/src/HandWritten.cs",     # pre-existing (user edit)
                " M sdk/ai/Generated/FooClient.cs",  # new (regenerated)
                "A  sdk/ai/api/Foo.netstandard2.0.cs", # new (Export-API)
                "?? sdk/ai/src/Scratch.cs"            # pre-existing (untracked user file)
            )
            $preExisting = @("sdk/ai/src/HandWritten.cs", "sdk/ai/src/Scratch.cs")

            $result = Get-CodeCheckSummary -CurrentStatusLines $currentLines -PreExistingChanges $preExisting

            $result.NewStatusLines.Count | Should -Be 2
            $result.NewStatusLines[0]    | Should -BeLike "*FooClient.cs*"
            $result.NewStatusLines[1]    | Should -BeLike "*Foo.netstandard2.0.cs*"
            $result.PreExistingCount      | Should -Be 2
        }

        It "preserves the original porcelain line text in new status lines" {
            $line = " M sdk/foo/Generated/Client.cs"
            $result = Get-CodeCheckSummary -CurrentStatusLines @($line) -PreExistingChanges @()

            $result.NewStatusLines[0] | Should -BeExactly $line
        }
    }

    Context "empty / no-op inputs" {
        It "returns empty summary when there are no current changes" {
            $result = Get-CodeCheckSummary -CurrentStatusLines @() -PreExistingChanges @()

            $result.NewStatusLines.Count | Should -Be 0
            $result.PreExistingCount      | Should -Be 0
        }

        It "returns empty summary when current lines are all blank or malformed" {
            $currentLines = @("", "   ", "M ")

            $result = Get-CodeCheckSummary -CurrentStatusLines $currentLines -PreExistingChanges @()

            $result.NewStatusLines.Count | Should -Be 0
        }
    }
}

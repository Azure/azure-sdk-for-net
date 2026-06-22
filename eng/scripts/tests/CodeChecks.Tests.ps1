#Requires -Version 7.0
<#
.SYNOPSIS
    Unit tests for the SkipDiffValidation functionality in CodeChecks.ps1.

.DESCRIPTION
    Tests the helper functions that parse git porcelain output, produce the
    "what is new" summary, and determine the correct action (error vs. report)
    when running CodeChecks with or without -SkipDiffValidation.

.How-To-Run
    Run these tests (Pester is installed automatically via PSModule-Helpers):
        Invoke-Pester -Output Detailed $PSScriptRoot/CodeChecks.Tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

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

# ─────────────────────────────────────────────
# Get-DiffCheckResult
# ─────────────────────────────────────────────
Describe "Get-DiffCheckResult" -Tag "UnitTest" {

    Context "no diffs detected" {
        It "returns 'none' action when there are no diffs and SkipDiffValidation is false" {
            $result = Get-DiffCheckResult -HasDiff $false -SkipDiffValidation $false
            $result.Action | Should -Be "none"
        }

        It "returns 'none' action when there are no diffs and SkipDiffValidation is true" {
            $result = Get-DiffCheckResult -HasDiff $false -SkipDiffValidation $true
            $result.Action | Should -Be "none"
        }
    }

    Context "default behavior (SkipDiffValidation = false) — validates CI mode" {
        It "returns 'error' action when diffs exist and SkipDiffValidation is false" {
            $result = Get-DiffCheckResult -HasDiff $true -SkipDiffValidation $false -ServiceDirectory "foo"
            $result.Action | Should -Be "error"
        }

        It "produces an error message mentioning the service directory" {
            $result = Get-DiffCheckResult -HasDiff $true -SkipDiffValidation $false -ServiceDirectory "storage"
            $result.ErrorMessage | Should -BeLike "*Generated code is not up to date*"
            $result.ErrorMessage | Should -BeLike "*storage*"
        }

        It "error message includes remediation instructions" {
            $result = Get-DiffCheckResult -HasDiff $true -SkipDiffValidation $false -ServiceDirectory "keyvault"
            $result.ErrorMessage | Should -BeLike "*Update-Snippets*"
            $result.ErrorMessage | Should -BeLike "*Export-API*"
            $result.ErrorMessage | Should -BeLike "*GenerateCode*"
        }

        It "error message suggests -SkipDiffValidation for local fix" {
            $result = Get-DiffCheckResult -HasDiff $true -SkipDiffValidation $false -ServiceDirectory "compute"
            $result.ErrorMessage | Should -BeLike "*-SkipDiffValidation*"
        }

        It "does not include a Summary in error mode" {
            $result = Get-DiffCheckResult -HasDiff $true -SkipDiffValidation $false
            $result.Keys | Should -Not -Contain "Summary"
        }
    }

    Context "report mode (SkipDiffValidation = true)" {
        It "returns 'report' action when diffs exist and SkipDiffValidation is true" {
            $statusLines = @(" M sdk/foo/Generated/Client.cs")
            $result = Get-DiffCheckResult -HasDiff $true -SkipDiffValidation $true -CurrentStatusLines $statusLines

            $result.Action | Should -Be "report"
        }

        It "includes a Summary with new status lines" {
            $statusLines = @(
                " M sdk/foo/Generated/Client.cs",
                " M sdk/foo/api/Foo.netstandard2.0.cs"
            )
            $result = Get-DiffCheckResult -HasDiff $true -SkipDiffValidation $true `
                -CurrentStatusLines $statusLines -PreExistingChanges @()

            $result.Summary | Should -Not -BeNullOrEmpty
            $result.Summary.NewStatusLines.Count | Should -Be 2
        }

        It "filters pre-existing changes in the summary" {
            $statusLines = @(
                " M sdk/foo/src/MyClient.cs",
                " M sdk/foo/Generated/Client.cs"
            )
            $preExisting = @("sdk/foo/src/MyClient.cs")
            $result = Get-DiffCheckResult -HasDiff $true -SkipDiffValidation $true `
                -CurrentStatusLines $statusLines -PreExistingChanges $preExisting

            $result.Summary.NewStatusLines.Count | Should -Be 1
            $result.Summary.NewStatusLines[0]    | Should -BeLike "*Generated/Client.cs*"
            $result.Summary.PreExistingCount      | Should -Be 1
        }

        It "does not include an ErrorMessage in report mode" {
            $result = Get-DiffCheckResult -HasDiff $true -SkipDiffValidation $true `
                -CurrentStatusLines @(" M sdk/foo/bar.cs")
            $result.Keys | Should -Not -Contain "ErrorMessage"
        }
    }

    Context "realistic end-to-end scenarios" {
        It "simulates CI run: diffs found, default mode (no flag), error is raised" {
            # CI runs without -SkipDiffValidation, so SkipDiffValidation is $false
            $result = Get-DiffCheckResult `
                -HasDiff $true `
                -SkipDiffValidation $false `
                -CurrentStatusLines @(" M sdk/ai/Generated/FooClient.cs") `
                -ServiceDirectory "ai"

            $result.Action       | Should -Be "error"
            $result.ErrorMessage | Should -BeLike "*not up to date*"
        }

        It "simulates local run: no diffs after code checks, nothing to report" {
            $result = Get-DiffCheckResult `
                -HasDiff $false `
                -SkipDiffValidation $true `
                -CurrentStatusLines @() `
                -PreExistingChanges @()

            $result.Action | Should -Be "none"
        }

        It "simulates local run with pre-existing and new changes" {
            $statusLines = @(
                " M sdk/ai/src/HandWritten.cs",
                " M sdk/ai/Generated/FooClient.cs",
                "A  sdk/ai/api/Foo.netstandard2.0.cs",
                "?? sdk/ai/src/Scratch.cs"
            )
            $preExisting = @("sdk/ai/src/HandWritten.cs", "sdk/ai/src/Scratch.cs")

            $result = Get-DiffCheckResult `
                -HasDiff $true `
                -SkipDiffValidation $true `
                -CurrentStatusLines $statusLines `
                -PreExistingChanges $preExisting

            $result.Action                        | Should -Be "report"
            $result.Summary.NewStatusLines.Count  | Should -Be 2
            $result.Summary.PreExistingCount       | Should -Be 2
        }
    }
}


# ─────────────────────────────────────────────
# Test-OnlyCiConfigChanged
# ─────────────────────────────────────────────
Describe "Test-OnlyCiConfigChanged" -Tag "UnitTest" {

    BeforeAll {
        $script:gitRoot = Join-Path ([System.IO.Path]::GetTempPath()) "codechecks-git-$([System.Guid]::NewGuid().ToString('N').Substring(0,8))"
        $script:savedTargetBranch = $env:SYSTEM_PULLREQUEST_TARGETBRANCH
    }

    AfterAll {
        $env:SYSTEM_PULLREQUEST_TARGETBRANCH = $script:savedTargetBranch
        if (Test-Path $script:gitRoot) {
            Remove-Item $script:gitRoot -Recurse -Force
        }
    }

    AfterEach {
        $env:SYSTEM_PULLREQUEST_TARGETBRANCH = $script:savedTargetBranch
    }

    BeforeEach {
        $env:SYSTEM_PULLREQUEST_TARGETBRANCH = $null
        if (Test-Path $script:gitRoot) {
            Remove-Item $script:gitRoot -Recurse -Force
        }
        New-Item $script:gitRoot -ItemType Directory -Force | Out-Null

        Push-Location $script:gitRoot
        git init --quiet --initial-branch=main
        git config user.email "test@test.com"
        git config user.name "test"

        # Create initial structure on "main" with multiple service directories
        foreach ($svc in @("mysvc", "othersvc")) {
            New-Item "sdk/$svc" -ItemType Directory -Force | Out-Null
            Set-Content "sdk/$svc/ci.yml" "trigger: none"
            Set-Content "sdk/$svc/ci.mgmt.yml" "trigger: none"
            New-Item "sdk/$svc/Azure.$svc/src" -ItemType Directory -Force | Out-Null
            Set-Content "sdk/$svc/Azure.$svc/src/Client.cs" "class Client {}"
            New-Item "sdk/$svc/Azure.$svc/tests" -ItemType Directory -Force | Out-Null
            Set-Content "sdk/$svc/Azure.$svc/tests/ClientTests.cs" "class ClientTests {}"
        }
        # Also add some non-ci yml files to test the pattern is specific
        Set-Content "sdk/mysvc/config.yml" "some: config"
        Set-Content "sdk/mysvc/Azure.mysvc/src/autorest.md" "autorest config"
        git add -A
        git commit -m "initial" --quiet

        # Create a feature branch for changes
        git checkout -b feature-branch --quiet
        Pop-Location
    }

    Context "only ci*.yml files changed" {
        It "returns true when only ci.yml changed" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "trigger: none`nmodified: true"
            git add -A; git commit -m "change ci.yml" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $true
        }

        It "returns true when only ci.mgmt.yml changed" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.mgmt.yml" "trigger: none`nmodified: true"
            git add -A; git commit -m "change ci.mgmt.yml" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $true
        }

        It "returns true when both ci.yml and ci.mgmt.yml changed" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified"
            Set-Content "sdk/mysvc/ci.mgmt.yml" "modified"
            git add -A; git commit -m "change both" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $true
        }

        It "returns true for non-standard ci file names like ci.compute.yml" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.compute.yml" "new file"
            git add -A; git commit -m "add ci.compute.yml" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $true
        }

        It "returns true when ci*.yml changed across multiple commits" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified in commit 1"
            git add -A; git commit -m "commit 1" --quiet
            Set-Content "sdk/mysvc/ci.mgmt.yml" "modified in commit 2"
            git add -A; git commit -m "commit 2" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $true
        }
    }

    Context "source code also changed — must NOT skip codegen" {
        It "returns false when a .cs source file also changed" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified"
            Set-Content "sdk/mysvc/Azure.mysvc/src/Client.cs" "class Client { int x; }"
            git add -A; git commit -m "change both" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }

        It "returns false when only a .cs file changed (no ci file)" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/Azure.mysvc/src/Client.cs" "class Client { int x; }"
            git add -A; git commit -m "change cs" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }

        It "returns false when a csproj file also changed" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified"
            Set-Content "sdk/mysvc/Azure.mysvc/src/Azure.mysvc.csproj" "<Project />"
            git add -A; git commit -m "change both" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }

        It "returns false when autorest.md changed" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified"
            Set-Content "sdk/mysvc/Azure.mysvc/src/autorest.md" "modified autorest config"
            git add -A; git commit -m "change both" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }

        It "returns false when a test file also changed" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified"
            Set-Content "sdk/mysvc/Azure.mysvc/tests/ClientTests.cs" "class ClientTests { void Test() {} }"
            git add -A; git commit -m "change both" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }

        It "returns false when a non-ci yml file changed (config.yml)" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified"
            Set-Content "sdk/mysvc/config.yml" "modified: config"
            git add -A; git commit -m "change both" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }

        It "returns false when ci.yml changed in one commit and .cs in another" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified"
            git add -A; git commit -m "ci change" --quiet
            Set-Content "sdk/mysvc/Azure.mysvc/src/Client.cs" "class Client { int x; }"
            git add -A; git commit -m "code change" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }

        It "returns false when README.md changed (affects snippets)" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified"
            Set-Content "sdk/mysvc/Azure.mysvc/README.md" "# Updated readme"
            git add -A; git commit -m "change both" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }
    }

    Context "cross-service isolation" {
        It "returns true for mysvc even when othersvc has code changes" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified"
            Set-Content "sdk/othersvc/Azure.othersvc/src/Client.cs" "class Client { int x; }"
            git add -A; git commit -m "mixed changes" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $true
        }

        It "returns false for othersvc when it has code changes even if mysvc is ci-only" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified"
            Set-Content "sdk/othersvc/Azure.othersvc/src/Client.cs" "class Client { int x; }"
            git add -A; git commit -m "mixed changes" --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "othersvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }
    }

    Context "no changes" {
        It "returns false when nothing changed in the service directory" {
            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }

        It "returns false for a nonexistent service directory" {
            $result = Test-OnlyCiConfigChanged -ServiceDirectory "doesnotexist" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }
    }

    Context "branch targeting via SYSTEM_PULLREQUEST_TARGETBRANCH" {
        It "uses the target branch from env var when set" {
            # Rename main to 'release' and set the env var
            Push-Location $script:gitRoot
            git checkout main --quiet
            git branch -m main release --quiet
            git checkout feature-branch --quiet 2>$null
            Set-Content "sdk/mysvc/ci.yml" "modified"
            git add -A; git commit -m "change ci.yml" --quiet
            Pop-Location

            $env:SYSTEM_PULLREQUEST_TARGETBRANCH = "refs/heads/release"
            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $true
        }

        It "handles target branch without refs/heads/ prefix" {
            Push-Location $script:gitRoot
            git checkout main --quiet
            git branch -m main develop --quiet
            git checkout feature-branch --quiet 2>$null
            Set-Content "sdk/mysvc/ci.yml" "modified"
            git add -A; git commit -m "change ci.yml" --quiet
            Pop-Location

            $env:SYSTEM_PULLREQUEST_TARGETBRANCH = "develop"
            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $true
        }
    }

    Context "merge base with diverged branches" {
        It "returns true when main advanced but only ci files changed on feature branch" {
            Push-Location $script:gitRoot
            # Make a change on feature branch
            Set-Content "sdk/mysvc/ci.yml" "modified on feature"
            git add -A; git commit -m "feature change" --quiet

            # Switch back to main and add a new commit
            git checkout main --quiet
            Set-Content "sdk/mysvc/Azure.mysvc/src/Client.cs" "class Client { string name; }"
            git add -A; git commit -m "main advanced" --quiet

            # Go back to feature branch
            git checkout feature-branch --quiet
            Pop-Location

            # The merge base is the original commit. Feature branch only has ci.yml changes.
            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $true
        }

        It "returns false when feature branch has both ci and code changes even if main also changed" {
            Push-Location $script:gitRoot
            Set-Content "sdk/mysvc/ci.yml" "modified on feature"
            Set-Content "sdk/mysvc/Azure.mysvc/src/Client.cs" "class Client { int x; }"
            git add -A; git commit -m "feature change" --quiet

            git checkout main --quiet
            Set-Content "sdk/mysvc/Azure.mysvc/src/Client.cs" "class Client { string name; }"
            git add -A; git commit -m "main advanced" --quiet

            git checkout feature-branch --quiet
            Pop-Location

            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }
    }

    Context "error handling — always falls back to running codegen" {
        It "returns false when RepoRoot is not a git repo" {
            $nonGitDir = Join-Path ([System.IO.Path]::GetTempPath()) "not-a-repo-$([System.Guid]::NewGuid().ToString('N').Substring(0,8))"
            New-Item $nonGitDir -ItemType Directory -Force | Out-Null
            try {
                $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot $nonGitDir
                $result | Should -Be $false
            } finally {
                Remove-Item $nonGitDir -Recurse -Force
            }
        }

        It "returns false when RepoRoot does not exist" {
            $result = Test-OnlyCiConfigChanged -ServiceDirectory "mysvc" -RepoRoot "/nonexistent/path/to/repo"
            $result | Should -Be $false
        }

        It "returns false when ServiceDirectory is empty" {
            $result = Test-OnlyCiConfigChanged -ServiceDirectory "" -RepoRoot $script:gitRoot
            $result | Should -Be $false
        }
    }
}

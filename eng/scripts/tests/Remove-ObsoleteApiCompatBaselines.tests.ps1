#Requires -Version 7.0
<#
.How-To-Run
This test file uses Pester, a testing framework for PowerShell.
For more information about Pester, see: https://pester.dev/docs/quick-start

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./Remove-ObsoleteApiCompatBaselines.tests.ps1`

#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Set-StrictMode -Version 3

BeforeAll {
    . (Join-Path $PSScriptRoot ".." "Remove-ObsoleteApiCompatBaselines.ps1")
    . (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "SemVer.ps1")

    function New-BaselineFile {
        param (
            [Parameter(Mandatory = $true)] [string]$RepoRoot,
            [Parameter(Mandatory = $true)] [string]$Name,
            [Parameter(Mandatory = $true)] [string]$Content
        )
        $dir = Join-Path $RepoRoot "eng" "apicompatbaselines"
        New-Item -ItemType Directory -Path $dir -Force | Out-Null
        $path = Join-Path $dir $Name
        # Write with LF line endings and no trailing newline to mirror the repo's files.
        [System.IO.File]::WriteAllText($path, $Content, (New-Object System.Text.UTF8Encoding($false)))
        return $path
    }
}

Describe "Remove-ObsoleteApiCompatBaselines" -Tag "UnitTest" {
    Context "project-specific baseline file" {
        It "removes eng/apicompatbaselines/<Project>.txt" {
            $root = Join-Path $TestDrive "proj-file"
            $baselinePath = New-BaselineFile -RepoRoot $root -Name "Azure.Storage.Blobs.txt" `
                -Content "MembersMustExist : Member 'public void Foo()' does not exist"

            $removed = Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs"

            $removed | Should -Be 1
            (Test-Path -LiteralPath $baselinePath) | Should -BeFalse
        }

        It "leaves baseline files for other projects untouched" {
            $root = Join-Path $TestDrive "proj-other"
            New-BaselineFile -RepoRoot $root -Name "Azure.Storage.Blobs.txt" -Content "suppression" | Out-Null
            $otherPath = New-BaselineFile -RepoRoot $root -Name "Azure.Core.txt" -Content "other suppression"

            Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs" | Out-Null

            (Test-Path -LiteralPath $otherPath) | Should -BeTrue
        }
    }

    Context "common list files (e.g. ApiCompatVersionOptOut.txt)" {
        It "removes only the matching project line and preserves comments and other entries" {
            $root = Join-Path $TestDrive "optout"
            $content = @(
                "# ApiCompat version presence opt-out list",
                "# One project name per line. Lines starting with '#' are comments.",
                "Azure.ResourceManager.Compute.BulkActions",
                "Azure.Storage.Blobs"
            ) -join "`n"
            $optOutPath = New-BaselineFile -RepoRoot $root -Name "ApiCompatVersionOptOut.txt" -Content $content

            $removed = Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs"

            $removed | Should -Be 1
            $result = [System.IO.File]::ReadAllText($optOutPath)
            $result | Should -Not -Match "Azure.Storage.Blobs"
            $result | Should -Match "Azure.ResourceManager.Compute.BulkActions"
            $result | Should -Match "# One project name per line"
        }

        It "preserves LF line endings and the no-trailing-newline convention" {
            $root = Join-Path $TestDrive "eol"
            $content = "# comment`nAzure.ResourceManager.Compute.BulkActions`nAzure.Storage.Blobs"
            $optOutPath = New-BaselineFile -RepoRoot $root -Name "ApiCompatVersionOptOut.txt" -Content $content

            Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs" | Out-Null

            $result = [System.IO.File]::ReadAllText($optOutPath)
            $result | Should -Be "# comment`nAzure.ResourceManager.Compute.BulkActions"
            $result.Contains("`r`n") | Should -BeFalse
        }

        It "normalizes CRLF input to LF" {
            $root = Join-Path $TestDrive "crlf"
            $content = "# comment`r`nAzure.ResourceManager.Compute.BulkActions`r`nAzure.Storage.Blobs"
            $optOutPath = New-BaselineFile -RepoRoot $root -Name "ApiCompatVersionOptOut.txt" -Content $content

            Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs" | Out-Null

            $result = [System.IO.File]::ReadAllText($optOutPath)
            $result | Should -Be "# comment`nAzure.ResourceManager.Compute.BulkActions"
            $result.Contains("`r`n") | Should -BeFalse
        }

        It "does not remove partial or substring matches" {
            $root = Join-Path $TestDrive "partial"
            $content = "Azure.Storage.Blobs.Batch`nAzure.Storage.Blobs"
            $optOutPath = New-BaselineFile -RepoRoot $root -Name "ApiCompatVersionOptOut.txt" -Content $content

            Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs" | Out-Null

            $result = [System.IO.File]::ReadAllText($optOutPath)
            $result | Should -Be "Azure.Storage.Blobs.Batch"
        }

        It "removes a whitespace-padded project line but keeps lines with other content" {
            $root = Join-Path $TestDrive "extra-content"
            $content = "Azure.Storage.Blobs # keep`n Azure.Storage.Blobs `nAzure.Storage.Blobs extra`nAzure.Core"
            $optOutPath = New-BaselineFile -RepoRoot $root -Name "ApiCompatVersionOptOut.txt" -Content $content

            $removed = Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs"

            $removed | Should -Be 1
            $result = [System.IO.File]::ReadAllText($optOutPath)
            $result | Should -Be "Azure.Storage.Blobs # keep`nAzure.Storage.Blobs extra`nAzure.Core"
        }

        It "does not touch a per-package suppression file that contains a standalone package-name line" {
            $root = Join-Path $TestDrive "suppression-collision"
            $suppressionContent = "MembersMustExist : Member 'public void Foo()' does not exist`nAzure.Storage.Blobs"
            $suppressionPath = New-BaselineFile -RepoRoot $root -Name "Azure.Core.txt" -Content $suppressionContent
            New-BaselineFile -RepoRoot $root -Name "ApiCompatVersionOptOut.txt" -Content "Azure.Storage.Blobs" | Out-Null

            $removed = Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs"

            $removed | Should -Be 1
            [System.IO.File]::ReadAllText($suppressionPath) | Should -Be $suppressionContent
        }

        It "removes both the project file and a common-file entry when both exist" {
            $root = Join-Path $TestDrive "both"
            $projPath = New-BaselineFile -RepoRoot $root -Name "Azure.Storage.Blobs.txt" -Content "suppression"
            $optOutPath = New-BaselineFile -RepoRoot $root -Name "ApiCompatVersionOptOut.txt" `
                -Content "# comment`nAzure.Storage.Blobs"

            $removed = Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs"

            $removed | Should -Be 2
            (Test-Path -LiteralPath $projPath) | Should -BeFalse
            [System.IO.File]::ReadAllText($optOutPath) | Should -Be "# comment"
        }
    }

    Context "no matching entries" {
        It "returns 0 when nothing matches" {
            $root = Join-Path $TestDrive "nomatch"
            New-BaselineFile -RepoRoot $root -Name "ApiCompatVersionOptOut.txt" -Content "Azure.Core" | Out-Null

            $removed = Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs"

            $removed | Should -Be 0
        }

        It "returns 0 when the apicompatbaselines directory does not exist" {
            $root = Join-Path $TestDrive "nodir"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null

            $removed = Remove-ObsoleteApiCompatBaselines -RepoRoot $root -PackageName "Azure.Storage.Blobs"

            $removed | Should -Be 0
        }
    }
}

Describe "Test-ApiCompatVersionBumped" -Tag "UnitTest" {
    Context "GA (non-preview) current version" {
        It "returns true on the normal auto-increment path (no explicit new version)" {
            Test-ApiCompatVersionBumped -CurrentVersion "2.0.0" -NewVersionString "" | Should -BeTrue
        }

        It "returns true when an explicit new version differs from the current version" {
            Test-ApiCompatVersionBumped -CurrentVersion "2.0.0" -NewVersionString "2.0.1" | Should -BeTrue
        }

        It "returns false when the explicit new version equals the current version (no-op bump)" {
            Test-ApiCompatVersionBumped -CurrentVersion "2.0.0" -NewVersionString "2.0.0" | Should -BeFalse
        }
    }

    Context "prerelease current version" {
        It "returns false on the auto-increment path" {
            Test-ApiCompatVersionBumped -CurrentVersion "2.0.0-beta.1" -NewVersionString "" | Should -BeFalse
        }

        It "returns false even when an explicit new version is provided" {
            Test-ApiCompatVersionBumped -CurrentVersion "2.0.0-beta.1" -NewVersionString "2.0.0" | Should -BeFalse
        }
    }
}


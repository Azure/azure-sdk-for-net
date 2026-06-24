#Requires -Version 7.0
<#
.How-To-Run
This test file uses Pester, a testing framework for PowerShell.

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./Sync-ReleaseArtifacts.tests.ps1`

#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Set-StrictMode -Version 3

BeforeAll {
    # Load ChangeLog-Operations for parsing helpers and the CHANGELOG_UNRELEASED_STATUS constant.
    . (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "SemVer.ps1")
    . (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "logging.ps1")
    . (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "ChangeLog-Operations.ps1")

    # Load just the testable functions from the script under test.
    # We define them here to avoid the main execution block and its
    # dependencies (Get-PkgProperties, git, etc.).
    function Merge-ChangeLogEntries {
        param(
            [Parameter(Mandatory = $true)] $MainEntries,
            [Parameter(Mandatory = $true)] $ReleaseEntries
        )

        foreach ($version in $ReleaseEntries.Keys) {
            $releaseEntry = $ReleaseEntries[$version]
            if (-not $MainEntries.Contains($version)) {
                $MainEntries[$version] = $releaseEntry
                Write-Host "  Added changelog entry for $version from release"
            }
            elseif ($MainEntries[$version].ReleaseStatus -eq $CHANGELOG_UNRELEASED_STATUS -and
                    $releaseEntry.ReleaseStatus -ne $CHANGELOG_UNRELEASED_STATUS) {
                $MainEntries[$version] = $releaseEntry
                Write-Host "  Updated changelog entry for $version with release date"
            }
            elseif ($releaseEntry.ReleaseStatus -ne $CHANGELOG_UNRELEASED_STATUS -and
                    $MainEntries[$version].ReleaseStatus -ne $CHANGELOG_UNRELEASED_STATUS) {
                $MainEntries[$version] = $releaseEntry
                Write-Host "  Replaced changelog entry for $version with release content"
            }
        }

        $datedStableReleases = @()
        foreach ($version in $ReleaseEntries.Keys) {
            if ($ReleaseEntries[$version].ReleaseStatus -eq $CHANGELOG_UNRELEASED_STATUS) { continue }
            $semVer = [AzureEngSemanticVersion]::ParseVersionString($version)
            if ($semVer -and -not $semVer.IsPrerelease) {
                $datedStableReleases += $semVer
            }
        }

        if ($datedStableReleases.Count -gt 0) {
            $toRemove = @()
            foreach ($version in @($MainEntries.Keys)) {
                if ($MainEntries[$version].ReleaseStatus -ne $CHANGELOG_UNRELEASED_STATUS) { continue }
                $entrySemVer = [AzureEngSemanticVersion]::ParseVersionString($version)
                if (-not $entrySemVer -or -not $entrySemVer.IsPrerelease) { continue }
                foreach ($stable in $datedStableReleases) {
                    if ($entrySemVer.Major -eq $stable.Major -and
                        $entrySemVer.Minor -eq $stable.Minor -and
                        $entrySemVer.Patch -eq $stable.Patch) {
                        $toRemove += $version
                        break
                    }
                }
            }
            foreach ($version in $toRemove) {
                $MainEntries.Remove($version)
                Write-Host "  Removed unreleased prerelease entry $version superseded by stable release"
            }
        }

        return $MainEntries
    }

    function Resolve-CsprojVersion {
        param(
            [Parameter(Mandatory = $true)] [string]$MainVersion,
            [Parameter(Mandatory = $true)] [string]$ReleaseVersion
        )

        $mainSemVer = [AzureEngSemanticVersion]::new($MainVersion)
        $releaseSemVer = [AzureEngSemanticVersion]::new($ReleaseVersion)

        if ($releaseSemVer.CompareTo($mainSemVer) -gt 0) {
            Write-Host "  Release version $ReleaseVersion > main version $MainVersion — using release"
            return $ReleaseVersion
        }
        elseif ($mainSemVer.CompareTo($releaseSemVer) -gt 0) {
            Write-Host "  Main version $MainVersion > release version $ReleaseVersion — using main"
            return $MainVersion
        }
        else {
            Write-Host "  Versions equal ($MainVersion) — no change needed"
            return $MainVersion
        }
    }

    function Build-Changelog {
        <# Helper to build a changelog string from version specs. Each spec is
           @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("### Bugs Fixed", "", "- fix1") }
        #>
        param([array]$Entries, [string]$Header = "# Release History")
        $lines = @($Header, "")
        foreach ($entry in $Entries) {
            $lines += "## $($entry.Version) $($entry.Status)"
            if ($entry.Content) { $lines += $entry.Content }
            else { $lines += @("", "### Features Added", "") }
            $lines += ""
        }
        return $lines -join "`n"
    }
}

Describe "Merge-ChangeLogEntries" {

    It "No-op when release and main have identical entries" {
        $changelog = Build-Changelog @(
            @{ Version = "1.1.0"; Status = "(2026-03-01)"; Content = @("", "### Features Added", "", "- feature1") },
            @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("", "### Features Added", "", "- initial") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $changelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $changelog

        $result = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        $result.Count | Should -Be 2
        $result.Contains("1.1.0") | Should -BeTrue
        $result.Contains("1.0.0") | Should -BeTrue
    }

    It "Adds new version from release that is missing in main" {
        $mainChangelog = Build-Changelog @(
            @{ Version = "1.2.0"; Status = "(Unreleased)" },
            @{ Version = "1.1.0"; Status = "(2026-02-01)"; Content = @("", "### Features Added", "", "- feature1") },
            @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("", "### Features Added", "", "- initial") }
        )
        $releaseChangelog = Build-Changelog @(
            @{ Version = "1.1.1"; Status = "(2026-03-17)"; Content = @("", "### Bugs Fixed", "", "- hotfix") },
            @{ Version = "1.1.0"; Status = "(2026-02-01)"; Content = @("", "### Features Added", "", "- feature1") },
            @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("", "### Features Added", "", "- initial") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $mainChangelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $releaseChangelog

        $result = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        $result.Count | Should -Be 4
        $result.Contains("1.2.0") | Should -BeTrue
        $result.Contains("1.1.1") | Should -BeTrue
        $result.Contains("1.1.0") | Should -BeTrue
        $result.Contains("1.0.0") | Should -BeTrue
        $result["1.1.1"].ReleaseStatus | Should -Be "(2026-03-17)"
    }

    It "Updates unreleased entry with release date" {
        $mainChangelog = Build-Changelog @(
            @{ Version = "1.1.0"; Status = "(Unreleased)"; Content = @("", "### Features Added", "", "- feature1") },
            @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("", "### Features Added", "", "- initial") }
        )
        $releaseChangelog = Build-Changelog @(
            @{ Version = "1.1.0"; Status = "(2026-03-17)"; Content = @("", "### Features Added", "", "- feature1", "- feature2") },
            @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("", "### Features Added", "", "- initial") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $mainChangelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $releaseChangelog

        $result = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        $result.Count | Should -Be 2
        $result["1.1.0"].ReleaseStatus | Should -Be "(2026-03-17)"
    }

    It "Preserves entries that only exist on main" {
        $mainChangelog = Build-Changelog @(
            @{ Version = "1.2.0"; Status = "(Unreleased)" },
            @{ Version = "1.1.0"; Status = "(2026-02-01)"; Content = @("", "### Features Added", "", "- feature1") },
            @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("", "### Features Added", "", "- initial") }
        )
        # Release branch was forked before 1.2.0 work started
        $releaseChangelog = Build-Changelog @(
            @{ Version = "1.1.1"; Status = "(2026-03-17)"; Content = @("", "### Bugs Fixed", "", "- hotfix") },
            @{ Version = "1.1.0"; Status = "(2026-02-01)"; Content = @("", "### Features Added", "", "- feature1") },
            @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("", "### Features Added", "", "- initial") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $mainChangelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $releaseChangelog

        $result = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        $result.Count | Should -Be 4
        $result.Contains("1.2.0") | Should -BeTrue
        $result["1.2.0"].ReleaseStatus | Should -Be "(Unreleased)"
        $result.Contains("1.1.1") | Should -BeTrue
        $result["1.1.1"].ReleaseStatus | Should -Be "(2026-03-17)"
    }

    It "Dated entry on both branches — release content wins" {
        $mainChangelog = Build-Changelog @(
            @{ Version = "1.0.0"; Status = "(2026-01-15)"; Content = @("", "### Features Added", "", "- from main") }
        )
        $releaseChangelog = Build-Changelog @(
            @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("", "### Features Added", "", "- from release") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $mainChangelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $releaseChangelog

        $result = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        # Release content wins when both are dated
        $result["1.0.0"].ReleaseStatus | Should -Be "(2026-01-01)"
    }

    It "Dated entry with different content — release content replaces main" {
        $mainChangelog = Build-Changelog @(
            @{ Version = "1.1.0"; Status = "(2026-03-17)"; Content = @("", "### Features Added", "", "- old content from main") }
        )
        $releaseChangelog = Build-Changelog @(
            @{ Version = "1.1.0"; Status = "(2026-03-17)"; Content = @("", "### Features Added", "", "- updated content from release", "- extra fix") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $mainChangelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $releaseChangelog

        $result = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        $result["1.1.0"].ReleaseContent | Should -Contain "- updated content from release"
        $result["1.1.0"].ReleaseContent | Should -Contain "- extra fix"
    }

    It "Unreleased entry on both branches — main's unreleased content is kept" {
        $mainChangelog = Build-Changelog @(
            @{ Version = "1.2.0"; Status = "(Unreleased)"; Content = @("", "### Features Added", "", "- main work in progress") }
        )
        $releaseChangelog = Build-Changelog @(
            @{ Version = "1.2.0"; Status = "(Unreleased)"; Content = @("", "### Features Added", "", "- release branch wip") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $mainChangelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $releaseChangelog

        $result = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        # Both unreleased — main wins (no overwrite)
        $result["1.2.0"].ReleaseContent | Should -Contain "- main work in progress"
    }

    It "GA release supersedes unreleased beta of the same version" {
        # Repro for https://github.com/Azure/azure-sdk-for-net/pull/58993
        # Release branch shipped 1.11.0 GA; main has 1.11.0-beta.1 (Unreleased)
        # plus a newer 1.12.0-beta.1 (Unreleased). The unreleased 1.11.0-beta.1
        # should be removed because it is now superseded by the GA release.
        $mainChangelog = Build-Changelog @(
            @{ Version = "1.12.0-beta.1"; Status = "(Unreleased)" },
            @{ Version = "1.11.0-beta.1"; Status = "(Unreleased)" },
            @{ Version = "1.10.0"; Status = "(2026-03-16)"; Content = @("", "### Features Added", "", "- prior") }
        )
        $releaseChangelog = Build-Changelog @(
            @{ Version = "1.11.0"; Status = "(2026-05-05)"; Content = @("", "### Features Added", "", "- ga content") },
            @{ Version = "1.10.0"; Status = "(2026-03-16)"; Content = @("", "### Features Added", "", "- prior") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $mainChangelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $releaseChangelog

        $result = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        $result.Contains("1.11.0") | Should -BeTrue
        $result["1.11.0"].ReleaseStatus | Should -Be "(2026-05-05)"
        $result.Contains("1.11.0-beta.1") | Should -BeFalse
        $result.Contains("1.12.0-beta.1") | Should -BeTrue
        $result.Contains("1.10.0") | Should -BeTrue
    }

    It "GA release does not remove a dated (already shipped) prerelease of same MMP" {
        # If main has a historical dated 1.11.0-beta.1 entry it must be preserved
        # — only Unreleased prereleases are superseded.
        $mainChangelog = Build-Changelog @(
            @{ Version = "1.11.0-beta.1"; Status = "(2026-04-01)"; Content = @("", "### Features Added", "", "- shipped beta") },
            @{ Version = "1.10.0"; Status = "(2026-03-16)"; Content = @("", "### Features Added", "", "- prior") }
        )
        $releaseChangelog = Build-Changelog @(
            @{ Version = "1.11.0"; Status = "(2026-05-05)"; Content = @("", "### Features Added", "", "- ga content") },
            @{ Version = "1.10.0"; Status = "(2026-03-16)"; Content = @("", "### Features Added", "", "- prior") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $mainChangelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $releaseChangelog

        $result = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        $result.Contains("1.11.0") | Should -BeTrue
        $result.Contains("1.11.0-beta.1") | Should -BeTrue
        $result["1.11.0-beta.1"].ReleaseStatus | Should -Be "(2026-04-01)"
    }

    It "GA release does not remove unreleased prereleases of different MMP" {
        $mainChangelog = Build-Changelog @(
            @{ Version = "1.12.0-beta.1"; Status = "(Unreleased)" },
            @{ Version = "1.10.0"; Status = "(2026-03-16)"; Content = @("", "### Features Added", "", "- prior") }
        )
        $releaseChangelog = Build-Changelog @(
            @{ Version = "1.11.0"; Status = "(2026-05-05)"; Content = @("", "### Features Added", "", "- ga content") },
            @{ Version = "1.10.0"; Status = "(2026-03-16)"; Content = @("", "### Features Added", "", "- prior") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $mainChangelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $releaseChangelog

        $result = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        $result.Contains("1.12.0-beta.1") | Should -BeTrue
        $result.Contains("1.11.0") | Should -BeTrue
    }

    It "Handles version ordering correctly after merge via Set-ChangeLogContent" {
        $mainChangelog = Build-Changelog @(
            @{ Version = "1.2.0"; Status = "(Unreleased)" },
            @{ Version = "1.1.0"; Status = "(2026-02-01)"; Content = @("", "### Features Added", "", "- feature1") },
            @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("", "### Features Added", "", "- initial") }
        )
        $releaseChangelog = Build-Changelog @(
            @{ Version = "1.1.1"; Status = "(2026-03-17)"; Content = @("", "### Bugs Fixed", "", "- hotfix") },
            @{ Version = "1.1.0"; Status = "(2026-02-01)"; Content = @("", "### Features Added", "", "- feature1") },
            @{ Version = "1.0.0"; Status = "(2026-01-01)"; Content = @("", "### Features Added", "", "- initial") }
        )
        $mainEntries = Get-ChangeLogEntriesFromContent $mainChangelog
        $releaseEntries = Get-ChangeLogEntriesFromContent $releaseChangelog

        $merged = Merge-ChangeLogEntries -MainEntries $mainEntries -ReleaseEntries $releaseEntries

        # Write to a temp file and read back to verify ordering
        $tempFile = [System.IO.Path]::GetTempFileName()
        try {
            Set-ChangeLogContent -ChangeLogLocation $tempFile -ChangeLogEntries $merged
            $content = Get-Content $tempFile -Raw

            # Verify version order in the file: 1.2.0 > 1.1.1 > 1.1.0 > 1.0.0
            $idx_120 = $content.IndexOf("1.2.0")
            $idx_111 = $content.IndexOf("1.1.1")
            $idx_110 = $content.IndexOf("1.1.0")
            $idx_100 = $content.IndexOf("1.0.0")

            $idx_120 | Should -BeLessThan $idx_111
            $idx_111 | Should -BeLessThan $idx_110
            $idx_110 | Should -BeLessThan $idx_100
        }
        finally {
            Remove-Item $tempFile -Force -ErrorAction SilentlyContinue
        }
    }
}

Describe "Resolve-CsprojVersion" {

    It "Normal release: release version equals main version" {
        $result = Resolve-CsprojVersion -MainVersion "1.1.0" -ReleaseVersion "1.1.0"
        $result | Should -Be "1.1.0"
    }

    It "Normal GA release: release version is higher than main" {
        $result = Resolve-CsprojVersion -MainVersion "1.0.0" -ReleaseVersion "1.1.0"
        $result | Should -Be "1.1.0"
    }

    It "Normal beta release: release equals main" {
        $result = Resolve-CsprojVersion -MainVersion "1.1.0-beta.2" -ReleaseVersion "1.1.0-beta.2"
        $result | Should -Be "1.1.0-beta.2"
    }

    It "Hotfix: main has advanced past release — keeps main version" {
        # Main is at 1.3.0-beta.1, hotfix ships 1.1.1
        $result = Resolve-CsprojVersion -MainVersion "1.3.0-beta.1" -ReleaseVersion "1.1.1"
        $result | Should -Be "1.3.0-beta.1"
    }

    It "Hotfix: main GA is higher than release — keeps main version" {
        # Main already shipped 1.2.0, hotfix ships 1.1.1
        $result = Resolve-CsprojVersion -MainVersion "1.2.0" -ReleaseVersion "1.1.1"
        $result | Should -Be "1.2.0"
    }

    It "Release version higher than main prerelease" {
        # Main has old beta, release ships newer GA
        $result = Resolve-CsprojVersion -MainVersion "1.0.0-beta.3" -ReleaseVersion "1.0.0"
        $result | Should -Be "1.0.0"
    }

    It "Prerelease on both — higher prerelease wins" {
        $result = Resolve-CsprojVersion -MainVersion "1.2.0-beta.1" -ReleaseVersion "1.2.0-beta.3"
        $result | Should -Be "1.2.0-beta.3"
    }

    It "Major version difference — higher wins" {
        $result = Resolve-CsprojVersion -MainVersion "2.0.0-beta.1" -ReleaseVersion "1.5.0"
        $result | Should -Be "2.0.0-beta.1"
    }
}

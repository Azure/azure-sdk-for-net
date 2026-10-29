#Requires -Version 7.0

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe "Update-MgmtPackageChangelog" {
    BeforeAll {
        $scriptContent = Get-Content (Join-Path $PSScriptRoot "../Invoke-GenerateAndBuildV2.ps1") -Raw
        $functionPattern = '(?ms)^function Update-MgmtPackageChangelog \{.*?^\}\r?$'
        if ($scriptContent -notmatch $functionPattern) {
            throw "Could not extract Update-MgmtPackageChangelog function from Invoke-GenerateAndBuildV2.ps1"
        }
        $functionCode = $Matches[0].Replace(
            '(Join-Path $PSScriptRoot "Automation-Sdk-UpdateChangelog.ps1")',
            '"Automation-Sdk-UpdateChangelog.ps1"')
        Invoke-Expression $functionCode
        $script:sdkPath = "sdk-root"
    }

    BeforeEach {
        Mock pwsh {
            $global:LASTEXITCODE = 0
        }
    }

    It "dispatches changelog generation for a succeeded management package" {
        $generatedPackage = [PSCustomObject]@{
            result = "succeeded"
            packageName = "Azure.ResourceManager.Test"
            packageFolder = "package-folder"
        }

        Update-MgmtPackageChangelog -generatedPackage $generatedPackage

        Should -Invoke pwsh -Times 1 -Exactly
    }

    It "skips a package with result '<result>'" -TestCases @(
        @{ result = "warning" }
        @{ result = "failed" }
    ) {
        param($result)
        $generatedPackage = [PSCustomObject]@{
            result = $result
            packageName = "Azure.ResourceManager.Test"
            packageFolder = "package-folder"
        }

        Update-MgmtPackageChangelog -generatedPackage $generatedPackage

        Should -Invoke pwsh -Times 0 -Exactly
    }

    It "skips a succeeded non-management package" {
        $generatedPackage = [PSCustomObject]@{
            result = "succeeded"
            packageName = "Azure.Test"
            packageFolder = "package-folder"
        }

        Update-MgmtPackageChangelog -generatedPackage $generatedPackage

        Should -Invoke pwsh -Times 0 -Exactly
    }

    It "warns without throwing when changelog generation fails" {
        Mock pwsh {
            $global:LASTEXITCODE = 1
        }
        Mock Write-Warning
        $generatedPackage = [PSCustomObject]@{
            result = "succeeded"
            packageName = "Azure.ResourceManager.Test"
            packageFolder = "package-folder"
        }

        { Update-MgmtPackageChangelog -generatedPackage $generatedPackage } | Should -Not -Throw

        Should -Invoke Write-Warning -Times 1 -Exactly -ParameterFilter {
            $Message -match "Continuing without changelog updates"
        }
    }
}

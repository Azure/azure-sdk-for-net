Describe "Get-PrPkgProperties service-level CI detection" {
    BeforeAll {
        . (Join-Path $PSScriptRoot ".." "Package-Properties.ps1")

        Mock Get-AllPkgProperties {
            return ,$script:packageProperties
        }
        Mock Update-TargetedFilesForTriggerPaths {
            param($TargetedFiles)
            return ,$TargetedFiles
        }
    }

    BeforeEach {
        $RepoRoot = $TestDrive
        $AdditionalValidationPackagesFromPackageSetFn = $null
        $serviceDirectory = Join-Path $RepoRoot "sdk" "widget"
        New-Item -Path (Join-Path $serviceDirectory "first") -ItemType Directory -Force | Out-Null
        New-Item -Path (Join-Path $serviceDirectory "second") -ItemType Directory -Force | Out-Null
        Get-ChildItem -Path $serviceDirectory -Filter "ci*.yml" -File | Remove-Item

        $script:packageProperties = @("first", "second") | ForEach-Object {
            [PSCustomObject]@{
                Name = $_
                DirectoryPath = Join-Path $serviceDirectory $_
                ServiceDirectory = "widget"
                ArtifactDetails = @{ triggeringPaths = @("/sdk/widget/ci.yml") }
                AdditionalValidationPackages = @()
                IncludedForValidation = $false
            }
        }

        $diffPath = Join-Path $TestDrive "diff.json"
        @{
            ChangedFiles = @("sdk/widget/service.md")
            DeletedFiles = @()
            ExcludePaths = @()
        } | ConvertTo-Json | Set-Content $diffPath
    }

    AfterAll {
        Remove-Variable packageProperties -Scope Script -ErrorAction SilentlyContinue
    }

    It "includes service packages when exactly one CI YAML exists under StrictMode 3" {
        Set-Content (Join-Path $serviceDirectory "ci.yml") ""
        Set-StrictMode -Version 3

        $packages = @(Get-PrPkgProperties $diffPath)

        $packages.Name | Should -Be @("first", "second")
    }

    It "does not include service packages when no CI YAML exists under StrictMode 3" {
        Set-StrictMode -Version 3

        $packages = @(Get-PrPkgProperties $diffPath)

        $packages.Count | Should -Be 0
    }

    It "does not include service packages when multiple CI YAMLs exist under StrictMode 3" {
        Set-Content (Join-Path $serviceDirectory "ci.yml") ""
        Set-Content (Join-Path $serviceDirectory "ci-extra.yml") ""
        Set-StrictMode -Version 3

        $packages = @(Get-PrPkgProperties $diffPath)

        $packages.Count | Should -Be 0
    }
}

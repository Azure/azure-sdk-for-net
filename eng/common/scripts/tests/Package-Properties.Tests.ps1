BeforeAll {
    Import-Module powershell-yaml -MinimumVersion 0.4.7 -ErrorAction Stop
    . (Join-Path $PSScriptRoot ".." "Package-Properties.ps1")

    function Get-ChangeLogEntry {}
    function Get-AllPkgProperties {}
}

Describe "PackageProps TypeSpec location metadata" {
    BeforeEach {
        Set-StrictMode -Version 3
        $packageDirectory = Join-Path $TestDrive "package"
        New-Item -Path $packageDirectory -ItemType Directory -Force | Out-Null
        $locationPath = Join-Path $packageDirectory "tsp-location.yaml"
        Set-Content -LiteralPath (Join-Path $packageDirectory "CHANGELOG.md") -Value "## 1.0.0 (Unreleased)"
        Mock Get-ChangeLogEntry { return @{ ReleaseStatus = "Unreleased" } }
        Mock CompatibleConvertFrom-Yaml {
            param($Content)
            return ConvertFrom-Yaml $Content
        }
    }

    It "preserves the spec project path for a direct TypeSpec location" {
        Set-Content -LiteralPath $locationPath -Value "directory: specification/storage/data-plane/DataLakeStorage`nrepo: Azure/azure-rest-api-specs`ncommit: main"

        $properties = [PackageProps]::new("azdatalake", "1.0.0", $packageDirectory, "package-props-tests")

        $properties.SpecProjectPath | Should -Be "specification/storage/data-plane/DataLakeStorage"
    }

    It "leaves the singular spec project path unset for a batch location" {
        Set-Content -LiteralPath $locationPath -Value "batch:`n  - ./internal/generated`n  - ./internal/generated_blob"

        $properties = [PackageProps]::new("azdatalake", "1.0.0", $packageDirectory, "package-props-tests")

        $properties.SpecProjectPath | Should -BeNullOrEmpty
        $properties.ChangeLogPath | Should -Be (Join-Path $packageDirectory "CHANGELOG.md")
        $properties.Version | Should -Be "1.0.0"
    }

    It "tolerates a location without an optional directory key" {
        Set-Content -LiteralPath $locationPath -Value "repo: Azure/azure-rest-api-specs`ncommit: main"

        $properties = [PackageProps]::new("azdatalake", "1.0.0", $packageDirectory, "package-props-tests")

        $properties.SpecProjectPath | Should -BeNullOrEmpty
    }

    It "preserves behavior when there is no TypeSpec location file" {
        if (Test-Path -LiteralPath $locationPath) {
            Remove-Item -LiteralPath $locationPath
        }

        $properties = [PackageProps]::new("azdatalake", "1.0.0", $packageDirectory, "package-props-tests")

        $properties.SpecProjectPath | Should -BeNullOrEmpty
    }

    It "returns batch package properties through the changelog caller's lookup under strict mode" {
        Set-Content -LiteralPath $locationPath -Value "batch:`n  - ./internal/generated`n  - ./internal/generated_blob"
        Mock Get-AllPkgProperties {
            return @([PackageProps]::new("azdatalake", "1.0.0", $packageDirectory, "package-props-tests"))
        }

        $properties = Get-PkgProperties -PackageName azdatalake -ServiceDirectory storage

        $properties.ChangeLogPath | Should -Be (Join-Path $packageDirectory "CHANGELOG.md")
        $properties.Version | Should -Be "1.0.0"
        $properties.ReleaseStatus | Should -Be "Unreleased"
        $properties.SpecProjectPath | Should -BeNullOrEmpty
    }
}

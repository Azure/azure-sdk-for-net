<#
```
Invoke-Pester -Output Detailed $PSScriptRoot/Service-Readme-Generation.Tests.ps1

We are testing:
1. Get-dotnet-OnboardedDocsMsPackagesForMoniker function in Docs-ToC.sp1
2. Get-dotnet-PackageLevelReadme function in Docs-ToC.sp1
```
#>

Import-Module Pester

BeforeAll {
    . $PSScriptRoot/../../Language-Settings.ps1
    . $PSScriptRoot/logging.ps1
}

# Test plan:
# 1. Tests on sucessfully building the onboarding package and its package info map.
# 2. Tests on passing error csv file.
# 3. Tests on missing metadata json file.
Describe "Get-OnboardedDocsMsPackagesForMoniker" -Tag "UnitTest" {
    # Passed cases
    It "Build the map of onboarding package to package info" -TestCases @(
        @{ DocRepoLocation = "$PSScriptRoot/inputs"; moniker="latest" }
        @{ DocRepoLocation = "$PSScriptRoot/inputs"; moniker="preview" }
    ) {
        $onboardingPackages = Get-dotnet-OnboardedDocsMsPackagesForMoniker -DocRepoLocation $DocRepoLocation -moniker $moniker
        foreach ($package in $onboardingPackages.GetEnumerator()) {
            $package.Key | Should -Be $package.Value.Name
            $packageValueNormalized = (ConvertTo-Json $package.Value) -replace "`r`n", "`n"
            $packageValueNormalized | Should -Be (Get-Content "$DocRepoLocation/metadata/$moniker/$($package.Key).json" -Raw)
        }
    }

    # Failed cases
    It "Failed to parse package info" -TestCases @(
        @{ DocRepoLocation = "$PSScriptRoot/inputs/exceptions"; moniker="latest" }
        @{ DocRepoLocation = "$PSScriptRoot/inputs/exceptions"; moniker="preview" }
    ) {
        $onboardingPackages = Get-dotnet-OnboardedDocsMsPackagesForMoniker -DocRepoLocation $DocRepoLocation -moniker $moniker
        $onboardingPackages.Value | Should -BeNullOrEmpty
    }
}

# Test plan:
# 1. Tests on getting package level readme sucessfully.
Describe "Get-PackageLevelReadme" -Tag "UnitTest" {
    # Passed cases
    It "Get package level readme readme from package" -TestCases @(
        @{ packageMetadataJson = "$PSScriptRoot/inputs/packageMetadata/1.json"; expectedPackageReadme="resourcemanager.hci" }
        @{ packageMetadataJson = "$PSScriptRoot/inputs/packageMetadata/2.json"; expectedPackageReadme="storage.blobs" }
        @{ packageMetadataJson = "$PSScriptRoot/inputs/packageMetadata/3.json"; expectedPackageReadme="microsoft.rest.clientruntime" }
    ) {
        $packageMetadata = (Get-Content $packageMetadataJson -Raw) | ConvertFrom-Json
        $packageReadme = Get-dotnet-PackageLevelReadme -packageMetadata $packageMetadata
        $packageReadme | Should -Be $expectedPackageReadme
    }
}

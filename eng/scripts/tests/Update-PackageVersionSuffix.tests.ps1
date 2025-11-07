#Requires -Version 7.0
<#
.How-To-Run
You can run the test by pester.

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./Update-PackageVersionSuffix.tests.ps1`

#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

# Source the function from the main script
$scriptContent = Get-Content (Join-Path $PSScriptRoot "../Invoke-GenerateAndBuildV2.ps1") -Raw
$functionPattern = '(?s)function Update-PackageVersionSuffix \{.*?\n\}\n'
if ($scriptContent -match $functionPattern) {
    $functionCode = $Matches[0]
    Invoke-Expression $functionCode
} else {
    throw "Could not extract Update-PackageVersionSuffix function from Invoke-GenerateAndBuildV2.ps1"
}

Describe "Update-PackageVersionSuffix" {
    BeforeAll {
        $testDir = Join-Path ([System.IO.Path]::GetTempPath()) "PackageVersionSuffixTests"
        if (Test-Path $testDir) {
            Remove-Item $testDir -Recurse -Force
        }
        New-Item -Path $testDir -ItemType Directory | Out-Null
    }

    AfterAll {
        if (Test-Path $testDir) {
            Remove-Item $testDir -Recurse -Force
        }
    }

    Context "When sdkReleaseType is 'beta'" {
        It "Should add beta suffix to stable version" {
            $testCsproj = Join-Path $testDir "test-add-beta.csproj"
            $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>1.0.0</Version>
  </PropertyGroup>
</Project>
"@
            Set-Content -Path $testCsproj -Value $csprojContent

            Update-PackageVersionSuffix -csprojPath $testCsproj -sdkReleaseType "beta"

            [xml]$updatedCsproj = Get-Content $testCsproj
            $version = $updatedCsproj.Project.PropertyGroup.Version
            $version | Should -Be "1.0.0-beta.1"
        }

        It "Should not modify version that already has beta suffix" {
            $testCsproj = Join-Path $testDir "test-keep-beta.csproj"
            $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>1.2.0-beta.3</Version>
  </PropertyGroup>
</Project>
"@
            Set-Content -Path $testCsproj -Value $csprojContent

            Update-PackageVersionSuffix -csprojPath $testCsproj -sdkReleaseType "beta"

            [xml]$updatedCsproj = Get-Content $testCsproj
            $version = $updatedCsproj.Project.PropertyGroup.Version
            $version | Should -Be "1.2.0-beta.3"
        }
    }

    Context "When sdkReleaseType is 'stable'" {
        It "Should remove beta suffix from version" {
            $testCsproj = Join-Path $testDir "test-remove-beta.csproj"
            $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>2.0.0-beta.5</Version>
  </PropertyGroup>
</Project>
"@
            Set-Content -Path $testCsproj -Value $csprojContent

            Update-PackageVersionSuffix -csprojPath $testCsproj -sdkReleaseType "stable"

            [xml]$updatedCsproj = Get-Content $testCsproj
            $version = $updatedCsproj.Project.PropertyGroup.Version
            $version | Should -Be "2.0.0"
        }

        It "Should not modify stable version" {
            $testCsproj = Join-Path $testDir "test-keep-stable.csproj"
            $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>3.1.0</Version>
  </PropertyGroup>
</Project>
"@
            Set-Content -Path $testCsproj -Value $csprojContent

            Update-PackageVersionSuffix -csprojPath $testCsproj -sdkReleaseType "stable"

            [xml]$updatedCsproj = Get-Content $testCsproj
            $version = $updatedCsproj.Project.PropertyGroup.Version
            $version | Should -Be "3.1.0"
        }
    }

    Context "Edge cases" {
        It "Should handle missing sdkReleaseType" {
            $testCsproj = Join-Path $testDir "test-no-type.csproj"
            $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>1.0.0</Version>
  </PropertyGroup>
</Project>
"@
            Set-Content -Path $testCsproj -Value $csprojContent

            Update-PackageVersionSuffix -csprojPath $testCsproj -sdkReleaseType ""

            [xml]$updatedCsproj = Get-Content $testCsproj
            $version = $updatedCsproj.Project.PropertyGroup.Version
            $version | Should -Be "1.0.0"
        }

        It "Should handle unknown sdkReleaseType" {
            $testCsproj = Join-Path $testDir "test-unknown-type.csproj"
            $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>1.0.0</Version>
  </PropertyGroup>
</Project>
"@
            Set-Content -Path $testCsproj -Value $csprojContent

            Update-PackageVersionSuffix -csprojPath $testCsproj -sdkReleaseType "unknown"

            [xml]$updatedCsproj = Get-Content $testCsproj
            $version = $updatedCsproj.Project.PropertyGroup.Version
            $version | Should -Be "1.0.0"
        }

        It "Should handle missing csproj file" {
            $testCsproj = Join-Path $testDir "nonexistent.csproj"

            { Update-PackageVersionSuffix -csprojPath $testCsproj -sdkReleaseType "beta" } | Should -Not -Throw
        }
    }
}

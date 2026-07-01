#Requires -Version 7.0
<#
.How-To-Run
This test file uses Pester, a testing framework for PowerShell.
For more information about Pester, see: https://pester.dev/docs/quick-start

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./Validate-CpmCompliance.tests.ps1`

#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe "Validate-CpmCompliance CPM-007" {
    BeforeAll {
        $scriptPath = Join-Path $PSScriptRoot ".." "Validate-CpmCompliance.ps1"
        $repoRoot = (Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")).Path.TrimEnd('\', '/')

        # Fixtures must live under the repo root so the script's Get-RelativePath works,
        # and outside the artifacts/bin/obj folders that the scan excludes.
        $fixtureName = ".cpm-compliance-tests-$([Guid]::NewGuid().ToString('N'))"
        $fixtureRoot = Join-Path $repoRoot $fixtureName

        function New-Fixture([string]$RelativeSubPath, [string]$FileName, [string]$Content) {
            $dir = Join-Path $fixtureRoot $RelativeSubPath
            New-Item -Path $dir -ItemType Directory -Force | Out-Null
            Set-Content -Path (Join-Path $dir $FileName) -Value $Content -NoNewline
        }

        New-Fixture "flag/src" "Test.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageVersion Include="Microsoft.Extensions.Configuration" Version="9.0.5" />
  </ItemGroup>
</Project>
'@

        New-Fixture "noflag/src" "Test.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Azure.Core" />
  </ItemGroup>
</Project>
'@

        New-Fixture "property/src" "Test.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <PackageVersion>1.0.0-beta.1</PackageVersion>
  </PropertyGroup>
</Project>
'@

        New-Fixture "samplesopt/samples" "Sample.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageVersion Include="Newtonsoft.Json" Version="13.0.3" />
  </ItemGroup>
</Project>
'@

        function Invoke-Validator([string]$PackageRelativePath) {
            $output = & $scriptPath -PackagePath (Join-Path $fixtureName $PackageRelativePath) *>&1
            return [pscustomobject]@{
                ExitCode = $LASTEXITCODE
                Output   = ($output | Out-String)
            }
        }
    }

    AfterAll {
        if (Test-Path $fixtureRoot) {
            Remove-Item $fixtureRoot -Recurse -Force
        }
    }

    It "flags an inline PackageVersion item in a csproj" {
        $result = Invoke-Validator "flag"
        $result.ExitCode | Should -Be 1
        $result.Output | Should -Match 'CPM-007'
    }

    It "does not flag a PackageReference without a version" {
        $result = Invoke-Validator "noflag"
        $result.ExitCode | Should -Be 0
        $result.Output | Should -Not -Match 'CPM-007'
    }

    It "does not flag the PackageVersion property form" {
        $result = Invoke-Validator "property"
        $result.ExitCode | Should -Be 0
        $result.Output | Should -Not -Match 'CPM-007'
    }

    It "does not flag PackageVersion items under samples" {
        $result = Invoke-Validator "samplesopt"
        $result.ExitCode | Should -Be 0
        $result.Output | Should -Not -Match 'CPM-007'
    }
}

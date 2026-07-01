#Requires -Version 7.0
<#
.How-To-Run
This test file uses Pester, a testing framework for PowerShell.
For more information about Pester, see: https://pester.dev/docs/quick-start

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./Validate-SampleSelfContainment.tests.ps1`

#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe "Validate-SampleSelfContainment" -Tag "UnitTest" {
    BeforeAll {
        $scriptPath = Join-Path $PSScriptRoot ".." "Validate-SampleSelfContainment.ps1"
        $repoRoot = (Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")).Path.TrimEnd('\', '/')

        # Fixtures live under the repo root so the script's Get-RelativePath works, and each
        # case gets its own samples/<service>/<sample> subtree scanned via -SamplesDirectory.
        $fixtureName = ".sample-selfcontainment-tests-$([Guid]::NewGuid().ToString('N'))"
        $fixtureRoot = Join-Path $repoRoot $fixtureName

        function New-Fixture([string]$RelativeSubPath, [string]$FileName, [string]$Content) {
            $dir = Join-Path $fixtureRoot $RelativeSubPath
            New-Item -Path $dir -ItemType Directory -Force | Out-Null
            Set-Content -Path (Join-Path $dir $FileName) -Value $Content -NoNewline
        }

        # Case: ProjectReference escaping into sdk/
        New-Fixture "escapes/svc/sample" "Bad.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <ProjectReference Include="..\..\..\sdk\agentserver\Foo\src\Foo.csproj" />
  </ItemGroup>
</Project>
'@

        # Case: tests project referencing a sibling src project within the same sample (allowed)
        New-Fixture "intra/svc/sample/tests" "Tests.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <ProjectReference Include="..\src\Sample.csproj" />
  </ItemGroup>
</Project>
'@
        New-Fixture "intra/svc/sample/src" "Sample.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
</Project>
'@

        # Case: ProjectReference relying on an MSBuild property
        New-Fixture "property/svc/sample" "Prop.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <ProjectReference Include="$(RepoRoot)\sdk\agentserver\Foo\src\Foo.csproj" />
  </ItemGroup>
</Project>
'@

        # Case: self-contained sample referencing only published packages (allowed)
        New-Fixture "clean/svc/sample" "Clean.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Azure.Messaging.EventHubs" Version="5.12.2" />
  </ItemGroup>
</Project>
'@

        # Case: Import escaping into eng/
        New-Fixture "importescape/svc/sample" "Imp.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
  <Import Project="..\..\..\eng\Shared.props" />
</Project>
'@

        function Invoke-Validator([string]$CaseRelativePath) {
            $output = & $scriptPath -SamplesDirectory (Join-Path $fixtureName $CaseRelativePath) *>&1
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

    It "flags a ProjectReference that escapes the sample directory" {
        $result = Invoke-Validator "escapes"
        $result.ExitCode | Should -Be 1
        $result.Output | Should -Match 'SAMPLE-001'
    }

    It "allows a tests project referencing a sibling src project in the same sample" {
        $result = Invoke-Validator "intra"
        $result.ExitCode | Should -Be 0
        $result.Output | Should -Not -Match 'SAMPLE-00'
    }

    It "flags a ProjectReference that relies on an MSBuild property" {
        $result = Invoke-Validator "property"
        $result.ExitCode | Should -Be 1
        $result.Output | Should -Match 'SAMPLE-002'
    }

    It "allows a self-contained sample that references only published packages" {
        $result = Invoke-Validator "clean"
        $result.ExitCode | Should -Be 0
        $result.Output | Should -Not -Match 'SAMPLE-00'
    }

    It "flags an Import that escapes the sample directory" {
        $result = Invoke-Validator "importescape"
        $result.ExitCode | Should -Be 1
        $result.Output | Should -Match 'SAMPLE-001'
    }
}

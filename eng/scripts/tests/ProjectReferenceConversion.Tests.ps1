#Requires -Version 7.0
<#
Run with: Invoke-Pester ./eng/scripts/tests/ProjectReferenceConversion.Tests.ps1
These tests evaluate the production conversion ItemGroup without restoring or building SDKs.
#>

BeforeAll {
    $script:repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
    $script:dotnet = (Get-Command dotnet -ErrorAction Stop).Source
    # Resolve an installed MSBuild directly so the tests do not need the repository's pinned SDK.
    $installedSdk = (& $script:dotnet --list-sdks | Select-Object -Last 1)
    if ($installedSdk -notmatch '^(\S+) \[(.+)\]$') {
        throw 'An installed .NET SDK is required.'
    }
    $script:msbuild = Join-Path $Matches[2] "$($Matches[1])/MSBuild.dll"
    [xml] $targets = Get-Content (Join-Path $script:repoRoot 'eng/Directory.Build.Common.targets') -Raw
    $conversion = $targets.Project.ItemGroup | Where-Object {
        $_.Condition -eq "'`$(UseProjectReferenceToAzureClients)' == 'true'"
    }
    if (@($conversion).Count -ne 1) {
        throw 'Expected exactly one production project-reference conversion ItemGroup.'
    }
    # OuterXml adds the inherited namespace declaration to the ItemGroup. MSBuild
    # accepts that declaration on the project root, not on an individual ItemGroup.
    $script:conversion = $conversion.OuterXml.Replace(' xmlns="http://schemas.microsoft.com/developer/msbuild/2003"', '')
    $script:fixtureRoot = Join-Path $TestDrive 'repository'
    foreach ($relativePath in @(
        'sdk/alpha/Azure.Alpha/src/Azure.Alpha.csproj',
        'sdk/core/Azure.Core/src/Azure.Core.csproj',
        'sdk/core/System.ClientModel/src/System.ClientModel.csproj',
        'sdk/deep/nested/package/src/Azure.Nested.csproj',
        'sdk/first/duplicate/src/Azure.Duplicate.csproj',
        'sdk/last/duplicate/src/Azure.Duplicate.csproj',
        'sdk/other/package/tests/Azure.TestsOnly.csproj'
    )) {
        $path = Join-Path $script:fixtureRoot $relativePath
        New-Item -ItemType Directory -Path (Split-Path $path) -Force | Out-Null
        Set-Content $path '<Project />'
    }

    function Get-Conversion {
        param(
            [string] $Items,
            [string] $Enabled = 'true',
            [string] $Framework = 'net8.0'
        )
        $project = Join-Path $TestDrive 'conversion.proj'
        $escapedRoot = [System.Security.SecurityElement]::Escape($script:fixtureRoot) + '/'
        Set-Content $project @"
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <RepoRoot>$escapedRoot</RepoRoot>
    <UseProjectReferenceToAzureClients>$Enabled</UseProjectReferenceToAzureClients>
    <TargetFramework>$Framework</TargetFramework>
  </PropertyGroup>
  <ItemGroup>$Items</ItemGroup>
  $script:conversion
</Project>
"@
        $output = & $script:dotnet $script:msbuild $project -nologo -getItem:PackageReference,ProjectReference,ProjectsToConvert 2>&1
        if ($LASTEXITCODE -ne 0) {
            throw ($output -join "`n")
        }
        return ($output -join "`n" | ConvertFrom-Json).Items
    }

    function Get-ProjectNames($Result) {
        return @($Result.ProjectReference | ForEach-Object { [System.IO.Path]::GetFileName($_.Identity) })
    }
}

Describe 'Package-to-project reference conversion' -Tag UnitTest {
    It 'converts only matching source projects and retains unmatched package metadata' {
        $result = Get-Conversion @'
<PackageReference Include="Azure.Alpha" Version="1.2.3" PrivateAssets="all" />
<PackageReference Include="External.Package" Version="4.5.6" PrivateAssets="all" />
<PackageReference Include="Azure.TestsOnly" Version="1.0.0" />
'@
        @(Get-ProjectNames $result) | Should -Be @('Azure.Alpha.csproj')
        @($result.PackageReference.Identity) | Should -Be @('External.Package', 'Azure.TestsOnly')
        $result.PackageReference[0].Version | Should -Be '4.5.6'
        $result.PackageReference[0].PrivateAssets | Should -Be 'all'
        $result.ProjectsToConvert[0].ProjectPath | Should -Be $result.ProjectReference[0].Identity
    }

    It 'matches package IDs case-insensitively without duplicating source references' {
        $result = Get-Conversion '<PackageReference Include="azure.alpha;AZURE.ALPHA" />'
        @(Get-ProjectNames $result) | Should -Be @('Azure.Alpha.csproj')
        @($result.PackageReference).Count | Should -Be 0
    }

    It 'preserves explicit conversion exclusions case-insensitively' {
        $result = Get-Conversion @'
<PackageReference Include="Azure.Alpha;Azure.Nested" />
<ExcludeFromProjectReferenceToConversion Include="azure.alpha" />
'@
        @(Get-ProjectNames $result) | Should -Be @('Azure.Nested.csproj')
        @($result.PackageReference.Identity) | Should -Be @('Azure.Alpha')
    }

    It 'preserves literal wildcard-like exclusion identities' {
        $result = Get-Conversion @'
<PackageReference Include="Azure.Alpha;Azure.Nested" />
<ExcludeFromProjectReferenceToConversion Include="Azure.A*" />
'@
        # Existing item-vector exclusions match identities literally, not as globs.
        @(Get-ProjectNames $result) | Should -Be @('Azure.Alpha.csproj', 'Azure.Nested.csproj')
        @($result.PackageReference).Count | Should -Be 0
    }

    It 'honors conditional references in each framework evaluation' {
        $items = @'
<PackageReference Include="Azure.Alpha" Condition="'$(TargetFramework)' == 'net8.0'" />
<PackageReference Include="Azure.Nested" Condition="'$(TargetFramework)' == 'net10.0'" />
'@
        @(Get-ProjectNames (Get-Conversion $items -Framework net8.0)) | Should -Be @('Azure.Alpha.csproj')
        @(Get-ProjectNames (Get-Conversion $items -Framework net10.0)) | Should -Be @('Azure.Nested.csproj')
    }

    It 'preserves discovery order and all projects with duplicate source filenames' {
        $result = Get-Conversion '<PackageReference Include="Azure.Nested;Azure.Duplicate;Azure.Alpha" />'
        @(Get-ProjectNames $result) | Should -Be @('Azure.Alpha.csproj', 'Azure.Nested.csproj', 'Azure.Duplicate.csproj', 'Azure.Duplicate.csproj')
        $result.ProjectReference[2].Identity.Replace('\', '/') | Should -Match '/sdk/first/'
        $result.ProjectReference[3].Identity.Replace('\', '/') | Should -Match '/sdk/last/'
    }

    It 'preserves existing project-reference metadata' {
        $result = Get-Conversion @'
<ProjectReference Include="existing.csproj" ReferenceOutputAssembly="false" Aliases="custom" />
<PackageReference Include="Azure.Alpha" />
'@
        $result.ProjectReference[0].Identity | Should -Be 'existing.csproj'
        $result.ProjectReference[0].ReferenceOutputAssembly | Should -Be 'false'
        $result.ProjectReference[0].Aliases | Should -Be 'custom'
        @(Get-ProjectNames $result) | Should -Be @('existing.csproj', 'Azure.Alpha.csproj')
    }

    It 'injects the source-generation analyzer once for <Packages>' -ForEach @(
        @{ Packages = 'Azure.Core' },
        @{ Packages = 'System.ClientModel' },
        @{ Packages = 'Azure.Core;System.ClientModel' }
    ) {
        $result = Get-Conversion "<PackageReference Include=`"$Packages`" />"
        $analyzers = @($result.ProjectReference | Where-Object { $_.Identity -like '*System.ClientModel.SourceGeneration.csproj' })
        $analyzers.Count | Should -Be 1
        $analyzers[0].ReferenceOutputAssembly | Should -Be 'false'
        $analyzers[0].OutputItemType | Should -Be 'Analyzer'
    }

    It 'does not inject the analyzer when the corresponding packages are excluded' {
        $result = Get-Conversion @'
<PackageReference Include="Azure.Core;System.ClientModel;Azure.Alpha" />
<ExcludeFromProjectReferenceToConversion Include="Azure.Core;System.ClientModel" />
'@
        @(Get-ProjectNames $result) | Should -Be @('Azure.Alpha.csproj')
        @($result.PackageReference.Identity) | Should -Be @('Azure.Core', 'System.ClientModel')
    }

    It 'leaves package-reference mode unchanged' {
        $result = Get-Conversion '<PackageReference Include="Azure.Core;Azure.Alpha" />' -Enabled false
        @($result.ProjectReference).Count | Should -Be 0
        @($result.PackageReference.Identity) | Should -Be @('Azure.Core', 'Azure.Alpha')
    }

    It 'does not introduce references when there are no package references' {
        $result = Get-Conversion ''
        @($result.ProjectReference).Count | Should -Be 0
        @($result.ProjectsToConvert).Count | Should -Be 0
    }
}

#Requires -Version 7.0

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Set-StrictMode -Version 3

BeforeAll {
    $engDirectory = Resolve-Path (Join-Path $PSScriptRoot ".." "..")
    $targetsPath = Join-Path $TestDrive "CodeGeneration.targets"
    [xml]$targets = Get-Content (Join-Path $engDirectory "CodeGeneration.targets") -Raw
    # Exercise the real target conditions and dependencies without building the plugin or running npm.
    $targets.SelectSingleNode("//Target[@Name='BuildPlugin']/Exec").SetAttribute("Command", "echo ClientPluginBuilt")
    foreach ($exec in $targets.SelectNodes("//Target[@Name='GenerateCode']/Exec")) {
        $exec.SetAttribute("Command", "echo LibraryGenerated")
    }
    $targets.Save($targetsPath)

    function New-CodeGenerationProject {
        param([string]$Name, [string]$EmitterPackage)

        $directory = Join-Path $TestDrive $Name
        $src = New-Item -ItemType Directory -Path (Join-Path $directory "src") -Force
        if ($EmitterPackage) {
            Set-Content (Join-Path $directory "tsp-location.yaml") "emitterPackageJsonPath: $EmitterPackage"
        }
        $project = Join-Path $src "Test.proj"
        Set-Content $project @"
<Project>
  <PropertyGroup>
    <SkipTspClientInstall>true</SkipTspClientInstall>
  </PropertyGroup>
  <Import Project="$targetsPath" />
</Project>
"@
        return $project
    }

    function Invoke-CodeGenerationTarget {
        param([string]$Project, [string]$Target = "GenerateCode", [string[]]$Properties = @())

        $output = & dotnet msbuild $Project "/t:$Target" /nologo /v:minimal @Properties 2>&1
        $LASTEXITCODE | Should -Be 0 -Because ($output -join "`n")
        return $output -join "`n"
    }
}

Describe "Code generation plugin builds" -Tag "UnitTest" {
    It "selects the plugin for <Name>" -TestCases @(
        @{ Name = "unbranded"; Emitter = "eng/http-client-csharp-emitter-package.json"; BuildPlugin = $true }
        @{ Name = "quoted"; Emitter = '"eng/http-client-csharp-emitter-package.json"'; BuildPlugin = $true }
        @{ Name = "azure"; Emitter = "eng/azure-typespec-http-client-csharp-emitter-package.json"; BuildPlugin = $false }
        @{ Name = "management"; Emitter = "eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json"; BuildPlugin = $false }
        @{ Name = "provisioning"; Emitter = "eng/azure-typespec-http-client-csharp-provisioning-emitter-package.json"; BuildPlugin = $false }
    ) {
        param($Name, $Emitter, $BuildPlugin)

        $project = New-CodeGenerationProject $Name $Emitter
        $output = Invoke-CodeGenerationTarget $project
        $output.Contains("ClientPluginBuilt") | Should -Be $BuildPlugin
        $output | Should -Match "LibraryGenerated"
        if ($BuildPlugin) {
            $output | Should -Match "ClientPluginBuilt[\s\S]*LibraryGenerated"
        }
    }

    It "does not build the plugin or generate code without TypeSpec input" {
        $project = New-CodeGenerationProject "no-typespec"
        $output = Invoke-CodeGenerationTarget $project
        $output | Should -Not -Match "ClientPluginBuilt|LibraryGenerated"
    }

    It "honors SkipBuildPlugin for a library that needs the plugin" {
        $project = New-CodeGenerationProject "skip-plugin" "eng/http-client-csharp-emitter-package.json"
        $output = Invoke-CodeGenerationTarget $project -Properties "/p:SkipBuildPlugin=true"
        $output | Should -Not -Match "ClientPluginBuilt"
        $output | Should -Match "LibraryGenerated"
    }

    It "preserves explicit plugin builds used by RegenPreview" {
        $output = Invoke-CodeGenerationTarget $targetsPath -Target "BuildPlugin" -Properties "/p:TypeSpecInput=temp"
        $output | Should -Match "ClientPluginBuilt"
    }

    It "selects plugin builds during service generation for <Name>" -TestCases @(
        @{ Name = "service-azure"; Emitter = "eng/azure-typespec-http-client-csharp-emitter-package.json"; BuildPlugin = $false }
        @{ Name = "service-unbranded"; Emitter = "eng/http-client-csharp-emitter-package.json"; BuildPlugin = $true }
    ) {
        param($Name, $Emitter, $BuildPlugin)

        $library = New-CodeGenerationProject $Name $Emitter
        $azureLibrary = New-CodeGenerationProject "$Name-azure" "eng/azure-typespec-http-client-csharp-emitter-package.json"
        $nonTypeSpecLibrary = New-CodeGenerationProject "$Name-no-typespec"
        $legacyLibrary = Join-Path $TestDrive "$Name-legacy.proj"
        Set-Content $legacyLibrary "<Project />"
        [xml]$service = Get-Content (Join-Path $engDirectory "service.proj") -Raw
        $serviceTargets = foreach ($targetName in @("InstallTspClient", "BuildPlugin", "GenerateCode")) {
            $service.SelectSingleNode("//Target[@Name='$targetName']").OuterXml
        }
        $project = Join-Path $TestDrive "$Name.proj"
        Set-Content $project @"
<Project>
  <ItemGroup>
    <ProjectReference Include="$library;$azureLibrary;$nonTypeSpecLibrary;$legacyLibrary" />
  </ItemGroup>
  $($serviceTargets -join "`n")
</Project>
"@
        $output = Invoke-CodeGenerationTarget $project
        ([regex]::Matches($output, "ClientPluginBuilt")).Count | Should -Be ([int]$BuildPlugin)
        ([regex]::Matches($output, "LibraryGenerated")).Count | Should -Be 2
        if ($BuildPlugin) {
            $output | Should -Match "ClientPluginBuilt[\s\S]*LibraryGenerated"
        }
    }
}

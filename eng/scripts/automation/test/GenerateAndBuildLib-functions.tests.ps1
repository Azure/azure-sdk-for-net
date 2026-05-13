#Requires -Version 7.0
<#
.How-To-Run
You can run the test by pester.

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./GenerateAndBuildLib-functions.tests.ps1`

#>
. (Join-Path $PSScriptRoot ".." ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)

Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

BeforeAll {
    . $PSScriptRoot/../GenerateAndBuildLib.ps1
}

Describe "update autorest.md" -Tag "UnitTest" {
    BeforeAll {
        copy-item -Path $PSScriptRoot/autorest.test.md -Destination $PSScriptRoot/autorest.md
    }

    it("set multiple input-file") {
        $inputfiles = "https://github.com/Azure/azure-rest-api-specs/blob/b2bddfe2e59b5b14e559e0433b6e6d057bcff95d/specification/purview/data-plane/Azure.Analytics.Purview.Account/preview/2019-11-01-preview/account.json;https://github.com/Azure/azure-rest-api-specs/blob/1424fc4a1f82af852a626c6ab6d1d296b5fe4df1/specification/purview/data-plane/Azure.Analytics.Purview.MetadataPolicies/preview/2021-07-01/purviewMetadataPolicy.json"

        $inputfile = ""
        $fileArray = $inputfiles.Split(";")
        if (($inputfiles -ne "") -And ($fileArray.Length -gt 0)) {
            for ($i = 0; $i -lt $fileArray.Count ; $i++) {
                $inputfile = $inputfile + [Environment]::NewLine + "- " + $fileArray[$i]
            }
        }
        CreateOrUpdateAutorestConfigFile -autorestFilePath $PSScriptRoot/autorest.md -namespace "Azure.Purview.Account" -inputfile "$inputfile"

        $autorestConfigYaml = Get-Content -Path $PSScriptRoot/autorest.md
        $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
        if ( $range.count -gt 1) {
            $startNum = $range[0];
            $lines = $range[1] - $range[0] - 1
            $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
        }

        $yml = ConvertFrom-YAML $autorestConfigYaml
        $inputfile_new = $yml["input-file"]

        $inputfile_new.Count | Should -Be 2
        $inputstr = $inputfile_new -join ";"
        $inputstr | Should -Be $inputfiles
    }

    it("set require and replace input-file") {
        $readme = "https://github.com/Azure/azure-rest-api-specs/specification/purview/data-plane/readme.md"

        CreateOrUpdateAutorestConfigFile -autorestFilePath $PSScriptRoot/autorest.md -namespace "Azure.Purview.Account" -readme "$readme"

        $autorestConfigYaml = Get-Content -Path $PSScriptRoot/autorest.md
        $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
        if ( $range.count -gt 1) {
            $startNum = $range[0];
            $lines = $range[1] - $range[0] - 1
            $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
        }

        $yml = ConvertFrom-YAML $autorestConfigYaml
        
        $inputfile_new = $yml["input-file"]
        $inputfile_new.Count | Should -Be 0

        $require = $yml["require"]
        $require | Should -Be $readme
    }

    it("combine autorest config") {
        $readme = "https://github.com/Azure/azure-rest-api-specs/specification/purview/data-plane/readme.md"
        $autorestConfigYamlInput = Get-Content -Path $PSScriptRoot/config.md
        $range = ($autorestConfigYamlInput | Select-String -Pattern '```').LineNumber
        if ( $range.count -gt 1) {
            $startNum = $range[0];
            $lines = $range[1] - $range[0] - 1
            $autorestConfigYamlInput = ($autorestConfigYamlInput | Select -Skip $startNum | Select -First $lines) |Out-String
        }
        CreateOrUpdateAutorestConfigFile -autorestFilePath $PSScriptRoot/autorest.md -namespace "Azure.Purview.Account" -readme "$readme" -autorestConfigYaml "$autorestConfigYamlInput"

        $autorestConfigYaml = Get-Content -Path $PSScriptRoot/autorest.md
        $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
        if ( $range.count -gt 1) {
            $startNum = $range[0];
            $lines = $range[1] - $range[0] - 1
            $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
        }
        
        $yml = ConvertFrom-YAML $autorestConfigYaml
        
        $title = $yml["title"]
        $title | Should -Be "AzurePurviewAdministration"

        $require = $yml["require"]
        $require | Should -Be $readme
    }
}

# Open an issue to track the disabled tests here: https://github.com/Azure/azure-sdk-for-net/issues/33487
Describe "Generate and Build SDK" -Tag "Unit" {
    BeforeAll {
        $sdkRootPath =  (Join-Path $PSScriptRoot .. .. .. ..)
        $sdkRootPath = Resolve-Path $sdkRootPath
    }
    
    it("generate sdk by readme.md") {
        $readme = "https://github.com/Azure/azure-rest-api-specs/blob/5ee062ac3cc2df298ff47bdfc7792d257fd85bb8/specification/deviceupdate/data-plane/readme.md"

        $generatedSDKPackages = New-Object 'Collections.Generic.List[System.Object]'
        $downloadUrlPrefix = "https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2/"
        Invoke-GenerateAndBuildSDK -readmeAbsolutePath $readme -sdkRootPath $sdkRootPath -downloadUrlPrefix "$downloadUrlPrefix" -generatedSDKPackages $generatedSDKPackages

        $generatedSDKPackages.Count | Should -Be 1
        $generatedSDKPackages[0].packageName | Should -Be "Azure.IoT.DeviceUpdate"
    }
}

Describe "GetSDKProjectFolder function" -Tag "UnitTest" {
    BeforeAll {
        $testTspConfigDir = Join-Path $PSScriptRoot "test-data"
        $testTspConfigFile = Join-Path $testTspConfigDir "tspconfig.yaml"
        
        if (!(Test-Path $testTspConfigDir)) {
            New-Item -ItemType Directory -Path $testTspConfigDir | Out-Null
        }
        
        # Create a test tspconfig.yaml with namespace configuration
        $testConfig = @"
parameters:
  service-dir:
    default: testservice
options:
  "@azure-tools/typespec-csharp":
    namespace: Azure.TestService.Client
    service-dir: testservice
"@
        $testConfig | Out-File -FilePath $testTspConfigFile -Encoding UTF8
    }
    
    AfterAll {
        if (Test-Path $testTspConfigDir) {
            Remove-Item -Recurse -Force $testTspConfigDir
        }
    }
    
    it("should read namespace configuration correctly") {
        $testSdkRoot = "/test/sdk/root"
        $result = GetSDKProjectFolder -typespecConfigurationFile $testTspConfigFile -sdkRepoRoot $testSdkRoot
        $expected = Join-Path $testSdkRoot "testservice" "Azure.TestService.Client"
        $result | Should -Be $expected
    }
    
    it("should prioritize package-dir over namespace when both are present") {
        $testTspConfigFile3 = Join-Path $testTspConfigDir "tspconfig-with-package-dir.yaml"
        $testConfigWithPackageDir = @"
parameters:
  service-dir:
    default: testservice
options:
  "@azure-tools/typespec-csharp":
    package-dir: Azure.TestService.PackageDir
    namespace: Azure.TestService.Client
    service-dir: testservice
"@
        $testConfigWithPackageDir | Out-File -FilePath $testTspConfigFile3 -Encoding UTF8
        
        $testSdkRoot = "/test/sdk/root"
        $result = GetSDKProjectFolder -typespecConfigurationFile $testTspConfigFile3 -sdkRepoRoot $testSdkRoot
        $expected = Join-Path $testSdkRoot "testservice" "Azure.TestService.PackageDir"
        $result | Should -Be $expected
    }
    
    it("should fallback to namespace when package-dir is not present") {
        $testSdkRoot = "/test/sdk/root"
        $result = GetSDKProjectFolder -typespecConfigurationFile $testTspConfigFile -sdkRepoRoot $testSdkRoot
        $expected = Join-Path $testSdkRoot "testservice" "Azure.TestService.Client"
        $result | Should -Be $expected
    }
    
    it("should throw error when namespace is missing") {
        $testTspConfigFile2 = Join-Path $testTspConfigDir "tspconfig-missing-namespace.yaml"
        $testConfigMissingNamespace = @"
parameters:
  service-dir:
    default: testservice
options:
  "@azure-tools/typespec-csharp":
    service-dir: testservice
"@
        $testConfigMissingNamespace | Out-File -FilePath $testTspConfigFile2 -Encoding UTF8
        
        {GetSDKProjectFolder -typespecConfigurationFile $testTspConfigFile2 -sdkRepoRoot "/test"} | Should -Throw "*namespace*"
    }
    
    it("should work with new @azure-typespec/http-client-csharp emitter") {
        $testTspConfigFileNew = Join-Path $testTspConfigDir "tspconfig-new-emitter.yaml"
        $testConfigNewEmitter = @"
parameters:
  service-dir:
    default: testservice
options:
  "@azure-typespec/http-client-csharp":
    namespace: Azure.TestService.NewEmitter
    service-dir: testservice
"@
        $testConfigNewEmitter | Out-File -FilePath $testTspConfigFileNew -Encoding UTF8
        
        $testSdkRoot = "/test/sdk/root"
        $result = GetSDKProjectFolder -typespecConfigurationFile $testTspConfigFileNew -sdkRepoRoot $testSdkRoot
        $expected = Join-Path $testSdkRoot "testservice" "Azure.TestService.NewEmitter"
        $result | Should -Be $expected
    }
    
    it("should prioritize package-dir over namespace with new emitter") {
        $testTspConfigFileNewPackageDir = Join-Path $testTspConfigDir "tspconfig-new-emitter-package-dir.yaml"
        $testConfigNewEmitterPackageDir = @"
parameters:
  service-dir:
    default: testservice
options:
  "@azure-typespec/http-client-csharp":
    package-dir: Azure.TestService.NewEmitter.PackageDir
    namespace: Azure.TestService.NewEmitter
    service-dir: testservice
"@
        $testConfigNewEmitterPackageDir | Out-File -FilePath $testTspConfigFileNewPackageDir -Encoding UTF8
        
        $testSdkRoot = "/test/sdk/root"
        $result = GetSDKProjectFolder -typespecConfigurationFile $testTspConfigFileNewPackageDir -sdkRepoRoot $testSdkRoot
        $expected = Join-Path $testSdkRoot "testservice" "Azure.TestService.NewEmitter.PackageDir"
        $result | Should -Be $expected
    }
    
    it("should prefer old emitter when both are present") {
        $testTspConfigFileBoth = Join-Path $testTspConfigDir "tspconfig-both-emitters.yaml"
        $testConfigBothEmitters = @"
parameters:
  service-dir:
    default: testservice
options:
  "@azure-tools/typespec-csharp":
    namespace: Azure.TestService.OldEmitter
    service-dir: testservice
  "@azure-typespec/http-client-csharp":
    namespace: Azure.TestService.NewEmitter
    service-dir: testservice
"@
        $testConfigBothEmitters | Out-File -FilePath $testTspConfigFileBoth -Encoding UTF8
        
        $testSdkRoot = "/test/sdk/root"
        $result = GetSDKProjectFolder -typespecConfigurationFile $testTspConfigFileBoth -sdkRepoRoot $testSdkRoot
        $expected = Join-Path $testSdkRoot "testservice" "Azure.TestService.OldEmitter"
        $result | Should -Be $expected
    }
    
    it("should throw error when neither emitter has namespace") {
        $testTspConfigFileNoEmitter = Join-Path $testTspConfigDir "tspconfig-no-emitter.yaml"
        $testConfigNoEmitter = @"
parameters:
  service-dir:
    default: testservice
options: {}
"@
        $testConfigNoEmitter | Out-File -FilePath $testTspConfigFileNoEmitter -Encoding UTF8
        
        {GetSDKProjectFolder -typespecConfigurationFile $testTspConfigFileNoEmitter -sdkRepoRoot "/test"} | Should -Throw "*namespace*"
    }

    it("should resolve emitter-output-dir placeholders") {
        $testTspEmitterConfig = Join-Path $testTspConfigDir "tspconfig-emitter-output.yaml"
        $testConfigEmitterOutput = @"
parameters:
    service-dir:
        default: testservice
options:
    "@azure-tools/typespec-csharp":
        namespace: Azure.TestService.Client
        service-dir: sdk/testservice2
        emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
"@
                $testConfigEmitterOutput | Out-File -FilePath $testTspEmitterConfig -Encoding UTF8

                $testSdkRoot = "/test/sdk/root"
                $result = GetSDKProjectFolder -typespecConfigurationFile $testTspEmitterConfig -sdkRepoRoot $testSdkRoot
                $expected = Join-Path $testSdkRoot "sdk" "testservice2" "Azure.TestService.Client"
                $result | Should -Be $expected
    }

    it("should resolve emitter-output-dir without placeholders") {
        $testTspEmitterConfigNoPlaceholder = Join-Path $testTspConfigDir "tspconfig-emitter-output-static.yaml"
        $testConfigEmitterOutputStatic = @"
parameters:
    service-dir:
        default: testservice
options:
    "@azure-tools/typespec-csharp":
        namespace: Azure.TestService2.Client
        service-dir: sdk/testservice2
        emitter-output-dir: "{output-dir}/sdk/testservice/Azure.TestService.Client"
"@
                $testConfigEmitterOutputStatic | Out-File -FilePath $testTspEmitterConfigNoPlaceholder -Encoding UTF8

                $testSdkRoot = "/test/sdk/root"
                $result = GetSDKProjectFolder -typespecConfigurationFile $testTspEmitterConfigNoPlaceholder -sdkRepoRoot $testSdkRoot
                $expected = Join-Path $testSdkRoot "sdk" "testservice" "Azure.TestService.Client"
                $result | Should -Be $expected
    }

    it("should throw when emitter-output-dir uses service-dir placeholder without definition") {
        $testTspEmitterMissingService = Join-Path $testTspConfigDir "tspconfig-emitter-output-missing-service.yaml"
        $testConfigEmitterMissingService = @"
options:
    "@azure-tools/typespec-csharp":
        namespace: Azure.TestService.Client
        emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
"@
        $testConfigEmitterMissingService | Out-File -FilePath $testTspEmitterMissingService -Encoding UTF8

        { GetSDKProjectFolder -typespecConfigurationFile $testTspEmitterMissingService -sdkRepoRoot "/test/sdk/root" } | Should -Throw "*'service-dir'*"
    }

    it("should throw when emitter-output-dir uses namespace placeholder without definition") {
        $testTspEmitterMissingNamespace = Join-Path $testTspConfigDir "tspconfig-emitter-output-missing-namespace.yaml"
        $testConfigEmitterMissingNamespace = @"
parameters:
    service-dir:
        default: testservice
options:
    "@azure-tools/typespec-csharp":
        emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
"@
        $testConfigEmitterMissingNamespace | Out-File -FilePath $testTspEmitterMissingNamespace -Encoding UTF8

        { GetSDKProjectFolder -typespecConfigurationFile $testTspEmitterMissingNamespace -sdkRepoRoot "/test/sdk/root" } | Should -Throw "*'namespace'*"
    }

    it("should interpolate package-name in namespace") {
        $testTspConfigPackageName = Join-Path $testTspConfigDir "tspconfig-package-name-namespace.yaml"
        $testConfigPackageName = @"
parameters:
  service-dir:
    default: testservice
options:
  "@azure-typespec/http-client-csharp-mgmt":
    package-name: Azure.ResourceManager.Compute.Bulkactions
    namespace: "{package-name}"
    service-dir: testservice
"@
        $testConfigPackageName | Out-File -FilePath $testTspConfigPackageName -Encoding UTF8

        $testSdkRoot = "/test/sdk/root"
        $result = GetSDKProjectFolder -typespecConfigurationFile $testTspConfigPackageName -sdkRepoRoot $testSdkRoot
        $expected = Join-Path $testSdkRoot "testservice" "Azure.ResourceManager.Compute.Bulkactions"
        $result | Should -Be $expected
    }

    it("should interpolate package-name in namespace with emitter-output-dir") {
        $testTspConfigPackageNameEmitter = Join-Path $testTspConfigDir "tspconfig-package-name-emitter-output.yaml"
        $testConfigPackageNameEmitter = @"
parameters:
  service-dir:
    default: testservice
options:
  "@azure-typespec/http-client-csharp-mgmt":
    emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
    package-name: Azure.ResourceManager.Compute.Bulkactions
    namespace: "{package-name}"
    service-dir: sdk/compute
"@
        $testConfigPackageNameEmitter | Out-File -FilePath $testTspConfigPackageNameEmitter -Encoding UTF8

        $testSdkRoot = "/test/sdk/root"
        $result = GetSDKProjectFolder -typespecConfigurationFile $testTspConfigPackageNameEmitter -sdkRepoRoot $testSdkRoot
        $expected = Join-Path $testSdkRoot "sdk" "compute" "Azure.ResourceManager.Compute.Bulkactions"
        $result | Should -Be $expected
    }

    it("should interpolate namespace in package-name") {
        $testTspConfigNsInPkgName = Join-Path $testTspConfigDir "tspconfig-ns-in-package-name.yaml"
        $testConfigNsInPkgName = @"
parameters:
  service-dir:
    default: testservice
options:
  "@azure-typespec/http-client-csharp":
    namespace: Azure.TestService.Client
    package-name: "{namespace}"
    service-dir: testservice
"@
        $testConfigNsInPkgName | Out-File -FilePath $testTspConfigNsInPkgName -Encoding UTF8

        $testSdkRoot = "/test/sdk/root"
        $result = GetSDKProjectFolder -typespecConfigurationFile $testTspConfigNsInPkgName -sdkRepoRoot $testSdkRoot
        $expected = Join-Path $testSdkRoot "testservice" "Azure.TestService.Client"
        $result | Should -Be $expected
    }

}

Describe "New-ChangeLogIfNotExists function" -Tag "UnitTest" {
    BeforeAll {
        $script:testProjectDir = Join-Path $PSScriptRoot "test-changelog"
        
        if (!(Test-Path $script:testProjectDir)) {
            New-Item -ItemType Directory -Path $script:testProjectDir | Out-Null
        }
    }
    
    AfterAll {
        if (Test-Path $script:testProjectDir) {
            Remove-Item -Recurse -Force $script:testProjectDir
        }
    }
    
    BeforeEach {
        # Clean up any existing CHANGELOG.md before each test
        $changelogPath = Join-Path $script:testProjectDir "CHANGELOG.md"
        if (Test-Path $changelogPath) {
            Remove-Item $changelogPath
        }
    }
    
    it("should create CHANGELOG.md when it doesn't exist") {
        $version = "1.0.0-beta.1"
        
        New-ChangeLogIfNotExists -projectFolder $script:testProjectDir -version $version
        
        $changelogPath = Join-Path $script:testProjectDir "CHANGELOG.md"
        Test-Path $changelogPath | Should -Be $true
    }
    
    it("should create CHANGELOG.md with correct version") {
        $version = "1.0.0-beta.1"
        
        New-ChangeLogIfNotExists -projectFolder $script:testProjectDir -version $version
        
        $changelogPath = Join-Path $script:testProjectDir "CHANGELOG.md"
        $content = Get-Content $changelogPath -Raw
        $content | Should -Match "1\.0\.0-beta\.1"
    }
    
    it("should create CHANGELOG.md with Release History header") {
        $version = "1.0.0-beta.1"
        
        New-ChangeLogIfNotExists -projectFolder $script:testProjectDir -version $version
        
        $changelogPath = Join-Path $script:testProjectDir "CHANGELOG.md"
        $content = Get-Content $changelogPath -Raw
        $content | Should -Match "# Release History"
    }
    
    it("should create CHANGELOG.md with Unreleased status") {
        $version = "1.0.0-beta.1"
        
        New-ChangeLogIfNotExists -projectFolder $script:testProjectDir -version $version
        
        $changelogPath = Join-Path $script:testProjectDir "CHANGELOG.md"
        $content = Get-Content $changelogPath -Raw
        $content | Should -Match "\(Unreleased\)"
    }
    
    it("should not overwrite existing CHANGELOG.md") {
        $version = "1.0.0-beta.1"
        
        $changelogPath = Join-Path $script:testProjectDir "CHANGELOG.md"
        $existingContent = "# Existing Content"
        Set-Content -Path $changelogPath -Value $existingContent
        
        New-ChangeLogIfNotExists -projectFolder $script:testProjectDir -version $version
        
        $content = Get-Content $changelogPath -Raw
        # Should contain the existing content (ignoring line ending differences)
        $content.Trim() | Should -Be $existingContent.Trim()
    }
    
    it("should handle different version formats") {
        $version = "2.0.0"
        
        New-ChangeLogIfNotExists -projectFolder $script:testProjectDir -version $version
        
        $changelogPath = Join-Path $script:testProjectDir "CHANGELOG.md"
        $content = Get-Content $changelogPath -Raw
        $content | Should -Match "2\.0\.0"
    }
}

Describe "New-MgmtPackageScaffolding function" -Tag "UnitTest" {
    BeforeAll {
        $script:testRootDir = Join-Path ([System.IO.Path]::GetTempPath()) "mgmt-scaffold-test-$(Get-Random)"
        New-Item -ItemType Directory -Path $script:testRootDir -Force | Out-Null

        # Set up a mock SDK structure: sdk/<service>/<package>/
        $script:testService = "horizondb"
        $script:testPackageName = "Azure.ResourceManager.HorizonDb"
        $script:testSdkRoot = Join-Path $script:testRootDir "sdk-root"
        $script:testServiceDir = Join-Path $script:testSdkRoot "sdk" $script:testService
        $script:testProjectDir = Join-Path $script:testServiceDir $script:testPackageName
        $script:testSrcDir = Join-Path $script:testProjectDir "src"

        New-Item -ItemType Directory -Path $script:testSrcDir -Force | Out-Null

        # Copy the real mgmt template into the mock SDK root so Read-MgmtTemplate can find it
        $realTemplateDir = Join-Path $PSScriptRoot ".." ".." ".." ".." "eng" "templates" "Azure.ResourceManager.Template"
        $realTemplateDir = Resolve-Path $realTemplateDir
        $mockTemplateDir = Join-Path $script:testSdkRoot "eng" "templates" "Azure.ResourceManager.Template"
        Copy-Item -Path $realTemplateDir -Destination $mockTemplateDir -Recurse -Force

        # Create a minimal .csproj (simulating emitter output)
        $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>1.0.0-beta.1</Version>
  </PropertyGroup>
</Project>
"@
        Set-Content -Path (Join-Path $script:testSrcDir "$($script:testPackageName).csproj") -Value $csprojContent

        # Create a minimal .sln (simulating emitter output)
        $slnContent = @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.0.31903.59
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "$($script:testPackageName)", "src\$($script:testPackageName).csproj", "{00000000-0000-0000-0000-000000000001}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{00000000-0000-0000-0000-000000000001}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{00000000-0000-0000-0000-000000000001}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{00000000-0000-0000-0000-000000000001}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{00000000-0000-0000-0000-000000000001}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
EndGlobal
"@
        Set-Content -Path (Join-Path $script:testProjectDir "$($script:testPackageName).sln") -Value $slnContent
    }

    AfterAll {
        if (Test-Path $script:testRootDir) {
            Remove-Item -Recurse -Force $script:testRootDir
        }
    }

    It "should create ci.mgmt.yml in the service directory" {
        New-MgmtPackageScaffolding `
            -sdkProjectFolder $script:testProjectDir `
            -packageName $script:testPackageName `
            -sdkRootPath $script:testSdkRoot

        $ciPath = Join-Path $script:testSdkRoot "sdk" $script:testService "ci.mgmt.yml"
        Test-Path $ciPath | Should -Be $true
    }

    It "should create ci.mgmt.yml with correct service directory and artifact" {
        $ciPath = Join-Path $script:testSdkRoot "sdk" $script:testService "ci.mgmt.yml"
        $content = Get-Content $ciPath -Raw
        $content | Should -Match "ServiceDirectory: horizondb"
        $content | Should -Match "name: Azure.ResourceManager.HorizonDb"
        $content | Should -Match "safeName: AzureResourceManagerHorizonDb"
    }

    It "should create Directory.Build.props" {
        $propsPath = Join-Path $script:testProjectDir "Directory.Build.props"
        Test-Path $propsPath | Should -Be $true
        $content = Get-Content $propsPath -Raw
        $content | Should -Match "Directory\.Build\.props"
    }

    It "should create README.md with package name" {
        $readmePath = Join-Path $script:testProjectDir "README.md"
        Test-Path $readmePath | Should -Be $true
        $content = Get-Content $readmePath -Raw
        $content | Should -Match "Azure\.ResourceManager\.HorizonDb"
        $content | Should -Match "dotnet add package"
    }

    It "should create CHANGELOG.md" {
        $changelogPath = Join-Path $script:testProjectDir "CHANGELOG.md"
        Test-Path $changelogPath | Should -Be $true
        $content = Get-Content $changelogPath -Raw
        $content | Should -Match "Release History"
    }

    It "should create AssemblyInfo.cs with correct provider namespace" {
        $asmInfoPath = Join-Path $script:testProjectDir "src" "Properties" "AssemblyInfo.cs"
        Test-Path $asmInfoPath | Should -Be $true
        $content = Get-Content $asmInfoPath -Raw
        $content | Should -Match 'AzureResourceProviderNamespace\("Microsoft\.HorizonDb"\)'
        $content | Should -Match "InternalsVisibleTo.*Azure\.ResourceManager\.HorizonDb\.Tests"
    }

    It "should create test project csproj" {
        $testCsprojPath = Join-Path $script:testProjectDir "tests" "$($script:testPackageName).Tests.csproj"
        Test-Path $testCsprojPath | Should -Be $true
        $content = Get-Content $testCsprojPath -Raw
        $content | Should -Match "ProjectReference.*src.*$([regex]::Escape($script:testPackageName))\.csproj"
    }

    It "should create test base class" {
        $testBasePath = Join-Path $script:testProjectDir "tests" "HorizonDbManagementTestBase.cs"
        Test-Path $testBasePath | Should -Be $true
        $content = Get-Content $testBasePath -Raw
        $content | Should -Match "class HorizonDbManagementTestBase"
        $content | Should -Match "ManagementRecordedTestBase<HorizonDbManagementTestEnvironment>"
    }

    It "should create test environment class" {
        $testEnvPath = Join-Path $script:testProjectDir "tests" "HorizonDbManagementTestEnvironment.cs"
        Test-Path $testEnvPath | Should -Be $true
        $content = Get-Content $testEnvPath -Raw
        $content | Should -Match "class HorizonDbManagementTestEnvironment"
        $content | Should -Match "TestEnvironment"
    }

    It "should not overwrite existing files when called again" {
        # Modify README to have custom content
        $readmePath = Join-Path $script:testProjectDir "README.md"
        $customContent = "# Custom README content"
        Set-Content -Path $readmePath -Value $customContent

        # Call scaffolding again
        New-MgmtPackageScaffolding `
            -sdkProjectFolder $script:testProjectDir `
            -packageName $script:testPackageName `
            -sdkRootPath $script:testSdkRoot

        # Verify README was not overwritten
        $content = Get-Content $readmePath -Raw
        $content.Trim() | Should -Be $customContent
    }

    It "should handle multi-segment provider names correctly" {
        $multiSegDir = Join-Path $script:testRootDir "multi-seg"
        $multiSegService = "compute"
        $multiSegPkg = "Azure.ResourceManager.Compute.Bulkactions"
        $multiSegSdkRoot = Join-Path $multiSegDir "sdk-root"
        $multiSegProjectDir = Join-Path $multiSegSdkRoot "sdk" $multiSegService $multiSegPkg
        $multiSegSrcDir = Join-Path $multiSegProjectDir "src"
        New-Item -ItemType Directory -Path $multiSegSrcDir -Force | Out-Null

        # Copy template into this mock SDK root too
        $realTemplateDir = Join-Path $PSScriptRoot ".." ".." ".." ".." "eng" "templates" "Azure.ResourceManager.Template"
        $realTemplateDir = Resolve-Path $realTemplateDir
        $mockTemplateDir = Join-Path $multiSegSdkRoot "eng" "templates" "Azure.ResourceManager.Template"
        Copy-Item -Path $realTemplateDir -Destination $mockTemplateDir -Recurse -Force

        $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>1.0.0-beta.1</Version>
  </PropertyGroup>
</Project>
"@
        Set-Content -Path (Join-Path $multiSegSrcDir "$multiSegPkg.csproj") -Value $csprojContent

        New-MgmtPackageScaffolding `
            -sdkProjectFolder $multiSegProjectDir `
            -packageName $multiSegPkg `
            -sdkRootPath $multiSegSdkRoot

        # Provider should be Microsoft.Compute.Bulkactions
        $asmInfoPath = Join-Path $multiSegProjectDir "src" "Properties" "AssemblyInfo.cs"
        $content = Get-Content $asmInfoPath -Raw
        $content | Should -Match 'AzureResourceProviderNamespace\("Microsoft\.Compute\.Bulkactions"\)'

        # Test class names should use last segment
        $testBasePath = Join-Path $multiSegProjectDir "tests" "BulkactionsManagementTestBase.cs"
        Test-Path $testBasePath | Should -Be $true
    }

    It "should find .slnx solution file when .sln does not exist" {
        # Remove the .sln and create a .slnx instead
        $slnPath = Join-Path $script:testProjectDir "$($script:testPackageName).sln"
        $slnxPath = Join-Path $script:testProjectDir "$($script:testPackageName).slnx"
        if (Test-Path $slnPath) { Remove-Item $slnPath }
        # Create a minimal .slnx (XML-based solution format)
        $slnxContent = @"
<Solution>
  <Project Path="src\$($script:testPackageName).csproj" />
</Solution>
"@
        Set-Content -Path $slnxPath -Value $slnxContent

        New-MgmtPackageScaffolding `
            -sdkProjectFolder $script:testProjectDir `
            -packageName $script:testPackageName `
            -sdkRootPath $script:testSdkRoot

        # Verify the .slnx still exists (wasn't replaced with .sln)
        Test-Path $slnxPath | Should -Be $true
        Test-Path $slnPath | Should -Be $false

        # Restore the .sln for other tests
        Remove-Item $slnxPath
        $slnContent = @"
Microsoft Visual Studio Solution File, Format Version 12.00
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "$($script:testPackageName)", "src\$($script:testPackageName).csproj", "{00000000-0000-0000-0000-000000000001}"
EndProject
Global
EndGlobal
"@
        Set-Content -Path $slnPath -Value $slnContent
    }

    It "should update existing ci.mgmt.yml when it already exists" {
        # Create a second package in same service directory to test ci.mgmt.yml update path
        $secondPkg = "Azure.ResourceManager.HorizonDb.SecondPkg"
        $secondProjectDir = Join-Path $script:testServiceDir $secondPkg
        $secondSrcDir = Join-Path $secondProjectDir "src"
        New-Item -ItemType Directory -Path $secondSrcDir -Force | Out-Null

        $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>1.0.0-beta.1</Version>
  </PropertyGroup>
</Project>
"@
        Set-Content -Path (Join-Path $secondSrcDir "$secondPkg.csproj") -Value $csprojContent

        New-MgmtPackageScaffolding `
            -sdkProjectFolder $secondProjectDir `
            -packageName $secondPkg `
            -sdkRootPath $script:testSdkRoot

        # ci.mgmt.yml should contain both packages
        $ciPath = Join-Path $script:testSdkRoot "sdk" $script:testService "ci.mgmt.yml"
        $content = Get-Content $ciPath -Raw
        $content | Should -Match "Azure\.ResourceManager\.HorizonDb"
        $content | Should -Match "Azure\.ResourceManager\.HorizonDb\.SecondPkg"
    }
}

Describe "New-MgmtPackageScaffolding multi-segment package" -Tag "UnitTest" {
    # Regression test: for multi-segment packages like Azure.ResourceManager.Compute.Bulkactions
    # placed under sdk/compute/, the ci.mgmt.yml ServiceDirectory must be the actual service
    # directory leaf ("compute"), not the package's last segment ("bulkactions").
    BeforeAll {
        $script:msTestRootDir = Join-Path ([System.IO.Path]::GetTempPath()) "mgmt-scaffold-ms-test-$(Get-Random)"
        New-Item -ItemType Directory -Path $script:msTestRootDir -Force | Out-Null

        $script:msService = "compute"
        $script:msPackageName = "Azure.ResourceManager.Compute.Bulkactions"
        $script:msSdkRoot = Join-Path $script:msTestRootDir "sdk-root"
        $script:msServiceDir = Join-Path $script:msSdkRoot "sdk" $script:msService
        $script:msProjectDir = Join-Path $script:msServiceDir $script:msPackageName
        $script:msSrcDir = Join-Path $script:msProjectDir "src"

        New-Item -ItemType Directory -Path $script:msSrcDir -Force | Out-Null

        $realTemplateDir = Join-Path $PSScriptRoot ".." ".." ".." ".." "eng" "templates" "Azure.ResourceManager.Template"
        $realTemplateDir = Resolve-Path $realTemplateDir
        $mockTemplateDir = Join-Path $script:msSdkRoot "eng" "templates" "Azure.ResourceManager.Template"
        Copy-Item -Path $realTemplateDir -Destination $mockTemplateDir -Recurse -Force

        $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>1.0.0-beta.1</Version>
  </PropertyGroup>
</Project>
"@
        Set-Content -Path (Join-Path $script:msSrcDir "$($script:msPackageName).csproj") -Value $csprojContent
    }

    AfterAll {
        if (Test-Path $script:msTestRootDir) {
            Remove-Item -Recurse -Force $script:msTestRootDir
        }
    }

    It "should derive ServiceDirectory from the service folder, not the package's last segment" {
        New-MgmtPackageScaffolding `
            -sdkProjectFolder $script:msProjectDir `
            -packageName $script:msPackageName `
            -sdkRootPath $script:msSdkRoot

        $ciPath = Join-Path $script:msSdkRoot "sdk" $script:msService "ci.mgmt.yml"
        $content = Get-Content $ciPath -Raw
        $content | Should -Match "ServiceDirectory: compute"
        $content | Should -Not -Match "ServiceDirectory: bulkactions"
        $content | Should -Match "name: Azure.ResourceManager.Compute.Bulkactions"
    }
}
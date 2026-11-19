#Requires -Version 7.0
<#
Run with PowerShell 7:
Invoke-Pester eng/scripts/tests/Invoke-GenerateAndBuildV2-TypeSpecEmitter.tests.ps1
#>
. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" "PSModule-Helpers.ps1")
if (-not (Get-Module Pester)) {
    Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module
}
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

BeforeDiscovery {
    $contractCases = @(
        @{ Name = "provided"; Json = '{"typespecEmitter":"@test/http-client-csharp-alternate"}'; Explicit = $true },
        @{ Name = "omitted"; Json = '{}'; Explicit = $false },
        @{ Name = "empty"; Json = '{"typespecEmitter":""}'; Explicit = $false },
        @{ Name = "null"; Json = '{"typespecEmitter":null}'; Explicit = $false },
        @{ Name = "whitespace"; Json = '{"typespecEmitter":"  "}'; Explicit = $false }
    )
}

BeforeAll {
    . (Join-Path $PSScriptRoot ".." "automation" "GenerateAndBuildLib.ps1")
    function npm { throw "npm must be mocked in these tests." }

    $scriptPath = Join-Path $PSScriptRoot ".." "Invoke-GenerateAndBuildV2.ps1"
    $integrationScriptRoot = Split-Path $scriptPath -Parent
    $ast = [System.Management.Automation.Language.Parser]::ParseFile($scriptPath, [ref]$null, [ref]$null)
    # Run the actual input assignments and TypeSpec branch without the unrelated AutoRest flow or exit.
    $inputAssignments = $ast.EndBlock.Statements | Where-Object {
        $_ -is [System.Management.Automation.Language.AssignmentStatementAst] -and
        $_.Left.Extent.Text -in @('$inputJson', '$typespecEmitter')
    }
    $readContract = [scriptblock]::Create(($inputAssignments.Extent.Text -join "`n"))
    $typeSpecBranch = $ast.EndBlock.Statements | Where-Object {
        $_ -is [System.Management.Automation.Language.IfStatementAst] -and
        $_.Clauses[0].Item1.Extent.Text -eq '$relatedTypeSpecProjectFolder'
    }
    $typeSpecBranch | Should -HaveCount 1
    $generateTypeSpec = [scriptblock]::Create($typeSpecBranch.Extent.Text.Replace('$PSScriptRoot', '$integrationScriptRoot'))
    foreach ($function in $ast.EndBlock.Statements | Where-Object {
        $_ -is [System.Management.Automation.Language.FunctionDefinitionAst]
    }) {
        . ([scriptblock]::Create($function.Extent.Text))
    }
}

Describe "Unified pipeline TypeSpec emitter contract" -Tag "UnitTest" {
    BeforeEach {
        $sdkPath = Join-Path $TestDrive "sdk repo"
        $swaggerDir = Join-Path $TestDrive "spec repo"
        $relatedTypeSpecProjectFolder = @("service")
        $configFolder = Join-Path $sdkPath "eng"
        $specFolder = Join-Path $swaggerDir "service"
        New-Item -ItemType Directory -Path $configFolder, $specFolder -Force | Out-Null
        $descriptorPath = Join-Path $configFolder "alternate-emitter-package.json"
        '{"dependencies":{"@test/http-client-csharp-alternate":"1.0.0"}}' | Set-Content $descriptorPath
        @'
supportedEmitters:
  - name: "@test/http-client-csharp-alternate"
    path: eng/alternate-emitter-package.json
'@ | Set-Content (Join-Path $configFolder "tsp-client-config.yaml")
        $tspConfigFile = Join-Path $specFolder "tspconfig.yaml"
        @'
options:
  "@azure-typespec/http-client-csharp":
    namespace: Azure.Default
    service-dir: sdk/default
    emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
  "@test/http-client-csharp-alternate":
    namespace: Azure.Alternate
    service-dir: sdk/alternate
    emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
'@ | Set-Content $tspConfigFile
        $defaultFolder = Join-Path $sdkPath "sdk" "default" "Azure.Default"
        $alternateFolder = Join-Path $sdkPath "sdk" "alternate" "Azure.Alternate"
        New-Item -ItemType Directory -Path $defaultFolder, $alternateFolder -Force | Out-Null
        $inputJsonFile = Join-Path $TestDrive "generateInput.json"
        $repoHttpsUrl = "https://github.com/Azure/azure-rest-api-specs"
        $commitid = "0123456789012345678901234567890123456789"
        $apiVersion = $null
        $sdkReleaseType = $null
        $downloadUrlPrefix = $null
        $exitCode = 0
        $generatedSDKPackages = [Collections.Generic.List[object]]::new()
        $script:npmCalls = @()
        Mock npm {
            $script:npmCalls += ,@($args)
            $global:LASTEXITCODE = 0
        }
        Mock Install-ModuleIfNotInstalled { Get-Module powershell-yaml }
        Mock GeneratePackage {
            $generatedSDKPackages.Add(@{ packageName = Split-Path $projectFolder -Leaf; result = "succeeded" })
        }
        Mock Test-MgmtSdkUsingNewGenerator { $false }
        Mock Test-DpgSdkUsingNewGenerator { $false }
    }

    It "handles <Name> typespecEmitter" -ForEach $contractCases {
        $Json | Set-Content $inputJsonFile
        . $readContract
        . $generateTypeSpec

        $initCalls = @($script:npmCalls | Where-Object { $_ -contains "init" })
        $initCalls | Should -HaveCount 1
        $initArguments = $initCalls[0]
        $initArguments | Should -Contain "--update-if-exists"
        $initArguments | Should -Contain "$tspConfigFile"
        $initArguments | Should -Contain "$specFolder"
        $initArguments | Should -Contain $commitid
        if ($Explicit) {
            $initArguments | Should -Contain "--emitter-package-json-path"
            $index = [array]::IndexOf($initArguments, "--emitter-package-json-path")
            $initArguments[$index + 1] | Should -Be $descriptorPath
            Should -Invoke GeneratePackage -Times 1 -Exactly -ParameterFilter { $projectFolder -eq $alternateFolder }
            $generatedSDKPackages[0].packageName | Should -Be "Azure.Alternate"
        } else {
            $initArguments | Should -Not -Contain "--emitter-package-json-path"
            Should -Invoke GeneratePackage -Times 1 -Exactly -ParameterFilter { $projectFolder -eq $defaultFolder }
            $generatedSDKPackages[0].packageName | Should -Be "Azure.Default"
        }
        $exitCode | Should -Be 0
    }

    It "rejects unsupported emitters before invoking npm" {
        '{"typespecEmitter":"@test/unsupported"}' | Set-Content $inputJsonFile
        . $readContract
        { . $generateTypeSpec } | Should -Throw "*is not supported*"
        Should -Invoke npm -Times 0 -Exactly
    }

    It "rejects missing registered package descriptors" {
        Remove-Item $descriptorPath
        { Get-TypeSpecEmitterPackageJsonPath -typespecEmitter "@test/http-client-csharp-alternate" -sdkRepoRoot $sdkPath } |
            Should -Throw "*was not found*"
    }

    It "does not fall back when the selected emitter has no options" {
        { GetSDKProjectFolder -typespecConfigurationFile $tspConfigFile -sdkRepoRoot $sdkPath -typespecEmitter "@test/unsupported" } |
            Should -Throw "*Options for TypeSpec emitter*were not found*"
    }

    It "preserves generation failure reporting for a selected emitter" {
        '{"typespecEmitter":"@test/http-client-csharp-alternate"}' | Set-Content $inputJsonFile
        . $readContract
        Mock npm {
            $global:LASTEXITCODE = if ($args -contains "init") { 42 } else { 0 }
        }
        . $generateTypeSpec
        $exitCode | Should -Be 42
        $generatedSDKPackages[0].result | Should -Be "failed"
        Should -Invoke GeneratePackage -Times 0 -Exactly
    }
}

#Requires -Version 7.0

BeforeAll {
    . (Join-Path $PSScriptRoot ".." "automation" "GenerateAndBuildLib.ps1")
}

Describe "Get-ApiCompatBreakingChangeItems" -Tag "UnitTest" {
    It "returns only ApiCompat diagnostics" {
        $logFilePath = Join-Path $TestDrive "log.txt"
        @(
            "error CS1002: ; expected [/repo/sdk/network/Azure.ResourceManager.Network/src/Azure.ResourceManager.Network.csproj]"
            "error CP0002: Member 'void Example.OldMethod()' does not exist [/repo/sdk/network/Azure.ResourceManager.Network/src/Azure.ResourceManager.Network.csproj::TargetFramework=net8.0]"
        ) | Set-Content $logFilePath

        Get-ApiCompatBreakingChangeItems -logFilePath $logFilePath | Should -Be @(
            "Member 'void Example.OldMethod()' does not exist"
        )
    }

    It "recognizes repository ApiCompat validation failures without CP diagnostics" {
        $logFilePath = Join-Path $TestDrive "log.txt"
        "error : ApiCompatVersion is missing from Azure.ResourceManager.Network. [/repo/sdk/network/Azure.ResourceManager.Network/src/Azure.ResourceManager.Network.csproj]" |
            Set-Content $logFilePath

        Test-ApiCompatFailure -logFilePath $logFilePath | Should -BeTrue
    }
}

Describe "GeneratePackage spec pull request validation" -Tag "UnitTest" {
    BeforeEach {
        $script:sdkRootPath = Join-Path $TestDrive "repo"
        $script:projectFolder = Join-Path $sdkRootPath "sdk" "network" "Azure.ResourceManager.Network"
        $script:srcPath = Join-Path $projectFolder "src"
        $script:logFilePath = Join-Path $srcPath "log.txt"
        $script:artifactPath = Join-Path $sdkRootPath "artifacts" "packages" "Release" "Azure.ResourceManager.Network"
        $script:exportApiArgumentsPath = Join-Path $sdkRootPath "export-api-arguments.txt"
        $script:dotnetCalls = @()
        $script:dotnetExitCodes = @(0)
        $script:dotnetCallIndex = 0

        New-Item -ItemType Directory -Path $srcPath -Force | Out-Null
        New-Item -ItemType Directory -Path $artifactPath -Force | Out-Null
        New-Item -ItemType Directory -Path (Join-Path $sdkRootPath "eng" "scripts") -Force | Out-Null
        '<Project />' | Set-Content (Join-Path $srcPath "Azure.ResourceManager.Network.csproj")
        "package" | Set-Content (Join-Path $artifactPath "Azure.ResourceManager.Network.1.0.0.nupkg")
        @'
param(
    [string]$PackagePath,
    [string]$SdkRepoPath
)
"$PackagePath|$SdkRepoPath" | Set-Content (Join-Path $SdkRepoPath "export-api-arguments.txt")
'@ | Set-Content (Join-Path $sdkRootPath "eng" "scripts" "Export-API.ps1")

        Mock dotnet {
            $script:dotnetCalls += ,@($args)
            $global:LASTEXITCODE = $script:dotnetExitCodes[$script:dotnetCallIndex]
            $script:dotnetCallIndex++
        }
    }

    It "uses one package-scoped Release pack and exports only that package" {
        $generatedSDKPackages = [System.Collections.ArrayList]::new()

        GeneratePackage `
            -projectFolder $projectFolder `
            -sdkRootPath $sdkRootPath `
            -path "sdk/network/Azure.ResourceManager.Network" `
            -downloadUrlPrefix "https://example.test" `
            -serviceType "resource-manager" `
            -runMode "spec-pull-request" `
            -skipGenerate `
            -generatedSDKPackages $generatedSDKPackages

        $dotnetCalls.Count | Should -Be 1
        $dotnetCalls[0] | Should -Be @(
            "pack"
            $srcPath
            "--configuration"
            "Release"
            "/p:ValidateRunApiCompat=true"
            "/flp:v=m;LogFile=$logFilePath"
        )
        Get-Content $exportApiArgumentsPath | Should -Be "$projectFolder|$sdkRootPath"
        $generatedSDKPackages[0].result | Should -Be "succeeded"
    }

    It "retries without API compatibility only for an ApiCompat failure" {
        $script:dotnetExitCodes = @(1, 0)
        Mock dotnet {
            $script:dotnetCalls += ,@($args)
            if ($script:dotnetCallIndex -eq 0) {
                "error CP0002: Member 'void Example.OldMethod()' does not exist [$srcPath/Azure.ResourceManager.Network.csproj::TargetFramework=net8.0]" |
                    Set-Content $logFilePath
            }
            $global:LASTEXITCODE = $script:dotnetExitCodes[$script:dotnetCallIndex]
            $script:dotnetCallIndex++
        }
        $generatedSDKPackages = [System.Collections.ArrayList]::new()

        GeneratePackage `
            -projectFolder $projectFolder `
            -sdkRootPath $sdkRootPath `
            -path "sdk/network/Azure.ResourceManager.Network" `
            -serviceType "data-plane" `
            -runMode "spec-pull-request" `
            -skipGenerate `
            -generatedSDKPackages $generatedSDKPackages

        $dotnetCalls.Count | Should -Be 2
        $dotnetCalls[1] | Should -Be @(
            "pack"
            $srcPath
            "--configuration"
            "Release"
            "/p:RunApiCompat=false"
        )
        $generatedSDKPackages[0].changelog.hasBreakingChange | Should -BeTrue
        $generatedSDKPackages[0].changelog.breakingChangeItems | Should -Be @(
            "Member 'void Example.OldMethod()' does not exist"
        )
    }

    It "does not retry an unrelated pack failure" {
        $script:dotnetExitCodes = @(1)
        Mock dotnet {
            $script:dotnetCalls += ,@($args)
            "error CS1002: ; expected [$srcPath/Azure.ResourceManager.Network.csproj]" | Set-Content $logFilePath
            $global:LASTEXITCODE = $script:dotnetExitCodes[$script:dotnetCallIndex]
            $script:dotnetCallIndex++
        }
        $generatedSDKPackages = [System.Collections.ArrayList]::new()

        GeneratePackage `
            -projectFolder $projectFolder `
            -sdkRootPath $sdkRootPath `
            -path "sdk/network/Azure.ResourceManager.Network" `
            -serviceType "data-plane" `
            -runMode "spec-pull-request" `
            -skipGenerate `
            -generatedSDKPackages $generatedSDKPackages

        $dotnetCalls.Count | Should -Be 1
        $generatedSDKPackages[0].result | Should -Be "warning"
        $generatedSDKPackages[0].changelog.hasBreakingChange | Should -BeFalse
    }

    It "retries a repository ApiCompat validation failure without marking a breaking change" {
        $script:dotnetExitCodes = @(1, 0)
        Mock dotnet {
            $script:dotnetCalls += ,@($args)
            if ($script:dotnetCallIndex -eq 0) {
                "error : ApiCompatVersion is missing from Azure.ResourceManager.Network. [$srcPath/Azure.ResourceManager.Network.csproj]" |
                    Set-Content $logFilePath
            }
            $global:LASTEXITCODE = $script:dotnetExitCodes[$script:dotnetCallIndex]
            $script:dotnetCallIndex++
        }
        $generatedSDKPackages = [System.Collections.ArrayList]::new()

        GeneratePackage `
            -projectFolder $projectFolder `
            -sdkRootPath $sdkRootPath `
            -path "sdk/network/Azure.ResourceManager.Network" `
            -serviceType "data-plane" `
            -runMode "spec-pull-request" `
            -skipGenerate `
            -generatedSDKPackages $generatedSDKPackages

        $dotnetCalls.Count | Should -Be 2
        $dotnetCalls[1] | Should -Contain "/p:RunApiCompat=false"
        $generatedSDKPackages[0].result | Should -Be "warning"
        $generatedSDKPackages[0].changelog.hasBreakingChange | Should -BeFalse
    }
}
